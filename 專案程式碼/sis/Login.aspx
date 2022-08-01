<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="sis.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登入</title>
    <link rel="stylesheet" href="https://cdn.staticfile.org/twitter-bootstrap/4.3.1/css/bootstrap.min.css"/>
  <script src="https://cdn.staticfile.org/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://cdn.staticfile.org/popper.js/1.15.0/umd/popper.min.js"></script>
  <script src="https://cdn.staticfile.org/twitter-bootstrap/4.3.1/js/bootstrap.min.js"></script>
  <script>
        function check() {
            var id = document.getElementById("account").value

            var pw = document.getElementById("password").value
            if (id == "" || pw == "") {
                document.getElementById("error").innerHTML = "invalid account or password"
                return false
            } else return true
        }
  </script>
</head>

<body>
    <div style="background:url(Properties/Tree1.jpg);background-size:cover;">
	<div class="container-fluid text-center">
        <div class="row align-items-center mx-auto"style="height: 100vh;">
            <form id="form1" class="form-signin mx-auto" runat="server">
            <div class="col mx-auto">
		        <div class="form-group">
                    <label for="account">帳號/學號</label>
                    <input type="text" id="account" runat="server" class="form-control" placeholder="帳號" />
		        </div>
		        <div class="form-group">
                    <label for="password">密碼</label>
        	        <input type="password" id="password" runat="server" class="form-control" placeholder="密碼" />
		        </div>
                <asp:Button ID="Button1" runat="server" Text="登入" OnClick="Button1_Click" onclientclick="if(check()==false) return false;" class="btn btn-lg btn-primary btn-block"/>
            <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
		    </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:MyConnection %>' SelectCommand="SELECT [id], [password] FROM [account]"></asp:SqlDataSource>
            </form>
	    </div> 
    </div>
    </div>
</body>
</html>

