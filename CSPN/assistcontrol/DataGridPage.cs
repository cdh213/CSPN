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
using CSPN.common;

namespace CSPN.assistcontrol
{
    public partial class DataGridPage : UserControl
    {
        IWellInfoService wellInfoService = new WellInfoService();
        IWellStateService wellStateService = new WellStateService();
        ILogService logservice = new LogService();
        IUsersService userservice = new UsersService();
        DataTable table = new DataTable();
        DataGridView _grid = new DataGridView();
        string _info = null;
        CSPNType _type;

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
        #region Access分页
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void ReadDataTable()
        {
            switch (_type)
            {
                case CSPNType.WellInfo:
                    table = wellInfoService.GetWellInfo_Table(_info);
                    break;
                case CSPNType.OperatorInfo:
                    table = userservice.GetOperator_Table();
                    break;
                case CSPNType.SysLogInfo:
                    table = logservice.GetSystemLogInfo();
                    break;
                case CSPNType.UserLogInfo_WellInfo:
                    table = logservice.GetUserLogInfo_WellInfo();
                    break;
                case CSPNType.UserLogInfo_GeneralInfo:
                    table = logservice.GetUserLogInfo_GeneralInfo();
                    break;
                case CSPNType.AppointmentInfo:
                    table = wellStateService.GetAppointmentInfo();
                    break;
            }
            //多少页
            MaxIndex = table.Rows.Count / pageSize + 1;
            tbPageIndex.Text = PageIndex.ToString();
            lbPageCount.Text = "/共" + MaxIndex + "页";
            lbPageSize.Text = "每页" + PageSize.ToString() + "条";
            DataTable tmpTable = new DataTable();
            tmpTable = this.table.Clone();
            int first = this.PageSize * (this.PageIndex - 1);
            first = (first > 0) ? first : 0;
            //如何总数量大于每页显示数量
            if (this.table.Rows.Count >= this.PageSize * this.PageIndex)
            {
                for (int i = first; i < PageSize * this.PageIndex; i++)
                    tmpTable.ImportRow(this.table.Rows[i]);
            }
            else
            {
                for (int i = first; i < this.table.Rows.Count; i++)
                    tmpTable.ImportRow(this.table.Rows[i]);
            }
            this._grid.DataSource = tmpTable;
            table.Clear();
            tmpTable.Dispose();
            table.Dispose();
            DisplayPagingInfo();
        }

        /// <summary>
        /// 每页显示等数据
        /// </summary>
        private void DisplayPagingInfo()
        {
            if (this.PageIndex == 1)
            {
                this.btnPrev.Enabled = false;
                this.btnFirst.Enabled = false;
            }
            else
            {
                this.btnPrev.Enabled = true;
                this.btnFirst.Enabled = true;
            }
            if (this.PageIndex == this.MaxIndex)
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
            else
            {
                this.btnNext.Enabled = true;
                this.btnLast.Enabled = true;
            }
            lbPageCount.Text = "/共" + MaxIndex + "页";
            int first = (this.PageIndex - 4) > 0 ? (this.PageIndex - 4) : 1;
            int last = (first + 9) > this.MaxIndex ? this.MaxIndex : (first + 9);
        }
        #endregion

        #region 其他分页
        ///// <summary>
        ///// 得到数据
        ///// </summary>
        //public void Bind()
        //{
        //    table = wellInfoService.GetWellInfo(PageSize, PageIndex, _strWhere, _wellInfo, out recorderCount);
        //    //--控制
        //    lbPageSize.Text = "每页" + PageSize.ToString() + "条";
        //    lbPageCount.Text = "/共" + PageCount.ToString() + "页";
        //    tbPageIndex.Text = PageIndex.ToString();

        //    if (PageCount > 1 && PageCount > PageIndex)
        //    {
        //        btnNext.Enabled = true;
        //        btnLast.Enabled = true;
        //    }
        //    else
        //    {
        //        btnNext.Enabled = false;
        //        btnLast.Enabled = false;
        //    }

        //    if (PageIndex > 1 && PageIndex <= PageCount)
        //    {
        //        btnFirst.Enabled = true;
        //        btnPrev.Enabled = true;
        //    }
        //    else
        //    {
        //        btnFirst.Enabled = false;
        //        btnPrev.Enabled = false;
        //    }
        //    _grid.DataSource = table;
        //    table.Dispose();
        //}
        #endregion

        /// <summary>
        /// 第一页
        /// </summary>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
            ReadDataTable();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            PageIndex--;
            ReadDataTable();
        }
        /// <summary>
        /// 下一页
        /// </summary>
        private void btnNext_Click(object sender, EventArgs e)
        {
            PageIndex++;
            ReadDataTable();
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast_Click(object sender, EventArgs e)
        {
            PageIndex = MaxIndex;
            ReadDataTable();
        }
        /// <summary>
        /// 确定导航
        /// </summary>
        private void btnGo_Click(object sender, EventArgs e)
        {
            PageIndex = int.Parse(tbPageIndex.Text.ToString());
            ReadDataTable();
        }

        private int pageIndex = 1;    //当前页，默认第一页
        private int pageSize = 30;    //页大小，默认20条目
        private int pageCount;      //总共页
        private int recorderCount;  //总共条目
        private int MaxIndex = 1; //最大页数


        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// 总共页
        /// </summary>
        public int PageCount
        {
            get
            {
                return recorderCount % pageSize > 0 ?
                    (recorderCount / pageSize) + 1 :
                    (recorderCount / pageSize);
            }
            set { pageCount = value; }
        }

        /// <summary>
        /// 总共条目数
        /// </summary>
        public int RecorderCount
        {
            get { return recorderCount; }
            set { recorderCount = value; }
        }
    }
}
