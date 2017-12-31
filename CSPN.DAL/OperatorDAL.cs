using CSPN.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CSPN.Model;
using CSPN.IDAL;

namespace CSPN.DAL
{
    /// <summary>
    /// 值班人员管理
    /// </summary>
    public class OperatorDAL : IOperatorDAL
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

        private const string SELECT_OPERATOR = "select * from CSPN_Operator_Info";
        private const string SELECT_OPERATOR_WORKID = "select * from CSPN_Operator_Info where Work_ID=@Work_ID";
        private const string INSERT_OPERATOR = "insert into CSPN_Operator_Info(Work_ID,RealName,Gender,Telephone,Area,ReceiveMsg) values(@Work_ID,@RealName,@Gender,@Telephone,@Area,@ReceiveMsg)";
        private const string UPDATE_OPERATOR = "update CSPN_Operator_Info set Work_ID=@Work_ID,RealName=@RealName,Gender=@Gender,Telephone=@Telephone,Area=@Area,ReceiveMsg=@ReceiveMsg where Work_ID=@Work_ID";
        private const string DELETE_OPERATOR = "delete from CSPN_Operator_Info where Work_ID=@Work_ID";

        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetOperator_Table()
        {
            DataTable table = new DataTable();
            using (Conn)
            {
                table.Load(Conn.ExecuteReader(SELECT_OPERATOR));
            }
            return table;
        }
        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        public IList<OperatorInfo> GetOperator()
        {
            using (Conn)
            {
                return Conn.Query<OperatorInfo>(SELECT_OPERATOR).ToList();
            }
        }
        /// <summary>
        /// 查询人员信息
        /// </summary>
        /// <returns></returns>
        public OperatorInfo GetOperatorByWork_ID(string work_ID)
        {
            using (Conn)
            {
                return Conn.Query<OperatorInfo>(SELECT_OPERATOR_WORKID, new { Work_ID = work_ID }).FirstOrDefault();
            }
        }
        /// <summary>
        /// 增加值班人员信息
        /// </summary>
        /// <returns></returns>
        public int InsertOperatorInfo(OperatorInfo oper)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Work_ID", oper.Work_ID);
            param.Add("@RealName", oper.RealName);
            param.Add("@Gender", oper.Gender);
            param.Add("@Telephone", oper.Telephone);
            param.Add("@Area", oper.Area);
            param.Add("@ReceiveMsg", oper.ReceiveMsg);
            using (Conn)
            {
                return Conn.Execute(INSERT_OPERATOR, param);
            }
        }
        /// <summary>
        /// 修改值班人员信息
        /// </summary>
        /// <returns></returns>
        public int UpdateOperatorInfo(OperatorInfo oper)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Work_ID", oper.Work_ID);
            param.Add("@RealName", oper.RealName);
            param.Add("@Gender", oper.Gender);
            param.Add("@Telephone", oper.Telephone);
            param.Add("@Area", oper.Area);
            param.Add("@ReceiveMsg", oper.ReceiveMsg);
            using (Conn)
            {
                return Conn.Execute(UPDATE_OPERATOR, param);
            }
        }
        /// <summary>
        /// 删除值班人员信息
        /// </summary>
        /// <returns></returns>
        public int DeleteOperatorInfo(string workid)
        {
            using (Conn)
            {
                return Conn.Execute(DELETE_OPERATOR, new { Work_ID = workid });
            }
        }
    }
}
