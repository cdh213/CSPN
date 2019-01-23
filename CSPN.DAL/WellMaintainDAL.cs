using CSPN.Factory;
using CSPN.IDAL;
using CSPN.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CSPN.DAL
{
    public class WellMaintainDAL : IWellMaintainDAL
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

        private const string select_Well_Maintain_Info = "select a.Terminal_ID,Name,Place,Icon,State,Maintain_StartTime,Maintain_EndTime,iif(Maintain_State=0,'未维护','维护中') as aMaintain_State from ((CSPN_Well_Maintain_Info as a inner join CSPN_Well_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Well_Current_State_Info as c on a.Terminal_ID=c.Terminal_ID) inner join CSPN_Dic_Well_State_Info as d on c.Well_State_ID=d.ID where a.Terminal_ID between (select max(a.Terminal_ID) from (select top {0} a.Terminal_ID from CSPN_Well_Info as a order by a.Terminal_ID asc)) and (select max(a.Terminal_ID) from (select top {1} a.Terminal_ID from CSPN_Well_Info as a order by a.Terminal_ID asc)) order by a.Terminal_ID asc";
        private const string select_Well_Maintain_Info_Count = "select count(*) from CSPN_Well_Info";
        private const string select_Maintain_StartTime = "select Terminal_ID,Maintain_State from CSPN_Well_Maintain_Info where Maintain_StartTime=@Maintain_StartTime";
        private const string select_Maintain_EndTime = "select Terminal_ID from CSPN_Well_Maintain_Info where Maintain_EndTime=@Maintain_EndTime";
        private const string updade_Well_Maintain_Info = "update CSPN_Well_Maintain_Info set Maintain_StartTime=@Maintain_StartTime,Maintain_EndTime=@Maintain_EndTime where Terminal_ID=@Terminal_ID";
        private const string set_Well_Maintain_Info = "update CSPN_Well_Maintain_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID set Maintain_State=1,Well_State_ID=6 where a.Terminal_ID=@Terminal_ID";
        private const string insert_Well_Maintain_Info = "insert into CSPN_Well_Maintain_Info(Terminal_ID,Maintain_State) values(@Terminal_ID,@Maintain_State)";
        private const string cancel_Well_Maintain_Info = "update CSPN_Well_Maintain_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID set Maintain_StartTime=NULL,Maintain_EndTime=NULL,Maintain_State=0,Well_State_ID=1 where a.Terminal_ID=@Terminal_ID";
        private const string Delete_Well_Maintain_Info = "delete from CSPN_Well_Maintain_Info where Terminal_ID=@Terminal_ID";

        private StringBuilder sb = null;

        /// <summary>
        /// 加载维护信息
        /// </summary>
        public DataTable GetMaintainInfo(int fSize, int sSize, out int pageCount)
        {
            sb = new StringBuilder();
            sb.AppendFormat(select_Well_Maintain_Info, fSize, sSize);
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    pageCount = (int)Conn.ExecuteScalar(select_Well_Maintain_Info_Count);
                    table.Load(Conn.ExecuteReader(sb.ToString()));
                }
                return table;
            }
        }

        /// <summary>
        /// 通过维护开始时间查询人井
        /// </summary>
        public List<WellMaintainInfo> GetMaintain_StartTime(string startTime)
        {
            using (Conn)
            {
                return Conn.Query<WellMaintainInfo>(select_Maintain_StartTime, new { Maintain_StartTime = startTime }).ToList();
            }
        }

        /// <summary>
        /// 通过维护结束时间查询人井
        /// </summary>
        public List<WellMaintainInfo> GetMaintain_EndTime(string endTime)
        {
            using (Conn)
            {
                return Conn.Query<WellMaintainInfo>(select_Maintain_EndTime, new { Maintain_EndTime = endTime }).ToList();
            }
        }

        /// <summary>
        /// 维护信息更新
        /// </summary>
        /// <param name="wellMaintainInfo">Maintain_StartTime,Maintain_EndTime,Terminal_ID</param>
        /// <returns></returns>
        public int UpdateMaintainInfo(WellMaintainInfo wellMaintainInfo)
        {
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@Maintain_StartTime", wellMaintainInfo.Maintain_StartTime);
            parm.Add("@Maintain_EndTime", wellMaintainInfo.Maintain_EndTime);
            parm.Add("@Terminal_ID", wellMaintainInfo.Terminal_ID);

            using (Conn)
            {
                return Conn.Execute(updade_Well_Maintain_Info, parm);
            }
        }

        /// <summary>
        /// 设置维护
        /// </summary>
        public int MaintainInfoSet(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(set_Well_Maintain_Info, new { Terminal_ID = terminal_ID });
            }
        }

        /// <summary>
        /// 取消维护
        /// </summary>
        public int MaintainInfoCancel(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(cancel_Well_Maintain_Info, new { Terminal_ID = terminal_ID });
            }
        }

        /// <summary>
        /// 增加维护信息
        /// </summary>
        public int InsertMaintainInfo(string terminal_ID, int maintain_State)
        {
            using (Conn)
            {
                return Conn.Execute(insert_Well_Maintain_Info, new { Terminal_ID = terminal_ID, Maintain_State = maintain_State });
            }
        }

        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteWellMaintainInfo(string terminal_ID)
        {
            using (Conn)
            {
                return Conn.Execute(Delete_Well_Maintain_Info, new { Terminal_ID = terminal_ID });
            }
        }
    }
}