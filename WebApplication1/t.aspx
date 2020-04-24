<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main</title>
    <style>
        a:link{
            color: #ffffff ;
        }
        a:visited{
            color: #ffffff;
        }
        a:hover{
            color: #ff0000;
        }
        *{
            margin:0px ;
            padding:0px;
        }
        #menu{
            margin: auto;
        }
        .main{
            
            color:black;
            font-family:微軟正黑體;
            font-weight:bold;
            font-size:20px;
            
            text-align:center;
            height:35px;
            line-height:35px;
            width:100px;
        }       
        .sub{
            cursor:pointer;
            background-color:#4d4949;
            color:white;
            font-family:微軟正黑體;
            text-align:center;
            font-weight:bold;
            width:100px;
        }
        .sub li{
            list-style-type:none;
            line-height:25px;
        }
        .item{
            float:left;
        }
    </style>
</head>
<body>
<div id="menu">
    <div class="item">
    <div class="main">課程</div>
    <div class="sub">
        <ul>
            <li><a href="add.aspx">加選</a></li>
            <li><a href="drop.aspx">退選</a></li>
            <li><a href="mycourse.aspx">我的課表</a></li>
            <li><a href="search.aspx">課程查詢</a></li>
        </ul>
    </div>
    </div> 
    <div class="item">
        <div class="main"></div>
        <div class="sub">
            <ul>
                <li></li>
                <li></li>
                <li></li>
            </ul>
        </div>
        </div>
</div>
    </body>
</html>