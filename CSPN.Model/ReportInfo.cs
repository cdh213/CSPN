using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.Model
{
    public class ReportInfo
    {
        private string _terminal_ID;//人井编号
        private int _well_State_ID_Pending;//人井状态信息ID-待处理
        private int _well_State_ID_Send;//人井状态信息ID-已通知
        private int _reportInterval;//上报时间间隔
        private int _reportTimes;//上报次数
        private int _notReportTimes;//上报次数
        private string _report_Time;//报警时间
        private WellInfo _wellInfo;
        private OperatorInfo _operatorInfo;
        private WellCurrentStateInfo wellCurrentStateInfo;

        /// <summary>
        /// 人井编号
        /// </summary>
        public string Terminal_ID
        {
            get { return _terminal_ID; }
            set { _terminal_ID = value; }
        }
        /// <summary>
        /// 人井状态信息ID-待处理
        /// </summary>
        public int Well_State_ID_Pending
        {
            get { return _well_State_ID_Pending; }
            set { _well_State_ID_Pending = value; }
        }
        /// <summary>
        /// 人井状态信息ID-已通知
        /// </summary>
        public int Well_State_ID_Send
        {
            get { return _well_State_ID_Send; }
            set { _well_State_ID_Send = value; }
        }
        /// <summary>
        /// 上报时间间隔
        /// </summary>
        public int ReportInterval
        {
            get { return _reportInterval; }
            set { _reportInterval = value; }
        }
        /// <summary>
        /// 上报次数
        /// </summary>
        public int ReportTimes
        {
            get { return _reportTimes; }
            set { _reportTimes = value; }
        }
        /// <summary>
        /// 未上报次数
        /// </summary>
        public int NotReportTimes
        {
            get { return _notReportTimes; }
            set { _notReportTimes = value; }
        }
        /// <summary>
        /// 报警时间
        /// </summary>
        public string Report_Time
        {
            get { return _report_Time; }
            set { _report_Time = value; }
        }
        public WellInfo WellInfo
        {
            get { return _wellInfo; }
            set { _wellInfo = value; }
        }
        public OperatorInfo OperatorInfo
        {
            get { return _operatorInfo; }
            set { _operatorInfo = value; }
        }
        public WellCurrentStateInfo WellCurrentStateInfo
        {
            get { return wellCurrentStateInfo; }
            set { wellCurrentStateInfo = value; }
        }
    }
}
