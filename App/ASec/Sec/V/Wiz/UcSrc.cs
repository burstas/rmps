﻿using System;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class UcSrc : UserControl
    {
        private ASec _ASec;
        private TextReader _Reader;

        #region 构造函数
        public UcSrc()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共函数
        public void InitView(ASec asec)
        {
            _ASec = asec;

            _ASec.ShowTips(PbMask, "选择掩码");
            _ASec.ShowTips(PbFile, "打开文件");
        }

        public void AppendFiles(string[] files)
        {
            foreach (string file in files)
            {
                if (Exists(file))
                {
                    continue;
                }
                LbFile.Items.Add(new Items { K = file, V = Path.GetFileName(file) });
            }
        }

        public void RemoveSelectedFile()
        {
            var idx = LbFile.SelectedIndex;
            if (idx < 0)
            {
                return;
            }
            LbFile.Items.RemoveAt(idx);
            if (idx == LbFile.Items.Count)
            {
                idx -= 1;
            }
            if (idx > 0)
            {
                LbFile.SelectedIndex = idx;
            }
        }

        public void ChangeOpt(string opt)
        {
            bool b = opt == "enc" || opt == "dec";
            //LlKey.Visible = b;
            //TbKey.Visible = b;
            //PbKey.Visible = b;
            //PbOUdc.Visible = b;
        }

        public void ChangeDir(string dir)
        {
        }

        public bool CheckInput()
        {
            if (TcSrc.SelectedTab == TpText)
            {
                string text = TbText.Text;
                if (string.IsNullOrEmpty(text))
                {
                    MessageBox.Show(this, "请输入您要处理的文本！");
                    TbText.Focus();
                    return false;
                }
            }
            else if (TcSrc.SelectedTab == TpFile)
            {
                if (LbFile.Items.Count < 1)
                {
                    MessageBox.Show(this, "请选择您要处理的文件！");
                    LbFile.Focus();
                    return false;
                }
            }
            return true;
        }

        public void Begin()
        {
            if (TcSrc.SelectedTab == TpText)
            {
                _Reader = new StringReader(TbText.Text);
                return;
            }

            if (TcSrc.SelectedTab == TpFile)
            {
                _Reader = new StreamReader("");
            }
        }

        public int Process(byte[] buffer, int offset, int length)
        {
            return -1;
        }

        public int Process(char[] buffer, int offset, int length)
        {
            return _Reader.Read(buffer, offset, length);
        }

        public void End()
        {
            _Reader.Close();
        }
        #endregion

        #region 事件处理
        private void TcSrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            PbFile.Visible = TcSrc.SelectedTab == TpFile;
        }

        private void TbText_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TbText_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                object obj = e.Data.GetData(DataFormats.StringFormat);
                if (obj == null)
                {
                    return;
                }
                TbText.Paste(obj as string);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LbFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void LbFile_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                object obj = e.Data.GetData(DataFormats.FileDrop);
                if (obj == null)
                {
                    return;
                }
                string[] arr = obj as string[];
                AppendFiles(arr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LbFile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PbMask_Click(object sender, EventArgs e)
        {

        }

        private void PbFile_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != Main.ShowOpenFileDialog(null, CApp.FILE_OPEN_ALL, null, true))
            {
                return;
            }
            AppendFiles(Main.OpenFileDialog.FileNames);
        }
        #endregion

        #region 私有函数
        private bool Exists(string file)
        {
            foreach (Items item in LbFile.Items)
            {
                if (file == item.K)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}