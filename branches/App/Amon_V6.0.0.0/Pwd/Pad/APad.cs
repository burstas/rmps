﻿using System.Windows.Forms;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.Pad
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
        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 1);
            Dock = DockStyle.Fill;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
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

        public void CopyAtt()
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
