using CSPN.Factory;
using CSPN.IBLL;
using CSPN.IDAL;
using CSPN.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.BLL
{
    /// <summary>
    /// 人井基本信息服务
    /// </summary>
    public class WellInfoService : IWellInfoService
    {
        private static readonly IWellInfoDAL welldal = DALFactory.CreateWellInfoDAL();
        private static readonly IReportNumInfoDAL reportnumdal = DALFactory.CreateReportNumInfoDAL();

        #region 人井基本信息
        /// <summary>
        /// 查询人井信息
        /// </summary>
        public DataTable GetWellInfo_Table(string wellinfo)
        {
            return welldal.GetWellInfo_Table(wellinfo);
        }
        /// <summary>
        /// 查询人井信息
        /// </summary>
        public IList<WellInfo> GetWellInfo_List(string wellinfo)
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
        /// 查询未上报人井信息
        /// </summary>
        public DataTable GetNotReportNumInfo(int reportTimes)
        {
            return reportnumdal.GetNotReportNumInfo(reportTimes);
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
        public int UpdateNotReportTimes()
        {
            return reportnumdal.UpdateNotReportTimes();
        }
        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertReportNumInfo(string terminal_ID)
        {
            return reportnumdal.InsertReportNumInfo(terminal_ID);
        }
        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteReportNumInfo(string terminal_ID)
        {
            return reportnumdal.DeleteReportNumInfo(terminal_ID);
        }
        #endregion
    }
}
