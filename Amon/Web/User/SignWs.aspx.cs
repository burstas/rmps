﻿using System;
using System.Text;
using System.Xml;
using Me.Amon.Model;

public partial class User_SignWs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserModel.Current(Session).Rank < IUser.LEVEL_01)
        {
            Response.Redirect("~/Index.aspx");
            return;
        }

        if (IsPostBack)
        {
            return;
        }
    }

    protected void BtSignWs_Click(object sender, EventArgs e)
    {
        String userPwds = TbPass1.Text;
        if (string.IsNullOrEmpty(userPwds))
        {
            LbErrMsg.Text = "请输入【登录口令】！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbPass1.Focus();
            return;
        }
        if (userPwds.Length < 4)
        {
            LbErrMsg.Text = "【登录口令】字符串长度不能小于 4 位！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbPass1.Focus();
            return;
        }
        if (userPwds != TbPass2.Text)
        {
            LbErrMsg.Text = "您两次输入的口令不一致，请重新输入！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbPass1.Text = "";
            TbPass2.Text = "";
            TbPass1.Focus();
            return;
        }

        StringBuilder buffer = new StringBuilder();
        XmlWriter writer = XmlWriter.Create(buffer);
        writer.WriteStartElement("Amon");
        writer.WriteStartElement("User");

        UserModel userModel = UserModel.Current(Session);
        if (!userModel.SignWs(userModel.Name, userPwds, writer))
        {
            LbErrMsg.Text = "用户注册失败，请稍后重试！";
            TrErrMsg.Attributes.Add("style", "display:;");
            return;
        }

        tr_RegData1.Visible = false;
        tr_RegData2.Visible = false;
        tr_RegInfo.Visible = true;

        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.Flush();
        writer.Close();

        TBData.Text = buffer.Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"").ToString();
    }
}