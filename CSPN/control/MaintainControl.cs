using System;
using System.Windows.Forms;
using CSPN.helper;
using CSPN.common;
using CSPN.Model;
using CSPN.IBLL;
using CSPN.BLL;
using CSPN.job;

namespace CSPN.control
{
    public partial class MaintainControl : UserControl
    {
        IWellStateService wellStateService = new WellStateService();
        WellCurrentStateInfo wellCurrentStateInfo = new WellCurrentStateInfo();
        string terminal_ID, startDateTime, endDateTime;

        public MaintainControl()
        {
            InitializeComponent();
            RefreshWellInfoJob.refreshEventHandler += new job.RefreshEventHandler(RefreshInfo);
        }
        private void MaintainControl_Load(object sender, EventArgs e)
        {
            DataLoade(false, null);
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

            if (startDateTime == endDateTime)
            {
                MessageBox.Show("时间填写错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                wellCurrentStateInfo.Maintain_StartTime = startDateTime;
                wellCurrentStateInfo.Maintain_EndTime = endDateTime;
                wellCurrentStateInfo.Terminal_ID = terminal_ID;
                if (wellStateService.UpdateMaintainInfo(wellCurrentStateInfo) > 0)
                {
                    MessageBox.Show("设置成功。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("设置失败，请重试。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //刷新
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataLoade(false, null);
        }
        //自动刷新
        private void RefreshInfo()
        {
            if (maintainGrid.InvokeRequired)
            {
                maintainGrid.Invoke(new job.RefreshEventHandler(RefreshInfo));
            }
            else
            {
                DataLoade(false, null);
            }
        }
        //加载系统维护信息
        private void DataLoade(bool strWhere, string info)
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
