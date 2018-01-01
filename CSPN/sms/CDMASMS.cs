using CSPN.helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPN.sms
{
    public class CDMASMS
    {
        //私有字段 串口对象
        static SerialPort sp;
        public static Queue<int> queue = new Queue<int>();

        /// <summary>
        /// 设置串口号和波特率
        /// </summary>
        /// <param name="comPort">串口号</param>
        /// <param name="baudRate">波特率</param>
        public static void Set(string comPort, int baudRate)
        {
            try
            {
                sp = new SerialPort();
                sp.PortName = comPort;      //串口号
                sp.BaudRate = baudRate;     //波特率
                sp.ReadTimeout = 5000;      //读超时时间 发送短信时间的需要
                sp.RtsEnable = true;        //必须为true 这样串口才能接收到数据
                sp.ReceivedBytesThreshold = 1; //接收缓冲区当中如果有一个字节的话就出发接收函数
                //收到短信息事件
                sp.DataReceived += sp_DataReceived;
            }
            catch(Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
                throw new Exception("串口设置错误！");
            }
        }

        //从串口收到数据,串口事件。
        static void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string temp = sp.ReadLine();
                if (temp.Length > 8)
                {
                    if (temp.IndexOf("+CMTI:") != -1)
                    {
                        queue.Enqueue(Convert.ToInt32(temp.Split(',')[1]));
                    }
                    if (temp.IndexOf("^SMMEMFULL:") != -1)
                    {
                        DeleteAllMsg();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 设备打开函数，无法时打开将引发异常
        /// </summary>
        public static bool Open()
        {
            try
            {
                sp.Open();
                //设备是否打开
                if (sp.IsOpen)
                {
                    //更新添加连接识别
                    string s = SendAT("AT");
                    int v = s.IndexOf("OK");
                    if (s.IndexOf("OK") == -1)
                    {
                        return false;
                    }
                    else
                    {
                        SendAT("ATE0");
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
                return false;
            }
        }
        /// <summary>
        /// 设备关闭
        /// </summary>
        public static void Close()
        {
            try
            {
                sp.Close();
                sp.Dispose();
                sp = null;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
        }

        /// <summary>
        /// 发送AT指令 逐条发送AT指令 调用一次发送一条指令
        /// 能返回一个OK或ERROR算一条指令
        /// </summary>
        /// <param name="ATCom">AT指令</param>
        /// <returns>发送指令后返回的字符串</returns>
        public static string SendAT(string ATCom)
        {
            string result = "";
            //忽略接收缓冲区内容，准备发送
            sp.DiscardInBuffer();
            //注销事件关联，为发送做准备
            sp.DataReceived -= sp_DataReceived;
            //发送AT指令
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(ATCom + "\r");
                sp.Write(data, 0, data.Length);
                Thread.Sleep(500);
                DateTime startTime = DateTime.Now;
                while (true)
                {
                    TimeSpan timespan = DateTime.Now - startTime;
                    if (timespan.Milliseconds > 3000)
                        return null;
                    int n = sp.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
                    if (n != 0)
                    {
                        byte[] buffer = new byte[n];
                        sp.Read(buffer, 0, n); ;//读取缓冲数据
                        result += Encoding.ASCII.GetString(buffer);
                        Thread.Sleep(300);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
            finally
            {
                //事件重新绑定 正常监视串口数据
                sp.DataReceived += sp_DataReceived;
            }
            return result;
        }
        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <returns>设备信息</returns>
        public static string GetDeviceMsg()
        {
            if (sp.IsOpen)
            {
                string deviceMsg = SendAT("ATI").Replace("\r\n", ";").Replace("OK", "");
                string hardwareVersion = SendAT("AT^HWVER").Replace("\r\n", "").Replace("OK", "");
                string deviceMEID = SendAT("AT^MEID").Replace("\r\n", "").Replace("OK", "");
                string signal = SendAT("AT+CSQ").Replace("\r\n", "").Replace("OK", "");
                if (deviceMsg + hardwareVersion + deviceMEID + signal != "")
                {
                    return deviceMsg + ";" + hardwareVersion + ";" + deviceMEID + ";" + signal;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        /// <summary>
        /// 按序号读取短信
        /// </summary>
        /// <param name="index">序号</param>
        /// <returns>短信</returns>
        public static string ReadMsgByIndex(int index)
        {
            string msg = SendAT(@"AT^HCMGR=" + index);
            string sms = null;
            try
            {
                if (msg.Trim() != "Invalid index" && msg.Trim() != "ERROR")
                {
                    sms = RMessage(msg);
                }
                else
                {
                    sms = null;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
            return sms;
        }
        /// <summary>
        /// 删除首选存储器上所有的已读短信和已发送短信，保留未读短信和未发送短信
        /// </summary>
        static void DeleteAllMsg()
        {
            SendAT("AT+CMGD=0,2");
        }
        /// <summary>
        /// 按序号删除短信
        /// </summary>
        /// <param name="index">序号</param>
        public static void DeleteMsgByIndex(int index)
        {
            SendAT("AT+CMGD=" + index);
        }
        /// <summary>
        /// 发送中文短信
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="phone">手机号</param>
        public static void SendCHNSms(string content, string phone)
        {
            //中文CDMA发送，UNICODE编码字节   
            byte[] b = Encoding.BigEndianUnicode.GetBytes(content);
            //CDMA的AT命令手机号码前面不能加86，否则虽然显示成功发送，但短信中心回应错误代码5   
            if (phone.IndexOf("86") == 0)
            {
                phone = phone.Substring(2);
            }
            try
            {
                //忽略接收缓冲区内容，准备发送
                sp.DiscardInBuffer();
                //注销事件关联，为发送做准备
                sp.DataReceived -= sp_DataReceived;
                //设置发送的号码和发送内容字节长度   
                sp.Write("AT^HCMGS=\"" + phone + "\"" + "\r");
                Thread.Sleep(500);
                //写入   
                sp.Write(b, 0, b.Length);
                Thread.Sleep(500);
                //写入CTRL+Z结束短信内容，注意在UNICODE模式下需要两个字节，这个也是不能在超级终端下操作的原因   
                byte[] b2 = new byte[] { 0x00, 0x1a };
                sp.Write(b2, 0, b2.Length);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(ex.Message, ex);
            }
            finally
            {
                //事件重新绑定 正常监视串口数据
                sp.DataReceived += sp_DataReceived;
            }
        }
        /// <summary>
        /// 设备初始化
        /// </summary>
        public static void DeviceInitialize()
        {
            SendAT("AT+CMGF=1");
            SendAT("AT+WSCL=6,4");
            SendAT("AT+CPMS=\"ME\",\"ME\",\"ME\"");
            SendAT("AT+CNMI=1,1,0,2,0");
            SendAT("AT^HSMSSS=0,0,6,0");
        }
        //格式化信息
        static string RMessage(string msg)
        {
            Regex regex = new Regex("^[\x21-\x7e]*$");
            string phone, datetime = null, message;
            string[] str, str1;
            str = msg.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            str1 = str[1].Remove(0, 7).Split(',');
            phone = str1[0];
            for (int i = 1; i < 7; i++)
            {
                datetime += str1[i];
            }
            if (regex.Match(str[2]).Success)
            {
                message = str[2].Substring(0, 24);
                return phone + ";" + datetime.TrimEnd(',') + ";" + message;
            }
            else
            {
                LogHelper.WriteLog("非指定短信，手机号：" + phone + "，时间：" + DateTime.ParseExact(datetime.TrimEnd(','), "yyyyMMddHHmmss", CultureInfo.CurrentCulture).ToString("yyyy/MM/dd HH:mm:ss"));
                return null;
            }
        }
    }
}
