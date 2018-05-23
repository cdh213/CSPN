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
        /// 添加系统日志信息
        /// </summary>
        /// <param name="systemLogInfo">Happen_Time,Terminal_ID,Well_State_ID,Electricity,Temperature,Humidity,Smoke_Detector,Smoke_Power,Signal_Strength</param>
        /// <returns></returns>
        int InsertSystemLogInfo(SystemLogInfo systemLogInfo);

        /// <summary>
        /// 删除系统日志信息
        /// </summary>
        int DeleteSystemLogInfo(string nowTime, int save_Day);
    }
}