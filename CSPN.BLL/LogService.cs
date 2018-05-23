using CSPN.Factory;
using CSPN.IBLL;
using CSPN.IDAL;
using CSPN.Model;
using System.Data;

namespace CSPN.BLL
{
    /// <summary>
    /// 日志服务
    /// </summary>
    public class LogService : ILogService
    {
        private static readonly IUserLogDAL userLogDAL = DALFactory.CreateUserLogDAL();
        private static readonly ISystemLogDAL systemLogDAL = DALFactory.CreateSystemLogDAL();

        #region 用户日志

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserLogInfo_WellInfo()
        {
            return userLogDAL.GetUserLogInfo_WellInfo();
        }

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserLogInfo_WellInfo(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return userLogDAL.GetUserLogInfo_WellInfo(fSize, sSize, out pageCount);
        }

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserLogInfo_GeneralInfo()
        {
            return userLogDAL.GetUserLogInfo_GeneralInfo();
        }

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserLogInfo_GeneralInfo(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return userLogDAL.GetUserLogInfo_GeneralInfo(fSize, sSize, out pageCount);
        }

        /// <summary>
        /// 添加用户日志信息
        /// </summary>
        /// <param name="userLogInfo">Happen_Time,Operation_Content,The_Operator,Terminal_ID,Notice_time,Receive_People,Current_State</param>
        /// <returns></returns>
        public int InsertUserLogInfo(UserLogInfo userLogInfo)
        {
            return userLogDAL.InsertUserLogInfo(userLogInfo);
        }

        /// <summary>
        /// 删除用户日志信息
        /// </summary>
        public int DeleteUserLogInfo(string nowTime, int save_Day)
        {
            return userLogDAL.DeleteUserLogInfo(nowTime, save_Day);
        }

        /// <summary>
        /// 更新用户日志信息
        /// </summary>
        /// <param name="userLogInfo">Processor,Process_Content,Process_Time,Current_State,Happen_Time</param>
        /// <returns></returns>
        public int UpdateUserLogInfo(UserLogInfo userLogInfo)
        {
            return userLogDAL.UpdateUserLogInfo(userLogInfo);
        }

        #endregion 用户日志

        #region 系统日志

        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetSystemLogInfo()
        {
            return systemLogDAL.GetSystemLogInfo();
        }

        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetSystemLogInfo(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return systemLogDAL.GetSystemLogInfo(fSize, sSize, out pageCount);
        }

        /// <summary>
        /// 添加系统日志信息
        /// </summary>
        /// <param name="systemLogInfo">Happen_Time,Terminal_ID,Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength</param>
        /// <returns></returns>
        public int InsertSystemLogInfo(SystemLogInfo systemLogInfo)
        {
            return systemLogDAL.InsertSystemLogInfo(systemLogInfo);
        }

        /// <summary>
        /// 删除系统日志信息
        /// </summary>
        /// <param name="UserLog">日志信息</param>
        /// <returns></returns>
        public int DeleteSystemLogInfo(string nowTime, int save_Day)
        {
            return systemLogDAL.DeleteSystemLogInfo(nowTime, save_Day);
        }

        #endregion 系统日志
    }
}