<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_course.aspx.cs" Inherits="sis.create_course" %>

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
      <td colspan="3">新增課程</td>
    </tr>
    <tr>
      <td>課程代碼</td>
      <td>課程名稱</td>
      <td>授課老師</td>
      <td>上課時間</td>
      <td>新增課程</td>
    </tr>

    <form name="checkbox" method='post' onsubmit="return check()">
    <tr>
      <td><input type="text" name="course_id" value="" "/></td>
      <td><input type="text" name="course_name" value="" "/></td>
      <td><input type="text" name="course_teacher" value="" "/></td>
      <td><input type="text" name="course_time" value="" "/></td> 
          <!--<input type="checkbox" name="account" value="< %=account[i]%>""/>-->
       <td>
           <asp:Button runat="server" ID="create" OnClick="create_Click" OnClientClick="" Text="新增" />
       </td>
    </tr>
        </form>
        </table>
            <a href="mag_course.aspx">返回</a>

        </div>
    </form>
</body>
</html>
