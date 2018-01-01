using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class EditUserInfoForm : Form
    {

        IUsersService userService = new UsersService();
        OperatorInfo opInfo = new OperatorInfo();
        UserLogHelper userLogHelper = new UserLogHelper();

        bool _isInsert = false;
        string _work_ID = null;

        //编辑时将选中信息加载到窗体上
        public EditUserInfoForm(bool isInsert, string work_ID)
        {
            InitializeComponent();
            _isInsert = isInsert;
            _work_ID = work_ID;
        }
        private void EditUserInfoForm_Load(object sender, EventArgs e)
        {
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

                opInfo = userService.GetOperatorByWork_ID(_work_ID);
                txtWorkID.Text = opInfo.Work_ID.Trim();
                txtName.Text = opInfo.RealName.Trim();
                txtArea.Text = opInfo.Area.Trim();
                txtTelephone.Text = opInfo.Telephone.Trim();
                if (opInfo.Gender.Trim() == "男")
                {
                    cmbGender.SelectedIndex = 0;
                }
                else
                {
                    cmbGender.SelectedIndex = 1;
                }
                if (opInfo.ReceiveMsg.Trim() == "是")
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
            opInfo.Area = txtArea.Text.Trim();//区域    
            opInfo.Work_ID = txtWorkID.Text.Trim();//工号
            opInfo.RealName = txtName.Text.Trim();//姓名
            opInfo.Telephone = txtTelephone.Text.Trim();//联系方式
            opInfo.Gender = cmbGender.Text.Trim();//性别
            opInfo.ReceiveMsg = cmbreceive.Text.Trim();//接收消息
            //添加
            if (_isInsert)
            {
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
                if (userService.GetOperatorByWork_ID(txtWorkID.Text.Trim()) != null)
                {
                    MessageBox.Show("该值班人员已存在，请勿重复添加！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    int a = userService.InsertOperatorInfo(opInfo);
                    if (a > 0)
                    {
                        MessageBox.Show("数据添加成功！", "人井监控管理系统", MessageBoxButtons.OK);
                        userLogHelper.InsertUserLog(DateTime.Now.ToString("yyyy/MM/dd"), "添加值班人员。", CommonClass.UserName, null, null);
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
                int b = userService.UpdateOperatorInfo(opInfo);
                if (b > 0)
                {
                    MessageBox.Show("数据修改成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    userLogHelper.InsertUserLog(DateTime.Now.ToString("yyyy/MM/dd"), "更新值班人员信息。", CommonClass.UserName, null, null);
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
