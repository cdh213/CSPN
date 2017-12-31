using CSPN.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.sms
{
    public class SMSAnalysis
    {
        #region 属性
        /// <summary>
        /// 报警信息：true，状态信息：false
        /// </summary>
        public static bool Message { get; set; }
        /// <summary>
        /// 井盖是否打开
        /// </summary>
        public static bool IsOpen { get; set; }
        /// <summary>
        /// 电量
        /// </summary>
        public static bool Electric { get; set; }
        /// <summary>
        /// 信号强度
        /// </summary>
        public static string Signal_Strength { get; set; }
        /// <summary>
        /// 温度
        /// </summary>
        public static string Temperature { get; set; }
        /// <summary>
        /// 湿度
        /// </summary>
        public static string Humidity { get; set; }
        /// <summary>
        /// 烟感是否报警
        /// </summary>
        private static bool IsSmokeAlarm { get; set; }
        /// <summary>
        /// 烟感
        /// </summary>
        public static string Smoke { get; set; }
        /// <summary>
        /// 烟感电量
        /// </summary>
        private static string Smoke_Power { get; set; }
        /// <summary>
        /// 是否无效
        /// </summary>
        public static bool? isInvalid = null;
        #endregion

        /// <summary>
        /// 信息分析结果
        /// </summary>
        /// <param name="smsMsg"></param>
        public static void MsgResult(string smsMsg)
        {
            ReadWriteRegistry registry = new ReadWriteRegistry();
            string[] s = new string[smsMsg.Length];
            for (int i = 0; i < smsMsg.Length - 1; i++)
            {
                s[i] = smsMsg.Substring(i, 1);
            }
            if (s[0] + s[1] == "33")
            {
                Message = true;
            }
            if (s[0] + s[1] == "55")
            {
                Message = false;
            }
            if (s[2] + s[3] == "01")
            {
                IsOpen = true;
            }
            if (s[2] + s[3] == "02")
            {
                IsOpen = false;
            }
            if (s[0] + s[1] + s[2] + s[3] == "5AC5")
            {
                ReadWriteRegistry.WriteRegistry("isInvalid", "true");
                isInvalid = true;
            }
            if (s[0] + s[1] + s[2] + s[3] == "5BD5")
            {
                ReadWriteRegistry.WriteRegistry("isInvalid", "false");
                isInvalid = false;
            }
            if (s[4] + s[5]=="00")
            {
                Electric = true;
            }
            if (s[4] + s[5] == "01")
            {
                Electric = false;
            }
            Signal_Strength = s[6] + s[7];
            if (s[8] + s[9] + s[10] + s[11] + s[12] == "00000")
            {
                Temperature = "无温度数据";
            }
            else
            {
                Temperature = s[8] + s[9] + s[10] + s[11] + s[12];
            }
            if (s[13] + s[14] + s[15] + s[16] + s[17] == "00000")
            {
                Humidity = "无湿度数据";
            }
            else
            {
                Humidity = s[13] + s[14] + s[15] + s[16] + s[17];
            }
            if (s[18] + s[19] + s[20] + s[21] == "0000")
            {
                Smoke = "无烟感数据";
            }
            else
            {
                if (s[18] + s[19] == "01")
                {
                    IsSmokeAlarm = false;
                }
                else
                {
                    IsSmokeAlarm = true;
                }
                Smoke_Power = s[22] + s[23];
                Smoke = IsSmokeAlarm.ToString() + ";" + Smoke_Power;
            }
        }
    }
}
