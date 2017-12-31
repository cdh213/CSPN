using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.Model
{
    /// <summary>
    /// 人井当前状态信息
    /// </summary>
    public class WellCurrentStateInfo
    {
        private string _terminal_ID;//人井编号
        private int _well_State_ID;//人井状态信息ID
        private string _temperature;//温度
        private string _humidity;//湿度
        private string _smoke_Detector;//烟感
        private string _smoke_Power;//烟感电量
        private string _signal_Strength;//信号强度
        private string _report_Time;//上报时间
        private WellStateInfo _wellStateInfo;
        private OperatorInfo _operatorInfo;
        private SystemLogInfo _systemLogInfo;
        private WellInfo _wellInfo;

        #region 属性
        /// <summary>
        /// 人井编号
        /// </summary>
        public string Terminal_ID
        {
            get { return _terminal_ID; }
            set { _terminal_ID = value; }
        }
        /// <summary>
        /// 人井状态信息ID
        /// </summary>
        public int Well_State_ID
        {
            get { return _well_State_ID; }
            set { _well_State_ID = value; }
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
        /// 湿度
        /// </summary>
        public string Humidity
        {
            get { return _humidity; }
            set { _humidity = value; }
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
        /// 烟感电量
        /// </summary>
        public string Smoke_Power
        {
            get { return _smoke_Power; }
            set { _smoke_Power = value; }
        }
        /// <summary>
        /// 信号强度
        /// </summary>
        public string Signal_Strength
        {
            get { return _signal_Strength; }
            set { _signal_Strength = value; }
        }
        /// <summary>
        /// 上报时间
        /// </summary>
        public string Report_Time
        {
            get { return _report_Time; }
            set { _report_Time = value; }
        }
        public WellStateInfo WellStateInfo
        {
            get { return _wellStateInfo; }
            set { _wellStateInfo = value; }
        }
        public OperatorInfo OperatorInfo
        {
            get { return _operatorInfo; }
            set { _operatorInfo = value; }
        }
        public SystemLogInfo SystemLogInfo
        {
            get { return _systemLogInfo; }
            set { _systemLogInfo = value; }
        }
        public WellInfo WellInfo
        {
            get { return _wellInfo; }
            set { _wellInfo = value; }
        }
        #endregion
    }
}
