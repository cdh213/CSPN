using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        DataTable GetUserLogInfo_GeneralInfo();
        /// <summary>
        /// 添加用户日志信息
        /// </summary>
        int InsertUserLogInfo(UserLogInfo userLog);
        /// <summary>
        /// 删除用户日志信息
        /// </summary>
        int DeleteUserLogInfo(UserLogInfo userLog);
        /// <summary>
        /// 更新用户日志信息
        /// </summary>
        int UpdateUserLogInfo(UserLogInfo userLog);
        #endregion

        #region 系统日志
        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        /// <returns></returns>
        DataTable GetSystemLogInfo();
        /// <summary>
        /// 添加系统日志信息
        /// </summary>
        /// <param name="UserLog">日志信息</param>
        /// <returns></returns>
        int InsertSystemLogInfo(SystemLogInfo sysLog);
        /// <summary>
        /// 删除系统日志信息
        /// </summary>
        /// <param name="UserLog">日志信息</param>
        /// <returns></returns>
        int DeleteSystemLogInfo(SystemLogInfo sysLog);
        #endregion
    }
}
