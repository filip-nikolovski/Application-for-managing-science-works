<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Diplomska.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Најава</title>
    <link rel="shortcut icon" href="../Images/favicon.ico" />
    <link href="style/loginStile.css" rel="stylesheet" />
    <link href="style/bootstrap.css" rel="stylesheet" />
<script>

    //This is the function that closes the pop-up
    function endBlackout() {
        $(".blackout").css("display", "none");
        $(".msgbox").css("display", "none");
    }

    //This is the function that starts the pop-up
    function strtBlackout() {
        $(".msgbox").css("display", "block");
        $(".blackout").css("display", "block");
    }

</script>

</head>
<body onload="strtBlackout()">
    
   
    <div class="blackout">
    </div>
    <div class="msgbox">
        <div class="infoEnter">
            <b>Help</b>
            <button type="button" class="close" aria-hidden="true" onclick="endBlackout()">×</button>
        </div>
       
    
        <div style="padding:10px">
            <b>For enter in application you can register as a new user or use test login credentials:</b><hr style="padding:0;margin:0" />
           <div><b>For enter in users part of application:</b><br />
            username: filip@finki.com<br />
            password: password<br />
           </div>

            <div><b>For enter in admin part:</b><br />
            username: admin@finki.com<br />
            password: admin
            </div>
        </div>
    </div>



    <form class="form-signin" runat="server">
    
        <h2 class="form-signin-heading">Please sign in</h2>
        <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control" style="width:100%" placeholder="Email address" autofocus></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" type="password" class="form-control" style="width:100%" placeholder="Password"></asp:TextBox>
       
        <asp:CheckBox ID="chkRemember" runat="server" /> Keep me logged in
       
        <asp:Button ID="Button1" runat="server" onclick="Button2_Click" Text="Sign in" 
             class="btn btn-lg btn-primary btn-block" />
     


         <a href="Register.aspx" style="float:right">Register</a><b><asp:Label runat="server" ID="lbl" Text="|" style="float:right;margin-left:2%;margin-right:2%;"></asp:Label></b>
       <a href="RessetPassword.aspx" style="float:right">Forgot password</a><b><asp:Label runat="server" ID="Label1" Text="|" style="float:right;margin-left:2%;margin-right:2%;"></asp:Label></b> <a href="#" onclick="strtBlackout()" style="float:right">Help</a>  <br />
    <asp:Label ID="Label3" runat="server" Text="" Font-Size="12px" ForeColor="Red" Visible="false"></asp:Label>
     
</form>
    
    <script src="scripts/jquery.js"></script>
    <script src="scripts/bootstrap.min.js"></script>

    </body>
</html>
