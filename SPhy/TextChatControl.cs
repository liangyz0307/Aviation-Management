using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ESBasic.Widget;
using ESBasic.Collections;
using ESFramework.Passive;
using ESBasic;
using ESPlus.Application.CustomizeInfo.Passive;
using ESPlus.FileTransceiver;
using ESFramework;
using OVCS.Core;
using ESFramework.Boost.DynamicGroup.Passive;
using ESFramework.Boost.Controls;
using ESPlus.Serialization;

namespace OVCS
{
    public partial class TextChatControl : UserControl
    {
        private Font messageFont = new Font("微软雅黑", 9);
        private EmotionForm emotionForm ;
        private string userID = "";
        private IDynamicGroupOutter groupOutter = null;
        private string groupID = "";

        private Dictionary<uint, Image> emotionDictionary;
        
        #region ButtonSend
        /// <summary>
        /// ButtonSend 用于设为AcceptButton
        /// </summary>
        public Button ButtonSend
        {
            get
            {
                return this.button_send;
            }
        } 
        #endregion

        public TextChatControl()
        {
            InitializeComponent();
            this.fontDialog1.ShowColor = true;              
        }

        public void Initialize(string _userID, string groupID, IDynamicGroupOutter _groupOutter)
        {
            this.userID = _userID;
            this.groupID = groupID;
            this.groupOutter = _groupOutter;

            #region Emotion
            List<string> tempList = ESBasic.Helpers.FileHelper.GetOffspringFiles(AppDomain.CurrentDomain.BaseDirectory + "Emotion\\");
            List<string> emotionFileList = new List<string>();
            foreach (string file in tempList)
            {
                string name = file.ToLower();
                if (name.EndsWith(".bmp") || name.EndsWith(".jpg") || name.EndsWith(".jpeg") || name.EndsWith(".png") || name.EndsWith(".gif"))
                {
                    emotionFileList.Add(name);
                }
            }
            emotionFileList.Sort(new Comparison<string>(CompareEmotionName));
            List<Image> emotionList = new List<Image>();
            for (int i = 0; i < emotionFileList.Count; i++)
            {
                emotionList.Add(Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "Emotion\\" + emotionFileList[i]));
            }
            #endregion

            this.emotionDictionary = new Dictionary<uint, Image>();
            for (uint i = 0; i < emotionList.Count; i++)
            {
                this.emotionDictionary.Add(i, emotionList[(int)i]);
            }

            this.chatBox_his.Initialize(this.emotionDictionary);
            this.chatBox_send.Initialize(this.emotionDictionary);

            this.emotionForm = new EmotionForm();
            this.emotionForm.Load += new EventHandler(emotionForm_Load);
            this.emotionForm.Initialize(emotionList);
            this.emotionForm.EmotionClicked += new CbGeneric<int, Image>(emotionForm_Clicked);
            this.emotionForm.Visible = false;
            this.emotionForm.LostFocus += new EventHandler(emotionForm_LostFocus);
        }

        void emotionForm_LostFocus(object sender, EventArgs e)
        {
            this.emotionForm.Visible = false;
        }

        void emotionForm_Load(object sender, EventArgs e)
        {
            this.SetEmotionFormLocation();
        }

        private void SetEmotionFormLocation()
        {
            Point pt = this.PointToScreen(this.panel1.Location);
            Point pos = new Point(pt.X + 30 - (this.emotionForm.Width / 2), pt.Y - this.emotionForm.Height);

            if (pos.X < 10)
            {
                pos = new Point(10, pos.Y);
            }
            this.emotionForm.Location = pos;
        }

        void emotionForm_Clicked(int imgIndex, Image img)
        {
            this.chatBox_send.InsertDefaultEmotion((uint)imgIndex);
            this.emotionForm.Visible = false;
        }

        private static int CompareEmotionName(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return a.Length - b.Length;
            }

