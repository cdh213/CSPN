using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.Model
{
    public class ReportNumInfo
    {
        private string _terminal_ID;//人井编号
        private int _reportInterval;//上报时间间隔
        private int _reportTimes;//上报次数
        private int _notReportTimes;//上报次数
        private WellInfo _wellInfo;
        private OperatorInfo _operatorInfo;

        /// <summary>
        /// 人井编号
        /// </summary>
        public string Terminal_ID
        {
            get { return _terminal_ID; }
            set { _terminal_ID = value; }
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
    }
}
