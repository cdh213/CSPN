using CSPN.Factory;
using CSPN.IBLL;
using CSPN.IDAL;
using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.BLL
{
    /// <summary>
    /// 人井状态信息服务
    /// </summary>
    public class WellStateService : IWellStateService
    {
        private static readonly IWellStateDAL wellStateDAL = DALFactory.CreateWellStateDAL();
        private static readonly IWellCurrentStateDAL wellCurrentStateDAL = DALFactory.CreateWellCurrentStateDAL();
        private static readonly IWellMaintainDAL wellMaintainDAL = DALFactory.CreateWellMaintainDAL();

        #region 人井状态信息

        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        /// <returns>人井状态</returns>
        public List<WellStateInfo> GetWellStateInfo()
        {
            return wellStateDAL.GetWellStateInfo();
        }

        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public WellStateInfo GetWellStateInfoByID(int id)
        {
            return wellStateDAL.GetWellStateInfoByID(id);
        }

        #endregion 人井状态信息

        #region 人井当前状态信息

        /// <summary>
        /// 查询报警信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAlarmInfo()
        {
            return wellCurrentStateDAL.GetAlarmInfo();
        }

        /// <summary>
        /// 查询报警信息
        /// </summary>
        /// <returns></returns>
        public List<WellCurrentStateInfo> GetAlarmInfoList()
        {
            return wellCurrentStateDAL.GetAlarmInfoList();
        }

        /// <summary>
        /// 查询已通知信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetNoticeInfo()
        {
            return wellCurrentStateDAL.GetNoticeInfo();
        }

        /// <summary>
        /// 通过Well_State_ID,Terminal_ID查询信息
        /// </summary>
        public WellCurrentStateInfo GetWellCurrentStateInfo(int well_State_ID, string terminal_ID)
        {
            return wellCurrentStateDAL.GetWellCurrentStateInfo(well_State_ID, terminal_ID);
        }

        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        /// <param name="wellCurrentStateInfo">Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength,Report_Time,Terminal_ID</param>
        /// <returns></returns>
        public int UpdateWellCurrentStateInfo(WellCurrentStateInfo wellCurrentStateInfo)
        {
            return wellCurrentStateDAL.UpdateWellCurrentStateInfo(wellCurrentStateInfo);
        }

        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        public int UpdateWellCurrentStateInfo(int well_State_ID, string terminal_ID)
        {
            return wellCurrentStateDAL.UpdateWellCurrentStateInfo(well_State_ID, terminal_ID);
        }

        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertWellCurrentStateInfo(string terminal_ID, int well_State_ID)
        {
            return wellCurrentStateDAL.InsertWellCurrentStateInfo(terminal_ID, well_State_ID);
        }

        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteWellCurrentStateInfo(string terminal_ID)
        {
            return wellCurrentStateDAL.DeleteWellCurrentStateInfo(terminal_ID);
        }

        #endregion 人井当前状态信息

        #region 维护信息

        /// <summary>
        /// 加载维护信息
        /// </summary>
        public DataTable GetMaintainInfo(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return wellMaintainDAL.GetMaintainInfo(fSize, sSize, out pageCount);
        }

        /// <summary>
        /// 通过维护开始时间查询人井
        /// </summary>
        public List<WellMaintainInfo> GetMaintain_StartTime(string startTime)
        {
            return wellMaintainDAL.GetMaintain_StartTime(startTime);
        }

        /// <summary>
        /// 通过维护结束时间查询人井
        /// </summary>
        public List<WellMaintainInfo> GetMaintain_EndTime(string endTime)
        {
            return wellMaintainDAL.GetMaintain_EndTime(endTime);
        }

        /// <summary>
        /// 维护信息更新
        /// </summary>
        /// <param name="wellMaintainInfo">Maintain_StartTime,Maintain_EndTime,Terminal_ID</param>
        /// <returns></returns>
        public int UpdateMaintainInfo(WellMaintainInfo wellMaintainInfo)
        {
            return wellMaintainDAL.UpdateMaintainInfo(wellMaintainInfo);
        }

        /// <summary>
        /// 维护信息更新
        /// </summary>
        public int UpdateMaintainInfo(int maintain_State, string terminal_ID)
        {
            return wellMaintainDAL.UpdateMaintainInfo(maintain_State, terminal_ID);
        }

        /// <summary>
        /// 增加维护信息
        /// </summary>
        public int InsertMaintainInfo(string terminal_ID, int maintain_State)
        {
            return wellMaintainDAL.InsertMaintainInfo(terminal_ID, maintain_State);
        }

        /// <summary>
        /// 取消维护
        /// </summary>
        public int MaintainInfoCancel(int maintain_State, string terminal_ID)
        {
            return wellMaintainDAL.MaintainInfoCancel(maintain_State, terminal_ID);
        }

        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteWellMaintainInfo(string terminal_ID)
        {
            return wellMaintainDAL.DeleteWellMaintainInfo(terminal_ID);
        }

        #endregion 维护信息
    }
}