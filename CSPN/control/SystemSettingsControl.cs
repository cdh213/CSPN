using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                tbSysLogTime.Text = ReadWriteConfig.ReadConfig("SysLogTime");
                tbUserLogTime.Text = ReadWriteConfig.ReadConfig("UserLogTime");
                tbNotReportTimes.Text = ReadWriteConfig.ReadConfig("NotReportTimes");
                tbRefreshTime.Text = ReadWriteConfig.ReadConfig("RefreshTime");
                DeviceLoad();
                GetDeviceMsg();
                DataLoade(false, null);
                UserDataLoade(null);
            }
            else
            {
                DeviceLoad();
                tabControl1.TabPages.Remove(OperatorSet);
                tabControl1.TabPages.Remove(UserSet);
                tabControl1.TabPages.Remove(SysSetTab);
            }
            PortName.SelectedItem = ReadWriteConfig.ReadConfig("PortName");
            BaudRate.SelectedItem = ReadWriteConfig.ReadConfig("BaudRate");
        }

        #region 系统设置
        private void btnSysSet_Click(object sender, EventArgs e)
        {
            if (tbSysLogTime.Text.Trim() == "" && tbUserLogTime.Text.Trim() == "" && tbNotReportTimes.Text.Trim() == "" && tbRefreshTime.Text.Trim() == "")
            {
                MessageBox.Show("请输入内容。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (isNumber(tbSysLogTime.Text.Trim()) && isNumber(tbUserLogTime.Text.Trim()) && isNumber(tbNotReportTimes.Text.Trim()) && isNumber(tbRefreshTime.Text.Trim()))
                {
                    ReadWriteConfig.WriteConfig("SysLogTime", tbSysLogTime.Text.Trim());
                    ReadWriteConfig.WriteConfig("UserLogTime", tbUserLogTime.Text.Trim());
                    ReadWriteConfig.WriteConfig("NotReportTimes", tbNotReportTimes.Text.Trim());
                    ReadWriteConfig.WriteConfig("RefreshTime", tbRefreshTime.Text.Trim());
                    MessageBox.Show("设置成功。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("输入的值错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool isNumber(string str)
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
                MessageBox.Show("请选择串口号和波特率！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ReadWriteConfig.WriteConfig("PortName", PortName.SelectedItem.ToString());
                ReadWriteConfig.WriteConfig("BaudRate", BaudRate.SelectedItem.ToString());
                MessageBox.Show("保存成功，请重启系统!", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.GetCurrentProcess().CloseMainWindow();
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (PortName.SelectedItem == null || BaudRate.SelectedItem == null)
            {
                MessageBox.Show("请选择串口号和波特率！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("测试通过，请保存后重启系统。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        WaitWin.Close();
                        MessageBox.Show("测试未通过，请重试！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    WaitWin.Close();
                    MessageBox.Show("测试未通过，请重试！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        //加载
        private void UserDataLoade(string info)
        {
            userinfo = userService.GetUsersByUserName(CommonClass.UserName);

            txtWorkID.Text = userinfo.Work_ID.Trim();
            txtusername.Text = userinfo.UserName.Trim();
            txtRealName.Text = userinfo.RealName.Trim();
            txtTelephone.Text = userinfo.Telephone.Trim();
            string gender = userinfo.Gender.Trim();
            if (gender == "男")
            {
                comGender.SelectedIndex = 0;
            }
            if (gender == "女")
            {
                comGender.SelectedIndex = 1;
            }
            txtlogintime.Text = userinfo.LoginTime;
        }
        //修改信息
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (btnedit.Text == "修改信息")
            {
                txtRealName.ReadOnly = false;
                txtTelephone.ReadOnly = false;
                comGender.Enabled = true;
                btnedit.Text = "确定";
            }
            else
            {
                userinfo.Work_ID = txtWorkID.Text.Trim();
                userinfo.RealName = txtRealName.Text.Trim();
                userinfo.Telephone = txtTelephone.Text.Trim();
                userinfo.Gender = comGender.Text.Trim();
                if (userservice.UpdateUsersInfo(userinfo) > 0)
                {
                    MessageBox.Show("修改成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("修改失败，请重试！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnedit.Text = "修改信息";
                txtRealName.ReadOnly = true;
                txtTelephone.ReadOnly = true;
                comGender.Enabled = false;
            }
        }
        #endregion

        #region 值班人员
        IUsersService userService = new UsersService();
        UsersInfo user = new UsersInfo();
        OperatorInfo operatorInfo = new OperatorInfo();
        
        //添加值班人员
        private void btnAdd_Click(object sender, EventArgs e)
        {
            new EditUserInfoForm(true, null).ShowDialog();
            DataLoade(false, null);
        }
        //修改值班人员
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (usergrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            work_ID = usergrid.CurrentRow.Cells[0].Value.ToString();
            new EditUserInfoForm(false, work_ID).ShowDialog();
            DataLoade(false, null);
            WebBrower.Reload();
        }
        //删除值班人员
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (usergrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择数据！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("是否删除？", "人井监控管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                work_ID = usergrid.CurrentRow.Cells[0].Value.ToString();
                if (userservice.DeleteOperatorInfo(work_ID) > 0)
                {
                    MessageBox.Show("数据删除成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("数据删除失败！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DataLoade(false, null);
            }
        }
        //刷新值班人员
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataLoade(false, null);
        }
        //值班人员信息导入
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
                DataLoade(false, null);
            }
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("导入成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //加载值班人员信息
        private void DataLoade(bool strWhere, string info)
        {
            //值班人员
            usergrid.AutoGenerateColumns = false;
            usergrid.DataSource = null;
            page.PageSize = 50;
            page.ShowPages(usergrid, info, CSPNType.OperatorInfo);
        }
        #endregion
    }
}
