﻿using CSPN.Model;
using System.Data;

namespace CSPN.IDAL
{
    /// <summary>
    /// 系统用户管理
    /// </summary>
    public interface IUsersDAL
    {
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
    }
}