<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="_0803_ucControl.WebForm5" %>

<%@ Register Src="~/ucCoverImage.ascx" TagPrefix="uc1" TagName="ucCoverImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>第五頁</h2>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click1"/>
    <uc1:ucCoverImage runat="server" ID="ucCoverImage" />
</asp:Content>
