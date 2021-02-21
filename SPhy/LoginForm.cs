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
using Sys;

using System.Diagnostics;
using ESFramework.Boost.DynamicGroup.Passive;
using ESFramework.Boost.NetworkDisk.Passive;

namespace OVCS
{
    public partial class LoginForm : Form
    {
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
            this.button2.Enabled = !Program.IsReleaseVersion;

            this.customizeHandler = _customizeHandler;          

            this.textBox_userID.Text = UserConfiguration.Singleton.UserID;
            this.checkBox1.Checked = UserConfiguration.Singleton.SavePassword;
            if (UserConfiguration.Singleton.SavePassword)
            {
                this.textBox_password.Text = UserConfiguration.Singleton.Password;
            }
        }
     
        //游客登录
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                  string _ip = tbx_IP.Text.Trim();
                UpdateAppConfig("ServerIP",_ip);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                this.isVisitor = true;
                //Random random = new Random();
                //this.userID = (random.Next(1000, 10000).ToString());
                this.userID ="2015";
                this.label_state.Visible = true;
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();
                if (!this.Login(true))
                {
                    this.label_state.Visible = false;
                    this.Cursor = Cursors.Default;
                    this.Refresh();
                    return;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;                
            }
            catch (Exception ee)
            {
                this.label_state.Visible = false;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ee.Message);
                Program.Logger.Log(ee, "LoginForm.button1_Click游客登录的处理", ESBasic.Loggers.ErrorLevel.High);
            }
        }


        private static void UpdateAppConfig(string newKey, string newValue)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            bool exist = false;
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == newKey)
                {
                    exist = true;
                }
            }
            if (exist)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        //private void button2_Click(object sender, EventArgs e)
        //{
           
        //    try
        //    {
        //        this.isVisitor = false;
        //        if (this.textBox_userID.Text.Trim() == "")
        //        {
        //            return;
        //        }
        //        this.userID = this.textBox_userID.Text;                 
        //        if (this.userID.Length > 11)
        //        {
        //            MessageBox.Show("登录账号的长度不能超过11");
        //            return;
        //        }

        //        this.password = this.textBox_password.Text.Trim();

        //        this.label_state.Visible = true;
        //        this.Cursor = Cursors.WaitCursor;
        //        this.Refresh();
        //        if (!this.Login(false))
        //        {
        //            this.label_state.Visible = false;
        //            this.Cursor = Cursors.Default;
        //            this.Refresh();
        //            return;
        //        }

        //        UserConfiguration.Singleton.UserID = this.userID;
        //        UserConfiguration.Singleton.Password = this.password;
        //        UserConfiguration.Singleton.SavePassword = this.checkBox1.Checked;
        //        UserConfiguration.Singleton.Save();
        //        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        //    }
        //    catch (Exception ee)
        //    {
        //        this.label_state.Visible = false;
        //        this.Cursor = Cursors.Default;
        //        MessageBox.Show(ee.Message);
        //        Program.Logger.Log(ee, "LoginForm.button2_Click登录的处理", ESBasic.Loggers.ErrorLevel.High);
        //    }
        //}

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
            try
            {
                this.isVisitor = false;
                if (this.textBox_userID.Text.Trim() == "")
                {
                    return;
                }
                this.userID = this.textBox_userID.Text;
                //if (this.userID.Length > 11)
                //{
                //    MessageBox.Show("登录账号的长度不能超过11");
                //    return;
                //}

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
            catch (Exception ee)
            {
                this.label_state.Visible = false;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ee.Message);
                Program.Logger.Log(ee, "LoginForm.button2_Click登录的处理", ESBasic.Loggers.ErrorLevel.High);
            }
        }
    }
    
}
