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

namespace CSPN.control
{
    public partial class PendingMsgControl : UserControl
    {
        IWellStateService wellStateService = new WellStateService();
        IWellInfoService wellInfoService = new WellInfoService();
        UserLogHelper userLogHelper = new UserLogHelper();
        WellCurrentStateInfo wellCurrentStateInfo = new WellCurrentStateInfo();
        WellStateInfo wellStateInfo = new WellStateInfo();
        WellInfo wellInfo = new WellInfo();

        public PendingMsgControl()
        {
            InitializeComponent();
            GetSMS.GetSMSHandle();
            GetSMS.getSMSHandler += new GetSMS.GetSMSEventHandler(ShowMsg);
            this.Load += PendingMsgControl_Load;
        }

        void PendingMsgControl_Load(object sender, EventArgs e)
        {
            tabControl1.Focus();
        }

        #region 列表显示报警，状态信息
        /// <summary>
        /// 列表显示报警，状态信息
        /// </summary>
        void ShowMsg(int well_State_ID, string terminal_ID)
        {
            Control control = this.ActiveControl;
            if (control != null)
            {
                if (control.Name == "tabControl1")
                {
                    control.BeginInvoke(new Action(() =>
                    {
                        if (tabControl1.SelectedTab == tab1)
                        {
                            wellCurrentStateInfo = wellStateService.GetAlarmInfo_StatusInfo(well_State_ID, terminal_ID);

                            gridAlarm.Rows.Add(wellCurrentStateInfo.WellInfo.Terminal_ID, wellCurrentStateInfo.Well_State_ID, wellCurrentStateInfo.WellInfo.Name, wellCurrentStateInfo.WellInfo.Place, wellCurrentStateInfo.WellStateInfo.Icon, wellCurrentStateInfo.Report_Time, wellCurrentStateInfo.OperatorInfo.Telephone);
                            gridAlarm.Sort(gridAlarm.Columns[5], ListSortDirection.Descending);
                        }
                    }));
                }
            }
        }
        #endregion

        #region 列表报警信息处理
        /// <summary>
        /// 报警信息处理
        /// </summary>
        void gridAlarm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = gridAlarm.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    string terminal_ID = gridAlarm.Rows[e.RowIndex].Cells[0].Value.ToString();
                    int well_State_ID = int.Parse(gridAlarm.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DisposeMsg(well_State_ID, terminal_ID, true);
                    gridAlarm.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        /// <summary>
        /// 报警信息处理完成
        /// </summary>
        private void dgvDispose_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvDispose.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    string terminal_ID = dgvDispose.Rows[e.RowIndex].Cells[0].Value.ToString();
                    int well_State_ID = int.Parse(dgvDispose.Rows[e.RowIndex].Cells[1].Value.ToString());
                    DisposeMsg(well_State_ID, terminal_ID, false);
                    dgvDispose.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        /// <summary>
        /// 处理报警信息以及完成处理（同时适用于地图）
        /// </summary>
        public void DisposeMsg(int well_State_ID,string terminal_ID, bool isAlarm)
        {
            if (isAlarm)
            {
                string phone = null, place = null, time = null;
                wellCurrentStateInfo = wellStateService.GetAlarmInfo_StatusInfo(well_State_ID, terminal_ID);

                if (wellCurrentStateInfo != null)
                {
                    phone = wellCurrentStateInfo.OperatorInfo.Telephone;
                    place = wellCurrentStateInfo.WellInfo.Place;
                    time = wellCurrentStateInfo.Report_Time;

                    CDMASMS.SendCHNSms("报警信息：地点：" + place + "，发生时间：" + time, phone);

                    userLogHelper.InsertUserLog(wellCurrentStateInfo.Report_Time, "处理报警信息", CommonClass.UserName, DateTime.Now.ToString("yyyy/MM/dd"), wellCurrentStateInfo.OperatorInfo.RealName);

                    wellStateService.UpdateWellCurrentStateInfo(5, terminal_ID);
                    GetSMS.UpdateMap(terminal_ID);
                    MessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                wellCurrentStateInfo = wellStateService.GetAlarmInfo_StatusInfo(well_State_ID, terminal_ID);

                userLogHelper.UpdateUserLog(wellCurrentStateInfo.Report_Time, wellCurrentStateInfo.OperatorInfo.RealName, "完成报警信息处理。", DateTime.Now.ToString("yyyy/MM/dd"));

                wellStateService.UpdateWellCurrentStateInfo(1, terminal_ID);
                GetSMS.UpdateMap(terminal_ID);
                MessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 通知处理
        private void tabControl1_Enter(object sender, EventArgs e)
        {
            gridAlarm.Rows.Clear();
            IList<WellCurrentStateInfo> list = wellStateService.GetAlarmInfo_StatusInfo();
            for (int i = 0; i < list.Count; i++)
            {
                gridAlarm.Rows.Add(list[i].WellInfo.Terminal_ID, list[i].Well_State_ID, list[i].WellInfo.Name, list[i].WellInfo.Place, list[i].WellStateInfo.Icon, list[i].Report_Time, list[i].OperatorInfo.Telephone);
                gridAlarm.Sort(gridAlarm.Columns[5], ListSortDirection.Descending);
            }
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == ProcessedTab)
            {
                dgvDispose.Rows.Clear();
                IList<WellCurrentStateInfo> wellCurrentlist = wellStateService.GetProcessedInfoByWell_State_ID(5);
                for (int i = 0; i < wellCurrentlist.Count; i++)
                {
                    dgvDispose.Rows.Add(wellCurrentlist[i].WellInfo.Terminal_ID, wellCurrentlist[i].Well_State_ID, wellCurrentlist[i].WellInfo.Name, wellCurrentlist[i].WellInfo.Place, wellCurrentlist[i].WellStateInfo.Icon, wellCurrentlist[i].Report_Time, wellCurrentlist[i].OperatorInfo.Telephone);
                    dgvDispose.Sort(dgvDispose.Columns[5], ListSortDirection.Descending);
                }
            }
            if (e.TabPage == NotReportTab)
            {
                dgvNotReport.Rows.Clear();
                NotReportNum();
            }
        }
        #endregion

        #region 未上报
        void NotReportNum()
        {
            int reportTimes = int.Parse(ReadWriteConfig.ReadConfig("NotReportTimes"));
            IList<ReportNumInfo> list = wellInfoService.GetNotReportNumInfo(reportTimes);
            for (int i = 0; i < list.Count; i++)
            {
                dgvNotReport.Rows.Add(list[i].WellInfo.Terminal_ID, list[i].WellInfo.Name, list[i].WellInfo.Longitude, list[i].WellInfo.Latitude, list[i].WellInfo.Place, list[i].ReportTimes, list[i].OperatorInfo.Telephone);
            }
        }
        private void dgvNotReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvNotReport.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    string terminal_Name = dgvNotReport.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string place = dgvNotReport.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string phone = dgvNotReport.Rows[e.RowIndex].Cells[6].Value.ToString();
                    CDMASMS.SendCHNSms(string.Format("位于：{0}的{1}已经{2}天或超过{2}天未发送信息。", place, terminal_Name, ReadWriteConfig.ReadConfig("NotReportTimes")), phone);

                    userLogHelper.InsertUserLog(wellCurrentStateInfo.Report_Time, "处理未上报信息。", CommonClass.UserName, null, null);
                    MessageBox.Show("处理成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvNotReport.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        #endregion

        #region 创建图片
        void gridAlarm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridAlarm.Columns[e.ColumnIndex].Name.Equals("Icon"))
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
    }
}
