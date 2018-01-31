using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.Model
{
    public class AlarmInfo
    {
        private string _report_Time;//上报时间
        private string _terminal_ID;//人井编号
        private int _well_State_ID;//人井状态信息ID
        private WellInfo _wellInfo;
        private WellCurrentStateInfo _wellCurrentStateInfo;
        private OperatorInfo _operatorInfo;

        /// <summary>
        /// 上报时间
        /// </summary>
        public string Report_Time
        {
            get { return _report_Time; }
            set { _report_Time = value; }
        }
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
        public WellInfo WellInfo
        {
            get { return _wellInfo; }
            set { _wellInfo = value; }
        }
        public WellCurrentStateInfo WellCurrentStateInfo
        {
            get { return _wellCurrentStateInfo; }
            set { _wellCurrentStateInfo = value; }
        }
        public OperatorInfo OperatorInfo
        {
            get { return _operatorInfo; }
            set { _operatorInfo = value; }
        }
    }
}
