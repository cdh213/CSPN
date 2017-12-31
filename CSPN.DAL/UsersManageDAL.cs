using CSPN.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CSPN.Model;
using CSPN.IDAL;

namespace CSPN.DAL
{
    /// <summary>
    /// 系统用户管理
    /// </summary>
    public class UsersManageDAL : IUsersManageDAL
    {
        #region Conn
        private IDbConnection _conn;
        public IDbConnection Conn
        {
            get
            {
                return _conn = ConnectionFactory.CreateConnection();
            }
        }
        #endregion

        private const string SELECT_User_Work_Id = "select * from CSPN_Users where Work_Id=@Work_Id";
        private const string SELECT_USER_USERNAME = "select * from CSPN_Users where UserName=@username";
        private const string UPDATE_LOGINTIME_ID = "update CSPN_Users set LoginTime=@LoginTime where Work_ID=@Work_ID";
        private const string UPDATE_UsersInfo = "update CSPN_Users set RealName=@RealName,Telephone=@Telephone,Gender=@Gender where Work_ID=@Work_ID";

        /// <summary>
        /// 查询登录用户信息
        /// </summary>
        public UsersInfo GetUsersByUserName(string username)
        {
            using (Conn)
            {
                return Conn.Query<UsersInfo>(SELECT_USER_USERNAME, new { username = username }).FirstOrDefault();
            }
        }
        /// <summary>
        /// 更新登录时间
        /// </summary>
        public int UpdateLoginTimeByID(string loginTime, string work_ID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@LoginTime", loginTime);
            param.Add("@Work_ID", work_ID);

            using (Conn)
            {
                return Conn.Execute(UPDATE_LOGINTIME_ID, param);
            }
        }
        /// <summary>
        /// 查询系统用户信息
        /// </summary>
        public UsersInfo GetUsersByID(string work_Id)
        {
            using (Conn)
            {
                return Conn.Query<UsersInfo>(SELECT_User_Work_Id, new { Work_Id = work_Id }).FirstOrDefault();
            }
        }
        /// <summary>
        /// 更新系统用户信息
        /// </summary>
        public int UpdateUsersInfo(UsersInfo usersInfo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RealName", usersInfo.RealName);
            param.Add("@Telephone", usersInfo.Telephone);
            param.Add("@Gender", usersInfo.Gender);
            param.Add("@Work_ID", usersInfo.Work_ID);

            using (Conn)
            {
                return Conn.Execute(UPDATE_UsersInfo, param);
            }
        }
    }
}
