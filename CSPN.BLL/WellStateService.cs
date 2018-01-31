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
        public DataTable GetMaintainInfo(int pageSize, int pageIndex, out int pageCount)
        {
            int fSize = pageSize * (pageIndex - 1) + 1;
            int sSize = fSize + (pageSize - 1);
            return wellcurrentdal.GetMaintainInfo(fSize, sSize, out pageCount);
        }
        /// <summary>
        /// 维护信息更新
        /// </summary>
        public int UpdateMaintainInfo(WellCurrentStateInfo wellCurrentStateInfo)
        {
            return wellcurrentdal.UpdateMaintainInfo(wellCurrentStateInfo);
        }
        /// <summary>
        /// 通过维护开始时间查询人井
        /// </summary>
        public object GetMaintain_StartTime(string startTime)
        {
            return wellcurrentdal.GetMaintain_StartTime(startTime);
        }
        /// <summary>
        /// 通过维护结束时间查询人井
        /// </summary>
        public object GetMaintain_EndTime(string endTime)
        {
            return wellcurrentdal.GetMaintain_EndTime(endTime);
        }
        #endregion
    }
}
