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
    public class SystemLogDAL : ISystemLogDAL
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

        private const string SELECT = "select Happen_Time,a.Terminal_ID,Name,Place,Well_State,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength from (CSPN_System_Log_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on a.Well_State=c.State order by Happen_Time desc";
        private const string SELECT_SystemLog = "select Happen_Time,a.Terminal_ID,Name,Place,Well_State,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength from (CSPN_System_Log_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on a.Well_State=c.State where Happen_Time between (select min(Happen_Time) from (select top {0} Happen_Time from CSPN_System_Log_Info order by Happen_Time desc)) and (select min(Happen_Time) from (select top {1} Happen_Time from CSPN_System_Log_Info order by Happen_Time desc)) order by Happen_Time desc";
        private const string SELECT_SystemLog_Count = "select count(*) from CSPN_System_Log_Info";
        private const string SELECT_MinHappen_Time = "select min(Happen_Time) from CSPN_System_Log_Info";
        private const string INSERT_SystemLog = "insert into CSPN_System_Log_Info(Happen_Time,Terminal_ID,Well_State,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength) values(@Happen_Time,@Terminal_ID,@Well_State,@Electricity,@Temperature,@Humidity,@Smoke_Detector,@Smoke_Power,@Signal_Strength)";
        private const string DELETE_SystemLog = "delete from CSPN_System_Log_Info where DateDiff('d',format(Happen_Time,'yyyy/mm/dd'),@NowTime)>=@Save_Day";

        StringBuilder sb = null;
        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        public DataTable GetSystemLogInfo()
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT));
                }
                return table;
            }
        }
        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        public DataTable GetSystemLogInfo(int fSize, int sSize, out int pageCount)
        {
            sb = new StringBuilder();
            sb.AppendFormat(SELECT_SystemLog, sSize, fSize);
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    pageCount = (int)Conn.ExecuteScalar(SELECT_SystemLog_Count);
                    table.Load(Conn.ExecuteReader(sb.ToString()));
                }
                return table;
            }
        }
        /// <summary>
        /// 查询发生时间的最小值
        /// </summary>
        public DateTime GetMinHappen_Time()
        {
            using (Conn)
            {
                return DateTime.Parse(Conn.ExecuteScalar(SELECT_MinHappen_Time).ToString());
            }
        }
        /// <summary>
        /// 添加系统日志信息
        /// </summary>
        public int InsertSystemLogInfo(SystemLogInfo sysLog)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Happen_Time", sysLog.Happen_Time);
            param.Add("@Terminal_ID", sysLog.Terminal_ID);
            param.Add("@Well_State", sysLog.Well_State);
            param.Add("@Electricity", sysLog.Electricity);
            param.Add("@Temperature", sysLog.Temperature);
            param.Add("@Humidity", sysLog.Humidity);
            param.Add("@Smoke_Detector", sysLog.Smoke_Detector);
            param.Add("@Smoke_Power", sysLog.Smoke_Power);
            param.Add("@Signal_Strength", sysLog.Signal_Strength);
            using (Conn)
            {
                return Conn.Execute(INSERT_SystemLog, param);
            }
        }

        /// <summary>
        /// 删除系统日志信息
        /// </summary>
        public int DeleteSystemLogInfo(string nowTime, int save_Day)
        {
            using (Conn)
            {
                return Conn.Execute(DELETE_SystemLog, new { NowTime = nowTime, Save_Day = save_Day });
            }
        }
    }
}
