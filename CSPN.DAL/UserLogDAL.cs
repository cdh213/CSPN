using CSPN.Factory;
using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSPN.IDAL;
using Dapper;
using System.Data.SqlClient;

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
        private const string SELECT_UserLog_WellInfo = "select Happen_Time, The_Operator,Operation_Content,Receive_People,Notice_time,Processor,Process_Content,Process_Time,Current_State from CSPN_User_Log_Info where Notice_time is not null order by Happen_Time desc";
        private const string SELECT_UserLog_GeneralInfo = "select Happen_Time,The_Operator,Operation_Content from CSPN_User_Log_Info where Notice_time is null order by Happen_Time desc";
        private const string INSERT_UserLog = "insert into CSPN_User_Log_Info(Happen_Time,Operation_Content,The_Operator,Notice_time,Receive_People,Current_State) values (@Happen_Time,@Operation_Content,@The_Operator,@Notice_time,@Receive_People,@Current_State)";
        private const string DELETE_UserLog = "delete from CSPN_User_Log_Info where DateDiff('d',format(Happen_Time,'yyyy/mm/dd'),@NowTime)>=@Save_Day";
        private const string UPDATE_UserLog = "update CSPN_User_Log_Info set Processor=@Processor,Process_Content=@Process_Content,Process_Time=@Process_Time,Current_State=@Current_State where Happen_Time=@Happen_Time";

       /// <summary>
       /// 查询用户日志信息
       /// </summary>
        public DataTable GetUserLogInfo_WellInfo() 
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT_UserLog_WellInfo));
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
                    table.Load(Conn.ExecuteReader(SELECT_UserLog_GeneralInfo));
                }
                return table;
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
            using (Conn)
            {
                return Conn.Execute(DELETE_UserLog, new { Save_Day = save_Day, NowTime = nowTime });
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
