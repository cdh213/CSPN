using CSPN.Factory;
using CSPN.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using CSPN.IDAL;

namespace CSPN.DAL
{
    
    /// <summary>
    /// 主页人井信息
    /// </summary>
    public class WellInfoDAL :IWellInfoDAL
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

        const string select_WellInfo_Table = "select a.Terminal_ID,Name,Longitude,Latitude,Place,Terminal_Phone,Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength,Icon,Color,ReportInterval,Work_ID,RealName,Telephone from (((CSPN_Well_Info as a inner join CSPN_Operator_Info as b on a.Operator_ID=b.ID) inner join CSPN_Well_Current_State_Info as c on a.Terminal_ID=c.Terminal_ID) inner join CSPN_Dic_Well_State_Info as d on c.Well_State_ID=d.ID) inner join CSPN_Report_Info as e on a.Terminal_ID=e.Terminal_ID where a.Terminal_ID between (select max(a.Terminal_ID) from (select top {0} a.Terminal_ID from CSPN_Well_Info as a order by a.Terminal_ID asc)) and (select max(a.Terminal_ID) from (select top {1} a.Terminal_ID from CSPN_Well_Info as a order by a.Terminal_ID asc)) order by a.Terminal_ID asc";
        const string select_WellInfo_Count = "select count(*) from CSPN_Well_Info where 1=1";
        const string select_WellInfo = "select a.Terminal_ID,Name,Longitude,Latitude,Place,Terminal_Phone,c.Terminal_ID as cTerminal_ID,Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength,d.ID,Icon,Color,e.Terminal_ID as eTerminal_ID,ReportInterval,Work_ID,RealName,Telephone from (((CSPN_Well_Info as a inner join CSPN_Operator_Info as b on a.Operator_ID=b.ID) inner join CSPN_Well_Current_State_Info as c on a.Terminal_ID=c.Terminal_ID) inner join CSPN_Dic_Well_State_Info as d on c.Well_State_ID=d.ID) inner join CSPN_Report_Info as e on a.Terminal_ID=e.Terminal_ID where 1=1";
        const string query_WellInfo_Terminal_ID = "select a.Terminal_ID as Terminal_ID,Name,Longitude,Latitude,Place,Terminal_Phone,[State],RealName,e.Terminal_ID,ReportInterval from (((CSPN_Well_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on b.Well_State_ID=c.ID) inner join CSPN_Operator_Info as d on a.Operator_ID=d.ID) inner join CSPN_Report_Info as e on a.Terminal_ID=e.Terminal_ID where a.Terminal_ID=@Terminal_ID";
        const string query_WellInfo_Terminal_Phone = "select a.*,b.Well_State_ID from CSPN_Well_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID where Terminal_Phone=@Terminal_Phone";
        const string update_WellInfo_Terminal_ID = "update CSPN_Well_Info set Name=@Name,Longitude=@Longitude,Latitude=@Latitude,Place=@Place,Operator_ID=@Operator_ID,Terminal_Phone=@Terminal_Phone where Terminal_ID=@Terminal_ID";
        const string Insert_WellInfo = "insert into CSPN_Well_Info(Terminal_ID,Name,Longitude,Latitude,Place,Operator_ID,Terminal_Phone) values(@Terminal_ID,@Name,@Longitude,@Latitude,@Place,@Operator_ID,@Terminal_Phone)";
        const string Delete_WellInfo = "delete from CSPN_Well_Info where Terminal_ID=@Terminal_ID";

