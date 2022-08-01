<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alter_user.aspx.cs" Inherits="sis.alter_user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            
        <table border="1">
    <tr >
      <td colspan="3">帳號列表</td>
    </tr>
    <tr>
      <td>帳號名稱</td>
      <td>帳號密碼</td>
      <td>管理工具</td>
    </tr>

    <form name="checkbox" method='post' onsubmit="return check()">
    <% for(var i=0;i<account.Length;i++){%>
    <tr>
      <td><input type="text" name="account" value="<%= account[i] %>" "/></td>
      <td><input type="text" name="password" value="<%= password[i] %>" "/></td> 
          <!--<input type="checkbox" name="account" value="< %=account[i]%>""/>-->
       <td>
           <asp:Button runat="server" ID="alter" OnClick="alter_Click" OnClientClick="" Text="確定" />
       </td>
    </tr>
    <% } %>
        </form>
        </table>
            <a href="mag_user.aspx">返回</a>

        </div>
    </form>
</body>
</html>
