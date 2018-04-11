using CSPN.Model;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSPN.common
{
    public class ReadWriteData
    {
        Dictionary<string, UsersInfo> users = new Dictionary<string, UsersInfo>();
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, UsersInfo> ReadData()
        {
            //读取文件流对象
            using (FileStream fs = new FileStream("Database/data.bin", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    //读出存在Data.bin 里的用户信息
                    users = bf.Deserialize(fs) as Dictionary<string, UsersInfo>;
                }
                return users;
            }
        }
        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="usersInfo">UsersInfo</param>
        public void WriteData(UsersInfo usersInfo)
        {
            using (FileStream fs = new FileStream("Database/data.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                //选在集合中是否存在用户名 
                if (users.ContainsKey(usersInfo.UserName))
                {
                    //如果有清掉
                    users.Remove(usersInfo.UserName);
                }
                //添加用户信息到集合
                users.Add(usersInfo.UserName, usersInfo);
                //写入文件
                bf.Serialize(fs, users);
            }
        }
    }
}
