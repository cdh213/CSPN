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
    public class SystemLogDAL:ISystemLogDAL
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

        private const string SELECT_SystemLog = "select Happen_Time,a.Terminal_ID,Name,Place,Well_State,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength from (CSPN_System_Log_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on a.Well_State=c.State";
        private const string INSERT_SystemLog = "insert into CSPN_System_Log_Info(Happen_Time,Terminal_ID,Well_State,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength) values(@Happen_Time,@Terminal_ID,@Well_State,@Temperature,@Humidity,@Smoke_Detector,@Smoke_Power,@Signal_Strength)";
        private const string DELETE_SystemLog = "delete from CSPN_System_Log_Info where DateDiff('d',format(Happen_Time,'yyyy/mm/dd'),@NowTime)>=@Save_Day";

        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        public DataTable GetSystemLogInfo()
        {
            DataTable table = new DataTable();
            using (Conn)
            {
                table.Load(Conn.ExecuteReader(SELECT_SystemLog));
            }
            return table;
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
        public int DeleteSystemLogInfo(string nowTime,int save_Day)
        {
            using (Conn)
            {
                return Conn.Execute(DELETE_SystemLog, new { NowTime = nowTime, Save_Day = save_Day });
            }
        }
    }
}
