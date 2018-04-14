using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using CSPN.common;
using CSPN.IBLL;
using CSPN.BLL;
using CSPN.Model;
using CSPN.assistcontrol;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using CSPN.sms;
using CSPN.webbrower;
using System.Text.RegularExpressions;

namespace CSPN.control
{
    public partial class SystemSettingsControl : UserControl
    {
        IUsersService userservice = new UsersService();
        UsersInfo userinfo = new UsersInfo();

        public bool isOpen { get; set; }
        string work_ID;

        public SystemSettingsControl()
        {
            InitializeComponent();
        }
        private void SystemSettingsControl_Load(object sender, EventArgs e)
        {
            if (isOpen)
            {
                tbSysLogTime.Text = ReadWriteXml.ReadXml("SysLogTime");
                tbUserLogTime.Text = ReadWriteXml.ReadXml("UserLogTime");
                tbNotReportTimes.Text = ReadWriteXml.ReadXml("NotReportTimes");
                tbRefreshTime.Text = ReadWriteXml.ReadXml("RefreshTime");
                cbEnabled.Checked = Convert.ToBoolean(ReadWriteXml.ReadXml("ReportInterval").Split('-')[0]);
                tbReportInterval.Text = ReadWriteXml.ReadXml("ReportInterval").Split('-')[1];
                DeviceLoad();
                GetDeviceMsg();
            }
            else
            {
                DeviceLoad();
                tabControl1.TabPages.Remove(OperatorSet);
                tabControl1.TabPages.Remove(UserSet);
                tabControl1.TabPages.Remove(SysSetTab);
            }
            PortName.SelectedItem = ReadWriteXml.ReadXml("PortName");
            BaudRate.SelectedItem = ReadWriteXml.ReadXml("BaudRate");
        }

