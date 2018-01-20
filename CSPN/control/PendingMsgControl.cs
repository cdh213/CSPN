using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSPN.IBLL;
using CSPN.BLL;
using CSPN.Model;
using System.Globalization;
using CSPN.common;
using CSPN.sms;
using CSPN.helper;
using CSPN.webbrower;

namespace CSPN.control
{
    public partial class PendingMsgControl : UserControl
    {
        IWellStateService wellStateService = new WellStateService();
        IWellInfoService wellInfoService = new WellInfoService();
        UserLogHelper userLogHelper = new UserLogHelper();
        string phone, place, time, terminal_Name, _terminal_ID;
        int _well_State_ID;

        public PendingMsgControl()
        {
            InitializeComponent();
            GetSMS.GetSMSHandle();
            GetSMS.getSMSEventHandler += new GetSMSEventHandler(ShowAlarmMsg);
            JsEvent.disposeMsgDelegate = new DisposeMsgDelegate(DisposeMsg);
        }

        #region 列表信息处理
        //报警信息处理
        void dgvAlarm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvAlarm.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    _terminal_ID = dgvAlarm.Rows[e.RowIndex].Cells[1].Value.ToString();
                    _well_State_ID = int.Parse(dgvAlarm.Rows[e.RowIndex].Cells[2].Value.ToString());
                    dgvAlarm.Rows.RemoveAt(e.RowIndex);
                    DisposeMsg(_well_State_ID, _terminal_ID, CSPNType.AlarmInfo);
                }
            }
        }
        //报警信息处理完成
        private void dgvDispose_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvDispose.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    _terminal_ID = dgvDispose.Rows[e.RowIndex].Cells[1].Value.ToString();
                    _well_State_ID = int.Parse(dgvDispose.Rows[e.RowIndex].Cells[2].Value.ToString());
                    dgvDispose.Rows.RemoveAt(e.RowIndex);
                    DisposeMsg(_well_State_ID, _terminal_ID, CSPNType.DisposeInfo);
                }
            }
        }
        //未上报处理
        private void dgvNotReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvNotReport.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    _terminal_ID = dgvNotReport.Rows[e.RowIndex].Cells[0].Value.ToString();
                    terminal_Name = dgvNotReport.Rows[e.RowIndex].Cells[1].Value.ToString();
                    place = dgvNotReport.Rows[e.RowIndex].Cells[4].Value.ToString();
                    phone = dgvNotReport.Rows[e.RowIndex].Cells[5].Value.ToString();
                    dgvNotReport.Rows.RemoveAt(e.RowIndex);
                    DisposeMsg(0, null, CSPNType.NotReportInfo);
                }
            }
        }
        #endregion

        #region 处理信息（同时适用于地图）
        /// <summary>
        /// 处理所有（同时适用于地图）
        /// </summary>
        public void DisposeMsg(int well_State_ID, string terminal_ID, CSPNType type)
        {
            switch (type)
            {
                case CSPNType.AlarmInfo:
                    WellCurrentStateInfo alarmInfo = wellStateService.GetAlarmInfo_StatusInfo(well_State_ID, terminal_ID);
                    phone = alarmInfo.OperatorInfo.Telephone;
                    place = alarmInfo.WellInfo.Place;
                    time = alarmInfo.Report_Time;
                    switch (well_State_ID)
                    {
                        case 2:
                            SenAlarmMsg("报警信息", alarmInfo.Report_Time, alarmInfo.OperatorInfo.RealName);
                            break;
                        case 3:
                            SenAlarmMsg("状态信息（低电量报警）", alarmInfo.Report_Time, alarmInfo.OperatorInfo.RealName);
                            break;
                        case 4:
                            SenAlarmMsg("状态信息（烟感报警）", alarmInfo.Report_Time, alarmInfo.OperatorInfo.RealName);
                            break;
                        case 5:
                            SenAlarmMsg("状态信息（烟感低电量报警）", alarmInfo.Report_Time, alarmInfo.OperatorInfo.RealName);
                            break;
                    }
                    wellStateService.UpdateWellCurrentStateInfo(7, terminal_ID);
                    GetSMS.UpdateMap(terminal_ID);
                    MessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case CSPNType.DisposeInfo:
                    WellCurrentStateInfo disposeInfo = wellStateService.GetAlarmInfo_StatusInfo(well_State_ID, terminal_ID);
                    switch (well_State_ID)
                    {
                        case 2:
                            UpdateDisposeMsg("报警信息", disposeInfo.Report_Time, disposeInfo.OperatorInfo.RealName);
                            break;
                        case 3:
                            UpdateDisposeMsg("状态信息（低电量报警）", disposeInfo.Report_Time, disposeInfo.OperatorInfo.RealName);
                            break;
                        case 4:
                            UpdateDisposeMsg("状态信息（烟感报警）", disposeInfo.Report_Time, disposeInfo.OperatorInfo.RealName);
                            break;
                        case 5:
                            UpdateDisposeMsg("状态信息（烟感低电量报警）", disposeInfo.Report_Time, disposeInfo.OperatorInfo.RealName);
                            break;
                    }
                    wellStateService.UpdateWellCurrentStateInfo(1, terminal_ID);
                    GetSMS.UpdateMap(terminal_ID);
                    MessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case CSPNType.NotReportInfo:
                    CDMASMS.SendCHNSms(string.Format("位于：{0}的{1}已经{2}天或超过{2}天未发送信息。", place, terminal_Name, ReadWriteConfig.ReadConfig("NotReportTimes")), phone);
                    wellInfoService.Empty_NotReportNumInfo(_terminal_ID);
                    userLogHelper.InsertUserLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "处理未上报信息。", CommonClass.UserName, null, null);
                    MessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dgvAlarm.Invoke(new GetSMSEventHandler(ShowAlarmMsg));
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
            dgvAlarm.DataSource = wellStateService.GetAlarmInfo_StatusInfo();
        }
        //已处理信息
        private void DisposeDataLoade()
        {
            dgvDispose.AutoGenerateColumns = false;
            dgvDispose.DataSource = wellStateService.GetProcessedInfo();
        }
        //未上报信息
        private void NotReportDataLoade()
        {
            int reportTimes = int.Parse(ReadWriteConfig.ReadConfig("NotReportTimes"));
            dgvNotReport.AutoGenerateColumns = false;
            dgvNotReport.DataSource = wellInfoService.GetNotReportNumInfo(reportTimes);
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
            if (dgvDispose.Columns[e.ColumnIndex].Name.Equals("dgvIcon"))
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
