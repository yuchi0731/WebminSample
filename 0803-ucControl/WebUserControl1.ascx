<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="_0803_ucControl.WebUserControl1" %>
<%--userContrl使用者設定：只是一個小區塊，可以被模組化重複使用的小區塊，所以沒有初始版面設定--%>

<div>
<img runat="server" id="imgConver" src="/Images/tankD.jpg" width="270" height="150" />
<%--img替代文字跟ltlTitle的一樣--%>
<span>
        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
</span>
    </div>