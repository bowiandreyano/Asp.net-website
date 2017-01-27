<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="FrontEnd_CustomerLogin_CustomerLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
   <meta charset="UTF-8">
  <title>Login Form</title>
  <meta name="viewport" content="initial-scale=1.0, width=device-width" />
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/meyer-reset/2.0/reset.min.css">
  <link rel="stylesheet" href="FrontEnd/CustomerLogin/css/style.css">
  <title></title>
</head>
<body>
<div class="login_form" runat="server" >
  <setion class="login-wrapper">
    
    <div class="logo">
    </div>
    
    <form id="login" method="post" action="#" runat="server">
     
      <label for="username">User Name</label>
      <asp:TextBox ID="TextBox1" runat="server" required name="login[username]" type="text" autocapitalize="off" autocorrect="off"></asp:TextBox>
      
      <label for="password">Password</label>
      <asp:TextBox ID="TextBox2" runat="server" required name="login[password]" type="password"></asp:TextBox>
      <div class="hide-show">
        <span>Show</span>
      </div>

        <div class="">
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"></asp:Button>
        </div>
</div>
      
    </form>
    
  </section>
</div>
  <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
   <SCRIPT type=text/javascript>
    function doClick(buttonName,e)
    {
        //the purpose of this function is to allow the enter key to 
        //point to the correct button to click.
        var key;

         if(window.event)
              key = window.event.keyCode;     //IE
         else
              key = e.which;     //firefox

        if (key == 13)
        {
            //Get the button the user wants to have clicked
            var btn = document.getElementById(buttonName);
            if (btn != null)
            { //If we find the button click it
                btn.click();
                event.keyCode = 0
            }
        }
   }
</SCRIPT>
    <script src="FrontEnd/CustomerLogin/js/index.js"></script>

</body>
</html>
