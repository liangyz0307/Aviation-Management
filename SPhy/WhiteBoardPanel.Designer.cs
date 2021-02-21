namespace OVCS
{
    partial class WhiteBoardPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhiteBoardPanel));
            OMCS.Engine.Paint.Messages.Passive.WhitBoardDataSendingParas whitBoardDataSendingParas2 = new  OMCS.Engine.Paint.Messages.Passive.WhitBoardDataSendingParas();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripLabel_progress = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_first = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_pre = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_totalCount = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_next = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_end = new System.Windows.Forms.ToolStripButton();
            this.whiteBoardConnector1 = new OMCS.Passive.WhiteBoard.WhiteBoardConnector();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_progress,
            this.toolStripProgressBar1,
            this.toolStripButton_end,
            this.toolStripButton_next,
            this.toolStripLabel_totalCount,
            this.toolStripButton_pre,
            this.toolStripButton_first});
            this.toolStrip1.Location = new System.Drawing.Point(0, 398);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(587, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripLabel_progress
            // 
            this.toolStripLabel_progress.Name = "toolStripLabel_progress";
            this.toolStripLabel_progress.Size = new System.Drawing.Size(111, 22);
            this.toolStripLabel_progress.Text = "正在下载课件：1/4";
            // 
            // toolStripButton_first
            // 
            this.toolStripButton_first.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_first.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_first.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_first.Image")));
            this.toolStripButton_first.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_first.Name = "toolStripButton_first";
            this.toolStripButton_first.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_first.Text = "首页";
            // 
            // toolStripButton_pre
            // 
            this.toolStripButton_pre.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_pre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_pre.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_pre.Image")));
            this.toolStripButton_pre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_pre.Name = "toolStripButton_pre";
            this.toolStripButton_pre.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_pre.Text = "上一页";
            // 
            // toolStripLabel_totalCount
            // 
            this.toolStripLabel_totalCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_totalCount.Name = "toolStripLabel_totalCount";
            this.toolStripLabel_totalCount.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabel_totalCount.Text = "第 1 / 6 页";
            // 
            // toolStripButton_next
            // 
            this.toolStripButton_next.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_next.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_next.Image")));
            this.toolStripButton_next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_next.Name = "toolStripButton_next";
            this.toolStripButton_next.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_next.Text = "下一页";
            // 
            // toolStripButton_end
            // 
            this.toolStripButton_end.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_end.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_end.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_end.Image")));
            this.toolStripButton_end.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_end.Name = "toolStripButton_end";
            this.toolStripButton_end.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_end.Text = "末页";
            // 
            // whiteBoardConnector1
            // 
            this.whiteBoardConnector1.AutoReconnect = false;
            this.whiteBoardConnector1.BackImageOfPage = null;
            this.whiteBoardConnector1.ContextMenuEnglish = false;
            this.whiteBoardConnector1.Cursor = System.Windows.Forms.Cursors.No;
            this.whiteBoardConnector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whiteBoardConnector1.FocusOnNewViewByOther = true;            
            this.whiteBoardConnector1.Location = new System.Drawing.Point(0, 0);
            this.whiteBoardConnector1.Name = "whiteBoardConnector1";
            this.whiteBoardConnector1.PageSize = new System.Drawing.Size(800, 600);
            this.whiteBoardConnector1.Size = new System.Drawing.Size(587, 398);
            this.whiteBoardConnector1.TabIndex = 1;
            this.whiteBoardConnector1.Timeout4LoadContent = 120;
            this.whiteBoardConnector1.WaitOwnerOnlineSpanInSecs = 0;
            this.whiteBoardConnector1.WatchingOnly = false;
            whitBoardDataSendingParas2.FragmentSize = 2048;
            whitBoardDataSendingParas2.SendingSpanInMSecs = 0;            
            // 
            // WhiteBoardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.whiteBoardConnector1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WhiteBoardPanel";
            this.Size = new System.Drawing.Size(587, 423);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_progress;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton toolStripButton_end;
        private System.Windows.Forms.ToolStripButton toolStripButton_next;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_totalCount;
        private System.Windows.Forms.ToolStripButton toolStripButton_pre;
        private System.Windows.Forms.ToolStripButton toolStripButton_first;
        private OMCS.Passive.WhiteBoard.WhiteBoardConnector whiteBoardConnector1;
    }
}
