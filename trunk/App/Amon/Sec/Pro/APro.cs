﻿using System;
using System.Windows.Forms;
using Me.Amon.Sec.Pro.Uc;
using Me.Amon.Sec.Pro.Uw;
using Me.Amon.Uc;
using Me.Amon.Uw;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Paddings;
using System.Drawing;
using Me.Amon.Util;

namespace Me.Amon.Sec.Pro
{
    public partial class APro : UserControl
    {
        private Cm _UcCm;
        private Uk _UcUk;
        private Di _UcDi;
        private Do _UcDo;

        private Edit _Edit;
        private UdcEditor _UdcEditor;
        private Open _Open;
        private Pass _Pass;
        private Save _Save;
        private Text _Text;

        public APro()
        {
            InitializeComponent();
        }

        public void InitOnce()
        {
            // 
            // UcDo
            // 
            _UcDo = new Me.Amon.Sec.Pro.Uc.Do(this);
            _UcDo.Init();
            _UcDo.Location = new System.Drawing.Point(258, 155);
            _UcDo.Name = "UcDo";
            _UcDo.Size = new System.Drawing.Size(240, 110);
            _UcDo.TabIndex = 6;
            Controls.Add(_UcDo);

            // 
            // UcDi
            // 
            _UcDi = new Me.Amon.Sec.Pro.Uc.Di(this);
            _UcDi.Init();
            _UcDi.Location = new System.Drawing.Point(12, 155);
            _UcDi.Name = "UcDi";
            _UcDi.Size = new System.Drawing.Size(240, 110);
            _UcDi.TabIndex = 5;
            Controls.Add(_UcDi);

            // 
            // UcUk
            // 
            _UcUk = new Me.Amon.Sec.Pro.Uc.Uk(this);
            _UcUk.Init();
            _UcUk.Location = new System.Drawing.Point(258, 39);
            _UcUk.Name = "UcUk";
            _UcUk.Size = new System.Drawing.Size(240, 110);
            _UcUk.TabIndex = 4;
            Controls.Add(_UcUk);

            // 
            // UcCm
            // 
            _UcCm = new Me.Amon.Sec.Pro.Uc.Cm(this);
            _UcCm.Init();
            _UcCm.Location = new System.Drawing.Point(12, 39);
            _UcCm.Name = "UcCm";
            _UcCm.Size = new System.Drawing.Size(240, 110);
            _UcCm.TabIndex = 3;
            Controls.Add(_UcCm);

            // 
            // CbKey
            // 
            CbKey.Items.Add(new Item { K = "0", V = "请选择" });
            CbKey.Items.Add(new Item { K = IData.DIR_ENC, V = "加密" });
            CbKey.Items.Add(new Item { K = IData.DIR_DEC, V = "解密" });
            CbKey.SelectedIndex = 0;
            CbKey.Visible = false;

            // 
            // CbOpt
            // 
            CbOpt.Items.Add(new Item { K = "0", V = "请选择" });
            CbOpt.Items.Add(new Item { K = IData.OPT_DIGEST, V = "散列算法" });
            //CbOpt.Items.Add(new Item { K = IData.OPT_RANDKEY, V = "随机口令" });
            CbOpt.Items.Add(new Item { K = IData.OPT_WRAPPER, V = "掩码算法" });
            CbOpt.Items.Add(new Item { K = IData.OPT_SCRYPTO, V = "块对称算法" });
            CbOpt.Items.Add(new Item { K = IData.OPT_SSTREAM, V = "流对称算法" });
            //CbOpt.Items.Add(new Item { K = IData.OPT_ACRYPTO, V = "非对称算法" });
            //CbOpt.Items.Add(new Item { K = IData.OPT_TXT2IMG, V = "图文转换" });
            CbOpt.SelectedIndex = 0;
        }

        #region 事件处理
        private void CbOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.LogInfo("CbOpt_SelectedIndexChanged...");

            Item item = CbOpt.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            _UcCm.InitOpt(item.K);
            _UcUk.InitOpt(item.K);
            _UcDi.InitOpt(item.K);
            _UcDo.InitOpt(item.K);

