using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.IDAL
{
    public interface IWellMaintainDAL
    {
        /// <summary>
        /// 加载维护信息
        /// </summary>
        DataTable GetMaintainInfo(int fSize, int sSize, out int pageCount);

        /// <summary>
        /// 通过维护开始时间查询人井
        /// </summary>
        List<WellMaintainInfo> GetMaintain_StartTime(string startTime);

        /// <summary>
        /// 通过维护结束时间查询人井
        /// </summary>
        List<WellMaintainInfo> GetMaintain_EndTime(string endTime);

        /// <summary>
        /// 维护信息更新
        /// </summary>
        /// <param name="wellMaintainInfo">Maintain_StartTime,Maintain_EndTime,Terminal_ID</param>
        /// <returns></returns>
        int UpdateMaintainInfo(WellMaintainInfo wellMaintainInfo);

        /// <summary>
        /// 维护信息更新
        /// </summary>
        int UpdateMaintainInfo(int maintain_State, string terminal_ID);

        /// <summary>
        /// 增加维护信息
        /// </summary>
        int InsertMaintainInfo(string terminal_ID, int maintain_State);

        /// <summary>
        /// 取消维护
        /// </summary>
        int MaintainInfoCancel(int maintain_State, string terminal_ID);

        /// <summary>
        /// 删除人井信息
        /// </summary>
        int DeleteWellMaintainInfo(string terminal_ID);
    }
}