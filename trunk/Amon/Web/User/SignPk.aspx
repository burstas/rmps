﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SignPk.aspx.cs" Inherits="User_SignPk" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr id="TrErrMsg" runat="server">
            <td align="center">
                <asp:Label ID="LbErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr id="tr_RegData1" runat="server">
            <td align="center">
                <table border="0" cellpadding="4" cellspacing="0" width="300" class="TB_DataList_TL">
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            现有口令：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="TbOldPass" runat="server" Style="width: 160px;" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            新登录口令：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="TbNewPass" runat="server" Style="width: 160px;" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            新口令确认：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="TbRepPass" runat="server" Style="width: 160px;" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_RegData2" runat="server">
            <td align="center">
                <table border="0" cellpadding="4" cellspacing="0" width="300">
                    <tr>
                        <td align="right">
                            <asp:Button ID="BtSignPk" runat="server" Text="修改(R)" AccessKey="R" OnClick="BtSignPk_Click" OnClientClick="return checkNull();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_RegInfo" runat="server" visible="false">
            <td align="center">
                <table border="0" cellpadding="5" cellspacing="0" width="300" class="TB_DataList_TL">
                    <tr>
                        <th align="left" class="TD_DataHead_TL_L">
                            恭喜：口令修改成功！
                        </th>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="AmonFoot" ContentPlaceHolderID="AmonFoot" runat="Server">
    <script type="text/javascript" src="SignPk.js"></script>
</asp:Content>