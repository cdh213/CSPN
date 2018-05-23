using CSPN.Factory;
using CSPN.IDAL;
using CSPN.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CSPN.DAL
{
    /// <summary>
    /// 人井当前状态
    /// </summary>
    public class WellCurrentStateDAL : IWellCurrentStateDAL
    {
        #region Conn

        public IDbConnection Conn
        {
            get
            {
                return ConnectionFactory.CreateConnection();
            }
        }

        #endregion Conn

        private const string SELECT_Alarm_Info1 = "select Report_Time,b.Terminal_ID,Well_State_ID,Name,Place,Icon,Telephone,RealName from ((CSPN_Well_Current_State_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on a.Well_State_ID=c.ID) inner join CSPN_Operator_Info as d on b.Operator_ID=d.ID where Well_State_ID=2 or Well_State_ID=3 or Well_State_ID=4 or Well_State_ID=5 order by Report_Time desc,Well_State_ID asc";
        private const string SELECT_Alarm_Info2 = "select Report_Time,a.Terminal_ID,Well_State_ID,Name,Place,RealName,Telephone,ReceiveMsg from (CSPN_Well_Current_State_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Operator_Info as c on b.Operator_ID=c.ID where Well_State_ID=2 or Well_State_ID=3 or Well_State_ID=4 or Well_State_ID=5 order by Report_Time desc,Well_State_ID asc";
        private const string SELECT_Notice_Info = "select Report_Time,b.Terminal_ID,Well_State_ID,Name,Place,Icon,RealName from ((CSPN_Well_Current_State_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on a.Well_State_ID=c.ID) inner join CSPN_Operator_Info as d on b.Operator_ID=d.ID where Well_State_ID=7 order by Report_Time desc";
        private const string SELECT_Well_Current_State_Info = "select Report_Time,Place,RealName,Telephone from (CSPN_Well_Current_State_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Operator_Info as c on b.Operator_ID=c.ID where Well_State_ID=@Well_State_ID and a.Terminal_ID=@Terminal_ID";
        private const string UPDATE_Well_Current_State = "update CSPN_Well_Current_State_Info set Well_State_ID=@Well_State_ID,Electricity=@Electricity,Temperature=@Temperature,Humidity=@Humidity,Smoke_Detector=@Smoke_Detector,Smoke_Power=@Smoke_Power,Signal_Strength=@Signal_Strength,Report_Time=@Report_Time where Terminal_ID=@Terminal_ID";
        private const string UPDATE_Well_State_ID = "update CSPN_Well_Current_State_Info set Well_State_ID=@Well_State_ID where Terminal_ID=@Terminal_ID";
        private const string Insert_WellInfo = "insert into CSPN_Well_Current_State_Info(Terminal_ID,Well_State_ID) values(@Terminal_ID,@Well_State_ID)";
        private const string Delete_WellInfo = "delete from CSPN_Well_Current_State_Info where Terminal_ID=@Terminal_ID";

        /// <summary>
        /// 查询报警信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAlarmInfo()
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT_Alarm_Info1));
                }
                return table;
            }
        }

        /// <summary>
        /// 查询报警信息
        /// </summary>
        /// <returns></returns>
        public List<WellCurrentStateInfo> GetAlarmInfoList()
        {
            using (Conn)
            {
                return Conn.Query<WellCurrentStateInfo, WellInfo, OperatorInfo, WellCurrentStateInfo>(SELECT_Alarm_Info2, (a, b, c) => { a.WellInfo = b; a.OperatorInfo = c; return a; }, null, null, true, "Report_Time,Name,RealName").ToList();
            }
        }

        /// <summary>
        /// 查询已通知信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetNoticeInfo()
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT_Notice_Info));
                }
                return table;
            }
        }

        /// <summary>
        /// 通过Well_State_ID,Terminal_ID查询信息
        /// </summary>
        public WellCurrentStateInfo GetWellCurrentStateInfo(int well_State_ID, string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Query<WellCurrentStateInfo, WellInfo, OperatorInfo, WellCurrentStateInfo>(SELECT_Well_Current_State_Info, (a, b, c) => { a.WellInfo = b; a.OperatorInfo = c; return a; }, new { Well_State_ID = well_State_ID, Terminal_ID = terminal_ID }, null, true, "Report_Time,Place,RealName").FirstOrDefault();
            }
        }

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
        /// <param name="wellCurrentStateInfo">Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength,Report_Time,Terminal_ID</param>
        /// <returns></returns>
        public int UpdateWellCurrentStateInfo(WellCurrentStateInfo wellCurrentStateInfo)
        {
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@Well_State_ID", wellCurrentStateInfo.Well_State_ID);
            parm.Add("@Electricity", wellCurrentStateInfo.Electricity);
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
    }
}