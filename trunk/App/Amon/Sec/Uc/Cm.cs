﻿using System;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Sec.Uc.CmUi;
using Me.Amon.Uc;
using Org.BouncyCastle.Crypto;

namespace Me.Amon.Sec.Uc
{
    public partial class Cm : UserControl, IView
    {
        private ASec _ASec;
        private ACm _Acm;

        private Default _Default;
        private Digest _Digest;
        private RandKey _RandKey;
        private Wrapper _Wrapper;
        private Confuse _Confuse;
        private Scrypto _Scrypto;
        private Sstream _Sstream;
        private Acrypto _Acrypto;
        private Txt2Img _Txt2Img;

        #region 构造函数
        public Cm()
        {
            InitializeComponent();
        }

        public Cm(ASec asec)
        {
            _ASec = asec;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void Init()
        {
            _Default = new Default(_ASec, this);
            _Digest = new Digest(_ASec, this);
            _RandKey = new RandKey(_ASec, this);
            _Wrapper = new Wrapper(_ASec, this);
            _Confuse = new Confuse(_ASec, this);
            _Scrypto = new Scrypto(_ASec, this);
            _Sstream = new Sstream(_ASec, this);
            _Acrypto = new Acrypto(_ASec, this);
            _Txt2Img = new Txt2Img(_ASec, this);

            _Acm = _Default;

            CbPads.Items.Add(ACm._SizeDef);
            CbPads.SelectedIndex = 0;

            CbMode.Items.Add(ACm._ModeDef);
            CbMode.SelectedIndex = 0;

            CbName.Items.Add(ACm._NameDef);
            CbName.SelectedIndex = 0;
        }

        public void InitOpt(string opt)
        {
            switch (opt)
            {
                case IData.OPT_DIGEST:
                    _Acm = _Digest;
                    break;
                case IData.OPT_RANDKEY:
                    _Acm = _RandKey;
                    break;
                case IData.OPT_WRAPPER:
                    _Acm = _Wrapper;
                    break;
                case IData.OPT_CONFUSE:
                    _Acm = _Confuse;
                    break;
                case IData.OPT_SCRYPTO:
                    _Acm = _Scrypto;
                    break;
                case IData.OPT_SSTREAM:
                    _Acm = _Sstream;
                    break;
                case IData.OPT_ACRYPTO:
                    _Acm = _Acrypto;
                    break;
                case IData.OPT_TXT2IMG:
                    _Acm = _Txt2Img;
                    break;
                default:
                    _Acm = _Default;
                    break;
            }
            _Acm.InitOpt();
        }

        public void InitDir(string dir)
        {
            _Acm.InitKey(dir);
        }

        public void InitAlg(string alg)
        {
        }

        public void FocusIn()
        {
            CbName.Focus();
        }

        public bool Check()
        {
            Item item = CbName.SelectedItem as Item;
            if (item == null || item.K == "0")
            {
                _ASec.ShowAlert("请选择算法名称！");
                CbName.Focus();
                return false;
            }
            return true;
        }

        public XmlElement SaveXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("cipher");

            XmlAttribute attr = doc.CreateAttribute("name");
            node.Attributes.Append(attr);

            Item item = CbName.SelectedItem as Item;
            if (item != null)
            {
                attr.Value = item.K;
            }

            attr = doc.CreateAttribute("mode");
            node.Attributes.Append(attr);
            item = CbMode.SelectedItem as Item;
            if (item != null)
            {
                attr.Value = item.K;
            }

            attr = doc.CreateAttribute("padding");
            node.Attributes.Append(attr);
            item = CbPads.SelectedItem as Item;
            if (item != null)
            {
                attr.Value = item.K;
            }

            return node;
        }

        public void LoadXml(XmlDocument doc)
        {
            XmlNode node = doc.SelectSingleNode("/msec/cipher");
            if (node != null)
            {
                XmlAttribute attr = node.Attributes["name"];
                if (attr != null)
                {
                    CbName.SelectedItem = new Item { K = attr.Value };
                }
                attr = node.Attributes["mode"];
                if (attr != null)
                {
                    CbMode.SelectedItem = new Item { K = attr.Value };
                }
                attr = node.Attributes["padding"];
                if (attr != null)
                {
                    CbPads.SelectedItem = new Item { K = attr.Value };
                }
            }
        }
        #endregion

        #region 事项处理
        private void CbName_SelectedIndexChanged(object sender, EventArgs e)
        {
#if DEBUG
            Main.LogInfo("CbName_SelectedIndexChanged...");
#endif
            Item item = CbName.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

#if DEBUG
            Main.LogInfo("CbName_SelectedIndexChanged:" + item.K);
#endif
            _Acm.ChangeName(item.K);
            _ASec.ChangeAlg(item.K);
        }

        private void CbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
#if DEBUG
            Main.LogInfo("CbMode_SelectedIndexChanged...");
#endif
            Item item = CbMode.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

#if DEBUG
            Main.LogInfo("CbMode_SelectedIndexChanged:" + item.K);
#endif
            string mode = item.K == "0" ? item.D : item.K;
            if (mode != null)
            {
                _Acm.ChangeMode(mode);
            }
        }

        private void CbPads_SelectedIndexChanged(object sender, EventArgs e)
        {
#if DEBUG
            Main.LogInfo("CbPads_SelectedIndexChanged...");
#endif
            Item item = CbPads.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

#if DEBUG
            Main.LogInfo("CbPads_SelectedIndexChanged:" + item.K);
#endif
            string size = item.K == "0" ? item.D : item.K;
            if (size != null)
            {
                _Acm.ChangePads(size);
            }
        }
        #endregion

        public BufferedBlockCipher Scrypto
        {
            get
            {
                return _Scrypto.Cipher;
            }
        }

        public BufferedAsymmetricBlockCipher Acrypto
        {
            get
            {
                return _Acrypto.Cipher;
            }
        }

        public IDigest Digest
        {
            get
            {
                return _Digest.Cipher;
            }
        }

        public Ce.Wrapper Wrapper
        {
            get
            {
                return _Wrapper.Cipher;
            }
        }

        public BufferedStreamCipher Stream
        {
            get
            {
                return _Sstream.Cipher;
            }
        }

        public string Txt2Img
        {
            get
            {
                return "txt2img";
            }
        }
    }
}