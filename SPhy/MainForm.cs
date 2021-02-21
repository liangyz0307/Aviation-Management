using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ESBasic;
using OMCS.Passive;
using System.Configuration;
using ESPlus.Application.Basic;
using ESPlus.Application.CustomizeInfo.Passive;
using ESPlus.Rapid;
using ESPlus.Serialization;
using ESBasic.ObjectManagement.Managers;
using ESBasic.ObjectManagement.Forms;
using ESPlus.FileTransceiver;
using System.IO;
using ESFramework;
using OMCS;
using ESPlus.Application.Group;
using System.Net;
using ESFramework.Boost.DynamicGroup.Passive;
using ESFramework.Boost.Controls;
using OMCS.Boost;
using ESFramework.Boost.NetworkDisk.Passive;
using OVCS.Core;
namespace OVCS
{
    public delegate TabPage CbCreateTabpage(string userID);
    public partial class MainForm : Form
    {        
        private IMultimediaManager multimediaManager = null;
        private IRapidPassiveEngine rapidPassiveEngine = null;    
        
        private string currentUserID;       
        private string roomID;         
        private int messageCount = 0;      
        private bool currentPageIsIM = false;
        private bool shareDesk = false;      
        private ObjectManager<string, TabPage> outTabPages = new ObjectManager<string, TabPage>();        
        private FormManager<string, SystemSettingForm> configFormManager = new FormManager<string, SystemSettingForm>();      
        private IDynamicGroupOutter groupOutter;
        private System.Threading.Timer timer;

        public MainForm()
        {
            InitializeComponent();            
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = this.textChatControl1.ButtonSend;                      
        }       

        #region Initialize
        public void Initialize(IRapidPassiveEngine _rapidPassiveEngine, IMultimediaManager _multimediaManager, IDynamicGroupOutter dynaGroupOutter, string userID, string _roomID)
        {
            this.Cursor = Cursors.WaitCursor;

            this.rapidPassiveEngine = _rapidPassiveEngine;
            this.multimediaManager = _multimediaManager;
            this.groupOutter = dynaGroupOutter;
            this.currentUserID = userID;      
            this.roomID = _roomID;                      
                          
            MultimediaManagerHelper.WaitUtilAvailable(this.multimediaManager, 30);

            this.Text += " - 房间：" + this.roomID;
            this.toolStripLabel_User.Text = "当前登录:" + this.currentUserID;              
           
            this.textChatControl1.Initialize(this.currentUserID, this.roomID, this.groupOutter);            
            
            this.whiteBoardConnector1.AutoReconnect = false;
            this.whiteBoardConnector1.ConnectEnded += new ESBasic.CbGeneric<OMCS.Passive.ConnectResult>(whiteBoardConnector1_ConnectEnded);

            this.rapidPassiveEngine.BasicOutter.BeingPushedOut += new CbGeneric(BasicOutter_BeingPushedOut);
            this.rapidPassiveEngine.ConnectionInterrupted += new CbGeneric(TcpPassiveEngine_ConnectionInterrupted);      
            this.multimediaManager.ConnectionInterrupted += new CbGeneric<IPEndPoint>(multimediaManager_ConnectionInterrupted);   
           
            this.groupOutter.BroadcastReceived += new CbGeneric<string, string, int, byte[]>(GroupOutter_BroadcastReceived);
            this.groupOutter.SomeoneQuitGroup += new CbGeneric<string, string>(GroupOutter_SomeoneQuitGroup);
            this.groupOutter.SomeoneJoinGroup += new CbGeneric<string, string>(GroupOutter_SomeoneJoinGroup);
            this.groupOutter.GroupmateOffline += new CbGeneric<string>(groupOutter_GroupmateOffline);
            this.groupOutter.JoinGroup(this.roomID);

            this.multiVideoChatContainer1.Initialize(this.multimediaManager, this.roomID);

            NDiskOutter nDiskOutter = new NDiskOutter(this.rapidPassiveEngine.FileOutter,this.rapidPassiveEngine.CustomizeOutter) ;
            this.nDiskBrowser1.NetDiskID = this.roomID;
            this.nDiskBrowser1.Initialize(null, this.rapidPassiveEngine.FileOutter, nDiskOutter);

            this.whiteBoardConnector1.BeginConnect(this.roomID);
            this.Cursor = Cursors.Default;       
            this.timer = new System.Threading.Timer(new System.Threading.TimerCallback(this.TimerAction) ,null,1000,1000) ;           
        }

