using CSPN.Model;
using System.Data;

namespace CSPN.IDAL
{
    public interface IUserLogDAL
    {
        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        DataTable GetUserLogInfo_WellInfo();

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        DataTable GetUserLogInfo_WellInfo(int fSize, int sSize, out int pageCount);

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        DataTable GetUserLogInfo_GeneralInfo();

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        DataTable GetUserLogInfo_GeneralInfo(int fSize, int sSize, out int pageCount);

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
    }
}