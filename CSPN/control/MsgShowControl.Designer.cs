namespace CSPN.control
{
    partial class MsgShowControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MsgShowControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPagemap = new System.Windows.Forms.TabPage();
            this.TabPagelist = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInto = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.page = new CSPN.assistcontrol.DataGridPage();
            this.txtCondition = new CSPN.assistcontrol.WaterTextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TerminalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal_Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Electricity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Humidity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Smoke_Detector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Smoke_Power = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signal_Strength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ReportInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Work_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.TabPagelist.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPagemap);
            this.tabControl1.Controls.Add(this.TabPagelist);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1070, 315);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // TabPagemap
            // 
            this.TabPagemap.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabPagemap.Location = new System.Drawing.Point(4, 29);
            this.TabPagemap.Name = "TabPagemap";
            this.TabPagemap.Size = new System.Drawing.Size(1062, 282);
            this.TabPagemap.TabIndex = 0;
            this.TabPagemap.Text = "地图显示";
            this.TabPagemap.UseVisualStyleBackColor = true;
            // 
            // TabPagelist
            // 
            this.TabPagelist.Controls.Add(this.tableLayoutPanel1);
            this.TabPagelist.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabPagelist.Location = new System.Drawing.Point(4, 29);
            this.TabPagelist.Name = "TabPagelist";
            this.TabPagelist.Size = new System.Drawing.Size(1062, 282);
            this.TabPagelist.TabIndex = 1;
            this.TabPagelist.Text = "列表显示";
            this.TabPagelist.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnQuery, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDelete, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInto, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRefresh, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.page, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCondition, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1062, 282);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.ColumnHeadersHeight = 30;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.TerminalID,
            this.Terminal_Name,
            this.Longitude,
            this.Latitude,
            this.Place,
            this.Terminal_Phone,
            this.Electricity,
            this.Temperature,
            this.Humidity,
            this.Smoke_Detector,
            this.Smoke_Power,
            this.Signal_Strength,
            this.Icon,
            this.ReportInterval,
            this.Work_ID,
            this.RealName,
            this.Telephone});
            this.tableLayoutPanel1.SetColumnSpan(this.grid, 10);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.GridColor = System.Drawing.Color.Blue;
            this.grid.Location = new System.Drawing.Point(3, 43);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid.RowTemplate.Height = 35;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(1056, 196);
            this.grid.TabIndex = 15;
            this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid_CellFormatting);
            this.grid.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.grid_CellToolTipTextNeeded);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnQuery.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuery.BackgroundImage")));
            this.btnQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuery.FlatAppearance.BorderSize = 0;
            this.btnQuery.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnQuery.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.Location = new System.Drawing.Point(221, 7);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(69, 26);
            this.btnQuery.TabIndex = 4;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(508, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 26);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(608, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(69, 26);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "编辑";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(708, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 26);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInto
            // 
            this.btnInto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInto.BackgroundImage")));
            this.btnInto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInto.FlatAppearance.BorderSize = 0;
            this.btnInto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnInto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnInto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInto.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInto.ForeColor = System.Drawing.Color.White;
            this.btnInto.Location = new System.Drawing.Point(808, 7);
            this.btnInto.Name = "btnInto";
            this.btnInto.Size = new System.Drawing.Size(120, 26);
            this.btnInto.TabIndex = 8;
            this.btnInto.Text = "信息导入(Excel)";
            this.btnInto.UseVisualStyleBackColor = true;
            this.btnInto.Click += new System.EventHandler(this.btnInto_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(958, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(69, 26);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // page
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.page, 10);
            this.page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.page.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.page.Location = new System.Drawing.Point(3, 245);
            this.page.Name = "page";
            this.page.PageSize = 50;
            this.page.Size = new System.Drawing.Size(1056, 34);
            this.page.TabIndex = 16;
            // 
            // txtCondition
            // 
            this.txtCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCondition.Location = new System.Drawing.Point(21, 7);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(194, 26);
            this.txtCondition.TabIndex = 17;
            this.txtCondition.WaterText = "请输入关键字查询";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // ck
            // 
            this.ck.HeaderText = "选择";
            this.ck.Name = "ck";
            this.ck.Visible = false;
            this.ck.Width = 65;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Well_Info_ID";
            this.Column1.HeaderText = "Well_Info_ID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "选择";
            this.Column2.Name = "Column2";
            this.Column2.Width = 43;
            // 
            // TerminalID
            // 
            this.TerminalID.DataPropertyName = "Terminal_ID";
            this.TerminalID.HeaderText = "人井编号";
            this.TerminalID.Name = "TerminalID";
            this.TerminalID.ReadOnly = true;
            this.TerminalID.Width = 90;
            // 
            // Terminal_Name
            // 
            this.Terminal_Name.DataPropertyName = "Name";
            this.Terminal_Name.HeaderText = "人井名称";
            this.Terminal_Name.Name = "Terminal_Name";
            this.Terminal_Name.ReadOnly = true;
            this.Terminal_Name.Width = 90;
            // 
            // Longitude
            // 
            this.Longitude.DataPropertyName = "Longitude";
            this.Longitude.HeaderText = "经度";
            this.Longitude.Name = "Longitude";
            this.Longitude.ReadOnly = true;
            this.Longitude.Width = 62;
            // 
            // Latitude
            // 
            this.Latitude.DataPropertyName = "Latitude";
            this.Latitude.HeaderText = "纬度";
            this.Latitude.Name = "Latitude";
            this.Latitude.ReadOnly = true;
            this.Latitude.Width = 62;
            // 
            // Place
            // 
            this.Place.DataPropertyName = "Place";
            this.Place.HeaderText = "地点";
            this.Place.Name = "Place";
            this.Place.ReadOnly = true;
            this.Place.Width = 62;
            // 
            // Terminal_Phone
            // 
            this.Terminal_Phone.DataPropertyName = "Terminal_Phone";
            this.Terminal_Phone.HeaderText = "终端手机号";
            this.Terminal_Phone.Name = "Terminal_Phone";
            this.Terminal_Phone.ReadOnly = true;
            this.Terminal_Phone.Width = 104;
            // 
            // Electricity
            // 
            this.Electricity.DataPropertyName = "Electricity";
            this.Electricity.HeaderText = "终端电量";
            this.Electricity.Name = "Electricity";
            this.Electricity.ReadOnly = true;
            this.Electricity.Width = 90;
            // 
            // Temperature
            // 
            this.Temperature.DataPropertyName = "Temperature";
            this.Temperature.HeaderText = "温度";
            this.Temperature.Name = "Temperature";
            this.Temperature.ReadOnly = true;
            this.Temperature.Width = 62;
            // 
            // Humidity
            // 
            this.Humidity.DataPropertyName = "Humidity";
            this.Humidity.HeaderText = "湿度";
            this.Humidity.Name = "Humidity";
            this.Humidity.ReadOnly = true;
            this.Humidity.Width = 62;
            // 
            // Smoke_Detector
            // 
            this.Smoke_Detector.DataPropertyName = "Smoke_Detector";
            this.Smoke_Detector.HeaderText = "烟感";
            this.Smoke_Detector.Name = "Smoke_Detector";
            this.Smoke_Detector.ReadOnly = true;
            this.Smoke_Detector.Width = 62;
            // 
            // Smoke_Power
            // 
            this.Smoke_Power.DataPropertyName = "Smoke_Power";
            this.Smoke_Power.HeaderText = "烟感电量";
            this.Smoke_Power.Name = "Smoke_Power";
            this.Smoke_Power.ReadOnly = true;
            this.Smoke_Power.Width = 90;
            // 
            // Signal_Strength
            // 
            this.Signal_Strength.DataPropertyName = "Signal_Strength";
            this.Signal_Strength.HeaderText = "信号强度";
            this.Signal_Strength.Name = "Signal_Strength";
            this.Signal_Strength.ReadOnly = true;
            this.Signal_Strength.ToolTipText = "取值从00到31。若为99，表示无信号。";
            this.Signal_Strength.Width = 90;
            // 
            // Icon
            // 
            this.Icon.DataPropertyName = "Icon";
            this.Icon.HeaderText = "状态";
            this.Icon.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            this.Icon.Width = 43;
            // 
            // ReportInterval
            // 
            this.ReportInterval.DataPropertyName = "ReportInterval";
            this.ReportInterval.HeaderText = "上报时间间隔";
            this.ReportInterval.Name = "ReportInterval";
            this.ReportInterval.ReadOnly = true;
            this.ReportInterval.Width = 118;
            // 
            // Work_ID
            // 
            this.Work_ID.DataPropertyName = "Work_ID";
            this.Work_ID.HeaderText = "值班人员工号";
            this.Work_ID.Name = "Work_ID";
            this.Work_ID.ReadOnly = true;
            this.Work_ID.Width = 118;
            // 
            // RealName
            // 
            this.RealName.DataPropertyName = "RealName";
            this.RealName.HeaderText = "值班人员姓名";
            this.RealName.Name = "RealName";
            this.RealName.ReadOnly = true;
            this.RealName.Width = 118;
            // 
            // Telephone
            // 
            this.Telephone.DataPropertyName = "Telephone";
            this.Telephone.HeaderText = "值班人员手机号";
            this.Telephone.Name = "Telephone";
            this.Telephone.ReadOnly = true;
            this.Telephone.Width = 132;
            // 
            // MsgShowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MsgShowControl";
            this.Size = new System.Drawing.Size(1070, 315);
            this.Load += new System.EventHandler(this.MsgShowControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.TabPagelist.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPagemap;
        private System.Windows.Forms.TabPage TabPagelist;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInto;
        private System.Windows.Forms.Button btnRefresh;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private assistcontrol.DataGridPage page;
        private assistcontrol.WaterTextBox txtCondition;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TerminalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Electricity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn Humidity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Smoke_Detector;
        private System.Windows.Forms.DataGridViewTextBoxColumn Smoke_Power;
        private System.Windows.Forms.DataGridViewTextBoxColumn Signal_Strength;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReportInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn Work_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
    }
}