        #region 系统设置
        private void btnSysSet_Click(object sender, EventArgs e)
        {
            if (tbSysLogTime.Text.Trim() == "" && tbUserLogTime.Text.Trim() == "" && tbNotReportTimes.Text.Trim() == "" && tbRefreshTime.Text.Trim() == "" && tbReportInterval.Text.Trim() == "")
            {
                UMessageBox.Show("请输入内容。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (IsNumber(tbSysLogTime.Text.Trim()) && IsNumber(tbUserLogTime.Text.Trim()) && IsNumber(tbNotReportTimes.Text.Trim()) && IsNumber(tbRefreshTime.Text.Trim()) && IsNumber(tbReportInterval.Text.Trim()))
                {
                    ReadWriteXml.WriteXml("SysLogTime", tbSysLogTime.Text.Trim());
                    ReadWriteXml.WriteXml("UserLogTime", tbUserLogTime.Text.Trim());
                    ReadWriteXml.WriteXml("NotReportTimes", tbNotReportTimes.Text.Trim());
                    ReadWriteXml.WriteXml("RefreshTime", tbRefreshTime.Text.Trim());
                    ReadWriteXml.WriteXml("ReportInterval", cbEnabled.Checked.ToString() + "-" + tbReportInterval.Text.Trim());
                    UMessageBox.Show("设置成功。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UMessageBox.Show("输入的值错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnabled.Checked)
            {
                lbReportInterval.Enabled = true;
                tbReportInterval.Enabled = true;
            }
            else
            {
                lbReportInterval.Enabled = false;
                tbReportInterval.Enabled = false;
            }
        }
        private bool IsNumber(string str)
        {
            if ((Regex.IsMatch(str, "^[1-9]*[1-9][0-9]*$")))
                return true;
            else
                return false;
        }
        #endregion

        #region 短信猫相关设置
        private void DeviceLoad()
        {
            PortName.DataSource = SerialPort.GetPortNames();
        }
        private void btnSet_Click(object sender, EventArgs e)
        {
            if (PortName.SelectedItem == null || BaudRate.SelectedItem == null)
            {
                UMessageBox.Show("请选择串口号和波特率！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ReadWriteXml.WriteXml("PortName", PortName.SelectedItem.ToString());
                ReadWriteXml.WriteXml("BaudRate", BaudRate.SelectedItem.ToString());
                UMessageBox.Show("保存成功，请重启系统!", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.GetCurrentProcess().CloseMainWindow();
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (PortName.SelectedItem == null || BaudRate.SelectedItem == null)
            {
                UMessageBox.Show("请选择串口号和波特率！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                WaitWin.Show(this, "正在测试，请稍后。。。。。。");
                CDMASMS.Close();
                CDMASMS.Set(PortName.SelectedItem.ToString(), Convert.ToInt32(BaudRate.SelectedItem.ToString()));
                if (CDMASMS.Open())
                {
                    string TSX = CDMASMS.SendAT("AT^MEID").Replace("\r\n", "").Replace("OK", "");
                    string production_Name = CDMASMS.SendAT("AT+CGMM").Replace("\r\n", "").Replace("OK", "");
                    if (TSX.Length == 14 && production_Name.IndexOf("MC323") != -1)
                    {
                        WaitWin.Close();
                        UMessageBox.Show("测试通过，请保存后重启系统。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        WaitWin.Close();
                        UMessageBox.Show("测试未通过，请重试！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    WaitWin.Close();
                    UMessageBox.Show("测试未通过，请重试！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void GetDeviceMsg()
        {
            string content = CDMASMS.GetDeviceMsg();
            if (content != null)
            {
                string[] str = content.Split(';');
                DeviceName.Text = str[1].Replace("Manufacturer:", "");
                DeviceModel.Text = str[2].Replace("Model:", "");
                HardwareVersion.Text = str[8].Replace("^HWVER:", "");
                SoftwareVersion.Text = str[3].Replace("Revision:", "");
                CardNo.Text = str[9];
                Signal.Text = str[10].Replace("+CSQ:", "").Split(',')[0];
            }
        }
        #endregion

        #region 系统用户
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            new EditUserInfoForm(true, null).ShowDialog();
            DataLoade(CSPNType.UserInfo);
        }
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (userGrid.SelectedRows.Count == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            work_ID = userGrid.CurrentRow.Cells[0].Value.ToString();
            new EditUserInfoForm(false, work_ID).ShowDialog();
            DataLoade(CSPNType.UserInfo);
        }
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (userGrid.SelectedRows.Count == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (UMessageBox.Show("是否删除？", "人井监控管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                work_ID = userGrid.CurrentRow.Cells[0].Value.ToString();
                if (userservice.DeleteUserInfo(work_ID) > 0)
                {
                    UMessageBox.Show("数据删除成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UMessageBox.Show("数据删除失败！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DataLoade(CSPNType.UserInfo);
            }
        }
        private void btnRefreshUser_Click(object sender, EventArgs e)
        {
            DataLoade(CSPNType.UserInfo);
        }
        #endregion

        #region 值班人员
        IUsersService userService = new UsersService();
        UsersInfo user = new UsersInfo();
        OperatorInfo operatorInfo = new OperatorInfo();
        
        //添加值班人员
        private void btnAddOperator_Click(object sender, EventArgs e)
        {
            new EditOperatorInfoForm(true, null).ShowDialog();
            DataLoade(CSPNType.OperatorInfo);
        }
        //修改值班人员
        private void btnUpdateOperator_Click(object sender, EventArgs e)
        {
            if (operatorGrid.SelectedRows.Count == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            work_ID = operatorGrid.CurrentRow.Cells[0].Value.ToString();
            new EditOperatorInfoForm(false, work_ID).ShowDialog();
            DataLoade(CSPNType.OperatorInfo);
            WebBrower.Reload();
        }
        //删除值班人员
        private void btnDeleteOperator_Click(object sender, EventArgs e)
        {
            if (operatorGrid.SelectedRows.Count == 0)
            {
                UMessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (UMessageBox.Show("是否删除？", "人井监控管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                work_ID = operatorGrid.CurrentRow.Cells[0].Value.ToString();
                if (userservice.DeleteOperatorInfo(work_ID) > 0)
                {
                    UMessageBox.Show("数据删除成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UMessageBox.Show("数据删除失败！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DataLoade(CSPNType.OperatorInfo);
            }
        }
        //刷新值班人员
        private void btnRefreshOperator_Click(object sender, EventArgs e)
        {
            DataLoade(CSPNType.OperatorInfo);
        }
        //值班人员信息导入
        string path = "";
        private void btnIntoOperator_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
                this.backgroundWorker.RunWorkerAsync(); // 运行 backgroundWorker 组件
                ImportProgressBarForm form = new ImportProgressBarForm(this.backgroundWorker, this.ParentForm.Width);// 显示进度条窗体
                form.ShowDialog(this);
                DataLoade(CSPNType.OperatorInfo);
            }
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UMessageBox.Show("导入成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    operatorInfo.Work_ID = currentRow.GetCell(0) == null ? "" : currentRow.GetCell(0).ToString();
                    operatorInfo.RealName = currentRow.GetCell(1) == null ? "" : currentRow.GetCell(1).ToString();
                    operatorInfo.Gender = currentRow.GetCell(2) == null ? "" : currentRow.GetCell(2).ToString();
                    operatorInfo.Telephone = currentRow.GetCell(3) == null ? "" : currentRow.GetCell(3).ToString();
                    operatorInfo.Area = currentRow.GetCell(4) == null ? "" : currentRow.GetCell(4).ToString();
                    operatorInfo.ReceiveMsg = currentRow.GetCell(5) == null ? "" : currentRow.GetCell(5).ToString();

                    //执行sql语句
                    userService.InsertOperatorInfo(operatorInfo);
                    worker.ReportProgress(r, sheet.LastRowNum);
                }
            }
        }
        #endregion

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == UserSet)
            {
                DataLoade(CSPNType.UserInfo);
            }
            if (e.TabPage == OperatorSet)
            {
                DataLoade(CSPNType.OperatorInfo);
            }
        }
        //加载信息
        private void DataLoade(CSPNType type)
        {
            if (type == CSPNType.OperatorInfo)
            {
                //值班人员
                operatorGrid.AutoGenerateColumns = false;
                operatorGrid.DataSource = null;
                pageOperator.PageSize = 50;
                pageOperator.ShowPages(operatorGrid, null, CSPNType.OperatorInfo);
            }
            else
            {
                //用户信息
                userGrid.AutoGenerateColumns = false;
                userGrid.DataSource = null;
                pageUser.PageSize = 50;
                pageUser.ShowPages(userGrid, null, CSPNType.UserInfo);
            } 
        }
    }
}
