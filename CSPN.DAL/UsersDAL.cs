using CSPN.Factory;
using CSPN.IDAL;
using CSPN.Model;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;

namespace CSPN.DAL
{
    /// <summary>
    /// 系统用户管理
    /// </summary>
    public class UsersDAL : IUsersDAL
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

        #endregion Conn

        private const string SELECT = "select * from CSPN_Users_Info where ID between (select max(ID) from (select top {0} ID from CSPN_Users_Info order by ID asc)) and (select max(ID) from (select top {1} ID from CSPN_Users_Info order by ID asc)) order by ID asc";
        private const string SELECT_Count = "select count(*) from CSPN_Users_Info";
        private const string SELECT_USER_USERNAME = "select * from CSPN_Users_Info where UserName=@username";
        private const string SELECT_User_Work_Id = "select * from CSPN_Users_Info where Work_Id=@Work_Id";
        private const string UPDATE_LOGINTIME_ID = "update CSPN_Users_Info set LoginTime=@LoginTime where Work_ID=@Work_ID";
        private const string UPDATE_UsersInfo = "update CSPN_Users_Info set RealName=@RealName,Gender=@Gender,Telephone=@Telephone,UserName=@UserName where Work_ID=@Work_ID";
        private const string INSERT_UsersInfo = "insert into CSPN_Users_Info(Work_ID,UserName,[PassWord],RealName,Gender,Telephone) values(@Work_ID,@UserName,@PassWord,@RealName,@Gender,@Telephone)";
        private const string DELETE_UsersInfo = "delete from CSPN_Users_Info where Work_ID=@Work_ID";

        private StringBuilder sb = null;

        /// <summary>
        /// 查询系统用户信息
        /// </summary>
        public DataTable GetUserInfo_Table(int fSize, int sSize, out int pageCount)
        {
            sb = new StringBuilder();
            sb.AppendFormat(SELECT, fSize, sSize);
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    pageCount = (int)Conn.ExecuteScalar(SELECT_Count);
                    table.Load(Conn.ExecuteReader(sb.ToString()));
                }
                return table;
            }
        }

        /// <summary>
        /// 查询系统用户信息
        /// </summary>
        public UsersInfo GetUsersByWork_ID(string work_Id)
        {
            using (Conn)
            {
                return Conn.Query<UsersInfo>(SELECT_User_Work_Id, new { Work_Id = work_Id }).FirstOrDefault();
            }
        }

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
        public int UpdateLoginTimeByWork_ID(string loginTime, string work_ID)
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
        /// 更新系统用户信息
        /// </summary>
        /// <param name="usersInfo">RealName,Gender,Telephone,UserName,Work_ID</param>
        /// <returns></returns>
        public int UpdateUserInfo(UsersInfo usersInfo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RealName", usersInfo.RealName);
            param.Add("@Gender", usersInfo.Gender);
            param.Add("@Telephone", usersInfo.Telephone);
            param.Add("@UserName", usersInfo.UserName);
            param.Add("@Work_ID", usersInfo.Work_ID);

            using (Conn)
            {
                return Conn.Execute(UPDATE_UsersInfo, param);
            }
        }

        /// <summary>
        /// 增加系统用户信息
        /// </summary>
        /// <param name="usersInfo">Work_ID,UserName,PassWord,RealName,Gender,Telephone</param>
        /// <returns></returns>
        public int InsertUserInfo(UsersInfo usersInfo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Work_ID", usersInfo.Work_ID);
            param.Add("@UserName", usersInfo.UserName);
            param.Add("@PassWord", usersInfo.PassWord);
            param.Add("@RealName", usersInfo.RealName);
            param.Add("@Gender", usersInfo.Gender);
            param.Add("@Telephone", usersInfo.Telephone);
            using (Conn)
            {
                return Conn.Execute(INSERT_UsersInfo, param);
            }
        }

        /// <summary>
        /// 删除系统用户信息
        /// </summary>
        public int DeleteUserInfo(string work_Id)
        {
            using (Conn)
            {
                return Conn.Execute(DELETE_UsersInfo, new { Work_Id = work_Id });
            }
        }
    }
}