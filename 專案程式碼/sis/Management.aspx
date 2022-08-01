<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Management.aspx.cs" Inherits="sis.Management" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
    function LogOut() {
            PageMethods.Funct()
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:ScriptManager runat="server" ID="fun" EnablePageMethods="true"></asp:ScriptManager>
        <div>
            <asp:Button runat="server" ID="mag_user" OnClick="mag_user_Click" OnClientClick="" Text="管理使用者"/>            
            <asp:Button runat="server" ID="mag_course" OnClick="mag_course_Click" OnClientClick="" Text="管理課程資訊"/>
            <a href="Login.aspx" class="nav-link" onclick="LogOut()" style="color:red">登出</a>


        </div>
    </form>
</body>
</html>