        private void TimerAction(object state)
        {
            if (this.gotoClose)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<object>(this.TimerAction), state);
            }
            else
            {
                string msg = string.Format("    VideoQuality - {0}" ,this.multimediaManager.CameraEncodeQuality);
                this.toolStripLabel_runtime.Text = msg;               
            }
        }

        void groupOutter_GroupmateOffline(string groupmateID)
        {
            this.GroupOutter_SomeoneQuitGroup(this.roomID, groupmateID);
        }

        #region 连接断开
        void TcpPassiveEngine_ConnectionInterrupted()
        {
            if (this.gotoClose)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric(this.TcpPassiveEngine_ConnectionInterrupted));
            }
            else
            {
                if (this.gotoClose)
                {
                    return;
                }
                MessageBox.Show("您已经掉线！");
                this.gotoClose = true;
                this.Close();
            }
        }

        void multimediaManager_ConnectionInterrupted(IPEndPoint ipe)
        {
            if (this.gotoClose)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<IPEndPoint>(this.multimediaManager_ConnectionInterrupted), ipe);
            }
            else
            {
                if (this.gotoClose)
                {
                    return;
                }
                MessageBox.Show("您已经掉线！");
                this.gotoClose = true;
                this.Close();
            }
        }
        #endregion

        #region 被挤掉线
        void BasicOutter_BeingPushedOut()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric(this.BasicOutter_BeingPushedOut));
            }
            else
            {
                if (this.gotoClose)
                {
                    return;
                }
                MessageBox.Show("已经在其它地方登录！");
                this.gotoClose = true;
                this.Close();
            }
        }
        #endregion                      
        #endregion

        #region GroupOutter_SomeoneQuitGroup 、GroupOutter_SomeoneJoinGroup       
        void GroupOutter_SomeoneQuitGroup(string groupID, string memberID)
        {
            if (groupID == this.roomID)
            {
                //如果有远程 连接到该组员，断开远程连接
                this.CloseRemotingDesktop(memberID ,false);                       
                this.ShowSystemMessage(memberID + "掉线！");  
            }       
        }
        void GroupOutter_SomeoneJoinGroup(string groupID, string memberID)
        {
            if (groupID == this.roomID)
            {
                this.ShowSystemMessage(memberID + "上线！");   

                //如果自己有共享 桌面给 组友，那么就给该新加入的组友一条 共享 其桌面的消息 ，并在授权列表中添加该组员
                if (this.shareDesk)
                {
                    this.rapidPassiveEngine.CustomizeOutter.Send(memberID, InformationTypes.ShareDesk, null, true, ActionTypeOnChannelIsBusy.Continue);                   
                }                
            }
        }
       
        #endregion     

        #region 收到组广播消息的处理
        void GroupOutter_BroadcastReceived(string broadcasterID, string groupID, int broadcastType, byte[] broadcastContent)
        {
            try
            {
                if (groupID == this.roomID)
                {
                    #region 即时通信消息的处理
                    if (broadcastType == InformationTypes.BroadcastChat)
                    {
                        ChatBoxContent contract = CompactPropertySerializer.Default.Deserialize<ChatBoxContent>(broadcastContent, 0);
                        string msg = string.Format("{0}说: ", broadcasterID, DateTime.Now) + contract.Text;
                        //当收到广播 消息，如果tablePage不在即时通讯 页，则在 标题上面显示 新增 消息数量
                        this.DealBeforeShowMessage(msg);
                        if (contract != null)
                        {
                            this.textChatControl1.ShowOtherTextChat(broadcasterID, contract);
                        }
                        return;
                    }
                    #endregion
                    #region 共享桌面消息的处理
                    if (broadcastType == InformationTypes.BroadcastShareDesk)
                    {
                        bool isShare = BitConverter.ToBoolean(broadcastContent, 0);
                        if (isShare)
                        {
                            this.OpenRemotingDesktop(broadcasterID);
                        }
                        else
                        {
                            this.CloseRemotingDesktop(broadcasterID ,true);
                        }
                        return;
                    }
                    #endregion    
                }
            }
            catch (Exception ee)
            {
                Program.Logger.Log(ee, string.Format("mainform.GroupOutter_BroadcastReceived({0},{1},{2})",broadcasterID,groupID,broadcastType), ESBasic.Loggers.ErrorLevel.High);
                MessageBox.Show(ee.Message);
            }
        }
        
        #endregion            

        #region CustomizeHandler_ControlRemotingDesktop
        public void CustomizeHandler_ControlRemotingDesktop(string userID, bool canControl)
        {
            TabPage page = this.GetDesktopPanelPage(userID);
            if (page == null)
            {
                page = this.outTabPages.Get(userID);
            }
            
            (page.Controls[0] as RemoteDesktopPanel).Control(canControl);
            
        } 
        #endregion           

        #region whiteBoardConnector1_ConnectEnded
        void whiteBoardConnector1_ConnectEnded(OMCS.Passive.ConnectResult result)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<ConnectResult>(this.whiteBoardConnector1_ConnectEnded), result);
            }
            else
            {
                if (result != ConnectResult.Succeed)
                {
                    this.ShowSystemMessage( string.Format("电子白板连接失败！{0}", result.ToString()));
                    
                }
            }
        } 
        #endregion       

        #region tabControl1_SelectedIndexChanged
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1)
            {
                this.currentPageIsIM = true;
                this.messageCount = 0;
                this.ChangePageText();
            }
            else
            {
                this.currentPageIsIM = false;

            }
        } 
        #endregion        

        #region 即时消息
        #region ChangePageText
        void ChangePageText()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CbGeneric(this.ChangePageText));
            }
            else
            {
                if (this.messageCount == 0)
                {
                    this.tabPage2.Text = "即时消息";
                }
                else
                {
                    this.tabPage2.Text = string.Format("即时消息(+{0})", this.messageCount);
                }
            }
        }
        #endregion 
        #endregion

        #region 远程桌面
        #region OpenRemotingDesktop
        public void OpenRemotingDesktop(string broadcasterID)
        {
            this.ShowSystemMessage(broadcasterID + "开启了桌面共享！");  

            TabPage  page = this.GetDesktopPanelPage(broadcasterID);
            if (page == null)
            {
                //新 生成一个page，且选中，远程连接到广播者 的桌面 
                this.CreateDesktopPage(broadcasterID);                
            }            
        }
        #endregion
        #region CloseRemotingDesktop//断开远程桌面的连接，关闭page
        private void CloseRemotingDesktop(string userID ,bool showMessage)
        {
            if (showMessage)
            {
                this.ShowSystemMessage(userID + "关闭了桌面共享！");
            }

            TabPage page = this.GetDesktopPanelPage(userID);
            if (page != null)
            {
                this.CloseShowInTabPage(page);
            }
            else
            {
                page = this.outTabPages.Get(userID);
                if (page != null)
                {
                    this.CloseOutShowTabPage(page);                  
                }
            }
        }
        #endregion
        #region CloseAllRemotingDesktop//断开所有远程桌面的连接，关闭page
        private void CloseAllRemotingDesktop()
        {
            for (int i = this.tabControl1.TabPages.Count - 1; i >= 3; i--)
            {
                this.CloseShowInTabPage(this.tabControl1.TabPages[i]);                
            }
            foreach (TabPage page in this.outTabPages.GetAll())
            {
                this.CloseOutShowTabPage(page);
            }
            
        }
        #endregion
        #region CloseShowInTabPage
        private void CloseShowInTabPage(TabPage page)
        {
            RemoteDesktopPanel desktopPanel = page.Controls[0] as RemoteDesktopPanel;
            if (desktopPanel != null)
            {
                desktopPanel.DisConnect();
                this.ClosePage(page);
            }
        } 
        #endregion
        #region CloseOutShowTabPage
        private void CloseOutShowTabPage(TabPage page)
        {
            RemoteDesktopPanel desktopPanel = page.Controls[0] as RemoteDesktopPanel;
            desktopPanel.DisConnect();
            desktopPanel.CloseShowFormDirectly = true;
            desktopPanel.ShowForm.CloseForm();
            this.outTabPages.Remove(page.Name);
        } 
        #endregion

        
        #region CreateDesktopPage
        private void CreateDesktopPage(string broadcasterID)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CbGeneric<string>(this.CreateDesktopPage), broadcasterID);
            }
            else
            {
                TabPage page = new TabPage();
                page.Text = broadcasterID + "的桌面";
                page.Name = broadcasterID;
                page.ImageIndex = 2;
                RemoteDesktopPanel desktopPanel = new RemoteDesktopPanel();
                desktopPanel.Initialize(page);
                desktopPanel.HidePageEvent += new CbGeneric<TabPage>(desktopPanel_HidePageEvent);
                desktopPanel.ShowPageEvent += new CbGeneric<string>(desktopPanel_ShowPageEvent);
                desktopPanel.Dock = DockStyle.Fill;
                
                page.Controls.Add(desktopPanel);
                this.tabControl1.TabPages.Add(page);
                this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
                desktopPanel.Connect(broadcasterID);                
            }
            
        }

        void desktopPanel_ShowPageEvent(string pageName)
        {
             TabPage page = this.outTabPages.Get(pageName);
             this.tabControl1.TabPages.Add(page);
             this.tabControl1.SelectedIndex = this.tabControl1.TabPages.Count - 1;
             this.outTabPages.Remove(pageName);
        }
        

        void desktopPanel_HidePageEvent(TabPage page)
        {
            this.outTabPages.Add(page.Name, page);
            this.tabControl1.TabPages.Remove(page);
        }
       
        #endregion
        #region GetDesktopPanelPage
        private TabPage GetDesktopPanelPage(string broadcasterID)
        {
            for (int i = 2; i < this.tabControl1.TabPages.Count; i++)
            {
                if (this.tabControl1.TabPages[i].Name == broadcasterID)
                {
                    return this.tabControl1.TabPages[i];
                }
            }
            return null;
        }
        #endregion

        #region ClosePage
        private void ClosePage(TabPage page)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CbGeneric<TabPage>(this.ClosePage), page);
            }
            else
            {
                this.tabControl1.TabPages.Remove(page);
                this.tabControl1.SelectedIndex = 0;
            }
        }
        #endregion                 
      
        #endregion              

        #region 系统设置
        private void ToolStripMenuItem_systemSetting_Click(object sender, EventArgs e)
        {
            try
            {
                SystemSettingForm form = this.configFormManager.GetForm(this.currentUserID);
                if (form == null)
                {
                    form = new SystemSettingForm(this.currentUserID, this.roomID, this.multimediaManager ,this.rapidPassiveEngine );
                    this.configFormManager.Add(form);
                    form.Show();
                }
                form.Focus();
            }
            catch (Exception ee)
            {
                Program.Logger.Log(ee, "MainForm.ToolStripMenuItem_systemSetting_Click", ESBasic.Loggers.ErrorLevel.High);
                MessageBox.Show(ee.Message);
            }
        } 
        #endregion
       
        #region MainForm_FormClosing
        private bool gotoClose = false;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.gotoClose = true;
            this.multiVideoChatContainer1.Close();          
            this.multimediaManager.DisconnectGuest(false);
            //this.multimediaManager.Dispose();
            this.rapidPassiveEngine.Close();
        }
        #endregion 

        private void ShowSystemMessage(string message)
        {
            this.DealBeforeShowMessage(message);           
            this.textChatControl1.ShowSystemMessage(message);
            if (UserConfiguration.Singleton.ButtballIsOpen)
            {
                this.ShowBallonForm(message);
            }
        }
        private void ShowBallonForm(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CbGeneric<string>(this.ShowBallonForm), message);
            }
            else
            {
                BallonForm ballonForm = new BallonForm();
                ballonForm.ScrollShow(message);
            }
        }
        #region DealBeforeShowMessage
        private void DealBeforeShowMessage(string msg)
        {
            if (msg.Length > 40)
            {
                msg = msg.Substring(0, 40) + "......";
            }
            this.toolStripLabel_lastMessage.Text = msg;
            if (!this.currentPageIsIM)
            {
                this.messageCount++;
                this.ChangePageText();
            }
        } 
        #endregion           

        #region 共享桌面
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.shareDesk = this.checkBox1.Checked; ;
                if (this.shareDesk)
                {
                    this.授权ToolStripMenuItem.Visible = true;
                    List<string> groupmates = this.groupOutter.GetGroupMembers(this.roomID);
                    foreach (string groupmateId in groupmates)
                    {
                        if (groupmateId != this.currentUserID)
                        {
                            ToolStripMenuItem item = new ToolStripMenuItem(groupmateId);
                            this.授权ToolStripMenuItem.DropDownItems.Add(item);
                            item.Click += new EventHandler(item_Click);
                        }
                    }
                }
                else
                {
                    this.授权ToolStripMenuItem.Visible = false;
                    this.授权ToolStripMenuItem.DropDownItems.Clear();
                }

                this.groupOutter.Broadcast(this.roomID, InformationTypes.BroadcastShareDesk, BitConverter.GetBytes(this.shareDesk), ActionTypeOnChannelIsBusy.Continue);
            }
            catch (Exception ee)
            {
                Program.Logger.Log(ee, "MainForm.checkBox1_CheckedChanged", ESBasic.Loggers.ErrorLevel.High);
                MessageBox.Show(ee.Message);
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem currentItem = (sender as ToolStripMenuItem);
                currentItem.Checked = !currentItem.Checked;

                this.rapidPassiveEngine.CustomizeOutter.Send(currentItem.Text, InformationTypes.ControlDesktop, BitConverter.GetBytes(currentItem.Checked), true, ActionTypeOnChannelIsBusy.Continue);
                //如果是授权给某人，那么要去掉其他人的受控权
                if (currentItem.Checked)
                {
                    foreach (ToolStripMenuItem item in this.授权ToolStripMenuItem.DropDownItems)
                    {
                        if (item.Text != currentItem.Text && item.Checked)
                        {
                            item.Checked = false;
                            this.rapidPassiveEngine.CustomizeOutter.Send(item.Text, InformationTypes.ControlDesktop, BitConverter.GetBytes(false), true, ActionTypeOnChannelIsBusy.Continue);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                Program.Logger.Log(ee, "mainform.item_Click", ESBasic.Loggers.ErrorLevel.High);
                MessageBox.Show(ee.Message);
            }

        }   
        #endregion

        private void 设备测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OMCS.Boost.Forms.DeviceSelectForm form = new OMCS.Boost.Forms.DeviceSelectForm();
            form.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
