<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCoverImage.ascx.cs" Inherits="_0803_ucControl.ucCoverImage" %>
<%--userContrl使用者設定：只是一個小區塊，可以被模組化重複使用的小區塊，所以沒有初始版面設定--%>



<%--把一部分重複出現的小版面，包裝成userControl，也就是自己定義的控制項--%>
<%--再把控制項裡面的圖片跟文字的Literal放進來--%>

<div runat="server" id="divMain" style="background-color:blanchedalmond">

    <img runat="server" id="imgConver" src="/Images/tankD.jpg" width="270" height="150"/>
        <%--img替代文字跟ltlTitle的一樣--%>
<span>
        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>
</span>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</div>