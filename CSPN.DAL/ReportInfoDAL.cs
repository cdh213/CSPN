using CSPN.Factory;
using CSPN.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CSPN.IDAL;

namespace CSPN.DAL
{
    /// <summary>
    /// 上报信息
    /// </summary>
    public class ReportInfoDAL : IReportInfoDAL
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

        private const string SELECT_ReportInfo_Pending = "select Report_Time,b.Terminal_ID,Name,Well_State_ID_Pending,Place,Icon,Telephone from ((CSPN_Well_Info as a inner join CSPN_Report_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on b.Well_State_ID_Pending=c.ID) inner join CSPN_Operator_Info as d on a.Operator_ID=d.ID where b.Well_State_ID_Pending=2 or b.Well_State_ID_Pending=3 or b.Well_State_ID_Pending=4 or b.Well_State_ID_Pending=5 order by Report_Time desc,Well_State_ID_Pending asc";
        private const string SELECT_ReportInfo_Send = "select Report_Time,b.Terminal_ID,Name,Well_State_ID_Send,Place,Icon,RealName from ((CSPN_Well_Info as a inner join CSPN_Report_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on b.Well_State_ID_Send=c.ID) inner join CSPN_Operator_Info as d on a.Operator_ID=d.ID where b.Well_State_ID_Send=7 order by Report_Time desc";
        private const string SELECT_ReportInfo_Terminal_ID = "select Report_Time,Place,RealName,Telephone from (CSPN_Well_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Operator_Info as c on a.Operator_ID=c.ID where b.Well_State_ID=@Well_State_ID and a.Terminal_ID=@Terminal_ID";
        private const string UPDATE_ReportInfo_Pending1 = "update CSPN_Report_Info set Well_State_ID_Pending=@Well_State_ID_Pending where Terminal_ID=@Terminal_ID";
        private const string UPDATE_ReportInfo_Pending2 = "update CSPN_Report_Info set Well_State_ID_Pending=@Well_State_ID_Pending,Report_Time=@Report_Time where Terminal_ID=@Terminal_ID";
        private const string UPDATE_ReportInfo_Send = "update CSPN_Report_Info set Well_State_ID_Send=@Well_State_ID_Send where Terminal_ID=@Terminal_ID";
        private const string SELECT_ReportInfo = "select a.ReportInterval,b.Terminal_ID,b.Report_Time from CSPN_Report_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID";
        private const string SELECT_ReportNumInfo_NotReportTimes = "select a.Terminal_ID,Name,Longitude,Latitude,Place,Telephone from (CSPN_Well_Info as a inner join CSPN_Report_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Operator_Info as c on a.Operator_ID=c.ID where NotReportTimes>=@NotReportTimes";
        private const string Update_ReportNumInfo_ReportTimes = "update CSPN_Report_Info set ReportTimes=ReportTimes+1 where Terminal_ID=@Terminal_ID";
        private const string Update_NotReportNumInfo_ReportTimes = "update CSPN_Report_Info set NotReportTimes=NotReportTimes+1 where Terminal_ID=@Terminal_ID";
        private const string Empty_ReportNumInfo_ReportTimes = "update CSPN_Report_Info set ReportTimes=0";
        private const string Empty_ReportNumInfo_NotReportTimes = "update CSPN_Report_Info set NotReportTimes=0 where Terminal_ID=@Terminal_ID";
        private const string Update_ReportInterval = "update CSPN_Report_Info set ReportInterval=@ReportInterval where Terminal_ID=@Terminal_ID";
        private const string Insert_WellInfo = "insert into CSPN_Report_Info(Terminal_ID,Well_State_ID_Pending,Well_State_ID_Send,ReportInterval,ReportTimes,NotReportTimes) values(@Terminal_ID,1,1,@ReportInterval,0,0)";
        private const string Delete_WellInfo = "delete from CSPN_Report_Info where Terminal_ID=@Terminal_ID";

