using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.IBLL
{
    /// <summary>
    /// 人井状态信息服务
    /// </summary>
    public interface IWellStateService
    {
        #region 人井状态信息

        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        /// <returns>人井状态</returns>
        List<WellStateInfo> GetWellStateInfo();

        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        WellStateInfo GetWellStateInfoByID(int id);

        #endregion 人井状态信息

        #region 人井当前状态信息

        /// <summary>
        /// 查询报警信息
        /// </summary>
        /// <returns></returns>
        DataTable GetAlarmInfo();

        /// <summary>
        /// 查询报警信息
        /// </summary>
        /// <returns></returns>
        List<WellCurrentStateInfo> GetAlarmInfoList();

        /// <summary>
        /// 查询已通知信息
        /// </summary>
        /// <returns></returns>
        DataTable GetNoticeInfo();

        /// <summary>
        /// 通过Well_State_ID,Terminal_ID查询信息
        /// </summary>
        WellCurrentStateInfo GetWellCurrentStateInfo(int well_State_ID, string terminal_ID);

        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        int UpdateWellCurrentStateInfo(int well_State_ID, string terminal_ID);

        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        /// <param name="wellCurrentStateInfo">Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength,Report_Time,Terminal_ID</param>
        /// <returns></returns>
        int UpdateWellCurrentStateInfo(WellCurrentStateInfo wellCurrentStateInfo);

        /// <summary>
        /// 增加人井信息
        /// </summary>
        int InsertWellCurrentStateInfo(string terminal_ID, int well_State_ID);

        /// <summary>
        /// 删除人井信息
        /// </summary>
        int DeleteWellCurrentStateInfo(string terminal_ID);

        #endregion 人井当前状态信息

        #region 维护信息

        /// <summary>
        /// 加载维护信息
        /// </summary>
        DataTable GetMaintainInfo(int fSize, int sSize, out int pageCount);

        /// <summary>
        /// 通过维护开始时间查询人井
        /// </summary>
        List<WellMaintainInfo> GetMaintain_StartTime(string startTime);

        /// <summary>
        /// 通过维护结束时间查询人井
        /// </summary>
        List<WellMaintainInfo> GetMaintain_EndTime(string endTime);

        /// <summary>
        /// 维护信息更新
        /// </summary>
        /// <param name="wellMaintainInfo">Maintain_StartTime,Maintain_EndTime,Terminal_ID</param>
        /// <returns></returns>
        int UpdateMaintainInfo(WellMaintainInfo wellMaintainInfo);

        /// <summary>
        /// 维护信息更新
        /// </summary>
        int UpdateMaintainInfo(int maintain_State, string terminal_ID);

        /// <summary>
        /// 增加维护信息
        /// </summary>
        int InsertMaintainInfo(string terminal_ID, int maintain_State);

        /// <summary>
        /// 取消维护
        /// </summary>
        int MaintainInfoCancel(int maintain_State, string terminal_ID);

        /// <summary>
        /// 删除人井信息
        /// </summary>
        int DeleteWellMaintainInfo(string terminal_ID);

        #endregion 维护信息
    }
}