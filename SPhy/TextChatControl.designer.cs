namespace OVCS
{
    partial class TextChatControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextChatControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chatBox_send = new ESFramework.Boost.Controls.ChatBox();
            this.button_send = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_cut = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.chatBox_his = new ESFramework.Boost.Controls.ChatBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chatBox_send);
            this.panel1.Controls.Add(this.button_send);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 112);
            this.panel1.TabIndex = 6;
            // 
            // chatBox_send
            // 
            this.chatBox_send.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBox_send.ContextMenuMode = ESFramework.Boost.Controls.ChatBoxContextMenuMode.None;
            this.chatBox_send.Location = new System.Drawing.Point(1, 28);
            this.chatBox_send.Name = "chatBox_send";
            this.chatBox_send.PopoutImageWhenDoubleClick = false;
            this.chatBox_send.Size = new System.Drawing.Size(331, 53);
            this.chatBox_send.TabIndex = 11;
            this.chatBox_send.Text = "";
            // 
            // button_send
            // 
            this.button_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_send.Location = new System.Drawing.Point(281, 87);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(50, 22);
            this.button_send.TabIndex = 10;
            this.button_send.Text = "发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton_cut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(334, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "表情";          
            this.toolStripButton1.MouseEnter += new System.EventHandler(this.toolStripButton1_MouseEnter);
            this.toolStripButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStripButton1_MouseUp);
            // 
            // toolStripButton_cut
            // 
            this.toolStripButton_cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_cut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_cut.Image")));
            this.toolStripButton_cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_cut.Name = "toolStripButton_cut";
            this.toolStripButton_cut.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_cut.Text = "截屏";
            this.toolStripButton_cut.Click += new System.EventHandler(this.toolStripButton_cut_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Color = System.Drawing.SystemColors.ControlText;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 121);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(334, 3);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // chatBox_his
            // 
            this.chatBox_his.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBox_his.ContextMenuMode = ESFramework.Boost.Controls.ChatBoxContextMenuMode.ForOutput;
            this.chatBox_his.Location = new System.Drawing.Point(1, 3);
            this.chatBox_his.Name = "chatBox_his";
            this.chatBox_his.PopoutImageWhenDoubleClick = true;
            this.chatBox_his.Size = new System.Drawing.Size(331, 121);
            this.chatBox_his.TabIndex = 8;
            this.chatBox_his.Text = "";
            // 
            // TextChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chatBox_his);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Name = "TextChatControl";
            this.Size = new System.Drawing.Size(334, 236);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripButton toolStripButton_cut;
        private ESFramework.Boost.Controls.ChatBox chatBox_send;
        private ESFramework.Boost.Controls.ChatBox chatBox_his;
    }
}
