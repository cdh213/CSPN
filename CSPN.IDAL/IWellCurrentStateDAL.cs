using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.IDAL
{
    /// <summary>
    /// 人井当前状态
    /// </summary>
    public interface IWellCurrentStateDAL
    {
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
    }
}