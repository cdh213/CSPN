using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.IBLL
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUsersService
    {
        #region 用户信息管理
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
        #endregion

        #region 值班人员管理
        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        DataTable GetOperator_Table();
        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        IList<OperatorInfo> GetOperator();
        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <returns></returns>
        OperatorInfo GetOperatorByWork_ID(string work_ID);
        /// <summary>
        /// 增加值班人员信息
        /// </summary>
        /// <returns></returns>
        int InsertOperatorInfo(OperatorInfo oper);
        /// <summary>
        /// 修改值班人员信息
        /// </summary>
        /// <returns></returns>
        int UpdateOperatorInfo(OperatorInfo oper);
        /// <summary>
        /// 删除值班人员信息
        /// </summary>
        /// <returns></returns>
        int DeleteOperatorInfo(string workid);
        #endregion
    }
}
