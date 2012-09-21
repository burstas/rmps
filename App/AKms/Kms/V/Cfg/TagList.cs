﻿using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.V.Cfg
{
    public partial class TagList : UserControl, IConfig
    {
        public TagList()
        {
            InitializeComponent();
        }

        #region IConfig 成员

        public void Init()
        {
            LsTags.Items.AddRange(DataModel.ListCategory().ToArray());
        }

        public bool Save()
        {
            return true;
        }

        public UserControl UserControl
        {
            get { return this; }
        }

        #endregion

        private void PbDelete_Click(object sender, System.EventArgs e)
        {
            var cat = LsTags.SelectedItem as MCategory;
            if (cat == null)
            {
                return;
            }

            if (DialogResult.Yes != MessageBox.Show(this, "确认要废弃此标签吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            DataModel.RemoveTags(cat.C2010203);
            DataModel.DropCategory(cat);
            LsTags.Items.Remove(cat);
        }
    }
}
