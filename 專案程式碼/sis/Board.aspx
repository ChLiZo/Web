<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Board.aspx.cs" Inherits="sis.Board" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="table table-dark table-hover">
                <tr>
                    <th>標題</th>
                    <th>發布單位</th>
                    <th>發布日期</th>
                </tr>
                <%for (int i = 0; i < newsId.Length; i++)
                    { %>
                <tr>
                    <td><a  class="title" href="news.aspx?id=<%=newsId[i] %>"><label><%= title[i] %></label></a></td>
                    <td><%= unit[i] %></td>
                    <td><%= date[i] %></td>
                </tr>
                <%} %>
            </table>
        </div>
    </form>
</body>
</html>