        /// <summary>
        /// 查询待处理信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetReportInfo_Pending()
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT_ReportInfo_Pending));
                }
                return table;
            }
        }
        /// <summary>
        /// 查询已通知信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetReportInfo_Send()
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT_ReportInfo_Send));
                }
                return table;
            }
        }
        /// <summary>
        /// 通过Terminal_ID查询信息
        /// </summary>
        public ReportInfo GetReportInfo_Terminal_ID(int well_State_ID, string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Query<ReportInfo, WellInfo, OperatorInfo, ReportInfo>(SELECT_ReportInfo_Terminal_ID, (a, b, c) => { a.WellInfo = b; a.OperatorInfo = c; return a; }, new { Well_State_ID = well_State_ID, Terminal_ID = terminal_ID }, null, true, "Report_Time,Place,RealName").FirstOrDefault();
            }
        }
        /// <summary>
        /// 更新待处理信息
        /// </summary>
        /// <returns></returns>
        public int UpdateReportInfo_Pending(int well_State_ID_Pending, string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(UPDATE_ReportInfo_Pending1, new { Well_State_ID_Pending = well_State_ID_Pending, Terminal_ID = terminal_ID });
            }
        }
        /// <summary>
        /// 更新待处理信息
        /// </summary>
        /// <returns></returns>
        public int UpdateReportInfo_Pending(ReportInfo reportInfo)
        {
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@Well_State_ID_Pending", reportInfo.Well_State_ID_Pending);
            parm.Add("@Report_Time", reportInfo.Report_Time);
            parm.Add("@Terminal_ID", reportInfo.Terminal_ID);
            using (Conn)
            {
                return Conn.Execute(UPDATE_ReportInfo_Pending2, parm);
            }
        }
        /// <summary>
        /// 更新已通知信息
        /// </summary>
        /// <returns></returns>
        public int UpdateReportInfo_Send(int well_State_ID_Send, string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(UPDATE_ReportInfo_Send, new { Well_State_ID_Send = well_State_ID_Send, Terminal_ID = terminal_ID });
            }
        }
        /// <summary>
        /// 查询上报人井信息
        /// </summary>
        public List<ReportInfo> GetReportInfo()
        {
            using (Conn)
            {
                return Conn.Query<ReportInfo, WellCurrentStateInfo, ReportInfo>(SELECT_ReportInfo, (a, b) => { a.WellCurrentStateInfo = b; return a; }, null, null, true, "Terminal_ID").ToList();
            }
        }
        /// <summary>
        /// 查询未上报人井信息
        /// </summary>
        public DataTable GetNotReportNumInfo(int notReportTimes)
        {
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    table.Load(Conn.ExecuteReader(SELECT_ReportNumInfo_NotReportTimes, new { NotReportTimes = notReportTimes }));
                }
                return table;
            }
        }
        /// <summary>
        /// 重置上报次数
        /// </summary>
        public int Empty_ReportNumInfo()
        {
            using (Conn)
            {
                return Conn.Execute(Empty_ReportNumInfo_ReportTimes);
            }
        }
        /// <summary>
        /// 重置未上报次数
        /// </summary>
        public int Empty_NotReportNumInfo(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Empty_ReportNumInfo_NotReportTimes, new { Terminal_ID = terminal_ID });
            }
        }
        /// <summary>
        /// 更新人井上报次数
        /// </summary>
        public int UpdateReportTimes(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Update_ReportNumInfo_ReportTimes, new { Terminal_ID = terminal_ID });
            }
        }
        /// <summary>
        /// 更新人井上未报次数
        /// </summary>
        public int UpdateNotReportTimes(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Update_NotReportNumInfo_ReportTimes,new { Terminal_ID = terminal_ID });
            }
        }
        /// <summary>
        /// 更新人井上未时间间隔
        /// </summary>
        public int UpdateReportInterval(int reportInterval, string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Update_ReportInterval, new { ReportInterval = reportInterval, Terminal_ID = terminal_ID });
            }
        }
        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertReportInfo(string terminal_ID, int reportInterval)
        {
            using (Conn)
            {
                return Conn.Execute(Insert_WellInfo, new { Terminal_ID = terminal_ID, ReportInterval = reportInterval });
            }
        }
        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteReportInfo(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Delete_WellInfo, new { Terminal_ID = terminal_ID });
            }
        }
    }
}
