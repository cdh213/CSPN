using CSPN.Factory;
using CSPN.Model;
using System.Data;
using System.Text;
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
        public IDbConnection Conn
        {
            get
            {
                return ConnectionFactory.CreateConnection();
            }
        }
        #endregion

        private const string UPDATE_Well_Current_State = "update CSPN_Well_Current_State_Info set Well_State_ID=@Well_State_ID,Electricity=@Electricity,Temperature=@Temperature,Humidity=@Humidity,Smoke_Detector=@Smoke_Detector,Smoke_Power=@Smoke_Power,Signal_Strength=@Signal_Strength,Report_Time=@Report_Time where Terminal_ID=@Terminal_ID";
        private const string UPDATE_Well_State_ID = "update CSPN_Well_Current_State_Info set Well_State_ID=@Well_State_ID where Terminal_ID=@Terminal_ID";
        private const string Insert_WellInfo = "insert into CSPN_Well_Current_State_Info(Terminal_ID,Well_State_ID) values(@Terminal_ID,@Well_State_ID)";
        private const string Delete_WellInfo = "delete from CSPN_Well_Current_State_Info where Terminal_ID=@Terminal_ID";
        private const string select_Well_Maintain_Info = "select a.Terminal_ID,Name,Place,b.Terminal_ID,b.Well_State_ID,Maintain_StartTime,Maintain_EndTime,c.ID,Icon,State from (CSPN_Well_Info as a inner join CSPN_Well_Current_State_Info as b on a.Terminal_ID=b.Terminal_ID) inner join CSPN_Dic_Well_State_Info as c on b.Well_State_ID=c.ID where a.Terminal_ID between (select max(a.Terminal_ID) from (select top {0} a.Terminal_ID from CSPN_Well_Info as a order by a.Terminal_ID asc)) and (select max(a.Terminal_ID) from (select top {1} a.Terminal_ID from CSPN_Well_Info as a order by a.Terminal_ID asc)) order by a.Terminal_ID asc";
        private const string select_Well_Maintain_Info_Count = "select count(*) from CSPN_Well_Info";
        private const string select_Maintain_StartTime = "select Terminal_ID from CSPN_Well_Current_State_Info where Maintain_StartTime=@Maintain_StartTime";
        private const string select_Maintain_EndTime = "select Terminal_ID from CSPN_Well_Current_State_Info where Maintain_EndTime=@Maintain_EndTime";
        private const string updade_Well_Maintain_Info = "update CSPN_Well_Current_State_Info set Maintain_StartTime=@Maintain_StartTime,Maintain_EndTime=@Maintain_EndTime where Terminal_ID=@Terminal_ID";


        StringBuilder sb = null;
        #region 当前人井状态信息
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
        #endregion

        #region 维护信息
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
        /// 维护信息更新
        /// </summary>
        public int UpdateMaintainInfo(WellCurrentStateInfo wellCurrentStateInfo)
        {
            DynamicParameters parm = new DynamicParameters();
            parm.Add("@Maintain_StartTime", wellCurrentStateInfo.Maintain_StartTime);
            parm.Add("@Maintain_EndTime", wellCurrentStateInfo.Maintain_EndTime);
            parm.Add("@Terminal_ID", wellCurrentStateInfo.Terminal_ID);

            using (Conn)
            {
                return Conn.Execute(updade_Well_Maintain_Info, parm);
            }
        }
        /// <summary>
        /// 通过维护开始时间查询人井
        /// </summary>
        public object GetMaintain_StartTime(string startTime)
        {
            using (Conn)
            {
                return Conn.ExecuteScalar(select_Maintain_StartTime, new { Maintain_StartTime = startTime });
            }
        }
        /// <summary>
        /// 通过维护结束时间查询人井
        /// </summary>
        public object GetMaintain_EndTime(string endTime)
        {
            using (Conn)
            {
                return Conn.ExecuteScalar(select_Maintain_EndTime, new { Maintain_EndTime = endTime });
            }
        }
        #endregion
    }
}
