﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.User.Sign
{
    /// <summary>
    /// 单机注册
    /// </summary>
    public partial class SignPc : UserControl, ISignAc
    {
        private string _Name;
        private string _Pass;
        private string _Root;
        private UserModel _UserModel;
        private Uc.Properties _Prop;
        private SignAc _SignAc;

        public SignPc()
        {
            InitializeComponent();
        }

        public SignPc(SignAc signAc, UserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();

            TbPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

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
                _SignAc.ShowAlert("请输入用户名！");
                TbName.Focus();
                return;
            }

            if (_Name.Length < 5)
            {
                _SignAc.ShowAlert("用户名不能少于5个字符！");
                TbName.Focus();
                return;
            }

            if (!Regex.IsMatch(_Name, "^\\w{5,}$"))
            {
                _SignAc.ShowAlert("用户名中含有非法字符！");
                TbName.Focus();
                return;
            }

            _Name = _Name.ToLower();
            _Prop = new Uc.Properties();
            _Prop.Load(IEnv.AMON_SYS);
            string home = _Prop.Get(string.Format(IEnv.AMON_SYS_HOME, _Name));
            if (!string.IsNullOrEmpty(home))
            {
                _SignAc.ShowAlert(string.Format("已存在名为 {0} 的用户，请尝试其它用户名！", _Name));
                return;
            }
            #endregion

            #region 口令判断
            _Pass = TbPass1.Text;
            TbPass1.Text = "";
            if (string.IsNullOrEmpty(_Pass))
            {
                _SignAc.ShowAlert("请输入登录口令！");
                TbPass1.Focus();
                return;
            }

            if (_Pass.Length < 4)
            {
                _SignAc.ShowAlert("登录口令不能少于4个字符！");
                TbPass1.Text = "";
                TbPass2.Text = "";
                TbPass1.Focus();
                return;
            }

            if (_Pass != TbPass2.Text)
            {
                TbPass2.Text = "";
                _SignAc.ShowAlert("您两次输入的口令不一致！");
                TbPass1.Focus();
                return;
            }
            TbPass2.Text = "";
            #endregion

            #region 路径判断
            _Root = TbPath.Text;
            if (string.IsNullOrEmpty(_Root))
            {
                _SignAc.ShowAlert("请选择您的数据存放目录！");
                BtPath.Focus();
                return;
            }
            if (_Root[_Root.Length - 1] != Path.DirectorySeparatorChar)
            {
                _Root += Path.DirectorySeparatorChar;
            }
            #endregion

            _SignAc.ShowWaiting();

            try
            {
                // 本地注册
                if (!_UserModel.CaSignUp(_Root, _Name, _Pass))
                {
                    _Pass = null;
                    _SignAc.HideWaiting();
                    _SignAc.ShowAlert("系统异常，请稍后重试！");
                    return;
                }

                _Prop.Set(string.Format(IEnv.AMON_SYS_CODE, _Name), _UserModel.Code);
                _Prop.Set(string.Format(IEnv.AMON_SYS_HOME, _Name), _UserModel.Home);
                _Prop.Save(IEnv.AMON_SYS);

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
            if (path[path.Length - 1] != Path.DirectorySeparatorChar)
            {
                path += Path.DirectorySeparatorChar;
            }
            TbPath.Text = path;
        }
        #endregion

        private void InitDat()
        {
            _UserModel.Init();
            BeanUtil.UnZip("Amon.dat", _UserModel.Home);

            var tmp = '\'' + _UserModel.Code + '\'';
            var dba = _UserModel.DBAccess;

            string file = _UserModel.Home + "dat.sql";
            StreamReader reader = File.OpenText(file);
            string line = reader.ReadLine();
            while (line != null)
            {
                dba.AddBatch(line.Replace("'A0000000'", tmp));
                line = reader.ReadLine();
            }
            reader.Close();
            File.Delete(file);

            dba.ExecuteBatch();

            _SignAc.CallBack(IEnv.IAPP_APWD);
        }
    }
}