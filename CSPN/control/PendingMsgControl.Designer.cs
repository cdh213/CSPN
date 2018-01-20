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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AlarmTab = new System.Windows.Forms.TabPage();
            this.dgvAlarm = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewButtonColumn3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProcessedTab = new System.Windows.Forms.TabPage();
            this.dgvDispose = new System.Windows.Forms.DataGridView();
            this.disReport_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NotReportTab = new System.Windows.Forms.TabPage();
            this.dgvNotReport = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Report_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Well_State_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.AlarmTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).BeginInit();
            this.ProcessedTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispose)).BeginInit();
            this.NotReportTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AlarmTab);
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
            // 
            // AlarmTab
            // 
            this.AlarmTab.Controls.Add(this.dgvAlarm);
            this.AlarmTab.Location = new System.Drawing.Point(4, 29);
            this.AlarmTab.Name = "AlarmTab";
            this.AlarmTab.Size = new System.Drawing.Size(960, 408);
            this.AlarmTab.TabIndex = 0;
            this.AlarmTab.Text = "通知处理";
            this.AlarmTab.UseVisualStyleBackColor = true;
            // 
            // dgvAlarm
            // 
            this.dgvAlarm.AllowUserToAddRows = false;
            this.dgvAlarm.AllowUserToDeleteRows = false;
            this.dgvAlarm.AllowUserToResizeRows = false;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvAlarm.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvAlarm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlarm.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlarm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvAlarm.ColumnHeadersHeight = 30;
            this.dgvAlarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.Icon,
            this.dataGridViewButtonColumn3});
            this.dgvAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlarm.GridColor = System.Drawing.Color.Blue;
            this.dgvAlarm.Location = new System.Drawing.Point(0, 0);
            this.dgvAlarm.MultiSelect = false;
            this.dgvAlarm.Name = "dgvAlarm";
            this.dgvAlarm.RowHeadersVisible = false;
            this.dgvAlarm.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvAlarm.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvAlarm.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvAlarm.RowTemplate.Height = 30;
            this.dgvAlarm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlarm.Size = new System.Drawing.Size(960, 408);
            this.dgvAlarm.TabIndex = 5;
            this.dgvAlarm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlarm_CellContentClick);
            this.dgvAlarm.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAlarm_CellFormatting);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Report_Time";
            dataGridViewCellStyle27.Format = "G";
            dataGridViewCellStyle27.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridViewTextBoxColumn7.HeaderText = "发生时间";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Terminal_ID";
            this.dataGridViewTextBoxColumn10.HeaderText = "人井编号";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Well_State_ID";
            this.dataGridViewTextBoxColumn12.HeaderText = "Well_State_ID";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn13.HeaderText = "人井名称";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Place";
            this.dataGridViewTextBoxColumn14.HeaderText = "地点";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // Icon
            // 
            this.Icon.DataPropertyName = "Icon";
            this.Icon.HeaderText = "状态";
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            // 
            // dataGridViewButtonColumn3
            // 
            this.dataGridViewButtonColumn3.HeaderText = "操作";
            this.dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            this.dataGridViewButtonColumn3.ReadOnly = true;
            this.dataGridViewButtonColumn3.Text = "处理";
            this.dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
            // 
            // ProcessedTab
            // 
            this.ProcessedTab.Controls.Add(this.dgvDispose);
            this.ProcessedTab.Location = new System.Drawing.Point(4, 29);
            this.ProcessedTab.Name = "ProcessedTab";
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
            dataGridViewCellStyle29.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDispose.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            this.dgvDispose.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDispose.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDispose.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.dgvDispose.ColumnHeadersHeight = 30;
            this.dgvDispose.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.disReport_Time,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dgvIcon,
            this.dataGridViewButtonColumn1});
            this.dgvDispose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDispose.GridColor = System.Drawing.Color.Blue;
            this.dgvDispose.Location = new System.Drawing.Point(0, 0);
            this.dgvDispose.MultiSelect = false;
            this.dgvDispose.Name = "dgvDispose";
            this.dgvDispose.RowHeadersVisible = false;
            this.dgvDispose.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDispose.RowsDefaultCellStyle = dataGridViewCellStyle32;
            this.dgvDispose.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDispose.RowTemplate.Height = 30;
            this.dgvDispose.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDispose.Size = new System.Drawing.Size(960, 408);
            this.dgvDispose.TabIndex = 4;
            this.dgvDispose.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDispose_CellContentClick);
            this.dgvDispose.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDispose_CellFormatting);
            // 
            // disReport_Time
            // 
            this.disReport_Time.DataPropertyName = "Report_Time";
            dataGridViewCellStyle31.Format = "G";
            dataGridViewCellStyle31.NullValue = null;
            this.disReport_Time.DefaultCellStyle = dataGridViewCellStyle31;
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
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "操作";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Text = "处理完成";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
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
            dataGridViewCellStyle33.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvNotReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.dgvNotReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotReport.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
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
            dataGridViewCellStyle35.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvNotReport.RowsDefaultCellStyle = dataGridViewCellStyle35;
            this.dgvNotReport.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvNotReport.RowTemplate.Height = 30;
            this.dgvNotReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotReport.Size = new System.Drawing.Size(960, 408);
            this.dgvNotReport.TabIndex = 6;
            this.dgvNotReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotReport_CellContentClick);
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
            // Report_Time
            // 
            this.Report_Time.DataPropertyName = "Report_Time";
            dataGridViewCellStyle36.Format = "G";
            dataGridViewCellStyle36.NullValue = null;
            this.Report_Time.DefaultCellStyle = dataGridViewCellStyle36;
            this.Report_Time.HeaderText = "发生时间";
            this.Report_Time.Name = "Report_Time";
            this.Report_Time.ReadOnly = true;
            this.Report_Time.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Report_Time.Width = 159;
            // 
            // Terminal_ID
            // 
            this.Terminal_ID.DataPropertyName = "Terminal_ID";
            this.Terminal_ID.HeaderText = "人井编号";
            this.Terminal_ID.Name = "Terminal_ID";
            this.Terminal_ID.ReadOnly = true;
            this.Terminal_ID.Width = 158;
            // 
            // Well_State_ID
            // 
            this.Well_State_ID.DataPropertyName = "Well_State_ID";
            this.Well_State_ID.HeaderText = "Well_State_ID";
            this.Well_State_ID.Name = "Well_State_ID";
            this.Well_State_ID.ReadOnly = true;
            this.Well_State_ID.Visible = false;
            // 
            // PendingMsgControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "PendingMsgControl";
            this.Size = new System.Drawing.Size(968, 441);
            this.tabControl1.ResumeLayout(false);
            this.AlarmTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarm)).EndInit();
            this.ProcessedTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispose)).EndInit();
            this.NotReportTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AlarmTab;
        private System.Windows.Forms.TabPage ProcessedTab;
        private System.Windows.Forms.DataGridView dgvDispose;
        private System.Windows.Forms.TabPage NotReportTab;
        private System.Windows.Forms.DataGridView dgvNotReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Report_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Well_State_ID;
        private System.Windows.Forms.DataGridView dgvAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn disReport_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dgvIcon;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn3;
    }
}
