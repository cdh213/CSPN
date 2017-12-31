using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.Model
{
    /// <summary>
    /// 值班人员信息
    /// </summary>
    public class OperatorInfo
    {
        private int _ID;
        private string _work_ID;//工号
        private string _realName;//姓名
        private string _gender;//性别
        private string _telephone;//电话
        private string _area;//区域
        private string _receiveMsg;//是否接受消息

        
        #region 属性
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 工号
        /// </summary>
        public string Work_ID
        {
            get { return _work_ID; }
            set { _work_ID = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }
        /// <summary>
        /// 是否接受消息
        /// </summary>
        public string ReceiveMsg
        {
            get { return _receiveMsg; }
            set { _receiveMsg = value; }
        }
        #endregion
    }
}
