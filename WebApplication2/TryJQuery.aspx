<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryJQuery.aspx.cs" Inherits="WebApplication2.TryJQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="script/jQuery3.6.0.js"></script>
<script>
    //$(document).ready(function () {可以簡寫成$(function ()

    $(document).ready(function () {
        $(".pp").click(function () {
            $(this).hide();//單一筆隱藏
        });

        //$("#p1").click(function () {
        //    $(".pp").show();//多筆show
        //});

            $("#txt1").change(function () {
                alert($(this).val());
            });

            $("#btn1").click(function () {
                $("#txt1").val('');//清空txt內容
            });
            //$("#btn1").click(function () {       //JS可多個事件
            //    alert(123);
            //});

            $("#btn1").on("click" ,function () {
                alert(123);
            });

            $("#btn1").mouseenter(function () {
                alert("You entered p1!");
            });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <p>If you click on me, I will disappear.</p>
            <p class="pp">Click me away!</p>
            <p class="pp">Click me away!</p>
            <p class="pp">Click me away!</p>
            <p class="pp">Click me away!</p>
            <p class="pp" id="p1">Click me too!</p>

          <input type="text" id="txt1" />
          <button type="button" id="btn1">Click Me</button>

            </div>
<%--        <script>
            var array = document.getElementsByClassName("pp");
            for (item of array) {
                item.onclick = function () {
                    item.style["display"] = "none";
                }
            }
        </script>--%>


    </form>
</body>
</html>
