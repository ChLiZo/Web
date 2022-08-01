<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alter_course.aspx.cs" Inherits="sis.alter_course" %>

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
      <td colspan="5">課程列表</td>
    </tr>
    <tr>
        <td>課程代碼</td>
       <td>課程名稱</td>
      <td>授課教師</td>
      <td>課程時間</td>
      <td>管理工具</td>
    </tr>

    <form name="checkbox" method='post' onsubmit="return check()">
    <% for(var i=0;i<course_id.Length;i++){%>
    <tr>
      <td><input type="text" name="course_id" value="<%= course_id[i] %>" "/></td>
      <td><input type="text" name="course_name" value="<%= course_name[i] %>" "/></td> 
      <td><input type="text" name="course_teacher" value="<%= course_teacher[i] %>" "/></td> 
      <td><input type="text" name="course_time" value="<%= course_time[i] %>" "/></td> 
          <!--<input type="checkbox" name="account" value="< %=account[i]%>""/>-->
       <td>
           <asp:Button runat="server" ID="alter" OnClick="alter_Click" OnClientClick="" Text="確定" />
       </td>
    </tr>
    <% } %>
        </form>
        </table>
            <a href="mag_course.aspx">返回</a>

        </div>
    </form>
</body>
</html>
