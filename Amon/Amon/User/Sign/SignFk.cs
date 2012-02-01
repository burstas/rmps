﻿using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.User.Sign
{
    public partial class SignFk : UserControl, ISignAc
    {
        private SignAc _SignAc;
        private UserModel _UserModel;

        public SignFk()
        {
            InitializeComponent();
        }

        public SignFk(SignAc signAc, UserModel userModel)
        {
            _SignAc = signAc;
            _UserModel = userModel;

            InitializeComponent();
        }

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public void DoSignAc()
        {
        }

        public void DoCancel()
        {
            _SignAc.Close();
        }

        public void ShowMenu(Control control, int x, int y)
        {
        }
        #endregion
    }
}