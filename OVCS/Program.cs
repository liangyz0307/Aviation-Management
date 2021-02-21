using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESPlus.Core;
using OMCS;
using System.IO;
using ESBasic.ObjectManagement.Managers;
using ESPlus.FileTransceiver;
using System.Configuration;
using OMCS.Passive;
using OMCS.Boost.Forms;

namespace OVCS
{
/*
 * OVCS采用的是ESFramework通信框架和OMCS网络语音视频框架的免费版本，若想获取其它版本，请联系www.oraycn.com。
 * 
 */
    static class Program
    {
        public static bool IsReleaseVersion = true;

        public static ESBasic.Loggers.FileAgileLogger Logger = new ESBasic.Loggers.FileAgileLogger(AppDomain.CurrentDomain.BaseDirectory + "AppLog.txt");
        public static ObjectManager<string, TransferingProject> AllTransferingProjects = new ObjectManager<string, TransferingProject>();
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                OMCS.GlobalUtil.SetMaxLengthOfUserID(byte.Parse(ConfigurationManager.AppSettings["MaxLengthOfUserID"]));
                ESPlus.GlobalUtil.SetMaxLengthOfUserID(byte.Parse(ConfigurationManager.AppSettings["MaxLengthOfUserID"]));
                bool haveRun = ESBasic.Helpers.ApplicationHelper.IsAppInstanceExist("OVCS");
                //if (haveRun)
                //{
                //    MessageBox.Show("OVCS已经在运行!");
                //    return;
                //}
                
                CustomizeHandler customizeHandler = new CustomizeHandler();
                LoginForm form = new LoginForm(customizeHandler);
                form.Text = ConfigurationManager.AppSettings["Title"];
                if (DialogResult.OK != form.ShowDialog())
                {
                    return;
                }              
                              
                MainForm mainForm = new MainForm();
                mainForm.Text = form.Text;
                mainForm.Show();
                mainForm.Initialize(form.RapidPassiveEngine, form.MultimediaManager, form.GroupOutter, form.UserID, "Room01");
                customizeHandler.Initialize(mainForm);             

                Application.Run(mainForm);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "\n" + ee.StackTrace);
            }
        }
    }
}
