﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_0728_1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:PlaceHolder ID="plcLogin" runat="server" Visible="false"></asp:PlaceHolder><br/>
        Account: <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
        <br/>
        Password: <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox>
        <br/>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <br/>
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </form>
</body>
</html>
