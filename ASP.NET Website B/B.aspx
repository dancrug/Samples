﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="B.aspx.cs" Inherits="Sample.B" %>

<%@ Register TagPrefix="uc" TagName="LeadForm" Src="~/controls/LeadForm.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta name="viewport" content="width=device-width, initial-scale=1.0">
 <meta name="SKYPE_TOOLBAR" content="SKYPE_TOOLBAR_PARSER_COMPATIBLE" />
 <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
 <title></title>
 <link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
 <link href="css/styles.min.css" rel="stylesheet" type="text/css" />
 <link href="scripts/lightbox/jquery.fancybox.css" rel="stylesheet" type="text/css" />
 <script src="scripts/jquery-1.11.3.min.js" type="text/javascript"></script>
 <script src="scripts/jquery.maskedinput.js" type="text/javascript"></script>
 <script src="scripts/lightbox/jquery.fancybox.pack.js" type="text/javascript"></script>
 <script src="scripts/Functions.js" type="text/javascript"></script>
 <script type="text/javascript">
  jQuery(function ($) {
   $("#LeadForm1_txtPhone").mask("999-999-9999");
  });
  $("#LeadForm1_txtPhone").keydown(function (e) {
   if (e.which == 36) {
    e.preventDefault();
   }
  });
 </script>
 
</head>
<body>
 <div class="container b">
  <div class="header">
   <div id="logo">
    <img src="images/" />
   </div>
   <div id="slogan" runat="server">
    <span>Beauty you can see. Value you can appreciate.</span>
   </div>
   <div id="phone" runat="server">
    <img src="images/phone-icon.png" />
    <span id="phoneNumber" runat="server"></span>
   </div>
   <div class="offer">
    <img src="images/window-offer-b.png" alt="$250 off per window, $700 off per patio door" />
   </div>
  </div>
  <div class="content">
   <div class="line">
   </div>
   <div class="left">
    <img src="images/Sample-windows.png" />
    <p>
     *See full offer details. Conditions may apply.</p>
   </div>
   <div class="right">
    <h1>
     Request a
     <br />
     FREE Consultation</h1>
    <h2>
     Our scheduling department will be in touch with you shortly.</h2>
    <form runat="server">
    <uc:LeadForm ID="LeadForm1" runat="server"></uc:LeadForm>
    </form>
   </div>
  </div>
  <div class="bottom">
   <div id="slideshow">
    <div id="slides">
     <%--<img src="images/2012-home-satisfaction-award.png" />
     <img src="images/2013-energy-star-award.png" />
     <img src="images/2014-home-satisfaction-award.png" />
     <img src="images/2014-super-service-award.png" />
     <img src="images/angies-list-a-rating.png" />
     <img src="images/BBB-accredited-business.png" />
     <img src="images/certified-indoor-advantage-gold.png" />
     <img src="images/certified-master-installer.png" />
     <img src="images/limited-warranty.png" />
     <img src="images/nfrc-certified.png" />
     <img src="images/proud-producer-of-certified-product.png" />--%>
    </div>
   </div>
  </div>
 </div>
 <div class="footer">
  <p>
   ©
   <script type="text/javascript">    document.write(new Date().getFullYear());</script>
   Sample LLC. All rights reserved. <a href=""
    data-fancybox-type="iframe" class="fancybox">Privacy Policy</a> | <a href=""
     data-fancybox-type="iframe" class="fancybox">Terms of Use</a>
  </p>
 </div>
</body>
</html>
