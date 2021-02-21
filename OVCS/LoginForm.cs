using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OMCS.Passive;
using System.Configuration;
using ESPlus.Rapid;
using ESPlus.Application.Basic;
using ESPlus.Application.CustomizeInfo.Passive;
using ESBasic.Security;
using System.Security.Cryptography;
using ESPlus.Application.CustomizeInfo;
using OMCS.Tools;

using System.Diagnostics;
using ESFramework.Boost.DynamicGroup.Passive;
using ESFramework.Boost.NetworkDisk.Passive;

using System.Web;
using CUST;
using System.Data.SqlClient;
using System.IO;

namespace OVCS
{
    public partial class LoginForm : Form
    {

        private WebService1.WebService1 _service;
        #region RapidPassiveEngine
        private IRapidPassiveEngine rapidPassiveEngine = RapidEngineFactory.CreatePassiveEngine();

        public IRapidPassiveEngine RapidPassiveEngine
        {
            get { return rapidPassiveEngine; }
        } 
        #endregion

        #region UserID
        private string userID;
        public string UserID
        {
            get { return userID; }
        }
        #endregion

        #region MultimediaManager
        private IMultimediaManager multimediaManager = MultimediaManagerFactory.GetSingleton();
        public IMultimediaManager MultimediaManager
        {
            get { return multimediaManager; }
        } 
        #endregion     

        #region GroupOutter
        private DynamicGroupOutter groupOutter = new DynamicGroupOutter();
        public DynamicGroupOutter GroupOutter
        {
            get { return groupOutter; }
        }
        #endregion

        #region IsVisitor
        private bool isVisitor = true;
        public bool IsVisitor
        {
            get { return isVisitor; }
        } 
        #endregion
        
