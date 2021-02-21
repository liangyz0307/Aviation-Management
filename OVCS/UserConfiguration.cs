using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OVCS
{
    [Serializable]
    public class UserConfiguration
    {
        public static string FilePath = "" ;

        #region Singleton
        private static UserConfiguration singleton;
        public static UserConfiguration Singleton
        {
            get { return UserConfiguration.singleton; }
        } 
        #endregion

        static UserConfiguration()
        {
            UserConfiguration.FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
                                         + "\\OVCS\\UserConfiguration.dat";
            if (!File.Exists(UserConfiguration.FilePath))
            {
                UserConfiguration.singleton = new UserConfiguration();
                UserConfiguration.singleton.Save();
            }
            else
            {
                try
                {
                    UserConfiguration.singleton = UserConfiguration.Load();
                }
                catch (Exception e)
                {
                    UserConfiguration.singleton = new UserConfiguration();
                    UserConfiguration.singleton.Save();
                }
            }
        }

        #region WebcamIndex
        private int webcamIndex = 0;
        /// <summary>
        /// 摄像头索引
        /// </summary>
        public int WebcamIndex
        {
            get { return webcamIndex; }
            set { webcamIndex = value; }
        }
        #endregion

        #region ExitWhenClose
        private bool exitWhenClose = true;
        /// <summary>
        /// 点击关闭按钮的时候，是否 退出程序
        /// </summary>
        public bool ExitWhenClose
        {
            get { return exitWhenClose; }
            set { exitWhenClose = value; }
        }
        #endregion

        #region ButtballIsOpen
        private bool buttballIsOpen = true;
        /// <summary>
        /// 是否 开启气泡提示
        /// </summary>
        public bool ButtballIsOpen
        {
            get { return buttballIsOpen; }
            set { buttballIsOpen = value; }
        } 
        #endregion

        #region UserID
        private string userID = "";
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        } 
        #endregion

        #region SavePassword
        private bool savePassword = true;
        public bool SavePassword
        {
            get { return savePassword; }
            set { savePassword = value; }
        } 
        #endregion

        #region Password
        private string password = "";
        public string Password
        {
            get { return password; }
            set { password = value; }
        } 
        #endregion

        public void Save()
        {
            ESBasic.Helpers.FileHelper.WriteBuffToFile(ESBasic.Helpers.SerializeHelper.SerializeObject(this), UserConfiguration.FilePath);     
        }

        private static UserConfiguration Load()
        {
            byte[] buff = ESBasic.Helpers.FileHelper.ReadFileReturnBytes(UserConfiguration.FilePath);
            return (UserConfiguration)ESBasic.Helpers.SerializeHelper.DeserializeBytes(buff, 0, buff.Length);
        }
    }
}
