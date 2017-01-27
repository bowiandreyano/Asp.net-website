<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="FrontEnd_CustomerLogin_Order" %>

<!DOCTYPE html>
<html>
<title>Home</title>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
body, h1,h2,h3,h4,h5,h6 {font-family: "Montserrat", sans-serif}
.w3-row-padding img {margin-bottom: 12px}
/* Set the width of the sidenav to 120px */
.w3-sidenav {width: 120px;background: #222;}
/* Add a left margin to the "page content" that matches the width of the sidenav (120px) */
#main {margin-left: 120px}
/* Remove margins from "page content" on small screens */
@media only screen and (max-width: 600px) {#main {margin-left: 0}}
</style>
<body class="w3-black">

<!-- Icon Bar (Sidenav - hidden on small screens) -->
<nav class="w3-sidenav w3-center w3-small w3-hide-small">
  <!-- Avatar image in top left corner -->
  
  <a class="w3-padding-large w3-black" href="#">
    <i class="fa fa-home w3-xxlarge"></i>
    <p>HOME</p>
  </a>
  <a class="w3-padding-large w3-hover-black" href="#about">
    <i class="fa fa-book w3-xxlarge"></i>
    <p>TUTORIAL</p>
  </a>
  <a class="w3-padding-large w3-hover-black" href="#hisorder">
    <i class="fa fa-history w3-xxlarge"></i>
    <p>HISTORY Order</p>
  </a>
  <a class="w3-padding-large w3-hover-black" href="#order">
    <i class="fa fa-envelope w3-xxlarge"></i>
    <p>ORDER</p>
  </a>
  <a class="w3-padding-large w3-hover-black" href="logout.aspx">
    <i class="fa fa-user-circle-o w3-xxlarge"></i>
    <p>LOGOUT</p>
  </a>
</nav>

<!-- Navbar on small screens (Hidden on medium and large screens) -->
<div class="w3-top w3-hide-large w3-hide-medium" id="myNavbar">
  <ul class="w3-navbar w3-black w3-opacity w3-hover-opacity-off w3-center w3-small">
    <li class="w3-left" style="width:25% !important"><a href="#">HOME</a></li>
    <li class="w3-left" style="width:25% !important"><a href="#about">TUTORIAL ORDER</a></li>
      <li class="w3-left" style="width:25% !important"><a href="#hisorder">HISTORY ORDER</a></li>
    <li class="w3-left" style="width:25% !important"><a href="#order">ORDER</a></li>
  </ul>
</div>

<!-- Page Content -->
<div class="w3-padding-large" id="main">
  <!-- Header/Home -->
  <header class="w3-container w3-padding-32 w3-center w3-black" id="home">
    <h1 class="w3-jumbo"><span class="w3-hide-small">Hello</span> <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h1>
    <p>Welcome to your dashboard, you can make an order.</p>
  </header>

  <!-- About Section -->
  <div class="w3-content w3-justify w3-text-grey w3-padding-64" id="about">
    <h2 class="w3-text-light-grey w3-jumbo">Tutorial</h2>
    <hr style="width:200px" class="w3-opacity">
      <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
      <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </div>

    <!-- Order Section -->
<form runat="server">
  <div class="w3-content w3-justify w3-text-grey w3-padding-64" id="hisorder">
    <h2 class="w3-text-light-grey w3-jumbo">History Order</h2>
      <asp:TextBox ID="TextBox7" runat="server" placeholder="Type your ID Order Please">
      </asp:TextBox><asp:Button ID="Button2" runat="server" Text="SEARCH" OnClick="Button2_Click" />
      <label>Note: You can grab your ID ORDER from your order below</label>
    <hr style="width:200px" class="w3-opacity">
      <table cellpadding="10" border="1" cellspacing="0" class="w3-table-all w3-centered w3-responsive">
        <tr class="w3-red">
            <td>ID</td>
            <td>Tittle</td>
            <td>username</td>
            <td>Type</td>
            <td>Description</td>
            <td>Company</td>
            <td>Email</td>
            <td>Status</td>
        </tr>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
          <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
    </table>
   </div>

<%--    <button class="w3-btn w3-light-grey w3-padding-large w3-section w3-hover-grey">
      <i class="fa fa-download"></i> Download Resume
    </button>--%>
    
    <!-- Grid for pricing tables -->
    <%--<h3 class="w3-padding-16 w3-text-light-grey">My Price</h3>
    <div class="w3-row-padding" style="margin:0 -16px">
      <div class="w3-half w3-margin-bottom">
        <ul class="w3-ul w3-white w3-center w3-opacity w3-hover-opacity-off">
          <li class="w3-dark-grey w3-xlarge w3-padding-32">Basic</li>
          <li class="w3-padding-16">Web Design</li>
          <li class="w3-padding-16">Photography</li>
          <li class="w3-padding-16">5GB Storage</li>
          <li class="w3-padding-16">Mail Support</li>
          <li class="w3-padding-16">
            <h2>$ 10</h2>
            <span class="w3-opacity">per month</span>
          </li>
          <li class="w3-light-grey w3-padding-24">
            <button class="w3-btn w3-white w3-padding-large w3-hover-black">Sign Up</button>
          </li>
        </ul>
      </div>

      <div class="w3-half">
        <ul class="w3-ul w3-white w3-center w3-opacity w3-hover-opacity-off">
          <li class="w3-dark-grey w3-xlarge w3-padding-32">Pro</li>
          <li class="w3-padding-16">Web Design</li>
          <li class="w3-padding-16">Photography</li>
          <li class="w3-padding-16">50GB Storage</li>
          <li class="w3-padding-16">Endless Support</li>
          <li class="w3-padding-16">
            <h2>$ 25</h2>
            <span class="w3-opacity">per month</span>
          </li>
          <li class="w3-light-grey w3-padding-24">
            <button class="w3-btn w3-white w3-padding-large w3-hover-black">Sign Up</button>
          </li>
        </ul>
      </div>
    <!-- End Grid/Pricing tables -->
    </div>--%>
    
    <%--<!-- Testimonials -->
    <h3 class="w3-padding-24 w3-text-light-grey">My Reputation</h3>  
    <img src="/w3images/bandmember.jpg" alt="Avatar" class="w3-left w3-circle w3-margin-right" style="width:80px">
    <p><span class="w3-large w3-margin-right">Chris Fox.</span> CEO at Mighty Schools.</p>
    <p>Jane Doe saved us from a web disaster.</p><br>
    
    <img src="/w3images/avatar_g2.jpg" alt="Avatar" class="w3-left w3-circle w3-margin-right" style="width:80px">
    <p><span class="w3-large w3-margin-right">Rebecca Flex.</span> CEO at Company.</p>
    <p>No one is better than Jane Doe.</p>
  <!-- End About Section -->
  </div>--%>
  
  <!-- Portfolio Section -->
<%--  <div class="w3-padding-64 w3-content" id="photos">
    <h2 class="w3-text-light-grey">My Photos</h2>
    <hr style="width:200px" class="w3-opacity">

    <!-- Grid for photos -->
    <div class="w3-row-padding" style="margin:0 -16px">
      <div class="w3-half">
        <img src="/w3images/wedding.jpg" style="width:100%">
        <img src="/w3images/rocks.jpg" style="width:100%">
        <img src="/w3images/sailboat.jpg" style="width:100%">
      </div>

      <div class="w3-half">
        <img src="/w3images/underwater.jpg" style="width:100%">
        <img src="/w3images/chef.jpg" style="width:100%">
        <img src="/w3images/wedding.jpg" style="width:100%">
        <img src="/w3images/p6.jpg" style="width:100%">
      </div>
    <!-- End photo grid -->
    </div>
  <!-- End Portfolio Section -->
  </div>--%>

  <!-- Orders Section -->
  <div class="w3-padding-64 w3-content w3-text-grey" id="order">
    <h2 class="w3-text-light-grey">Contact Me</h2>
    <hr style="width:200px" class="w3-opacity">

    <div class="w3-section">
      <p><i class="fa fa-map-marker fa-fw w3-text-white w3-xxlarge w3-margin-right"></i> Depok, INDONESIA</p>
      <p><i class="fa fa-phone fa-fw w3-text-white w3-xxlarge w3-margin-right"></i> Phone: +62 829182192</p>
      <p><i class="fa fa-envelope fa-fw w3-text-white w3-xxlarge w3-margin-right"> </i> Email: slideshifucs@ss.com</p>
    </div><br>
    <p>Lets get in touch. Send me an order:</p>

 <%--    <form runat="server">--%>
      <p><asp:TextBox ID="TextBox1" runat="server" CssClass="w3-form" Width="100%" Enabled="False"></asp:TextBox></p>
      <p><asp:TextBox ID="TextBox2" runat="server" placeholder="Project Tittle" CssClass="w3-form" Width="100%"></asp:TextBox></p>
      <p>Name : <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></p>
      <p><asp:DropDownList ID="DropDownList1" runat="server" CssClass="w3-dropdown-hover" placeholder="Click me" Width="100%" Height="40px"></asp:DropDownList></p>
      <p><asp:TextBox ID="TextBox3" runat="server" placeholder="Please elaborate any instructions, needs and objectives for this project" CssClass="w3-form" Width="100%"></asp:TextBox></p>
      <p><asp:TextBox ID="TextBox4" runat="server" placeholder="Company/Organization" CssClass="w3-form" Width="100%"></asp:TextBox></p>
      <p><asp:TextBox ID="TextBox5" runat="server" placeholder="Email" CssClass="w3-form" Width="100%"></asp:TextBox></p>
      <%--<p><asp:TextBox ID="TextBox6" runat="server" placeholder="Status" CssClass="w3-form" Width="100%"></asp:TextBox></p>--%>
      <p>
          <asp:Button ID="Button1" Text="Submit" runat="server" CssClass="w3-light-grey w3-padding-large" OnClick="Button1_Click" />
      </p>
    </form>
  <!-- End Contact Section -->
  </div>
  
    <!-- Footer -->
  <footer class="w3-content w3-padding-64 w3-text-grey w3-xlarge">
    <i class="fa fa-facebook-official w3-hover-text-indigo"></i>
    <i class="fa fa-instagram w3-hover-text-purple"></i>
    <i class="fa fa-snapchat w3-hover-text-yellow"></i>
    <i class="fa fa-pinterest-p w3-hover-text-red"></i>
    <i class="fa fa-twitter w3-hover-text-light-blue"></i>
    <i class="fa fa-linkedin w3-hover-text-indigo"></i>
    <p class="w3-medium">Powered by <a href="http://www.w3schools.com/w3css/default.asp" target="_blank" class="w3-hover-text-green">SlideShifu</a></p>
  <!-- End footer -->
  </footer>

<!-- END PAGE CONTENT -->
</div>

</body>
</html>

