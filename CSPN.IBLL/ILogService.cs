using CSPN.Model;
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
        /// 添加用户日志信息
        /// </summary>
        /// <param name="userLogInfo">Happen_Time,Operation_Content,The_Operator,Terminal_ID,Notice_time,Receive_People,Current_State</param>
        /// <returns></returns>
        int InsertUserLogInfo(UserLogInfo userLogInfo);

        /// <summary>
        /// 删除用户日志信息
        /// </summary>
        int DeleteUserLogInfo(string nowTime, int save_Day);

        /// <summary>
        /// 更新用户日志信息
        /// </summary>
        /// <param name="userLogInfo">Processor,Process_Content,Process_Time,Current_State,Happen_Time</param>
        /// <returns></returns>
        int UpdateUserLogInfo(UserLogInfo userLogInfo);

        #endregion 用户日志

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
        /// 添加系统日志信息
        /// </summary>
        /// <param name="systemLogInfo">Happen_Time,Terminal_ID,Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength</param>
        /// <returns></returns>
        int InsertSystemLogInfo(SystemLogInfo systemLogInfo);

        /// <summary>
        /// 删除系统日志信息
        /// </summary>
        int DeleteSystemLogInfo(string nowTime, int save_Day);

        #endregion 系统日志
    }
}