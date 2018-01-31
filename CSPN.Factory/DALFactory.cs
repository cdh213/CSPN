using CSPN.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.Factory
{
    /// <summary>
    /// DAL工厂，读取App.config的配置文件
    /// 实例化相应的DAL对象
    /// </summary>
    public class DALFactory
    {
        private static readonly string path = "CSPN.DAL";

        public DALFactory() { }

        public static IOperatorDAL CreateOperatorDAL()
        {
            string className = path + ".OperatorDAL";
            return (IOperatorDAL)Assembly.Load(path).CreateInstance(className);
        }
        public static ISystemLogDAL CreateSystemLogDAL()
        {
            string className = path + ".SystemLogDAL";
            return (ISystemLogDAL)Assembly.Load(path).CreateInstance(className);
        }
        public static IUserLogDAL CreateUserLogDAL()
        {
            string className = path + ".UserLogDAL";
            return (IUserLogDAL)Assembly.Load(path).CreateInstance(className);
        }
        public static IUsersManageDAL CreateUsersManagDAL()
        {
            string className = path + ".UsersManageDAL";
            return (IUsersManageDAL)Assembly.Load(path).CreateInstance(className);
        }
        public static IWellCurrentStateDAL CreateWellCurrentStateDAL()
        {
            string className = path + ".WellCurrentStateDAL";
            return (IWellCurrentStateDAL)Assembly.Load(path).CreateInstance(className);
        }
        public static IWellInfoDAL CreateWellInfoDAL()
        {
            string className = path + ".WellInfoDAL";
            return (IWellInfoDAL)Assembly.Load(path).CreateInstance(className);
        }
        public static IWellStateInfoDAL CreateWellStateInfoDAL()
        {
            string className = path + ".WellStateInfoDAL";
            return (IWellStateInfoDAL)Assembly.Load(path).CreateInstance(className);
        }
        public static IReportNumInfoDAL CreateReportNumInfoDAL()
        {
            string className = path + ".ReportNumInfoDAL";
            return (IReportNumInfoDAL)Assembly.Load(path).CreateInstance(className);
        }
        public static IAlarmInfoDAL CreateAlarmInfoDAL()
        {
            string className = path + ".AlarmInfoDAL";
            return (IAlarmInfoDAL)Assembly.Load(path).CreateInstance(className);
        }
    }
}
