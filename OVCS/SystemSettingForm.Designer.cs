namespace OVCS
{
    partial class SystemSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemSettingForm));
            this.comboBox_webcam = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton_closeButtball = new System.Windows.Forms.RadioButton();
            this.radioButton_openButtball = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_webcam
            // 
            this.comboBox_webcam.BackColor = System.Drawing.Color.White;
            this.comboBox_webcam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_webcam.FormattingEnabled = true;
            this.comboBox_webcam.Location = new System.Drawing.Point(12, 37);
            this.comboBox_webcam.Name = "comboBox_webcam";
            this.comboBox_webcam.Size = new System.Drawing.Size(204, 20);
            this.comboBox_webcam.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "摄像头选择：";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(78, 102);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 15;
            this.button_ok.Text = "确 定";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "气泡提示：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton_closeButtball);
            this.panel2.Controls.Add(this.radioButton_openButtball);
            this.panel2.Location = new System.Drawing.Point(8, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 33);
            this.panel2.TabIndex = 20;
            // 
            // radioButton_closeButtball
            // 
            this.radioButton_closeButtball.AutoSize = true;
            this.radioButton_closeButtball.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_closeButtball.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton_closeButtball.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_closeButtball.Location = new System.Drawing.Point(129, 5);
            this.radioButton_closeButtball.Name = "radioButton_closeButtball";
            this.radioButton_closeButtball.Size = new System.Drawing.Size(46, 16);
            this.radioButton_closeButtball.TabIndex = 19;
            this.radioButton_closeButtball.Text = "关闭";
            this.radioButton_closeButtball.UseVisualStyleBackColor = false;
            // 
            // radioButton_openButtball
            // 
            this.radioButton_openButtball.AutoSize = true;
            this.radioButton_openButtball.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_openButtball.Checked = true;
            this.radioButton_openButtball.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButton_openButtball.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_openButtball.Location = new System.Drawing.Point(70, 5);
            this.radioButton_openButtball.Name = "radioButton_openButtball";
            this.radioButton_openButtball.Size = new System.Drawing.Size(52, 16);
            this.radioButton_openButtball.TabIndex = 18;
            this.radioButton_openButtball.TabStop = true;
            this.radioButton_openButtball.Text = "开启 ";
            this.radioButton_openButtball.UseVisualStyleBackColor = false;
            // 
            // SystemSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 140);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.comboBox_webcam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置 ";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_webcam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton_closeButtball;
        private System.Windows.Forms.RadioButton radioButton_openButtball;
    }
}