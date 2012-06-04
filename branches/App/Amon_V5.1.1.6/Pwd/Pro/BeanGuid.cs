﻿using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Bean;
using Me.Amon.Bean.Att;
using Me.Amon.Model;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanGuid : UserControl, IAttEdit
    {
        private AAtt _Att;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private DataTable _DataTable;

        #region 构造函数
        public BeanGuid()
        {
            InitializeComponent();
        }

        public BeanGuid(SafeModel safeModel, DataTable dataTable)
        {
            _SafeModel = safeModel;
            _DataTable = dataTable;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            PbCard.Image = viewModel.GetImage("export-card-16");
            //_AWiz.ShowTips(PbCard, "导出为卡片");

            if (!Directory.Exists("Card"))
            {
                return;
            }

            EventHandler exportHandler = new EventHandler(ExportCard_Click);

            XmlDocument doc = new XmlDocument();
            ToolStripMenuItem item;
            XmlNode node;
            foreach (string cardFile in Directory.GetFiles("Card", "*.acxml"))
            {
                try
                {
                    doc.Load(cardFile);

                    node = doc.SelectSingleNode("/amon/info/name");
                    string name = (node != null ? node.InnerText ?? "未知" : Path.GetFileName(cardFile));
                    node = doc.SelectSingleNode("/amon/info/type");
                    string type = (node != null ? node.InnerText ?? "" : "all").Trim().ToLower();

                    item = new ToolStripMenuItem();
                    item.Text = name;

                    if ("htm" == type)
                    {
                        item.Tag = "htm:" + cardFile;
                        item.Click += exportHandler;
                        CcHtm.DropDownItems.Add(item);
                        continue;
                    }
                    if ("svg" == type)
                    {
                        item.Tag = "svg:" + cardFile;
                        item.Click += exportHandler;
                        CcHtm.DropDownItems.Add(item);
                        continue;
                    }
                    if ("txt" == type)
                    {
                        item.Tag = "txt:" + cardFile;
                        item.Click += exportHandler;
                        CcTxt.DropDownItems.Add(item);
                        continue;
                    }
                    if ("vcf" == type)
                    {
                        item.Tag = "vcf:" + cardFile;
                        item.Click += exportHandler;
                        CcTxt.DropDownItems.Add(item);
                        continue;
                    }
                    if ("png" == type)
                    {
                        item.Tag = "png:" + cardFile;
                        item.Click += exportHandler;
                        CcImg.DropDownItems.Add(item);
                        continue;
                    }
                    if ("qrc" == type)
                    {
                        item.Tag = "qrc:" + cardFile;
                        item.Click += exportHandler;
                        CcImg.DropDownItems.Add(item);
                        continue;
                    }
                    item.Tag = "all:" + cardFile;
                    item.Click += exportHandler;
                    CcAll.DropDownItems.Add(item);
                }
                catch (Exception exp)
                {
                    Main.ShowError(exp);
                    return;
                }
            }
        }

        public Control Control { get { return this; } }

        public string Title { get { return "向导"; } }

        public bool ShowData(AAtt att)
        {
            if ((_DataModel.LibModified & IEnv.KEY_APWD) > 0)
            {
                CbName.DataSource = null;
                CbName.DataSource = _DataModel.LibList;
                CbName.DisplayMember = "Name";
                CbName.ValueMember = "Id";
                _DataModel.LibModified &= ~IEnv.KEY_APWD;
            }

            _Att = att;

            CbName.SelectedValue = new LibHeader { Id = att.GetSpec(GuidAtt.SPEC_GUID_TPLT) };
            PbCard.Visible = _Att.GetSpec(GuidAtt.SPEC_GUID_TPLT) == IEnv.LIB_CARD;
            CbName.Focus();
            return true;
        }

        public void Copy()
        {
        }

        public bool Save()
        {
            LibHeader header = CbName.SelectedItem as LibHeader;
            if (header == null || header.Id == "0")
            {
                return false;
            }

            if (header.Id != _Att.GetSpec(GuidAtt.SPEC_GUID_TPLT))
            {
                _Att.SetSpec(GuidAtt.SPEC_GUID_TPLT, header.Id);
                if (!_SafeModel.Key.IsUpdate)
                {
                    AAtt att;
                    if (_SafeModel.Count < AAtt.HEAD_SIZE)
                    {
                        att = _SafeModel.InitMeta();
                        _DataTable.Rows.Add(att.Order, att);
                        att = _SafeModel.InitLogo();
                        _DataTable.Rows.Add(att.Order, att);
                        att = _SafeModel.InitHint();
                        _DataTable.Rows.Add(att.Order, att);
                    }
                    _SafeModel.InitData(header);
                    for (int i = _DataTable.Rows.Count - 1; i >= AAtt.HEAD_SIZE; i -= 1)
                    {
                        _DataTable.Rows.RemoveAt(i);
                    }
                    for (int i = AAtt.HEAD_SIZE; i < _SafeModel.Count; i += 1)
                    {
                        att = _SafeModel.GetAtt(i);
                        _DataTable.Rows.Add(att.Order, att);
                    }
                }
                _Att.Modified = true;
            }

            return true;
        }
        #endregion

        #region 事件处理
        private void PbCard_Click(object sender, EventArgs e)
        {
            CmCard.Show(PbCard, 0, PbCard.Height);
        }

        private void ExportCard_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }

            string command = item.Tag as string;
            if (!CharUtil.IsValidate(command))
            {
                return;
            }

            int dot = command.IndexOf(':');
            if (dot < 0)
            {
                return;
            }

            string key = command.Substring(0, dot).ToLower();
            string src = command.Substring(dot + 1);
            if (!CharUtil.IsValidate(key) || !CharUtil.IsValidate(src))
            {
                return;
            }
            if (!File.Exists(src))
            {
                Main.ShowAlert(string.Format("无法读取卡片模板文件：{0}", src));
                return;
            }

            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }

            string dst = fd.SelectedPath;
            if (!CharUtil.IsValidate(dst))
            {
                Main.ShowAlert("您选择的目录不存在！");
                return;
            }

            Card card = new Card(_SafeModel);
            switch (key)
            {
                case "htm":
                    card.ExportHtm(src, dst);
                    break;
                case "svg":
                    card.ExportSvg(src, dst);
                    break;
                case "txt":
                    card.ExportTxt(src, dst);
                    break;
                case "vcf":
                    card.ExportVcf(src, dst);
                    break;
                case "png":
                    card.ExportPng(src, dst);
                    break;
                case "qrc":
                    card.ExportQrc(src, dst);
                    break;
                case "all":
                    card.ExportAll(src, dst);
                    break;
                default:
                    return;
            }
        }
        #endregion
    }
}