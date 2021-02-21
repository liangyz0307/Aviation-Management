namespace OVCS
{
    partial class BallonForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BallonForm));
            this.label_message = new System.Windows.Forms.Label();
            this.timer_up = new System.Windows.Forms.Timer(this.components);
            this.timer_down = new System.Windows.Forms.Timer(this.components);
            this.timer_wait = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label_message
            // 
            this.label_message.Location = new System.Drawing.Point(12, 15);
            this.label_message.Name = "label_message";
            this.label_message.Size = new System.Drawing.Size(156, 45);
            this.label_message.TabIndex = 0;
            this.label_message.Text = "一小時了，該休息了! ";
            // 
            // timer_up
            // 
            this.timer_up.Tick += new System.EventHandler(this.timer_up_Tick);
            // 
            // timer_down
            // 
            this.timer_down.Tick += new System.EventHandler(this.timer_down_Tick);
            // 
            // timer_wait
            // 
            this.timer_wait.Interval = 10000;
            this.timer_wait.Tick += new System.EventHandler(this.timer_wait_Tick);
            // 
            // BallonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(174, 72);
            this.Controls.Add(this.label_message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(180, 100);
            this.MinimizeBox = false;
            this.Name = "BallonForm";
            this.ShowInTaskbar = false;
            this.Text = "OVCS";
            this.TopMost = true;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BallonForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Timer timer_up;
        private System.Windows.Forms.Timer timer_down;
        private System.Windows.Forms.Timer timer_wait;
    }
}