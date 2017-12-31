using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSPN.Model;
using System.ServiceModel;
using System.Data;

namespace CSPN.IDAL
{
    public interface ISystemLogDAL
    {
        DataTable GetSystemLogInfo();
        int InsertSystemLogInfo(SystemLogInfo sysLog);
        int DeleteSystemLogInfo(SystemLogInfo sysLog);
    }
}
