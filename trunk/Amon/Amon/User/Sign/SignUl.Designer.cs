﻿namespace Me.Amon.User.Sign
{
    partial class SignUl
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
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbPath = new System.Windows.Forms.Label();
            this.TbPath = new System.Windows.Forms.TextBox();
            this.LbData = new System.Windows.Forms.Label();
            this.TbInfo = new System.Windows.Forms.TextBox();
            this.BtPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(71, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "登录用户(&N)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(80, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(127, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbPath
            // 
            this.LbPath.AutoSize = true;
            this.LbPath.Location = new System.Drawing.Point(3, 33);
            this.LbPath.Name = "LbPath";
            this.LbPath.Size = new System.Drawing.Size(71, 12);
            this.LbPath.TabIndex = 2;
            this.LbPath.Text = "存储路径(&P)";
            // 
            // TbPath
            // 
            this.TbPath.Location = new System.Drawing.Point(80, 30);
            this.TbPath.Name = "TbPath";
            this.TbPath.ReadOnly = true;
            this.TbPath.Size = new System.Drawing.Size(100, 21);
            this.TbPath.TabIndex = 3;
            // 
            // LbData
            // 
            this.LbData.AutoSize = true;
            this.LbData.Location = new System.Drawing.Point(3, 60);
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(71, 12);
            this.LbData.TabIndex = 5;
            this.LbData.Text = "令牌数据(&T)";
            // 
            // TbInfo
            // 
            this.TbInfo.Location = new System.Drawing.Point(80, 57);
            this.TbInfo.Multiline = true;
            this.TbInfo.Name = "TbInfo";
            this.TbInfo.Size = new System.Drawing.Size(143, 48);
            this.TbInfo.TabIndex = 6;
            // 
            // BtPath
            // 
            this.BtPath.Location = new System.Drawing.Point(186, 30);
            this.BtPath.Name = "BtPath";
            this.BtPath.Size = new System.Drawing.Size(21, 21);
            this.BtPath.TabIndex = 4;
            this.BtPath.Text = "button1";
            this.BtPath.UseVisualStyleBackColor = true;
            // 
            // SignUl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtPath);
            this.Controls.Add(this.TbInfo);
            this.Controls.Add(this.LbData);
            this.Controls.Add(this.TbPath);
            this.Controls.Add(this.LbPath);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "SignUl";
            this.Size = new System.Drawing.Size(226, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbPath;
        private System.Windows.Forms.TextBox TbPath;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.TextBox TbInfo;
        private System.Windows.Forms.Button BtPath;
    }
}