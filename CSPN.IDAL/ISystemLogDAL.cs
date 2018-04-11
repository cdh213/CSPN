using System;
using CSPN.Model;
using System.Data;

namespace CSPN.IDAL
{
    public interface ISystemLogDAL
    {
        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        DataTable GetSystemLogInfo();
        /// <summary>
        /// 查询系统日志信息
        /// </summary>
        DataTable GetSystemLogInfo(int fSize, int sSize, out int pageCount);
        /// <summary>
        /// 查询发生时间的最小值
        /// </summary>
        DateTime GetMinHappen_Time();
        /// <summary>
        /// 添加系统日志信息
        /// </summary>
        int InsertSystemLogInfo(SystemLogInfo sysLog);
        /// <summary>
        /// 删除系统日志信息
        /// </summary>
        int DeleteSystemLogInfo(string nowTime, int save_Day);
    }
}
