using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.IDAL
{
    /// <summary>
    /// 系统用户管理
    /// </summary>
    public interface IUsersManageDAL
    {
        /// <summary>
        /// 查询登录用户信息
        /// </summary>
        UsersInfo GetUsersByUserName(string username);
        /// <summary>
        /// 更新登录时间
        /// </summary>
        int UpdateLoginTimeByID(string loginTime, string work_ID);
        /// <summary>
        /// 查询系统用户信息
        /// </summary>
        UsersInfo GetUsersByID(string work_Id);
        /// <summary>
        /// 更新系统用户信息
        /// </summary>
        int UpdateUsersInfo(UsersInfo usersInfo);
    }
}
