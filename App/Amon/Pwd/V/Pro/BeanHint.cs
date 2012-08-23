﻿using System;
using System.Windows.Forms;
using Me.Amon.Gtd.V;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanHint : UserControl, IAttEdit
    {
        private APro _APro;
        private HintAtt _Att;

        #region 构造函数
        public BeanHint()
        {
            InitializeComponent();
        }

        public BeanHint(APro apro)
        {
            _APro = apro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            BtHint.Image = BeanUtil.NaN16;
        }

        public Control Control { get { return this; } }

        public string Title { get { return "提醒"; } }

        public bool ShowData(Att att)
        {
            _Att = att as HintAtt;

            if (_Att != null)
            {
                LlHint.Text = _Att.Gtd == null ? "<无提醒>" : _Att.Gtd.Title;
                TbData.Text = _Att.Data;
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

            if (TbData.Text != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }
            return true;
        }
        #endregion

        #region 事件处理
        private void BtName_Click(object sender, EventArgs e)
        {
            GtdEditor detail = new GtdEditor();
            detail.MGtd = _Att.Gtd;
            if (DialogResult.OK == detail.ShowDialog())
            {
                _Att.Gtd = detail.MGtd;
                LlHint.Text = _Att.Gtd.Title;
            }
        }
        #endregion
    }
}