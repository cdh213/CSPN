using CSPN.IDAL;
using System.Reflection;

namespace CSPN.Factory
{
    /// <summary>
    /// DAL工厂，读取App.config的配置文件
    /// 实例化相应的DAL对象
    /// </summary>
    public class DALFactory
    {
        private static readonly string path = "CSPN.DAL";

        public DALFactory()
        {
        }

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

        public static IUsersDAL CreateUsersDAL()
        {
            string className = path + ".UsersDAL";
            return (IUsersDAL)Assembly.Load(path).CreateInstance(className);
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

        public static IWellStateDAL CreateWellStateDAL()
        {
            string className = path + ".WellStateDAL";
            return (IWellStateDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static IReportDAL CreateReportDAL()
        {
            string className = path + ".ReportDAL";
            return (IReportDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static IWellMaintainDAL CreateWellMaintainDAL()
        {
            string className = path + ".WellMaintainDAL";
            return (IWellMaintainDAL)Assembly.Load(path).CreateInstance(className);
        }
    }
}