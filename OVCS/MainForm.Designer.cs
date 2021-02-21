using OMCS.Boost.MultiChat;
namespace OVCS
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_systemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.设备测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.授权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_User = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_runtime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_lastMessage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.panel_right = new System.Windows.Forms.Panel();
            this.multiVideoChatContainer1 = new OMCS.Boost.MultiChat.MultiVideoChatContainer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel_mid = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.whiteBoardConnector1 = new OMCS.Passive.WhiteBoard.WhiteBoardConnector();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.nDiskBrowser1 = new ESFramework.Boost.NetworkDisk.Passive.NDiskBrowser();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textChatControl1 = new OVCS.TextChatControl();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel_right.SuspendLayout();
            this.panel_mid.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具ToolStripMenuItem,
            this.授权ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1013, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_systemSetting,
            this.设备测试ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // ToolStripMenuItem_systemSetting
            // 
            this.ToolStripMenuItem_systemSetting.Name = "ToolStripMenuItem_systemSetting";
            this.ToolStripMenuItem_systemSetting.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_systemSetting.Text = "系统设置";
            this.ToolStripMenuItem_systemSetting.Click += new System.EventHandler(this.ToolStripMenuItem_systemSetting_Click);
            // 
            // 设备测试ToolStripMenuItem
            // 
            this.设备测试ToolStripMenuItem.Name = "设备测试ToolStripMenuItem";
            this.设备测试ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设备测试ToolStripMenuItem.Text = "设备测试";
            this.设备测试ToolStripMenuItem.Click += new System.EventHandler(this.设备测试ToolStripMenuItem_Click);
            // 
            // 授权ToolStripMenuItem
            // 
            this.授权ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.授权ToolStripMenuItem.Name = "授权ToolStripMenuItem";
            this.授权ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.授权ToolStripMenuItem.Text = "授权";
            this.授权ToolStripMenuItem.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_User,
            this.toolStripSeparator1,
            this.toolStripLabel_runtime,
            this.toolStripLabel_lastMessage,
            this.toolStripLabel1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 676);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1013, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "当前用户：aa01";
            // 
            // toolStripLabel_User
            // 
            this.toolStripLabel_User.Name = "toolStripLabel_User";
            this.toolStripLabel_User.Size = new System.Drawing.Size(96, 22);
            this.toolStripLabel_User.Text = "当前用户：aa01";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_runtime
            // 
            this.toolStripLabel_runtime.Name = "toolStripLabel_runtime";
            this.toolStripLabel_runtime.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel_runtime.Text = "      ";
            // 
            // toolStripLabel_lastMessage
            // 
            this.toolStripLabel_lastMessage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_lastMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripLabel_lastMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripLabel_lastMessage.Name = "toolStripLabel_lastMessage";
            this.toolStripLabel_lastMessage.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel_lastMessage.Text = "-";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.BackgroundImage = global::OVCS.Properties.Resources.MinIcons_005;
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::OVCS.Properties.Resources.MinIcons_005;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "最新消息";
            // 
            // panel_right
            // 
            this.panel_right.Controls.Add(this.multiVideoChatContainer1);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_right.Location = new System.Drawing.Point(763, 25);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(250, 651);
            this.panel_right.TabIndex = 11;
            // 
            // multiVideoChatContainer1
            // 
            this.multiVideoChatContainer1.BackColor = System.Drawing.Color.Transparent;
            this.multiVideoChatContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiVideoChatContainer1.Location = new System.Drawing.Point(0, 0);
            this.multiVideoChatContainer1.Name = "multiVideoChatContainer1";
            this.multiVideoChatContainer1.Size = new System.Drawing.Size(250, 651);
            this.multiVideoChatContainer1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(760, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 651);
            this.splitter1.TabIndex = 12;
            this.splitter1.TabStop = false;
            // 
            // panel_mid
            // 
            this.panel_mid.Controls.Add(this.tabControl1);
            this.panel_mid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_mid.Location = new System.Drawing.Point(0, 25);
            this.panel_mid.Name = "panel_mid";
            this.panel_mid.Size = new System.Drawing.Size(760, 651);
            this.panel_mid.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 651);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.whiteBoardConnector1);
            this.tabPage1.ImageIndex = 1;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 624);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "电子白板";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // whiteBoardConnector1
            // 
            this.whiteBoardConnector1.AutoReconnect = false;
            this.whiteBoardConnector1.BackImageOfPage = null;
            this.whiteBoardConnector1.ContextMenuEnglish = false;
            this.whiteBoardConnector1.CoursewareEnabled = true;
            this.whiteBoardConnector1.Cursor = System.Windows.Forms.Cursors.No;
            this.whiteBoardConnector1.DisplayPageBorder = false;
            this.whiteBoardConnector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whiteBoardConnector1.FocusOnNewViewByOther = true;
            this.whiteBoardConnector1.IsManager = true;
            this.whiteBoardConnector1.Location = new System.Drawing.Point(3, 3);
            this.whiteBoardConnector1.MinimumSize = new System.Drawing.Size(530, 200);
            this.whiteBoardConnector1.Name = "whiteBoardConnector1";
            this.whiteBoardConnector1.PageSize = new System.Drawing.Size(800, 600);
            this.whiteBoardConnector1.Size = new System.Drawing.Size(746, 618);
            this.whiteBoardConnector1.TabIndex = 0;
            this.whiteBoardConnector1.Timeout4LoadContent = 120;
            this.whiteBoardConnector1.ToolBarVisiable = true;
            this.whiteBoardConnector1.WaitOwnerOnlineSpanInSecs = 0;
            this.whiteBoardConnector1.WatchingOnly = false;
            this.whiteBoardConnector1.ZoomFactor = OMCS.Passive.WhiteBoard.WhiteBoardZoomFactor.Percent100;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textChatControl1);
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 624);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "即时消息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.nDiskBrowser1);
            this.tabPage3.ImageIndex = 3;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(752, 624);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "共享文件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // nDiskBrowser1
            // 
            this.nDiskBrowser1.AllowDrop = true;
            this.nDiskBrowser1.AllowUploadFolder = false;
            this.nDiskBrowser1.BackColor = System.Drawing.Color.Transparent;
            this.nDiskBrowser1.Connected = true;
            this.nDiskBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nDiskBrowser1.Location = new System.Drawing.Point(0, 0);
            this.nDiskBrowser1.LockRootDirectory = false;
            this.nDiskBrowser1.Name = "nDiskBrowser1";
            this.nDiskBrowser1.NetDiskID = "";
            this.nDiskBrowser1.Size = new System.Drawing.Size(752, 624);
            this.nDiskBrowser1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "即时消息.png");
            this.imageList1.Images.SetKeyName(1, "1330593377_applications-education.png");
            this.imageList1.Images.SetKeyName(2, "远程桌面.png");
            this.imageList1.Images.SetKeyName(3, "文件共享.png");
            this.imageList1.Images.SetKeyName(4, "Master.ico");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(893, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "共享桌面";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textChatControl1
            // 
            this.textChatControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textChatControl1.Location = new System.Drawing.Point(3, 3);
            this.textChatControl1.Name = "textChatControl1";
            this.textChatControl1.Size = new System.Drawing.Size(746, 618);
            this.textChatControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 701);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.panel_mid);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "吉林省民航机场集团公司视频会议系统(测试版)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_right.ResumeLayout(false);
            this.panel_mid.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }   
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_User;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel_mid;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private TextChatControl textChatControl1;
        private OMCS.Passive.WhiteBoard.WhiteBoardConnector whiteBoardConnector1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_systemSetting;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_runtime;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_lastMessage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private MultiVideoChatContainer multiVideoChatContainer1;
        private System.Windows.Forms.ToolStripMenuItem 授权ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private ESFramework.Boost.NetworkDisk.Passive.NDiskBrowser nDiskBrowser1;
        private System.Windows.Forms.ToolStripMenuItem 设备测试ToolStripMenuItem;
    }
}

