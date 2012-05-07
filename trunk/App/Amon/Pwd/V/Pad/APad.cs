﻿using System.Windows.Forms;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.V.Pad
{
    public partial class APad : UserControl, IPwd
    {
        private APwd _APwd;
        private SafeModel _SafeModel;

        public APad()
        {
            InitializeComponent();
        }

        public void Init(APwd apwd, SafeModel safeModel, DataModel dataModel)
        {
            _APwd = apwd;
            _SafeModel = safeModel;
        }

        public void Init()
        {
        }

        #region 接口实现
        public void InitView(Panel panel)
        {
            panel.Controls.Add(this);
            Dock = DockStyle.Fill;
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);
        }

        public void ShowInfo()
        {
        }

        public void ShowData()
        {
        }

        public void AppendKey()
        {
        }

        public bool UpdateKey()
        {
            return true;
        }

        public void DeleteKey()
        {
        }

        public void AppendAtt(int type)
        {
        }

        public void UpdateAtt(int type)
        {
        }

        public void CutAtt()
        {
        }

        public void CopyAtt()
        {
        }

        public void PasteAtt()
        {
        }

        public void ClearAtt()
        {
        }

        public void SaveAtt()
        {
        }

        public void DropAtt()
        {
        }
        #endregion

        public void ShowTips(Control control, string caption)
        {
            _APwd.ShowTips(control, caption);
        }
    }
}