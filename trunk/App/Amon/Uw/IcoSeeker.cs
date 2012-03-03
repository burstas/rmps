﻿using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Da;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Util;
using Me.Amon.Uw.Ico;

namespace Me.Amon.Uw
{
    public partial class IcoSeeker : Form
    {
        private UserModel _UserModel;
        private DirEdit _DirEdit;
        private IcoView _IcoView;
        private Control _Control;
        private string _RootDir;
        private string _HomeDir;
        private int _LastIdx;
        private int _IcoSize;

        #region 构造函数
        public IcoSeeker()
        {
            InitializeComponent();
        }

        public IcoSeeker(UserModel userModel, string rootDir)
        {
            _UserModel = userModel;
            _RootDir = rootDir;
            _HomeDir = rootDir;

            InitializeComponent();
        }

        public void InitOnce(int icoSize)
        {
            _IcoSize = icoSize;

            ShowIcoView();

            LsDir.Items.Add(new Dir { Id = "0", Name = "默认分类", Tips = "默认分类" });

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(DBConst.AICO0100);
            dba.AddColumn(DBConst.AICO0103);
            dba.AddColumn(DBConst.AICO0104);
            dba.AddColumn(DBConst.AICO0105);
            dba.AddColumn(DBConst.AICO0107);
            dba.AddWhere(DBConst.AICO0102, _UserModel.Code);
            dba.AddSort(DBConst.AICO0101, true);

            using (DataTable dt = dba.ExecuteSelect())
            {
                foreach (DataRow row in dt.Rows)
                {
                    Dir item = new Dir();
                    item.Id = row[DBConst.AICO0103] as string;
                    item.Name = row[DBConst.AICO0104] as string;
                    item.Tips = row[DBConst.AICO0105] as string;
                    item.Memo = row[DBConst.AICO0107] as string;
                    LsDir.Items.Add(item);
                }
            }

            LsDir.SelectedIndex = 0;
            _IcoView.ShowData(_HomeDir);
        }
        #endregion

        public int IcoSize { get { return _IcoSize; } }
        public string HomeDir { get { return _HomeDir; } }
        public AmonHandler<Bean.Ico> CallBackHandler { get; set; }

        #region 事件处理
        #region 界面事件
        private void LsDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_LastIdx == LsDir.SelectedIndex)
            {
                return;
            }
            _LastIdx = LsDir.SelectedIndex;

            if (_Control is DirEdit)
            {
                ShowIcoView();
            }

            Dir item = LsDir.SelectedItem as Dir;
            if (item == null)
            {
                return;
            }

            _HomeDir = CharUtil.IsValidateHash(item.Id) ? Path.Combine(_RootDir, item.Id) : _RootDir;
            if (!Directory.Exists(_HomeDir))
            {
                return;
            }
            _IcoView.ShowData(_HomeDir);
        }
        #endregion

        #region 菜单事件
        private void MiAppend_Click(object sender, EventArgs e)
        {
            if (_Control is IcoView)
            {
                ShowDirEdit();
            }
            _DirEdit.ShowData(new Dir());
        }

        private void MiUpdate_Click(object sender, EventArgs e)
        {
            Dir item = LsDir.SelectedItem as Dir;
            if (item == null || item.Id == "0")
            {
                return;
            }

            if (_Control is IcoView)
            {
                ShowDirEdit();
            }
            _DirEdit.ShowData(item);
        }

        private void MiDelete_Click(object sender, EventArgs e)
        {
            Dir item = LsDir.SelectedItem as Dir;
            if (item == null || item.Id == "0")
            {
                return;
            }

            if (DialogResult.Yes != MessageBox.Show("确认要删除吗？", "", MessageBoxButtons.YesNo))
            {
                return;
            }

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(DBConst.AICO0100);
            dba.AddWhere(DBConst.AICO0102, _UserModel.Code);
            dba.AddWhere(DBConst.AICO0103, item.Id);
            if (1 != dba.ExecuteDelete())
            {
                return;
            }
            if (Directory.Exists(HomeDir))
            {
                Directory.Delete(HomeDir, true);
            }

            LsDir.Items.Remove(item);
        }
        #endregion
        #endregion

        #region 私有函数
        private void ShowDirEdit()
        {
            if (_DirEdit == null)
            {
                _DirEdit = new DirEdit(this);
                _DirEdit.Init();
                _DirEdit.Location = new Point(138, 12);
                _DirEdit.Size = new Size(248, 249);
                _DirEdit.TabIndex = 1;
            }
            if (_IcoView != null)
            {
                Controls.Remove(_IcoView);
            }
            Controls.Add(_DirEdit);
            _Control = _DirEdit;
        }

        private void ShowIcoView()
        {
            if (_IcoView == null)
            {
                _IcoView = new IcoView(this);
                _IcoView.InitOnce();
                _IcoView.Location = new Point(138, 12);
                _IcoView.Size = new Size(248, 249);
                _IcoView.TabIndex = 1;
            }
            if (_DirEdit != null)
            {
                Controls.Remove(_DirEdit);
            }
            Controls.Add(_IcoView);
            _Control = _IcoView;
        }
        #endregion

        #region 公有函数
        public void UpdateDir(Dir item)
        {
            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(DBConst.AICO0100);
            dba.AddParam(DBConst.AICO0104, item.Name);
            dba.AddParam(DBConst.AICO0105, item.Tips);
            dba.AddParam(DBConst.AICO0106, item.Path);
            dba.AddParam(DBConst.AICO0107, item.Memo);
            if (CharUtil.IsValidateHash(item.Id))
            {
                dba.AddWhere(DBConst.AICO0102, _UserModel.Code);
                dba.AddWhere(DBConst.AICO0103, item.Id);
                dba.AddVcs(DBConst.AICO0108, DBConst.AICO0109, item.Operate, DBConst.OPT_INSERT);
                dba.ExecuteUpdate();

                LsDir.Items[LsDir.SelectedIndex] = item;
            }
            else
            {
                item.Id = HashUtil.UtcTimeInHex();
                dba.AddParam(DBConst.AICO0101, LsDir.Items.Count);
                dba.AddParam(DBConst.AICO0102, _UserModel.Code);
                dba.AddParam(DBConst.AICO0103, item.Id);
                dba.AddVcs(DBConst.AICO0108, DBConst.AICO0109);
                dba.ExecuteInsert();

                Directory.CreateDirectory(_RootDir + item.Id);
                LsDir.Items.Add(item);
                LsDir.SelectedItem = item;
            }
        }

        public void CallBack(Bean.Ico img)
        {
            if (CallBackHandler != null)
            {
                CallBackHandler.Invoke(img);
            }
            Close();
        }
        #endregion
    }
}
