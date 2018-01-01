namespace CSPN.control
{
    partial class LogInfoControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInfoControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPagesys = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Sysgrid = new System.Windows.Forms.DataGridView();
            this.Sys_Happen_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Well_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Humidity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Smoke_Detector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Smoke_Power = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signal_Strength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Syspage = new CSPN.assistcontrol.DataGridPage();
            this.btnSysOut = new System.Windows.Forms.Button();
            this.TabPageuser = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.userpage = new CSPN.assistcontrol.DataGridPage();
            this.btnUserOut = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.TabPagesys.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sysgrid)).BeginInit();
            this.TabPageuser.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPagesys);
            this.tabControl1.Controls.Add(this.TabPageuser);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(967, 467);
            this.tabControl1.TabIndex = 0;
            // 
            // TabPagesys
            // 
            this.TabPagesys.Controls.Add(this.tableLayoutPanel1);
            this.TabPagesys.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabPagesys.Location = new System.Drawing.Point(4, 29);
            this.TabPagesys.Name = "TabPagesys";
            this.TabPagesys.Padding = new System.Windows.Forms.Padding(3);
            this.TabPagesys.Size = new System.Drawing.Size(959, 434);
            this.TabPagesys.TabIndex = 0;
            this.TabPagesys.Text = "系统日志信息";
            this.TabPagesys.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Sysgrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Syspage, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSysOut, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(953, 428);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Sysgrid
            // 
            this.Sysgrid.AllowUserToAddRows = false;
            this.Sysgrid.AllowUserToDeleteRows = false;
            this.Sysgrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sysgrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Sysgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Sysgrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Sysgrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Sysgrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.Sysgrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Sysgrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Sysgrid.ColumnHeadersHeight = 30;
            this.Sysgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sys_Happen_Time,
            this.Terminal_ID,
            this.Terminal_Name,
            this.Place,
            this.Well_State,
            this.Temperature,
            this.Humidity,
            this.Smoke_Detector,
            this.Smoke_Power,
            this.Signal_Strength});
            this.Sysgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sysgrid.GridColor = System.Drawing.Color.Blue;
            this.Sysgrid.Location = new System.Drawing.Point(3, 44);
            this.Sysgrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Sysgrid.MultiSelect = false;
            this.Sysgrid.Name = "Sysgrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Sysgrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Sysgrid.RowHeadersVisible = false;
            this.Sysgrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sysgrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Sysgrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sysgrid.RowTemplate.Height = 35;
            this.Sysgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Sysgrid.Size = new System.Drawing.Size(947, 340);
            this.Sysgrid.TabIndex = 15;
            // 
            // Sys_Happen_Time
            // 
            this.Sys_Happen_Time.DataPropertyName = "Happen_Time";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.Sys_Happen_Time.DefaultCellStyle = dataGridViewCellStyle3;
            this.Sys_Happen_Time.HeaderText = "发生时间";
            this.Sys_Happen_Time.Name = "Sys_Happen_Time";
            this.Sys_Happen_Time.ReadOnly = true;
            // 
            // Terminal_ID
            // 
            this.Terminal_ID.DataPropertyName = "Terminal_ID";
            this.Terminal_ID.HeaderText = "人井编号";
            this.Terminal_ID.Name = "Terminal_ID";
            this.Terminal_ID.ReadOnly = true;
            // 
            // Terminal_Name
            // 
            this.Terminal_Name.DataPropertyName = "Name";
            this.Terminal_Name.HeaderText = "人井名称";
            this.Terminal_Name.Name = "Terminal_Name";
            this.Terminal_Name.ReadOnly = true;
            // 
            // Place
            // 
            this.Place.DataPropertyName = "Place";
            this.Place.HeaderText = "地点";
            this.Place.Name = "Place";
            this.Place.ReadOnly = true;
            // 
            // Well_State
            // 
            this.Well_State.DataPropertyName = "Well_State";
            this.Well_State.HeaderText = "人井状态";
            this.Well_State.Name = "Well_State";
            this.Well_State.ReadOnly = true;
            // 
            // Temperature
            // 
            this.Temperature.DataPropertyName = "Temperature";
            this.Temperature.HeaderText = "温度";
            this.Temperature.Name = "Temperature";
            this.Temperature.ReadOnly = true;
            // 
            // Humidity
            // 
            this.Humidity.DataPropertyName = "Humidity";
            this.Humidity.HeaderText = "湿度";
            this.Humidity.Name = "Humidity";
            this.Humidity.ReadOnly = true;
            // 
            // Smoke_Detector
            // 
            this.Smoke_Detector.DataPropertyName = "Smoke_Detector";
            this.Smoke_Detector.HeaderText = "烟感";
            this.Smoke_Detector.Name = "Smoke_Detector";
            this.Smoke_Detector.ReadOnly = true;
            // 
            // Smoke_Power
            // 
            this.Smoke_Power.DataPropertyName = "Smoke_Power";
            this.Smoke_Power.HeaderText = "烟感电量";
            this.Smoke_Power.Name = "Smoke_Power";
            this.Smoke_Power.ReadOnly = true;
            // 
            // Signal_Strength
            // 
            this.Signal_Strength.DataPropertyName = "Signal_Strength";
            this.Signal_Strength.HeaderText = "信号强度";
            this.Signal_Strength.Name = "Signal_Strength";
            this.Signal_Strength.ReadOnly = true;
            this.Signal_Strength.ToolTipText = "取值从00到31。若为99，表示无信号。";
            // 
            // Syspage
            // 
            this.Syspage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Syspage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Syspage.Location = new System.Drawing.Point(3, 392);
            this.Syspage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Syspage.Name = "Syspage";
            this.Syspage.PageCount = 0;
            this.Syspage.PageIndex = 1;
            this.Syspage.PageSize = 30;
            this.Syspage.RecorderCount = 0;
            this.Syspage.Size = new System.Drawing.Size(947, 32);
            this.Syspage.TabIndex = 0;
            // 
            // btnSysOut
            // 
            this.btnSysOut.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSysOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSysOut.BackgroundImage")));
            this.btnSysOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSysOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSysOut.FlatAppearance.BorderSize = 0;
            this.btnSysOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSysOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSysOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysOut.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSysOut.ForeColor = System.Drawing.Color.White;
            this.btnSysOut.Location = new System.Drawing.Point(810, 5);
            this.btnSysOut.Name = "btnSysOut";
            this.btnSysOut.Size = new System.Drawing.Size(140, 30);
            this.btnSysOut.TabIndex = 14;
            this.btnSysOut.Text = "信息导出(Excel)";
            this.btnSysOut.UseVisualStyleBackColor = true;
            this.btnSysOut.Click += new System.EventHandler(this.btnSysOut_Click);
            // 
            // TabPageuser
            // 
            this.TabPageuser.Controls.Add(this.tableLayoutPanel2);
            this.TabPageuser.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabPageuser.Location = new System.Drawing.Point(4, 29);
            this.TabPageuser.Name = "TabPageuser";
            this.TabPageuser.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageuser.Size = new System.Drawing.Size(959, 434);
            this.TabPageuser.TabIndex = 1;
            this.TabPageuser.Text = "用户日志信息";
            this.TabPageuser.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.userpage, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnUserOut, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbType, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(953, 428);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // userpage
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.userpage, 3);
            this.userpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userpage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userpage.Location = new System.Drawing.Point(3, 392);
            this.userpage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userpage.Name = "userpage";
            this.userpage.PageCount = 0;
            this.userpage.PageIndex = 1;
            this.userpage.PageSize = 30;
            this.userpage.RecorderCount = 0;
            this.userpage.Size = new System.Drawing.Size(947, 32);
            this.userpage.TabIndex = 0;
            // 
            // btnUserOut
            // 
            this.btnUserOut.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUserOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUserOut.BackgroundImage")));
            this.btnUserOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserOut.FlatAppearance.BorderSize = 0;
            this.btnUserOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUserOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUserOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserOut.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserOut.ForeColor = System.Drawing.Color.White;
            this.btnUserOut.Location = new System.Drawing.Point(810, 5);
            this.btnUserOut.Name = "btnUserOut";
            this.btnUserOut.Size = new System.Drawing.Size(140, 30);
            this.btnUserOut.TabIndex = 14;
            this.btnUserOut.Text = "信息导出(Excel)";
            this.btnUserOut.UseVisualStyleBackColor = true;
            this.btnUserOut.Click += new System.EventHandler(this.btnUserOut_Click);
            // 
            // panel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel1, 3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 342);
            this.panel1.TabIndex = 15;
            // 
            // cbType
            // 
            this.cbType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "人井信息日志",
            "一般用户日志"});
            this.cbType.Location = new System.Drawing.Point(103, 6);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(167, 28);
            this.cbType.TabIndex = 16;
            this.cbType.DropDownClosed += new System.EventHandler(this.cbType_DropDownClosed);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 40);
            this.label1.TabIndex = 17;
            this.label1.Text = "日志类型";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LogInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LogInfoControl";
            this.Size = new System.Drawing.Size(967, 467);
            this.Load += new System.EventHandler(this.LogInfoControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabPagesys.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Sysgrid)).EndInit();
            this.TabPageuser.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitializeUserLogInfo_WellInfo()
        {
            gridUserLogInfo_WellInfo = new System.Windows.Forms.DataGridView();
            System.Windows.Forms.DataGridViewTextBoxColumn User_Happen_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn The_Operator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Operation_Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Receive_People = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Notice_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Processor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Process_Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Process_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Current_State = new System.Windows.Forms.DataGridViewTextBoxColumn();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            //
            // this.gridUserLogInfo_GeneralInfo
            // 
            gridUserLogInfo_WellInfo.AllowUserToAddRows = false;
            gridUserLogInfo_WellInfo.AllowUserToDeleteRows = false;
            gridUserLogInfo_WellInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            gridUserLogInfo_WellInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            gridUserLogInfo_WellInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridUserLogInfo_WellInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            gridUserLogInfo_WellInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            gridUserLogInfo_WellInfo.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            gridUserLogInfo_WellInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            gridUserLogInfo_WellInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            gridUserLogInfo_WellInfo.ColumnHeadersHeight = 30;
            gridUserLogInfo_WellInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { User_Happen_Time, The_Operator, Operation_Content, Receive_People, Notice_time, Processor, Process_Content, Process_Time, Current_State });
            gridUserLogInfo_WellInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            gridUserLogInfo_WellInfo.GridColor = System.Drawing.Color.Blue;
            gridUserLogInfo_WellInfo.Location = new System.Drawing.Point(3, 44);
            gridUserLogInfo_WellInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gridUserLogInfo_WellInfo.MultiSelect = false;
            gridUserLogInfo_WellInfo.Name = "this.gridUserLogInfo_GeneralInfo";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            gridUserLogInfo_WellInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            gridUserLogInfo_WellInfo.RowHeadersVisible = false;
            gridUserLogInfo_WellInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            gridUserLogInfo_WellInfo.RowsDefaultCellStyle = dataGridViewCellStyle8;
            gridUserLogInfo_WellInfo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            gridUserLogInfo_WellInfo.RowTemplate.Height = 35;
            gridUserLogInfo_WellInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridUserLogInfo_WellInfo.Size = new System.Drawing.Size(947, 340);
            gridUserLogInfo_WellInfo.TabIndex = 15;
            // 
            // User_Happen_Time
            // 
            User_Happen_Time.DataPropertyName = "Happen_Time";
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            User_Happen_Time.DefaultCellStyle = dataGridViewCellStyle4;
            User_Happen_Time.HeaderText = "发生时间";
            User_Happen_Time.Name = "User_Happen_Time";
            User_Happen_Time.ReadOnly = true;
            // 
            // The_Operator
            // 
            The_Operator.DataPropertyName = "The_Operator";
            The_Operator.HeaderText = "操作者";
            The_Operator.Name = "The_Operator";
            The_Operator.ReadOnly = true;
            // 
            // Operation_Content
            // 
            Operation_Content.DataPropertyName = "Operation_Content";
            Operation_Content.HeaderText = "操作内容";
            Operation_Content.Name = "Operation_Content";
            Operation_Content.ReadOnly = true;
            // 
            // Receive_People
            // 
            Receive_People.DataPropertyName = "Receive_People";
            Receive_People.HeaderText = "接收者";
            Receive_People.Name = "Receive_People";
            Receive_People.ReadOnly = true;
            // 
            // Notice_time
            // 
            Notice_time.DataPropertyName = "Notice_time";
            Notice_time.HeaderText = "通知时间";
            Notice_time.Name = "Notice_time";
            Notice_time.ReadOnly = true;
            // 
            // Processor
            // 
            Processor.DataPropertyName = "Processor";
            Processor.HeaderText = "处理人";
            Processor.Name = "Processor";
            Processor.ReadOnly = true;
            // 
            // Process_Content
            // 
            Process_Content.DataPropertyName = "Process_Content";
            Process_Content.HeaderText = "处理内容";
            Process_Content.Name = "Process_Content";
            Process_Content.ReadOnly = true;
            // 
            // Process_Time
            // 
            Process_Time.DataPropertyName = "Process_Time";
            Process_Time.HeaderText = "处理时间";
            Process_Time.Name = "Process_Time";
            Process_Time.ReadOnly = true;
            // 
            // Current_State
            // 
            Current_State.DataPropertyName = "Current_State";
            Current_State.HeaderText = "是否已处理";
            Current_State.Name = "Current_State";
            Current_State.ReadOnly = true;
        }

        private void InitializeUserLogInfo_GeneralInfo()
        {
            gridUserLogInfo_GeneralInfo = new System.Windows.Forms.DataGridView();
            System.Windows.Forms.DataGridViewTextBoxColumn User_Happen_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn The_Operator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Operation_Content = new System.Windows.Forms.DataGridViewTextBoxColumn();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            // 
            // this.gridUserLogInfo_GeneralInfo
            // 
            gridUserLogInfo_GeneralInfo.AllowUserToAddRows = false;
            gridUserLogInfo_GeneralInfo.AllowUserToDeleteRows = false;
            gridUserLogInfo_GeneralInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            gridUserLogInfo_GeneralInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            gridUserLogInfo_GeneralInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gridUserLogInfo_GeneralInfo.BackgroundColor = System.Drawing.SystemColors.Window;
            gridUserLogInfo_GeneralInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            gridUserLogInfo_GeneralInfo.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            gridUserLogInfo_GeneralInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            gridUserLogInfo_GeneralInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            gridUserLogInfo_GeneralInfo.ColumnHeadersHeight = 30;
            gridUserLogInfo_GeneralInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { User_Happen_Time, The_Operator, Operation_Content });
            gridUserLogInfo_GeneralInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            gridUserLogInfo_GeneralInfo.GridColor = System.Drawing.Color.Blue;
            gridUserLogInfo_GeneralInfo.Location = new System.Drawing.Point(3, 44);
            gridUserLogInfo_GeneralInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gridUserLogInfo_GeneralInfo.MultiSelect = false;
            gridUserLogInfo_GeneralInfo.Name = "this.gridUserLogInfo_GeneralInfo";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            gridUserLogInfo_GeneralInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            gridUserLogInfo_GeneralInfo.RowHeadersVisible = false;
            gridUserLogInfo_GeneralInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            gridUserLogInfo_GeneralInfo.RowsDefaultCellStyle = dataGridViewCellStyle8;
            gridUserLogInfo_GeneralInfo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            gridUserLogInfo_GeneralInfo.RowTemplate.Height = 35;
            gridUserLogInfo_GeneralInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridUserLogInfo_GeneralInfo.Size = new System.Drawing.Size(947, 340);
            gridUserLogInfo_GeneralInfo.TabIndex = 15;

            // 
            // User_Happen_Time
            // 
            User_Happen_Time.DataPropertyName = "Happen_Time";
            dataGridViewCellStyle4.Format = "G";
            dataGridViewCellStyle4.NullValue = null;
            User_Happen_Time.DefaultCellStyle = dataGridViewCellStyle4;
            User_Happen_Time.HeaderText = "发生时间";
            User_Happen_Time.Name = "User_Happen_Time";
            User_Happen_Time.ReadOnly = true;
            // 
            // The_Operator
            // 
            The_Operator.DataPropertyName = "The_Operator";
            The_Operator.HeaderText = "操作者";
            The_Operator.Name = "The_Operator";
            The_Operator.ReadOnly = true;
            // 
            // Operation_Content
            // 
            Operation_Content.DataPropertyName = "Operation_Content";
            Operation_Content.HeaderText = "操作内容";
            Operation_Content.Name = "Operation_Content";
            Operation_Content.ReadOnly = true;
        }
        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPagesys;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView Sysgrid;
        private assistcontrol.DataGridPage Syspage;
        private System.Windows.Forms.Button btnSysOut;
        private System.Windows.Forms.TabPage TabPageuser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnUserOut;
        private assistcontrol.DataGridPage userpage;

        private System.Windows.Forms.DataGridView gridUserLogInfo_WellInfo;
        private System.Windows.Forms.DataGridView gridUserLogInfo_GeneralInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sys_Happen_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
        private System.Windows.Forms.DataGridViewTextBoxColumn Well_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn Humidity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Smoke_Detector;
        private System.Windows.Forms.DataGridViewTextBoxColumn Smoke_Power;
        private System.Windows.Forms.DataGridViewTextBoxColumn Signal_Strength;
    }
}
