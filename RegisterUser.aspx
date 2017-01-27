﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterUser.aspx.cs" Inherits="Admindasboard" %>

<!DOCTYPE html>
<html>
<title>W3.CSS Template</title>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
html,body,h1,h2,h3,h4,h5 {font-family: "Raleway", sans-serif}
</style>
<body class="w3-light-grey">

<!-- Top container -->
<div class="w3-container w3-top w3-black w3-large w3-padding" style="z-index:4">
  <button class="w3-btn w3-hide-large w3-padding-0 w3-hover-text-grey" onclick="w3_open();"><i class="fa fa-bars"></i>  Menu</button>
  <span class="w3-right">Logo</span>
</div>

<!-- Sidenav/menu -->
<nav class="w3-sidenav w3-collapse w3-white w3-animate-left" style="z-index:3;width:300px;" id="mySidenav"><br>
  <div class="w3-container w3-row">
    <div class="w3-col s4">
    </div>
    <div class="w3-col s8">
      <a href="#" class="w3-hover-none w3-hover-text-red w3-show-inline-block"><i class="fa fa-envelope"></i></a>
      <a href="#" class="w3-hover-none w3-hover-text-green w3-show-inline-block"><i class="fa fa-user"></i></a>
      <a href="#" class="w3-hover-none w3-hover-text-blue w3-show-inline-block"><i class="fa fa-cog"></i></a>
    </div>
  </div>
  <hr>
  <div class="w3-container">
    <h5>Dashboard</h5>
  </div>
  <a href="#" class="w3-padding-16 w3-hide-large w3-dark-grey w3-hover-black" onclick="w3_close()" title="close menu"><i class="fa fa-remove fa-fw"></i>  Close Menu</a>
  <a href="#" class="w3-padding w3-blue"><i class="fa fa-users fa-fw"></i>  Overview</a>
  <a href="#" class="w3-padding"><i class="fa fa-eye fa-fw"></i>  Views</a>
  <a href="#" class="w3-padding"><i class="fa fa-users fa-fw"></i>  Traffic</a>
  <a href="#" class="w3-padding"><i class="fa fa-bullseye fa-fw"></i>  Geo</a>
  <a href="#" class="w3-padding"><i class="fa fa-diamond fa-fw"></i>  Orders</a>
  <a href="#" class="w3-padding"><i class="fa fa-bell fa-fw"></i>  News</a>
  <a href="#" class="w3-padding"><i class="fa fa-bank fa-fw"></i>  General</a>
  <a href="#" class="w3-padding"><i class="fa fa-history fa-fw"></i>  History</a>
  <a href="#" class="w3-padding"><i class="fa fa-cog fa-fw"></i>  Settings</a><br><br>
</nav>


<!-- Overlay effect when opening sidenav on small screens -->
<div class="w3-overlay w3-hide-large w3-animate-opacity" onclick="w3_close()" style="cursor:pointer" title="close side menu" id="myOverlay"></div>

<!-- !PAGE CONTENT! -->
<div class="w3-main" style="margin-left:300px;margin-top:43px;">

  <!-- Header -->
<div class="w3-container" runat="server">
    <form class="w3-container" action="form.asp" runat="server">
  <h2>Input Form</h2>

  <div class="w3-group">      
      <asp:TextBox ID="TextBox1" runat="server">Username</asp:TextBox>
  </div>

  <div class="w3-group">      
      <asp:TextBox ID="TextBox2" runat="server">Password</asp:TextBox>
  </div>  

  <div class="w3-group">      
    <asp:TextBox ID="TextBox3" runat="server">Address</asp:TextBox>
  </div>
  
  <div class="w3-group">      
    <asp:TextBox ID="TextBox4" runat="server">Email</asp:TextBox>
  </div>
        
  <div class="w3-group">      
    <asp:TextBox ID="TextBox5" runat="server">Telephone</asp:TextBox>
  </div>
    
  <div class="w3-group">      
    <asp:TextBox ID="TextBox6" runat="server">Mobile Phone</asp:TextBox>
  </div>

  <div class="w3-group">      
    <button class="w3-btn">Register</button>
  </div>
</form>


</div>


  <!-- Footer -->
  <footer class="w3-container w3-padding-16 w3-light-grey">
    <h4>FOOTER</h4>
    <p>Powered by <a href="http://www.w3schools.com/w3css/default.asp" target="_blank">w3.css</a></p>
  </footer>

  <!-- End page content -->
</div>

<script>
// Get the Sidenav
var mySidenav = document.getElementById("mySidenav");

// Get the DIV with overlay effect
var overlayBg = document.getElementById("myOverlay");

// Toggle between showing and hiding the sidenav, and add overlay effect
function w3_open() {
    if (mySidenav.style.display === 'block') {
        mySidenav.style.display = 'none';
        overlayBg.style.display = "none";
    } else {
        mySidenav.style.display = 'block';
        overlayBg.style.display = "block";
    }
}

// Close the sidenav with the close button
function w3_close() {
    mySidenav.style.display = "none";
    overlayBg.style.display = "none";
}
</script>

</body>
</html>
