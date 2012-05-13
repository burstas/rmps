﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Pwd;
using Me.Amon.Util;

namespace Me.Amon.User.Sign
{
    public partial class SignIn : UserControl, ISignAc
    {
        private string _Name;
        private string _Pass;
        //private string _Info;
        private string _Home;
        private UserModel _UserModel;
        private DFAccess _Prop;
        private SignAc _SignAc;

        #region 构造函数
        public SignIn()
        {
            InitializeComponent();
        }

        public SignIn(SignAc signAc, UserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public void DoSignAc()
        {
            #region 用户判断
            _Name = TbName.Text;
            if (string.IsNullOrEmpty(_Name))
            {
                _SignAc.ShowAlert("请输入【登录用户】！");
                TbName.Focus();
                return;
            }
            if (!CharUtil.IsValidateName(_Name))
            {
                _SignAc.ShowAlert("【登录用户】应在 4 到 32 个字符之间，且仅能为大小写字母、下划线及英文点号！");
                TbName.Focus();
                return;
            }
            #endregion

            #region 口令判断
            _Pass = TbPass.Text;
            TbPass.Text = "";
            if (string.IsNullOrEmpty(_Pass))
            {
                _SignAc.ShowAlert("请输入【登录口令】！");
                TbPass.Focus();
                return;
            }

            if (_Pass.Length < 4)
            {
                _SignAc.ShowAlert("【登录口令】不能少于 4 个字符！");
                TbPass.Focus();
                return;
            }
            #endregion

            _SignAc.ShowWaiting();

            _Prop = new DFAccess();
            _Prop.Load(IEnv.AMON_SYS);

            _Name = _Name.ToLower();
            string code = _Prop.Get(string.Format(IEnv.AMON_SYS_CODE, _Name));
            _Home = _Prop.Get(string.Format(IEnv.AMON_SYS_HOME, _Name));

            #region 已有用户首次登录
            if (!CharUtil.IsValidateCode(code))
            {
                _Home = IEnv.DIR_DATA;

                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.Headers["Content-type"] = "application/x-www-form-urlencoded";
                client.Encoding = Encoding.UTF8;
                client.UploadStringCompleted += new UploadStringCompletedEventHandler(SignIn_UploadStringCompleted);
                client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=sin&d=" + _Name);
                return;
            }
            #endregion

            #region 已有用户正常登录
            if (!_UserModel.CaSignIn(_Home, code, _Name, _Pass))
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert("身份验证错误，请确认您的用户及口令输入是否正确！");
                TbPass.Focus();
                return;
            }

            _UserModel.Init();
            _SignAc.CallBack(0);
            #endregion
        }

        public void DoCancel()
        {
            _SignAc.Close();
        }

        public void ShowMenu(Control control, int x, int y)
        {
        }
        #endregion

        #region 私有函数
        private void SignIn_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;

            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                string code = null;
                if (reader.Name == "Code" || reader.ReadToFollowing("Code"))
                {
                    code = reader.ReadElementContentAsString();
                }
                if (!CharUtil.IsValidateCode(code))
                {
                    _SignAc.HideWaiting();
                    _SignAc.ShowAlert("注册用户失败，请稍后重试！");
                    return;
                }
                _Home = Path.Combine(_Home, code);
                if (!Directory.Exists(_Home))
                {
                    Directory.CreateDirectory(_Home);
                }

                if (!_UserModel.WsSignIn(_Home, code, _Name, _Pass, reader))
                {
                    _SignAc.HideWaiting();
                    _SignAc.ShowAlert("请确认您输入的登录用户及登录口令是否正确！");
                    TbName.Focus();
                }
                else
                {
                    DFAccess prop = new DFAccess();
                    prop.Load(IEnv.AMON_SYS);
                    prop.Set(string.Format(IEnv.AMON_SYS_HOME, _Name), _UserModel.Home);
                    prop.Set(string.Format(IEnv.AMON_SYS_CODE, _Name), _UserModel.Code);
                    prop.Save(IEnv.AMON_SYS);

                    InitDat();
                }
            }

            _Pass = null;
        }

        private void InitDat()
        {
            _UserModel.Init();

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitCat_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=cat&c=" + _UserModel.Code);
        }

        private void InitCat_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                Cat cat;
                while (reader.ReadToFollowing("Cat"))
                {
                    cat = new Cat();
                    if (!cat.FromXml(reader))
                    {
                        continue;
                    }
                    _UserModel.DBA.SaveVcs(cat);
                }
            }

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitLib_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=lib&c=" + _UserModel.Code);
        }

        private void InitLib_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                Lib header;
                while (reader.ReadToFollowing("Lib"))
                {
                    header = new Lib();
                    if (!header.FromXml(reader))
                    {
                        continue;
                    }
                    _UserModel.DBA.SaveVcs(header);
                }
            }

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitUdc_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=udc&c=" + _UserModel.Code);
        }

        private void InitUdc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                Udc udc;
                while (reader.ReadToFollowing("Udc"))
                {
                    udc = new Udc();
                    if (!udc.FromXml(reader))
                    {
                        continue;
                    }
                    _UserModel.DBA.SaveVcs(udc);
                }
            }

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.Encoding = Encoding.UTF8;
            client.UploadStringCompleted += new UploadStringCompletedEventHandler(InitKey_UploadStringCompleted);
            client.UploadStringAsync(new Uri(IEnv.SERVER_PATH), "POST", "&o=key&c=" + _UserModel.Code);
        }

        private void InitKey_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(e.Error.Message);
                return;
            }

            string xml = e.Result;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                if (xml.IndexOf("<Error>") > 0)
                {
                    _SignAc.HideWaiting();
                    reader.ReadToFollowing("Error");
                    _SignAc.ShowAlert(reader.ReadElementContentAsString());
                    return;
                }

                Key key;
                while (reader.ReadToFollowing("Key"))
                {
                    key = new Key();
                    if (!key.FromXml(reader))
                    {
                        continue;
                    }
                    _UserModel.DBA.SaveVcs(key);
                }
            }

            BeanUtil.UnZip("Amon.dat", _UserModel.Home);
            _SignAc.CallBack(IEnv.IAPP_APWD);
        }
        #endregion
    }
}