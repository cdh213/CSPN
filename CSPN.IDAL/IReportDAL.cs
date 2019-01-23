using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.IDAL
{
    public interface IReportDAL
    {
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