﻿using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using rmp.io.db;
using rmp.util;

public partial class mpwd_index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.SCRIPTID] = "index";

        if (IsPostBack)
        {
            return;
        }

        const string sid = "130F0000";
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010104, sid);
        dba.addSort(cons.io.db.comn.ComnCons.C0010105, false);
        dba.addLimit(1);

        DataTable dataList = dba.executeSelect();
        if (dataList.Rows.Count > 0)
        {
            DataRow row = dataList.Rows[0];

            lb_SoftVers.Text = row[cons.io.db.comn.ComnCons.C0010105].ToString();
            lb_PubsTime.Text = row[cons.io.db.comn.ComnCons.C0010107].ToString();
            String down = row[cons.io.db.comn.ComnCons.C001010F].ToString();
            hl_DownWinJ.NavigateUrl = down + "_win_with_jre.zip";
            hl_DownWinN.NavigateUrl = down + "_win.zip";
            hl_DownMac.NavigateUrl = down + "_mac.zip";
            hl_DownLnx.NavigateUrl = down + "_lin.zip";
            hl_DownAll.NavigateUrl = down + "_all.zip";
            hl_SoftJnlp.NavigateUrl = row[cons.io.db.comn.ComnCons.C0010110].ToString();
            hl_Win.NavigateUrl = String.Format("~/_images/{0}/3000_w03.png", sid);
            hl_Lin.NavigateUrl = String.Format("~/_images/{0}/3000_l01.png", sid);
            hl_Sub.NavigateUrl = String.Format("~/_images/{0}/3000_j01.png", sid);

            // 软件介绍
            SoftInfo.Text = WrpUtil.db2Html(row[cons.io.db.comn.ComnCons.C0010112].ToString());

            // 发行日期
            PubsTime.Text = row[cons.io.db.comn.ComnCons.C0010107].ToString();

            // 发行版本
            SoftVers.Text = row[cons.io.db.comn.ComnCons.C0010105].ToString();

            // 软件更新
            BugList.Text = WrpUtil.db2Html(row[cons.io.db.comn.ComnCons.C0010113].ToString());
        }
    }
}