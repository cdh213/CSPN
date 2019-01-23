using CSPN.common;
using CSPN.job;
using System;
using System.Windows.Forms;

namespace CSPN.control
{
    public partial class LogInfoControl : UserControl
    {
        public LogInfoControl()
        {
            InitializeComponent();
            RefreshWellInfoJob.refreshEvent += new RefreshDelegate(AutoRefresh);
        }

        private void LogInfoControl_Load(object sender, EventArgs e)
        {
            DataLoade(CSPNType.SysLogInfo);
            DataLoade(CSPNType.UserLogInfo_WellInfo);
            DataLoade(CSPNType.UserLogInfo_GeneralInfo);
        }

        //系统日志刷新
        private void btnSysRefresh_Click(object sender, EventArgs e)
        {
            DataLoade(CSPNType.SysLogInfo);
        }

        //用户日志刷新
        private void btnWellInfoRefresh_Click(object sender, EventArgs e)
        {
            DataLoade(CSPNType.UserLogInfo_WellInfo);
        }

        //用户日志刷新
        private void btnGeneralInfoRefresh_Click(object sender, EventArgs e)
        {
            DataLoade(CSPNType.UserLogInfo_GeneralInfo);
        }

        #region 自动刷新

        private void AutoRefresh()
        {
            if (InvokeRequired)
            {
                Sysgrid.Invoke(new RefreshDelegate(AutoRefresh));
                wellInfoGrid.Invoke(new RefreshDelegate(AutoRefresh));
                generalInfoGrid.Invoke(new RefreshDelegate(AutoRefresh));
            }
            else
            {
                DataLoade(CSPNType.SysLogInfo);
                DataLoade(CSPNType.UserLogInfo_WellInfo);
                DataLoade(CSPNType.UserLogInfo_GeneralInfo);
            }
        }

        #endregion 自动刷新

        //加载日志信息
        private void DataLoade(CSPNType type)
        {
            switch (type)
            {
                case CSPNType.SysLogInfo:
                    Sysgrid.AutoGenerateColumns = false;
                    Sysgrid.DataSource = null;
                    Syspage.PageSize = 50;
                    Syspage.ShowPages(Sysgrid, null, type);
                    break;

                case CSPNType.UserLogInfo_WellInfo:
                    wellInfoGrid.AutoGenerateColumns = false;
                    wellInfoGrid.DataSource = null;
                    wellInfoPage.PageSize = 50;
                    wellInfoPage.ShowPages(wellInfoGrid, null, type);
                    break;

                case CSPNType.UserLogInfo_GeneralInfo:
                    generalInfoGrid.AutoGenerateColumns = false;
                    generalInfoGrid.DataSource = null;
                    generalInfoPage.PageSize = 50;
                    generalInfoPage.ShowPages(generalInfoGrid, null, type);
                    break;
            }
        }

        private void Sysgrid_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                e.ToolTipText = "取值从00到31。若为99，表示无信号。";
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == TabSys)
            {
                DataLoade(CSPNType.SysLogInfo);
            }
            else if (e.TabPage == TabWellInfo)
            {
                DataLoade(CSPNType.UserLogInfo_WellInfo);
            }
            else
            {
                DataLoade(CSPNType.UserLogInfo_GeneralInfo);
            }
        }
    }
}