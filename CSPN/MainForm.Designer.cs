namespace CSPN
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnMsgShow = new System.Windows.Forms.ToolStripButton();
            this.btnPendingMsg = new System.Windows.Forms.ToolStripButton();
            this.btnMessagelog = new System.Windows.Forms.ToolStripButton();
            this.btnMaintain = new System.Windows.Forms.ToolStripButton();
            this.btnStatementManage = new System.Windows.Forms.ToolStripButton();
            this.btnSystemSettings = new System.Windows.Forms.ToolStripButton();
            this.lbUserName = new System.Windows.Forms.ToolStripLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMsgShow,
            this.btnPendingMsg,
            this.btnMessagelog,
            this.btnMaintain,
            this.btnStatementManage,
            this.btnSystemSettings,
            this.lbUserName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1084, 72);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnMsgShow
            // 
            this.btnMsgShow.Image = ((System.Drawing.Image)(resources.GetObject("btnMsgShow.Image")));
            this.btnMsgShow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMsgShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMsgShow.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMsgShow.Name = "btnMsgShow";
            this.btnMsgShow.Size = new System.Drawing.Size(84, 72);
            this.btnMsgShow.Text = "人井信息显示";
            this.btnMsgShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMsgShow.Click += new System.EventHandler(this.btnMsgShow_Click);
            // 
            // btnPendingMsg
            // 
            this.btnPendingMsg.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPendingMsg.Image = ((System.Drawing.Image)(resources.GetObject("btnPendingMsg.Image")));
            this.btnPendingMsg.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPendingMsg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPendingMsg.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnPendingMsg.Name = "btnPendingMsg";
            this.btnPendingMsg.Size = new System.Drawing.Size(78, 72);
            this.btnPendingMsg.Text = "待处理信息";
            this.btnPendingMsg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPendingMsg.Click += new System.EventHandler(this.btnPendingMsg_Click);
            // 
            // btnMessagelog
            // 
            this.btnMessagelog.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMessagelog.Image = ((System.Drawing.Image)(resources.GetObject("btnMessagelog.Image")));
            this.btnMessagelog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMessagelog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMessagelog.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMessagelog.Name = "btnMessagelog";
            this.btnMessagelog.Size = new System.Drawing.Size(91, 72);
            this.btnMessagelog.Text = "人井消息日志";
            this.btnMessagelog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMessagelog.Click += new System.EventHandler(this.btnMessagelog_Click);
            // 
            // btnMaintain
            // 
            this.btnMaintain.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMaintain.Image = ((System.Drawing.Image)(resources.GetObject("btnMaintain.Image")));
            this.btnMaintain.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMaintain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMaintain.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMaintain.Name = "btnMaintain";
            this.btnMaintain.Size = new System.Drawing.Size(65, 72);
            this.btnMaintain.Text = "预约维护";
            this.btnMaintain.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMaintain.Click += new System.EventHandler(this.btnMaintain_Click);
            // 
            // btnStatementManage
            // 
            this.btnStatementManage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStatementManage.Image = ((System.Drawing.Image)(resources.GetObject("btnStatementManage.Image")));
            this.btnStatementManage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStatementManage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStatementManage.Margin = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnStatementManage.Name = "btnStatementManage";
            this.btnStatementManage.Size = new System.Drawing.Size(65, 72);
            this.btnStatementManage.Text = "报表管理";
            this.btnStatementManage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStatementManage.Click += new System.EventHandler(this.btnStatementManage_Click);
            // 
            // btnSystemSettings
            // 
            this.btnSystemSettings.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSystemSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSystemSettings.Image")));
            this.btnSystemSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSystemSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSystemSettings.Margin = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSystemSettings.Name = "btnSystemSettings";
            this.btnSystemSettings.Size = new System.Drawing.Size(65, 72);
            this.btnSystemSettings.Text = "系统管理";
            this.btnSystemSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSystemSettings.Click += new System.EventHandler(this.btnSystemSettings_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lbUserName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(79, 69);
            this.lbUserName.Text = "欢迎回来！";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelMain.Location = new System.Drawing.Point(0, 72);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1084, 539);
            this.panelMain.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人井监控管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripButton btnPendingMsg;
        private System.Windows.Forms.ToolStripButton btnMessagelog;
        private System.Windows.Forms.ToolStripButton btnMaintain;
        private System.Windows.Forms.ToolStripButton btnStatementManage;
        private System.Windows.Forms.ToolStripButton btnSystemSettings;
        private System.Windows.Forms.ToolStripButton btnMsgShow;
        private System.Windows.Forms.ToolStripLabel lbUserName;


    }
}