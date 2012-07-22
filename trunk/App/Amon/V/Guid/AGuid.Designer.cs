﻿namespace Me.Amon.V.Guid
{
    partial class AGuid
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PbApp = new System.Windows.Forms.PictureBox();
            this.LvApp = new System.Windows.Forms.ListView();
            this.IlApp = new System.Windows.Forms.ImageList(this.components);
            this.IsApp = new System.Windows.Forms.ImageList(this.components);
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MgTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.MgPlugIns = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MgSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignIn = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignOf = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignFp = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MgLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.MgTray = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MgInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MgExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PbApp)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbApp
            // 
            this.PbApp.BackColor = System.Drawing.SystemColors.Window;
            this.PbApp.Location = new System.Drawing.Point(12, 12);
            this.PbApp.Name = "PbApp";
            this.PbApp.Size = new System.Drawing.Size(25, 25);
            this.PbApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbApp.TabIndex = 3;
            this.PbApp.TabStop = false;
            this.PbApp.DoubleClick += new System.EventHandler(this.PbApp_DoubleClick);
            this.PbApp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseUp);
            // 
            // LvApp
            // 
            this.LvApp.AllowDrop = true;
            this.LvApp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvApp.LargeImageList = this.IlApp;
            this.LvApp.Location = new System.Drawing.Point(43, 12);
            this.LvApp.MultiSelect = false;
            this.LvApp.Name = "LvApp";
            this.LvApp.Size = new System.Drawing.Size(257, 130);
            this.LvApp.SmallImageList = this.IsApp;
            this.LvApp.TabIndex = 4;
            this.LvApp.UseCompatibleStateImageBehavior = false;
            this.LvApp.SelectedIndexChanged += new System.EventHandler(this.LvApp_SelectedIndexChanged);
            this.LvApp.DoubleClick += new System.EventHandler(this.LvApp_DoubleClick);
            // 
            // IlApp
            // 
            this.IlApp.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlApp.ImageSize = new System.Drawing.Size(32, 32);
            this.IlApp.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // IsApp
            // 
            this.IsApp.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IsApp.ImageSize = new System.Drawing.Size(16, 16);
            this.IsApp.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MgTopMost,
            this.MgPlugIns,
            this.MgSep0,
            this.MgSignUp,
            this.MgSignIn,
            this.MgSignOf,
            this.MgSignFp,
            this.MgSep1,
            this.MgLogo,
            this.MgTray,
            this.MgSep2,
            this.MiReset,
            this.toolStripSeparator1,
            this.MgInfo,
            this.MgExit});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(164, 270);
            // 
            // MgTopMost
            // 
            this.MgTopMost.Checked = true;
            this.MgTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MgTopMost.Name = "MgTopMost";
            this.MgTopMost.Size = new System.Drawing.Size(163, 22);
            this.MgTopMost.Text = "窗口置项(&W)";
            this.MgTopMost.Click += new System.EventHandler(this.MgTopMost_Click);
            // 
            // MgPlugIns
            // 
            this.MgPlugIns.CheckOnClick = true;
            this.MgPlugIns.Name = "MgPlugIns";
            this.MgPlugIns.Size = new System.Drawing.Size(163, 22);
            this.MgPlugIns.Text = "显示扩展(&P)";
            this.MgPlugIns.Click += new System.EventHandler(this.MgPlugIns_Click);
            // 
            // MgSep0
            // 
            this.MgSep0.Name = "MgSep0";
            this.MgSep0.Size = new System.Drawing.Size(160, 6);
            // 
            // MgSignUp
            // 
            this.MgSignUp.Name = "MgSignUp";
            this.MgSignUp.Size = new System.Drawing.Size(163, 22);
            this.MgSignUp.Text = "注册(&U)";
            // 
            // MgSignIn
            // 
            this.MgSignIn.Name = "MgSignIn";
            this.MgSignIn.Size = new System.Drawing.Size(163, 22);
            this.MgSignIn.Text = "登录(&L)";
            this.MgSignIn.Click += new System.EventHandler(this.MgSignIn_Click);
            // 
            // MgSignOf
            // 
            this.MgSignOf.Name = "MgSignOf";
            this.MgSignOf.Size = new System.Drawing.Size(163, 22);
            this.MgSignOf.Text = "注销(&O)";
            this.MgSignOf.Visible = false;
            this.MgSignOf.Click += new System.EventHandler(this.MgSignOf_Click);
            // 
            // MgSignFp
            // 
            this.MgSignFp.Name = "MgSignFp";
            this.MgSignFp.Size = new System.Drawing.Size(163, 22);
            this.MgSignFp.Text = "找回口令(&F)";
            this.MgSignFp.Visible = false;
            this.MgSignFp.Click += new System.EventHandler(this.MgSignFp_Click);
            // 
            // MgSep1
            // 
            this.MgSep1.Name = "MgSep1";
            this.MgSep1.Size = new System.Drawing.Size(160, 6);
            // 
            // MgLogo
            // 
            this.MgLogo.Name = "MgLogo";
            this.MgLogo.Size = new System.Drawing.Size(163, 22);
            this.MgLogo.Text = "显示眼睛动画(&E)";
            this.MgLogo.Click += new System.EventHandler(this.MgLogo_Click);
            // 
            // MgTray
            // 
            this.MgTray.Name = "MgTray";
            this.MgTray.Size = new System.Drawing.Size(163, 22);
            this.MgTray.Text = "显示托盘图标(&T)";
            this.MgTray.Click += new System.EventHandler(this.MgTray_Click);
            // 
            // MgSep2
            // 
            this.MgSep2.Name = "MgSep2";
            this.MgSep2.Size = new System.Drawing.Size(160, 6);
            // 
            // MiReset
            // 
            this.MiReset.Name = "MiReset";
            this.MiReset.Size = new System.Drawing.Size(163, 22);
            this.MiReset.Text = "重置(&R)";
            this.MiReset.Visible = false;
            this.MiReset.Click += new System.EventHandler(this.MiReset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // MgInfo
            // 
            this.MgInfo.Name = "MgInfo";
            this.MgInfo.Size = new System.Drawing.Size(163, 22);
            this.MgInfo.Text = "关于(&A)";
            this.MgInfo.Click += new System.EventHandler(this.MgInfo_Click);
            // 
            // MgExit
            // 
            this.MgExit.Name = "MgExit";
            this.MgExit.Size = new System.Drawing.Size(163, 22);
            this.MgExit.Text = "退出(&X)";
            this.MgExit.Click += new System.EventHandler(this.MgExit_Click);
            // 
            // AGuid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbApp);
            this.Controls.Add(this.LvApp);
            this.Name = "AGuid";
            this.Size = new System.Drawing.Size(312, 154);
            ((System.ComponentModel.ISupportInitialize)(this.PbApp)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbApp;
        private System.Windows.Forms.ListView LvApp;
        private System.Windows.Forms.ImageList IlApp;
        private System.Windows.Forms.ImageList IsApp;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MgTopMost;
        private System.Windows.Forms.ToolStripMenuItem MgPlugIns;
        private System.Windows.Forms.ToolStripSeparator MgSep0;
        private System.Windows.Forms.ToolStripMenuItem MgSignUp;
        private System.Windows.Forms.ToolStripMenuItem MgSignIn;
        private System.Windows.Forms.ToolStripMenuItem MgSignOf;
        private System.Windows.Forms.ToolStripMenuItem MgSignFp;
        private System.Windows.Forms.ToolStripSeparator MgSep1;
        private System.Windows.Forms.ToolStripMenuItem MgLogo;
        private System.Windows.Forms.ToolStripMenuItem MgTray;
        private System.Windows.Forms.ToolStripSeparator MgSep2;
        private System.Windows.Forms.ToolStripMenuItem MiReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MgInfo;
        private System.Windows.Forms.ToolStripMenuItem MgExit;
    }
}
