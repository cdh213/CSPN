using CSPN.Factory;
using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CSPN.IDAL;

namespace CSPN.DAL
{
    /// <summary>
    /// 人井当前状态
    /// </summary>
    public class WellCurrentStateDAL : IWellCurrentStateDAL
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

        private const string UPDATE_Well_Current_State = "update CSPN_Well_Current_State_Info set Well_State_ID=@Well_State_ID,Temperature=@Temperature,Humidity=@Humidity,Smoke_Detector=@Smoke_Detector,Smoke_Power=@Smoke_Power,Signal_Strength=@Signal_Strength,Report_Time=@Report_Time where Terminal_ID=@Terminal_ID";

        private const string UPDATE_Well_State_ID = "update CSPN_Well_Current_State_Info set Well_State_ID=@Well_State_ID where Terminal_ID=@Terminal_ID";

        private const string SELECT_WELL_INFO = "select Report_Time,Well_State_ID,a.Terminal_ID,Name,Place,Icon,RealName,Telephone from ((CSPN_Well_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on b.Well_State_ID=c.ID) inner join CSPN_Operator_Info as d on a.Operator_ID=d.ID where 1=1";

        private const string SELECT_WELL_INFO_Well_State_ID = "select Report_Time,Well_State_ID,a.Terminal_ID,Name,Place,Icon,Telephone from ((CSPN_Well_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on b.Well_State_ID=c.ID) inner join CSPN_Operator_Info as d on a.Operator_ID=d.ID where b.Well_State_ID=@Well_State_ID";
        private const string Insert_WellInfo = "insert into CSPN_Well_Current_State_Info(Terminal_ID,Well_State_ID) values(@Terminal_ID,@Well_State_ID)";
        private const string Delete_WellInfo = "delete from CSPN_Well_Current_State_Info where Terminal_ID=@Terminal_ID";

        const string select_Well_Appointment_Info = "select a.Terminal_ID,Name,Place,b.Terminal_ID,b.Well_State_ID,c.ID,State from (CSPN_Well_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on b.Well_State_ID=c.ID";
        const string updade_Well_Appointment_Info = "update CSPN_Well_Current_State_Info set Well_State_ID=@Well_State_ID where Terminal_ID=@Terminal_ID";

        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        public int UpdateWellCurrentStateInfo(int well_State_ID, string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(UPDATE_Well_State_ID, new { Well_State_ID = well_State_ID, Terminal_ID = terminal_ID });
            }
        }
        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        public int UpdateWellCurrentStateInfo(WellCurrentStateInfo wellCurrentStateInfo)
        {
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@Well_State_ID", wellCurrentStateInfo.Well_State_ID);
            parm.Add("@Temperature", wellCurrentStateInfo.Temperature);
            parm.Add("@Humidity", wellCurrentStateInfo.Humidity);
            parm.Add("@Smoke_Detector", wellCurrentStateInfo.Smoke_Detector);
            parm.Add("@Smoke_Power", wellCurrentStateInfo.Smoke_Power);
            parm.Add("@Signal_Strength", wellCurrentStateInfo.Signal_Strength);
            parm.Add("@Report_Time", wellCurrentStateInfo.Report_Time);
            parm.Add("@Terminal_ID", wellCurrentStateInfo.Terminal_ID);

            using (Conn)
            {
                return Conn.Execute(UPDATE_Well_Current_State, parm);
            }
        }
        /// <summary>
        /// 查询报警,状态信息
        /// </summary>
        public IList<WellCurrentStateInfo> GetAlarmInfo_StatusInfo()
        {
            StringBuilder sql = new StringBuilder(SELECT_WELL_INFO);
            sql.Append(" and b.Well_State_ID=2 or b.Well_State_ID=3");
            using (Conn)
            {
                return Conn.Query<WellCurrentStateInfo, WellInfo, WellStateInfo, OperatorInfo, WellCurrentStateInfo>(sql.ToString(), (a, b, c, d) => { a.WellInfo = b; a.WellStateInfo = c; a.OperatorInfo = d; return a; }, null, null, true, "Report_Time,Terminal_ID,Icon,RealName").ToList();
            }
        }
        /// <summary>
        /// 通过Terminal_ID查询报警,状态信息
        /// </summary>
        public WellCurrentStateInfo GetAlarmInfo_StatusInfo(string terminal_ID)
        {
            StringBuilder sql = new StringBuilder(SELECT_WELL_INFO);
            sql.AppendFormat(" and b.Well_State_ID=2 or b.Well_State_ID=4 and a.Terminal_ID='{0}'", terminal_ID);
            using (Conn)
            {
                return Conn.Query<WellCurrentStateInfo, WellInfo, WellStateInfo, OperatorInfo, WellCurrentStateInfo>(sql.ToString(), (a, b, c, d) => { a.WellInfo = b; a.WellStateInfo = c; a.OperatorInfo = d; return a; }, null, null, true, "Report_Time,Terminal_ID,Icon,RealName").SingleOrDefault();
            }
        }
        /// <summary>
        /// 通过Well_State_ID，Terminal_ID查询报警,状态信息
        /// </summary>
        public WellCurrentStateInfo GetAlarmInfo_StatusInfo(int well_State_ID, string terminal_ID)
        {
            StringBuilder sql = new StringBuilder(SELECT_WELL_INFO);
            sql.AppendFormat(" and b.Well_State_ID={0} and a.Terminal_ID='{1}'", well_State_ID, terminal_ID);
            using (Conn)
            {
                return Conn.Query<WellCurrentStateInfo, WellInfo, WellStateInfo, OperatorInfo, WellCurrentStateInfo>(sql.ToString(), (a, b, c, d) => { a.WellInfo = b; a.WellStateInfo = c; a.OperatorInfo = d; return a; }, null, null, true, "Report_Time,Terminal_ID,Icon,RealName").SingleOrDefault();
            }
        }
        /// <summary>
        /// 查询已处理信息
        /// </summary>
        public IList<WellCurrentStateInfo> GetProcessedInfoByWell_State_ID(int well_State_ID)
        {
            using (Conn)
            {
                return Conn.Query<WellCurrentStateInfo, WellInfo, WellStateInfo, OperatorInfo, WellCurrentStateInfo>(SELECT_WELL_INFO_Well_State_ID, (a, b, c, d) => { a.WellInfo = b; a.WellStateInfo = c; a.OperatorInfo = d; return a; }, new { Well_State_ID = well_State_ID }, null, true, "Report_Time,Terminal_ID,Icon,Telephone").ToList();
            }
        }
        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertWellCurrentStateInfo(string terminal_ID, int well_State_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Insert_WellInfo, new { Terminal_ID = terminal_ID, Well_State_ID = well_State_ID });
            }
        }
        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteWellCurrentStateInfo(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Delete_WellInfo, new { Terminal_ID = terminal_ID });
            }
        }

        #region 维护信息
        /// <summary>
        /// 加载维护信息
        /// </summary>
        public DataTable GetAppointmentInfo()
        {
            DataTable table = new DataTable();
            using (Conn)
            {
                table.Load(Conn.ExecuteReader(select_Well_Appointment_Info));
            }
            return table;
        }
        /// <summary>
        /// 维护信息更新
        /// </summary>
        public int UpdateAppointmentInfo(int well_State_ID, string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(updade_Well_Appointment_Info, new { Well_State_ID = well_State_ID, Terminal_ID = terminal_ID });
            }
        }
        #endregion
    }
}
