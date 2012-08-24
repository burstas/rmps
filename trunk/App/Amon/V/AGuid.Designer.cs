﻿namespace Me.Amon.V
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
            this.MiApps = new System.Windows.Forms.ToolStripMenuItem();
            this.MiReset = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.MiPlugIns = new System.Windows.Forms.ToolStripMenuItem();
            this.MiLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.MiTray = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiSignOf = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.PbApp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseDown);
            this.PbApp.MouseEnter += new System.EventHandler(this.PbApp_MouseEnter);
            this.PbApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseMove);
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
            this.LvApp.ShowItemToolTips = true;
            this.LvApp.Size = new System.Drawing.Size(265, 116);
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
            this.MiApps,
            this.MiReset,
            this.MiSep0,
            this.MiTopMost,
            this.MiPlugIns,
            this.MiLogo,
            this.MiTray,
            this.MiSep1,
            this.MiSignOf,
            this.MiSep2,
            this.MiInfo,
            this.MiExit});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(164, 242);
            // 
            // MiApps
            // 
            this.MiApps.Name = "MiApps";
            this.MiApps.Size = new System.Drawing.Size(163, 22);
            this.MiApps.Text = "应用(&A)";
            // 
            // MiReset
            // 
            this.MiReset.Name = "MiReset";
            this.MiReset.Size = new System.Drawing.Size(163, 22);
            this.MiReset.Text = "重置(&R)";
            this.MiReset.Visible = false;
            this.MiReset.Click += new System.EventHandler(this.MiReset_Click);
            // 
            // MiSep0
            // 
            this.MiSep0.Name = "MiSep0";
            this.MiSep0.Size = new System.Drawing.Size(160, 6);
            // 
            // MiTopMost
            // 
            this.MiTopMost.Checked = true;
            this.MiTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiTopMost.Name = "MiTopMost";
            this.MiTopMost.Size = new System.Drawing.Size(163, 22);
            this.MiTopMost.Text = "窗口置项(&W)";
            this.MiTopMost.Click += new System.EventHandler(this.MiTopMost_Click);
            // 
            // MiPlugIns
            // 
            this.MiPlugIns.CheckOnClick = true;
            this.MiPlugIns.Name = "MiPlugIns";
            this.MiPlugIns.Size = new System.Drawing.Size(163, 22);
            this.MiPlugIns.Text = "显示扩展窗口(&P)";
            this.MiPlugIns.Click += new System.EventHandler(this.MiPlugIns_Click);
            // 
            // MiLogo
            // 
            this.MiLogo.Name = "MiLogo";
            this.MiLogo.Size = new System.Drawing.Size(163, 22);
            this.MiLogo.Text = "显示眼睛动画(&E)";
            this.MiLogo.Click += new System.EventHandler(this.MiLogo_Click);
            // 
            // MiTray
            // 
            this.MiTray.Name = "MiTray";
            this.MiTray.Size = new System.Drawing.Size(163, 22);
            this.MiTray.Text = "显示托盘图标(&T)";
            this.MiTray.Click += new System.EventHandler(this.MiTray_Click);
            // 
            // MiSep1
            // 
            this.MiSep1.Name = "MiSep1";
            this.MiSep1.Size = new System.Drawing.Size(160, 6);
            // 
            // MiSignOf
            // 
            this.MiSignOf.Name = "MiSignOf";
            this.MiSignOf.Size = new System.Drawing.Size(163, 22);
            this.MiSignOf.Text = "注销(&O)";
            this.MiSignOf.Click += new System.EventHandler(this.MiSignOf_Click);
            // 
            // MiSep2
            // 
            this.MiSep2.Name = "MiSep2";
            this.MiSep2.Size = new System.Drawing.Size(160, 6);
            // 
            // MiInfo
            // 
            this.MiInfo.Name = "MiInfo";
            this.MiInfo.Size = new System.Drawing.Size(163, 22);
            this.MiInfo.Text = "关于(&I)";
            this.MiInfo.Click += new System.EventHandler(this.MiInfo_Click);
            // 
            // MiExit
            // 
            this.MiExit.Name = "MiExit";
            this.MiExit.Size = new System.Drawing.Size(163, 22);
            this.MiExit.Text = "退出(&X)";
            this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // AGuid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 140);
            this.Controls.Add(this.PbApp);
            this.Controls.Add(this.LvApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AGuid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AGuid_MouseDown);
            this.MouseLeave += new System.EventHandler(this.AGuid_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AGuid_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AGuid_MouseUp);
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
        private System.Windows.Forms.ToolStripMenuItem MiTopMost;
        private System.Windows.Forms.ToolStripMenuItem MiPlugIns;
        private System.Windows.Forms.ToolStripSeparator MiSep0;
        private System.Windows.Forms.ToolStripMenuItem MiSignOf;
        private System.Windows.Forms.ToolStripSeparator MiSep1;
        private System.Windows.Forms.ToolStripMenuItem MiLogo;
        private System.Windows.Forms.ToolStripMenuItem MiTray;
        private System.Windows.Forms.ToolStripSeparator MiSep2;
        private System.Windows.Forms.ToolStripMenuItem MiReset;
        private System.Windows.Forms.ToolStripMenuItem MiInfo;
        private System.Windows.Forms.ToolStripMenuItem MiExit;
        private System.Windows.Forms.ToolStripMenuItem MiApps;
    }
}
