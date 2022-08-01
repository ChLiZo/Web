<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="sis.Course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="1" width="100%" style="table-layout:fixed;word-break:break-all;background:#ecedbe">
                <tr>
                    <td>課程編號</td>
                    <td>課程名稱</td>
                    <td>上課時間</td>
                    <td>指導老師</td>
                </tr>
                <% for(int i=0;i<c_name.Length;i++){ %>
                <tr>
                    <td><%= c_id[i] %></td>
                    <td><%= c_name[i] %></td>
                    <td><%= c_time[i] %></td>
                    <td><%= teacher[i] %></td>
                </tr><% } %>
            </table>
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
                  <td align="center">第<%= i %>節<br/><%= time[i]%></td>
                  <% for(var j=1;j<8;j++){ %>
                    <td align="center"><%= schedule[j,i] %><br/><%=scheduleTeacher[j,i] %></td>
                  <% } %>
                </tr>
              <% } %>
            </table>
        </div>
        <!--<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString='<%$ ConnectionStrings:MyConnection %>' SelectCommand="SELECT [c_name], [teacher], [c_time], [c_id] FROM [course]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString='<%$ ConnectionStrings:MyConnection %>' SelectCommand="SELECT [id], [c_id] FROM [choose]"></asp:SqlDataSource>-->
    </form>
</body>
</html>
