using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using me.amon.db;
using me.amon.util;

public partial class cipher_Index : System.Web.UI.Page
{
    #region 全局常量
    private int imgSize = 16;
    private const string CAT_DIGEST = "digest";
    private const string CAT_CONFUSE = "confuse";
    private const string CAT_PRIVATE = "private";
    private const string CAT_PUBLIC = "public";
    private const string CAT_DIGITAL = "digital";
    #endregion

    #region 页面加载
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        IbMd.ImageUrl = "~/_img/safe/switch" + imgSize + ".png";
        IbMd.Width = imgSize;
        IbMd.Height = imgSize;

        ImKd.Src = "~/_img/safe/wizard" + imgSize + ".png";
        ImKd.Width = imgSize;
        ImKd.Height = imgSize;

        IbMd.Attributes["Checked"] = "False";
        CbMf.Visible = false;
        CbMl.Visible = false;

        CbMc.Items.Add(new ListItem("请选择", "0"));
        CbMc.Items.Add(new ListItem("消息摘要", CAT_DIGEST));
        CbMc.Items.Add(new ListItem("数据混淆", CAT_CONFUSE));
        CbMc.Items.Add(new ListItem("私钥加密", CAT_PRIVATE));
        CbMc.Items.Add(new ListItem("公钥加密", CAT_PUBLIC));
        CbMc.Items.Add(new ListItem("数字签名", CAT_DIGITAL));

        Match match = Regex.Match(Request.RawUrl, "/index\\.aspx\\?c\\w+$");
        if (match.Success)
        {
            LoadData(match.Value.Substring("/index.aspx?c".Length));
        }
        else
        {
            BtOp.Text = "生成(G)";
            BtOp.AccessKey = "G";
            Session["charKey"] = "";
        }

