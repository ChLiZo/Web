<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mag_user.aspx.cs" Inherits="sis.mag_user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
    function check() {
        var cObj = document.getElementsByName('account');
        for (var i = 0; i < cObj.length; i++) {
            if (cObj[i].checked) {
                return true;
            }
        }
        alert('請勾選至少一項');
        return false;
    }
</script>
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
      <td><%= account[i] %></td>
      <td><%= password[i] %></td><!--<input type="checkbox" name="account" value="< %=account[i]%>""/>-->
       <td>
           <label for="delete">刪除</label>
           <input type="radio" id="delete" name="delete" value="<%="b"+account[i]%>""/>
           <label for="alter">變更</label>
           <input type="radio" id="alter" name="alter" value="<%="c" +account[i] %>""/>
           <asp:Button runat="server" ID="sure" OnClick="sure_Click" OnClientClick="" Text="確定" checked="checked" />
       </td>
    </tr>
    <% } %>
    <tr >
      <td colspan="5"><asp:Button runat="server" ID="create" OnClick="create_Click" OnClientClick="" Text="新增資料" /></td>
    </tr>

    </form>
        </table>
            
        <a href="Management.aspx">返回</a>
        
        </div>
    </form>
</body>
</html>
