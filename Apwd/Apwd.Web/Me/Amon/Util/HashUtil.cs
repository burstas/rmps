﻿using System;
using System.Security.Cryptography;

namespace Me.Amon.Util
{
    /// <summary>
    /// HashUtil 的摘要说明
    /// </summary>
    public class HashUtil
    {
        private HashUtil()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bigCase"></param>
        /// <returns></returns>
        public static String getCurrTimeHex(bool bigCase)
        {
            return CharUtil.encodeLong(DateTime.UtcNow.ToBinary(), bigCase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static byte[] digest(String text, String hash)
        {
            // 参数为不空检测
            if (CharUtil.isValidate(text) && CharUtil.isValidate(hash))
            {
                try
                {
                    // 获取摘要对象实例
                    MD5 md = MD5.Create(hash);
                    // 字符串到字节转换
                    byte[] mesg = CharUtil.getBytes(text);
                    // 数据摘要
                    return md.ComputeHash(mesg);
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }
            }

            return (new byte[0]);
        }

        public static String digest(String text, bool bigCase)
        {
            return CharUtil.EncodeBytes(digest(text, "MD5"), bigCase);
        }
    }
}