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
        private static readonly IWellInfoDAL wellInfoDAL = DALFactory.CreateWellInfoDAL();
        private static readonly IReportDAL reportDAL = DALFactory.CreateReportDAL();

        #region 人井基本信息

        /// <summary>
        /// 查询人井信息
        /// </summary>
        public DataTable GetWellInfo_Table(string wellinfo, int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return wellInfoDAL.GetWellInfo_Table(wellinfo, fSize, sSize, out pageCount);
        }

        /// <summary>
        /// 查询人井信息
        /// </summary>
        public List<WellInfo> GetWellInfo_List(string wellinfo)
        {
            return wellInfoDAL.GetWellInfo_List(wellinfo);
        }

        /// <summary>
        /// 通过ID查询人井信息
        /// </summary>
        public WellInfo GetWellInfoByTerminal_ID(string terminal_ID)
        {
            return wellInfoDAL.GetWellInfoByTerminal_ID(terminal_ID);
        }

        /// <summary>
        /// 通过Phone查询人井信息
        /// </summary>
        public WellInfo GetWellInfoByPhone(string terminal_Phone)
        {
            return wellInfoDAL.GetWellInfoByPhone(terminal_Phone);
        }

        /// <summary>
        /// 增加人井信息
        /// </summary>
        /// <param name="wellInfo">Terminal_ID,Name,Longitude,Latitude,Place,Operator_ID,Terminal_Phone</param>
        /// <returns></returns>
        public int InsertWellInfo(WellInfo wellInfo)
        {
            return wellInfoDAL.InsertWellInfo(wellInfo);
        }

        /// <summary>
        /// 修改人井信息
        /// </summary>
        /// <param name="wellInfo">Name,Longitude,Latitude,Place,Operator_ID,Terminal_Phone,Terminal_ID</param>
        /// <returns></returns>
        public int UpdateWellInfo(WellInfo wellInfo)
        {
            return wellInfoDAL.UpdateWellInfo(wellInfo);
        }

        /// <summary>
        /// 删除人井信息
        /// </summary>
        /// <param name="terminal_ID">人井编号</param>
        /// <returns></returns>
        public int DeleteWellInfo(string terminal_Phone)
        {
            return wellInfoDAL.DeleteWellInfo(terminal_Phone);
        }

        #endregion 人井基本信息

        #region 人井上报信息

        /// <summary>
        /// 查询上报人井信息
        /// </summary>
        public List<ReportInfo> GetReportInfo()
        {
            return reportDAL.GetReportInfo();
        }

        /// <summary>
        /// 查询未上报人井信息
        /// </summary>
        public DataTable GetNotReportNumInfo(int notReportTimes)
        {
            return reportDAL.GetNotReportNumInfo(notReportTimes);
        }

        /// <summary>
        /// 重置上报次数
        /// </summary>
        public int Empty_ReportNumInfo()
        {
            return reportDAL.Empty_ReportNumInfo();
        }

        /// <summary>
        /// 重置未上报次数
        /// </summary>
        public int Empty_NotReportNumInfo(string terminal_ID)
        {
            return reportDAL.Empty_NotReportNumInfo(terminal_ID);
        }

        /// <summary>
        /// 更新人井上报次数
        /// </summary>
        public int UpdateReportTimes(string terminal_ID)
        {
            return reportDAL.UpdateReportTimes(terminal_ID);
        }

        /// <summary>
        /// 更新人井上未报次数
        /// </summary>
        public int UpdateNotReportTimes(string terminal_ID)
        {
            return reportDAL.UpdateNotReportTimes(terminal_ID);
        }

        /// <summary>
        /// 更新人井上未时间间隔
        /// </summary>
        public int UpdateReportInterval(int reportInterval, string terminal_ID)
        {
            return reportDAL.UpdateReportInterval(reportInterval, terminal_ID);
        }

        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertReportInfo(string terminal_ID, int reportInterval)
        {
            return reportDAL.InsertReportInfo(terminal_ID, reportInterval);
        }

        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteReportInfo(string terminal_ID)
        {
            return reportDAL.DeleteReportInfo(terminal_ID);
        }

        #endregion 人井上报信息
    }
}