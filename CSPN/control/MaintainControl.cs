using CSPN.assistcontrol;
using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.job;
using CSPN.Model;
using System;
using System.Windows.Forms;

namespace CSPN.control
{
    public partial class MaintainControl : UserControl
    {
        private IWellStateService wellStateService = new WellStateService();
        private WellMaintainInfo wellMaintainInfo = new WellMaintainInfo();
        private string terminal_ID, startDateTime, endDateTime, nowTime;
        private int minutes = 0, value = 0;

        public MaintainControl()
        {
            InitializeComponent();
            RefreshWellInfoJob.refreshEvent += new RefreshDelegate(RefreshInfo);
        }

        private void MaintainControl_Load(object sender, EventArgs e)
        {
            dtpStartDateTime.Value = DateTime.Now;
            dtpEndDateTime.Value = DateTime.Now;

            DataLoade();
        }

        //对Maintenancegrid进行选中，并读取到textbox中
        private void maintainGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtTerminal_ID.Text = terminal_ID = maintainGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTerminal_Name.Text = maintainGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPlace.Text = maintainGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtState.Text = maintainGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                startDateTime = maintainGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                endDateTime = maintainGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                if (startDateTime != "")
                    dtpStartDateTime.Value = Convert.ToDateTime(startDateTime);
                else
                    dtpStartDateTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:00"));

                if (endDateTime != "")
                    dtpEndDateTime.Value = Convert.ToDateTime(endDateTime);
                else
                    dtpEndDateTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:00"));
            }
        }

        //设定修改时间
        private void btnSet_Click(object sender, EventArgs e)
        {
            startDateTime = dtpStartDateTime.Value.ToString("yyyy/MM/dd HH:mm:00");
            endDateTime = dtpEndDateTime.Value.ToString("yyyy/MM/dd HH:mm:00");
            nowTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:00");

            if (txtTerminal_ID.Text.Trim() != "")
            {
                if (startDateTime != endDateTime)
                {
                    value = Convert.ToDateTime(startDateTime).CompareTo(Convert.ToDateTime(nowTime));
                    minutes = (Convert.ToDateTime(startDateTime) - Convert.ToDateTime(nowTime)).Minutes;
                    if (minutes < 0 || value < 0)
                    {
                        UMessageBox.Show("开始时间填写错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        wellMaintainInfo.Maintain_StartTime = startDateTime;
                        wellMaintainInfo.Maintain_EndTime = endDateTime;
                        wellMaintainInfo.Terminal_ID = terminal_ID;
                        if (minutes >= 2)
                        {
                            if (wellStateService.UpdateMaintainInfo(wellMaintainInfo) > 0)
                            {
                                UMessageBox.Show("设置成功。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                UMessageBox.Show("设置失败，请重试。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (wellStateService.MaintainInfoSet(terminal_ID) > 0 && wellStateService.UpdateMaintainInfo(wellMaintainInfo) > 0)
                            {
                                UMessageBox.Show("设置成功。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                UMessageBox.Show("设置失败，请重试。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    DataLoade();
                }
                else
                {
                    UMessageBox.Show("开始时间与结束时间相同。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                UMessageBox.Show("请选择数据。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //取消预约/维护
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtTerminal_ID.Text.Trim() != "")
            {
                if (startDateTime != "" || endDateTime != "")
                {
                    if (txtState.Text.Trim() == "人井维护")
                    {
                        if (wellStateService.MaintainInfoCancel(terminal_ID) > 0)
                        {
                            UMessageBox.Show("取消维护成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            UMessageBox.Show("取消维护失败！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (wellStateService.MaintainInfoCancel(terminal_ID) > 0)
                        {
                            UMessageBox.Show("取消预约成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            UMessageBox.Show("取消预约失败！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    UMessageBox.Show("该人井不在预约/维护状态！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DataLoade();
            }
            else
            {
                UMessageBox.Show("请选择数据。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //刷新
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataLoade();
        }

        //自动刷新
        private void RefreshInfo()
        {
            if (InvokeRequired)
            {
                maintainGrid.Invoke(new RefreshDelegate(RefreshInfo));
            }
            else
            {
                DataLoade();
            }
        }

        //加载系统维护信息
        private void DataLoade()
        {
            txtTerminal_ID.Text = txtTerminal_Name.Text = txtPlace.Text = txtState.Text = "";
            maintainGrid.AutoGenerateColumns = false;
            maintainGrid.DataSource = null;
            maintainPage.PageSize = 50;
            maintainPage.ShowPages(maintainGrid, null, CSPNType.MaintainInfo);
        }

        private void maintainGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (maintainGrid.Columns[e.ColumnIndex].Name.Equals("Icon"))
            {
                e.Value = ImageHelper.ToImage(e.Value.ToString());
            }
        }
    }
}