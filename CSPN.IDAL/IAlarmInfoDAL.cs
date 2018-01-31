using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.IDAL
{
    /// <summary>
    /// 报警、状态信息
    /// </summary>
    public interface IAlarmInfoDAL
    {
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
    }
}
