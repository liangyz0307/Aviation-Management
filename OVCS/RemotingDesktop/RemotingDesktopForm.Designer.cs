namespace OVCS
{
    partial class RemotingDesktopForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemotingDesktopForm));
            this.desktopPanel1 = new OMCS.Passive.Video.VideoPanel();
            this.SuspendLayout();
            // 
            // desktopPanel1
            // 
            this.desktopPanel1.BackColor = System.Drawing.Color.White;
            this.desktopPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktopPanel1.Location = new System.Drawing.Point(0, 0);
            this.desktopPanel1.Name = "desktopPanel1";
            this.desktopPanel1.Size = new System.Drawing.Size(652, 451);
            this.desktopPanel1.TabIndex = 0;
            // 
            // RemotingDesktopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 451);
            this.Controls.Add(this.desktopPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RemotingDesktopForm";
            this.Text = "RemotingDesktopForm";           
            this.ResumeLayout(false);

        }

        #endregion

        private OMCS.Passive.Video.VideoPanel desktopPanel1;


    }
}