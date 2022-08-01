<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="sis.news" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://cdn.staticfile.org/twitter-bootstrap/4.3.1/css/bootstrap.min.css"/>
    <script src="https://cdn.staticfile.org/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdn.staticfile.org/popper.js/1.15.0/umd/popper.min.js"></script>
    <script src="https://cdn.staticfile.org/twitter-bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script> 
        $(document).ready(function () {
            $("#toggle").click(function () {
                if ($("#innercomment").css("display") == "none") {
                    $("#toggle").text("隱藏留言");
                    $("#innercomment").toggle();
                } else {
                    $("#toggle").text("顯示留言");
                    $("#innercomment").toggle();
                }
            });

            $(".backtoboard").click(function () {
                $("#content").load("/Board.aspx");
            });

        });
        function loadBg() {
            document.body.style.backgroundImage = "url('Properties/blue.jpg')";
        }
    </script>
    <style>
        .bg-image {
            /*background-image: url(Properties/sky.jpg);;*/  /*自己的電腦圖片資料夾位置*/
            position: absolute;  /*絕對位置*/
            left: 0;
            right: 0;
             top: 0;
            bottom: 0;
            background-position: center;
            background-size: cover;
            z-index: -999; /*設定圖片層級*/
        }
    </style>
    <title>公告</title>
</head>
<body onload="loadBg()" class="bg-image">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div style="padding: 30px">
            <center>
                <table class="table-dark table-bordered table-striped"style="width:100%">
                <tr>
                    <td>標題</td>
                    <td><label id="title" runat="server"></label></td>
                </tr>
                <tr>
                    <td>內容</td>
                    <td><label id="text" runat="server"></label></td>
                </tr>
                    <tr>
                    <td>發布單位</td>
                    <td><label id="unit" runat="server"></label></td>
                </tr>
                <tr>
                    <td>發布日期</td>
                    <td><label id="date" runat="server"></label></td>
                </tr>
                    <tr><td colspan="2"><a href="Main.aspx" class="backtoboard">>返回公告</a></td></tr>
            </table>
            </center>
            <div id="comment" style="padding-top: 20px;">
                <h1>留言</h1>
                <a href="javascript: void(0)" id="toggle" class="btn btn-info">顯示留言</a>
                <div id="innercomment" style="display: none;padding-top:10px">
                    <table class="table-dark table-bordered table-striped" style="width: 100%">
                        <%for (int i = 0; i < cmt_date.Length; i++){ %>
                        <tr>
                            <td>
                                <div class="card-dark">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col">
                                                <a href="#" class="btn btn-secondary disabled btn-sm"><%=i+1 %>樓
                                                </a>
                                                <label class="card-title" style="padding-left: 10px"><%= cmt_userId[i] %></label>
                                            </div>
                                        </div>
                                        <p class="card-text" style="padding:16px"><%=cmt_text[i] %></p>
                                        <p class="text-right"><small>發布日期:<%=cmt_date[i] %></small></p>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <%} %>
                    </table>
                    <div style="padding-top:20px">
                        <label for="comment">撰寫留言:</label>
                        <textarea class="form-control" style="resize:none" rows="5" id="input" runat="server"></textarea>
                    </div>
                    <asp:Button ID="Button2" runat="server" Text="發送留言" OnClick="Button2_Click" class="btn btn-info"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>