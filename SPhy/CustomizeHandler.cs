using System;
using System.Collections.Generic;
using System.Text;
using ESPlus.Application.CustomizeInfo.Passive;
using ESPlus.Serialization;
using ESPlus.Application.CustomizeInfo;
using OVCS.Core;
namespace OVCS
{
    public class CustomizeHandler : IIntegratedCustomizeHandler
    {
        private MainForm mainForm;        

        public void Initialize(MainForm form)
        {
            this.mainForm = form;
        }
        public void HandleInformation(string sourceUserID, int informationType, byte[] info)
        {
            try
            {
                //控制是否能 控制远程桌面
                if (informationType == InformationTypes.ControlDesktop)
                {
                    this.mainForm.CustomizeHandler_ControlRemotingDesktop(sourceUserID, BitConverter.ToBoolean(info, 0));
                    return;
                }
                //收到共享 桌面的消息
                if (informationType == InformationTypes.ShareDesk)
                {                   
                    this.mainForm.OpenRemotingDesktop(sourceUserID);
                    return;
                }    
            }
            catch (Exception ee)
            {
                Program.Logger.Log(ee,string.Format("CustomizeHandler.HandleInformation({0},{1})",sourceUserID, informationType), ESBasic.Loggers.ErrorLevel.High);
                
            }
        }

        public void HandleInformationFromServer(int informationType, byte[] info)
        {
            
        }

        public byte[] HandleQuery(string sourceUserID, int informationType, byte[] info)
        {
            return null;
        }

        public byte[] HandleQueryFromServer(int informationType, byte[] info)
        {
            return null;
        }

        public bool CanHandle(int informationType)
        {
            return informationType >= 50 && informationType <= 100;
            
        }
    }
}
