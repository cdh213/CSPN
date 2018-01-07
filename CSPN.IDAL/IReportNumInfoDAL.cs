using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.IDAL
{
    public interface IReportNumInfoDAL
    {
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
    }
}
