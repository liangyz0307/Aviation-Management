namespace OVCS
{
    partial class SelectGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectGroupForm));
            this.button_goinSelfGroup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ownerID = new System.Windows.Forms.TextBox();
            this.textBox_roomPassword = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_goinSelfGroup
            // 
            this.button_goinSelfGroup.BackColor = System.Drawing.Color.Lavender;
            this.button_goinSelfGroup.Location = new System.Drawing.Point(84, 12);
            this.button_goinSelfGroup.Name = "button_goinSelfGroup";
            this.button_goinSelfGroup.Size = new System.Drawing.Size(194, 23);
            this.button_goinSelfGroup.TabIndex = 14;
            this.button_goinSelfGroup.Text = "进入自己房间";
            this.button_goinSelfGroup.UseVisualStyleBackColor = false;
            this.button_goinSelfGroup.Click += new System.EventHandler(this.button_goinSelfGroup_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox_ownerID);
            this.groupBox2.Controls.Add(this.textBox_roomPassword);
            this.groupBox2.Location = new System.Drawing.Point(4, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 130);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "进入他人房间";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(199, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "进入";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "房主帐号：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "房间密码：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_ownerID
            // 
            this.textBox_ownerID.Location = new System.Drawing.Point(80, 30);
            this.textBox_ownerID.Name = "textBox_ownerID";
            this.textBox_ownerID.Size = new System.Drawing.Size(194, 21);
            this.textBox_ownerID.TabIndex = 14;
            // 
            // textBox_roomPassword
            // 
            this.textBox_roomPassword.Location = new System.Drawing.Point(80, 71);
            this.textBox_roomPassword.Name = "textBox_roomPassword";
            this.textBox_roomPassword.Size = new System.Drawing.Size(194, 21);
            this.textBox_roomPassword.TabIndex = 15;
            // 
            // SelectGroupForm
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 196);
            this.Controls.Add(this.button_goinSelfGroup);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "房间选择";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_goinSelfGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ownerID;
        private System.Windows.Forms.TextBox textBox_roomPassword;

    }
}