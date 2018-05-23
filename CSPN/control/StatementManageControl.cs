using CSPN.assistcontrol;
using CSPN.common;
using System;
using System.Windows.Forms;

namespace CSPN.control
{
    public partial class StatementManageControl : UserControl
    {
        public StatementManageControl()
        {
            InitializeComponent();
            WellGridInitializeComponent();
        }

        //将系统日志导出数据库
        private void btnSysOut_Click(object sender, EventArgs e)
        {
            new ExportLogInfoSetForm(CSPNType.SysLogInfo).ShowDialog(this);
        }

        //用户日志-人井日志
        private void btnUserWellInfoOut_Click(object sender, EventArgs e)
        {
            new ExportLogInfoSetForm(CSPNType.UserLogInfo_WellInfo).ShowDialog(this);
        }

        //用户日志-一般日志
        private void btnUserGeneralInfoOut_Click(object sender, EventArgs e)
        {
            new ExportLogInfoSetForm(CSPNType.UserLogInfo_GeneralInfo).ShowDialog(this);
        }
    }
}