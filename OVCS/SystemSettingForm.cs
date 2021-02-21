using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OMCS.Passive;
using ESBasic.ObjectManagement.Forms;
using OMCS.Tools;
using ESPlus.Rapid;
using OVCS.Core;

namespace OVCS
{
    public partial class SystemSettingForm : Form, IManagedForm<string>
    {
        
        private IMultimediaManager multimediaManager;
        private IRapidPassiveEngine rapidPassiveEngine;
        private string userID;
        private string groupID;

        #region SystemSettingForm
        public SystemSettingForm(string _userID, string _groupID, IMultimediaManager _multimediaManager, IRapidPassiveEngine engine)
        {
            InitializeComponent();
            this.multimediaManager = _multimediaManager;
            this.userID = _userID;
            this.groupID = _groupID;
            this.rapidPassiveEngine = engine;            

            IList<CameraInformation> cameras = Camera.GetCameras();
            this.comboBox_webcam.DataSource = cameras;
            if (cameras.Count == 0)
            {
                UserConfiguration.Singleton.WebcamIndex = 0;
            }
            else
            {
                if (cameras.Count >= UserConfiguration.Singleton.WebcamIndex + 1)
                {
                    this.comboBox_webcam.SelectedIndex = UserConfiguration.Singleton.WebcamIndex;
                }
                else
                {
                    this.comboBox_webcam.SelectedIndex = 0;
                }
            }            
            if (UserConfiguration.Singleton.ButtballIsOpen)
            {
                this.radioButton_openButtball.Checked = true;
                //this.radioButton_closeButtball.Checked = false;
            }
            else
            {
                this.radioButton_closeButtball.Checked = true;
                //this.radioButton_openButtball.Checked = false;
            }
        } 
        #endregion       

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox_webcam.SelectedIndex < 0)
                {
                    UserConfiguration.Singleton.WebcamIndex = 0;
                }
                else
                {
                    UserConfiguration.Singleton.WebcamIndex = this.comboBox_webcam.SelectedIndex;
                }
               
                this.multimediaManager.CameraDeviceIndex = UserConfiguration.Singleton.WebcamIndex;
               
                UserConfiguration.Singleton.ButtballIsOpen = this.radioButton_openButtball.Checked;
                UserConfiguration.Singleton.Save();             
              
                this.Close();
            }
            catch (Exception ee)
            {
                Program.Logger.Log(ee, "SystemSettingForm.button_ok_Click", ESBasic.Loggers.ErrorLevel.High);
                MessageBox.Show(ee.Message);
            }
        }

        public string FormID
        {
            get { return this.userID; }
        }
    }
}
