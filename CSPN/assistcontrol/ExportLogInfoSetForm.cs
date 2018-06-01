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
        private BindingSource bs = new BindingSource();
        private ILogService logService = new LogService();
        private ExcelHelper ex = new ExcelHelper();
        private DataTable dt = new DataTable();
        private DataView dv = new DataView();
        private Dictionary<string, string> dic = null;
        private int j = 0;
        private CSPNType _type;
        private string fileName = "";

        public ExportLogInfoSetForm(CSPNType type)
        {
            InitializeComponent();
            _type = type;
        }

        private void ExportLogInfoSetForm_Load(object sender, EventArgs e)
        {
            switch (_type)
            {
                case CSPNType.SysLogInfo:
                    dic = new Dictionary<string, string>() { { "Happen_Time", "发生时间" }, { "Terminal_ID", "人井编号" }, { "Name", "人井名称" }, { "Place", "地点" }, { "State", "人井状态" }, { "Electricity", "电量" }, { "Temperature", "温度" }, { "Humidity", "湿度" }, { "Smoke_Detector", "烟感" }, { "Smoke_Power", "烟感电量" }, { "Signal_Strength", "信号强度" } };
                    bs.DataSource = dic;
                    clbItems.DataSource = bs;
                    clbItems.DisplayMember = "Value";
                    clbItems.ValueMember = "Key";
                    for (int i = 0; i < dic.Count; i++)
                    {
                        clbItems.SetItemChecked(i, true);
                    }
                    dt = logService.GetSystemLogInfo();
                    fileName = "系统日志" + DateTime.Now.ToString("yyyy-MM-dd");
                    clbItems.SetItemCheckState(0, CheckState.Indeterminate);
                    SetTime();
                    break;

                case CSPNType.UserLogInfo_WellInfo:
                    dic = new Dictionary<string, string>() { { "Happen_Time", "发生时间" }, { "Terminal_ID", "人井编号" }, { "Name", "人井名称" }, { "Place", "地点" }, { "The_Operator", "操作者" }, { "Operation_Content", "操作内容" }, { "Receive_People", "接收者" }, { "Notice_time", "通知时间" }, { "Processor", "处理人" }, { "Process_Content", "处理内容" }, { "Process_Time", "处理时间" }, { "Current_State", "是否已处理" } };
                    bs.DataSource = dic;
                    clbItems.DataSource = bs;
                    clbItems.DisplayMember = "Value";
                    clbItems.ValueMember = "Key";
                    for (int i = 0; i < dic.Count; i++)
                    {
                        clbItems.SetItemChecked(i, true);
                    }
                    dt = logService.GetUserLogInfo_WellInfo();
                    fileName = "人井处理日志" + DateTime.Now.ToString("yyyy-MM-dd");
                    clbItems.SetItemCheckState(0, CheckState.Indeterminate);
                    SetTime();
                    break;

                case CSPNType.UserLogInfo_GeneralInfo:
                    dic = new Dictionary<string, string>() { { "Happen_Time", "发生时间" }, { "The_Operator", "操作者" }, { "Operation_Content", "操作内容" } };
                    bs.DataSource = dic;
                    clbItems.DataSource = bs;
                    clbItems.DisplayMember = "Value";
                    clbItems.ValueMember = "Key";
                    for (int i = 0; i < dic.Count; i++)
                    {
                        clbItems.SetItemChecked(i, true);
                    }
                    dt = logService.GetUserLogInfo_GeneralInfo();
                    fileName = "用户日志" + DateTime.Now.ToString("yyyy-MM-dd");
                    clbItems.SetItemCheckState(0, CheckState.Indeterminate);
                    SetTime();
                    break;
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            WaitWin.Show(this, "正在导出，请稍后。。。。。。");
            SetData();
            if (dt.Rows.Count == 0)
            {
                UMessageBox.Show("当前没有数据。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                WaitWin.Close();
                return;
            }
            ex.setExcel(dt, fileName);
            WaitWin.Close();
            Close();
        }

        private void SetData()
        {
            dv = dt.DefaultView;
            dv.RowFilter = string.Format("{0}>=#{1}# and {0}<=#{2}#", "Happen_Time", dtpStartTime.Value.ToString("yyyy/MM/dd 00:00:00"), dtpEndTime.Value.ToString("yyyy/MM/dd 23:59:59"));
            dt = dv.ToTable();

            foreach (KeyValuePair<string, string> item in dic)
            {
                if (dt.Columns[j].ColumnName == item.Key)
                {
                    dt.Columns[j].ColumnName = item.Value;
                }
                j++;
            }

            for (int i = 0; i < clbItems.Items.Count; i++)
            {
                if (!clbItems.GetItemChecked(i))
                {
                    dt.Columns.RemoveAt(i);
                }
            }
        }

        private void SetTime()
        {
            dtpEndTime.MaxDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd 23:59:59"));
            dtpStartTime.MaxDate = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd 23:59:59"));
            if (dt.Rows.Count == 0)
            {
                dtpStartTime.MinDate = DateTime.Now.Date;
                dtpEndTime.MinDate = DateTime.Now.Date;
                dtpStartTime.Value = DateTime.Now.Date;
            }
            else
            {
                DateTime minTime = DateTime.Parse(dt.AsEnumerable().Select(t => t.Field<DateTime>("Happen_Time")).Min().ToString("yyyy/MM/dd 23:59:59"));

                dtpStartTime.MinDate = minTime;
                dtpEndTime.MinDate = minTime;
                dtpStartTime.Value = minTime;
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
    }
}