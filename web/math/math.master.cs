﻿using System;
using System.Web.UI;

public partial class math_math : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 消息提示不可见
        lb_ErrMsg.Text = "";

        // 页面事件交互状态不进行后面的处理
        if (IsPostBack)
        {
            return;
        }
    }
}