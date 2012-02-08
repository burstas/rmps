﻿using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Da;
using Me.Amon.Util;
using System.Xml;
using System.Text.RegularExpressions;

namespace Me.Amon.Model
{
    public sealed class UserModel
    {
        #region 全局变量
        private string _Info;
        private byte[] _Data;

        private byte[] _Keys;
        private byte[] _Salt;
        private char[] _Mask;

        public string Code { get { return _Code; } }
        private string _Code;
        public string Name { get { return _Name; } }
        private string _Name;
        public string Home { get { return _Home; } }
        private string _Home;
        public string Look { get; set; }
        public string Feel { get; set; }
        #endregion

        #region 权限认证
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public bool CaSignIn(string home, string code, string name, string pass)
        {
            string file = home + IEnv.AMON_CFG;
            if (!File.Exists(file))
            {
                return false;
            }

            Uc.Properties prop = new Uc.Properties();
            prop.Load(file);

            string hash = prop.Get(IEnv.AMON_CFG_DATA);
            if (!CharUtil.IsValidate(hash, 344))
            {
                return false;
            }
            _Data = Convert.FromBase64String(hash);
            hash = Digest(name, pass);
            if (hash != prop.Get(IEnv.AMON_CFG_INFO))
            {
                return false;
            }
            string data = prop.Get(IEnv.AMON_CFG_MAIN);

            if (!Decrypt(name, code, pass, data))
            {
                return false;
            }

            _Name = name;
            _Code = code;
            _Info = hash;
            _Home = home;
            Look = "Default";
            Feel = "Default";
            return true;
        }

        /// <summary>
        /// 重新认证
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CaSignRc(string name, string info)
        {
            return (name == _Name && info == _Info);
        }

        /// <summary>
        /// 屏幕加锁
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool CaSignAc(string pass)
        {
            return _Info == Digest(Name, pass);
        }

        public bool CaSignWs(string root, string name, string pass, string text)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(text);
            #region Code
            XmlNode node = doc.SelectSingleNode("/Amon/User/Code");
            if (node == null)
            {
                return false;
            }
            string code = node.InnerText;
            if (!Regex.IsMatch(code, "^[A-Z0-9]{8}$"))
            {
                return false;
            }
            #endregion

            #region Data
            node = doc.SelectSingleNode("/Amon/User/Data");
            if (node == null)
            {
                return false;
            }
            string data = node.InnerText;
            if (!Regex.IsMatch(data, "^[A-Za-z0-9+/=]{256,}$"))
            {
                return false;
            }
            #endregion

            #region Info
            node = doc.SelectSingleNode("/Amon/User/Info");
            if (node == null)
            {
                return false;
            }
            string info = node.InnerText;
            if (!Regex.IsMatch(info, "^[A-Za-z0-9+/=]{44}$"))
            {
                return false;
            }
            #endregion

            #region Main
            node = doc.SelectSingleNode("/Amon/User/Main");
            if (node == null)
            {
                return false;
            }
            string main = node.InnerText;
            if (!Regex.IsMatch(main, "^[A-Za-z0-9+/=]{108}$"))
            {
                return false;
            }
            #endregion

            #region Safe
            node = doc.SelectSingleNode("/Amon/User/Safe");
            if (node == null)
            {
                return false;
            }
            string safe = node.InnerText;
            #endregion

            _Data = Convert.FromBase64String(data);
            if (info != Digest(name, pass))
            {
                return false;
            }

            if (!Decrypt(name, code, pass, main))
            {
                return false;
            }

            CaSignNw(root, name, code, Convert.ToBase64String(_Data), info, main, "");
            _Home = root + code + Path.DirectorySeparatorChar;
            Look = "Default";
            Feel = "Default";
            return true;
        }

        /// <summary>
        /// 网络登录
        /// </summary>
        /// <returns></returns>
        public bool CaSignNw(string root, string name, string code, string data, string info, string main, string safe)
        {
            root += code;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            Uc.Properties prop = new Uc.Properties();
            prop.Set(IEnv.AMON_CFG_NAME, name);
            prop.Set(IEnv.AMON_CFG_CODE, code);
            prop.Set(IEnv.AMON_CFG_DATA, data);
            prop.Set(IEnv.AMON_CFG_INFO, info);
            prop.Set(IEnv.AMON_CFG_MAIN, main);
            prop.Set(IEnv.AMON_CFG_SAFE, safe);
            prop.Save(root + Path.DirectorySeparatorChar + IEnv.AMON_CFG);
            return true;
        }

