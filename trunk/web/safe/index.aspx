<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="cipher_Index" %>

<!doctype html>
<html>
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link href="index.css" rel="stylesheet" type="text/css" />
    <link href="../_res/jQueryUI/ui-lightness/jquery-ui-1.8.14.custom.css" rel="stylesheet" type="text/css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" type="text/javascript"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.14/jquery-ui.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="AmonForm" runat="server">
    <asp:ScriptManager ID="AmonManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="TextUpdate" runat="server">
        <ContentTemplate>
            <table style="width: 100%; height: 100%;" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="BgTl">
                    </td>
                    <td class="BgTm">
                    </td>
                    <td class="BgTr">
                    </td>
                </tr>
                <tr>
                    <td class="BgMl">
                    </td>
                    <td id="TdTa" class="BgMm">
                        <div id="DvSt" class="Txt">
                            <asp:TextBox ID="TaSt" runat="server" TextMode="MultiLine" ToolTip="输入内容(S)" AccessKey="S"></asp:TextBox>
                        </div>
                        <div id="DvOt" class="Txt">
                            <%-- Method Direction：操作方向（加密还是解密） --%>
                            <asp:ImageButton ID="IbMd" runat="server" AlternateText="X" ToolTip="互换(X)" AccessKey="X" OnClick="IbMd_Click" />
                            <%-- HdMd:是否为解密操作：1是，0否 --%>
                            <asp:HiddenField ID="HdMd" runat="server" />
                        </div>
                        <div id="DvDt" class="Txt">
                            <asp:TextBox ID="TaDt" runat="server" TextMode="MultiLine" ToolTip="输出内容(D)" AccessKey="D" ReadOnly="true"></asp:TextBox>
                        </div>
                    </td>
                    <td class="BgMr">
                    </td>
                </tr>
                <tr>
                    <td class="BgMl">
                    </td>
                    <td class="BgMm">
                        <%-- 算法选项 --%>
                        <div id="DvMo" runat="server">
                            <%-- Method Category:加密方案 --%>
                            <asp:DropDownList ID="CbMc" runat="server" ToolTip="加密方案(C)" AccessKey="C" OnSelectedIndexChanged="CbMc_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <%-- Method Function:加密算法 --%>
                            <asp:DropDownList ID="CbMf" runat="server" ToolTip="加密算法(A)" AccessKey="A">
                            </asp:DropDownList>
                            <%-- 密钥长度 --%>
                            <asp:DropDownList ID="CbMl" runat="server" ToolTip="密钥长度(L)" AccessKey="L">
                            </asp:DropDownList>
                            <img id="ImKd" runat="server" src="~/_img/safe/wizard16.png" alt="" title="生成密钥" onclick="return skd();" />
                            <asp:LinkButton ID="LbMc" runat="server" OnClientClick="return scd();">字符集</asp:LinkButton>
                        </div>
                        <asp:Label ID="LbErr1" runat="server"></asp:Label>
                    </td>
                    <td class="BgMr">
                    </td>
                </tr>
                <tr>
                    <td class="BgMl">
                    </td>
                    <td class="BgMm">
                        <%-- User Password用户口令 --%>
                        <asp:TextBox ID="TbUp" runat="server" ToolTip="用户口令(P)" AccessKey="P"></asp:TextBox>
                    </td>
                    <td class="BgMr">
                    </td>
                </tr>
                <tr>
                    <td class="BgBl">
                    </td>
                    <td class="BgBm" align="center">
                        <asp:Button ID="BtDo" runat="server" CssClass="Btn" OnClick="BtDo_Click" Text="执行(R)" AccessKey="R" />
                        <asp:Button ID="BtOp" runat="server" CssClass="Btn" OnClick="BtOp_Click" />
                    </td>
                    <td class="BgBr">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="dvCd" title="字符集" style="display: none;">
        <iframe id="ifCd" style="border: 0; width: 100%; height: 100%; overflow: hidden;"></iframe>
    </div>
    <div id="dvKd" title="密钥对" style="display: none;">
        <iframe id="ifKd" style="border: 0; width: 100%; height: 100%; overflow: hidden;"></iframe>
    </div>
    <div id="dvTp" style="width: 302px; height: 152px; position: absolute; left: 50px; top: 30px; background-color: Gray; display: none;">
    </div>
    </form>
</body>
</html>

<script src="index.js" type="text/javascript"></script>

