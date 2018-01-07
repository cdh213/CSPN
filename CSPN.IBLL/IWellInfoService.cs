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
        DataTable GetWellInfo_Table(string wellinfo);
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
        /// 增加人井信息
        /// </summary>
        int InsertReportNumInfo(string terminal_ID);
        /// <summary>
        /// 删除人井信息
        /// </summary>
        int DeleteReportNumInfo(string terminal_ID);
        #endregion
    }
}
