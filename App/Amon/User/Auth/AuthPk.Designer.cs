﻿namespace Me.Amon.User.Auth
{
    partial class AuthPk
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
            this.LbOldPass = new System.Windows.Forms.Label();
            this.TbOldPass = new System.Windows.Forms.TextBox();
            this.LbNewPass1 = new System.Windows.Forms.Label();
            this.TbNewPass1 = new System.Windows.Forms.TextBox();
            this.LbNewPass2 = new System.Windows.Forms.Label();
            this.TbNewPass2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbOldPass
            // 
            this.LbOldPass.AutoSize = true;
            this.LbOldPass.Location = new System.Drawing.Point(24, 6);
            this.LbOldPass.Name = "LbOldPass";
            this.LbOldPass.Size = new System.Drawing.Size(71, 12);
            this.LbOldPass.TabIndex = 0;
            this.LbOldPass.Text = "旧 口 令(&O)";
            // 
            // TbOldPass
            // 
            this.TbOldPass.Location = new System.Drawing.Point(101, 3);
            this.TbOldPass.Name = "TbOldPass";
            this.TbOldPass.Size = new System.Drawing.Size(100, 21);
            this.TbOldPass.TabIndex = 1;
            this.TbOldPass.UseSystemPasswordChar = true;
            // 
            // LbNewPass1
            // 
            this.LbNewPass1.AutoSize = true;
            this.LbNewPass1.Location = new System.Drawing.Point(24, 33);
            this.LbNewPass1.Name = "LbNewPass1";
            this.LbNewPass1.Size = new System.Drawing.Size(71, 12);
            this.LbNewPass1.TabIndex = 2;
            this.LbNewPass1.Text = "新 口 令(&N)";
            // 
            // TbNewPass1
            // 
            this.TbNewPass1.Location = new System.Drawing.Point(101, 30);
            this.TbNewPass1.Name = "TbNewPass1";
            this.TbNewPass1.Size = new System.Drawing.Size(100, 21);
            this.TbNewPass1.TabIndex = 3;
            this.TbNewPass1.UseSystemPasswordChar = true;
            // 
            // LbNewPass2
            // 
            this.LbNewPass2.AutoSize = true;
            this.LbNewPass2.Location = new System.Drawing.Point(24, 60);
            this.LbNewPass2.Name = "LbNewPass2";
            this.LbNewPass2.Size = new System.Drawing.Size(71, 12);
            this.LbNewPass2.TabIndex = 4;
            this.LbNewPass2.Text = "口令确认(&V)";
            // 
            // TbNewPass2
            // 
            this.TbNewPass2.Location = new System.Drawing.Point(101, 57);
            this.TbNewPass2.Name = "TbNewPass2";
            this.TbNewPass2.Size = new System.Drawing.Size(100, 21);
            this.TbNewPass2.TabIndex = 5;
            this.TbNewPass2.UseSystemPasswordChar = true;
            // 
            // AuthPk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbNewPass2);
            this.Controls.Add(this.LbNewPass2);
            this.Controls.Add(this.TbNewPass1);
            this.Controls.Add(this.LbNewPass1);
            this.Controls.Add(this.TbOldPass);
            this.Controls.Add(this.LbOldPass);
            this.Name = "AuthPk";
            this.Size = new System.Drawing.Size(226, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbOldPass;
        private System.Windows.Forms.TextBox TbOldPass;
        private System.Windows.Forms.Label LbNewPass1;
        private System.Windows.Forms.TextBox TbNewPass1;
        private System.Windows.Forms.Label LbNewPass2;
        private System.Windows.Forms.TextBox TbNewPass2;
    }
}