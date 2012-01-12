﻿using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Att;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanHead : UserControl, IWizView
    {
        private SafeModel _SafeModel;

        public BeanHead()
        {
            InitializeComponent();
        }

        public BeanHead(SafeModel safeModel)
        {
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel)
        {
            CbLib.DataSource = dataModel.LibKey;
            CbLib.DisplayMember = "Name";
            CbLib.ValueMember = "Id";
        }

        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 0);
            Dock = DockStyle.Fill;
            grid.RowStyles[1].Height = 32;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
        }

        public void ShowData()
        {
            GuidAtt guid = _SafeModel.Guid;
            if (guid == null)
            {
                return;
            }

            CbLib.SelectedValue = new Item { K = guid.GetSpec(GuidAtt.SPEC_GUID_TPLT) };

            MetaAtt meta = _SafeModel.Meta;
            if (meta == null)
            {
                return;
            }
            TbName.Text = meta.Name;
            TbMeta.Text = meta.Data;

            LogoAtt logo = _SafeModel.Logo;
            if (logo == null)
            {
                return;
            }
            //TbLogoData.Text = logo.Data;

            HintAtt hint = _SafeModel.Hint;
            if (hint == null)
            {
                return;
            }
            TbHint.Text = hint.Data;

            CbLib.Focus();
        }

        public bool SaveData()
        {
            if (_SafeModel.Key == null)
            {
                return false;
            }

            LibHeader lib = CbLib.SelectedItem as LibHeader;
            if (lib == null || !CharUtil.IsValidateHash(lib.Id))
            {
                BeanUtil.ShowAlert("请选择您要使用的模板！");
                CbLib.Focus();
                return false;
            }

            string name = TbName.Text;
            if (!CharUtil.IsValidate(name))
            {
                BeanUtil.ShowAlert("请输入口令标题！");
                TbName.Focus();
                return false;
            }

            GuidAtt guid = _SafeModel.Guid;
            if (lib.Id != guid.GetSpec(GuidAtt.SPEC_GUID_TPLT))
            {
                guid.SetSpec(GuidAtt.SPEC_GUID_TPLT, lib.Id);
                if (!CharUtil.IsValidateHash(_SafeModel.Key.Id))
                {
                    _SafeModel.InitData(lib);
                }
            }

            MetaAtt meta = _SafeModel.Meta;
            meta.Name = name;
            meta.Data = TbMeta.Text;

            LogoAtt logo = _SafeModel.Logo;
            logo.Name = "";
            //logo.Data = TbLogo.Text;

            HintAtt hint = _SafeModel.Hint;
            hint.Name = "";
            hint.Data = TbHint.Text;

            return true;
        }

        public void CopyData()
        {
        }

        private void CbLib_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}