            switch (item.K)
            {
                case IData.OPT_DIGEST:
                    CbKey.Visible = false;
                    break;
                case IData.OPT_WRAPPER:
                    CbKey.SelectedIndex = 0;
                    CbKey.Visible = true;
                    CbKey.Focus();
                    break;
                case IData.OPT_SCRYPTO:
                    CbKey.SelectedIndex = 0;
                    CbKey.Visible = true;
                    CbKey.Focus();
                    break;
                case IData.OPT_SSTREAM:
                    CbKey.SelectedIndex = 0;
                    CbKey.Visible = true;
                    CbKey.Focus();
                    break;
                case IData.OPT_ACRYPTO:
                    CbKey.Visible = false;
                    break;
                case IData.OPT_TXT2IMG:
                    CbKey.Visible = false;
                    break;
                default:
                    CbKey.Visible = false;
                    _UcCm.FocusIn();
                    break;
            }
        }

        private void CbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            Main.LogInfo("CbKey_SelectedIndexChanged...");

            Item item = CbKey.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            _UcCm.InitDir(item.K);
            _UcUk.InitDir(item.K);
            _UcDi.InitDir(item.K);
            _UcDo.InitDir(item.K);
        }
        #endregion

        #region 公有函数
        public void ChangeAlg(string alg)
        {
            _UcUk.InitAlg(alg);
            _UcDi.InitAlg(alg);
            _UcDo.InitAlg(alg);
        }

        public void ShowEdit(string data, CallBackHandler<string> handler)
        {
            if (_Edit != null && _Edit.Visible)
            {
                return;
            }
            _Edit = new Edit();
            _Edit.CallBack = handler;
            _Edit.Location = new Point(Location.X + (Width - _Edit.Width) / 2, Location.Y + (Height - _Edit.Height) / 2);
            _Edit.Show(this, data);
        }

        public void ShowMask(Udc udc)
        {
            if (_UdcEditor != null && _UdcEditor.Visible)
            {
                return;
            }
            _UdcEditor = new UdcEditor(_UserModel);
            _UdcEditor.Init(null, udc);
            BeanUtil.CenterToParent(_UdcEditor, this);
            _UdcEditor.ShowDialog(this);
        }

        public void ShowOpen(string file, CallBackHandler<string> handler)
        {
            if (_Open == null)
            {
                _Open = new Open();
            }
            _Open.CallBack = handler;
            _Open.Show(this, file);
        }

        public void ShowPass(string pass, CallBackHandler<string> handler)
        {
            if (_Pass != null && _Pass.Visible)
            {
                return;
            }
            _Pass = new Pass();
            _Pass.CallBack = handler;
            _Pass.Location = new Point(Location.X + (Width - _Pass.Width) / 2, Location.Y + (Height - _Pass.Height) / 2);
            _Pass.Show(this, pass);
        }

        public void ShowSave(string file, CallBackHandler<string> handler)
        {
            if (_Save == null)
            {
                _Save = new Save();
            }
            _Save.CallBack = handler;
            _Save.Show(this, file);
        }

        public void ShowText(string data, CallBackHandler<string> handler)
        {
            if (_Text != null && _Text.Visible)
            {
                return;
            }
            _Text = new Text();
            _Text.CallBack = handler;
            _Text.Location = new Point(Location.X + (Width - _Text.Width) / 2, Location.Y + (Height - _Text.Height) / 2);
            _Text.Show(this, data);
        }
        #endregion

        #region 私有方法
        private void Digest()
        {
            IDigest digest = _UcCm.Digest;

            try
            {
                _UcDi.Begin();
                _UcDo.Begin();

                byte[] buf = new byte[IData.BUF_SIZE];
                int len = _UcDi.Read(buf, 0, buf.Length);
                while (len > 0)
                {
                    digest.BlockUpdate(buf, 0, len);
                    len = _UcDi.Read(buf, 0, buf.Length);
                }
                len = digest.DoFinal(buf, 0);
                _UcDo.Write(buf, 0, len);

                ShowInfo("处理已完成！");
            }
            catch (Exception exp)
            {
                ShowInfo("错误：" + exp.Message);
            }
            finally
            {
                _UcDo.End();
                _UcDi.End();
            }
        }

        private void Randkey()
        {
            _UcDo.Begin();

            byte[] buf = new byte[IData.BUF_SIZE];
            int len = _UcDi.Read(buf, 0, buf.Length);
            _UcDo.Write(buf, 0, len);

            ShowInfo("处理已完成！");

            _UcDo.End();
        }

        private void Wrapper()
        {
            try
            {
                _UcDi.Begin();
                _UcDo.Begin();

                byte[] buf = new byte[IData.BUF_SIZE];
                int len = _UcDi.Read(buf, 0, buf.Length);
                while (len > 0)
                {
                    _UcDo.Write(buf, 0, len);
                    len = _UcDi.Read(buf, 0, buf.Length);
                }

                ShowInfo("处理已完成！");
            }
            catch (Exception exp)
            {
                ShowInfo("错误：" + exp.Message);
            }
            finally
            {
                _UcDo.End();
                _UcDi.End();
            }
        }

        private void Scrypto(bool encrypt)
        {
            BufferedCipherBase cipher = _UcCm.Scrypto;
            cipher.Init(encrypt, _UcUk.GenParam());

            try
            {
                _UcDi.Begin();
                _UcDo.Begin();

                byte[] bi = new byte[IData.BUF_SIZE];
                byte[] bo = new byte[IData.BUF_SIZE];
                int li = _UcDi.Read(bi, 0, bi.Length);
                int lo;
                while (li > 0)
                {
                    lo = cipher.ProcessBytes(bi, 0, li, bo, 0);
                    _UcDo.Write(bo, 0, lo);
                    li = _UcDi.Read(bi, 0, bi.Length);
                }
                if (cipher is PaddedBufferedBlockCipher)
                {
                    lo = cipher.DoFinal(bo, 0);
                    _UcDo.Write(bo, 0, lo);
                }

                ShowInfo("处理已完成！");
            }
            catch (Exception exp)
            {
                ShowInfo("错误：" + exp.Message);
            }
            finally
            {
                _UcDo.End();
                _UcDi.End();
            }
        }

        private void Sstream(bool encrypt)
        {
            BufferedStreamCipher cipher = _UcCm.Stream;
            cipher.Init(encrypt, _UcUk.GenParam());

            try
            {
                _UcDi.Begin();
                _UcDo.Begin();

                byte[] bi = new byte[IData.BUF_SIZE];
                byte[] bo = new byte[IData.BUF_SIZE];
                int li = _UcDi.Read(bi, 0, bi.Length);
                int lo;
                while (li > 0)
                {
                    lo = cipher.ProcessBytes(bi, 0, li, bo, 0);
                    _UcDo.Write(bo, 0, lo);
                    li = _UcDi.Read(bi, 0, bi.Length);
                }
                lo = cipher.DoFinal(bo, 0);
                _UcDo.Write(bo, 0, lo);

                ShowInfo("处理已完成！");
            }
            catch (Exception exp)
            {
                ShowInfo("错误：" + exp.Message);
            }
            finally
            {
                _UcDo.End();
                _UcDi.End();
            }
        }

        private void Acrypto(bool encrypt)
        {
            BufferedBlockCipher cipher = _UcCm.Scrypto;
            cipher.Init(encrypt, _UcUk.GenParam());

            try
            {
                _UcDi.Begin();
                _UcDo.Begin();

                byte[] bi = new byte[IData.BUF_SIZE];
                byte[] bo = new byte[IData.BUF_SIZE];
                int li = _UcDi.Read(bi, 0, bi.Length);
                int lo;
                while (li > 0)
                {
                    lo = cipher.ProcessBytes(bi, 0, li, bo, 0);
                    _UcDo.Write(bo, 0, lo);
                    li = _UcDi.Read(bi, 0, bi.Length);
                }
                if (cipher is PaddedBufferedBlockCipher)
                {
                    lo = cipher.DoFinal(bo, 0);
                    _UcDo.Write(bo, 0, lo);
                }

                ShowInfo("处理已完成！");
            }
            catch (Exception exp)
            {
                ShowInfo("错误：" + exp.Message);
            }
            finally
            {
                _UcDo.End();
                _UcDi.End();
            }
        }

        private void Txt2Img()
        {
        }
        #endregion

    }
}
