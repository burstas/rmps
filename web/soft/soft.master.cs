﻿using System;
using System.Web.UI;

public partial class soft_soft : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 页面事件交互状态不进行后面的处理
        if (IsPostBack)
        {
            return;
        }
    }
}