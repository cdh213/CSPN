using CSPN.Model;
using System.Collections.Generic;
using System.Data;

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
        List<WellInfo> GetWellInfo_List(string wellinfo);

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
        /// <param name="wellInfo">Terminal_ID,Name,Longitude,Latitude,Place,Operator_ID,Terminal_Phone</param>
        /// <returns></returns>
        int InsertWellInfo(WellInfo wellInfo);

        /// <summary>
        /// 修改人井信息
        /// </summary>
        /// <param name="wellInfo">Name,Longitude,Latitude,Place,Operator_ID,Terminal_Phone,Terminal_ID</param>
        /// <returns></returns>
        int UpdateWellInfo(WellInfo wellInfo);

        /// <summary>
        /// 删除人井信息
        /// </summary>
        int DeleteWellInfo(string terminal_ID);

        #endregion 人井基本信息

        #region 人井上报信息

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
        /// 更新人井未上报次数
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

        #endregion 人井上报信息
    }
}