using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class ExportLogInfoSetForm : Form
    {
        ILogService logService = new LogService();
        ExcelHelper ex = new ExcelHelper();
        DataTable dt = new DataTable();
        DataView dv = new DataView();
        List<Items> list = new List<Items>();
        List<string> timelist = new List<string>();
        CSPNType _type;

        public ExportLogInfoSetForm(DataGridView dgv, CSPNType type)
        {
            InitializeComponent();
            _type = type;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                ExportLogInfoSetForm.Items items = new ExportLogInfoSetForm.Items();
                items.HeaderText = dgv.Columns[i].HeaderText;
                items.DataPropertyName = dgv.Columns[i].DataPropertyName;
                list.Add(items);
            }
            dt = dgv.DataSource as DataTable;
        }

        private void ExportLogInfoSetForm_Load(object sender, EventArgs e)
        {
            clbItems.DataSource = list;
            clbItems.DisplayMember = "HeaderText";
            clbItems.ValueMember = "DataPropertyName";
            for (int i = 0; i < list.Count; i++)
            {
                clbItems.SetItemChecked(i, true);
            }
            clbItems.SetItemCheckState(0, CheckState.Indeterminate);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                timelist.Add(dt.Rows[i][0].ToString());
            }
            SetTime();
        }
        private void rbCurrent_CheckedChanged(object sender, EventArgs e)
        {
            SetTime();
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            WaitWin.Show(this, "正在导出，请稍后。。。。。。");
            //导出当前页
            if (rbCurrent.Checked)
            {
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("当前页中没有数据", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SetData();
                }
            }
            else//导出全部
            {
                switch (_type)
                {
                    case CSPNType.SysLogInfo:
                        dt = logService.GetSystemLogInfo();
                        break;
                    case CSPNType.UserLogInfo_WellInfo:
                        dt = logService.GetUserLogInfo_WellInfo();
                        break;
                    case CSPNType.UserLogInfo_GeneralInfo:
                        dt = logService.GetUserLogInfo_GeneralInfo();
                        break;
                }
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("没有数据", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SetData();
                }
            }
            ex.setExcel(dt);
            WaitWin.Close();
            this.Close();
        }
        private void SetData()
        {
            dv = dt.DefaultView;
            dv.RowFilter = string.Format("{0}>=#{1}# and {0}<=#{2}#", list[0].DataPropertyName, dtpStartTime.Value.Date.ToString(), dtpEndTime.Value.Date.ToString());
            dt = dv.ToTable();

            for (int i = 0; i < list.Count; i++)
            {
                if (dt.Columns[i].ColumnName == list[i].DataPropertyName)
                {
                    dt.Columns[i].ColumnName = list[i].HeaderText;
                }
            }
            for (int i = 0; i < clbItems.Items.Count; i++)
            {
                if (!clbItems.GetItemChecked(i))
                {
                    dt.Columns.Remove(list[i].HeaderText);
                }
            }
        }
        private void SetTime()
        {
            dtpEndTime.MaxDate = DateTime.Now;
            dtpStartTime.MaxDate = DateTime.Now;
            if (rbCurrent.Checked)
            {
                dtpStartTime.MinDate = DateTime.Parse(timelist.Min());
                dtpStartTime.Value = DateTime.Parse(timelist.Min());
            }
            else
            {
                dtpStartTime.MinDate = logService.GetMinHappen_Time();
                dtpStartTime.Value = logService.GetMinHappen_Time();
            }
        }
         private void ExportLogInfoSetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dv.Dispose();
            dt.Dispose();
        }
        private void clbItems_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Indeterminate)
            {
                e.NewValue = CheckState.Indeterminate;
            }
        }
        class Items
        {
            public string HeaderText { get; set; }
            public string DataPropertyName { get; set; }
        }
    }
}
