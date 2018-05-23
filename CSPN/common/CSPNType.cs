namespace CSPN.common
{
    public enum CSPNType
    {
        /// <summary>
        /// 人井信息
        /// </summary>
        WellInfo = 0,

        /// <summary>
        /// 系统日志
        /// </summary>
        SysLogInfo = 1,

        /// <summary>
        /// 用户日志_人井日志
        /// </summary>
        UserLogInfo_WellInfo = 2,

        /// <summary>
        /// 用户日志_一般
        /// </summary>
        UserLogInfo_GeneralInfo = 3,

        /// <summary>
        /// 预约维护
        /// </summary>
        MaintainInfo = 4,

        /// <summary>
        /// 报警信息
        /// </summary>
        AlarmInfo = 5,

        /// <summary>
        /// 已处理信息
        /// </summary>
        DisposeInfo = 6,

        /// <summary>
        /// 未上报信息
        /// </summary>
        NotReportInfo = 7,

        /// <summary>
        /// 值班人员信息
        /// </summary>
        OperatorInfo = 8,

        /// <summary>
        /// 用户信息
        /// </summary>
        UserInfo = 9
    }
}