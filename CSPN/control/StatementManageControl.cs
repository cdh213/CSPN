using CSPN.assistcontrol;
using CSPN.BLL;
using CSPN.common;
using CSPN.IBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CSPN.control
{
    public partial class StatementManageControl : UserControl
    {
        private ILogService logService = new LogService();
        private List<string> time = new List<string>();
        private List<int> num = new List<int>();
        private string str = ReadWriteXml.ReadXml("SysLogTime");

        public StatementManageControl()
        {
            InitializeComponent();
            WellGridInitializeComponent();
        }

        private void StatementManageControl_Load(object sender, EventArgs e)
        {
            using (DataTable dt = logService.GetSystemLogInfo())
            {
                dt.DefaultView.Sort = "Happen_Time ASC";
                if (dt.DefaultView.ToTable().Rows.Count != 0)
                {
                    time = dt.DefaultView.ToTable().AsEnumerable().Select(t => t.Field<DateTime>("Happen_Time").ToString("yyyy/MM/dd")).ToList().GroupBy(p => p).Select(p => p.Key).ToList();
                    for (int i = 0; i < time.Count(); i++)
                    {
                        num.Add(dt.DefaultView.ToTable().AsEnumerable().Where(x => x.Field<DateTime>("Happen_Time").ToString("yyyy/MM/dd") == time[i].ToString()).Count());
                    }
                }
                else
                {
                    for (int i = 0; i < Convert.ToInt32(str); i++)
                    {
                        time.Add(DateTime.Now.AddDays(-i).ToString("yyyy/MM/dd"));
                        num.Add(1);
                    }
                }
            }
            SetChart();
        }

        private void SetChart()
        {
            ////标题
            ct.Titles.Add("近" + time.Count + "天人井上报次数统计");
            //x轴上突出的小点
            ct.ChartAreas[0].Axes[0].MajorTickMark.Enabled = false;
            ct.ChartAreas[0].Axes[1].MajorTickMark.Enabled = false;
            //设置X轴上的值类型
            ct.Series[0].XValueType = ChartValueType.String;
            ct.Series[0].YValueType = ChartValueType.Int32;
            //设置显示X Y的值
            ct.Series[0].Label = "#VAL";
            //鼠标移动到对应点显示数值
            ct.Series[0].ToolTip = "时间：#VALX\r次数：#VAL";
            ct.Series[0].ChartArea = "ChartArea1";//设置图表背景框
            //添加数据
            ct.Series[0].Points.DataBindXY(time, num);
            //折线段配置
            ct.Series[0].Color = Color.Blue;//线条颜色
            ct.Series[0].BorderWidth = 3; //线条粗细
            ct.Series[0].MarkerBorderColor = Color.Red;//标记点边框颜色
            ct.Series[0].MarkerBorderWidth = 3;//标记点边框大小
            ct.Series[0].MarkerColor = Color.Red;//标记点中心颜色
            ct.Series[0].MarkerSize = 5;//标记点大小
            ct.Series[0].MarkerStyle = MarkerStyle.Circle;//标记点类型
        }

        //将系统日志导出数据库
        private void btnSysOut_Click(object sender, EventArgs e)
        {
            new ExportLogInfoSetForm(CSPNType.SysLogInfo).ShowDialog(this);
        }

        //用户日志-人井日志
        private void btnUserWellInfoOut_Click(object sender, EventArgs e)
        {
            new ExportLogInfoSetForm(CSPNType.UserLogInfo_WellInfo).ShowDialog(this);
        }

        //用户日志-一般日志
        private void btnUserGeneralInfoOut_Click(object sender, EventArgs e)
        {
            new ExportLogInfoSetForm(CSPNType.UserLogInfo_GeneralInfo).ShowDialog(this);
        }
    }
}