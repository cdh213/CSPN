using CSPN.Model;
using System.Collections.Generic;

namespace CSPN.IDAL
{
    /// <summary>
    /// 人井状态信息
    /// </summary>
    public interface IWellStateInfoDAL
    {
        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        /// <returns>人井状态</returns>
        List<WellStateInfo> GetWellStateInfo();
        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        WellStateInfo GetWellStateInfoByID(int id);
    }
}
