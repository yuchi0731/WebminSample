<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDomSample.ascx.cs" Inherits="_0803_ucControl.ucDomSample" %>



<asp:PlaceHolder ID="PlaceHolder1" runat="server">
    <asp:Literal ID="Literal1" runat="server">Literal</asp:Literal>

    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </asp:PlaceHolder>

    <asp:Image ID="Image1" runat="server"  ImageUrl="~/Images/tankD.jpg" Width="270" Height="150" />

</asp:PlaceHolder>
