﻿namespace Me.Amon.Pwd.Wiz
{
    partial class BeanData
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
            this.BtOpt = new System.Windows.Forms.Button();
            this.TbData = new System.Windows.Forms.TextBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.可选输入OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.特殊符号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtOpt
            // 
            this.BtOpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtOpt.Location = new System.Drawing.Point(326, 0);
            this.BtOpt.Name = "BtOpt";
            this.BtOpt.Size = new System.Drawing.Size(21, 21);
            this.BtOpt.TabIndex = 3;
            this.BtOpt.Text = "button1";
            this.BtOpt.UseVisualStyleBackColor = true;
            this.BtOpt.Click += new System.EventHandler(this.BtOpt_Click);
            // 
            // TbData
            // 
            this.TbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbData.Location = new System.Drawing.Point(0, 0);
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(320, 21);
            this.TbData.TabIndex = 2;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.可选输入OToolStripMenuItem,
            this.数据集ToolStripMenuItem,
            this.特殊符号ToolStripMenuItem});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 92);
            // 
            // 可选输入OToolStripMenuItem
            // 
            this.可选输入OToolStripMenuItem.Name = "可选输入OToolStripMenuItem";
            this.可选输入OToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.可选输入OToolStripMenuItem.Text = "可选输入(&O)";
            // 
            // 数据集ToolStripMenuItem
            // 
            this.数据集ToolStripMenuItem.Name = "数据集ToolStripMenuItem";
            this.数据集ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.数据集ToolStripMenuItem.Text = "取值空间(&S)";
            // 
            // 特殊符号ToolStripMenuItem
            // 
            this.特殊符号ToolStripMenuItem.Name = "特殊符号ToolStripMenuItem";
            this.特殊符号ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.特殊符号ToolStripMenuItem.Text = "特殊符号(&C)";
            // 
            // BeanData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtOpt);
            this.Controls.Add(this.TbData);
            this.Name = "BeanData";
            this.Size = new System.Drawing.Size(350, 24);
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtOpt;
        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem 可选输入OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 特殊符号ToolStripMenuItem;
    }
}
