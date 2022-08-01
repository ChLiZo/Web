<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="sis.Search" %>

<!DOCTYPE html>

<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://code.jquery.com/jquery-3.5.1.js" integrity="sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc=" crossorigin="anonymous"></script>
    <script>
        function MyClick1() {
            $('tr').css("display", "none")
            $('#default1').css("display", "")
            $('#default2').css("display", "")
            var name="#"+$('#name').val()
            $(name).css("display","")
        }
        function MyClick2() {
            $('tr').css("display", "none")
            $('#default1').css("display", "")
            $('#default2').css("display", "")

            var date = "." + $('#date').val()
            $(date).css("display", "")
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            教師姓名:
            <select id="name" name="name">
                <%foreach (var j in list){%>
                  <option value="<%=j%>"><%=j%></option>
                <%}%>
            </select>
            <button type="button" onclick="MyClick1()">搜尋</button><br />
            上課日期:
            <select id="date" name="date">
                <%for (var i = 1; i < 8; i++){%>
                  <option value="<%=i %>">星期<%=i %></option>
                <%}%>
            </select>
            <button type="button" onclick="MyClick2()">搜尋</button>
    <table style="border:2px #000000 solid;" cellpadding="2" border='1'>
    <tr id="default1">
      <td colspan="3">課程列表</td>
    </tr>
    <tr id="default2">
      <td>課程名稱</td>
      <td>上課時間</td>
      <td colspan="2">指導老師</td>
    </tr>

    <% for(var i=0;i<cn.Length;i++){ %>
    <tr id="<%= tn[i] %>" style="display:none;" class="<%= ct[i].ToString().Substring(0,1) %>">
      <td><%= cn[i] %></td>
      <td><%= cnt[i] %></td>  
      <td><%= tn[i] %></td>
    </tr>
    <% } %>
    </table>
        </div>
    </form>    
</body>
</html>