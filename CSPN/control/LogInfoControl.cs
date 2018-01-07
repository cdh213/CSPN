using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSPN.assistcontrol;
using CSPN.helper;
using CSPN.common;
using CSPN.job;

namespace CSPN.control
{
    public partial class LogInfoControl : UserControl
    {
        public LogInfoControl()
        {
            InitializeComponent();
            InitializeSysLogInfo();
            InitializeUserLogInfo_WellInfo();
            InitializeUserLogInfo_GeneralInfo();
            RefreshWellInfoJob.refreshEventHandler += new job.RefreshEventHandler(RefreshInfo);
        }
        
        private void LogInfoControl_Load(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
            DataLoade(false, null);
        }

        private void cbType_DropDownClosed(object sender, EventArgs e)
        {
            DataLoade(false, null);
        }
        //将系统日志导出数据库
        private void btnSysOut_Click(object sender, EventArgs e)
        {
            new ExportLogInfoSetForm(Sysgrid, CSPNType.SysLogInfo).ShowDialog(this);
            DataLoade(false, null);
        }
        //将用户日志导出数据库
        private void btnUserOut_Click(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex == 0)
            {
                new ExportLogInfoSetForm((DataGridView)panelUser.Controls[0], CSPNType.UserLogInfo_WellInfo).ShowDialog(this);
            }
            else
            {
                new ExportLogInfoSetForm((DataGridView)panelUser.Controls[0], CSPNType.UserLogInfo_GeneralInfo).ShowDialog(this);
            }
            DataLoade(false, null);
        }
        //显示图标
        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Sysgrid.Columns[e.ColumnIndex].Name.Equals("Icon"))
            {
                e.Value = ImageHelper.ToImage(e.Value.ToString());
            }
        }
        //自动刷新
        private void RefreshInfo()
        {
            if (Sysgrid.InvokeRequired)
            {
                Sysgrid.Invoke(new job.RefreshEventHandler(RefreshInfo));
            }
            else
            {
                DataLoade(false, null);
            }
        }
        //加载日志信息
        private void DataLoade(bool strWhere, string info)
        {
            //系统日志
            panelSys.Controls.Clear();
            panelSys.Controls.Add(Sysgrid);
            Sysgrid.AutoGenerateColumns = false;
            Sysgrid.DataSource = null;
            Syspage.PageSize = 50;
            Syspage.ShowPages(Sysgrid, info, CSPNType.SysLogInfo);
            //用户日志
            if (cbType.SelectedIndex == 0)
            {
                panelUser.Controls.Clear();
                panelUser.Controls.Add(gridUserLogInfo_WellInfo);
                gridUserLogInfo_WellInfo.AutoGenerateColumns = false;
                gridUserLogInfo_WellInfo.DataSource = null;
                userpage.PageSize = 50;
                userpage.ShowPages(gridUserLogInfo_WellInfo, null, CSPNType.UserLogInfo_WellInfo);
            }
            else
            {
                panelUser.Controls.Clear();
                panelUser.Controls.Add(gridUserLogInfo_GeneralInfo);
                gridUserLogInfo_GeneralInfo.AutoGenerateColumns = false;
                gridUserLogInfo_GeneralInfo.DataSource = null;
                userpage.PageSize = 50;
                userpage.ShowPages(gridUserLogInfo_GeneralInfo, null, CSPNType.UserLogInfo_GeneralInfo);
            }
        }
        private void Sysgrid_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                e.ToolTipText = "取值从00到31。若为99，表示无信号。";
            }
        }
    }
}
