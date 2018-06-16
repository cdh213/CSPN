using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.IBLL
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface IUsersService
    {
        #region 用户信息管理

        /// <summary>
        /// 查询系统用户信息
        /// </summary>
        DataTable GetUserInfo_Table(int fSize, int sSize, out int pageCount);

        /// <summary>
        /// 查询系统用户信息
        /// </summary>
        UsersInfo GetUsersByWork_ID(string work_Id);

        /// <summary>
        /// 查询登录用户信息
        /// </summary>
        UsersInfo GetUsersByUserName(string username);

        /// <summary>
        /// 更新登录时间
        /// </summary>
        int UpdateLoginTimeByWork_ID(string loginTime, string work_ID);

        /// <summary>
        /// 修改密码
        /// </summary>
        int UpdatePassWordByWork_ID(string passWord, string work_ID);

        /// <summary>
        /// 更新系统用户信息
        /// </summary>
        /// <param name="usersInfo">RealName,Gender,Telephone,UserName,Work_ID</param>
        /// <returns></returns>
        int UpdateUserInfo(UsersInfo usersInfo);

        /// <summary>
        /// 增加系统用户信息
        /// </summary>
        /// <param name="usersInfo">Work_ID,UserName,PassWord,RealName,Gender,Telephone</param>
        /// <returns></returns>
        int InsertUserInfo(UsersInfo usersInfo);

        /// <summary>
        /// 删除系统用户信息
        /// </summary>
        int DeleteUserInfo(string work_Id);

        #endregion 用户信息管理

        #region 值班人员管理

        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        DataTable GetOperator_Table(int pageSize, int pageIndex, out int pageCount);

        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        List<OperatorInfo> GetOperator();

        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <returns></returns>
        OperatorInfo GetOperatorByWork_ID(string work_ID);

        /// <summary>
        /// 查询人井信息
        /// </summary>
        /// <returns></returns>
        int GetWellInfoByWork_ID(string work_ID);

        /// <summary>
        /// 增加值班人员信息
        /// </summary>
        /// <param name="operatorInfo">Work_ID,RealName,Gender,Telephone,Area,ReceiveMsg</param>
        /// <returns></returns>
        int InsertOperatorInfo(OperatorInfo operatorInfo);

        /// <summary>
        /// 修改值班人员信息
        /// </summary>
        /// <param name="operatorInfo">Work_ID,RealName,Gender,Telephone,Area,ReceiveMsg</param>
        /// <returns></returns>
        int UpdateOperatorInfo(OperatorInfo operatorInfo);

        /// <summary>
        /// 删除值班人员信息
        /// </summary>
        /// <returns></returns>
        int DeleteOperatorInfo(string workid);

        #endregion 值班人员管理
    }
}