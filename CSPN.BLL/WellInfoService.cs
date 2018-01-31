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
        private static readonly IAlarmInfoDAL alarmInfoDAL = DALFactory.CreateAlarmInfoDAL();

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
        /// 更新人井上未时间间隔
        /// </summary>
        public int UpdateReportInterval(int reportInterval, string terminal_ID)
        {
            return reportnumdal.UpdateReportInterval(reportInterval, terminal_ID);
        }
        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertReportNumInfo(string terminal_ID, int reportInterval)
        {
            return reportnumdal.InsertReportNumInfo(terminal_ID, reportInterval);
        }
        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteReportNumInfo(string terminal_ID)
        {
            return reportnumdal.DeleteReportNumInfo(terminal_ID);
        }
        #endregion

        #region 人井报警信息
        /// <summary>
        /// 查询报警,状态信息
        /// </summary>
        public DataTable GetAlarmInfo_StatusInfo()
        {
            return alarmInfoDAL.GetAlarmInfo_StatusInfo();
        }
        /// <summary>
        /// 通过Terminal_ID查询报警,状态信息
        /// </summary>
        public AlarmInfo GetAlarmInfo_StatusInfo(int well_State_ID, string terminal_ID)
        {
            return alarmInfoDAL.GetAlarmInfo_StatusInfo(well_State_ID, terminal_ID);
        }
        /// <summary>
        /// 查询已处理信息
        /// </summary>
        public DataTable GetProcessedInfo()
        {
            return alarmInfoDAL.GetProcessedInfo();
        }
        /// <summary>
        /// 增加报警、状态信息
        /// </summary>
        public int InsertAlarmInfo(AlarmInfo alarmInfo)
        {
            return alarmInfoDAL.InsertAlarmInfo(alarmInfo);
        }
        /// <summary>
        /// 删除报警、状态信息
        /// </summary>
        public int DeleteAlarmInfo(string report_Time)
        {
            return alarmInfoDAL.DeleteAlarmInfo(report_Time);
        }
        /// <summary>
        /// 更新报警、状态信息
        /// </summary>
        public int UpdateAlarmInfo(int well_State_ID, string report_Time)
        {
            return alarmInfoDAL.UpdateAlarmInfo(well_State_ID, report_Time);
        }
        #endregion
    }
}
