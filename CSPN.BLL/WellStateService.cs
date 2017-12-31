using CSPN.Factory;
using CSPN.IBLL;
using CSPN.IDAL;
using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.BLL
{
    /// <summary>
    /// 人井状态信息服务
    /// </summary>
    public class WellStateService : IWellStateService
    {
        private static readonly IWellStateInfoDAL wellstatedal = DALFactory.CreateWellStateInfoDAL();
        private static readonly IWellCurrentStateDAL wellcurrentdal = DALFactory.CreateWellCurrentStateDAL();

        #region 人井状态信息
        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        /// <returns>人井状态</returns>
        public IList<WellStateInfo> GetWellStateInfo()
        {
            return wellstatedal.GetWellStateInfo();
        }
        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public WellStateInfo GetWellStateInfoByID(int id)
        {
            return wellstatedal.GetWellStateInfoByID(id);
        }
        #endregion

        #region 人井当前状态信息
        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        public int UpdateWellCurrentStateInfo(WellCurrentStateInfo wellCurrentStateInfo)
        {
            return wellcurrentdal.UpdateWellCurrentStateInfo(wellCurrentStateInfo);
        }
        /// <summary>
        /// 更新当前人井状态信息
        /// </summary>
        public int UpdateWellCurrentStateInfo(int well_State_ID, string terminal_ID)
        {
            return wellcurrentdal.UpdateWellCurrentStateInfo(well_State_ID, terminal_ID);
        }
        /// <summary>
        /// 查询报警,状态信息
        /// </summary>
        public IList<WellCurrentStateInfo> GetAlarmInfo_StatusInfo()
        {
            return wellcurrentdal.GetAlarmInfo_StatusInfo();
        }
        /// <summary>
        /// 通过Terminal_ID查询报警,状态信息
        /// </summary>
        public WellCurrentStateInfo GetAlarmInfo_StatusInfo(string terminal_ID)
        {
            return wellcurrentdal.GetAlarmInfo_StatusInfo(terminal_ID);
        }
        /// <summary>
        /// 通过Well_State_ID，Terminal_ID查询报警,状态信息
        /// </summary>
        public WellCurrentStateInfo GetAlarmInfo_StatusInfo(int well_State_ID, string terminal_ID)
        {
            return wellcurrentdal.GetAlarmInfo_StatusInfo(well_State_ID, terminal_ID);
        }
        /// <summary>
        /// 查询已处理信息
        /// </summary>
        public IList<WellCurrentStateInfo> GetProcessedInfoByWell_State_ID(int well_State_ID)
        {
            return wellcurrentdal.GetProcessedInfoByWell_State_ID(well_State_ID);
        }
        /// <summary>
        /// 增加人井信息
        /// </summary>
        public int InsertWellCurrentStateInfo(string terminal_ID, int well_State_ID)
        {
            return wellcurrentdal.InsertWellCurrentStateInfo(terminal_ID, well_State_ID);
        }
        /// <summary>
        /// 删除人井信息
        /// </summary>
        public int DeleteWellCurrentStateInfo(string terminal_ID)
        {
            return wellcurrentdal.DeleteWellCurrentStateInfo(terminal_ID);
        }
        #endregion

        #region 维护信息
        /// <summary>
        /// 加载维护信息
        /// </summary>
        public DataTable GetAppointmentInfo()
        {
            return wellcurrentdal.GetAppointmentInfo();
        }
        /// <summary>
        /// 维护信息更新
        /// </summary>
        public int UpdateAppointmentInfo(int well_State_ID, string terminal_ID)
        {
            return wellcurrentdal.UpdateAppointmentInfo(well_State_ID, terminal_ID);
        }
        #endregion
    }
}
