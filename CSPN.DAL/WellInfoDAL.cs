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
using System.Collections;
using System.Threading;
using System.Data.OleDb;

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

        const string select_WellInfo = "select a.Terminal_ID,Name,Longitude,Latitude,Place,Terminal_Phone,c.Terminal_ID as cTerminal_ID,Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength,d.ID,Icon,Color,Work_ID,RealName,Telephone from ((CSPN_Well_Info as a inner join CSPN_Operator_Info as b on a.Operator_ID=b.ID) inner join CSPN_Well_Current_State_Info as c on a.Terminal_ID=c.Terminal_ID) inner join CSPN_Dic_Well_State_Info as d on c.Well_State_ID=d.ID where 1=1";
        const string query_WellInfo_Terminal_ID = "select a.Terminal_ID,Name,Longitude,Latitude,Place,Terminal_Phone,[State],RealName from ((CSPN_Well_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on b.Well_State_ID=c.ID) inner join CSPN_Operator_Info as d on a.Operator_ID=d.ID where a.Terminal_ID=@Terminal_ID";
        const string query_WellInfo_Terminal_Phone = "select * from CSPN_Well_Info where Terminal_Phone=@Terminal_Phone";
        const string update_WellInfo_Terminal_ID = "update CSPN_Well_Info set Name=@Name,Longitude=@Longitude,Latitude=@Latitude,Place=@Place,Operator_ID=@Operator_ID,Terminal_Phone=@Terminal_Phone where Terminal_ID=@Terminal_ID";
        const string Insert_WellInfo = "insert into CSPN_Well_Info(Terminal_ID,Name,Longitude,Latitude,Place,Operator_ID,Terminal_Phone) values(@Terminal_ID,@Name,@Longitude,@Latitude,@Place,@Operator_ID,@Terminal_Phone)";
        const string Delete_WellInfo = "delete from CSPN_Well_Info where Terminal_ID=@Terminal_ID";

        
        /// <summary>
        /// 查询人井信息
        /// </summary>
        public DataTable GetWellInfo_Table(string wellinfo)
        {
            StringBuilder sb = new StringBuilder(select_WellInfo);
            DataTable table = new DataTable();
            if (wellinfo != null)
            {
                sb.AppendFormat(" and Terminal_ID='{0}' or Name='{0}' or Place='{0}' or Place='{0}'", wellinfo);
            }
            using (Conn)
            {
                using (IDataReader read = Conn.ExecuteReader(sb.ToString()))
                {
                    table.Load(read);
                }
            }
            return table;
        }
        /// <summary>
        /// 查询人井信息
        /// </summary>
        public IList<WellInfo> GetWellInfo_List(string wellinfo)
        {
            StringBuilder sb = new StringBuilder(select_WellInfo);
            if (wellinfo != null)
            {
                sb.AppendFormat(" and a.Terminal_ID='{0}' or Name='{0}' or Place='{0}' or Place='{0}'", wellinfo);
            }
            using (Conn)
            {
                return Conn.Query<WellInfo, WellCurrentStateInfo, WellStateInfo, OperatorInfo, WellInfo>(sb.ToString(), (a, c, d, b) => { a.WellCurrentStateInfo = c; a.WellStateInfo = d; a.OperatorInfo = b; return a; }, null, null, true, "Terminal_ID,cTerminal_ID,ID,Work_ID").ToList();
            }
        }
        /// <summary>
        /// 通过Terminal_ID查询人井信息
        /// </summary>
        public WellInfo GetWellInfoByTerminal_ID(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Query<WellInfo, WellStateInfo, OperatorInfo, WellInfo>(query_WellInfo_Terminal_ID, (a, b, c) => { a.WellStateInfo = b; a.OperatorInfo = c; return a; }, new { Terminal_ID = terminal_ID }, null, true, "Terminal_ID,State,RealName").FirstOrDefault();
            }
        }
        /// <summary>
        /// 通过Phone查询人井信息
        /// </summary>
        public WellInfo GetWellInfoByPhone(string terminal_Phone)
        {
            using (Conn)
            {
                return Conn.Query<WellInfo>(query_WellInfo_Terminal_Phone, new { Terminal_Phone = terminal_Phone }).FirstOrDefault();
                
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
