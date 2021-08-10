<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormASJS.aspx.cs" Inherits="WebApplication2.WebFormASJS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        //要注意順序，先初始化再執行
        var val =<%= this.ForJSInt %>;
        var val2 = <%= (this.ForJSBool) ? "true" :"false" %>;
        var val3 = '<%=this.ForJSString%>';
    </script>
    <script src="script/WebForm1.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </form>
</body>
</html>
