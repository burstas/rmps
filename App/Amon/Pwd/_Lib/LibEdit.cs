﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Lib
{
    public partial class LibEdit : Form
    {
        private TreeNode _Selected;
        private UserModel _UserModel;
        private DataModel _DataModel;
        private ILibEdit _UcEditer;
        private LibHeader _UcHeader;
        private LibDetail _UcDetail;

        public LibEdit()
        {
            InitializeComponent();
        }

        public LibEdit(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel)
        {
            _DataModel = dataModel;

            foreach (Pwd.Lib header in dataModel.LibList)
            {
                if (header.Id == "0")
                {
                    continue;
                }

                TreeNode root = new TreeNode();
                root.Name = header.Id;
                root.Tag = header;
                root.Text = header.Text;
                root.ToolTipText = header.Memo;
                TvLibView.Nodes.Add(root);

                if (header.Details == null)
                {
                    continue;
                }
                foreach (Pwd.LibDetail detail in header.Details)
                {
                    TreeNode node = new TreeNode();
                    node.Name = detail.Id;
                    node.Tag = detail;
                    node.Text = Att.SP_TPL_LS + detail.Text + Att.SP_TPL_RS;
                    node.ToolTipText = detail.Memo;
                    root.Nodes.Add(node);
                }
            }

            _UcHeader = new LibHeader(this);
            _UcHeader.Init();
            _UcDetail = new LibDetail(this);
            _UcDetail.Init();

            _UcHeader.Location = new Point(6, 20);
            _UcHeader.Size = new Size(231, 183);
            GbGroup.Controls.Add(_UcHeader);
            _UcHeader.Show(new Pwd.Lib());
            _UcEditer = _UcHeader;
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            _UcEditer.Save();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TvLibTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _Selected = e.Node;
            if (_Selected == null)
            {
                return;
            }

            object obj = _Selected.Tag;
            if (obj is Pwd.Lib)
            {
                ShowHeader(obj as Pwd.Lib);
                return;
            }
            if (obj is Pwd.LibDetail)
            {
                ShowDetail(obj as Pwd.LibDetail);
                return;
            }
        }

        private void MiAppendLibh_Click(object sender, EventArgs e)
        {
            ShowHeader(new Pwd.Lib());
        }

        private void MiDeleteLibh_Click(object sender, EventArgs e)
        {
            _Selected = TvLibView.SelectedNode;
            if (_Selected == null)
            {
                return;
            }

            object obj = _Selected.Tag;
            if (!(obj is Pwd.Lib))
            {
                return;
            }

            if (DialogResult.Yes != MessageBox.Show("确认要删除此模板吗，此操作将不可恢复？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
            {
                return;
            }

            Pwd.Lib header = (Pwd.Lib)obj;

            _UserModel.DBA.DeleteVcs(header);

            TvLibView.Nodes.Remove(_Selected);
            _DataModel.LibList.Remove(header);
            _DataModel.LibModified = -1;
        }

        private void MiAppendLibd_Click(object sender, EventArgs e)
        {
            _Selected = TvLibView.SelectedNode;
            if (_Selected == null)
            {
                return;
            }

            while (_Selected.Parent != null)
            {
                _Selected = _Selected.Parent;
            }
            ShowDetail(new Pwd.LibDetail());
        }

        private void MiDeleteLibd_Click(object sender, EventArgs e)
        {
            _Selected = TvLibView.SelectedNode;
            if (_Selected == null)
            {
                return;
            }
            object obj = _Selected.Tag;
            if (!(obj is Pwd.LibDetail))
            {
                return;
            }
            Pwd.LibDetail detail = (Pwd.LibDetail)obj;

            TreeNode node = _Selected.Parent;
            if (node == null)
            {
                return;
            }
            obj = node.Tag;
            if (!(obj is Pwd.Lib))
            {
                return;
            }
            Pwd.Lib header = (Pwd.Lib)obj;

            if (DialogResult.Yes != MessageBox.Show("确认要删除此属性吗，此操作将不可恢复？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
            {
                return;
            }

            _UserModel.DBA.DeleteVcs(detail);
            header.Details.Remove(detail);
            _UserModel.DBA.SaveVcs(header);

            TvLibView.Nodes.Remove(_Selected);
            _DataModel.LibModified = -1;
        }

        private void ShowHeader(Pwd.Lib header)
        {
            if (_UcEditer.Name != "LibHeader")
            {
                GbGroup.Controls.Clear();

                _UcHeader.Location = new System.Drawing.Point(6, 20);
                _UcHeader.Size = new System.Drawing.Size(231, 183);
                _UcHeader.TabIndex = 0;
                GbGroup.Controls.Add(_UcHeader);
                GbGroup.Text = "模板";

                _UcEditer = _UcHeader;
            }
            _UcHeader.Show(header);
        }

        private void ShowDetail(Pwd.LibDetail detail)
        {
            if (_UcEditer.Name != "LibDetail")
            {
                GbGroup.Controls.Clear();

                _UcDetail.Location = new System.Drawing.Point(6, 20);
                _UcDetail.Size = new System.Drawing.Size(231, 183);
                _UcDetail.TabIndex = 0;
                GbGroup.Controls.Add(_UcDetail);
                GbGroup.Text = "属性";

                _UcEditer = _UcDetail;
            }
            _UcDetail.Show(detail);
        }

        public void SaveHeader(Pwd.Lib header)
        {
            bool update = CharUtil.IsValidateHash(header.Id);
            _UserModel.DBA.SaveVcs(header);

            if (update)
            {
                _Selected.Text = header.Text;
                _Selected.ToolTipText = header.Memo;
            }
            else
            {
                _DataModel.LibList.Add(header);

                TreeNode node = new TreeNode();
                node.Name = header.Id;
                node.Tag = header;
                node.Text = header.Text;
                node.ToolTipText = header.Memo;
                TvLibView.Nodes.Add(node);

                TvLibView.SelectedNode = null;
            }

            _DataModel.LibModified = -1;
        }

        public void SaveDetail(Pwd.LibDetail detail)
        {
            bool update = CharUtil.IsValidateHash(detail.Id);

            Pwd.Lib header = _Selected.Tag as Pwd.Lib;
            detail.Header = header.Id;
            detail.Id = HashUtil.UtcTimeInHex(false);
            header.Details.Add(detail);
            _UserModel.DBA.SaveVcs(header);

            if (update)
            {
                _Selected.Text = Att.SP_TPL_LS + detail.Text + Att.SP_TPL_RS;
                TreeNode root = TvLibView.SelectedNode;
            }
            else
            {
                TreeNode node = new TreeNode();
                node.Name = detail.Id;
                node.Tag = detail;
                node.Text = Att.SP_TPL_LS + detail.Text + Att.SP_TPL_RS;
                node.ToolTipText = detail.Memo;
                _Selected.Nodes.Add(node);

                TvLibView.SelectedNode = null;
            }
            _DataModel.LibModified = -1;
        }
    }
}
