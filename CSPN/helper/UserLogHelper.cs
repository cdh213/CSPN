using CSPN.BLL;
using CSPN.IBLL;
using CSPN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.helper
{
    public class UserLogHelper
    {
        ILogService logService = new LogService();
        UserLogInfo userLogInfo = new UserLogInfo();

        /// <summary>
        /// 添加用户日志
        /// </summary>
        /// <param name="info">需要添加的日志（个数最多为5）。发生时间 操作内容 操作者 通知时间 接收到通知的人</param>
        public void InsertUserLog(params string[] info)
        {
            userLogInfo.Happen_Time = info[0];
            userLogInfo.Save_Day = 6;
            userLogInfo.Operation_Content = info[1];
            userLogInfo.The_Operator = info[2];
            userLogInfo.Notice_time = info[3];
            userLogInfo.Receive_People = info[4];
            userLogInfo.Current_State = "否";
            logService.InsertUserLogInfo(userLogInfo);
        }
        /// <summary>
        /// 更新用户日志
        /// </summary>
        /// <param name="info">需要更新的日志（个数最多为4）。处理人 处理内容 处理时间 发生时间</param>
        public void UpdateUserLog(params string[] info)
        {
            userLogInfo.Processor = info[0];
            userLogInfo.Process_Content = info[1];
            userLogInfo.Process_Time = info[2];
            userLogInfo.Current_State = "是";
            userLogInfo.Happen_Time = info[3];
            logService.UpdateUserLogInfo(userLogInfo);
        }
    }
}
