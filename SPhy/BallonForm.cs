using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OVCS
{
    public partial class BallonForm : Form
    {
        public BallonForm()
        {
            InitializeComponent();
        }

        public void ScrollShow(string message)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ESBasic.CbGeneric<string>(this.ScrollShow), message);
            }
            else
            {
                this.Visible = true;
                this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.MaximumSize.Width - 10, Screen.PrimaryScreen.WorkingArea.Height-38);
                
                this.label_message.Text = message;
                this.Show();
                this.Width = this.MaximumSize.Width;
                this.Height = 0;
                this.timer_up.Enabled = true;
                            
            }
        }

        private void ScrollUp()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ESBasic.CbGeneric(this.ScrollUp));
            }
            else
            {
                if (this.Height < this.MaximumSize.Height)
                {
                    this.Height += 5;
                    this.Location = new Point(this.Location.X, this.Location.Y - 5);
                }
                else
                {
                    this.timer_up.Enabled = false;
                    this.timer_wait.Enabled = true;
                }
            }
        }

        private void ScrollDown()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ESBasic.CbGeneric(this.ScrollDown));
            }
            else
            {
                if (Height > 38)
                {
                    this.Height -= 5;
                    this.Location = new Point(this.Location.X, this.Location.Y + 5);

                }
                else
                {
                    this.timer_down.Enabled = false;
                    this.Close();
                    this.Dispose();
                }
            }
        }

       

        private void timer_up_Tick(object sender, EventArgs e)
        {
            ScrollUp(); 
        }

        private void timer_down_Tick(object sender, EventArgs e)
        {
            ScrollDown(); 
        }

        private void BallonForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                timer_up.Enabled = false;
                timer_down.Enabled = true;
                this.timer_wait.Enabled = false;
            }
        }

        private void timer_wait_Tick(object sender, EventArgs e)
        {
            timer_up.Enabled = false;
            timer_down.Enabled = true;
            this.timer_wait.Enabled = false;
        }       


    }
}
