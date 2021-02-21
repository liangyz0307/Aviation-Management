using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OMCS.Tools;
using OMCS.Server;
using OMCS.Passive;
using ESBasic;
using OMCS;
using OMCS.Communication.Basic;


namespace OVCS
{
    public partial class DeviceSelectForm : Form
    {
        private IMultimediaManager multimediaManager = MultimediaManagerFactory.GetSingleton();
        private string userID;
        private AgileIPEndPoint ipe;

        public DeviceSelectForm(IMultimediaManager mgr)
        {
            InitializeComponent();
            this.multimediaManager = mgr;
            this.userID = this.multimediaManager.CurrentUserID;
            this.ipe = this.multimediaManager.ServerIPE;

            this.multimediaManager.DeviceErrorOccurred += new CbGeneric<MultimediaDeviceType, int, string>(multimediaManager_DeviceErrorOccurred);
            this.cameraConnector1.ConnectEnded += new CbGeneric<ConnectResult>(cameraConnector1_ConnectEnded);
            this.microphoneConnector1.ConnectEnded += new CbGeneric<ConnectResult>(microphoneConnector1_ConnectEnded);

            this.button_refresh_Click(this.button_refresh, new EventArgs());
            try
            {
                this.comboBox1.SelectedIndex = this.multimediaManager.CameraDeviceIndex;
            }
            catch { }
        }

        void multimediaManager_DeviceErrorOccurred(MultimediaDeviceType deviceType, int deviceIndex, string error)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<MultimediaDeviceType, int, string>(this.multimediaManager_DeviceErrorOccurred), deviceType, deviceIndex ,error);
            }
            else
            {
                MessageBox.Show(string.Format("Error : {0} - {1}" ,deviceType,error));
            }
        }

        void microphoneConnector1_ConnectEnded(ConnectResult res)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<ConnectResult>(this.microphoneConnector1_ConnectEnded), res);
            }
            else
            {
                if (res != ConnectResult.Succeed)
                {
                    this.label_error2.Visible = true;
                    this.label_error2.Text = res.ToString();
                }
                else
                {
                    this.label_error2.Visible = false;
                }                
            }
        }

        void cameraConnector1_ConnectEnded(ConnectResult res)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<ConnectResult>(this.cameraConnector1_ConnectEnded), res);
            }                
            else
            {
                if (res != ConnectResult.Succeed)
                {
                    this.label_error.Visible = true;
                    this.label_error.Text = res.ToString();
                }
                else
                {
                    this.label_error.Visible = false;                   
                }
                this.label_info.Visible = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.label_error.Visible = false;
                this.label_error2.Visible = false;
                this.label_error3.Visible = false;
                this.label_info.Visible = true;
                if (!SoundDevice.IsSoundCardInstalled())
                {
                    this.label_error3.Visible = true;
                    this.label_error3.Text = "声卡没有安装";
                }

                bool reIni = this.multimediaManager.CameraDeviceIndex != this.comboBox1.SelectedIndex ||
                    this.multimediaManager.MicrophoneDeviceIndex != this.comboBox2.SelectedIndex ||
                    this.multimediaManager.SpeakerIndex != this.comboBox3.SelectedIndex;
                if (reIni && this.multimediaManager.Available)
                {
                    this.multimediaManager.Dispose();

                    //初始化多媒体管理器                
                    this.multimediaManager.CameraDeviceIndex = this.comboBox1.SelectedIndex;
                    this.multimediaManager.MicrophoneDeviceIndex = this.comboBox2.SelectedIndex;
                    this.multimediaManager.SpeakerIndex = this.comboBox3.SelectedIndex;
                    this.multimediaManager.Initialize(this.userID, "", this.ipe.IPAddress, this.ipe.Port); //与OMCS服务器建立连接，并登录
                }

                //尝试连接设备
                this.cameraConnector1.BeginConnect(this.userID);
                this.microphoneConnector1.BeginConnect(this.userID);

                this.button_start.Enabled = false;
                this.button1.Visible = false;
                this.button_stop.Enabled = true;
                this.button_refresh.Enabled = false;
                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
                this.comboBox3.Enabled = false;
            }
            catch (Exception ee)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ee.Message);
            }           
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            try
            {
                //断开到设备的连接
                this.cameraConnector1.Disconnect();
                this.microphoneConnector1.Disconnect();               

                this.button_start.Enabled = true;
                this.button_stop.Enabled = false;
                this.button1.Visible = true;
                this.button_refresh.Enabled = true;  
                this.comboBox1.Enabled = true;
                this.comboBox2.Enabled = true;
                this.comboBox3.Enabled = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            try
            {
                //获取摄像头列表
                IList<CameraInformation> cameras = Camera.GetCameras();
                this.comboBox1.DataSource = cameras;
                if (cameras.Count > 0)
                {
                    this.comboBox1.SelectedIndex = 0;
                }

                //获取麦克风列表
                IList<MicrophoneInformation> microphones = SoundDevice.GetMicrophones();
                this.comboBox2.DataSource = microphones;
                if (microphones.Count > 0)
                {
                    this.comboBox2.SelectedIndex = 0;
                }

                //获取扬声器列表
                IList<SpeakerInformation> speakers = SoundDevice.GetSpeakers();
                this.comboBox3.DataSource = speakers;
                if (speakers.Count > 0)
                {
                    this.comboBox3.SelectedIndex = 0;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserConfiguration.Singleton.WebcamIndex = this.comboBox1.SelectedIndex;
            this.multimediaManager.CameraDeviceIndex = this.comboBox1.SelectedIndex;
            UserConfiguration.Singleton.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
