<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        div
        {
            position:absolute;
            top:28%;
            left:42%;
        }
        form
        {
            background-color:antiquewhite;
        }
        .auto-style1 {
            margin-top: 0px;
        }
        .auto-style2 {
            width: 221px;
            height: 187px;
        }
        .auto-style3 {
            width: 183px;
            height: 148px;
            margin-right: 12px;
        }
    </style>
<%--    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>--%>
    <meta http-equiv="Content-Type" content="text/html ; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script>
        function check() {
            var id = document.getElementById("account").value

            var pw = document.getElementById("password").value
            if (id=="" || pw=="") {
                document.getElementById("error").innerHTML = "invalid account or password"
                return false
            } else return true
        }  
        
    </script>
    <title>Login</title>
</head>
<body background="Properties/Tree.jpg">
     <div>
         <form id="form1" runat="server" margin:0 auto class="auto-style2">
        <fieldset style="margin-left: 10px; margin-top: 10px; margin-bottom: 10px;" class="auto-style3">
            <legend>
                <a>Login</a>
            </legend>
            <small  class="form-text text-muted">學號:</small>
            <asp:TextBox ID="account" runat="server" Height="22px" Width="170px" ></asp:TextBox><br /><br />
            <small  class="form-text text-muted">密碼:</small>
            <small  class="form-text text-muted">
            <asp:TextBox ID="password" runat="server" Height="22px" Width="170px" TextMode="Password"></asp:TextBox></small>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="if(check()==false) return false;" Text="Login" style="margin-left: 44px" Width="62px" CssClass="auto-style1"/>
        </fieldset>
            <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
        </form>
     </div>
</body>
</html>
