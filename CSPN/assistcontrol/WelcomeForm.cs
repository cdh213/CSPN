using CSPN.common;
using CSPN.control;
using CSPN.helper;
using CSPN.sms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        FileHelper file = new FileHelper();
        string portName = null;
        int baudRate = 0;

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            if (file.FileSize("cache") > 31457280)
            {
                file.DelectDir("cache");
            }
            //设置启动窗体
            this.timer1.Start();
            this.timer1.Interval = 2000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            //打开串口
            portName = ReadWriteConfig.ReadConfig("PortName");
            baudRate = Convert.ToInt32(ReadWriteConfig.ReadConfig("BaudRate"));
            CDMASMS.Set(portName, baudRate);
            if (CDMASMS.Open())
            {
                string TSX = CDMASMS.SendAT("AT^MEID").Replace("\r\n", "").Replace("OK", "");
                if (TSX.Length == 14)
                {
                    TSX = SysFunction.GetSecurit(TSX.Remove(3, 5));
                    if (ReadWriteConfig.ReadConfig("TSX").Equals(TSX))
                    {
                        string netstat = CDMASMS.SendAT("AT+CREG?").Replace("\r\n", "").Replace("OK", "");
                        if (netstat.Split(',')[1] == "1")
                        {
                            if (ReadWriteRegistry.ReadRegistry("isInvalid") == null)
                            {
                                ReadWriteRegistry.WriteRegistry("isInvalid", "false");
                            }
                            if (ReadWriteRegistry.ReadRegistry("isInvalid") == "true")
                            {
                                this.DialogResult = DialogResult.Cancel;
                            }
                            else
                            {
                                CDMASMS.DeviceInitialize();
                                this.DialogResult = DialogResult.OK;
                            }
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("未注册到本地网络！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CDMASMS.Close();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("硬件不匹配！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CDMASMS.Close();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("读取硬件信息失败！请确认硬件设备连接正确。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CDMASMS.Close();
                    this.Close();
                }  
            }
            else
            {
                MessageBox.Show("串口打开失败，请在系统设置中重新配置串口数据。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }

        private void WelcomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭定时器
            this.timer1.Stop();
            this.timer1.Dispose();
        }
    }
}
