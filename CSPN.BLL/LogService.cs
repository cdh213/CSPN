using CSPN.Factory;
using CSPN.IBLL;
using CSPN.IDAL;
using CSPN.Model;
using System;
using System.Data;

namespace CSPN.BLL
{
    /// <summary>
    /// 日志服务
    /// </summary>
    public class LogService : ILogService
    {
        private static readonly IUserLogDAL userlogdal = DALFactory.CreateUserLogDAL();
        private static readonly ISystemLogDAL syslogdal = DALFactory.CreateSystemLogDAL();

        #region 用户日志
        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserLogInfo_WellInfo()
        {
            return userlogdal.GetUserLogInfo_WellInfo();
        }
        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserLogInfo_WellInfo(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return userlogdal.GetUserLogInfo_WellInfo(fSize, sSize, out pageCount);
        }
        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserLogInfo_GeneralInfo()
        {
            return userlogdal.GetUserLogInfo_GeneralInfo();
        }
        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserLogInfo_GeneralInfo(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return userlogdal.GetUserLogInfo_GeneralInfo(fSize, sSize, out pageCount);
        }
        /// <summary>
        /// 查询发生时间的最小值
        /// </summary>
        public DateTime GetMinHappen_Time_UserLog()
        {
            return userlogdal.GetMinHappen_Time_UserLog();
        }
        /// <summary>
        /// 添加用户日志信息
        /// </summary>
        /// <param name="UserLog">日志信息</param>
        /// <returns></returns>
        public int InsertUserLogInfo(UserLogInfo userLog)
        {
            return userlogdal.InsertUserLogInfo(userLog);
        }

        /// <summary>
        /// 删除用户日志信息
        /// </summary>
        /// <param name="UserLog">日志信息</param>
        /// <returns></returns>
        public int DeleteUserLogInfo(string nowTime, int save_Day)
        {
            return userlogdal.DeleteUserLogInfo(nowTime, save_Day);
        }
        /// <summary>
        /// 更新用户日志信息
        /// </summary>
        /// <param name="UserLog">日志信息</param>
        /// <returns></returns>
        public int UpdateUserLogInfo(UserLogInfo userLog)
        {
            return userlogdal.UpdateUserLogInfo(userLog);
        }
        #endregion

        #region 系统日志
        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetSystemLogInfo()
        {
            return syslogdal.GetSystemLogInfo();
        }
        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetSystemLogInfo(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return syslogdal.GetSystemLogInfo(fSize, sSize, out pageCount);
        }
        /// <summary>
        /// 查询发生时间的最小值
        /// </summary>
        public DateTime GetMinHappen_Time_SysLog()
        {
            return syslogdal.GetMinHappen_Time_SysLog();
        }
        /// <summary>
        /// 添加系统日志信息
        /// </summary>
        /// <param name="UserLog">日志信息</param>
        /// <returns></returns>
        public int InsertSystemLogInfo(SystemLogInfo sysLog)
        {
            return syslogdal.InsertSystemLogInfo(sysLog);
        }
        /// <summary>
        /// 删除系统日志信息
        /// </summary>
        /// <param name="UserLog">日志信息</param>
        /// <returns></returns>
        public int DeleteSystemLogInfo(string nowTime, int save_Day)
        {
            return syslogdal.DeleteSystemLogInfo(nowTime, save_Day);
        }
        #endregion
    }
}
