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
        /// 电量是否报警
        /// </summary>
        public static bool IsElectricityAlarm { get; set; }
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
        /// 是否有烟感数据
        /// </summary>
        public static bool SmokeMsg { get; set; }
        /// <summary>
        /// 烟感是否报警
        /// </summary>
        public static bool IsSmokeAlarm { get; set; }
        /// <summary>
        /// 烟感电量是否报警
        /// </summary>
        public static bool IsSmoke_PowerAlarm { get; set; }

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
            #region 报警信息
            if (s[0] + s[1] == "33")
            {
                Message = true;
            }
            if (s[0] + s[1] == "55")
            {
                Message = false;
            }
            #endregion

            #region 井盖是否打开
            if (s[2] + s[3] == "01")
            {
                IsOpen = true;
            }
            if (s[2] + s[3] == "02")
            {
                IsOpen = false;
            }
            #endregion

            #region 是否失效
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
            #endregion

            #region 电量是否报警
            if (s[4] + s[5] == "00")
            {
                IsElectricityAlarm = false;
            }
            if (s[4] + s[5] == "01")
            {
                IsElectricityAlarm = true;
            }
            #endregion

            #region 信号强度
            Signal_Strength = s[6] + s[7];
            #endregion

            #region 温度湿度
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
            #endregion

            #region 烟感
            if (s[18] + s[19] + s[20] + s[21] == "0000")
            {
                SmokeMsg = false;
            }
            else
            {
                SmokeMsg = true;
                if (s[18] + s[19] == "01")
                {
                    IsSmokeAlarm = false;
                }
                else
                {
                    IsSmokeAlarm = true;
                }
                if (s[20] + s[21] == "00")
                {
                    IsSmoke_PowerAlarm = false;
                }
                else
                {
                    IsSmoke_PowerAlarm = true;
                }
            }
            #endregion 
        }
    }
}
