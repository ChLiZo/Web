<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>加選</title>
</head>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
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

<body>
    <form runat="server">
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
