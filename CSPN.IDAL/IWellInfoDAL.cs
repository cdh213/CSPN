using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.IDAL
{
    /// <summary>
    /// 主页人井信息
    /// </summary>
    public interface IWellInfoDAL
    {
        /// <summary>
        /// 查询人井信息
        /// </summary>
        DataTable GetWellInfo_Table(string wellinfo, int fSize, int sSize, out int pageCount);
        /// <summary>
        /// 查询人井信息
        /// </summary>
        List<WellInfo> GetWellInfo_List(string wellinfo);
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
    }
}
