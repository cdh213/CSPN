using CSPN.assistcontrol;
using CSPN.BLL;
using CSPN.common;
using CSPN.IBLL;
using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CSPN
{
    public partial class LoginForm : Form
    {
        private IUsersService userService = new UsersService();
        private UsersInfo usersInfo = new UsersInfo();
        private ReadWriteData readWriteData = new ReadWriteData();
        private Dictionary<string, UsersInfo> users = new Dictionary<string, UsersInfo>();

        public string userName { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (ReadWriteRegistry.ReadRegistry("isInvalid") == null)
            {
                ReadWriteRegistry.WriteRegistry("isInvalid", "false");
            }
            users = readWriteData.ReadData();
            //循环添加到Combox
            foreach (UsersInfo userInfo in users.Values)
            {
                cbUserName.Items.Add(userInfo.UserName);
            }
            //用户名默认选中第一个
            if (cbUserName.Items.Count > 0)
            {
                cbUserName.SelectedIndex = 0;
                txtPWD.Text = users[cbUserName.SelectedItem.ToString().Trim()].PassWord;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbUserName.Text.Trim() != null && txtPWD.Text.Trim() != "")
            {
                usersInfo = userService.GetUsersByUserName(cbUserName.Text.Trim());
                if (usersInfo != null)
                {
                    if (usersInfo.PassWord.Trim() == txtPWD.Text.Trim() || usersInfo.PassWord.Trim() == SysFunction.GetSecurit(txtPWD.Text.Trim() + "CSPN" + cbUserName.Text.Trim()))
                    {
                        UMessageBox.Show("登录成功。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (cbRemember.Checked)
                        {
                            readWriteData.WriteData(usersInfo);
                        }
                        else
                        {
                            usersInfo.PassWord = "";
                            readWriteData.WriteData(usersInfo);
                        }
                        userName = usersInfo.UserName;
                        userService.UpdateLoginTimeByWork_ID(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), usersInfo.Work_ID);
                        Close();
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        UMessageBox.Show("密码错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    UMessageBox.Show("用户名错误。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                UMessageBox.Show("请输入用户名或密码。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lbLostPWD_Click(object sender, EventArgs e)
        {
        }

        private void txtPWD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                btnLogin_Click(sender, e);//触发button事件
            }
        }

        private void cbUserName_DropDownClosed(object sender, EventArgs e)
        {
            if (cbUserName.Items.Count != 0)
            {
                txtPWD.Text = users[cbUserName.SelectedItem.ToString().Trim()].PassWord;
            }
        }

        private void lbForgotPWD_Click(object sender, EventArgs e)
        {
            new ForgotPWD("").ShowDialog(this);
        }
    }
}