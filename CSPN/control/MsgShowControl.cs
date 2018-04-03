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
using CSPN.Model;
using CefSharp;
using CSPN.common;
using CSPN.assistcontrol;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using CSPN.webbrower;
using CSPN.helper;
using Newtonsoft.Json;
using CSPN.job;
using System.Threading;
using System.Collections;

namespace CSPN.control
{
    public partial class MsgShowControl : UserControl
    {
        IWellInfoService wellInfoService = new WellInfoService();
        IWellStateService wellStateService = new WellStateService();
        WellInfo well = new WellInfo();
        WellStateInfo stateInfo = new WellStateInfo();
        OperatorInfo operatorInfo = new OperatorInfo();
        IUsersService user = new UsersService();
        string terminal_ID;

        public MsgShowControl()
        {
            InitializeComponent();
            WebBrower.webBrower.Dock = DockStyle.Fill;
            TabPagemap.Controls.Add(WebBrower.webBrower);
            RefreshWellInfoJob.refreshEventHandler += new job.RefreshEventHandler(RefreshInfo);
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
                IList<WellInfo> list = wellInfoService.GetWellInfo_List(ef.GetTerminal_ID());
                string json = JsonConvert.SerializeObject(list);
                WebBrower.webBrower.ExecuteScriptAsync("addMaker", json);
            }
            DataLoade(null);
        }
        //编辑
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int[] n = new int[grid.Rows.Count + 1];
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                //判断该行的复选框是否存在
                if (grid.Rows[i].Cells[0].Value != null)
                {
                    //判断该复选框是否被选中
                    if (Convert.ToBoolean(grid.Rows[i].Cells[0].Value))
                    {
                        n[0]++;
                        n[i + 1] = -1;
                    }
                }
            }
            if (n[0] == 0)
            {
                MessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (n[0] > 1)
            {
                MessageBox.Show("请选择一项！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                terminal_ID = grid.Rows[Array.IndexOf(n, -1) - 1].Cells[1].Value.ToString();
                new EditWellInfoForm(terminal_ID, false, false, null).ShowDialog();
                IList<WellInfo> list = wellInfoService.GetWellInfo_List(terminal_ID);
                string json = JsonConvert.SerializeObject(list);
                WebBrower.webBrower.ExecuteScriptAsync("updateMarker", json);
                DataLoade(null);
            }
        }
            
        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int[] n = new int[grid.Rows.Count + 1];
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                //判断该行的复选框是否存在
                if (grid.Rows[i].Cells[0].Value != null)
                {
                    //判断该复选框是否被选中
                    if (Convert.ToBoolean(grid.Rows[i].Cells[0].Value))
                    {
                        n[0]++;
                        n[i + 1] = i;
                    }
                }
            }
            if (n[0] == 0)
            {
                MessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("是否删除？", "人井监控管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int i = 1; i < n.Length; i++)
                    {
                        if (n[i] != 0)
                        {
                            terminal_ID = grid.Rows[n[i]].Cells[1].Value.ToString();
                            wellInfoService.DeleteWellInfo(terminal_ID);
                            wellStateService.DeleteWellCurrentStateInfo(terminal_ID);
                            wellInfoService.DeleteReportNumInfo(terminal_ID);
                        }
                    }
                    MessageBox.Show("数据删除成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    WebBrower.Reload();
                    DataLoade(null);
                }
            }
        }
        //信息导入
        string path = "";
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
            MessageBox.Show("导入成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                IList<ICell> listCells = new List<ICell>(); //list中保存当前行的所有的单元格内容
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
                    wellStateService.InsertWellCurrentStateInfo(well.Terminal_ID, 1);
                    wellInfoService.InsertReportNumInfo(well.Terminal_ID, 1);
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
                grid.Invoke(new job.RefreshEventHandler(RefreshInfo));
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
        #endregion
    }
}
