using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ESBasic;
using OMCS.Passive.RemoteDesktop;
using OMCS.Passive;

namespace OVCS
{
    public partial class RemoteDesktopPanel : UserControl
    {
        public event CbGeneric<TabPage> HidePageEvent;
        public event CbGeneric<string> ShowPageEvent;
        
        private TabPage ownerPage;
        #region ShowForm
        private RemotingDesktopForm showForm = null;

        public RemotingDesktopForm ShowForm
        {
            get { return showForm; }
        } 
        #endregion

        public bool CloseShowFormDirectly = false;
        public OMCS.Passive.RemoteDesktop.DesktopPanel DesktopPanel
        {
            get { return this.desktopPanel1; }
        }

        
        public RemoteDesktopPanel()
        {            
            InitializeComponent();                           
            this.dynamicDesktopConnector1.SetViewer(this.desktopPanel1);
            this.dynamicDesktopConnector1.ConnectEnded += new ESBasic.CbGeneric<OMCS.Passive.ConnectResult>(dynamicDesktopConnector1_ConnectEnded);
            
            
        }

        void showform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.CloseShowFormDirectly)
            {
                return;
            }
            //返回tabpage显示
            this.ReturnToTabPage();
           
        }
        private void ReturnToTabPage()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CbGeneric(this.ReturnToTabPage));
            }
            else
            {
                this.dynamicDesktopConnector1.SetViewer(this.desktopPanel1);
                
                if (this.ShowPageEvent != null)
                {
                    this.ShowPageEvent(this.ownerPage.Name);
                }
            }
        }

        public void Initialize(TabPage _ownerPage)
        {
            this.ownerPage = _ownerPage;           
        }
       
        

        void dynamicDesktopConnector1_ConnectEnded(OMCS.Passive.ConnectResult connectResult)
        {
            if (connectResult != OMCS.Passive.ConnectResult.Succeed)
            {
                
            }
        }


        #region Connect
        public void Connect(string destUserID)
        {
            this.dynamicDesktopConnector1.BeginConnect(destUserID);
        } 
        #endregion
        #region DisConnect
        public void DisConnect()
        {
            this.dynamicDesktopConnector1.Disconnect();
        } 
        #endregion

        #region Control
        public void Control(bool canControl)
        {
            this.dynamicDesktopConnector1.WatchingOnly = !canControl;
        } 
        #endregion

       
       
        //浮出
        private void toolStripButton_out_Click(object sender, EventArgs e)
        {
            this.ShowInNewForm(false);
        }
        //全屏
        private void toolStripButton_fullScreen_Click(object sender, EventArgs e)
        {
            this.ShowInNewForm(true);
        }
        private void ShowInNewForm(bool isFullScreen)
        {
            try
            {
                //在新窗体中显示 
                this.showForm = new RemotingDesktopForm(this.ownerPage.Text);
                this.showForm.FormClosing += new FormClosingEventHandler(showform_FormClosing);
                //隐藏page
                if (this.HidePageEvent != null)
                {
                    this.HidePageEvent(this.ownerPage);
                }

             
                
                if (isFullScreen)
                {
                    this.showForm.FullScreen();
                }
                this.showForm.Show();
                this.showForm.Focus();
                this.dynamicDesktopConnector1.SetViewer(this.showForm.DesktopPanel);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                Program.Logger.Log(ee, string.Format("RemoteDesktopPanel.ShowInNewForm({0})", isFullScreen), ESBasic.Loggers.ErrorLevel.High);

            }
        }
       
        
        
    }
}
