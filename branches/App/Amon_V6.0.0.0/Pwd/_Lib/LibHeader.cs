﻿using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Lib
{
    public partial class LibHeader : UserControl, ILibEdit
    {
        private LibEdit _LibEdit;
        private Me.Amon.Pwd.Lib _LibHeader;

        public LibHeader()
        {
            InitializeComponent();
        }

        public LibHeader(LibEdit libEdit)
        {
            _LibEdit = libEdit;

            InitializeComponent();
        }

        public void Init()
        {
            TbName.MaxLength = DBConst.APWD0306_SIZE;
            TbMemo.MaxLength = DBConst.APWD0308_SIZE;
        }

        public void Show(Me.Amon.Pwd.Lib header)
        {
            _LibHeader = header;

            TbName.Text = _LibHeader.Name;
            TbMemo.Text = _LibHeader.Memo;
        }

        public void Save()
        {
            string name = TbName.Text;
            if (!CharUtil.IsValidate(name))
            {
                return;
            }

            _LibHeader.Name = name;
            _LibHeader.Memo = TbMemo.Text;

            _LibEdit.SaveHeader(_LibHeader);
            Show(new Me.Amon.Pwd.Lib());
        }
    }
}