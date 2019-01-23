namespace CSPN.Model
{
    /// <summary>
    /// 人井基本信息
    /// </summary>
    public class WellInfo
    {
        private string _terminal_ID;//人井编号
        private string _name;//人井名称
        private string _longitude;//经度
        private string _latitude;//纬度
        private string _place;//地点
        private string _operator_ID;//值班人员ID
        private string _terminal_Phone;//终端手机号
        private WellCurrentStateInfo _wellCurrentStateInfo;
        private WellStateInfo _wellStateInfo;
        private OperatorInfo _operatorInfo;
        private SystemLogInfo _systemLogInfo;
        private ReportInfo _reportNumInfo;

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
        /// 人井名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        /// <summary>
        /// 地点
        /// </summary>
        public string Place
        {
            get { return _place; }
            set { _place = value; }
        }

        /// <summary>
        /// 值班人员ID
        /// </summary>
        public string Operator_ID
        {
            get { return _operator_ID; }
            set { _operator_ID = value; }
        }

        /// <summary>
        /// 终端手机号
        /// </summary>
        public string Terminal_Phone
        {
            get { return _terminal_Phone; }
            set { _terminal_Phone = value; }
        }

        public WellCurrentStateInfo WellCurrentStateInfo
        {
            get { return _wellCurrentStateInfo; }
            set { _wellCurrentStateInfo = value; }
        }

        public WellStateInfo WellStateInfo
        {
            get { return _wellStateInfo; }
            set { _wellStateInfo = value; }
        }

        public OperatorInfo OperatorInfo
        {
            get { return _operatorInfo; }
            set { _operatorInfo = value; }
        }

        public SystemLogInfo SystemLogInfo
        {
            get { return _systemLogInfo; }
            set { _systemLogInfo = value; }
        }

        public ReportInfo ReportNumInfo
        {
            get { return _reportNumInfo; }
            set { _reportNumInfo = value; }
        }

        #endregion 属性
    }
}