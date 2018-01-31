using CSPN.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.IBLL
{
    /// <summary>
    /// 人井基本信息服务
    /// </summary>
    public interface IWellInfoService
    {
        #region 人井基本信息
        /// <summary>
        /// 查询人井信息
        /// </summary>
        DataTable GetWellInfo_Table(string wellinfo, int pageSize, int pageIndex, out int pageCount);
        /// <summary>
        /// 查询人井信息
        /// </summary>
        IList<WellInfo> GetWellInfo_List(string wellinfo);
        /// <summary>
        /// 通过Terminal_ID查询人井信息
        /// </summary>
        WellInfo GetWellInfoByTerminal_ID(string terminal_ID);
        /// <summary>
        /// 通过Phone查询人井信息
        /// </summary>
        WellInfo GetWellInfoByPhone(string terminal_Phone);
        /// <summary>
        /// 增加人井信息
        /// </summary>
        int InsertWellInfo(WellInfo wellInfo);
        /// <summary>
        /// 修改人井信息
        /// </summary>
        int UpdateWellInfo(WellInfo wellInfo);
        /// <summary>
        /// 删除人井信息
        /// </summary>
        int DeleteWellInfo(string terminal_ID);
        #endregion
        
        #region 人井上报次数
        /// <summary>
        /// 查询未上报人井信息
        /// </summary>
        DataTable GetNotReportNumInfo(int reportTimes);
        /// <summary>
        /// 重置上报次数
        /// </summary>
        int Empty_ReportNumInfo();
        /// <summary>
        /// 重置未上报次数
        /// </summary>
        int Empty_NotReportNumInfo(string terminal_ID);
        /// <summary>
        /// 更新人井上报次数
        /// </summary>
        int UpdateReportTimes(string terminal_ID);
        /// <summary>
        /// 更新人井上未报次数
        /// </summary>
        int UpdateNotReportTimes();
        /// <summary>
        /// 更新人井上未时间间隔
        /// </summary>
        int UpdateReportInterval(int reportInterval, string terminal_ID);
        /// <summary>
        /// 增加人井信息
        /// </summary>
        int InsertReportNumInfo(string terminal_ID, int reportInterval);
        /// <summary>
        /// 删除人井信息
        /// </summary>
        int DeleteReportNumInfo(string terminal_ID);
        #endregion

        #region 人井报警信息
        /// <summary>
        /// 查询报警,状态信息
        /// </summary>
        DataTable GetAlarmInfo_StatusInfo();
        /// <summary>
        /// 通过Terminal_ID查询报警,状态信息
        /// </summary>
        AlarmInfo GetAlarmInfo_StatusInfo(int well_State_ID, string terminal_ID);
        /// <summary>
        /// 查询已处理信息
        /// </summary>
        DataTable GetProcessedInfo();
        /// <summary>
        /// 增加报警、状态信息
        /// </summary>
        int InsertAlarmInfo(AlarmInfo alarmInfo);
        /// <summary>
        /// 删除报警、状态信息
        /// </summary>
        int DeleteAlarmInfo(string report_Time);
        /// <summary>
        /// 更新报警、状态信息
        /// </summary>
        int UpdateAlarmInfo(int well_State_ID, string report_Time);
        #endregion
    }
}
