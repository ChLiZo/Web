<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Drop.aspx.cs" Inherits="sis.Drop" %>

<!DOCTYPE html>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">


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

        <table border="1" width="100%" style="table-layout:fixed;word-break:break-all;background:#f2f2f2">
              <tr>
                <td align="center">課程時間表</td>
                <td align="center">星期一</td>
                <td align="center">星期二</td>
                <td align="center">星期三</td>
                <td align="center">星期四</td>
                <td align="center">星期五</td>
                <td align="center">星期六</td>
                <td align="center">星期七</td>
              </tr>
              <% string[] time =new string[] {"", "0810-0900", "0910-1000", "1010-1100", "1110-1200", "1330-1420", "1430-1520", "1530-1620", "1630-1720" }; %>
              <% for(var i=1;i<9;i++){%>
                <tr>
                  <td align="center">第<%= i %>節<br><%= time[i]%></td>
                  <% for(var j=1;j<8;j++){ %>
                    <td align="center"><%= schedule[j,i] %><br><%=scheduleTeacher[j,i] %></td>
                  <% } %>
                </tr>
              <% } %>
            </table>

    </form>
        </table>
    </form>
</body>
</html>