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
    public class ReportNumInfoDAL : IReportNumInfoDAL
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

        const string SELECT_ReportNumInfo_ReportTimes = "select a.Terminal_ID,Name,Longitude,Latitude,Place,ReportTimes,Telephone from (CSPN_Well_Info as a inner join CSPN_ReportNumInfo as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Operator_Info as c on a.Operator_ID=c.ID where ReportTimes>=@ReportTimes";
        const string Update_ReportNumInfo_ReportTimes = "update CSPN_ReportNumInfo set ReportTimes=ReportTimes+1 where Terminal_ID=@Terminal_ID";
        const string Update_NotReportNumInfo_ReportTimes = "update CSPN_ReportNumInfo set NotReportTimes=NotReportTimes+1 where ReportTimes=0";
        const string Empty_ReportNumInfo_ReportTimes = "update CSPN_ReportNumInfo set ReportTimes=0 where ReportTimes>0";

        const string Insert_WellInfo = "insert into CSPN_ReportNumInfo(Terminal_ID,ReportTimes,NotReportTimes) values(@Terminal_ID,0,0)";
        const string Delete_WellInfo = "delete from CSPN_ReportNumInfo where Terminal_ID=@Terminal_ID";

        /// <summary>
        /// 查询未上报人井信息
        /// </summary>
        public IList<ReportNumInfo> GetNotReportNumInfo(int reportTimes)
        {
            using (Conn)
            {
                return Conn.Query<WellInfo, ReportNumInfo, OperatorInfo, ReportNumInfo>(SELECT_ReportNumInfo_ReportTimes, (a, b, c) => { b.WellInfo = a; b.OperatorInfo = c; return b; }, new { ReportTimes = reportTimes }, null, true, "Terminal_ID,ReportTimes,Telephone", null, null).ToList();
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
        public int UpdateNotReportTimes()
        {
            using (Conn)
            {
                return Conn.Execute(Update_NotReportNumInfo_ReportTimes);
            }
        }
        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertReportNumInfo(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Insert_WellInfo, new { Terminal_ID = terminal_ID });
            }
        }
        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteReportNumInfo(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Delete_WellInfo, new { Terminal_ID = terminal_ID });
            }
        }
    }
}
