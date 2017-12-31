using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UsersInfo
    {
        private string _work_ID;//工号
        private string _userName;//用户名
        private string _passWord;//密码
        private string _realName;//真实姓名
        private string _gender;//用户性别
        private string _telephone;//电话
        private string _loginTime;//最后一次登录时间

        #region 属性
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord
        {
            get { return _passWord; }
            set { _passWord = value; }
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
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }
        /// <summary>
        /// 用户性别
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
        /// 最后一次登录时间
        /// </summary>
        public string LoginTime
        {
            get { return _loginTime; }
            set { _loginTime = value; }
        }
        #endregion
    }
}