        TaSt.Focus();
    }

    private void LoadData(string code)
    {
        DBAccess dba = new DBAccess();
        dba.addTable("cipher_text");
        dba.addWhere("code", code);
        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count != 1)
        {
            return;
        }
        DataRow dr = dt.Rows[0];

        Session["category"] = dr["cat"];
        Session["function"] = dr["fun"];
        Session["keySize"] = dr["keysize"];
        Session["charKey"] = dr["charset"];
        Session["salt"] = Hex2Bytes("" + dr["salt"]);
        Session["iv"] = Hex2Bytes("" + dr["iv"]);
        TaSt.Text = "" + dr["text"];

        HdMd.Value = "1";
        BtOp.Text = "返回(H)";
        BtOp.AccessKey = "H";
        TaSt.ReadOnly = true;
        DvMo.Visible = false;
    }
    #endregion

    #region 内部方法
    /// <summary>
    /// 密文文本到字节转换
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private byte[] DecodeBytes(string source)
    {
        string charKey = Session["charKey"] as string;
        if (string.IsNullOrEmpty(charKey) || "0" == charKey || !Regex.IsMatch(charKey, "^[\\dA-F]{16}$"))
        {
            return Hex2Bytes(source);
        }

        char[] array = source.ToCharArray();
        return DecodeBytes(array, 0, array.Length, 0, null);
    }

    /// <summary>
    /// 密文字节到文本转换
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private string EncodeBytes(byte[] array)
    {
        return EncodeBytes(array, 0, array.Length);
    }

    /// <summary>
    /// 密文字节到文本转换
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private string EncodeBytes(byte[] array, int index, int count)
    {
        string charKey = Session["charKey"] as string;
        if (string.IsNullOrEmpty(charKey) || "0" == charKey || !Regex.IsMatch(charKey, "^[\\dA-F]{16}$"))
        {
            return Bytes2Hex(array);
        }
        return EncodeBytes(array, index, count, 0, null);
    }

    #region 掩码处理
    private const int MAX_BITS = 8;
    /// <summary>
    /// 按指定位制及掩码对数组进行加密
    /// </summary>
    /// <param name="array">待处理的字节数组</param>
    /// <param name="index">起始索引</param>
    /// <param name="count">处理长度</param>
    /// <param name="ratio">输出位制</param>
    /// <param name="model">输出掩码</param>
    /// <returns></returns>
    private static string EncodeBytes(byte[] array, int index, int count, int ratio, char[] model)
    {
        StringBuilder buf = new StringBuilder();

        #region 正常处理
        int i = 0;//中间变量：当前整数
        int c = 0;//中间变量：当前整数中有效位数
        int m = (1 << ratio) - 1;//中间变量：位操作掩码
        int n = index + count;// 结束索引
        int t;
        for (int j = index; j < n; j += 1)
        {
            i = (i << MAX_BITS) | (array[j] & 0xFF);
            c += MAX_BITS;

            while (c >= ratio)
            {
                c -= ratio;
                t = (i >> c) & m;
                buf.Append(model[t]);
            }
            i &= ((1 << c) - 1);
        }
        #endregion

        #region 特殊处理
        if (c > 0)
        {
            buf.Append(model[i & m]);
        }
        #endregion

        return buf.ToString();
    }

    /// <summary>
    /// 按指定位制及掩码对数组进行解密
    /// </summary>
    /// <param name="array"></param>
    /// <param name="index">起始索引</param>
    /// <param name="count">处理长度</param>
    /// <param name="ratio"></param>
    /// <param name="model"></param>
    private static byte[] DecodeBytes(char[] array, int index, int count, int ratio, char[] model)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int j = 0; j < model.Length; j += 1)
        {
            dict[model[j]] = j;
        }

        #region 末位是否需要特殊处理
        int m = 1;
        // 判断是否为2的次幂
        bool s = (ratio == m);
        int i = 0;
        while (i++ < 3 && !s)
        {
            m <<= 1;
            s = (ratio == m);
        }
        #endregion

        #region 正常处理
        List<byte> buf = new List<byte>();
        i = 0;
        int c = 0;
        m = (1 << ratio) - 1;//中间变量：位操作掩码
        int n = index + (s ? count : count - 1);
        int t;
        for (int j = index; j < n; j += 1)
        {
            i = (i << ratio) | dict[array[j]];
            c += ratio;
            if (c >= MAX_BITS)
            {
                c -= MAX_BITS;
                t = (i >> c) & 0xFF;
                buf.Add((byte)t);
                i &= ((1 << c) - 1);
            }
        }
        #endregion

        #region 特殊处理
        if (!s)
        {
            t = ((i << (MAX_BITS - c)) | dict[array[n]]) & 0xFF;
            buf.Add((byte)t);
        }
        #endregion

        return buf.ToArray();
    }
    #endregion

    #region 16进制
    /// <summary>
    /// 16进制字符串转换为数组
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private byte[] Hex2Bytes(string source)
    {
        int t = 0;
        bool f = false;
        MemoryStream stream = new MemoryStream(source.Length);
        foreach (char b in source.ToUpper().ToCharArray())
        {
            if (b >= '0' && b <= '9')
            {
                if (f)
                {
                    t |= (b - '0');
                    stream.WriteByte((byte)t);
                    t = 0;
                    f = false;
                    continue;
                }

                t = (b - '0') << 4;
                f = true;
                continue;
            }

            if (b >= 'A' && b <= 'F')
            {
                if (f)
                {
                    t |= (b - 'A' + 10);
                    stream.WriteByte((byte)t);
                    t = 0;
                    f = false;
                    continue;
                }

                t = (b - 'A' + 10) << 4;
                f = true;
                continue;
            }
        }
        byte[] a = stream.ToArray();
        stream.Close();
        return a;
    }

    /// <summary>
    /// 数组转换为16进制字符串
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private string Bytes2Hex(byte[] array)
    {
        return Bytes2Hex(array, 0, array.Length);
    }

    private string Bytes2Hex(byte[] array, int index, int count)
    {
        count += index;
        StringBuilder buf = new StringBuilder();
        while (index < count)
        {
            buf.Append(Convert.ToString(array[index++], 16).ToUpper().PadLeft(2, '0'));
        }
        return buf.ToString();
    }
    #endregion

    #region 编码处理
    /// <summary>
    /// 明文文本到字节转换
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private byte[] String2Bytes(string source)
    {
        return Encoding.UTF8.GetBytes(source);
    }

    /// <summary>
    /// 明文字节到字符转换
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private string Bytes2String(byte[] array)
    {
        return Bytes2String(array, 0, array.Length);
    }

    /// <summary>
    /// 明文字节到字符转换
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private string Bytes2String(byte[] array, int index, int count)
    {
        return Encoding.UTF8.GetString(array, index, count);
    }
    #endregion

    /// <summary>
    /// 切换输入输出文本
    /// </summary>
    private void ChangeSource()
    {
        string md = (IbMd.Attributes["Checked"] ?? "False").ToLower();
        IbMd.Attributes["Checked"] = ("true" == md ? "False" : "True");
    }

    /// <summary>
    /// 切换加密解密方向
    /// </summary>
    private void ChangeAction()
    {
        string md = (HdMd.Value ?? "0").Trim();
        HdMd.Value = ("0" == md ? "1" : "0");
    }

    private bool Encrypt
    {
        get
        {
            return "1" != (HdMd.Value ?? "0").Trim();
        }
    }
    #endregion

    #region 消息摘要
    /// <summary>
    /// 摘要
    /// </summary>
    /// <param name="algName">算法名称</param>
    public void DigestCipher(string algName)
    {
        HashAlgorithm algorithm = HashAlgorithm.Create(algName);
        byte[] byteOut = algorithm.ComputeHash(String2Bytes(TaSt.Text));
        TaDt.Text = EncodeBytes(byteOut);
    }
    #endregion

    #region 私钥加密
    private byte[] CreateSalt(int length)
    {
        // Create a buffer
        byte[] randBytes;

        if (length < 1)
        {
            length = 1;
        }
        randBytes = new byte[length];

        // Fill the buffer with random bytes.
        new RNGCryptoServiceProvider().GetBytes(randBytes);

        // return the bytes.
        return randBytes;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="algName">算法名称</param>
    private void PrivateCipher(string algName, bool encrypt)
    {
        if (encrypt)
        {
            TaDt.Text = PrivateEncrypt(algName, TaSt.Text, TbUp.Text);
        }
        else
        {
            TaDt.Text = PrivateDecrypt(algName, TaSt.Text, TbUp.Text);
        }
    }

    /// <summary>   
    /// 加密
    /// </summary>   
    /// <param name="Source">待加密的串</param>   
    /// <returns>经过加密的串</returns>   
    private string PrivateEncrypt(string algName, string Source, string password)
    {
        SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create(algName);
        byte[] salt = CreateSalt(8);
        byte[] iv1 = algorithm.IV;
        byte[] iv2 = new byte[iv1.Length];
        Array.Copy(iv1, iv2, iv1.Length);
        PasswordDeriveBytes derive = new PasswordDeriveBytes(password, salt);
        algorithm.Key = derive.CryptDeriveKey(algName, "SHA1", algorithm.KeySize, iv2);

        byte[] byteIn = String2Bytes(Source);
        byte[] byteOut;

        //algorithm.Key = GetLegalKey(algorithm);
        //algorithm.IV = GetLegalIV(algorithm);
        using (ICryptoTransform Encryptor = algorithm.CreateEncryptor())
        {
            using (MemoryStream MemStream = new MemoryStream())
            {
                using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                {
                    CryptoStream.Write(byteIn, 0, byteIn.Length);
                    CryptoStream.FlushFinalBlock();
                    byteOut = MemStream.ToArray();
                    CryptoStream.Close();
                    MemStream.Close();
                }
            }
        }

        Session["salt"] = salt;
        Session["iv"] = iv1;

        string text = EncodeBytes(byteOut);
        SaveCipher(CAT_PRIVATE, algName, algorithm.KeySize, "", salt, iv1, text);
        return text;
    }
    /// <summary>   
    /// 解密
    /// </summary>   
    /// <param name="Source">待解密的串</param>   
    /// <returns>经过解密的串</returns>   
    private string PrivateDecrypt(string algName, string source, string password)
    {
        SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create(algName);
        byte[] salt = Session["salt"] as byte[];
        byte[] iv1 = Session["iv"] as byte[];
        byte[] iv2 = new byte[iv1.Length];
        Array.Copy(iv1, iv2, iv1.Length);
        PasswordDeriveBytes derive = new PasswordDeriveBytes(password, salt);
        algorithm.Key = derive.CryptDeriveKey(algName, "SHA1", algorithm.KeySize, iv2);
        algorithm.IV = iv1;

        byte[] byteIn = DecodeBytes(source);
        byte[] byteOut = new byte[byteIn.Length];
        int byteCnt;

        //algorithm.Key = GetLegalKey(algorithm);
        //algorithm.IV = GetLegalIV(algorithm);
        using (ICryptoTransform Decryptor = algorithm.CreateDecryptor())
        {
            using (MemoryStream MemStream = new MemoryStream(byteIn))
            {
                using (CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
                {
                    byteCnt = CryptoStream.Read(byteOut, 0, byteOut.Length);
                    CryptoStream.Close();
                    MemStream.Close();
                }
            }
        }
        return Bytes2String(byteOut, 0, byteCnt);
    }
    #endregion

    #region 公钥加密
    private void PublicCipher(string fun, bool encrypt)
    {
        if (encrypt)
        {
            PublicEncrypt(TaSt.Text);
        }
        else
        {
            PublicDecrypt(TaSt.Text);
        }
    }

    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private void PublicEncrypt(string source)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(TbUp.Text);

        byte[] srcBytes = String2Bytes(source);
        byte[] dstBytes = rsa.Encrypt(srcBytes, false);

        TaDt.Text = EncodeBytes(dstBytes);
    }

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private void PublicDecrypt(string source)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(TbUp.Text);

        byte[] srcBytes = DecodeBytes(source);
        byte[] dstBytes = rsa.Decrypt(srcBytes, false);
        TaDt.Text = Bytes2String(dstBytes);
    }
    #endregion

    #region 数字签名
    private void DigitalCipher(string algName, bool encrypt)
    {
        algName = algName.ToUpper();
        if (encrypt)
        {
            if ("RSA" == algName)
            {
                RSACreate();
                return;
            }
            if ("DSA" == algName)
            {
                DSACreate();
            }
        }
        else
        {
            if ("RSA" == algName)
            {
                RSAVerify();
                return;
            }
            if ("DSA" == algName)
            {
                DSAVerify();
            }
        }
    }

    /// <summary>
    /// DSA签名
    /// </summary>
    private void RSACreate()
    {
        byte[] bytes = String2Bytes(TaSt.Text);
        //选择签名体式格局，有RSA和DSA
        DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
        byte[] sign = dsa.SignData(bytes);
        //sign就是出来的签名效果。
    }
    /// <summary>
    /// 解密
    /// </summary>
    private void RSAVerify()
    {
        byte[] bytes = null;
        byte[] sign = null;
        DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
        dsa.FromXmlString(dsa.ToXmlString(false));
        bool ver = dsa.VerifyData(bytes, sign);
        if (ver)
        {
            Console.WriteLine("经由过程");
        }
        else
        {
            Console.WriteLine("不克不及经由过程");
        }
    }

    /// <summary>
    /// DSA签名
    /// </summary>
    private void DSACreate()
    {
        byte[] bytes = String2Bytes(TaSt.Text);
        //选择签名体式格局，有RSA和DSA
        DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
        byte[] sign = dsa.SignData(bytes);
        //sign就是出来的签名效果。
    }
    /// <summary>
    /// 解密
    /// </summary>
    private void DSAVerify()
    {
        byte[] bytes = null;
        byte[] sign = null;
        DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
        dsa.FromXmlString(dsa.ToXmlString(false));
        bool ver = dsa.VerifyData(bytes, sign);
        if (ver)
        {
            Console.WriteLine("经由过程");
        }
        else
        {
            Console.WriteLine("不克不及经由过程");
        }
    }
    #endregion

    #region 用户事件
    /// <summary>
    /// 执行加密运算
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtDo_Click(object sender, EventArgs e)
    {
        bool encrypt = Encrypt;

        string cat;
        string fun;
        if (encrypt)
        {
            // 加密方案
            ListItem catItem = CbMc.SelectedItem;
            if (catItem == null)
            {
                LbErr1.Text = "请选择一个加密方案！";
                CbMc.Focus();
                return;
            }
            cat = (catItem.Value ?? "").Trim().ToLower();
            if (string.IsNullOrEmpty(cat) || "0" == cat)
            {
                LbErr1.Text = "请选择一个加密方案！";
                CbMc.Focus();
                return;
            }

            // 加密算法
            ListItem funItem = CbMf.SelectedItem;
            if (funItem == null)
            {
                LbErr1.Text = "请选择一个加密算法！";
                CbMf.Focus();
                return;
            }
            fun = (funItem.Value ?? "").Trim().ToUpper();
            if (string.IsNullOrEmpty(fun) || "0" == fun)
            {
                LbErr1.Text = "请选择一个加密算法！";
                CbMf.Focus();
                return;
            }

            // 输入文本
            string source = TaSt.Text;
            if (string.IsNullOrEmpty(source))
            {
                LbErr1.Text = "请输入明文！";
                TaSt.Focus();
                return;
            }
        }
        else
        {
            cat = Session["category"] as string;
            fun = Session["function"] as string;
        }

        string password = TbUp.Text;
        if (string.IsNullOrEmpty(password))
        {
            LbErr1.Text = "请输入口令！";
            TbUp.Focus();
            return;
        }

        // 执行加密
        if (CAT_DIGEST == cat)
        {
            DigestCipher(fun);
            return;
        }
        if (CAT_PRIVATE == cat)
        {
            PrivateCipher(fun, encrypt);
            return;
        }
        if (CAT_PUBLIC == cat)
        {
            PublicCipher(fun, encrypt);
            return;
        }
        if (CAT_DIGITAL == cat)
        {
            return;
        }
    }

    protected void BtOp_Click(object sender, EventArgs e)
    {
        byte[] salt = Session["salt"] as byte[];
        if (salt == null)
        {
            return;
        }
    }

    private string SaveCipher(string category, string function, int keySize, string charSet, byte[] salt, byte[] iv, string text)
    {
        long time = DateTime.Now.Millisecond;
        string key = time.ToString();
        DBAccess dba = new DBAccess();
        dba.addTable("cipher_text");
        dba.addParam("id", CharUtil.encodeLong(time, false));//访问键值
        dba.addParam("code", key);//访问键值
        dba.addParam("cat", category);//加密算法
        dba.addParam("fun", function);//加密算法
        dba.addParam("keysize", keySize);//口令长度
        dba.addParam("charset", charSet);//字符集
        dba.addParam("salt", Bytes2Hex(salt));//salt
        dba.addParam("iv", Bytes2Hex(iv));//iv
        dba.addParam("text", text);//密文
        dba.addParam("create_time", "now()", false);//创建日间
        dba.executeInsert();
        return key;
    }

    /// <summary>
    /// 切换加密方案
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CbMc_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListItem item = CbMc.SelectedItem;
        if (item == null)
        {
            return;
        }

        CbMf.Items.Clear();
        if (item.Value == CAT_DIGEST)
        {
            CbMf.Items.Add(new ListItem("MD5", "MD5"));
            CbMf.Items.Add(new ListItem("SHA-1", "SHA1"));
            CbMf.Items.Add(new ListItem("SHA-256", "SHA256"));
            CbMf.Items.Add(new ListItem("SHA-384", "SHA384"));
            CbMf.Items.Add(new ListItem("SHA-512", "SHA512"));
            CbMf.Visible = true;
            CbMl.Visible = false;
            return;
        }
        if (item.Value == CAT_CONFUSE)
        {
            CbMf.Items.Add(new ListItem("1位掩码", "1"));
            CbMf.Items.Add(new ListItem("2位掩码", "2"));
            CbMf.Items.Add(new ListItem("3位掩码", "3"));
            CbMf.Items.Add(new ListItem("4位掩码", "4"));
            CbMf.Items.Add(new ListItem("5位掩码", "5"));
            CbMf.Items.Add(new ListItem("6位掩码", "6"));
            CbMf.Items.Add(new ListItem("7位掩码", "7"));
            CbMf.Items.Add(new ListItem("8位掩码", "8"));
            CbMf.Visible = true;
            CbMl.Visible = false;
            return;
        }
        if (item.Value == CAT_PRIVATE)
        {
            CbMf.Items.Add(new ListItem("DES", "DES"));
            CbMf.Items.Add(new ListItem("三重DES", "TripleDES"));
            CbMf.Items.Add(new ListItem("AES", "AES"));
            CbMf.Items.Add(new ListItem("Rijndael", "Rijndael"));
            CbMf.Visible = true;
            CbMl.Visible = false;
            return;
        }
        if (item.Value == CAT_PUBLIC)
        {
            CbMf.Items.Add(new ListItem("RSA", "RSA"));
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            KeySizes[] ks = rsa.LegalKeySizes;
            CbMf.Visible = true;
            CbMl.Visible = true;
            return;
        }
        if (item.Value == CAT_DIGITAL)
        {
            CbMf.Items.Add(new ListItem("RSA", "RSA"));
            CbMf.Items.Add(new ListItem("DSA", "DSA"));
            CbMf.Visible = true;
            CbMl.Visible = false;
            return;
        }

        CbMf.Visible = false;
        CbMl.Visible = false;
    }

    /// <summary>
    /// 切换输入输出内容
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void IbMd_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        string srcText = TaSt.Text;
        string dstText = TaDt.Text;
        TaSt.Text = dstText;
        TaDt.Text = srcText;

        ChangeSource();
        ChangeAction();
    }
    #endregion
}
