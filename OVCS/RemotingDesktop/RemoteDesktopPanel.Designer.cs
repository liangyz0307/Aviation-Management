namespace OVCS
{
    partial class RemoteDesktopPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteDesktopPanel));
            this.dynamicDesktopConnector1 = new OMCS.Passive.RemoteDesktop.DynamicDesktopConnector(this.components);
            this.desktopPanel1 = new OMCS.Passive.RemoteDesktop.DesktopPanel();
            this.panel_top = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_out = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_fullScreen = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_top.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dynamicDesktopConnector1
            // 
            this.dynamicDesktopConnector1.AdaptiveToViewerSize = false;
            this.dynamicDesktopConnector1.DisplayVideoParameters = true;
            this.dynamicDesktopConnector1.ShowMouseCursor = true;
            this.dynamicDesktopConnector1.WaitOwnerOnlineSpanInSecs = 0;
            this.dynamicDesktopConnector1.WatchingOnly = true;
            // 
            // desktopPanel1
            // 
            this.desktopPanel1.BackColor = System.Drawing.Color.White;
            this.desktopPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktopPanel1.Location = new System.Drawing.Point(0, 0);
            this.desktopPanel1.Name = "desktopPanel1";
            this.desktopPanel1.Size = new System.Drawing.Size(501, 308);
            this.desktopPanel1.TabIndex = 0;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.toolStrip1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(501, 36);
            this.panel_top.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_out,
            this.toolStripButton_fullScreen});
            this.toolStrip1.Location = new System.Drawing.Point(4, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(75, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_out
            // 
            this.toolStripButton_out.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_out.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_out.Image")));
            this.toolStripButton_out.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_out.Name = "toolStripButton_out";
            this.toolStripButton_out.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton_out.Text = "浮出";
            this.toolStripButton_out.Click += new System.EventHandler(this.toolStripButton_out_Click);
            // 
            // toolStripButton_fullScreen
            // 
            this.toolStripButton_fullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_fullScreen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_fullScreen.Image")));
            this.toolStripButton_fullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_fullScreen.Name = "toolStripButton_fullScreen";
            this.toolStripButton_fullScreen.Size = new System.Drawing.Size(36, 22);
            this.toolStripButton_fullScreen.Text = "全屏";
            this.toolStripButton_fullScreen.Click += new System.EventHandler(this.toolStripButton_fullScreen_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 36);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(501, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.desktopPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 308);
            this.panel1.TabIndex = 3;
            // 
            // RemoteDesktopPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel_top);
            this.Name = "RemoteDesktopPanel";
            this.Size = new System.Drawing.Size(501, 347);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OMCS.Passive.RemoteDesktop.DynamicDesktopConnector dynamicDesktopConnector1;
        private OMCS.Passive.RemoteDesktop.DesktopPanel desktopPanel1;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_out;
        private System.Windows.Forms.ToolStripButton toolStripButton_fullScreen;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;

    }
}
