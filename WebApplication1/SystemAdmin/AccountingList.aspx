<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="_0728_1.SystemAdmin.AccountingList" %>


<%@ Register Src="~/UserControls/ucPager2.ascx" TagPrefix="uc1" TagName="ucPager2" %>



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
                    <asp:Button ID="btnCreate" runat="server" Text="Add Accounting" OnClick="btnCreate_Click" />
                    <br/>
                    <asp:GridView ID="gvAccountingList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvAccountingList_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                        <Columns>
                            <asp:BoundField DataField="Caption" HeaderText="標題" />
                            <asp:BoundField DataField="Amount" HeaderText="金額" />          
                            <asp:TemplateField HeaderText="In/Out">
                                <ItemTemplate>
                                  <%--  <%# ((int)Eval("ActType")==0) ? "支出" : "收入" %>--%>

                                   <%-- <asp:Literal ID="ltActType" runat="server"></asp:Literal>--%>
                                    <asp:Label ID="lblActType" runat="server"></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="建立日期" />
                            
                            <asp:TemplateField HeaderText="Act">
                                <ItemTemplate>
                                   <%-- <asp:Image ID="imgCover" runat="server" width="80" Height="50" Visible='<%# Eval("CoverImage")!=null %>'  ImageUrl='<%# "../FileDownload/Accounting/" + Eval("CoverImage") %>'/>--%>
                                   <!-- 只是空字串判斷寫這邊就好
                                    較為複雜  就在程式碼內處理-->


                                    <asp:Image ID="imgCover" runat="server" Visible="false" Width="80" Height="50" />

                                    <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>                    
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>


                    <div>
                        <uc1:ucPager2 runat="server" id="ucPager2" PageSize="10" Url="/SystemAdmin/AccountingList.aspx" />
                    </div>


                    <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            No data in your Accounting Note.
                        </p>
                    </asp:PlaceHolder>                    
                  
                </td>
            </tr>


        </table>

    </form>
</body>
</html>
