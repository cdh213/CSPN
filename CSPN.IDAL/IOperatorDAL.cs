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
    /// 值班人员管理
    /// </summary>
    public interface IOperatorDAL
    {
        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        DataTable GetOperator_Table();
        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        IList<OperatorInfo> GetOperator();
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
