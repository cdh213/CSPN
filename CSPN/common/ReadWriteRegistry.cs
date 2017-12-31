using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.common
{
    /// <summary>
    /// 读写注册表
    /// </summary>
    public class ReadWriteRegistry
    {
        /// <summary>
        /// 写入注册表
        /// </summary>
        /// <param name="name">要存储的值的名称。</param>
        /// <param name="value">要存储的数据。</param>
        public static void WriteRegistry(string name, object value)
        {
            using (RegistryKey software = Registry.CurrentUser.CreateSubKey("Software\\CSPN", RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                software.SetValue(name, value, RegistryValueKind.String);
            }
        }
        /// <summary>
        /// 读取注册表
        /// </summary>
        /// <param name="name">要存储的值的名称。</param>
        /// <returns>与 name 关联的值；如果未找到 name，则为 null。</returns>
        public static string ReadRegistry(string name)
        {
            string value = null;
            using (RegistryKey software = Registry.CurrentUser.OpenSubKey("Software\\CSPN",true))
            {
                if (software != null)
                {
                    if (software.GetValue(name) != null) //读取失败返回null
                    {
                        value = software.GetValue(name).ToString();
                    }
                }
                return value;
            }
        }
    }
}
