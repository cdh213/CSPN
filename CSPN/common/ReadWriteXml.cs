using System.Xml;

namespace CSPN.common
{
    /// <summary>
    /// 读写xml文件
    /// </summary>
    public static class ReadWriteXml
    {
        private static string path = @"config/setting.xml";
        private static string value = null;

        /// <summary>
        /// 读取Xml文件
        /// </summary>
        /// <param name="name">要检索的元素的限定的名称。</param>
        /// <returns>值</returns>
        public static string ReadXml(string name)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.SelectNodes("Setting");
            foreach (XmlNode node in nodes)
            {
                value = node[name].Attributes["Value"].Value;
            }
            return value;
        }

        /// <summary>
        /// 写入Xml文件
        /// </summary>
        /// <param name="name">要检索的元素的限定的名称。</param>
        /// <param name="value">要写入的值</param>
        public static void WriteXml(string name, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList nodes = doc.SelectNodes("Setting");
            foreach (XmlNode node in nodes)
            {
                node[name].Attributes["Value"].Value = value;
            }
            doc.Save(path);
        }
    }
}