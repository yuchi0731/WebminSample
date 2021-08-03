<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="_0803_ucControl.WebForm4" %>

<%@ Register Src="~/ucCoverImage.ascx" TagPrefix="uc1" TagName="ucCoverImage" %>
<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>第四頁</h2>
    <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
    <uc1:ucCoverImage runat="server" ID="ucCoverImage" />
</asp:Content>
