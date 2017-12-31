using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.common
{
    public enum ShowPagesType
    {
        /// <summary>
        /// 人井信息
        /// </summary>
        WellInfo,
        /// <summary>
        /// 值班人员信息
        /// </summary>
        OperatorInfo,
        /// <summary>
        /// 系统日志
        /// </summary>
        SysLogInfo,
        /// <summary>
        /// 用户日志_人井日志
        /// </summary>
        UserLogInfo_WellInfo,
        /// <summary>
        /// 用户日志_一般
        /// </summary>
        UserLogInfo_GeneralInfo,
        /// <summary>
        /// 预约维护
        /// </summary>
        AppointmentInfo
    }
}
