<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="sis.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>校務資訊系統</title>
    
    <link rel="stylesheet" href="https://cdn.staticfile.org/twitter-bootstrap/4.3.1/css/bootstrap.min.css"/>
    <script src="https://cdn.staticfile.org/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdn.staticfile.org/popper.js/1.15.0/umd/popper.min.js"></script>
    <script src="https://cdn.staticfile.org/twitter-bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {

            
            $("#content").load("/Board.aspx");

            $("#add").click(function () {
                $("#content").load("/Add.aspx");
            });
            $("#drop").click(function () {
                $("#content").load("/Drop.aspx");
            });
            $("#course").click(function () {
                $("#content").load("/Course.aspx");
            });
            $("#search").click(function () {
                $("#content").load("/Search.aspx");
            });
            $("#board").click(function () {
                $("#content").load("/Board.aspx");
            });
            $("#profile").click(function () {
                $("#content").load("/Profile.aspx");
            });

        });
        function loadBg() {
            document.body.style.backgroundImage = "url('Properties/blue.jpg')"; 
        }
        function LogOut() {
            PageMethods.Funct()
        }
    </script>
    <style>
        .bg-image {
            /*background-image: url(Properties/sky.jpg);;*/  /*自己的電腦圖片資料夾位置*/
            position: absolute;  /*絕對位置*/
            left: 0;
            right: 0;
             top: 0;
            bottom: 0;
            background-position: center;
            background-size: cover;
            z-index: -999; /*設定圖片層級*/
        }
    </style>
    
    
</head>
<body onload="loadBg()" class="bg-image">
    <form id="form1" runat="server"  class="bg-image">
        <asp:ScriptManager runat="server" ID="fun" EnablePageMethods="true"></asp:ScriptManager>
        <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
        <ul class="navbar-nav">
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="javascript: void(0)" id="navbardrop" data-toggle="dropdown">
		      課程相關
          </a>
          <div class="dropdown-menu">
            <a id="add" class="dropdown-item" >加選</a>
            <a id="drop" class="dropdown-item" >退選</a>
            <a id="course" class="dropdown-item" >我的課表</a>
		    <a id="search" class="dropdown-item" >課程查詢</a>
          </div>
        </li>
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="javascript: void(0)" id="navbardrop2" data-toggle="dropdown">
		      校務相關
          </a>
          <div class="dropdown-menu">
              <a id="board" class="dropdown-item">校務公布欄</a>
          </div>
        </li>
            <li><a class="nav-link" href="#" id="profile">個人資料</a> </li>   
        
<li><a href="Login.aspx" class="nav-link" onclick="LogOut()" style="color:red">登出</a></li>
        </ul>
         
    </nav>
        <br />
        <div id="content"style="padding:30px"></div>
    </form>
</body>
</html>