        private CustomizeHandler customizeHandler;       
        private string password = "";
        public LoginForm(CustomizeHandler _customizeHandler)
        {
            InitializeComponent();
          // this.button2.Enabled = !Program.IsReleaseVersion;

            this.customizeHandler = _customizeHandler;          

            this.textBox_userID.Text = UserConfiguration.Singleton.UserID;
            this.checkBox1.Checked = UserConfiguration.Singleton.SavePassword;
            if (UserConfiguration.Singleton.SavePassword)
            {
                this.textBox_password.Text = UserConfiguration.Singleton.Password; 
            }
        }
        private bool Login(bool isVisitor)
        {       
            //业务逻辑服务器
            this.rapidPassiveEngine.WaitResponseTimeoutInSecs = 30;
            this.rapidPassiveEngine.HeartBeatSpanInSecs = 5;
            this.rapidPassiveEngine.SecurityLogEnabled = false;            
            
            groupOutter.TryP2PWhenGroupmateConnected = false;
            groupOutter.RapidPassiveEngine = this.rapidPassiveEngine;
            DynamicGroupPassiveHandler groupPassiveHandler = new DynamicGroupPassiveHandler();
            groupPassiveHandler.Initialize(groupOutter);

            NDiskPassiveHandler nDiskPassiveHandler = new NDiskPassiveHandler();

            ComplexCustomizeHandler handler = new ComplexCustomizeHandler(this.customizeHandler, groupPassiveHandler, nDiskPassiveHandler);
            this.rapidPassiveEngine.SystemToken = isVisitor ? "visitor" : "member";
            LogonResponse result = this.rapidPassiveEngine.Initialize(this.userID, this.password, ConfigurationManager.AppSettings["ServerIP"], int.Parse(ConfigurationManager.AppSettings["ServerPort"]), handler);
           
            if (result.LogonResult != LogonResult.Succeed)
            {
                if (result.LogonResult == LogonResult.HadLoggedOn)
                {
                    MessageBox.Show("已经在其它地方登录！");
                }
                else
                {
                    MessageBox.Show("用户或者密码错误！");
                }
                return false;
            }
           
            groupOutter.Initialize(this.rapidPassiveEngine.CurrentUserID);
            nDiskPassiveHandler.Initialize(this.rapidPassiveEngine.FileOutter, null);

            //OMCS 参数设置            
            multimediaManager.ChannelMode = (OMCS.Passive.ChannelMode)Enum.Parse(typeof(OMCS.Passive.ChannelMode), ConfigurationManager.AppSettings["ChannelMode"]);
            multimediaManager.AutoReconnect = false;
            multimediaManager.SecurityLogEnabled = true;        
            multimediaManager.CameraDeviceIndex = 0;
            multimediaManager.MicrophoneDeviceIndex = int.Parse(ConfigurationManager.AppSettings["MicrophoneIndex"]);
            multimediaManager.SpeakerIndex = int.Parse(ConfigurationManager.AppSettings["SpeakerIndex"]);                    
            multimediaManager.AutoAdjustCameraEncodeQuality = false;
            multimediaManager.CameraEncodeQuality = 3;
            multimediaManager.MaxCameraFrameRate = 12;
            multimediaManager.MaxDesktopFrameRate = 3;           
            multimediaManager.Advanced.AllowDiscardFrameWhenBroadcast = false;
            multimediaManager.Advanced.MaxInterval4CameraKeyFrame = 20;
            multimediaManager.Advanced.MaxInterval4DesktopKeyFrame = 20;
            multimediaManager.Advanced.VideoQualityEnhanced = false;
            multimediaManager.Advanced.VideoBitrateControlType4Desktop = BitrateControlType.CQP;
            multimediaManager.Advanced.VideoBitrateControlType4Camera = BitrateControlType.ABR;
                     
            IList<CameraInformation> cameras = Camera.GetCameras();
            if (cameras.Count == 0 || cameras.Count < UserConfiguration.Singleton.WebcamIndex + 1)
            {
                UserConfiguration.Singleton.WebcamIndex = 0;
            }
            this.multimediaManager.CameraDeviceIndex = UserConfiguration.Singleton.WebcamIndex;
            try
            {
                string[] cameraSizeStr = ConfigurationManager.AppSettings["CameraVideoSize"].Split(',');
                multimediaManager.CameraVideoSize = new System.Drawing.Size(int.Parse(cameraSizeStr[0]), int.Parse(cameraSizeStr[1]));
            }
            catch { }
               
            multimediaManager.Initialize(userID, "", ConfigurationManager.AppSettings["ServerIP"], int.Parse(ConfigurationManager.AppSettings["OmcsPort"]));
            multimediaManager.OutputAudio = true;          
           
            return true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.cnblogs.com/justnow");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //string workpath = System.IO.Directory.GetCurrentDirectory();
            //FileStream fs = new FileStream("D:\\OVCS_inatal_log.txt", FileMode.OpenOrCreate);
            //byte[] data = System.Text.Encoding.Default.GetBytes("OVCS工作路径:"+workpath);
            //fs.Write(data, 0, data.Length);
            //fs.Flush();
            //fs.Close();
            //if (!Directory.Exists(workpath))
            //{
            //    Directory.CreateDirectory(workpath);
            //}
            try {
                _service = new WebService1.WebService1();
                if (_service.Login(textBox_userID.Text, textBox_password.Text))
                {
                    this.isVisitor = false;
                    if (this.textBox_userID.Text.Trim() == "")
                    {
                        return;
                    }
                    this.userID = this.textBox_userID.Text;
                    this.password = this.textBox_password.Text.Trim();

                    this.label_state.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                    this.Refresh();
                    if (!this.Login(false))
                    {
                        this.label_state.Visible = false;
                        this.Cursor = Cursors.Default;
                        this.Refresh();
                        return;
                    }
                    UserConfiguration.Singleton.UserID = this.userID;
                    UserConfiguration.Singleton.Password = this.password;
                    UserConfiguration.Singleton.SavePassword = this.checkBox1.Checked;
                    UserConfiguration.Singleton.Save();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("登录账号或者密码不正确!");
                    return;
                }
            }
            catch (Exception ee)
            {
                this.label_state.Visible = false;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ee.Message);
                Program.Logger.Log(ee, "LoginForm.button2_Click登录的处理", ESBasic.Loggers.ErrorLevel.High);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            _service = new WebService1.WebService1();
        }
    }
    
}
