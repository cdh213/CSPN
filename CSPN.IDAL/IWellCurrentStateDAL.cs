﻿using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.IDAL
{
    /// <summary>
    /// 人井当前状态
    /// </summary>
    public interface IWellCurrentStateDAL
    {
        #region 当前人井状态信息
        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        int UpdateWellCurrentStateInfo(int well_State_ID, string terminal_ID);
        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        int UpdateWellCurrentStateInfo(WellCurrentStateInfo wellCurrentStateInfo);
        /// <summary>
        /// 查询报警,状态信息
        /// </summary>
        DataTable GetAlarmInfo_StatusInfo();
        /// <summary>
        /// 通过Well_State_ID，Terminal_ID查询报警,状态信息
        /// </summary>
        WellCurrentStateInfo GetAlarmInfo_StatusInfo(int well_State_ID, string terminal_ID);
        /// <summary>
        /// 查询已处理信息
        /// </summary>
        DataTable GetProcessedInfo();
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
        DataTable GetMaintainInfo();
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
