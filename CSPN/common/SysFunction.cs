using System;
using System.Security.Cryptography;

namespace CSPN.common
{
    public static class SysFunction
    {
        /// <summary>
        /// 将字符串转换为byte数组
        /// </summary>
        /// <param name="ps_str">需要转换的字符串</param>
        /// <returns></returns>
        private static byte[] ConvertToByteArray(string ps_str)
        {
            char[] arrChar;
            int iCount;

            arrChar = ps_str.ToCharArray();
            iCount = arrChar.Length - 1;
            byte[] arrByte = new byte[iCount];

            for (int i = 0; i < iCount; i++)
            {
                arrByte[i] = Convert.ToByte(arrChar[i]);
            }
            return arrByte;
        }

        /// <summary>
        /// 返回指定字符串的128位hash加密串
        /// </summary>
        /// <param name="ps_sourceStr">需要加密的字符串</param>
        /// <returns>返回已加密的串</returns>
        public static string GetSecurit(string ps_sourceStr)
        {
            byte[] myHashInput, myHashOutput;
            MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();
            myHashInput = ConvertToByteArray(ps_sourceStr);
            myHashOutput = myMD5.ComputeHash(myHashInput);
            return BitConverter.ToString(myHashOutput);
        }
    }
}
