using CSPN.BLL;
using CSPN.common;
using CSPN.IBLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class DataGridPage : UserControl
    {
        private IWellInfoService wellInfoService = new WellInfoService();
        private IWellStateService wellStateService = new WellStateService();
        private ILogService logservice = new LogService();
        private IUsersService userservice = new UsersService();
        private DataTable table = new DataTable();
        private DataGridView _grid = new DataGridView();
        private string _info = null;
        private CSPNType _type;

        public DataGridPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public void ShowPages(DataGridView grid, string info, CSPNType type)
        {
            _grid = grid;
            _info = info;
            _type = type;
            ReadDataTable();
        }

        /// <summary>
        /// 得到数据
        /// </summary>
        public void ReadDataTable()
        {
            switch (_type)
            {
                case CSPNType.WellInfo:
                    table = wellInfoService.GetWellInfo_Table(_info, pageSize, pageIndex, out recorderCount);
                    break;

                case CSPNType.SysLogInfo:
                    table = logservice.GetSystemLogInfo(pageSize, pageIndex, out recorderCount);
                    break;

                case CSPNType.UserLogInfo_WellInfo:
                    table = logservice.GetUserLogInfo_WellInfo(pageSize, pageIndex, out recorderCount);
                    break;

                case CSPNType.UserLogInfo_GeneralInfo:
                    table = logservice.GetUserLogInfo_GeneralInfo(pageSize, pageIndex, out recorderCount);
                    break;

                case CSPNType.MaintainInfo:
                    table = wellStateService.GetMaintainInfo(pageSize, pageIndex, out recorderCount);
                    break;

                case CSPNType.OperatorInfo:
                    table = userservice.GetOperator_Table(pageSize, pageIndex, out recorderCount);
                    break;

                case CSPNType.UserInfo:
                    table = userservice.GetUserInfo_Table(pageSize, pageIndex, out recorderCount);
                    break;
            }
            //--控制
            lbPageSize.Text = "每页" + pageSize.ToString() + "条";
            lbPageCount.Text = "/共" + PageCount.ToString() + "页";
            tbPageIndex.Text = pageIndex.ToString();
            btnLast.Tag = PageCount;

            if (PageCount > 1 && PageCount > pageIndex)
            {
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }

            if (pageIndex > 1 && pageIndex <= PageCount)
            {
                btnFirst.Enabled = true;
                btnPrev.Enabled = true;
            }
            else
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
            }
            _grid.DataSource = table;
            table.Dispose();
        }

        /// <summary>
        /// 第一页
        /// </summary>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            ReadDataTable();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            pageIndex--;
            ReadDataTable();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e)
        {
            pageIndex++;
            ReadDataTable();
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast_Click(object sender, EventArgs e)
        {
            pageIndex = (int)btnLast.Tag;
            ReadDataTable();
        }

        /// <summary>
        /// 确定导航
        /// </summary>
        private void btnGo_Click(object sender, EventArgs e)
        {
            pageIndex = int.Parse(tbPageIndex.Text.ToString());
            ReadDataTable();
        }

        /// <summary>
        /// 当前页，默认第一页
        /// </summary>
        private int pageIndex = 1;

        /// <summary>
        /// 页大小，默认50条目
        /// </summary>
        private int pageSize = 50;

        /// <summary>
        /// 总共页
        /// </summary>
        private int pageCount;

        /// <summary>
        /// 总共条目
        /// </summary>
        private int recorderCount = 0;

        /// <summary>
        /// 页大小，默认50条目
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// 总共页
        /// </summary>
        private int PageCount
        {
            get
            {
                return recorderCount % pageSize > 0 ?
                    (recorderCount / pageSize) + 1 :
                    (recorderCount / pageSize);
            }
            set { pageCount = value; }
        }
    }
}