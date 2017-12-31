using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.Model
{
    /// <summary>
    /// 人井状态信息字典表
    /// </summary>
    public class WellStateInfo
    {
        private int _ID;
        private string _state;//状态信息
        private string _color;//状态信息图标颜色
        private string _icon;//状态图标地址
        
        #region 属性
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        /// <summary>
        /// 状态信息
        /// </summary>
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 状态信息图标颜色
        /// </summary>
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        /// <summary>
        /// 状态图标地址
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        #endregion
    }
}
