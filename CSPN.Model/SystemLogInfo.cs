using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.Model
{
    /// <summary>
    /// 系统日志信息
    /// </summary>
    public class SystemLogInfo
    {
        private string _happen_Time;//发生时间
        private string _save_Day;//保存日志时间
        private string _terminal_ID;//人井ID
        private string _well_State;//人井状态信息
        private string _temperature;//温度
        private string _humidity;//湿度
        private string _smoke_Detector;//烟感
        private string _smoke_Power;//烟感电量
        private string _signal_Strength;//信号强度
        

        #region 属性
        /// <summary>
        /// 信号强度
        /// </summary>
        public string Signal_Strength
        {
            get { return _signal_Strength; }
            set { _signal_Strength = value; }
        }
        /// <summary>
        /// 烟感电量
        /// </summary>
        public string Smoke_Power
        {
            get { return _smoke_Power; }
            set { _smoke_Power = value; }
        }
        /// <summary>
        /// 烟感
        /// </summary>
        public string Smoke_Detector
        {
            get { return _smoke_Detector; }
            set { _smoke_Detector = value; }
        }
        /// <summary>
        /// 湿度
        /// </summary>
        public string Humidity
        {
            get { return _humidity; }
            set { _humidity = value; }
        }
        /// <summary>
        /// 温度
        /// </summary>
        public string Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
        /// <summary>
        /// 人井状态信息ID
        /// </summary>
        public string Well_State
        {
            get { return _well_State; }
            set { _well_State = value; }
        }
        /// <summary>
        /// 人井ID
        /// </summary>
        public string Terminal_ID
        {
            get { return _terminal_ID; }
            set { _terminal_ID = value; }
        }
        /// <summary>
        /// 保存日志时间
        /// </summary>
        public string Save_Day
        {
            get { return _save_Day; }
            set { _save_Day = value; }
        }
        /// <summary>
        /// 发生时间
        /// </summary>
        public string Happen_Time
        {
            get { return _happen_Time; }
            set { _happen_Time = value; }
        }
        #endregion
    }
}
