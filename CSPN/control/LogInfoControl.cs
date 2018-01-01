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

namespace CSPN.control
{
    public partial class LogInfoControl : UserControl
    {
        public LogInfoControl()
        {
            InitializeComponent();
            InitializeUserLogInfo_WellInfo();
            InitializeUserLogInfo_GeneralInfo();
        }

        private void LogInfoControl_Load(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
            DataLoade(false, null);
        }

        private void cbType_DropDownClosed(object sender, EventArgs e)
        {
            //用户日志
            if (cbType.SelectedIndex == 0)
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(gridUserLogInfo_WellInfo);
                gridUserLogInfo_WellInfo.AutoGenerateColumns = false;
                gridUserLogInfo_WellInfo.DataSource = null;
                userpage.PageSize = 50;
                userpage.ShowPages(gridUserLogInfo_WellInfo, null, ShowPagesType.UserLogInfo_WellInfo);
            }
            else
            {
                panel1.Controls.Clear();
                panel1.Controls.Add(gridUserLogInfo_GeneralInfo);
                gridUserLogInfo_GeneralInfo.AutoGenerateColumns = false;
                gridUserLogInfo_GeneralInfo.DataSource = null;
                userpage.PageSize = 50;
                userpage.ShowPages(gridUserLogInfo_GeneralInfo, null, ShowPagesType.UserLogInfo_GeneralInfo);
            }
        }
        //将系统日志导出数据库
        private void btnSysOut_Click(object sender, EventArgs e)
        {
            WaitWin.Show(this, "正在导出，请稍后。。。。。。");
            ExcelHelper ex = new ExcelHelper();
            ex.setExcel(Sysgrid);
            WaitWin.Close();
        }
        //将用户日志导出数据库
        private void btnUserOut_Click(object sender, EventArgs e)
        {
            WaitWin.Show(this, "正在导出，请稍后。。。。。。");
            ExcelHelper ex = new ExcelHelper();
            ex.setExcel((DataGridView)panel1.Controls[0]);
            WaitWin.Close();
        }
        //显示图标
        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Sysgrid.Columns[e.ColumnIndex].Name.Equals("Icon"))
            {
                e.Value = ImageHelper.ToImage(e.Value.ToString());
            }
        }
        //加载日志信息
        public void DataLoade(bool strWhere, string info)
        {
            //系统日志
            Sysgrid.AutoGenerateColumns = false;
            Sysgrid.DataSource = null;
            Syspage.PageSize = 50;
            Syspage.ShowPages(Sysgrid, info, ShowPagesType.SysLogInfo);
            //用户日志
            panel1.Controls.Clear();
            panel1.Controls.Add(gridUserLogInfo_WellInfo);
            gridUserLogInfo_WellInfo.AutoGenerateColumns = false;
            gridUserLogInfo_WellInfo.DataSource = null;
            userpage.PageSize = 50;
            userpage.ShowPages(gridUserLogInfo_WellInfo, null, ShowPagesType.UserLogInfo_WellInfo);
        }
    }
}
