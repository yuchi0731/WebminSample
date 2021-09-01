﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingDetail.aspx.cs" Inherits="_0728_1.SystemAdmin.AccountingDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       
        <table>
            <tr>
                <td colspan="2">
                    <h1>流水帳管理系統 - 後台</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <a href="UserInfo.aspx">使用者資訊</a><br />
                    <a href="AccountingList.aspx">流水帳管理</a>
                </td>
                <td>
                    <!--這裡放主要內容-->
                    <!--如果沒有資料要有目前尚未有資料的提示訊息-->
                    Type: <asp:DropDownList ID="ddlActType" runat="server">
                        <asp:ListItem Value="0">支出</asp:ListItem>
                        <asp:ListItem Value="1">收入</asp:ListItem>
                          </asp:DropDownList>
                    <br/>
                    Amount:
                    <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox>
                    <br/>
                    Caption:
                    <asp:TextBox ID="txtCaption" runat="server"></asp:TextBox>
                    <br/>
                    Desc:
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <br/>
                    <asp:FileUpload ID="fileCover" runat="server" /><br/>
  
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />   
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    <br/>
                    <asp:Literal ID="ltMsg" runat="server"></asp:Literal>

                </td>
            </tr>


        </table>

    </form>
</body>
</html>
