using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OMCS.Passive.RemoteDesktop;

namespace OVCS
{
    public partial class RemotingDesktopForm : Form
    {
        public OMCS.Passive.Video.VideoPanel DesktopPanel
        {
            get { return this.desktopPanel1; }
        }

        public RemotingDesktopForm(string formText)
        {
            InitializeComponent();
            this.Text = formText;
        }        
        
        protected override bool ProcessDialogKey(Keys keyData)
        {           
            if (keyData == Keys.Escape)
            {
                this.Close();
            }           
            return true;
        }

        public void FullScreen()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            
            this.BackColor = Color.Black;
            this.TopMost = true;
        }

        public void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ESBasic.CbGeneric(this.CloseForm));
            }
            else
            {
                this.Close();
            }
        }
        

       
       

        


        

       
      

       
    }
}