        /// <summary>
        /// 修改登录口令
        /// </summary>
        /// <param name="oldPwds"></param>
        /// <param name="newPwds"></param>
        /// <returns></returns>
        public bool CaSignPk(string oldPwds, string newPwds)
        {
            // 已有口令校验
            if (_Info != Digest(Name, oldPwds))
            {
                return false;
            }

            // 生成加密密钥及字符空间
            byte[] t = new byte[72];
            byte[] a = Encoding.UTF8.GetBytes(Code);
            int i = 0;
            Array.Copy(a, 0, t, i, a.Length);
            i += a.Length;
            Array.Copy(_Salt, 0, t, i, _Salt.Length);
            i += _Salt.Length;
            Array.Copy(_Keys, 0, t, i, _Keys.Length);
            i += _Keys.Length;
            a = Encoding.UTF8.GetBytes(_Mask);
            Array.Copy(a, 0, t, i, a.Length);

            // 口令
            byte[] k = GenK(Name, Code, newPwds);
            // 向量
            byte[] v = GenV(Name, Code, newPwds);

            #region AES 加密
            AesManaged aes = new AesManaged();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(k, v), CryptoStreamMode.Write))
                {
                    cStream.Write(t, 0, t.Length);
                    cStream.FlushFinalBlock();
                    t = mStream.ToArray();
                }
            }
            aes.Clear();
            #endregion

            // 摘要用户登录信息
            _Info = Digest(Name, newPwds);

            string data = Convert.ToBase64String(t);
            Uc.Properties prop = new Uc.Properties();
            prop.Set(IEnv.AMON_CFG_INFO, _Info);
            prop.Set(IEnv.AMON_CFG_MAIN, data);
            prop.Save(Home + IEnv.AMON_CFG);

            return true;
        }

        /// <summary>
        /// 口令找回
        /// </summary>
        /// <param name="usrName"></param>
        /// <param name="secPwds"></param>
        /// <returns></returns>
        public bool CaSignFp(string usrName, StringBuilder secPwds)
        {
            //name = usrName;

            //// 用户登录身份认证
            //string text = userMdl.getCfg(ConsCfg.CFG_USER_SKEY, "");
            //if (!com.magicpwd._util.Char.isValidate(text))
            //{
            //    return false;
            //}

            //pwds = secPwds.toString();
            //byte[] temp = signSkDigest();
            //if (text.indexOf(Util.bytesToString(temp, true)) != 0)
            //{
            //    return false;
            //}

            //// 获取用户配置密文
            //keys = cipherDigest();

            //text = text.substring(128);
            //temp = Char.toBytes(text, true);

            //// 解密用户配置密文获得解密数据
            //Cipher aes = Cipher.getInstance(ConsEnv.NAME_CIPHER);
            //aes.init(Cipher.DECRYPT_MODE, this);
            //temp = aes.doFinal(temp);

            //// 生成随机口令
            //this.name = usrName;
            //this.pwds = new string(generateUserChar());
            //byte[] t = signInDigest();
            //userMdl.setCfg(ConsCfg.CFG_USER_INFO, Util.bytesToString(t, true));

            //this.keys = cipherDigest();
            //aes.init(Cipher.ENCRYPT_MODE, this);
            //t = aes.doFinal(temp);
            //userMdl.setCfg(ConsCfg.CFG_USER_PKEY, Util.bytesToString(t, true));

            //System.arraycopy(temp, 16, keys, 0, temp.length - 16);
            //mask = new string(temp, 0, 16).toCharArray();
            //secPwds.delete(0, secPwds.length()).append(pwds);
            return true;
        }

        /// <summary>
        /// 设定安全口令
        /// </summary>
        /// <param name="oldPwds"></param>
        /// <param name="secPwds"></param>
        /// <returns></returns>
        public bool CaSignSk(string oldPwds, string secPwds)
        {
            //// 已有口令校验
            //pwds = oldPwds;
            //byte[] temp = signInDigest();
            //if (!Util.bytesToString(temp, true).equals(userMdl.getCfg(ConsCfg.CFG_USER_INFO, "")))
            //{
            //    return false;
            //}

            //// 认证信息
            //this.pwds = secPwds;
            //string sKey = Util.bytesToString(signSkDigest(), true);

            //temp = new string(mask).getBytes();

            //// 生成加密密钥及字符空间
            //byte[] t = new byte[32];
            //System.arraycopy(temp, 0, t, 0, temp.length);// 字符空间
            //System.arraycopy(keys, 0, t, 16, keys.length);// 加密密钥

            //// 摘要用户加密信息
            //temp = keys;
            //keys = cipherDigest();

            //// 加密安全数据
            //Cipher aes = Cipher.getInstance(ConsEnv.NAME_CIPHER);
            //aes.init(Cipher.ENCRYPT_MODE, this);
            //t = aes.doFinal(t);
            //userMdl.setCfg(ConsCfg.CFG_USER_SKEY, sKey + Util.bytesToString(t, true));

            //this.keys = temp;
            //this.pwds = null;

            return true;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public bool CaSignUp(string root, string name, string pass)
        {
            string code = "A0000000";
            byte[] k = GenK(name, code, pass);
            byte[] v = GenV(name, code, pass);

            Random r = new Random();
            _Salt = new byte[16];
            r.NextBytes(_Salt);
            _Keys = new byte[32];
            r.NextBytes(_Keys);
            _Mask = GenChar();

            byte[] t = new byte[72];
            byte[] a = Encoding.UTF8.GetBytes(code);
            int i = 0;
            Array.Copy(a, 0, t, i, a.Length);
            i += a.Length;
            Array.Copy(_Salt, 0, t, i, _Salt.Length);
            i += _Salt.Length;
            Array.Copy(_Keys, 0, t, i, _Keys.Length);
            i += _Keys.Length;
            a = Encoding.UTF8.GetBytes(_Mask);
            Array.Copy(a, 0, t, i, a.Length);

            #region AES 加密
            AesManaged aes = new AesManaged();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(k, v), CryptoStreamMode.Write))
                {
                    cStream.Write(t, 0, t.Length);
                    cStream.FlushFinalBlock();
                    t = mStream.ToArray();
                }
            }
            aes.Clear();
            #endregion
            string main = Convert.ToBase64String(t);

            _Data = new byte[256];
            r.NextBytes(_Data);
            string info = Digest(name, pass);

            CaSignNw(root, name, code, Convert.ToBase64String(_Data), info, main, "");

            _Name = name;
            _Code = code;
            _Info = pass;
            _Home = root + code + Path.DirectorySeparatorChar;
            return true;
        }

        public void CaSignOf()
        {
            _Info = null;
            _Keys = null;
            _Salt = null;
            _Mask = null;

            _Name = null;
            _Code = null;
            _Home = null;
        }
        #endregion

        private char[] GenChar()
        {
            char[] c = new char[93];
            char t = '!';
            int i = 0;
            while (i < 6)
            {
                c[i++] = t++;
            }
            t = '(';
            while (i < 93)
            {
                c[i++] = t++;
            }
            return CharUtil.NextRandomKey(c, 16, false);
        }

        #region 数据安全
        public string Digest(string name, string pass)
        {
            byte[] s = Encoding.UTF8.GetBytes(name + '%' + pass + "@Amon");
            byte[] t = new byte[_Data.Length + s.Length];
            new Random().NextBytes(t);
            Array.Copy(_Data, t, _Data.Length);
            Array.Copy(s, 0, t, _Data.Length, s.Length);

            return Convert.ToBase64String(Digest(t));
        }

        public byte[] Digest(byte[] data)
        {
            return HashAlgorithm.Create("SHA256").ComputeHash(data);
        }

        private byte[] GenK(string name, string code, string pass)
        {
            return Digest(Encoding.UTF8.GetBytes(name + '@' + code + "&Amon.Me/" + pass));
        }

        private byte[] GenV(string name, string code, string pass)
        {
            return Encoding.UTF8.GetBytes(code + "@Amon.Me");
        }

        private bool Decrypt(string name, string code, string pass, string data)
        {
            #region 口令散列
            // 口令
            byte[] k = GenK(name, code, pass);
            // 向量
            byte[] v = GenV(name, code, pass);
            // 数据
            byte[] t = Convert.FromBase64String(data);
            pass = null;
            #endregion

            #region AES 解密
            AesManaged aes = new AesManaged();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(k, v), CryptoStreamMode.Write))
                {
                    cStream.Write(t, 0, t.Length);
                    cStream.FlushFinalBlock();
                    t = mStream.ToArray();
                }
            }
            aes.Clear();
            #endregion

            if (t.Length != 72)
            {
                return false;
            }

            _Code = Encoding.UTF8.GetString(t, 0, 8);
            int i = 8;
            _Salt = new byte[16];
            Array.Copy(t, i, _Salt, 0, _Salt.Length);
            i += _Salt.Length;
            _Keys = new byte[32];
            Array.Copy(t, i, _Keys, 0, _Keys.Length);
            i += _Keys.Length;
            _Mask = Encoding.UTF8.GetChars(t, i, 16);
            return true;
        }

        public string DecodeKey(string data)
        {
            AesManaged aes = new AesManaged();

            byte[] buf = CharUtil.DecodeString(data, _Mask);
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(_Keys, _Salt), CryptoStreamMode.Write))
                {
                    cStream.Write(buf, 0, buf.Length);
                    cStream.FlushFinalBlock();
                    buf = mStream.ToArray();
                }
            }
            aes.Clear();

            return Encoding.UTF8.GetString(buf, 0, buf.Length);
        }

        public string EncodeKey(string data)
        {
            AesManaged aes = new AesManaged();

            byte[] buf = Encoding.UTF8.GetBytes(data);
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(_Keys, _Salt), CryptoStreamMode.Write))
                {
                    cStream.Write(buf, 0, buf.Length);
                    cStream.FlushFinalBlock();
                    buf = mStream.ToArray();
                }
            }
            aes.Clear();

            return CharUtil.EncodeString(buf, _Mask);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Post(string data)
        {
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            //client.UploadStringAsync(new Uri(EnvConst.SERVER_PATH), "POST", "c=" + Code + "&t=" + _Token + data);
        }

        private DBAccess _DBAccess;
        private DCAccess _DCAccess;
        private DFAccess _DFAccess;

        public void Init()
        {
            _DBAccess = new DBAccess();
            _DBAccess.Init(this);
            _DCAccess = new DCAccess();
            _DCAccess.Init(this);
            _DFAccess = new DFAccess();
            _DFAccess.Init(this);
        }

        public DBAccess DBAccess { get { return _DBAccess; } }
        public DCAccess DCAccess { get { return _DCAccess; } }
        public DFAccess DFAccess { get { return _DFAccess; } }
    }
}
