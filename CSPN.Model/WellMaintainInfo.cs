namespace CSPN.Model
{
    public class WellMaintainInfo
    {
        private string _terminal_ID;//人井编号
        private string _maintain_StartTime;//维护开始时间
        private string _maintain_EndTime;//维护结束结束
        private int _maintain_State;//维护状态 0：不维护 1：维护
        private WellCurrentStateInfo _wellCurrentStateInfo;

        #region 属性

        /// <summary>
        /// 人井编号
        /// </summary>
        public string Terminal_ID
        {
            get { return _terminal_ID; }
            set { _terminal_ID = value; }
        }

        /// <summary>
        /// 维护开始时间
        /// </summary>
        public string Maintain_StartTime
        {
            get { return _maintain_StartTime; }
            set { _maintain_StartTime = value; }
        }

        /// <summary>
        /// 维护结束时间
        /// </summary>
        public string Maintain_EndTime
        {
            get { return _maintain_EndTime; }
            set { _maintain_EndTime = value; }
        }

        /// <summary>
        /// 维护状态 0：不维护 1：维护
        /// </summary>
        public int Maintain_State
        {
            get { return _maintain_State; }
            set { _maintain_State = value; }
        }

        public WellCurrentStateInfo WellCurrentStateInfo
        {
            get { return _wellCurrentStateInfo; }
            set { _wellCurrentStateInfo = value; }
        }

        #endregion 属性
    }
}