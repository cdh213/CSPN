using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSPN.helper;
using CSPN.common;

namespace CSPN.control
{
    public partial class AppointmentControl : UserControl
    {
        QuartzHelper quartz = new QuartzHelper();

        public static string ID;
        public static string state;
        public static int MRowIndex;

        public string year;
        public string month;
        public string day;
        public string hour;
        public string minute;
        public string second;

        public AppointmentControl()
        {
            InitializeComponent();
        }

        private void AppointmentControl_Load(object sender, EventArgs e)
        {
            DataLoade(false, null);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            year = dateTimePicker1.Value.Year.ToString();
            month = dateTimePicker1.Value.Month.ToString();
            day = dateTimePicker1.Value.Day.ToString();

            hour = dateTimePicker2.Value.Hour.ToString();
            minute = dateTimePicker2.Value.Minute.ToString();
            second = dateTimePicker2.Value.Second.ToString();
            ID = txtID.Text;
            state = comState.Text;
            //quartz.init(typeof(Maintenance), year, month, day, hour, minute, second);
            MessageBox.Show("设定完成！");
        }

        private void appointmentGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txtID.Text = appointmentGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                comState.Text = appointmentGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                MRowIndex = e.RowIndex;
            }
        }

        //加载系统维护信息
        public void DataLoade(bool strWhere, string info)
        {
            appointmentGrid.AutoGenerateColumns = false;
            appointmentGrid.DataSource = null;
            appointmentPage.PageSize = 50;
            appointmentPage.ShowPages(appointmentGrid, null, CSPNType.AppointmentInfo);
        }
    }
}
