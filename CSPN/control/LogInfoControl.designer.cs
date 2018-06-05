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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInfoControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPagesys = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSysRefresh = new System.Windows.Forms.Button();
            this.Syspage = new CSPN.assistcontrol.DataGridPage();
            this.panelSys = new System.Windows.Forms.Panel();
            this.TabPageuser = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUserRefresh = new System.Windows.Forms.Button();
            this.userpage = new CSPN.assistcontrol.DataGridPage();
            this.panelUser = new System.Windows.Forms.Panel();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.TabPagesys.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.TabPagesys.Size = new System.Drawing.Size(959, 434);
            this.TabPagesys.TabIndex = 0;
            this.TabPagesys.Text = "系统日志信息";
            this.TabPagesys.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnSysRefresh, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Syspage, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelSys, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 434);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnSysRefresh
            // 
            this.btnSysRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSysRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSysRefresh.BackgroundImage")));
            this.btnSysRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSysRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSysRefresh.FlatAppearance.BorderSize = 0;
            this.btnSysRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSysRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSysRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSysRefresh.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSysRefresh.ForeColor = System.Drawing.Color.White;
            this.btnSysRefresh.Location = new System.Drawing.Point(874, 7);
            this.btnSysRefresh.Name = "btnSysRefresh";
            this.btnSysRefresh.Size = new System.Drawing.Size(69, 26);
            this.btnSysRefresh.TabIndex = 15;
            this.btnSysRefresh.Text = "刷新";
            this.btnSysRefresh.UseVisualStyleBackColor = true;
            this.btnSysRefresh.Click += new System.EventHandler(this.btnSysRefresh_Click);
            // 
            // Syspage
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Syspage, 2);
            this.Syspage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Syspage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Syspage.Location = new System.Drawing.Point(3, 397);
            this.Syspage.Name = "Syspage";
            this.Syspage.PageSize = 50;
            this.Syspage.Size = new System.Drawing.Size(953, 34);
            this.Syspage.TabIndex = 0;
            // 
            // panelSys
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelSys, 2);
            this.panelSys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSys.Location = new System.Drawing.Point(3, 43);
            this.panelSys.Name = "panelSys";
            this.panelSys.Size = new System.Drawing.Size(953, 348);
            this.panelSys.TabIndex = 15;
            // 
            // TabPageuser
            // 
            this.TabPageuser.Controls.Add(this.tableLayoutPanel2);
            this.TabPageuser.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabPageuser.Location = new System.Drawing.Point(4, 29);
            this.TabPageuser.Name = "TabPageuser";
            this.TabPageuser.Size = new System.Drawing.Size(959, 434);
            this.TabPageuser.TabIndex = 1;
            this.TabPageuser.Text = "用户日志信息";
            this.TabPageuser.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel2.Controls.Add(this.btnUserRefresh, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.userpage, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelUser, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbType, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(959, 434);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnUserRefresh
            // 
            this.btnUserRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUserRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUserRefresh.BackgroundImage")));
            this.btnUserRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUserRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserRefresh.FlatAppearance.BorderSize = 0;
            this.btnUserRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUserRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUserRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserRefresh.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserRefresh.ForeColor = System.Drawing.Color.White;
            this.btnUserRefresh.Location = new System.Drawing.Point(874, 7);
            this.btnUserRefresh.Name = "btnUserRefresh";
            this.btnUserRefresh.Size = new System.Drawing.Size(69, 26);
            this.btnUserRefresh.TabIndex = 16;
            this.btnUserRefresh.Text = "刷新";
            this.btnUserRefresh.UseVisualStyleBackColor = true;
            this.btnUserRefresh.Click += new System.EventHandler(this.btnUserRefresh_Click);
            // 
            // userpage
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.userpage, 4);
            this.userpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userpage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userpage.Location = new System.Drawing.Point(3, 397);
            this.userpage.Name = "userpage";
            this.userpage.PageSize = 50;
            this.userpage.Size = new System.Drawing.Size(953, 34);
            this.userpage.TabIndex = 0;
            // 
            // panelUser
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panelUser, 4);
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUser.Location = new System.Drawing.Point(3, 43);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(953, 348);
            this.panelUser.TabIndex = 15;
            // 
            // cbType
            // 
            this.cbType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "人井处理日志",
            "用户日志"});
            this.cbType.Location = new System.Drawing.Point(103, 10);
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
            this.Name = "LogInfoControl";
            this.Size = new System.Drawing.Size(967, 467);
            this.Load += new System.EventHandler(this.LogInfoControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabPagesys.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TabPageuser.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitializeSysLogInfo()
        {
            Sysgrid = new System.Windows.Forms.DataGridView();
            System.Windows.Forms.DataGridViewTextBoxColumn Sys_Happen_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Terminal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Terminal_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Well_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Electricity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Humidity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Smoke_Detector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Smoke_Power = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Signal_Strength = new System.Windows.Forms.DataGridViewTextBoxColumn();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            Sysgrid.AllowUserToAddRows = false;
            Sysgrid.AllowUserToDeleteRows = false;
            Sysgrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            Sysgrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            Sysgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            Sysgrid.BackgroundColor = System.Drawing.SystemColors.Window;
            Sysgrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            Sysgrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            Sysgrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            Sysgrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            Sysgrid.ColumnHeadersHeight = 30;
            Sysgrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Sys_Happen_Time, Terminal_ID, Terminal_Name, Place, Well_State, Electricity, Temperature, Humidity, Smoke_Detector, Smoke_Power, Signal_Strength });
            Sysgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            Sysgrid.GridColor = System.Drawing.Color.Blue;
            Sysgrid.Location = new System.Drawing.Point(3, 44);
            Sysgrid.MultiSelect = false;
            Sysgrid.Name = "Sysgrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            Sysgrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            Sysgrid.RowHeadersVisible = false;
            Sysgrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            Sysgrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            Sysgrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            Sysgrid.RowTemplate.Height = 35;
            Sysgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            Sysgrid.Size = new System.Drawing.Size(947, 340);
            Sysgrid.TabIndex = 15;
            Sysgrid.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.Sysgrid_CellToolTipTextNeeded);
            // 
            // Sys_Happen_Time
            // 
            Sys_Happen_Time.DataPropertyName = "Happen_Time";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            Sys_Happen_Time.DefaultCellStyle = dataGridViewCellStyle3;
            Sys_Happen_Time.HeaderText = "发生时间";
            Sys_Happen_Time.Name = "Sys_Happen_Time";
            Sys_Happen_Time.ReadOnly = true;
            // 
            // Terminal_ID
            // 
            Terminal_ID.DataPropertyName = "Terminal_ID";
            Terminal_ID.HeaderText = "人井编号";
            Terminal_ID.Name = "Terminal_ID";
            Terminal_ID.ReadOnly = true;
            // 
            // Terminal_Name
            // 
            Terminal_Name.DataPropertyName = "Name";
            Terminal_Name.HeaderText = "人井名称";
            Terminal_Name.Name = "Terminal_Name";
            Terminal_Name.ReadOnly = true;
            // 
            // Place
            // 
            Place.DataPropertyName = "Place";
            Place.HeaderText = "地点";
            Place.Name = "Place";
            Place.ReadOnly = true;
            // 
            // Well_State
            // 
            Well_State.DataPropertyName = "State";
            Well_State.HeaderText = "人井状态";
            Well_State.Name = "Well_State";
            Well_State.ReadOnly = true;
            // 
            // Electricity
            // 
            Electricity.DataPropertyName = "Electricity";
            Electricity.HeaderText = "终端电量";
            Electricity.Name = "Electricity";
            // 
            // Temperature
            // 
            Temperature.DataPropertyName = "Temperature";
            Temperature.HeaderText = "温度";
            Temperature.Name = "Temperature";
            Temperature.ReadOnly = true;
            // 
            // Humidity
            // 
            Humidity.DataPropertyName = "Humidity";
            Humidity.HeaderText = "湿度";
            Humidity.Name = "Humidity";
            Humidity.ReadOnly = true;
            // 
            // Smoke_Detector
            // 
            Smoke_Detector.DataPropertyName = "Smoke_Detector";
            Smoke_Detector.HeaderText = "烟感";
            Smoke_Detector.Name = "Smoke_Detector";
            Smoke_Detector.ReadOnly = true;
            // 
            // Smoke_Power
            // 
            Smoke_Power.DataPropertyName = "Smoke_Power";
            Smoke_Power.HeaderText = "烟感电量";
            Smoke_Power.Name = "Smoke_Power";
            Smoke_Power.ReadOnly = true;
            // 
            // Signal_Strength
            // 
            Signal_Strength.DataPropertyName = "Signal_Strength";
            Signal_Strength.HeaderText = "信号强度";
            Signal_Strength.Name = "Signal_Strength";
            Signal_Strength.ReadOnly = true;
            Signal_Strength.ToolTipText = "取值从00到31。若为99，表示无信号。";
        }

        private void InitializeUserLogInfo_WellInfo()
        {
            gridUserLogInfo_WellInfo = new System.Windows.Forms.DataGridView();
            System.Windows.Forms.DataGridViewTextBoxColumn User_Happen_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn User_Terminal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn User_Terminal_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn User_Terminal_Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            gridUserLogInfo_WellInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { User_Happen_Time, User_Terminal_ID, User_Terminal_Name, User_Terminal_Place, The_Operator, Operation_Content, Receive_People, Notice_time, Processor, Process_Content, Process_Time, Current_State });
            gridUserLogInfo_WellInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            gridUserLogInfo_WellInfo.GridColor = System.Drawing.Color.Blue;
            gridUserLogInfo_WellInfo.Location = new System.Drawing.Point(3, 44);
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
            // User_Terminal_ID
            //
            User_Terminal_ID.DataPropertyName = "Terminal_ID";
            User_Terminal_ID.HeaderText = "人井编号";
            User_Terminal_ID.Name = "Terminal_ID";
            User_Terminal_ID.ReadOnly = true;
            // 
            // User_Terminal_Name
            //
            User_Terminal_Name.DataPropertyName = "Name";
            User_Terminal_Name.HeaderText = "人井名称";
            User_Terminal_Name.Name = "Name";
            User_Terminal_Name.ReadOnly = true;
            // 
            // User_Terminal_Place
            //
            User_Terminal_Place.DataPropertyName = "Place";
            User_Terminal_Place.HeaderText = "地点";
            User_Terminal_Place.Name = "Place";
            User_Terminal_Place.ReadOnly = true;
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
        private assistcontrol.DataGridPage Syspage;
        private System.Windows.Forms.TabPage TabPageuser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private assistcontrol.DataGridPage userpage;

        private System.Windows.Forms.DataGridView Sysgrid;
        private System.Windows.Forms.DataGridView gridUserLogInfo_WellInfo;
        private System.Windows.Forms.DataGridView gridUserLogInfo_GeneralInfo;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSys;
        private System.Windows.Forms.Button btnSysRefresh;
        private System.Windows.Forms.Button btnUserRefresh;
    }
}
