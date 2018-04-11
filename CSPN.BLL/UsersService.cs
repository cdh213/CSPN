using CSPN.Factory;
using CSPN.IBLL;
using CSPN.IDAL;
using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.BLL
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UsersService : IUsersService
    {
        private static readonly IUsersManageDAL managdal = DALFactory.CreateUsersManagDAL();
        private static readonly IOperatorDAL operatordal = DALFactory.CreateOperatorDAL();

        #region 用户信息管理
        /// <summary>
        /// 查询系统用户信息
        /// </summary>
        public DataTable GetUserInfo_Table(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return managdal.GetUserInfo_Table(fSize, sSize, out pageCount);
        }
        /// <summary>
        /// 查询系统用户信息
        /// </summary>
        public UsersInfo GetUsersByWork_ID(string work_Id)
        {
            return managdal.GetUsersByWork_ID(work_Id);
        }
        /// <summary>
        /// 查询登录用户信息
        /// </summary>
        public UsersInfo GetUsersByUserName(string username)
        {
            return managdal.GetUsersByUserName(username);
        }
        /// <summary>
        /// 更新登录时间
        /// </summary>
        public int UpdateLoginTimeByWork_ID(string loginTime, string work_ID)
        {
            return managdal.UpdateLoginTimeByWork_ID(loginTime, work_ID);
        }
        /// <summary>
        /// 更新系统用户信息
        /// </summary>
        public int UpdateUserInfo(UsersInfo usersInfo)
        {
            return managdal.UpdateUserInfo(usersInfo);
        }
        /// <summary>
        /// 增加系统用户信息
        /// </summary>
        public int InsertUserInfo(UsersInfo usersInfo)
        {
            return managdal.InsertUserInfo(usersInfo);
        }
        /// <summary>
        /// 删除系统用户信息
        /// </summary>
        public int DeleteUserInfo(string work_Id)
        {
            return managdal.DeleteUserInfo(work_Id);
        }
        #endregion

        #region 值班人员管理
        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetOperator_Table(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return operatordal.GetOperator_Table(fSize, sSize, out pageCount);
        }
        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        public List<OperatorInfo> GetOperator()
        {
            return operatordal.GetOperator();
        }
        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <returns></returns>
        public OperatorInfo GetOperatorByWork_ID(string work_ID)
        {
            return operatordal.GetOperatorByWork_ID(work_ID);
        }
        /// <summary>
        /// 增加值班人员信息
        /// </summary>
        /// <returns></returns>
        public int InsertOperatorInfo(OperatorInfo oper)
        {
            return operatordal.InsertOperatorInfo(oper);
        }
        /// <summary>
        /// 修改值班人员信息
        /// </summary>
        /// <returns></returns>
        public int UpdateOperatorInfo(OperatorInfo oper)
        {
            return operatordal.UpdateOperatorInfo(oper);
        }
        /// <summary>
        /// 删除值班人员信息
        /// </summary>
        /// <returns></returns>
        public int DeleteOperatorInfo(string workid)
        {
            return operatordal.DeleteOperatorInfo(workid);
        }
        #endregion
    }
}
