using CefSharp;
using CSPN.BLL;
using CSPN.control;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.job;
using CSPN.Model;
using CSPN.sms;
using CSPN.webbrower;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class MessageForm : Form
    {
        private static MessageForm messageForm = null;
        private IWellInfoService wellInfoService = new WellInfoService();
        private IWellStateService wellStateService = new WellStateService();
        private string terminal_ID = null;
        private List<WellInfo> list = null;
        private string json = null;

        private MessageForm()
        {
            InitializeComponent();
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width, Screen.PrimaryScreen.WorkingArea.Height - Height);
            PointToScreen(p);
            Location = p;

            GetSMS.getSMSEvent += new GetSMSDelegate(ShowAlarmMsg);
            PendingMsgControl.refreshMessageEvent += new RefreshMessageDelegate(ShowAlarmMsg);
            RefreshWellInfoJob.refreshEvent += new RefreshDelegate(RefreshInfo);
        }

        public static MessageForm GetMessageForm()
        {
            if (messageForm == null || messageForm.IsDisposed)
            {
                messageForm = new MessageForm();
            }
            return messageForm;
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            if (dgvAlarm.SelectedRows.Count == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            terminal_ID = dgvAlarm.CurrentRow.Cells[1].Value.ToString();
            list = wellInfoService.GetWellInfo_List(terminal_ID);
            json = JsonConvert.SerializeObject(list);
            WebBrower.webBrower.ExecuteScriptAsync("searchData", json);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(232, 17, 35);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(83, 143, 198);
        }

        //显示信息
        private void ShowAlarmMsg()
        {
            if (dgvAlarm.InvokeRequired)
            {
                dgvAlarm.Invoke(new GetSMSDelegate(ShowAlarmMsg));
            }
            else
            {
                AlarmDataLoade();
            }
        }

        //自动刷新
        private void RefreshInfo()
        {
            if (dgvAlarm.InvokeRequired)
            {
                dgvAlarm.Invoke(new RefreshDelegate(RefreshInfo));
            }
            else
            {
                AlarmDataLoade();
            }
        }

        private void AlarmDataLoade()
        {
            dgvAlarm.AutoGenerateColumns = false;
            dgvAlarm.DataSource = wellStateService.GetAlarmInfo();
            if (dgvAlarm.Rows.Count == 0)
            {
                if (GetMessageForm().InvokeRequired)
                {
                    GetMessageForm().Invoke(new Action(() => { GetMessageForm().Visible = false; }));
                }
                else
                {
                    GetMessageForm().Visible = false;
                }
            }
        }

        private void dgvAlarm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAlarm.Columns[e.ColumnIndex].Name.Equals("Icon"))
            {
                e.Value = ImageHelper.ToImage(e.Value.ToString());
            }
        }
    }
}