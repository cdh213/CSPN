using CSPN.Factory;
using CSPN.IDAL;
using CSPN.Model;
using Dapper;
using System.Data;
using System.Text;

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

        #endregion Conn

        private const string SELECT = "select Happen_Time,a.Terminal_ID,Name,Place,State,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength from (CSPN_System_Log_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on a.Well_State_ID=c.ID order by Happen_Time desc";
        private const string SELECT_SystemLog = "select Happen_Time,a.Terminal_ID,Name,Place,iif(State='人井关闭电量正常','人井关闭','人井关闭') as cState,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength from (CSPN_System_Log_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on a.Well_State_ID=c.ID where Happen_Time between (select min(Happen_Time) from (select top {0} Happen_Time from CSPN_System_Log_Info order by Happen_Time desc)) and (select min(Happen_Time) from (select top {1} Happen_Time from CSPN_System_Log_Info order by Happen_Time desc)) order by Happen_Time desc";
        private const string SELECT_SystemLog_Count = "select count(*) from CSPN_System_Log_Info";
        private const string INSERT_SystemLog = "insert into CSPN_System_Log_Info(Happen_Time,Terminal_ID,Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength) values(@Happen_Time,@Terminal_ID,@Well_State_ID,@Electricity,@Temperature,@Humidity,@Smoke_Detector,@Smoke_Power,@Signal_Strength)";
        private const string DELETE_SystemLog = "delete from CSPN_System_Log_Info where DateDiff('d',format(Happen_Time,'yyyy/mm/dd'),'{0}')>={1}";

        private StringBuilder sb = null;

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
        /// 添加系统日志信息
        /// </summary>
        /// <param name="systemLogInfo">Happen_Time,Terminal_ID,Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength</param>
        /// <returns></returns>
        public int InsertSystemLogInfo(SystemLogInfo systemLogInfo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Happen_Time", systemLogInfo.Happen_Time);
            param.Add("@Terminal_ID", systemLogInfo.Terminal_ID);
            param.Add("@Well_State_ID", systemLogInfo.Well_State_ID);
            param.Add("@Electricity", systemLogInfo.Electricity);
            param.Add("@Temperature", systemLogInfo.Temperature);
            param.Add("@Humidity", systemLogInfo.Humidity);
            param.Add("@Smoke_Detector", systemLogInfo.Smoke_Detector);
            param.Add("@Smoke_Power", systemLogInfo.Smoke_Power);
            param.Add("@Signal_Strength", systemLogInfo.Signal_Strength);
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
            sb = new StringBuilder();
            sb.AppendFormat(DELETE_SystemLog, nowTime, save_Day);
            using (Conn)
            {
                return Conn.Execute(sb.ToString());
            }
        }
    }
}