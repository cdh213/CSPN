using CSPN.Model;
using System;
using System.Data;

namespace CSPN.IBLL
{
    public interface ILogService
    {
        #region 用户日志
        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        DataTable GetUserLogInfo_WellInfo();
        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        DataTable GetUserLogInfo_WellInfo(int pageSize, int pageIndex, out int pageCount);
        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        DataTable GetUserLogInfo_GeneralInfo();
        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        DataTable GetUserLogInfo_GeneralInfo(int pageSize, int pageIndex, out int pageCount);
        /// <summary>
        /// 查询发生时间的最小值
        /// </summary>
        DateTime GetMinHappen_Time_UserLog();
        /// <summary>
        /// 添加用户日志信息
        /// </summary>
        int InsertUserLogInfo(UserLogInfo userLog);
        /// <summary>
        /// 删除用户日志信息
        /// </summary>
        int DeleteUserLogInfo(string nowTime, int save_Day);
        /// <summary>
        /// 更新用户日志信息
        /// </summary>
        int UpdateUserLogInfo(UserLogInfo userLog);
        #endregion

        #region 系统日志
        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        DataTable GetSystemLogInfo();
        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        DataTable GetSystemLogInfo(int pageSize, int pageIndex, out int pageCount);
        /// <summary>
        /// 查询发生时间的最小值
        /// </summary>
        DateTime GetMinHappen_Time_SysLog();
        /// <summary>
        /// 添加系统日志信息
        /// </summary>
        int InsertSystemLogInfo(SystemLogInfo sysLog);
        /// <summary>
        /// 删除系统日志信息
        /// </summary>
        int DeleteSystemLogInfo(string nowTime, int save_Day);
        #endregion
    }
}
