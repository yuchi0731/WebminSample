<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryAjax.aspx.cs" Inherits="WebApplication2.TryAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="script/jQuery3.6.0.js"></script>
    <script>
        $(function () {
            //check hidden field
            var domWeatherData = $("#hfWeatherData").val();//做狀態保留
            if (domWeatherData) {
                try {
                    var wData = JSON.parse(domWeatherData);
                    $("#spanLoc").text(wData["Name"]);
                    $("#spanTemp").text(wData["T"]);
                    $("#spanPop").text(wData["Pop"]);
                }
                catch {
                    $("#spanLoc").text("-");
                    $("#spanTemp").text("-");
                    $("#spanPop").text("-");
                }
            }

            //button click
            $("#btn1").click(function () {
                var acc = $("#txt1").val();
                var pwd = $("#pwd1").val();
                var url = "WeatherDataHandler.ashx?account=" + acc;

                $.ajax({
                    url: url,
                    type: "POST",
                    data: {
                        "Password":pwd
                    },
                    success: function (result) {
                        var txt = JSON.stringify(result);
                        $("#hfWeatherData").val(txt);

                        $("#spanLoc").text(result["Name"]);
                        $("#spanTemp").text(result["T"]);
                        $("#spanPop").text(result["Pop"]);


                        //type: "POST",
                        //data: {}
                         //url: "Test.txt", //透過Ajax讀取txt
                    //success: function (result) {
                    //    $("#div1").html(result); //按下按鈕後，將資料夾內的Test.txt內容(url來源)，成功讀取的話輸出在div1中
                    // }
                    }
                });
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        Account: <input type="text" id="txt1" /><br />
        Password: <input type="password" id="pwd1" /><br />
        <button type="button" id="btn1">Click Me</button>
        <div id="div1">--</div>
        <asp:HiddenField ID="hfWeatherData" runat="server" />

        <table border="1">
            <tr>
                <th>地點</th>
                <td>
                    <span id="spanLoc">-</span>
                </td>
            </tr>
            <tr>
                <th>溫度</th>
                <td>
                    <span id="spanTemp">-</span>
                </td>
            </tr>
            <tr>
                <th>降雨率</th>
                <td>
                    <span id="spanPop">-</span>
                </td>
            </tr>
        </table>

        <asp:Literal ID="ltMsg" runat="server">1</asp:Literal>
        <asp:Button ID="Button1" runat="server" Text="ltMsg+1" OnClick="Button1_Click" />


    </form>
</body>
</html>
