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
    /// 人井报警信息
    /// </summary>
    public class AlarmInfoDAL : IAlarmInfoDAL
    {
        #region Conn
        public IDbConnection Conn
        {
            get
            {
                return ConnectionFactory.CreateConnection();
            }
        }
        #endregion

        private const string SELECT_AlarmInfo_StatusInfo1 = "select Report_Time,b.Terminal_ID,Name,Well_State_ID,Place,Icon,Telephone from ((CSPN_Well_Info as a inner join CSPN_Alarm_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on b.Well_State_ID=c.ID) inner join CSPN_Operator_Info as d on a.Operator_ID=d.ID where b.Well_State_ID=2 or b.Well_State_ID=3 or b.Well_State_ID=4 or b.Well_State_ID=5 order by Report_Time desc";
        private const string SELECT_AlarmInfo_StatusInfo2 = "select Report_Time,Place,RealName,Telephone from (CSPN_Well_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Operator_Info as c on a.Operator_ID=c.ID where b.Well_State_ID=@Well_State_ID and a.Terminal_ID=@Terminal_ID";
        private const string Insert_AlarmInfo = "insert into CSPN_Alarm_Info(Report_Time,Terminal_ID,Well_State_ID) values(@Report_Time,@Terminal_ID,@Well_State_ID)";
        private const string Delete_AlarmInfo = "delete from CSPN_Alarm_Info where Report_Time=@Report_Time";
        private const string UPDATE_AlarmInfo = "update CSPN_Alarm_Info set Well_State_ID=@Well_State_ID where Report_Time=@Report_Time";
        private const string SELECT_ProcessedInfo = "select Report_Time,b.Terminal_ID,Name,Well_State_ID,Place,Icon,RealName from ((CSPN_Well_Info as a inner join CSPN_Alarm_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on b.Well_State_ID=c.ID) inner join CSPN_Operator_Info as d on a.Operator_ID=d.ID where b.Well_State_ID=7 order by Report_Time desc";

        /// <summary>
        /// 查询报警,状态信息
        /// </summary>
        public DataTable GetAlarmInfo_StatusInfo()
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT_AlarmInfo_StatusInfo1));
                }
                return table;
            }
        }
        /// <summary>
        /// 通过Terminal_ID查询报警,状态信息
        /// </summary>
        public AlarmInfo GetAlarmInfo_StatusInfo(int well_State_ID, string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Query<AlarmInfo, WellInfo, OperatorInfo, AlarmInfo>(SELECT_AlarmInfo_StatusInfo2, (a, b, c) => { a.WellInfo = b; a.OperatorInfo = c; return a; }, new { Well_State_ID = well_State_ID, Terminal_ID = terminal_ID }, null, true, "Report_Time,Place,RealName").SingleOrDefault();
            }
        }
        /// <summary>
        /// 查询已处理信息
        /// </summary>
        public DataTable GetProcessedInfo()
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT_ProcessedInfo));
                }
                return table;
            }
        }
        /// <summary>
        /// 增加报警、状态信息
        /// </summary>
        public int InsertAlarmInfo(AlarmInfo alarmInfo)
        {
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@Report_Time", alarmInfo.Report_Time);
            parm.Add("@Terminal_ID", alarmInfo.Terminal_ID);
            parm.Add("@Well_State_ID", alarmInfo.Well_State_ID);

            using (Conn)
            {
                return Conn.Execute(Insert_AlarmInfo, parm);
            }
        }
        /// <summary>
        /// 删除报警、状态信息
        /// </summary>
        public int DeleteAlarmInfo(string report_Time)
        {
            using (Conn)
            {
                return Conn.Execute(Delete_AlarmInfo, new { Report_Time = report_Time });
            }
        }
        /// <summary>
        /// 更新报警、状态信息
        /// </summary>
        public int UpdateAlarmInfo(int well_State_ID, string report_Time)
        {

            using (Conn)
            {
                return Conn.Execute(UPDATE_AlarmInfo, new { Well_State_ID = well_State_ID, Report_Time = report_Time });
            }
        }
    }
}
