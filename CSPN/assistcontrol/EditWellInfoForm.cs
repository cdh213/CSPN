using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.Model;
using System;
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
    public partial class EditWellInfoForm : Form
    {
        IWellInfoService wellInfoService = new WellInfoService();
        IWellStateService wellStateService = new WellStateService();
        IUsersService userService = new UsersService();
        UserLogHelper userLogHelper = new UserLogHelper();

        WellInfo wellInfo = new WellInfo();
        WellCurrentStateInfo wellCurrentStateInfo = new WellCurrentStateInfo();
        bool _isInsert = false;
        bool _isaddMaker = false;
        string _menuPositon = null;
        string terminal_ID = null;
        public DialogResult result = DialogResult.Cancel;

        /// <summary>
        /// EditWellInfoForm
        /// </summary>
        /// <param name="terminal_ID">人井编号</param>
        /// <param name="isInsert">是否是添加</param>
        /// <param name="isaddMaker">是否是在地图上添加</param>
        /// <param name="menuPositon">在地图上添加时经纬度</param>
        public EditWellInfoForm(string terminal_ID, bool isInsert, bool isaddMaker, string menuPositon)
        {
            InitializeComponent();
            wellInfo.Terminal_ID = terminal_ID;
            _isInsert = isInsert;
            _isaddMaker = isaddMaker;
            _menuPositon = menuPositon;
        }

        private void EditInfoForm_Load(object sender, EventArgs e)
        {
            cbState.DataSource = wellStateService.GetWellStateInfo();
            cbOperator.DataSource = userService.GetOperator();
            if (_isInsert)
            {
                if (_isaddMaker)
                {
                    txtLongitude.Text = _menuPositon.Split(',')[0];
                    txtLatitude.Text = _menuPositon.Split(',')[1];
                }
                this.Text = "添加数据";
                this.Icon = new Icon("resource/images/add.ico");
            }
            else
            {
                this.Text = "更新数据";
                this.Icon = new Icon("resource/images/update.ico");

                wellInfo = wellInfoService.GetWellInfoByTerminal_ID(wellInfo.Terminal_ID);

                txtTerminal_ID.Text = wellInfo.Terminal_ID;
                txtName.Text = wellInfo.Name;
                txtLongitude.Text = wellInfo.Longitude;
                txtLatitude.Text = wellInfo.Latitude;
                txtPlace.Text = wellInfo.Place;
                txtTerminal_Phone.Text = wellInfo.Terminal_Phone;
                cbState.Text = wellInfo.WellStateInfo.State;
                cbOperator.Text = wellInfo.OperatorInfo.RealName;
            }
        }
        public string GetTerminal_ID()
        {
            return terminal_ID;
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtTerminal_ID.Text.Trim() == "")
            {
                MessageBox.Show("请填写人井编号。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtLongitude.Text.Trim() == "" && txtLatitude.Text.Trim() == "")
            {
                MessageBox.Show("请填写经度纬度。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTerminal_Phone.Text.Trim() == "")
            {
                MessageBox.Show("请填写终端手机号。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbOperator.SelectedIndex == -1)
            {
                MessageBox.Show("请选择值班人员。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            result = DialogResult.OK;
            terminal_ID = wellInfo.Terminal_ID = txtTerminal_ID.Text.Trim();
            wellInfo.Name = txtName.Text.Trim();
            wellInfo.Longitude = txtLongitude.Text.Trim();
            wellInfo.Latitude = txtLatitude.Text.Trim();
            wellInfo.Place = txtPlace.Text.Trim();
            wellInfo.Terminal_Phone = txtTerminal_Phone.Text.Trim();
            wellInfo.Operator_ID = (int)cbOperator.SelectedValue;

            if (_isInsert)
            {
                if (wellInfoService.GetWellInfoByTerminal_ID(txtTerminal_ID.Text.Trim()) == null && wellInfoService.GetWellInfoByPhone(txtTerminal_Phone.Text.Trim()) == null)
                {
                    wellInfoService.InsertWellInfo(wellInfo);
                    wellStateService.InsertWellCurrentStateInfo(wellInfo.Terminal_ID, (int)cbState.SelectedValue);
                    wellInfoService.InsertReportNumInfo(wellInfo.Terminal_ID);

                    userLogHelper.InsertUserLog(DateTime.Now.ToString(), "添加人井。", CommonClass.UserName, null, null);
                }
                else
                {
                    MessageBox.Show("当前人井已存在。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                wellInfoService.UpdateWellInfo(wellInfo);
                wellStateService.UpdateWellCurrentStateInfo((int)cbState.SelectedValue, wellInfo.Terminal_ID);

                userLogHelper.InsertUserLog(DateTime.Now.ToString(), "更新人井信息。", CommonClass.UserName, null, null);
            }
            MessageBox.Show(this.Text + "成功！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
