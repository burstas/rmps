﻿using System.IO;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanLogo : UserControl, IAttEdit
    {
        private APro _APro;
        private LogoAtt _Att;
        private Png _APng;
        private DataModel _DataModel;

        #region 构造函数
        public BeanLogo()
        {
            InitializeComponent();
        }

        public BeanLogo(APro apro)
        {
            _APro = apro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;
            _APng = new Png();

            _APro.ShowTips(PbLogo, "点击选择徽标");
        }

        public Control Control { get { return this; } }

        public string Title { get { return "徽标"; } }

        public bool ShowData(Att att)
        {
            _Att = att as LogoAtt;

            if (_Att != null)
            {
                string temp = _Att.GetSpec(LogoAtt.SPEC_LOGO_DIR);
                _APng.File = _Att.Text;
                _APng.Path = temp;

                TbData.Text = _Att.Data;

                if (!CharUtil.IsValidateHash(_Att.Text))
                {
                    PbLogo.Image = BeanUtil.NaN16;
                }
                else
                {
                    string path = _DataModel.KeyDir;
                    if (CharUtil.IsValidateHash(temp))
                    {
                        path = Path.Combine(path, temp, _Att.Text + CApp.IMG_KEY_EDIT_EXT);
                    }
                    else
                    {
                        path = Path.Combine(path, _Att.Text + CApp.IMG_KEY_EDIT_EXT);
                    }
                    PbLogo.Image = BeanUtil.ReadImage(path, BeanUtil.NaN16);
                }
            }

            return true;
        }

        public new bool Focus()
        {
            return TbData.Focus();
        }

        public void Cut()
        {
            TbData.Cut();
        }

        public void Copy()
        {
            if (!string.IsNullOrEmpty(TbData.SelectedText))
            {
                TbData.Copy();
                return;
            }
            if (!string.IsNullOrEmpty(TbData.Text))
            {
                Clipboard.SetText(TbData.Text);
            }
        }

        public void Paste()
        {
            TbData.Paste();
        }

        public void Clear()
        {
            TbData.Clear();
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (_Att.Text != _APng.File)
            {
                _Att.Text = _APng.File;
                _Att.SetSpec(LogoAtt.SPEC_LOGO_DIR, _APng.Path);
                _Att.Modified = true;
            }

            if (TbData.Text != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }

            return true;
        }
        #endregion

        #region 事件处理
        private void PbName_Click(object sender, System.EventArgs e)
        {
            _APro.ShowIcoSeeker(new AmonHandler<Png>(ChangeImgByKey));
        }
        #endregion

        private void ChangeImgByKey(Png png)
        {
            _APng = png;
            string path;
            if (CharUtil.IsValidateHash(png.Path))
            {
                path = Path.Combine(_DataModel.KeyDir, png.Path, png.File + CApp.IMG_KEY_EDIT_EXT);
            }
            else
            {
                path = Path.Combine(_DataModel.KeyDir, png.File + CApp.IMG_KEY_EDIT_EXT);
            }
            PbLogo.Image = BeanUtil.ReadImage(path, BeanUtil.NaN16);
        }
    }
}