        StringBuilder sb = null;
        StringBuilder count = null;
        /// <summary>
        /// 查询人井信息
        /// </summary>
        public DataTable GetWellInfo_Table(string wellinfo,int fSize,int sSize,out int pageCount)
        {
            using (DataTable table = new DataTable())
            {
                if (wellinfo == null)
                {
                    sb = new StringBuilder();
                    sb.AppendFormat(select_WellInfo_Table, fSize, sSize);
                    count = new StringBuilder(select_WellInfo_Count);
                }
                else
                {
                    sb = new StringBuilder(select_WellInfo);
                    sb.AppendFormat(" and a.Terminal_ID='{0}' or Name='{0}' or Place='{0}' or Place='{0}'", wellinfo);
                    count = new StringBuilder(select_WellInfo_Count);
                    count.AppendFormat(" and Terminal_ID='{0}' or Name='{0}' or Place='{0}' or Place='{0}'", wellinfo);
                }
                using (Conn)
                {
                    pageCount = (int)Conn.ExecuteScalar(count.ToString());
                    table.Load(Conn.ExecuteReader(sb.ToString()));
                }
                return table;
            }
        }
        /// <summary>
        /// 查询人井信息
        /// </summary>
        public List<WellInfo> GetWellInfo_List(string wellinfo)
        {
            sb = new StringBuilder(select_WellInfo);
            if (wellinfo != null)
            {
                sb.AppendFormat(" and a.Terminal_ID='{0}' or Name='{0}' or Place='{0}' or Place='{0}'", wellinfo);
            }
            using (Conn)
            {
                return Conn.Query<WellInfo, WellCurrentStateInfo, WellStateInfo, ReportInfo, OperatorInfo, WellInfo>(sb.ToString(), (a, c, d, e, b) => { a.WellCurrentStateInfo = c; a.WellStateInfo = d; a.OperatorInfo = b; a.ReportNumInfo = e; return a; }, null, null, true, "Terminal_ID,cTerminal_ID,ID,eTerminal_ID,Work_ID").ToList();
            }
        }
        /// <summary>
        /// 通过Terminal_ID查询人井信息
        /// </summary>
        public WellInfo GetWellInfoByTerminal_ID(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Query<WellInfo, WellStateInfo, OperatorInfo, ReportInfo, WellInfo>(query_WellInfo_Terminal_ID, (a, b, c, d) => { a.WellStateInfo = b; a.OperatorInfo = c; a.ReportNumInfo = d; return a; }, new { Terminal_ID = terminal_ID }, null, true, "Terminal_ID,State,RealName,e.Terminal_ID").FirstOrDefault();
            }
        }
        /// <summary>
        /// 通过Phone查询人井信息
        /// </summary>
        public WellInfo GetWellInfoByPhone(string terminal_Phone)
        {
            using (Conn)
            {
                return Conn.Query<WellInfo, WellCurrentStateInfo, WellInfo>(query_WellInfo_Terminal_Phone, (a, b) => { a.WellCurrentStateInfo = b; return a; }, new { Terminal_Phone = terminal_Phone }, null, true, "Terminal_ID,Well_State_ID").FirstOrDefault();
            }
        }
        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertWellInfo(WellInfo wellInfo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Terminal_ID", wellInfo.Terminal_ID);
            param.Add("@Name", wellInfo.Name);
            param.Add("@Longitude", wellInfo.Longitude);
            param.Add("@Latitude", wellInfo.Latitude);
            param.Add("@Place", wellInfo.Place);
            param.Add("@Operator_ID", wellInfo.Operator_ID);
            param.Add("@Terminal_Phone", wellInfo.Terminal_Phone);
            using (Conn)
            {
                return Conn.Execute(Insert_WellInfo, param);
            }
        }
        /// <summary>
        /// 修改人井信息
        /// </summary>
        public int UpdateWellInfo(WellInfo wellInfo)
        {
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@Name", wellInfo.Name);
            parm.Add("@Longitude", wellInfo.Longitude);
            parm.Add("@Latitude", wellInfo.Latitude);
            parm.Add("@Place", wellInfo.Place);
            parm.Add("@Operator_ID", wellInfo.Operator_ID);
            parm.Add("@Terminal_Phone", wellInfo.Terminal_Phone);
            parm.Add("@Terminal_ID", wellInfo.Terminal_ID);
            using (Conn)
            {
                return Conn.Execute(update_WellInfo_Terminal_ID, parm);
            }
        }
        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteWellInfo(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Delete_WellInfo, new { Terminal_ID = terminal_ID });
            }
        }
    }
}
