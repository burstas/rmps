﻿using System;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Pwd._Att;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz
{
    public partial class BeanHead : UserControl, IWizView
    {
        private AWiz _AWiz;
        private Pwd.Ico _AIco;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private TextBox _TBox;

        #region 构造函数
        public BeanHead()
        {
            InitializeComponent();
        }

        public BeanHead(AWiz awiz, SafeModel safeModel)
        {
            _AWiz = awiz;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;
            _AIco = new Pwd.Ico();

            TbName.GotFocus += new EventHandler(TbName_GotFocus);
            TbMeta.GotFocus += new EventHandler(TbMeta_GotFocus);
            TbHint.GotFocus += new EventHandler(TbHint_GotFocus);
            TbMemo.GotFocus += new EventHandler(TbMemo_GotFocus);
        }
        #endregion

        #region 接口实现
        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 0);
            Dock = DockStyle.Fill;
            TabIndex = 0;
            grid.RowStyles[1].Height = 32;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
        }

        public void ShowData()
        {
            MetaAtt meta = _SafeModel.Meta;
            if (meta == null)
            {
                return;
            }
            TbName.Text = meta.Text;
            TbMeta.Text = meta.Data;

            LogoAtt logo = _SafeModel.Logo;
            if (logo == null)
            {
                return;
            }
            _AIco.File = logo.Text;
            _AIco.Path = logo.Path;
            if (!CharUtil.IsValidateHash(logo.Text))
            {
                PbLogo.Image = BeanUtil.NaN16;
            }
            else
            {
                string path = _DataModel.KeyDir;
                if (CharUtil.IsValidateHash(logo.Path))
                {
                    path = Path.Combine(path, logo.Path, logo.Text + EApp.IMG_KEY_EDIT_EXT);
                }
                else
                {
                    path = Path.Combine(path, logo.Text + EApp.IMG_KEY_EDIT_EXT);
                }
                PbLogo.Image = BeanUtil.ReadImage(path, BeanUtil.NaN16);
            }

            HintAtt hint = _SafeModel.Hint;
            if (hint == null)
            {
                return;
            }
            TbHint.Text = hint.Data;

            Focus();
        }

        public bool SaveData()
        {
            if (_SafeModel.Key == null)
            {
                return false;
            }

            string text = TbName.Text;
            if (!CharUtil.IsValidate(text))
            {
                Main.ShowAlert("请输入记录标题！");
                TbName.Focus();
                return false;
            }

            MetaAtt meta = _SafeModel.Meta;
            if (meta.Text != text)
            {
                meta.Text = text;
                meta.Modified = true;
            }
            if (meta.Data != TbMeta.Text)
            {
                meta.Data = TbMeta.Text;
                meta.Modified = true;
            }
            _SafeModel.Modified |= meta.Modified;

            LogoAtt logo = _SafeModel.Logo;
            if (logo.Text != _AIco.File)
            {
                logo.Text = _AIco.File;
                logo.Modified = true;
            }
            if (logo.Path != _AIco.Path)
            {
                logo.Path = _AIco.Path;
                logo.Modified = true;
            }
            _SafeModel.Modified |= logo.Modified;

            HintAtt hint = _SafeModel.Hint;
            hint.Text = "";
            if (hint.Data != TbHint.Text)
            {
                hint.Data = TbHint.Text;
                hint.Modified = true;
            }
            _SafeModel.Modified |= hint.Modified;

            return true;
        }

        public void CutData()
        {
            if (_TBox != null)
            {
                _TBox.Cut();
            }
        }

        public void CopyData()
        {
            if (_TBox != null)
            {
                _TBox.Copy();
            }
        }

        public void PasteData()
        {
            if (_TBox != null)
            {
                _TBox.Paste();
            }
        }

        public void ClearData()
        {
            if (_TBox != null)
            {
                _TBox.Clear();
            }
        }
        #endregion

        #region 事件处理
        private void CbLib_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void PbLogo_Click(object sender, EventArgs e)
        {
            _AWiz.ShowIcoSeeker(_DataModel.KeyDir, new AmonHandler<Pwd.Ico>(ChangeImgByKey));
        }

        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbName;
        }

        private void TbMeta_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbMeta;
        }

        private void TbHint_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbHint;
        }

        private void TbMemo_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbMemo;
        }
        #endregion

        #region 私有函数
        private void ChangeImgByKey(Pwd.Ico ico)
        {
            _AIco = ico;
            string path;
            if (CharUtil.IsValidateHash(ico.Path))
            {
                path = Path.Combine(_DataModel.KeyDir, ico.Path, ico.File + EApp.IMG_KEY_EDIT_EXT);
            }
            else
            {
                path = Path.Combine(_DataModel.KeyDir, ico.File + EApp.IMG_KEY_EDIT_EXT);
            }
            PbLogo.Image = BeanUtil.ReadImage(path, BeanUtil.NaN16);
        }
        #endregion
    }
}