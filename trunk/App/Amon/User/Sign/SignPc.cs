﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Pwd;
using Me.Amon.Ren;
using Me.Amon.Util;

namespace Me.Amon.User.Sign
{
    /// <summary>
    /// 单机注册
    /// </summary>
    public partial class SignPc : UserControl, ISignAc
    {
        private UserModel _UserModel;
        private DFAccess _Prop;
        private SignAc _SignAc;

        #region 构造函数
        public SignPc()
        {
            InitializeComponent();
        }

        public SignPc(SignAc signAc, UserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();

            TbPath.Text = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), EApp.DIR_DATA);
            _SignAc.ShowTips(BtPath, "选择目录");
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
            string name = TbName.Text;
            if (string.IsNullOrEmpty(name))
            {
                _SignAc.ShowAlert("请输入用户名！");
                TbName.Focus();
                return;
            }

            if (name.Length < 5)
            {
                _SignAc.ShowAlert("用户名不能少于5个字符！");
                TbName.Focus();
                return;
            }

            if (!Regex.IsMatch(name, "^\\w{5,}$"))
            {
                _SignAc.ShowAlert("用户名中含有非法字符！");
                TbName.Focus();
                return;
            }

            name = name.ToLower();
            _Prop = new DFAccess();
            _Prop.Load(EApp.AMON_SYS);
            string home = _Prop.Get(string.Format(EApp.AMON_SYS_HOME, name));
            if (!string.IsNullOrEmpty(home))
            {
                _SignAc.ShowAlert(string.Format("已存在名为 {0} 的用户，请尝试其它用户名！", name));
                return;
            }
            #endregion

            #region 口令判断
            string pass = TbPass1.Text;
            TbPass1.Text = "";
            if (string.IsNullOrEmpty(pass))
            {
                _SignAc.ShowAlert("请输入登录口令！");
                TbPass1.Focus();
                return;
            }

            if (pass.Length < 4)
            {
                _SignAc.ShowAlert("登录口令不能少于4个字符！");
                TbPass1.Text = "";
                TbPass2.Text = "";
                TbPass1.Focus();
                return;
            }

            if (pass != TbPass2.Text)
            {
                TbPass2.Text = "";
                _SignAc.ShowAlert("您两次输入的口令不一致！");
                TbPass1.Focus();
                return;
            }
            TbPass2.Text = "";
            #endregion

            #region 路径判断
            home = TbPath.Text;
            if (string.IsNullOrEmpty(home))
            {
                _SignAc.ShowAlert("请选择您的数据存放目录！");
                BtPath.Focus();
                return;
            }
            #endregion

            #region 代码
            string code = EApp.USER_AMON;
            if (Directory.Exists(Path.Combine(home, code)))
            {
                _SignAc.ShowAlert(string.Format("指定路径下已存在名为 {0} 的目录！", code));
                return;
            }
            #endregion

            _SignAc.ShowWaiting();

            try
            {
                // 本地注册
                if (!_UserModel.CaSignUp(home, code, name, pass))
                {
                    pass = null;
                    _SignAc.HideWaiting();
                    _SignAc.ShowAlert("系统异常，请稍后重试！");
                    return;
                }

                _Prop.Set(string.Format(EApp.AMON_SYS_CODE, name), _UserModel.Code);
                _Prop.Set(string.Format(EApp.AMON_SYS_HOME, name), _UserModel.Home);
                _Prop.Save(EApp.AMON_SYS);

                InitDat();
            }
            catch (Exception exp)
            {
                _SignAc.HideWaiting();
                _SignAc.ShowAlert(exp.Message);
                return;
            }
        }

        public void DoCancel()
        {
            _SignAc.ShowView(ESignAc.SignIn);
        }

        public void ShowMenu(Control control, int x, int y)
        {
        }
        #endregion

        #region 事件处理
        private void BtPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "请选择您要存放数据的目录：";
            fd.SelectedPath = TbPath.Text;
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }
            string path = fd.SelectedPath;
            if (string.IsNullOrEmpty(path))
            {
                _SignAc.ShowAlert("请选择数据存放目录！");
                BtPath.Focus();
                return;
            }
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception exp)
                {
                    _SignAc.ShowAlert(exp.Message);
                    BtPath.Focus();
                    return;
                }
            }
            TbPath.Text = path;
        }
        #endregion

        #region 私有函数
        private void InitDat()
        {
            _UserModel.Init();
            BeanUtil.UnZip("Amon.dat", _UserModel.Home);

            string file;
            StreamReader stream;

            #region 类别
            file = Path.Combine(_UserModel.Home, "Cat.xml");
            if (File.Exists(file))
            {
                stream = new StreamReader(file);
                using (XmlReader reader = XmlReader.Create(stream))
                {
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
                stream.Close();
                File.Delete(file);
            }
            #endregion

            #region 模板
            file = Path.Combine(_UserModel.Home, "Lib.xml");
            if (File.Exists(file))
            {
                stream = new StreamReader(file);
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    Lib header;
                    while (reader.Name == "Lib" || reader.ReadToFollowing("Lib"))
                    {
                        header = new Lib();
                        if (!header.FromXml(reader))
                        {
                            continue;
                        }
                        _UserModel.DBA.SaveVcs(header);
                    }
                }
                stream.Close();
                File.Delete(file);
            }
            #endregion

            #region 字符
            file = Path.Combine(_UserModel.Home, "Udc.xml");
            if (File.Exists(file))
            {
                stream = new StreamReader(file);
                using (XmlReader reader = XmlReader.Create(stream))
                {
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
                stream.Close();
                File.Delete(file);
            }
            #endregion

            #region 重命名
            file = Path.Combine(_UserModel.Home, "Ren.xml");
            if (File.Exists(file))
            {
                stream = new StreamReader(file);
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    MRen ren;
                    while (reader.ReadToFollowing("Ren"))
                    {
                        ren = new MRen();
                        if (!ren.FromXml(reader))
                        {
                            continue;
                        }
                        _UserModel.DBA.SaveVcs(ren);
                    }
                }
                stream.Close();
                File.Delete(file);
            }
            #endregion
            _SignAc.CallBack(EApp.IAPP_APWD);
        }
        #endregion
    }
}
