using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        IList<WellStateInfo> GetWellStateInfo();
        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        WellStateInfo GetWellStateInfoByID(int id);
    }
}
