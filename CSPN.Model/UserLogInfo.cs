using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.Model
{
    /// <summary>
    /// 用户日志信息
    /// </summary>
    public class UserLogInfo
    {
        private string _happen_Time;//发生时间
        private string _operation_Content;//操作内容
        private string _the_Operator;//操作者
        private string _notice_time;//通知时间
        private string _receive_People;//接收到通知的人
        private string _process_Time;//处理时间
        private string _processor;//处理人
        private string _process_Content;//处理内容
        private string _current_State;//当前状态是否处理

        #region 属性
        /// <summary>
        /// 通知时间
        /// </summary>
        public string Happen_Time
        {
            get { return _happen_Time; }
            set { _happen_Time = value; }
        }
        /// <summary>
        /// 操作者
        /// </summary>
        public string The_Operator
        {
            get { return _the_Operator; }
            set { _the_Operator = value; }
        }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string Operation_Content
        {
            get { return _operation_Content; }
            set { _operation_Content = value; }
        }
        /// <summary>
        /// 通知时间
        /// </summary>
        public string Notice_time
        {
            get { return _notice_time; }
            set { _notice_time = value; }
        }
        /// <summary>
        /// 处理时间
        /// </summary>
        public string Process_Time
        {
            get { return _process_Time; }
            set { _process_Time = value; }
        }
        /// <summary>
        /// 处理人
        /// </summary>
        public string Processor
        {
            get { return _processor; }
            set { _processor = value; }
        }
        /// <summary>
        /// 接收到通知的人
        /// </summary>
        public string Receive_People
        {
            get { return _receive_People; }
            set { _receive_People = value; }
        }
        /// <summary>
        /// 处理内容
        /// </summary>
        public string Process_Content
        {
            get { return _process_Content; }
            set { _process_Content = value; }
        }
        /// <summary>
        /// 当前状态是否处理
        /// </summary>
        public string Current_State
        {
            get { return _current_State; }
            set { _current_State = value; }
        }
        #endregion
    }
}
