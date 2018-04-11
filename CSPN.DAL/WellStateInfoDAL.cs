using CSPN.Factory;
using CSPN.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using CSPN.IDAL;

namespace CSPN.DAL
{
    /// <summary>
    /// 人井状态信息
    /// </summary>
    public class WellStateInfoDAL : IWellStateInfoDAL
    {
        #region Conn
        private IDbConnection _conn;
        public IDbConnection Conn
        {
            get
            {
                return _conn = ConnectionFactory.CreateConnection();
            }
        }
        #endregion

        private const string SELECT_WELL_STATE = "select * from CSPN_Dic_Well_State_Info where ID=1 or ID=2 or ID=6";
        private const string SELECT_WELL_STATE_ID = "select * from CSPN_Dic_Well_State_Info where ID=@ID";

        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        public List<WellStateInfo> GetWellStateInfo()
        {
            using (Conn)
            {
                return Conn.Query<WellStateInfo>(SELECT_WELL_STATE).ToList();
            }
        }
        /// <summary>
        /// 查询人井状态信息
        /// </summary>
        public WellStateInfo GetWellStateInfoByID(int id)
        {
            WellStateInfo wellStateInfo = new WellStateInfo();
            using (Conn)
            {
                using(IDataReader read = Conn.ExecuteReader(SELECT_WELL_STATE_ID, new { ID = id }))
                {
                    while (read.Read())
                    {
                        wellStateInfo.ID = int.Parse(read["ID"].ToString());
                        wellStateInfo.State = read["State"].ToString();
                        wellStateInfo.Color = read["Color"].ToString();
                        wellStateInfo.Icon = read["Icon"].ToString();
                    }
                }
            }
            return wellStateInfo;
        }
    }
}
