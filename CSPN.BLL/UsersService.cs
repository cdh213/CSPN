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
        private static readonly IUsersDAL usersDAL = DALFactory.CreateUsersDAL();
        private static readonly IOperatorDAL operatorDAL = DALFactory.CreateOperatorDAL();

        #region 用户信息管理

        /// <summary>
        /// 查询系统用户信息
        /// </summary>
        public DataTable GetUserInfo_Table(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return usersDAL.GetUserInfo_Table(fSize, sSize, out pageCount);
        }

        /// <summary>
        /// 查询系统用户信息
        /// </summary>
        public UsersInfo GetUsersByWork_ID(string work_Id)
        {
            return usersDAL.GetUsersByWork_ID(work_Id);
        }

        /// <summary>
        /// 查询登录用户信息
        /// </summary>
        public UsersInfo GetUsersByUserName(string username)
        {
            return usersDAL.GetUsersByUserName(username);
        }

        /// <summary>
        /// 更新登录时间
        /// </summary>
        public int UpdateLoginTimeByWork_ID(string loginTime, string work_ID)
        {
            return usersDAL.UpdateLoginTimeByWork_ID(loginTime, work_ID);
        }

        /// <summary>
        /// 更新系统用户信息
        /// </summary>
        /// <param name="usersInfo">RealName,Gender,Telephone,UserName,Work_ID</param>
        /// <returns></returns>
        public int UpdateUserInfo(UsersInfo usersInfo)
        {
            return usersDAL.UpdateUserInfo(usersInfo);
        }

        /// <summary>
        /// 增加系统用户信息
        /// </summary>
        /// <param name="usersInfo">Work_ID,UserName,PassWord,RealName,Gender,Telephone</param>
        /// <returns></returns>
        public int InsertUserInfo(UsersInfo usersInfo)
        {
            return usersDAL.InsertUserInfo(usersInfo);
        }

        /// <summary>
        /// 删除系统用户信息
        /// </summary>
        public int DeleteUserInfo(string work_Id)
        {
            return usersDAL.DeleteUserInfo(work_Id);
        }

        #endregion 用户信息管理

        #region 值班人员管理

        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetOperator_Table(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return operatorDAL.GetOperator_Table(fSize, sSize, out pageCount);
        }

        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        public List<OperatorInfo> GetOperator()
        {
            return operatorDAL.GetOperator();
        }

        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <returns></returns>
        public OperatorInfo GetOperatorByWork_ID(string work_ID)
        {
            return operatorDAL.GetOperatorByWork_ID(work_ID);
        }

        /// <summary>
        /// 增加值班人员信息
        /// </summary>
        /// <param name="operatorInfo">Work_ID,RealName,Gender,Telephone,Area,ReceiveMsg</param>
        /// <returns></returns>
        public int InsertOperatorInfo(OperatorInfo operatorInfo)
        {
            return operatorDAL.InsertOperatorInfo(operatorInfo);
        }

        /// <summary>
        /// 修改值班人员信息
        /// </summary>
        /// <param name="operatorInfo">Work_ID,RealName,Gender,Telephone,Area,ReceiveMsg</param>
        /// <returns></returns>
        public int UpdateOperatorInfo(OperatorInfo operatorInfo)
        {
            return operatorDAL.UpdateOperatorInfo(operatorInfo);
        }

        /// <summary>
        /// 删除值班人员信息
        /// </summary>
        /// <returns></returns>
        public int DeleteOperatorInfo(string workid)
        {
            return operatorDAL.DeleteOperatorInfo(workid);
        }

        #endregion 值班人员管理
    }
}