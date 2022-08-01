<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mag_course.aspx.cs" Inherits="sis.mag_course" %>

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
      <td colspan="3">課程列表</td>
    </tr>
    <tr>
      <td>課程名稱</td>
      <td>授課教師</td>
      <td>課程時間</td>
      <td>管理工具</td>
    </tr>

    <form name="checkbox" method='post' onsubmit="return check()">
    <% for(var i=0;i< course_name.Length;i++){%>
    <tr>
      <td><%= course_name[i] %></td>
      <td><%= course_teacher[i] %></td>
        <!--<input type="checkbox" name="account" value="< %=account[i]%>""/>-->
       
        <td><%= course_time[i] %></td>
      <td>
           <label for="delete">刪除</label>
           <input type="radio" id="delete" name="delete" value="<%="b"+course_id[i]%>""/>
           <label for="alter">變更</label>
           <input type="radio" id="alter" name="alter" value="<%="c" +course_id[i] %>""/>
           <asp:Button runat="server" ID="sure" OnClick="sure_Click" OnClientClick="" Text="確定" />
       </td>
    </tr>
    <% } %>
        <tr >
      <td colspan="5"><asp:Button runat="server" ID="create" OnClick="create_Click" OnClientClick="" Text="新增資料" /></td>
    </tr>
        </form>
        </table>
        </div> 
        <a href="Management.aspx">返回</a>
    </form>
</body>
</html>
