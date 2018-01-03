namespace CSPN.control
{
    partial class PendingMsgControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.gridAlarm = new System.Windows.Forms.DataGridView();
            this.ProcessedTab = new System.Windows.Forms.TabPage();
            this.dgvDispose = new System.Windows.Forms.DataGridView();
            this.NotReportTab = new System.Windows.Forms.TabPage();
            this.dgvNotReport = new System.Windows.Forms.DataGridView();
            this.Report_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Well_State_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAlarmDeal = new System.Windows.Forms.DataGridViewButtonColumn();
            this.disReport_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlarm)).BeginInit();
            this.ProcessedTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispose)).BeginInit();
            this.NotReportTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.ProcessedTab);
            this.tabControl1.Controls.Add(this.NotReportTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(968, 441);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.Enter += new System.EventHandler(this.tabControl1_Enter);
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.gridAlarm);
            this.tab1.Location = new System.Drawing.Point(4, 29);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(960, 408);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "通知处理";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // gridAlarm
            // 
            this.gridAlarm.AllowUserToAddRows = false;
            this.gridAlarm.AllowUserToDeleteRows = false;
            this.gridAlarm.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridAlarm.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAlarm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAlarm.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAlarm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridAlarm.ColumnHeadersHeight = 30;
            this.gridAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Report_Time,
            this.Terminal_ID,
            this.Well_State_ID,
            this.Terminal_Name,
            this.Place,
            this.Icon,
            this.Telephone,
            this.btnAlarmDeal});
            this.gridAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAlarm.GridColor = System.Drawing.Color.Blue;
            this.gridAlarm.Location = new System.Drawing.Point(3, 3);
            this.gridAlarm.MultiSelect = false;
            this.gridAlarm.Name = "gridAlarm";
            this.gridAlarm.RowHeadersVisible = false;
            this.gridAlarm.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridAlarm.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridAlarm.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridAlarm.RowTemplate.Height = 30;
            this.gridAlarm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAlarm.Size = new System.Drawing.Size(954, 402);
            this.gridAlarm.TabIndex = 3;
            this.gridAlarm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAlarm_CellContentClick);
            this.gridAlarm.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridAlarm_CellFormatting);
            // 
            // ProcessedTab
            // 
            this.ProcessedTab.Controls.Add(this.dgvDispose);
            this.ProcessedTab.Location = new System.Drawing.Point(4, 29);
            this.ProcessedTab.Name = "ProcessedTab";
            this.ProcessedTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProcessedTab.Size = new System.Drawing.Size(960, 408);
            this.ProcessedTab.TabIndex = 1;
            this.ProcessedTab.Text = "已通知处理";
            this.ProcessedTab.UseVisualStyleBackColor = true;
            // 
            // dgvDispose
            // 
            this.dgvDispose.AllowUserToAddRows = false;
            this.dgvDispose.AllowUserToDeleteRows = false;
            this.dgvDispose.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDispose.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDispose.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDispose.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDispose.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDispose.ColumnHeadersHeight = 30;
            this.dgvDispose.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.disReport_Time,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dgvIcon,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewButtonColumn1});
            this.dgvDispose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDispose.GridColor = System.Drawing.Color.Blue;
            this.dgvDispose.Location = new System.Drawing.Point(3, 3);
            this.dgvDispose.MultiSelect = false;
            this.dgvDispose.Name = "dgvDispose";
            this.dgvDispose.RowHeadersVisible = false;
            this.dgvDispose.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDispose.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDispose.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDispose.RowTemplate.Height = 30;
            this.dgvDispose.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDispose.Size = new System.Drawing.Size(954, 402);
            this.dgvDispose.TabIndex = 4;
            this.dgvDispose.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDispose_CellContentClick);
            this.dgvDispose.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDispose_CellFormatting);
            // 
            // NotReportTab
            // 
            this.NotReportTab.Controls.Add(this.dgvNotReport);
            this.NotReportTab.Location = new System.Drawing.Point(4, 29);
            this.NotReportTab.Name = "NotReportTab";
            this.NotReportTab.Size = new System.Drawing.Size(960, 408);
            this.NotReportTab.TabIndex = 2;
            this.NotReportTab.Text = "未上报";
            this.NotReportTab.UseVisualStyleBackColor = true;
            // 
            // dgvNotReport
            // 
            this.dgvNotReport.AllowUserToAddRows = false;
            this.dgvNotReport.AllowUserToDeleteRows = false;
            this.dgvNotReport.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvNotReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvNotReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotReport.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvNotReport.ColumnHeadersHeight = 30;
            this.dgvNotReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.Longitude,
            this.Latitude,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewButtonColumn2});
            this.dgvNotReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotReport.GridColor = System.Drawing.Color.Blue;
            this.dgvNotReport.Location = new System.Drawing.Point(0, 0);
            this.dgvNotReport.MultiSelect = false;
            this.dgvNotReport.Name = "dgvNotReport";
            this.dgvNotReport.RowHeadersVisible = false;
            this.dgvNotReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvNotReport.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvNotReport.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvNotReport.RowTemplate.Height = 30;
            this.dgvNotReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotReport.Size = new System.Drawing.Size(960, 408);
            this.dgvNotReport.TabIndex = 6;
            this.dgvNotReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotReport_CellContentClick);
            // 
            // Report_Time
            // 
            this.Report_Time.DataPropertyName = "Report_Time";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.Report_Time.DefaultCellStyle = dataGridViewCellStyle3;
            this.Report_Time.HeaderText = "发生时间";
            this.Report_Time.Name = "Report_Time";
            this.Report_Time.ReadOnly = true;
            this.Report_Time.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Terminal_ID
            // 
            this.Terminal_ID.DataPropertyName = "Terminal_ID";
            this.Terminal_ID.HeaderText = "人井编号";
            this.Terminal_ID.Name = "Terminal_ID";
            this.Terminal_ID.ReadOnly = true;
            // 
            // Well_State_ID
            // 
            this.Well_State_ID.DataPropertyName = "Well_State_ID";
            this.Well_State_ID.HeaderText = "Well_State_ID";
            this.Well_State_ID.Name = "Well_State_ID";
            this.Well_State_ID.ReadOnly = true;
            this.Well_State_ID.Visible = false;
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
            // Icon
            // 
            this.Icon.DataPropertyName = "Icon";
            this.Icon.HeaderText = "状态";
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            // 
            // Telephone
            // 
            this.Telephone.DataPropertyName = "Telephone";
            this.Telephone.HeaderText = "值班人员电话";
            this.Telephone.Name = "Telephone";
            this.Telephone.ReadOnly = true;
            this.Telephone.Visible = false;
            // 
            // btnAlarmDeal
            // 
            this.btnAlarmDeal.HeaderText = "操作";
            this.btnAlarmDeal.Name = "btnAlarmDeal";
            this.btnAlarmDeal.ReadOnly = true;
            this.btnAlarmDeal.Text = "处理";
            this.btnAlarmDeal.UseColumnTextForButtonValue = true;
            // 
            // disReport_Time
            // 
            this.disReport_Time.DataPropertyName = "Report_Time";
            dataGridViewCellStyle7.Format = "G";
            dataGridViewCellStyle7.NullValue = null;
            this.disReport_Time.DefaultCellStyle = dataGridViewCellStyle7;
            this.disReport_Time.HeaderText = "发生时间";
            this.disReport_Time.Name = "disReport_Time";
            this.disReport_Time.ReadOnly = true;
            this.disReport_Time.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Terminal_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "人井编号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Well_State_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Well_State_ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "人井名称";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Place";
            this.dataGridViewTextBoxColumn4.HeaderText = "地点";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dgvIcon
            // 
            this.dgvIcon.DataPropertyName = "Icon";
            this.dgvIcon.HeaderText = "状态";
            this.dgvIcon.Name = "dgvIcon";
            this.dgvIcon.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Telephone";
            this.dataGridViewTextBoxColumn6.HeaderText = "值班人员电话";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "操作";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "处理完成";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Terminal_ID";
            this.dataGridViewTextBoxColumn5.HeaderText = "人井编号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn8.HeaderText = "人井名称";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // Longitude
            // 
            this.Longitude.DataPropertyName = "Longitude";
            this.Longitude.HeaderText = "经度";
            this.Longitude.Name = "Longitude";
            // 
            // Latitude
            // 
            this.Latitude.DataPropertyName = "Latitude";
            this.Latitude.HeaderText = "纬度";
            this.Latitude.Name = "Latitude";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Place";
            this.dataGridViewTextBoxColumn9.HeaderText = "地点";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Telephone";
            this.dataGridViewTextBoxColumn11.HeaderText = "值班人员电话";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "操作";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Text = "处理";
            this.dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            // 
            // PendingMsgControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PendingMsgControl";
            this.Size = new System.Drawing.Size(968, 441);
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlarm)).EndInit();
            this.ProcessedTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispose)).EndInit();
            this.NotReportTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabPage ProcessedTab;
        private System.Windows.Forms.DataGridView gridAlarm;
        private System.Windows.Forms.DataGridView dgvDispose;
        private System.Windows.Forms.TabPage NotReportTab;
        private System.Windows.Forms.DataGridView dgvNotReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Report_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Well_State_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewButtonColumn btnAlarmDeal;
        private System.Windows.Forms.DataGridViewTextBoxColumn disReport_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dgvIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
    }
}
