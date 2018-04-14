using System;
using System.Windows.Forms;
using CSPN.IBLL;
using CSPN.BLL;
using CSPN.Model;
using CSPN.common;
using CSPN.sms;
using CSPN.helper;
using CSPN.webbrower;
using CSPN.assistcontrol;
using System.Threading;

namespace CSPN.control
{
    public delegate void RefreshMessageDelegate();

    public partial class PendingMsgControl : UserControl
    {
        public static RefreshMessageDelegate refreshMessageDelegate; 
        IWellStateService wellStateService = new WellStateService();
        IWellInfoService wellInfoService = new WellInfoService();
        UserLogHelper userLogHelper = new UserLogHelper();
        string terminal_ID, phone, place, time, terminal_Name, realName;
        int well_State_ID = 0;

        public PendingMsgControl()
        {
            InitializeComponent();
            GetSMS.GetSMSHandle();
            GetSMS.getSMSDelegate += new GetSMSDelegate(ShowAlarmMsg);
            JsEvent.disposeMsgDelegate += new DisposeMsgDelegate(DisposeMsg_Map);
        }

        #region 列表信息处理
        //报警信息处理
        private void btnAlarm_Click(object sender, EventArgs e)
        {
            int[] n = new int[dgvAlarm.Rows.Count + 1];
            for (int i = 0; i < dgvAlarm.Rows.Count; i++)
            {
                //判断该行的复选框是否存在
                if (dgvAlarm.Rows[i].Cells[0].Value != null)
                {
                    //判断该复选框是否被选中
                    if (Convert.ToBoolean(dgvAlarm.Rows[i].Cells[0].Value))
                    {
                        n[0]++;
                        n[i + 1] = i;
                    }
                }
            }
            if (n[0] == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                WaitWin.Show(this, "正在处理，请稍后。。。。。。");
                for (int i = 1; i < n.Length; i++)
                {
                    time = dgvAlarm.Rows[n[i]].Cells[1].Value.ToString();
                    terminal_ID = dgvAlarm.Rows[n[i]].Cells[2].Value.ToString();
                    well_State_ID = int.Parse(dgvAlarm.Rows[n[i]].Cells[3].Value.ToString());
                    place = dgvAlarm.Rows[n[i]].Cells[5].Value.ToString();
                    phone = dgvAlarm.Rows[n[i]].Cells[7].Value.ToString();
                    dgvAlarm.Rows.RemoveAt(n[i]);
                    DisposeMsg(CSPNType.AlarmInfo);
                    Thread.Sleep(1000);
                }
                WaitWin.Close();
                UMessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //报警信息处理完成
        private void btnDispose_Click(object sender, EventArgs e)
        {
            int[] n = new int[dgvDispose.Rows.Count + 1];
            for (int i = 0; i < dgvDispose.Rows.Count; i++)
            {
                //判断该行的复选框是否存在
                if (dgvDispose.Rows[i].Cells[0].Value != null)
                {
                    //判断该复选框是否被选中
                    if (Convert.ToBoolean(dgvDispose.Rows[i].Cells[0].Value))
                    {
                        n[0]++;
                        n[i + 1] = i;
                    }
                }
            }
            if (n[0] == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                WaitWin.Show(this, "正在处理，请稍后。。。。。。");
                for (int i = 1; i < n.Length; i++)
                {
                    time = dgvDispose.Rows[n[i]].Cells[1].Value.ToString();
                    terminal_ID = dgvDispose.Rows[n[i]].Cells[2].Value.ToString();
                    well_State_ID = int.Parse(dgvDispose.Rows[n[i]].Cells[3].Value.ToString());
                    realName = dgvDispose.Rows[n[i]].Cells[7].Value.ToString();
                    dgvDispose.Rows.RemoveAt(n[i]);
                    DisposeMsg(CSPNType.DisposeInfo);
                    Thread.Sleep(500);
                }
                WaitWin.Close();
                UMessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //未上报处理
        private void btnInform_Click(object sender, EventArgs e)
        {
            int[] n = new int[dgvNotReport.Rows.Count + 1];
            for (int i = 0; i < dgvNotReport.Rows.Count; i++)
            {
                //判断该行的复选框是否存在
                if (dgvNotReport.Rows[i].Cells[0].Value != null)
                {
                    //判断该复选框是否被选中
                    if (Convert.ToBoolean(dgvNotReport.Rows[i].Cells[0].Value))
                    {
                        n[0]++;
                        n[i + 1] = i;
                    }
                }
            }
            if (n[0] == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                WaitWin.Show(this, "正在处理，请稍后。。。。。。");
                for (int i = 1; i < n.Length; i++)
                {
                    terminal_ID = dgvNotReport.Rows[n[i]].Cells[1].Value.ToString();
                    terminal_Name = dgvNotReport.Rows[n[i]].Cells[2].Value.ToString();
                    place = dgvNotReport.Rows[n[i]].Cells[5].Value.ToString();
                    phone = dgvNotReport.Rows[n[i]].Cells[6].Value.ToString();
                    dgvNotReport.Rows.RemoveAt(n[i]);
                    DisposeMsg(CSPNType.NotReportInfo);
                    Thread.Sleep(500);
                }
                WaitWin.Close();
                UMessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 处理信息
        private void DisposeMsg_Map(int well_State_ID, string terminal_ID, CSPNType type)
        {
            ReportInfo reportInfo = wellInfoService.GetReportInfo_Terminal_ID(well_State_ID, terminal_ID);
            this.terminal_ID = terminal_ID;
            this.well_State_ID = well_State_ID;
            phone = reportInfo.OperatorInfo.Telephone;
            place = reportInfo.WellInfo.Place;
            time = reportInfo.Report_Time;
            realName = reportInfo.OperatorInfo.RealName;
            DisposeMsg(type);
            UMessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 处理信息
        /// </summary>
        private void DisposeMsg(CSPNType type)
        {
            switch (type)
            {
                case CSPNType.AlarmInfo:
                    switch (well_State_ID)
                    {
                        case 2:
                            SenAlarmMsg("报警信息", time, realName);
                            break;
                        case 3:
                            SenAlarmMsg("状态信息（低电量报警）", time, realName);
                            break;
                        case 4:
                            SenAlarmMsg("状态信息（烟感报警）", time, realName);
                            break;
                        case 5:
                            SenAlarmMsg("状态信息（烟感低电量报警）", time, realName);
                            break;
                    }
                    wellStateService.UpdateWellCurrentStateInfo(7, terminal_ID);
                    wellInfoService.UpdateReportInfo_Pending(1, terminal_ID);
                    wellInfoService.UpdateReportInfo_Send(7, terminal_ID);
                    GetSMS.UpdateMap(terminal_ID);
                    if (refreshMessageDelegate != null)
                    {
                        refreshMessageDelegate();
                    }
                    break;
                case CSPNType.DisposeInfo:
                    switch (well_State_ID)
                    {
                        //case 2:
                        //    UpdateDisposeMsg("报警信息", time, realName);
                        //    break;
                        //case 3:
                        //    UpdateDisposeMsg("状态信息（低电量报警）", time, realName);
                        //    break;
                        //case 4:
                        //    UpdateDisposeMsg("状态信息（烟感报警）", time, realName);
                        //    break;
                        //case 5:
                        //    UpdateDisposeMsg("状态信息（烟感低电量报警）", time, realName);
                        //    break;
                        case 7:
                            UpdateDisposeMsg("报警信息", time, realName);
                            break;
                    }
                    wellStateService.UpdateWellCurrentStateInfo(1, terminal_ID);
                    wellInfoService.UpdateReportInfo_Send(1, terminal_ID);
                    GetSMS.UpdateMap(terminal_ID);
                    break;
                case CSPNType.NotReportInfo:
                    CDMASMS.SendCHNSms(string.Format("位于：{0}的{1}已经{2}天或超过{2}天未发送信息。", place, terminal_Name, ReadWriteXml.ReadXml("NotReportTimes")), phone);
                    wellInfoService.Empty_NotReportNumInfo(terminal_ID);
                    userLogHelper.InsertUserLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "处理未上报信息。", CommonClass.UserName, null, null);
                    break;
            }
        }
        private void SenAlarmMsg(string msg, string report_Time, string realName)
        {
            CDMASMS.SendCHNSms(msg + "：地点：" + place + "，发生时间：" + time, phone);
            userLogHelper.InsertUserLog(report_Time, "处理" + msg, CommonClass.UserName, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), realName);
        }
        private void UpdateDisposeMsg(string msg, string report_Time, string realName)
        {
            userLogHelper.UpdateUserLog(realName, "完成" + msg + "处理。", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), report_Time);
        }
        #endregion

        #region 委托信息
        //报警信息
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
        #endregion
        
        #region 信息显示
        //报警信息
        private void AlarmDataLoade()
        {
            dgvAlarm.AutoGenerateColumns = false;
            dgvAlarm.DataSource = wellInfoService.GetReportInfo_Pending();
        }
        //已处理信息
        private void DisposeDataLoade()
        {
            dgvDispose.AutoGenerateColumns = false;
            dgvDispose.DataSource = wellInfoService.GetReportInfo_Send();
        }
        //未上报信息
        private void NotReportDataLoade()
        {
            int notReportTimes = int.Parse(ReadWriteXml.ReadXml("NotReportTimes"));
            dgvNotReport.AutoGenerateColumns = false;
            dgvNotReport.DataSource = wellInfoService.GetNotReportNumInfo(notReportTimes);
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == AlarmTab)
            {
                AlarmDataLoade();
            }
            else if (e.TabPage == ProcessedTab)
            {
                DisposeDataLoade();
            }
            else
            {
                NotReportDataLoade();
            }
        }
        #endregion

        #region 创建图片
        void dgvAlarm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAlarm.Columns[e.ColumnIndex].Name.Equals("Icon"))
            {
                e.Value = ImageHelper.ToImage(e.Value.ToString());
            }
        }
        private void dgvDispose_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDispose.Columns[e.ColumnIndex].Name.Equals("disposeIcon"))
            {
                e.Value = ImageHelper.ToImage(e.Value.ToString());
            }
        }
        #endregion

        public void RefreshInfo()
        {
            AlarmDataLoade();
            DisposeDataLoade();
            NotReportDataLoade();
        }
    }
}
