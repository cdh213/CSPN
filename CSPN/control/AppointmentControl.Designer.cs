namespace CSPN.control
{
    partial class AppointmentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.labState = new System.Windows.Forms.Label();
            this.comState = new System.Windows.Forms.ComboBox();
            this.labdate = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.btnSet = new System.Windows.Forms.Button();
            this.appointmentGrid = new System.Windows.Forms.DataGridView();
            this.Terminal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WellName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WellPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WellState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentPage = new CSPN.assistcontrol.DataGridPage();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labState, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.comState, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.labdate, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker2, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnSet, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.appointmentGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.appointmentPage, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1011, 424);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(684, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "人井编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(784, 37);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(174, 26);
            this.txtID.TabIndex = 20;
            // 
            // labState
            // 
            this.labState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labState.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labState.Location = new System.Drawing.Point(684, 80);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(94, 60);
            this.labState.TabIndex = 22;
            this.labState.Text = "状态";
            this.labState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comState
            // 
            this.comState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comState.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comState.FormattingEnabled = true;
            this.comState.Items.AddRange(new object[] {
            "人井关闭并电量正常",
            "人井关闭并电量不足",
            "人井非正常打开",
            "已通知处理",
            "人井维护"});
            this.comState.Location = new System.Drawing.Point(784, 96);
            this.comState.Name = "comState";
            this.comState.Size = new System.Drawing.Size(174, 28);
            this.comState.TabIndex = 31;
            // 
            // labdate
            // 
            this.labdate.AutoSize = true;
            this.labdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labdate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labdate.Location = new System.Drawing.Point(684, 140);
            this.labdate.Name = "labdate";
            this.labdate.Size = new System.Drawing.Size(94, 60);
            this.labdate.TabIndex = 32;
            this.labdate.Text = "日期";
            this.labdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(784, 157);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(174, 26);
            this.dateTimePicker1.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(684, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 60);
            this.label4.TabIndex = 34;
            this.label4.Text = "时间";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker2.Location = new System.Drawing.Point(783, 217);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(176, 26);
            this.dateTimePicker2.TabIndex = 35;
            // 
            // btnSet
            // 
            this.btnSet.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSet.BackgroundImage")));
            this.btnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSet.FlatAppearance.BorderSize = 0;
            this.btnSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.ForeColor = System.Drawing.Color.White;
            this.btnSet.Location = new System.Drawing.Point(784, 309);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 26);
            this.btnSet.TabIndex = 36;
            this.btnSet.Text = "设定";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // appointmentGrid
            // 
            this.appointmentGrid.AllowUserToAddRows = false;
            this.appointmentGrid.AllowUserToDeleteRows = false;
            this.appointmentGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.appointmentGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.appointmentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.appointmentGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.appointmentGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.appointmentGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.appointmentGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.appointmentGrid.ColumnHeadersHeight = 30;
            this.appointmentGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Terminal_ID,
            this.WellName,
            this.WellPlace,
            this.WellState});
            this.appointmentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appointmentGrid.GridColor = System.Drawing.Color.Blue;
            this.appointmentGrid.Location = new System.Drawing.Point(2, 2);
            this.appointmentGrid.Margin = new System.Windows.Forms.Padding(2);
            this.appointmentGrid.MultiSelect = false;
            this.appointmentGrid.Name = "appointmentGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.appointmentGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.appointmentGrid.RowHeadersVisible = false;
            this.appointmentGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.appointmentGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tableLayoutPanel1.SetRowSpan(this.appointmentGrid, 6);
            this.appointmentGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.appointmentGrid.RowTemplate.Height = 35;
            this.appointmentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentGrid.Size = new System.Drawing.Size(657, 380);
            this.appointmentGrid.TabIndex = 37;
            this.appointmentGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.appointmentGrid_CellContentClick);
            // 
            // Terminal_ID
            // 
            this.Terminal_ID.DataPropertyName = "a.Terminal_ID";
            this.Terminal_ID.HeaderText = "人井ID";
            this.Terminal_ID.Name = "Terminal_ID";
            this.Terminal_ID.ReadOnly = true;
            // 
            // WellName
            // 
            this.WellName.DataPropertyName = "Name";
            this.WellName.HeaderText = "人井名称";
            this.WellName.Name = "WellName";
            this.WellName.ReadOnly = true;
            // 
            // WellPlace
            // 
            this.WellPlace.DataPropertyName = "Place";
            this.WellPlace.HeaderText = "地点";
            this.WellPlace.Name = "WellPlace";
            this.WellPlace.ReadOnly = true;
            // 
            // WellState
            // 
            this.WellState.DataPropertyName = "State";
            this.WellState.HeaderText = "当前状态";
            this.WellState.Name = "WellState";
            this.WellState.ReadOnly = true;
            // 
            // appointmentPage
            // 
            this.appointmentPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appointmentPage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.appointmentPage.Location = new System.Drawing.Point(3, 388);
            this.appointmentPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.appointmentPage.Name = "appointmentPage";
            this.appointmentPage.PageCount = 0;
            this.appointmentPage.PageIndex = 1;
            this.appointmentPage.PageSize = 30;
            this.appointmentPage.RecorderCount = 0;
            this.appointmentPage.Size = new System.Drawing.Size(655, 32);
            this.appointmentPage.TabIndex = 38;
            // 
            // AppointmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AppointmentControl";
            this.Size = new System.Drawing.Size(1011, 424);
            this.Load += new System.EventHandler(this.AppointmentControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.ComboBox comState;
        private System.Windows.Forms.Label labdate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnSet;
        public System.Windows.Forms.DataGridView appointmentGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WellName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WellPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn WellState;
        private assistcontrol.DataGridPage appointmentPage;
    }
}
