using CSPN.Model;
using System.Collections.Generic;
using System.Data;

namespace CSPN.IDAL
{
    /// <summary>
    /// 值班人员管理
    /// </summary>
    public interface IOperatorDAL
    {
        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        DataTable GetOperator_Table(int fSize, int sSize, out int pageCount);
        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        List<OperatorInfo> GetOperator();
        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <returns></returns>
        OperatorInfo GetOperatorByWork_ID(string work_ID);
        /// <summary>
        /// 增加值班人员信息
        /// </summary>
        /// <returns></returns>
        int InsertOperatorInfo(OperatorInfo oper);
        /// <summary>
        /// 修改值班人员信息
        /// </summary>
        /// <returns></returns>
        int UpdateOperatorInfo(OperatorInfo oper);
        /// <summary>
        /// 删除值班人员信息
        /// </summary>
        /// <returns></returns>
        int DeleteOperatorInfo(string workid);
    }
}
