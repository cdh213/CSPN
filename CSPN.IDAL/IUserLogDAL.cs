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
        int InsertUserLogInfo(UserLogInfo userLog);
        /// <summary>
        /// 删除用户日志信息
        /// </summary>
        int DeleteUserLogInfo(string nowTime, int save_Day);
        /// <summary>
        /// 更新用户日志信息
        /// </summary>
        int UpdateUserLogInfo(UserLogInfo userLog);
    }
}
