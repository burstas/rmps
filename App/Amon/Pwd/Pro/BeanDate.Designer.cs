﻿namespace Me.Amon.Pwd.Pro
{
    partial class BeanDate
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
            this.BtNow = new System.Windows.Forms.Button();
            this.DtData = new System.Windows.Forms.DateTimePicker();
            this.LbData = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbName = new System.Windows.Forms.Label();
            this.BtOpt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtNow
            // 
            this.BtNow.Location = new System.Drawing.Point(56, 57);
            this.BtNow.Name = "BtNow";
            this.BtNow.Size = new System.Drawing.Size(21, 21);
            this.BtNow.TabIndex = 4;
            this.BtNow.UseVisualStyleBackColor = true;
            this.BtNow.Click += new System.EventHandler(this.BtNow_Click);
            // 
            // DtData
            // 
            this.DtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtData.Location = new System.Drawing.Point(56, 30);
            this.DtData.Name = "DtData";
            this.DtData.Size = new System.Drawing.Size(200, 21);
            this.DtData.TabIndex = 3;
            // 
            // LbData
            // 
            this.LbData.AutoSize = true;
            this.LbData.Location = new System.Drawing.Point(3, 33);
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(47, 12);
            this.LbData.TabIndex = 2;
            this.LbData.Text = "数据(&D)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(56, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "名称(&N)";
            // 
            // BtOpt
            // 
            this.BtOpt.Location = new System.Drawing.Point(83, 57);
            this.BtOpt.Name = "BtOpt";
            this.BtOpt.Size = new System.Drawing.Size(21, 21);
            this.BtOpt.TabIndex = 5;
            this.BtOpt.UseVisualStyleBackColor = true;
            this.BtOpt.Click += new System.EventHandler(this.BtOpt_Click);
            // 
            // BeanDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtOpt);
            this.Controls.Add(this.BtNow);
            this.Controls.Add(this.DtData);
            this.Controls.Add(this.LbData);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "BeanDate";
            this.Size = new System.Drawing.Size(366, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtNow;
        private System.Windows.Forms.DateTimePicker DtData;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.Button BtOpt;
    }
}
