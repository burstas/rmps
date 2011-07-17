﻿using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class help_help0005 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "独立插件";
        Session[cons.wrp.WrpCons.SCRIPTID] = "help0005";

        List<K1V2> guidList = Wrps.GuidHelp(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 guidItem = guidList[1];
        guidItem.K = "help0005.aspx";
        guidItem.V1 = "独立插件";
        guidItem.V2 = "独立插件";

        if (IsPostBack)
        {
            return;
        }
    }
}