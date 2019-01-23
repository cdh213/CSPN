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
    /// 上报信息
    /// </summary>
    public class ReportDAL : IReportDAL
    {
        #region Conn

        private IDbConnection Conn
        {
            get
            {
                return ConnectionFactory.CreateConnection();
            }
        }

        #endregion Conn

        private const string SELECT_ReportInfo = "select a.ReportInterval,b.Terminal_ID,b.Report_Time from CSPN_Report_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID";
        private const string SELECT_ReportNumInfo_NotReportTimes = "select a.Terminal_ID,Name,Longitude,Latitude,Place,Telephone,RealName from (CSPN_Well_Info as a inner join CSPN_Report_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Operator_Info as c on a.Operator_ID=c.Work_ID where NotReportTimes>=@NotReportTimes";
        private const string Update_ReportNumInfo_ReportTimes = "update CSPN_Report_Info set ReportTimes=ReportTimes+1 where Terminal_ID=@Terminal_ID";
        private const string Update_NotReportNumInfo_ReportTimes = "update CSPN_Report_Info set NotReportTimes=NotReportTimes+1 where Terminal_ID=@Terminal_ID";
        private const string Empty_ReportNumInfo_ReportTimes = "update CSPN_Report_Info set ReportTimes=0";
        private const string Empty_ReportNumInfo_NotReportTimes = "update CSPN_Report_Info set NotReportTimes=0 where Terminal_ID=@Terminal_ID";
        private const string Update_ReportInterval = "update CSPN_Report_Info set ReportInterval=@ReportInterval where Terminal_ID=@Terminal_ID";
        private const string Insert_WellInfo = "insert into CSPN_Report_Info(Terminal_ID,ReportInterval,ReportTimes,NotReportTimes) values(@Terminal_ID,@ReportInterval,0,0)";
        private const string Delete_WellInfo = "delete from CSPN_Report_Info where Terminal_ID=@Terminal_ID";

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
                return Conn.Execute(Update_NotReportNumInfo_ReportTimes, new { Terminal_ID = terminal_ID });
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