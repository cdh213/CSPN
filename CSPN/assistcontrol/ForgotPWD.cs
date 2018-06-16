using CSPN.BLL;
using CSPN.common;
using CSPN.IBLL;
using CSPN.Model;
using System;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class ForgotPWD : Form
    {
        private IUsersService usersService = new UsersService();
        private UsersInfo usersInfo = new UsersInfo();

        public ForgotPWD(string work_ID)
        {
            InitializeComponent();
            if (work_ID != "")
            {
                tbWork_ID.Enabled = false;
            }
            tbWork_ID.Text = work_ID;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (tbWork_ID.Text.Trim() != "" && tbPWD.Text.Trim() != "" && tbRePWD.Text.Trim() != "")
            {
                if (tbPWD.Text.Trim() == tbRePWD.Text.Trim())
                {
                    usersInfo = usersService.GetUsersByWork_ID(tbWork_ID.Text.Trim());
                    if (usersInfo != null)
                    {
                        usersService.UpdatePassWordByWork_ID(SysFunction.GetSecurit(tbPWD.Text.Trim() + "CSPN" + usersInfo.UserName), tbWork_ID.Text.Trim());
                        UMessageBox.Show("修改成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        UMessageBox.Show("当前账号不存在！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    UMessageBox.Show("两次密码输入不一致，请重新输入！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                UMessageBox.Show("请输入工号和密码！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}