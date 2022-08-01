<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="sis.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script>
        function loadBg() {
            document.body.style.backgroundImage = "url('Properties/blue.jpg')"; 
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
    <title></title>
</head>
<body onload="loadBg()" class="bg-image">
    <form id="form1" runat="server">
        <div>
        <table border="1">
    <tr>
      <td>姓名</td>
      <td><input type="text" name="name" value="<%= _name %>"/></td>
    </tr>
    <tr>
      <td>系別年級</td>
      <td><input type="text" name="grade" value="<%=_grade %>" /></td>
    </tr>
    <tr>
      <td>性別</td>
      <td><input type="text" name="sex" value="<%= _sex %>" /></td>
    </tr>
    <tr>
      <td>email</td>
      <td><input type="text" name="email" value="<%= _email %>" /></td>
    </tr>
    <tr>
      <td>電話號碼</td>
      <td><input type="text" name="phone" value="<%= _phone %>" /></td>
    </tr>
    <tr>
      <td>生日</td>
      <td><input type="text" name="birth" value="<%= _birth %>" /></td>
    </tr>
      <tr><td><asp:Button runat="server" ID="sure" OnClick="sure_Click" OnClientClick="" Text="確定變更" autopostback="false" /></td></tr>
        </table>
            <a href="Main.aspx">返回</a>
        </div>
    </form>
</body>
</html>
