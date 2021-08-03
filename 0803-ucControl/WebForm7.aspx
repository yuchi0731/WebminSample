<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="_0803_ucControl.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> My Title </title>
    <style>
        p:last-child{
            /*color:aquamarine*/
        }

        span{
            color: blue
        }

        #span2{
            color:lightpink
        }
         #span3{
            color:lightblue
        }
         .cls1{
             color:blueviolet
         }
         .cls2{
             color:aqua
         }
         
         /*透過親子關係，選擇p裡面的span*/
         p > span{
             background-color:lightsteelblue
         }

    </style>
</head>
<body>    
        <div>
             <p class="cls1">P Text1</p>
            <p>
                <span class="cls2">First</span>
                <span id ="span2">Second</span>
                <span id ="span3">Third</span>
            </p>
            <p class="cls1">P Text3</p>
            <span>123123</span>
        </div>
</body>
</html>
