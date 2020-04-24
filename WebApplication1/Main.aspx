<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebApplication1.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 641px;
        }
        .auto-style2 {
            height: 125px;
        }
        .auto-style3 {
            height: 53px;
        }     
    </style>
    <link rel="stylesheet" type="text/css" href="Properties/dropDown.css">
    <script src="https://code.jquery.com/jquery-3.5.0.js" integrity="sha256-r/AaFHrszJtwpe+tHyNi/XCfMxYpbsRg2Uqn0x3s2zc=" crossorigin="anonymous"></script>
    <script>
        function Add() {
            $("#content").load("Add.aspx")
        }
        function Drop() {
            $("#content").load("Drop.aspx")
        }
        function Course() {
            $("#content").load("Course.aspx")
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header" style="border:2px black solid" class="auto-style2"></div>
        <div id="menu" class="auto-style3">
            <%--<ul class="dropDown">
                <li><a href="#">課程相關</a>
                    <ul>
                        <li><a href="add.aspx">加選</a></li>
                        <li><a href="drop.aspx">退選</a></li>
                        <li><a href="mycourse.aspx">我的課表</a></li>
                        <li><a href="search.aspx">課程查詢</a></li>
                    </ul>
                </li>
            </ul>--%>
            <ul class="dropDown">
                <li><a>課程相關</a>
                    <ul>
                        <li><a onclick="Add()">加選</a></li>
                        <li><a onclick="Drop()">退選</a></li>
                        <li><a onclick="Course()">我的課表</a></li>
                        <li><a onclick="Search()">課程查詢</a></li>
                    </ul>
                </li>
            </ul>

            <ul class="dropDown">
                <li><a>校務相關</a>
                    <ul>

                    </ul>
                </li>
            </ul>

        </div>
        <div id="content" style="border:2px black solid" class="auto-style1"></div>
    </form>
</body>
</html>
