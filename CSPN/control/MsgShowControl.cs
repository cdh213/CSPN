using CefSharp;
using CSPN.assistcontrol;
using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.job;
using CSPN.Model;
using CSPN.webbrower;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace CSPN.control
{
    public partial class MsgShowControl : UserControl
    {
        private IWellInfoService wellInfoService = new WellInfoService();
        private IWellStateService wellStateService = new WellStateService();
        private WellInfo well = new WellInfo();
        private WellStateInfo stateInfo = new WellStateInfo();
        private OperatorInfo operatorInfo = new OperatorInfo();
        private IUsersService user = new UsersService();
        private List<int> infoList = new List<int>();
        private string terminal_ID;

        public MsgShowControl()
        {
            InitializeComponent();
            WebBrower.webBrower.Dock = DockStyle.Fill;
            TabPagemap.Controls.Add(WebBrower.webBrower);
            RefreshWellInfoJob.refreshDelegate += new RefreshDelegate(RefreshInfo);
        }

        private void MsgShowControl_Load(object sender, EventArgs e)
        {
            DataLoade(null);
        }

        #region 列表显示

        //查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataLoade(txtCondition.Text);
        }

        //添加
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditWellInfoForm ef = new EditWellInfoForm(null, true, false, null);
            ef.ShowDialog();
            if (ef.DialogResult == DialogResult.OK)
            {
                List<WellInfo> list = wellInfoService.GetWellInfo_List(ef.GetTerminal_ID());
                string json = JsonConvert.SerializeObject(list);
                WebBrower.webBrower.ExecuteScriptAsync("addMaker", json);
            }
            DataLoade(null);
        }

        //编辑
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            infoList.Clear();
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                //判断该行的复选框是否存在
                if (grid.Rows[i].Cells[0].Value != null)
                {
                    //判断该复选框是否被选中
                    if (Convert.ToBoolean(grid.Rows[i].Cells[0].Value))
                    {
                        infoList.Add(i);
                    }
                }
            }
            if (infoList.Count == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (infoList.Count > 1)
            {
                UMessageBox.Show("请选择一项！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                terminal_ID = grid.Rows[infoList[0]].Cells[1].Value.ToString();
                new EditWellInfoForm(terminal_ID, false, false, null).ShowDialog();
                List<WellInfo> list = wellInfoService.GetWellInfo_List(terminal_ID);
                string json = JsonConvert.SerializeObject(list);
                WebBrower.webBrower.ExecuteScriptAsync("updateMarker", json);
                DataLoade(null);
            }
        }

        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            infoList.Clear();
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                //判断该行的复选框是否存在
                if (grid.Rows[i].Cells[0].Value != null)
                {
                    //判断该复选框是否被选中
                    if (Convert.ToBoolean(grid.Rows[i].Cells[0].Value))
                    {
                        infoList.Add(i);
                    }
                }
            }
            if (infoList.Count == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (UMessageBox.Show("是否删除？", "人井监控管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 0; i < infoList.Count; i++)
                    {
                        terminal_ID = grid.Rows[infoList[i]].Cells[1].Value.ToString();
                        wellInfoService.DeleteWellInfo(terminal_ID);
                        wellInfoService.DeleteReportInfo(terminal_ID);
                        wellStateService.DeleteWellCurrentStateInfo(terminal_ID);
                        wellStateService.DeleteWellMaintainInfo(terminal_ID);
                    }
                    UMessageBox.Show("数据删除成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    WebBrower.Reload();
                    DataLoade(null);
                }
            }
        }

        //信息导入
        private string path = "";

        private void btnInto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                this.backgroundWorker.RunWorkerAsync(); // 运行 backgroundWorker 组件
                ImportProgressBarForm form = new ImportProgressBarForm(this.backgroundWorker, this.ParentForm.Width);// 显示进度条窗体
                form.ShowDialog(this);
                DataLoade(null);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UMessageBox.Show("导入成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            WebBrower.Reload();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //从Excel中读取数据
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = null;  //新建IWorkbook对象
                if (path.IndexOf(".xlsx") > 0) // 2007版本
                {
                    workbook = new XSSFWorkbook(fileStream);  //xlsx数据读入workbook
                }
                else if (path.IndexOf(".xls") > 0) // 2003版本
                {
                    workbook = new HSSFWorkbook(fileStream);  //xls数据读入workbook
                }
                //获取wk中的sheet
                ISheet sheet = workbook.GetSheetAt(0);
                IRow currentRow;  //新建当前工作表行数据
                List<ICell> listCells = new List<ICell>(); //list中保存当前行的所有的单元格内容
                //遍历说有行
                for (int r = 1; r <= sheet.LastRowNum; r++)
                {
                    //获取每一行
                    currentRow = sheet.GetRow(r);

                    well.Terminal_ID = currentRow.GetCell(0) == null ? "" : currentRow.GetCell(0).ToString();
                    well.Name = currentRow.GetCell(1) == null ? "" : currentRow.GetCell(1).ToString();
                    well.Terminal_Phone = currentRow.GetCell(2) == null ? "" : currentRow.GetCell(2).ToString();
                    well.Longitude = currentRow.GetCell(3) == null ? "" : currentRow.GetCell(3).ToString();
                    well.Latitude = currentRow.GetCell(4) == null ? "" : currentRow.GetCell(4).ToString();
                    well.Place = currentRow.GetCell(5) == null ? "" : currentRow.GetCell(5).ToString();
                    operatorInfo.Work_ID = currentRow.GetCell(6).ToString();
                    well.Operator_ID = user.GetOperatorByWork_ID(operatorInfo.Work_ID).ID;

                    //执行sql语句
                    wellInfoService.InsertWellInfo(well);
                    wellInfoService.InsertReportInfo(well.Terminal_ID, 3);
                    wellStateService.InsertWellCurrentStateInfo(well.Terminal_ID, 1);
                    wellStateService.InsertMaintainInfo(well.Terminal_ID, 0);
                    worker.ReportProgress(r, sheet.LastRowNum);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataLoade(null);
        }

        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grid.Columns[e.ColumnIndex].Name.Equals("Icon"))
            {
                e.Value = ImageHelper.ToImage(e.Value.ToString());
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == TabPagelist)
            {
                DataLoade(null);
            }
        }

        private void grid_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                e.ToolTipText = "取值从00到31。若为99，表示无信号。";
            }
        }

        //自动刷新
        private void RefreshInfo()
        {
            if (grid.InvokeRequired)
            {
                grid.Invoke(new RefreshDelegate(RefreshInfo));
            }
            else
            {
                DataLoade(null);
            }
        }

        //加载
        private void DataLoade(string wellInfo)
        {
            grid.AutoGenerateColumns = false;
            grid.DataSource = null;
            page.PageSize = 50;
            page.ShowPages(grid, wellInfo, CSPNType.WellInfo);
        }

        #endregion 列表显示
    }
}