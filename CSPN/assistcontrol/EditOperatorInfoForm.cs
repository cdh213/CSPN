using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class EditOperatorInfoForm : Form
    {
        IUsersService userService = new UsersService();
        OperatorInfo operatorInfo = null;
        UserLogHelper userLogHelper = new UserLogHelper();

        bool _isInsert = false;
        string _work_ID = null;

        //编辑时将选中信息加载到窗体上
        public EditOperatorInfoForm(bool isInsert, string work_ID)
        {
            InitializeComponent();
            _isInsert = isInsert;
            _work_ID = work_ID;
        }
        private void EditUserInfoForm_Load(object sender, EventArgs e)
        {
            operatorInfo = new OperatorInfo();
            if (_isInsert == true)
            {
                this.Text = "添加数据";
                this.Icon = new Icon("resource/images/add.ico");
                btnSure.Text = "确定添加";
                cmbGender.SelectedIndex = 0;
                cmbreceive.SelectedIndex = 0;
            }
            else
            {
                this.Text = "更新数据";
                this.Icon = new Icon("resource/images/update.ico");
                btnSure.Text = "确定修改";
                txtWorkID.Enabled = false;

                operatorInfo = userService.GetOperatorByWork_ID(_work_ID);
                txtWorkID.Text = operatorInfo.Work_ID.Trim();
                txtName.Text = operatorInfo.RealName.Trim();
                txtArea.Text = operatorInfo.Area.Trim();
                txtTelephone.Text = operatorInfo.Telephone.Trim();
                if (operatorInfo.Gender.Trim() == "男")
                {
                    cmbGender.SelectedIndex = 0;
                }
                else
                {
                    cmbGender.SelectedIndex = 1;
                }
                if (operatorInfo.ReceiveMsg.Trim() == "是")
                {
                    cmbreceive.SelectedIndex = 0;
                }
                else
                {
                    cmbreceive.SelectedIndex = 1;
                }
            }
        }
        //确定添加/更新
        private void btnSure_Click(object sender, EventArgs e)
        {
            operatorInfo = new OperatorInfo()
            {
                Area = txtArea.Text.Trim(),//区域    
                Work_ID = txtWorkID.Text.Trim(),//工号
                RealName = txtName.Text.Trim(),//姓名
                Telephone = txtTelephone.Text.Trim(),//联系方式
                Gender = cmbGender.SelectedItem.ToString().Trim(),//性别
                ReceiveMsg = cmbreceive.SelectedItem.ToString().Trim(),//接收消息
            };

            if (txtWorkID.Text.Trim() == "")
            {
                MessageBox.Show("请输入值班人员工号！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("请输入值班人员姓名！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTelephone.Text.Trim() == "")
            {
                MessageBox.Show("请输入值班人员手机号！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //添加
            if (_isInsert)
            {
                if (userService.GetOperatorByWork_ID(txtWorkID.Text.Trim()) != null)
                {
                    MessageBox.Show("该值班人员已存在，请勿重复添加！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    int a = userService.InsertOperatorInfo(operatorInfo);
                    if (a > 0)
                    {
                        MessageBox.Show("数据添加成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        userLogHelper.InsertUserLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "添加值班人员。", CommonClass.UserName, null, null);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("数据添加失败！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            //更新
            else
            {
                int a = userService.UpdateOperatorInfo(operatorInfo);
                if (a > 0)
                {
                    MessageBox.Show("数据修改成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    userLogHelper.InsertUserLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "更新值班人员信息。", CommonClass.UserName, null, null);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("数据修改失败！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
