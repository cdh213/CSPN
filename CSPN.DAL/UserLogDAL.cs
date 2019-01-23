using CSPN.Factory;
using CSPN.IDAL;
using CSPN.Model;
using Dapper;
using System.Data;
using System.Text;

namespace CSPN.DAL
{
    public class UserLogDAL : IUserLogDAL
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

        private const string SELECT_UserLogWellInfo = "select Happen_Time,a.Terminal_ID,Name,Place,The_Operator,Operation_Content,Receive_People,Notice_time,Processor,Process_Content,Process_Time,Current_State from CSPN_User_Log_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID where Notice_time is not null order by Happen_Time desc";
        private const string SELECT_UserLog_WellInfo = "select Happen_Time,a.Terminal_ID,Name,Place,The_Operator,Operation_Content,Receive_People,Notice_time,Processor,Process_Content,Process_Time,Current_State from CSPN_User_Log_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID where Happen_Time between (select min(Happen_Time) from (select top {0} Happen_Time from (select * from CSPN_User_Log_Info where Notice_time is not null) order by Happen_Time desc)) and (select min(Happen_Time) from (select top {1} Happen_Time from (select * from CSPN_User_Log_Info where Notice_time is not null) order by Happen_Time desc)) order by Happen_Time desc";
        private const string SELECT_UserLog_WellInfo_Count = "select count(*) from CSPN_User_Log_Info where Notice_time is not null";
        private const string SELECT_UserLogGeneralInfo = "select Happen_Time,The_Operator,Operation_Content from CSPN_User_Log_Info where Notice_time is null order by Happen_Time desc";
        private const string SELECT_UserLog_GeneralInfo = "select Happen_Time,The_Operator,Operation_Content from (select * from CSPN_User_Log_Info where Notice_time is null) where Happen_Time between (select min(Happen_Time) from (select top {0} Happen_Time from (select * from CSPN_User_Log_Info where Notice_time is null) order by Happen_Time desc)) and (select min(Happen_Time) from (select top {1} Happen_Time from (select * from CSPN_User_Log_Info where Notice_time is null) order by Happen_Time desc)) order by Happen_Time desc";
        private const string SELECT_UserLog_GeneralInfo_Count = "select count(*) from CSPN_User_Log_Info where Notice_time is null";
        private const string INSERT_UserLog = "insert into CSPN_User_Log_Info(Happen_Time,Operation_Content,The_Operator,Terminal_ID,Notice_time,Receive_People,Current_State) values (@Happen_Time,@Operation_Content,@The_Operator,@Terminal_ID,@Notice_time,@Receive_People,@Current_State)";
        private const string DELETE_UserLog = "delete from CSPN_User_Log_Info where DateDiff('d',format(Happen_Time,'yyyy/mm/dd'),'{0}')>={1}";
        private const string UPDATE_UserLog = "update CSPN_User_Log_Info set Processor=@Processor,Process_Content=@Process_Content,Process_Time=@Process_Time,Current_State=@Current_State where Happen_Time=@Happen_Time";

        private StringBuilder sb = null;

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        public DataTable GetUserLogInfo_WellInfo()
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT_UserLogWellInfo));
                }
                return table;
            }
        }

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        public DataTable GetUserLogInfo_WellInfo(int fSize, int sSize, out int pageCount)
        {
            sb = new StringBuilder();
            sb.AppendFormat(SELECT_UserLog_WellInfo, sSize, fSize);
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    pageCount = (int)Conn.ExecuteScalar(SELECT_UserLog_WellInfo_Count);
                    table.Load(Conn.ExecuteReader(sb.ToString()));
                }
                return table;
            }
        }

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        public DataTable GetUserLogInfo_GeneralInfo()
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT_UserLogGeneralInfo));
                }
                return table;
            }
        }

        /// <summary>
        /// 查询用户日志信息
        /// </summary>
        public DataTable GetUserLogInfo_GeneralInfo(int fSize, int sSize, out int pageCount)
        {
            sb = new StringBuilder();
            sb.AppendFormat(SELECT_UserLog_GeneralInfo, sSize, fSize);
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    pageCount = (int)Conn.ExecuteScalar(SELECT_UserLog_GeneralInfo_Count);
                    table.Load(Conn.ExecuteReader(sb.ToString()));
                }
                return table;
            }
        }

        /// <summary>
        /// 添加用户日志信息
        /// </summary>
        /// <param name="userLogInfo">Happen_Time,Operation_Content,The_Operator,Terminal_ID,Notice_time,Receive_People,Current_State</param>
        /// <returns></returns>
        public int InsertUserLogInfo(UserLogInfo userLogInfo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Happen_Time", userLogInfo.Happen_Time);
            param.Add("@Operation_Content", userLogInfo.Operation_Content);
            param.Add("@The_Operator", userLogInfo.The_Operator);
            param.Add("@Terminal_ID", userLogInfo.Terminal_ID);
            param.Add("@Notice_time", userLogInfo.Notice_time);
            param.Add("@Receive_People", userLogInfo.Receive_People);
            param.Add("@Current_State", userLogInfo.Current_State);
            using (Conn)
            {
                return Conn.Execute(INSERT_UserLog, param);
            }
        }

        /// <summary>
        /// 删除用户日志信息
        /// </summary>
        public int DeleteUserLogInfo(string nowTime, int save_Day)
        {
            sb = new StringBuilder();
            sb.AppendFormat(DELETE_UserLog, nowTime, save_Day);
            using (Conn)
            {
                return Conn.Execute(sb.ToString());
            }
        }

        /// <summary>
        /// 更新用户日志信息
        /// </summary>
        /// <param name="userLogInfo">Processor,Process_Content,Process_Time,Current_State,Happen_Time</param>
        /// <returns></returns>
        public int UpdateUserLogInfo(UserLogInfo userLogInfo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Processor", userLogInfo.Processor);
            param.Add("@Process_Content", userLogInfo.Process_Content);
            param.Add("@Process_Time", userLogInfo.Process_Time);
            param.Add("@Current_State", userLogInfo.Current_State);
            param.Add("@Happen_Time", userLogInfo.Happen_Time);
            using (Conn)
            {
                return Conn.Execute(UPDATE_UserLog, param);
            }
        }
    }
}