<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_0803_ucControl.Default" %>

<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>
<%@ Register Src="~/ucCoverImage.ascx" TagPrefix="uc1" TagName="ucCoverImage" %>
<%--放入userControl時會自動放入註冊的內容&參考哪些定義--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--tagname由註冊內容來的--%>
    <uc1:WebUserControl1 runat="server" id="WebUserControl1" />
    <uc1:ucCoverImage runat="server" id="ucCoverImage" MyTitle="測試 uc 1" BackColor="Red"/>
    <uc1:WebUserControl1 runat="server" id="WebUserControl2" />
    <uc1:ucCoverImage runat="server" ID="ucCoverImage1" />
    <uc1:WebUserControl1 runat="server" id="WebUserControl3" />
    <uc1:ucCoverImage runat="server" ID="ucCoverImage2" />
</asp:Content>
