using CSPN.common;
using CSPN.helper;
using CSPN.sms;
using System;
using System.Configuration;
using System.IO.Ports;
using System.Windows.Forms;

namespace CSPN.assistcontrol
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private FileHelper file = new FileHelper();
        private string tsx = ConfigurationManager.AppSettings["TSX"];

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            if (file.FileSize("cache") > 31457280)
            {
                file.DeleteDir("cache");
            }
            //设置启动窗体
            this.timer1.Start();
            this.timer1.Interval = 2000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            if (SerialPort.GetPortNames().Length != 0)
            {
                //读取配置文件
                string portName = ReadWriteXml.ReadXml("PortName");
                string baudRate = ReadWriteXml.ReadXml("BaudRate");
                CDMASMS.Set(portName, Convert.ToInt32(baudRate));
                if (CDMASMS.Open())
                {
                    string TSX = CDMASMS.SendAT("AT^MEID").Replace("\r\n", "").Replace("OK", "");
                    string production_Name = CDMASMS.SendAT("AT+CGMM").Replace("\r\n", "").Replace("OK", "");
                    if (TSX.Length == 14 && production_Name.IndexOf("MC323") != -1)
                    {
                        TSX = SysFunction.GetSecurit(TSX.Remove(3, 5));
                        if (tsx.Equals(TSX))
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
                                    this.DialogResult = DialogResult.Abort;
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
                                UMessageBox.Show("未注册到本地网络，请确认硬件设备连接正确。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                CDMASMS.Close();
                                this.Close();
                            }
                        }
                        else
                        {
                            UMessageBox.Show("硬件不匹配！", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CDMASMS.Close();
                            this.Close();
                        }
                    }
                    else
                    {
                        UMessageBox.Show("串口打开失败，请在系统设置中重新配置串口数据。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.No;
                        this.Close();
                    }
                }
                else
                {
                    UMessageBox.Show("串口打开失败，请在系统设置中重新配置串口数据。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;
                    this.Close();
                }
            }
            else
            {
                UMessageBox.Show("读取硬件信息失败，请确认硬件设备连接正确。", "人井监控管理系统", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CDMASMS.Close();
                this.Close();
            }
        }

        private void WelcomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭定时器
            this.timer1.Dispose();
        }
    }
}