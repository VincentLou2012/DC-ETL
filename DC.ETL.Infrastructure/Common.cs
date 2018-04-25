using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DC.ETL.Infrastructure
{
    public class Commons
    {
        private static string key = "default";
        /// <summary>
        /// 默认加密方法
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string DESEncrypt(string text)
        {
            return DESEncrypt(text, key);
        }
        /// <summary>
        /// DES加密方法
        /// </summary>
        /// <param name="text">明文</param>
        /// <param name="sKey">密钥</param>
        /// <returns>加密后的密文</returns>
        public static string DESEncrypt(string text, string sKey)
        {
            //加密
            return text;

        }
        /// <summary>
        /// DES解密方法，默认方法
        /// </summary>
        /// <param name="text">待加密明文</param>
        /// <returns>加密后的密文</returns>
        public static string DESDecrypt(string text)
        {
            return DESDecrypt(text, key);
        }
        /// <summary>
        /// DES解密方法
        /// </summary>
        /// <param name="text">密文</param>
        /// <param name="sKey">密钥</param>
        /// <returns>解密后的明文</returns>
        public static string DESDecrypt(string text, string sKey)
        {
            //TODO:解密
            return text;

        }

        /// <summary>
        /// ip数组转8进制
        /// </summary>
        /// <param name="iparr"></param>
        /// <returns></returns>
        public static string ConvertTo8Binary(int[] iparr)
        {
            string ips = string.Empty;
            foreach (var ipe in iparr)
            {
                string ipbn = Convert.ToString(ipe, 2).PadLeft(8, '0');
                ips += ipbn;
            }
            return ips;
        }

        /// <summary>
        /// 二进制码转IPv4地址
        /// </summary>
        /// <param name="binaryStr">32位二进制码</param>
        /// <returns></returns>
        public static string BinaryToIPstr(string binaryStr)
        {
            string IPSTR = string.Empty;
            for (int i = 0; i < binaryStr.Length; i += 8)
            {
                string ipbstr = binaryStr.Substring(i, 8);
                IPSTR += Convert.ToInt32(ipbstr, 2) + ".";
            }
            IPSTR = IPSTR.Remove(IPSTR.Length - 1, 1);
            return IPSTR;
        }
    }
}
