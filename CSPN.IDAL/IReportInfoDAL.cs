using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.IDAL
{
    public interface IReportInfoDAL
    {
        /// <summary>
        /// 查询待处理信息
        /// </summary>
        /// <returns></returns>
        DataTable GetReportInfo_Pending();
        /// <summary>
        /// 查询已通知信息
        /// </summary>
        /// <returns></returns>
        DataTable GetReportInfo_Send();
        /// <summary>
        /// 通过Terminal_ID查询信息
        /// </summary>
        ReportInfo GetReportInfo_Terminal_ID(int well_State_ID, string terminal_ID);
        /// <summary>
        /// 更新待处理信息
        /// </summary>
        /// <returns></returns>
        int UpdateReportInfo_Pending(int well_State_ID_Pending, string terminal_ID);
        /// <summary>
        /// 更新待处理信息
        /// </summary>
        /// <returns></returns>
        int UpdateReportInfo_Pending(ReportInfo reportInfo);
        /// <summary>
        /// 更新已通知信息
        /// </summary>
        /// <returns></returns>
        int UpdateReportInfo_Send(int well_State_ID_Send, string terminal_ID);
        /// <summary>
        /// 查询上报人井信息
        /// </summary>
        List<ReportInfo> GetReportInfo();
        /// <summary>
        /// 查询未上报人井信息
        /// </summary>
        DataTable GetNotReportNumInfo(int notReportTimes);
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
        int UpdateNotReportTimes(string terminal_ID);
        /// <summary>
        /// 更新人井上未时间间隔
        /// </summary>
        int UpdateReportInterval(int reportInterval, string terminal_ID);
        /// <summary>
        /// 增加人井信息
        /// </summary>
        int InsertReportInfo(string terminal_ID, int reportInterval);
        /// <summary>
        /// 删除人井信息
        /// </summary>
        int DeleteReportInfo(string terminal_ID);
    }
}
