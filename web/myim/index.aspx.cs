﻿using System;
using System.Web.UI;

using cons.wrp;

public partial class myim_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "即时通讯";
        Session[cons.wrp.WrpCons.SCRIPTID] = "index";

        Session[cons.wrp.WrpCons.GUIDSIZE] = 1;

        if (IsPostBack)
        {
            return;
        }
    }
}