using CSPN.Factory;
using CSPN.Model;
using System.Data;
using System.Text;
using CSPN.IDAL;
using Dapper;
using System;

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
        #endregion

        private const string SELECT_UserLogWellInfo = "select Happen_Time, The_Operator,Operation_Content,Receive_People,Notice_time,Processor,Process_Content,Process_Time,Current_State from CSPN_User_Log_Info where Notice_time is not null order by Happen_Time desc";
        private const string SELECT_UserLog_WellInfo = "select * from (select * from CSPN_User_Log_Info where Notice_time is not null) where Happen_Time between (select min(Happen_Time) from (select top {0} Happen_Time from (select * from CSPN_User_Log_Info where Notice_time is not null) order by Happen_Time desc)) and (select min(Happen_Time) from (select top {1} Happen_Time from (select * from CSPN_User_Log_Info where Notice_time is not null) order by Happen_Time desc)) order by Happen_Time desc";
        private const string SELECT_UserLog_WellInfo_Count = "select count(*) from CSPN_User_Log_Info where Notice_time is not null";
        private const string SELECT_UserLogGeneralInfo = "select Happen_Time,The_Operator,Operation_Content from CSPN_User_Log_Info where Notice_time is null order by Happen_Time desc";
        private const string SELECT_UserLog_GeneralInfo = "select Happen_Time,The_Operator,Operation_Content from (select * from CSPN_User_Log_Info where Notice_time is null) where Happen_Time between (select min(Happen_Time) from (select top {0} Happen_Time from (select * from CSPN_User_Log_Info where Notice_time is null) order by Happen_Time desc)) and (select min(Happen_Time) from (select top {1} Happen_Time from (select * from CSPN_User_Log_Info where Notice_time is null) order by Happen_Time desc)) order by Happen_Time desc";
        private const string SELECT_UserLog_GeneralInfo_Count = "select count(*) from CSPN_User_Log_Info where Notice_time is null";
        private const string SELECT_MinHappen_Time = "select min(Happen_Time) from CSPN_User_Log_Info";
        private const string INSERT_UserLog = "insert into CSPN_User_Log_Info(Happen_Time,Operation_Content,The_Operator,Notice_time,Receive_People,Current_State) values (@Happen_Time,@Operation_Content,@The_Operator,@Notice_time,@Receive_People,@Current_State)";
        private const string DELETE_UserLog = "delete from CSPN_User_Log_Info where DateDiff('d',format(Happen_Time,'yyyy/mm/dd'),'{0}')>={1}";
        private const string UPDATE_UserLog = "update CSPN_User_Log_Info set Processor=@Processor,Process_Content=@Process_Content,Process_Time=@Process_Time,Current_State=@Current_State where Happen_Time=@Happen_Time";

        StringBuilder sb = null;
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
        /// 查询发生时间的最小值
        /// </summary>
        public DateTime GetMinHappen_Time_UserLog()
        {
            using (Conn)
            {
                return DateTime.Parse(Conn.ExecuteScalar(SELECT_MinHappen_Time).ToString());
            }
        }
        /// <summary>
        /// 添加用户日志信息
        /// </summary>
        public int InsertUserLogInfo(UserLogInfo userLog)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Happen_Time", userLog.Happen_Time);
            param.Add("@Operation_Content", userLog.Operation_Content);
            param.Add("@The_Operator", userLog.The_Operator);
            param.Add("@Notice_time", userLog.Notice_time);
            param.Add("@Receive_People", userLog.Receive_People);
            param.Add("@Current_State", userLog.Current_State);
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
        public int UpdateUserLogInfo(UserLogInfo userLog)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Processor", userLog.Processor);
            param.Add("@Process_Content", userLog.Process_Content);
            param.Add("@Process_Time", userLog.Process_Time);
            param.Add("@Current_State", userLog.Current_State);
            param.Add("@Happen_Time", userLog.Happen_Time);
            using (Conn)
            {
                return Conn.Execute(UPDATE_UserLog, param);
            }
        }
    }
}
