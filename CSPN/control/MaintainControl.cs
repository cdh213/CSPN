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
        private string terminal_ID, startDateTime, endDateTime;

        public MaintainControl()
        {
            InitializeComponent();
            RefreshWellInfoJob.refreshDelegate += new RefreshDelegate(RefreshInfo);
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
                    dtpStartDateTime.Value = DateTime.Parse(startDateTime);
                else
                    dtpStartDateTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:00"));

                if (endDateTime != "")
                    dtpEndDateTime.Value = DateTime.Parse(endDateTime);
                else
                    dtpEndDateTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd HH:mm:00"));
            }
        }

        //设定修改时间
        private void btnSet_Click(object sender, EventArgs e)
        {
            startDateTime = dtpStartDateTime.Value.ToString("yyyy/MM/dd HH:mm:00");
            endDateTime = dtpEndDateTime.Value.ToString("yyyy/MM/dd HH:mm:00");

            if (txtTerminal_ID.Text.Trim() != "")
            {
                if (startDateTime != endDateTime)
                {
                    wellMaintainInfo.Maintain_StartTime = startDateTime;
                    wellMaintainInfo.Maintain_EndTime = endDateTime;
                    wellMaintainInfo.Terminal_ID = terminal_ID;
                    if (wellStateService.UpdateMaintainInfo(wellMaintainInfo) > 0)
                    {
                        UMessageBox.Show("设置成功。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        UMessageBox.Show("设置失败，请重试。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    DataLoade();
                }
                else
                {
                    UMessageBox.Show("时间填写错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            if (maintainGrid.InvokeRequired)
            {
                maintainGrid.Invoke(new RefreshDelegate(RefreshInfo));
            }
            else
            {
                DataLoade();
            }
        }

        //取消维护
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtTerminal_ID.Text.Trim() != "")
            {
                if (txtState.Text.Trim() == "人井维护")
                {
                    if (wellStateService.MaintainInfoCancel(0, terminal_ID) > 0)
                    {
                        UMessageBox.Show("成功取消维护！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        UMessageBox.Show("取消维护失败！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    DataLoade();
                }
                else
                {
                    UMessageBox.Show("该人井不在维护状态！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                UMessageBox.Show("请选择数据。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //加载系统维护信息
        private void DataLoade()
        {
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