using CSPN.Factory;
using CSPN.IBLL;
using CSPN.IDAL;
using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.BLL
{
    /// <summary>
    /// 人井基本信息服务
    /// </summary>
    public class WellInfoService : IWellInfoService
    {
        private static readonly IWellInfoDAL welldal = DALFactory.CreateWellInfoDAL();
        private static readonly IReportInfoDAL reportnumdal = DALFactory.CreateReportNumInfoDAL();

        #region 人井基本信息
        /// <summary>
        /// 查询人井信息
        /// </summary>
        public DataTable GetWellInfo_Table(string wellinfo, int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return welldal.GetWellInfo_Table(wellinfo, fSize, sSize, out pageCount);
        }
        /// <summary>
        /// 查询人井信息
        /// </summary>
        public List<WellInfo> GetWellInfo_List(string wellinfo)
        {
            return welldal.GetWellInfo_List(wellinfo);
        }
        /// <summary>
        /// 通过ID查询人井信息
        /// </summary>
        public WellInfo GetWellInfoByTerminal_ID(string terminal_ID)
        {
            return welldal.GetWellInfoByTerminal_ID(terminal_ID);
        }
        /// <summary>
        /// 通过Phone查询人井信息
        /// </summary>
        public WellInfo GetWellInfoByPhone(string terminal_Phone)
        {
            return welldal.GetWellInfoByPhone(terminal_Phone);
        }
        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertWellInfo(WellInfo wellInfo)
        {
            return welldal.InsertWellInfo(wellInfo);
        }
        /// <summary>
        /// 修改人井信息
        /// </summary>
        /// <param name="well">人井信息</param>
        /// <returns></returns>
        public int UpdateWellInfo(WellInfo wellInfo)
        {
            return welldal.UpdateWellInfo(wellInfo);
        }
        /// <summary>
        /// 删除人井信息
        /// </summary>
        /// <param name="terminal_ID">人井编号</param>
        /// <returns></returns>
        public int DeleteWellInfo(string terminal_Phone)
        {
            return welldal.DeleteWellInfo(terminal_Phone);
        }
        #endregion

        #region 人井上报次数
        /// <summary>
        /// 查询上报人井信息
        /// </summary>
        public List<ReportInfo> GetReportInfo()
        {
            return reportnumdal.GetReportInfo();
        }
        /// <summary>
        /// 查询未上报人井信息
        /// </summary>
        public DataTable GetNotReportNumInfo(int notReportTimes)
        {
            return reportnumdal.GetNotReportNumInfo(notReportTimes);
        }
        /// <summary>
        /// 重置上报次数
        /// </summary>
        public int Empty_ReportNumInfo()
        {
            return reportnumdal.Empty_ReportNumInfo();
        }
        /// <summary>
        /// 重置未上报次数
        /// </summary>
        public int Empty_NotReportNumInfo(string terminal_ID)
        {
            return reportnumdal.Empty_NotReportNumInfo(terminal_ID);
        }
        /// <summary>
        /// 更新人井上报次数
        /// </summary>
        public int UpdateReportTimes(string terminal_ID)
        {
            return reportnumdal.UpdateReportTimes(terminal_ID);
        }
        /// <summary>
        /// 更新人井上未报次数
        /// </summary>
        public int UpdateNotReportTimes(string terminal_ID)
        {
            return reportnumdal.UpdateNotReportTimes(terminal_ID);
        }
        /// <summary>
        /// 更新人井上未时间间隔
        /// </summary>
        public int UpdateReportInterval(int reportInterval, string terminal_ID)
        {
            return reportnumdal.UpdateReportInterval(reportInterval, terminal_ID);
        }
        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertReportInfo(string terminal_ID, int reportInterval)
        {
            return reportnumdal.InsertReportInfo(terminal_ID, reportInterval);
        }
        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteReportInfo(string terminal_ID)
        {
            return reportnumdal.DeleteReportInfo(terminal_ID);
        }
        #endregion

        #region 人井报警信息
        /// <summary>
        /// 查询待处理信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetReportInfo_Pending()
        {
            return reportnumdal.GetReportInfo_Pending();
        }
        /// <summary>
        /// 查询已通知信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetReportInfo_Send()
        {
            return reportnumdal.GetReportInfo_Send();
        }
        /// <summary>
        /// 通过Terminal_ID查询信息
        /// </summary>
        public ReportInfo GetReportInfo_Terminal_ID(int well_State_ID, string terminal_ID)
        {
            return reportnumdal.GetReportInfo_Terminal_ID(well_State_ID, terminal_ID);
        }
        /// <summary>
        /// 更新待处理信息
        /// </summary>
        /// <returns></returns>
        public int UpdateReportInfo_Pending(int well_State_ID_Pending, string terminal_ID)
        {
            return reportnumdal.UpdateReportInfo_Pending(well_State_ID_Pending, terminal_ID);
        }
        /// <summary>
        /// 更新待处理信息
        /// </summary>
        /// <returns></returns>
        public int UpdateReportInfo_Pending(ReportInfo reportInfo)
        {
            return reportnumdal.UpdateReportInfo_Pending(reportInfo);
        }
        /// <summary>
        /// 更新已通知信息
        /// </summary>
        /// <returns></returns>
        public int UpdateReportInfo_Send(int well_State_ID_Send, string terminal_ID)
        {
            return reportnumdal.UpdateReportInfo_Send(well_State_ID_Send, terminal_ID);
        }
        #endregion
    }
}
