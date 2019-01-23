using CSPN.Factory;
using CSPN.IDAL;
using CSPN.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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

        #endregion Conn

        private const string SELECT_OPERATOR = "select * from CSPN_Operator_Info";
        private const string SELECT = "select * from CSPN_Operator_Info where Work_ID between (select max(Work_ID) from (select top {0} Work_ID from CSPN_Operator_Info order by Work_ID asc)) and (select max(Work_ID) from (select top {1} Work_ID from CSPN_Operator_Info order by Work_ID asc)) order by Work_ID asc";
        private const string SELECT_Count = "select count(*) from CSPN_Operator_Info";
        private const string SELECT_WELLINFO = "select count(*) from CSPN_Well_Info where Operator_ID=@Work_ID";
        private const string SELECT_OPERATOR_WORKID = "select * from CSPN_Operator_Info where Work_ID=@Work_ID";
        private const string INSERT_OPERATOR = "insert into CSPN_Operator_Info(Work_ID,RealName,Gender,Telephone,Area,ReceiveMsg) values(@Work_ID,@RealName,@Gender,@Telephone,@Area,@ReceiveMsg)";
        private const string UPDATE_OPERATOR = "update CSPN_Operator_Info set RealName=@RealName,Gender=@Gender,Telephone=@Telephone,Area=@Area,ReceiveMsg=@ReceiveMsg where Work_ID=@Work_ID";
        private const string DELETE_OPERATOR = "delete from CSPN_Operator_Info where Work_ID=@Work_ID";

        private StringBuilder sb = null;

        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetOperator_Table(int fSize, int sSize, out int pageCount)
        {
            sb = new StringBuilder();
            sb.AppendFormat(SELECT, fSize, sSize);
            using (DataTable table = new DataTable())
            {
                using (Conn)
                {
                    pageCount = (int)Conn.ExecuteScalar(SELECT_Count);
                    table.Load(Conn.ExecuteReader(sb.ToString()));
                }
                return table;
            }
        }

        /// <summary>
        /// 加载值班人员信息
        /// </summary>
        /// <returns></returns>
        public List<OperatorInfo> GetOperator()
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
        /// 查询人井信息
        /// </summary>
        /// <returns></returns>
        public int GetWellInfoByWork_ID(string work_ID)
        {
            using (Conn)
            {
                return Convert.ToInt32(Conn.ExecuteScalar(SELECT_WELLINFO, new { Work_ID = work_ID }));
            }
        }

        /// <summary>
        /// 增加值班人员信息
        /// </summary>
        /// <param name="operatorInfo">Work_ID,RealName,Gender,Telephone,Area,ReceiveMsg</param>
        /// <returns></returns>
        public int InsertOperatorInfo(OperatorInfo operatorInfo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Work_ID", operatorInfo.Work_ID);
            param.Add("@RealName", operatorInfo.RealName);
            param.Add("@Gender", operatorInfo.Gender);
            param.Add("@Telephone", operatorInfo.Telephone);
            param.Add("@Area", operatorInfo.Area);
            param.Add("@ReceiveMsg", operatorInfo.ReceiveMsg);
            using (Conn)
            {
                return Conn.Execute(INSERT_OPERATOR, param);
            }
        }

        /// <summary>
        /// 修改值班人员信息
        /// </summary>
        /// <param name="operatorInfo">Work_ID,RealName,Gender,Telephone,Area,ReceiveMsg</param>
        /// <returns></returns>
        public int UpdateOperatorInfo(OperatorInfo operatorInfo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RealName", operatorInfo.RealName);
            param.Add("@Gender", operatorInfo.Gender);
            param.Add("@Telephone", operatorInfo.Telephone);
            param.Add("@Area", operatorInfo.Area);
            param.Add("@ReceiveMsg", operatorInfo.ReceiveMsg);
            param.Add("@Work_ID", operatorInfo.Work_ID);
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