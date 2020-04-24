<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Drop.aspx.cs" Inherits="WebApplication1.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script>
    function check() {
        var cObj = document.getElementsByName('c_id');
        for (var i = 0; i < cObj.length; i++) {
            if (cObj[i].checked) {
                return true;
            }
        }
        alert('請勾選至少一項');
        return false;
    }

    </script>
    <title>退選</title>
</head>
<body>
    <form id="form1" runat="server">
<table border="1">
    <tr >
      <td colspan="3">課程列表</td>
    </tr>
    <tr>
      <td>課程名稱</td>
      <td colspan="2">指導老師</td>
    </tr>

    <form name="checkbox" method='post' onsubmit="return check()">
    <% for(var i=0;i<cn.Length;i++){ %>
    <tr>
      <td><%= cn[i] %></td>
      <td><%= tn[i] %><input type="checkbox" name="c_id" value="<%=cid[i]%>""/></td>
    </tr>
    <% } %>
    <asp:Button runat="server" ID="Submit" OnClick="Submit_Click" OnClientClick="if(check()==false)return false;" Text="Submit"/>
    </form>
        </table>
    </form>
</body>
</html>
