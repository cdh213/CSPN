using CSPN.BLL;
using CSPN.IBLL;
using CSPN.Model;

namespace CSPN.helper
{
    public class UserLogHelper
    {
        private ILogService logService = new LogService();
        private UserLogInfo userLogInfo = new UserLogInfo();

        /// <summary>
        /// 添加用户日志（发生时间 操作内容 操作者 人井编号 通知时间 接收到通知的人 没有为null）。
        /// </summary>
        /// <param name="info">需要添加的日志（个数最多为6），没有为null。发生时间 操作内容 操作者 人井编号 通知时间 接收到通知的人</param>
        public void InsertUserLog(params string[] info)
        {
            userLogInfo.Happen_Time = info[0];
            userLogInfo.Operation_Content = info[1];
            userLogInfo.The_Operator = info[2];
            userLogInfo.Terminal_ID = info[3];
            userLogInfo.Notice_time = info[4];
            userLogInfo.Receive_People = info[5];
            userLogInfo.Current_State = "否";
            logService.InsertUserLogInfo(userLogInfo);
        }

        /// <summary>
        /// 更新用户日志（处理人 处理内容 处理时间 发生时间）。
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