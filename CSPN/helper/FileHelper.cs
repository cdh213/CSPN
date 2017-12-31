using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.helper
{
    public class FileHelper
    {
        /// <summary>
        /// 获取文件夹的大小
        /// </summary>
        /// <param name="filePath">文件夹路径</param>
        /// <returns></returns>
        public long FileSize(string filePath)
        {
            long temp = 0;
            //判断当前路径所指向的是否为文件
            if (File.Exists(filePath) == false)
            {
                string[] str1 = Directory.GetFileSystemEntries(filePath);
                foreach (string s1 in str1)
                {
                    temp += FileSize(s1);
                }
            }
            else
            {
                //定义一个FileInfo对象,使之与filePath所指向的文件向关联,
                //以获取其大小
                FileInfo fileInfo = new FileInfo(filePath);
                return fileInfo.Length;
            }
            return temp;
        }
        /// <summary>
        /// 删除文件夹内的内容
        /// </summary>
        /// <param name="srcPath"></param>
        public void DelectDir(string filePath)
        {
            DirectoryInfo dir = new DirectoryInfo(filePath);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
            foreach (FileSystemInfo file in fileinfo)
            {
                if (file is DirectoryInfo)            //判断是否文件夹
                {
                    DirectoryInfo subdir = new DirectoryInfo(file.FullName);
                    subdir.Attributes = FileAttributes.Normal;
                    subdir.Delete(true);          //删除子目录和文件
                }
                else
                {
                    File.SetAttributes(file.FullName, FileAttributes.Normal);
                    File.Delete(file.FullName);      //删除指定文件
                }
            }
        }
    }
}