            return a.CompareTo(b);
        }

       
       
        #region button_send_Click
        private void button_send_Click(object sender, EventArgs e)
        {
            try
            {
                ChatBoxContent content = this.chatBox_send.GetContent();
                if (content.IsEmpty())
                {                 
                    return;
                }

                byte[] buff = CompactPropertySerializer.Default.Serialize(content);

                this.AppendChatBoxContent(this.userID, content, Color.SeaGreen);

               

                //广播消息给组友
                this.groupOutter.Broadcast(this.groupID, InformationTypes.BroadcastChat, buff, ActionTypeOnChannelIsBusy.Continue);               

                //清空输入框
                this.chatBox_send.Clear();
                this.chatBox_send.Focus();
            }
            catch (Exception ee)
            {
                Program.Logger.Log(ee, "TextChatControl.button_send_Click", ESBasic.Loggers.ErrorLevel.High);
                MessageBox.Show(ee.Message);
            }
        } 
        #endregion

        #region ShowOtherTextChat
        public void ShowOtherTextChat(string broadcastID, ChatBoxContent content)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CbGeneric<string, ChatBoxContent>(this.ShowOtherTextChat), broadcastID, content);
            }
            else
            {
                this.AppendChatBoxContent(broadcastID, content, Color.Black);

            }
        } 
        #endregion

        private void AppendChatBoxContent(string userName, ChatBoxContent content, Color color)
        {
            string showTime = DateTime.Now.ToLongTimeString();

            this.chatBox_his.AppendRichText(string.Format("{0}  {1}\n", userName, showTime), new Font(this.messageFont, FontStyle.Regular), color);
            this.chatBox_his.AppendText("    ");

            this.chatBox_his.AppendChatBoxContent(content);
            this.chatBox_his.AppendText("\n");
            this.chatBox_his.Select(this.chatBox_his.Text.Length, 0);
            this.chatBox_his.ScrollToCaret();
        } 

        #region ShowSystemMessage
        public void ShowSystemMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CbGeneric<string>(this.ShowSystemMessage), message);
            }
            else
            {
                this.chatBox_his.AppendRichText(string.Format("系统:({0})\n  ", DateTime.Now), new Font(this.messageFont, FontStyle.Regular), Color.DarkGray);
                this.chatBox_his.AppendRichText(message + "\n", new Font(this.messageFont, FontStyle.Regular), Color.DarkGray);                
                this.chatBox_his.ScrollToCaret();
            }
        }
        #endregion

        #region ShowFileTransCompleted
        //internal void ShowFileTransCompleted(string projectName)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.Invoke(new CbGeneric<string>(this.ShowFileTransCompleted), projectName);
        //    }
        //    else
        //    {
        //        DateTime showTime = DateTime.Now;
        //        this.agileRichTextBox_history.AppendRichText(string.Format("{0}  {1}\n", "系统", showTime), null, null, Color.DarkGray);
        //        string showText = string.Format("{0} {1}\n", projectName, "下载成功");
        //        this.agileRichTextBox_history.AppendRichText(showText, null, null, Color.DarkGray);
        //        this.agileRichTextBox_history.ScrollToCaret();
        //    }
        //}
        #endregion

        #region 显示文件传输失败的消息
        //internal void ShowFileTransferFailed(string projectName)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.Invoke(new CbGeneric<string>(this.ShowFileTransferFailed), projectName);
        //    }
        //    else
        //    {
        //        DateTime showTime = DateTime.Now;
        //        this.agileRichTextBox_history.AppendRichText(string.Format("{0}  {1}\n", "系统", showTime), null, null, Color.DarkGray);
        //        string showText = string.Format("文件{0}下载失败！\n ", projectName);
        //        this.agileRichTextBox_history.AppendRichText(showText, null, null, Color.DarkGray);
        //        this.agileRichTextBox_history.ScrollToCaret();
        //    }
        //}
        #endregion

        #region 截屏
                
        private void toolStripButton_cut_Click(object sender, EventArgs e)
        {
            try
            {
                CaptureScreenForm form = new CaptureScreenForm();

                if (DialogResult.Cancel == form.ShowDialog())
                {
                    return;
                }
                if (form.CaptureRegion.Width == 0 && form.CaptureRegion.Height == 0)
                {
                    return;
                }
                Bitmap bitmap = ESBasic.Helpers.ScreenHelper.CaptureScreen(form.CaptureRegion);               
                this.chatBox_send.InsertImage(bitmap);               
            }
            catch (Exception ee)
            {
                Program.Logger.Log(ee, "TextChatControl.toolStripButton_cut_Click", ESBasic.Loggers.ErrorLevel.High);
                MessageBox.Show(ee.Message);
            }

        } 
        #endregion

        private void toolStripButton1_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void toolStripButton1_MouseUp(object sender, MouseEventArgs e)
        {
            this.SetEmotionFormLocation();
            this.emotionForm.Visible = !this.emotionForm.Visible;
        }       
        
    }   
}
