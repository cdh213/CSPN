﻿using CSPN.Model;
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
        #endregion

        #region 人井当前状态信息
        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        int UpdateWellCurrentStateInfo(int well_State_ID, string terminal_ID);
        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        int UpdateWellCurrentStateInfo(WellCurrentStateInfo wellCurrentStateInfo);
        /// <summary>
        /// 增加人井信息
        /// </summary>
        int InsertWellCurrentStateInfo(string terminal_ID, int well_State_ID);
        /// <summary>
        /// 删除人井信息
        /// </summary>
        int DeleteWellCurrentStateInfo(string terminal_ID);
        #endregion

        #region 维护信息
        /// <summary>
        /// 加载维护信息
        /// </summary>
        DataTable GetMaintainInfo(int pageSize, int pageIndex, out int pageCount);
        /// <summary>
        /// 维护信息更新
        /// </summary>
        int UpdateMaintainInfo(WellCurrentStateInfo wellCurrentStateInfo);
        /// <summary>
        /// 通过维护开始时间查询人井
        /// </summary>
        object GetMaintain_StartTime(string startTime);
        /// <summary>
        /// 通过维护结束时间查询人井
        /// </summary>
        object GetMaintain_EndTime(string endTime);
        #endregion
    }
}
