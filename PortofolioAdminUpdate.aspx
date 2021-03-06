﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PortofolioAdminUpdate.aspx.cs" Inherits="PortofolioAdminUpdate" %>

<!DOCTYPE html>
<html>
<title>Update Portofolio</title>
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
  <span class="w3-right">SlideShifu</span>
</div>

<!-- Sidenav/menu -->
<nav class="w3-sidenav w3-collapse w3-white w3-animate-left" style="z-index:3;width:300px;" id="mySidenav"><br>
  <div class="w3-container w3-row">
    <div class="w3-col s4">
    </div>
    <div class="w3-col s8">
      <span>Welcome, <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> </span><br>
      <a href="orders.aspx" class="w3-hover-none w3-hover-text-red w3-show-inline-block"><i class="fa fa-envelope"></i></a>
      <a href="admin.aspx" class="w3-hover-none w3-hover-text-green w3-show-inline-block"><i class="fa fa-user"></i></a>
      <a href="logout.aspx" class="w3-hover-none w3-hover-text-blue w3-show-inline-block"><i class="fa fa-cog"></i></a>
    </div>
  </div>
  <hr>
  <div class="w3-container">
    <h5>Dashboard</h5>
  </div>
  <a href="#" class="w3-padding-16 w3-hide-large w3-dark-grey w3-hover-black" onclick="w3_close()" title="close menu"><i class="fa fa-remove fa-fw"></i>  Close Menu</a>
  <a href="overview.aspx" class="w3-padding"><i class="fa fa-users fa-fw"></i>  Overview</a>
  <a href="orders.aspx" class="w3-padding"><i class="fa fa-eye fa-fw"></i>  Orders</a>
  <a href="portofolio.aspx" class="w3-padding w3-blue"><i class="fa fa-bullseye fa-fw"></i>  Portofolio</a>
  <a href="Tutorialorders.aspx" class="w3-padding"><i class="fa fa-diamond fa-fw"></i>  Tutorial Orders</a>
  <a href="Customer.aspx" class="w3-padding"><i class="fa fa-bell fa-fw"></i>  Customer</a>
  <a href="Admin.aspx" class="w3-padding"><i class="fa fa-users fa-fw"></i>  Admin</a>
  <a href="logout.aspx" class="w3-padding"><i class="fa fa-cog fa-fw"></i>  Logout</a><br><br>
</nav>
  
<!-- Overlay effect when opening sidenav on small screens -->
<div class="w3-overlay w3-hide-large w3-animate-opacity" onclick="w3_close()" style="cursor:pointer" title="close side menu" id="myOverlay"></div>

<!-- !PAGE CONTENT! -->
<div class="w3-main" style="margin-left:300px;margin-top:43px;">

  <!-- Header -->
  <header class="w3-container" style="padding-top:22px">
    <h5><b><i class="fa fa-dashboard"></i> My Dashboard</b></h5>
  </header>

  <div class="w3-container" runat="server">
      <h1>Insert Portofolio Data</h1>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="10">
            <tr>
                <td>Port ID</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="w3-input w3-border"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Port Name</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="w3-input w3-border"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Port Description</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="w3-input w3-border"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Port Image</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="w3-btn"/>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Save" CssClass="w3-btn" OnClick="Button1_Click"/>
                </td>
            </tr>
        </table>
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
