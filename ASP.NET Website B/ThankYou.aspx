﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="Sample.ThankYou" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <meta name="viewport" content="width=device-width, initial-scale=1.0">
 <meta name="SKYPE_TOOLBAR" content="SKYPE_TOOLBAR_PARSER_COMPATIBLE" />
 <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
 <title></title>
 <link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
 <link href="css/styles.min.css" rel="stylesheet" type="text/css" />
 <link href="scripts/lightbox/jquery.fancybox.css" rel="stylesheet" type="text/css" />
 <script src="scripts/jquery-1.11.3.min.js" type="text/javascript"></script>
 <script src="scripts/lightbox/jquery.fancybox.pack.js" type="text/javascript"></script>
 
</head>
<body>
 <div class="container ty">
  <div class="header">
   <div id="logo">
    <img src="images/" />
   </div>
   <div id="slogan">
    <span>Beauty you can see. Value you can appreciate.</span>
   </div>
   <div id="phone">
    <img src="images/phone-icon.png" />
    <span id="phoneNumber" runat="server"></span>
   </div>
  </div>
  <div class="content">
   <div class="line">
   </div>
   <h1>
    Your Request Was Successful</h1>
   <p>
    A Sample consultant will contact you for your free consultation.
   </p>
   <p>
    <img src="images/Sample-windows-ty.png" alt="windows" />
   </p>
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
