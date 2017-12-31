using CSPN.Model;
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
        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        int UpdateWellCurrentStateInfo(WellCurrentStateInfo wellCurrentStateInfo);
        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        int UpdateWellCurrentStateInfo(int well_State_ID, string terminal_ID);
        /// <summary>
        /// 查询报警,状态信息
        /// </summary>
        IList<WellCurrentStateInfo> GetAlarmInfo_StatusInfo();
        /// <summary>
        /// 通过Terminal_ID查询报警,状态信息
        /// </summary>
        WellCurrentStateInfo GetAlarmInfo_StatusInfo(string terminal_ID);
        /// <summary>
        /// 通过Well_State_ID，Terminal_ID查询报警,状态信息
        /// </summary>
        WellCurrentStateInfo GetAlarmInfo_StatusInfo(int well_State_ID, string terminal_ID);
        /// <summary>
        /// 查询已处理信息
        /// </summary>
        IList<WellCurrentStateInfo> GetProcessedInfoByWell_State_ID(int well_State_ID);
        /// <summary>
        /// 增加人井信息
        /// </summary>
        int InsertWellCurrentStateInfo(string terminal_ID, int well_State_ID);
        /// <summary>
        /// 删除人井信息
        /// </summary>
        int DeleteWellCurrentStateInfo(string terminal_ID);
        /// <summary>
        /// 加载维护信息
        /// </summary>
        DataTable GetAppointmentInfo();
        /// <summary>
        /// 维护信息更新
        /// </summary>
        int UpdateAppointmentInfo(int well_State_ID, string terminal_ID);
    }
}
