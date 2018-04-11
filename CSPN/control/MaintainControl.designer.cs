namespace CSPN.control
{
    partial class MaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintainControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTerminal_ID = new System.Windows.Forms.TextBox();
            this.labState = new System.Windows.Forms.Label();
            this.labdate = new System.Windows.Forms.Label();
            this.dtpStartDateTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEndDateTime = new System.Windows.Forms.DateTimePicker();
            this.maintainGrid = new System.Windows.Forms.DataGridView();
            this.Terminal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Terminal_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Icon = new System.Windows.Forms.DataGridViewImageColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maintain_StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maintain_EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maintainPage = new CSPN.assistcontrol.DataGridPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTerminal_Name = new System.Windows.Forms.TextBox();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maintainGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTerminal_ID, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labState, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labdate, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.dtpStartDateTime, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.dtpEndDateTime, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.maintainGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.maintainPage, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTerminal_Name, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPlace, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtState, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1052, 475);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(785, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "人井编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTerminal_ID
            // 
            this.txtTerminal_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTerminal_ID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTerminal_ID.Location = new System.Drawing.Point(865, 37);
            this.txtTerminal_ID.Name = "txtTerminal_ID";
            this.txtTerminal_ID.ReadOnly = true;
            this.txtTerminal_ID.Size = new System.Drawing.Size(164, 26);
            this.txtTerminal_ID.TabIndex = 20;
            // 
            // labState
            // 
            this.labState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labState.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labState.Location = new System.Drawing.Point(785, 200);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(74, 60);
            this.labState.TabIndex = 22;
            this.labState.Text = "状态";
            this.labState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labdate
            // 
            this.labdate.AutoSize = true;
            this.labdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labdate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labdate.Location = new System.Drawing.Point(785, 260);
            this.labdate.Name = "labdate";
            this.labdate.Size = new System.Drawing.Size(74, 60);
            this.labdate.TabIndex = 32;
            this.labdate.Text = "开始时间";
            this.labdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpStartDateTime
            // 
            this.dtpStartDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDateTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpStartDateTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDateTime.Location = new System.Drawing.Point(865, 277);
            this.dtpStartDateTime.Name = "dtpStartDateTime";
            this.dtpStartDateTime.Size = new System.Drawing.Size(164, 26);
            this.dtpStartDateTime.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(785, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 60);
            this.label4.TabIndex = 34;
            this.label4.Text = "结束时间";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpEndDateTime
            // 
            this.dtpEndDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDateTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpEndDateTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDateTime.Location = new System.Drawing.Point(865, 337);
            this.dtpEndDateTime.Name = "dtpEndDateTime";
            this.dtpEndDateTime.Size = new System.Drawing.Size(164, 26);
            this.dtpEndDateTime.TabIndex = 35;
            // 
            // maintainGrid
            // 
            this.maintainGrid.AllowUserToAddRows = false;
            this.maintainGrid.AllowUserToDeleteRows = false;
            this.maintainGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.maintainGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.maintainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.maintainGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.maintainGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.maintainGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.maintainGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.maintainGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.maintainGrid.ColumnHeadersHeight = 30;
            this.maintainGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Terminal_ID,
            this.Terminal_Name,
            this.Place,
            this.Icon,
            this.State,
            this.Maintain_StartTime,
            this.Maintain_EndTime});
            this.maintainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maintainGrid.GridColor = System.Drawing.Color.Blue;
            this.maintainGrid.Location = new System.Drawing.Point(3, 3);
            this.maintainGrid.MultiSelect = false;
            this.maintainGrid.Name = "maintainGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.maintainGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.maintainGrid.RowHeadersVisible = false;
            this.maintainGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.maintainGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tableLayoutPanel1.SetRowSpan(this.maintainGrid, 8);
            this.maintainGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.maintainGrid.RowTemplate.Height = 35;
            this.maintainGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.maintainGrid.Size = new System.Drawing.Size(756, 429);
            this.maintainGrid.TabIndex = 37;
            this.maintainGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.maintainGrid_CellClick);
            this.maintainGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.maintainGrid_CellFormatting);
            // 
            // Terminal_ID
            // 
            this.Terminal_ID.DataPropertyName = "a.Terminal_ID";
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
            // Icon
            // 
            this.Icon.DataPropertyName = "Icon";
            this.Icon.HeaderText = "当前状态";
            this.Icon.Name = "Icon";
            this.Icon.ReadOnly = true;
            this.Icon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Icon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "说明";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // Maintain_StartTime
            // 
            this.Maintain_StartTime.DataPropertyName = "Maintain_StartTime";
            this.Maintain_StartTime.HeaderText = "维护开始时间";
            this.Maintain_StartTime.Name = "Maintain_StartTime";
            this.Maintain_StartTime.ReadOnly = true;
            // 
            // Maintain_EndTime
            // 
            this.Maintain_EndTime.DataPropertyName = "Maintain_EndTime";
            this.Maintain_EndTime.HeaderText = "维护结束时间";
            this.Maintain_EndTime.Name = "Maintain_EndTime";
            this.Maintain_EndTime.ReadOnly = true;
            // 
            // maintainPage
            // 
            this.maintainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maintainPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.maintainPage.Location = new System.Drawing.Point(3, 438);
            this.maintainPage.Name = "maintainPage";
            this.maintainPage.PageSize = 50;
            this.maintainPage.Size = new System.Drawing.Size(756, 34);
            this.maintainPage.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(785, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 60);
            this.label2.TabIndex = 39;
            this.label2.Text = "人井名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(785, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 60);
            this.label3.TabIndex = 40;
            this.label3.Text = "地点";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTerminal_Name
            // 
            this.txtTerminal_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTerminal_Name.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTerminal_Name.Location = new System.Drawing.Point(865, 97);
            this.txtTerminal_Name.Name = "txtTerminal_Name";
            this.txtTerminal_Name.ReadOnly = true;
            this.txtTerminal_Name.Size = new System.Drawing.Size(164, 26);
            this.txtTerminal_Name.TabIndex = 41;
            // 
            // txtPlace
            // 
            this.txtPlace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlace.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPlace.Location = new System.Drawing.Point(865, 157);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.ReadOnly = true;
            this.txtPlace.Size = new System.Drawing.Size(164, 26);
            this.txtPlace.TabIndex = 42;
            // 
            // txtState
            // 
            this.txtState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtState.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtState.Location = new System.Drawing.Point(865, 217);
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(164, 26);
            this.txtState.TabIndex = 43;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(785, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 49);
            this.panel1.TabIndex = 45;
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
            this.btnRefresh.Location = new System.Drawing.Point(26, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 26);
            this.btnRefresh.TabIndex = 44;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSet.BackgroundImage")));
            this.btnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSet.FlatAppearance.BorderSize = 0;
            this.btnSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.ForeColor = System.Drawing.Color.White;
            this.btnSet.Location = new System.Drawing.Point(144, 11);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 26);
            this.btnSet.TabIndex = 36;
            this.btnSet.Text = "设定";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // MaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MaintainControl";
            this.Size = new System.Drawing.Size(1052, 475);
            this.Load += new System.EventHandler(this.MaintainControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maintainGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTerminal_ID;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.Label labdate;
        private System.Windows.Forms.DateTimePicker dtpStartDateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndDateTime;
        private System.Windows.Forms.Button btnSet;
        private assistcontrol.DataGridPage maintainPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTerminal_Name;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.DataGridView maintainGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
        private System.Windows.Forms.DataGridViewImageColumn Icon;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maintain_StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maintain_EndTime;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel1;
    }
}
