﻿using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Pwd.Bean;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class BeanFile : AFile, IAttEdit
    {
        private TextBox _Ctl;

        #region 构造函数
        public BeanFile()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            TbText.GotFocus += new EventHandler(TbName_GotFocus);
            TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtView.Image = viewModel.GetImage("att-file-preview");
            BtOpen.Image = viewModel.GetImage("att-file-append");

            InitSpec(TbData);
        }

        public Control Control { get { return this; } }

        public string Title { get { return "文件"; } }

        public bool ShowData(Att att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbText.Text = _Att.Text;
                TbData.Text = _Att.Data;
            }

            if (string.IsNullOrEmpty(TbText.Text))
            {
                TbText.Focus();
            }
            else
            {
                TbData.Focus();
            }
            return true;
        }

        public void Cut()
        {
            if (_Ctl != null)
            {
                _Ctl.Cut();
            }
        }

        public void Copy()
        {
            if (_Ctl != null)
            {
                _Ctl.Copy();
            }
        }

        public void Paste()
        {
            if (_Ctl != null)
            {
                _Ctl.Paste();
            }
        }

        public void Clear()
        {
            if (_Ctl != null)
            {
                _Ctl.Clear();
            }
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (TbText.Text != _Att.Text)
            {
                _Att.Text = TbText.Text;
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
        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbText;
            TbText.SelectAll();
        }

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbData;
            TbData.SelectAll();
        }

        private void BtView_Click(object sender, EventArgs e)
        {
            ShowSpec(BtView);
        }

        private void BtOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        #endregion
    }
}