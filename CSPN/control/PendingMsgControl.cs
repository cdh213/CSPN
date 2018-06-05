using CSPN.assistcontrol;
using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.job;
using CSPN.Model;
using CSPN.sms;
using CSPN.webbrower;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace CSPN.control
{
    public delegate void RefreshMessageDelegate();

    public partial class PendingMsgControl : UserControl
    {
        public static RefreshMessageDelegate refreshMessageDelegate;
        private IWellStateService wellStateService = new WellStateService();
        private IWellInfoService wellInfoService = new WellInfoService();
        private UserLogHelper userLogHelper = new UserLogHelper();
        private static bool isUse = false;
        private string terminal_ID, phone, place, time, terminal_Name, realName;
        private int well_State_ID = 0;
        private List<int> msgList = new List<int>();

        public PendingMsgControl()
        {
            InitializeComponent();
            GetSMS.GetSMSHandle();
            GetSMS.getSMSDelegate += new GetSMSDelegate(ShowAlarmMsg);
            JsEvent.disposeMsgDelegate += new DisposeMsgDelegate(DisposeMsg_Map);
            AutoSendSMSJob.autoSendSMSDelegate += new AutoSendSMSDelegate(AutoAutoSendSMS);
        }

        #region 列表信息处理

        //报警信息处理
        private void btnAlarm_Click(object sender, EventArgs e)
        {
            isUse = true;
            msgList.Clear();
            for (int i = 0; i < dgvAlarm.Rows.Count; i++)
            {
                //判断该行的复选框是否存在
                if (dgvAlarm.Rows[i].Cells[0].Value != null)
                {
                    //判断该复选框是否被选中
                    if (Convert.ToBoolean(dgvAlarm.Rows[i].Cells[0].Value))
                    {
                        msgList.Add(i);
                    }
                }
            }
            if (msgList.Count == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                WaitWin.Show(this, "正在处理，请稍后。。。。。。");
                for (int i = 0; i < msgList.Count; i++)
                {
                    time = dgvAlarm.Rows[msgList[i]].Cells[1].Value.ToString();
                    terminal_ID = dgvAlarm.Rows[msgList[i]].Cells[2].Value.ToString();
                    well_State_ID = int.Parse(dgvAlarm.Rows[msgList[i]].Cells[3].Value.ToString());
                    terminal_Name = dgvAlarm.Rows[msgList[i]].Cells[4].Value.ToString();
                    place = dgvAlarm.Rows[msgList[i]].Cells[5].Value.ToString();
                    phone = dgvAlarm.Rows[msgList[i]].Cells[7].Value.ToString();
                    realName = dgvAlarm.Rows[msgList[i]].Cells[8].Value.ToString();
                    DisposeMsg(CSPNType.AlarmInfo);
                    Thread.Sleep(2000);
                }
                AlarmDataLoade();
                WaitWin.Close();
                UMessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            isUse = false;
        }

        //报警信息处理完成
        private void btnDispose_Click(object sender, EventArgs e)
        {
            msgList.Clear();
            for (int i = 0; i < dgvDispose.Rows.Count; i++)
            {
                //判断该行的复选框是否存在
                if (dgvDispose.Rows[i].Cells[0].Value != null)
                {
                    //判断该复选框是否被选中
                    if (Convert.ToBoolean(dgvDispose.Rows[i].Cells[0].Value))
                    {
                        msgList.Add(i);
                    }
                }
            }
            if (msgList.Count == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                WaitWin.Show(this, "正在处理，请稍后。。。。。。");
                for (int i = 0; i < msgList.Count; i++)
                {
                    time = dgvDispose.Rows[msgList[i]].Cells[1].Value.ToString();
                    terminal_ID = dgvDispose.Rows[msgList[i]].Cells[2].Value.ToString();
                    well_State_ID = int.Parse(dgvDispose.Rows[msgList[i]].Cells[3].Value.ToString());
                    realName = dgvDispose.Rows[msgList[i]].Cells[7].Value.ToString();
                    DisposeMsg(CSPNType.DisposeInfo);
                    Thread.Sleep(1000);
                }
                DisposeDataLoade();
                WaitWin.Close();
                UMessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //未上报处理
        private void btnInform_Click(object sender, EventArgs e)
        {
            msgList.Clear();
            for (int i = 0; i < dgvNotReport.Rows.Count; i++)
            {
                //判断该行的复选框是否存在
                if (dgvNotReport.Rows[i].Cells[0].Value != null)
                {
                    //判断该复选框是否被选中
                    if (Convert.ToBoolean(dgvNotReport.Rows[i].Cells[0].Value))
                    {
                        msgList.Add(i);
                    }
                }
            }
            if (msgList.Count == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                WaitWin.Show(this, "正在处理，请稍后。。。。。。");
                for (int i = 0; i < msgList.Count; i++)
                {
                    terminal_ID = dgvNotReport.Rows[msgList[i]].Cells[1].Value.ToString();
                    terminal_Name = dgvNotReport.Rows[msgList[i]].Cells[2].Value.ToString();
                    place = dgvNotReport.Rows[msgList[i]].Cells[5].Value.ToString();
                    phone = dgvNotReport.Rows[msgList[i]].Cells[6].Value.ToString();
                    realName = dgvNotReport.Rows[msgList[i]].Cells[7].Value.ToString();
                    DisposeMsg(CSPNType.NotReportInfo);
                    Thread.Sleep(2000);
                }
                NotReportDataLoade();
                WaitWin.Close();
                UMessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion 列表信息处理

        #region 处理信息

        private WellCurrentStateInfo wellCurrentStateInfo = null;

        private void DisposeMsg_Map(int well_State_ID, string terminal_ID, CSPNType type)
        {
            wellCurrentStateInfo = wellStateService.GetWellCurrentStateInfo(well_State_ID, terminal_ID);
            this.terminal_ID = terminal_ID;
            this.well_State_ID = well_State_ID;
            phone = wellCurrentStateInfo.OperatorInfo.Telephone;
            place = wellCurrentStateInfo.WellInfo.Place;
            time = wellCurrentStateInfo.Report_Time;
            realName = wellCurrentStateInfo.OperatorInfo.RealName;
            DisposeMsg(type);
            UMessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //自动发送短信
        private void AutoAutoSendSMS(List<WellCurrentStateInfo> list)
        {
            btnAlarm.Enabled = false;
            if (!isUse)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].OperatorInfo.ReceiveMsg.Trim() == "是")
                    {
                        time = list[i].Report_Time.TrimEnd();
                        terminal_ID = list[i].Terminal_ID.TrimEnd();
                        well_State_ID = list[i].Well_State_ID;
                        terminal_Name = list[i].WellInfo.Name.TrimEnd();
                        place = list[i].WellInfo.Place.TrimEnd();
                        phone = list[i].OperatorInfo.Telephone.TrimEnd();
                        realName = list[i].OperatorInfo.RealName.TrimEnd();
                        DisposeMsg(CSPNType.AlarmInfo);
                        Thread.Sleep(2000);
                    }
                }
                ShowAlarmMsg();
            }
            btnAlarm.Enabled = true;
        }

        /// <summary>
        /// 处理信息
        /// </summary>
        private void DisposeMsg(CSPNType type)
        {
            if (type == CSPNType.AlarmInfo)
            {
                switch (well_State_ID)
                {
                    case 2:
                        SenAlarmMsg("报警信息(井盖打开)");
                        wellStateService.UpdateWellCurrentStateInfo(7, terminal_ID);
                        break;

                    case 3:
                        SenAlarmMsg("报警信息(低电量报警)");
                        wellStateService.UpdateWellCurrentStateInfo(8, terminal_ID);
                        break;

                    case 4:
                        SenAlarmMsg("报警信息(烟感报警)");
                        wellStateService.UpdateWellCurrentStateInfo(8, terminal_ID);
                        break;

                    case 5:
                        SenAlarmMsg("报警信息(烟感低电量报警)");
                        wellStateService.UpdateWellCurrentStateInfo(8, terminal_ID);
                        break;
                }
                GetSMS.UpdateMap(terminal_ID);
                if (refreshMessageDelegate != null)
                {
                    refreshMessageDelegate();
                }
            }
            else if (type == CSPNType.DisposeInfo)
            {
                switch (well_State_ID)
                {
                    case 2:
                        UpdateDisposeMsg("报警信息(井盖打开)");
                        break;

                    case 3:
                        UpdateDisposeMsg("报警信息(低电量报警)");
                        break;

                    case 4:
                        UpdateDisposeMsg("报警信息(烟感报警)");
                        break;

                    case 5:
                        UpdateDisposeMsg("报警信息(烟感低电量报警)");
                        break;

                    default:
                        UpdateDisposeMsg("报警信息");
                        break;
                }
                wellStateService.UpdateWellCurrentStateInfo(1, terminal_ID);
                GetSMS.UpdateMap(terminal_ID);
            }
            else
            {
                CDMASMS.SendCHNSms($"位于:{place}的{terminal_Name}已经{ReadWriteXml.ReadXml("NotReportTimes")}天或超过{ReadWriteXml.ReadXml("NotReportTimes")}天未发送信息", phone);
                wellInfoService.Empty_NotReportNumInfo(terminal_ID);
                userLogHelper.InsertUserLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "处理未上报信息", CommonClass.UserName, terminal_ID, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), realName);
            }
        }

        private void SenAlarmMsg(string msg)
        {
            CDMASMS.SendCHNSms($"{msg}--编号:{terminal_ID},名称:{terminal_Name},地点:{place},时间：{time}", phone);
            userLogHelper.InsertUserLog(time, "处理" + msg, CommonClass.UserName, terminal_ID, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), realName);
        }

        private void UpdateDisposeMsg(string msg)
        {
            userLogHelper.UpdateUserLog(realName, "完成" + msg + "处理", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), time);
        }

        #endregion 处理信息

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

        #endregion 委托信息

        #region 信息显示

        //报警信息
        private void AlarmDataLoade()
        {
            dgvAlarm.AutoGenerateColumns = false;
            dgvAlarm.DataSource = wellStateService.GetAlarmInfo();
        }

        //已处理信息
        private void DisposeDataLoade()
        {
            dgvDispose.AutoGenerateColumns = false;
            dgvDispose.DataSource = wellStateService.GetNoticeInfo();
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

        #endregion 信息显示

        #region 创建图片

        private void dgvAlarm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        #endregion 创建图片

        public void RefreshInfo()
        {
            AlarmDataLoade();
            DisposeDataLoade();
            NotReportDataLoade();
        }
    }
}