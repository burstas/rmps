﻿using System;
using System.Windows.Forms;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class UwAlg : Form
    {
        public UwAlg()
        {
            InitializeComponent();
        }

        public void Init()
        {
        }

        public string Alg { get; set; }

        public string BlockSize { get; set; }

        public string Padding { get; set; }

        private void BtOk_Click(object sender, EventArgs e)
        {

        }
    }
}