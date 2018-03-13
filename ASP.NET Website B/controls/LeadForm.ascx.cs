﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample.controls
{
 public partial class LeadForm : System.Web.UI.UserControl
 {
  protected FormClass f = new FormClass();

  protected void Page_Load(object sender, EventArgs e)
  {
   f.populateStates(ddlStates);
   FormProperties.strSource = "0";
   FormProperties.strAppPath = Request.PhysicalApplicationPath;
   FormProperties.strIsTest = "0";
   FormProperties.strCampaignID = "1202";
   if (Request.QueryString["Source"] != null)
   {
    FormProperties.strSource = Request.QueryString["Source"].ToString();
   }
   else
   {
    FormProperties.strSource = "0";
   }
   if (Request.QueryString["test"] != null)
   {
    FormProperties.strIsTest = Request.QueryString["test"].ToString();
   }
   if (Request.UrlReferrer != null)
   {
    FormProperties.strReferralURL = Request.UrlReferrer.ToString();
   }
   if (Request.QueryString["Campaign"] != null)
   {
    FormProperties.strCampaign = Request.QueryString["Campaign"].ToString();
   }
   if (Request.QueryString["Kwd"] != null)
   {
    FormProperties.strKwd = Request.QueryString["Kwd"].ToString();
   }
   FormProperties.strIpAddress = Request.UserHostAddress.ToString();
  }

  protected void btnSubmit_Click(object sender, EventArgs e)
  {
   string useragent = string.Empty;
   string browser = string.Empty;
   useragent = Request.UserAgent;
   browser = Request.Browser.Browser;
   if (Page.IsValid)
   {
    int response = f.sendLead(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtStreet.Text, txtCity.Text, ddlStates.SelectedValue, txtZipCode.Text, txtPhone.Text, ddlBestTimetoCall.SelectedValue, ddlNumWindows.SelectedValue, tcpa.InnerText, useragent, browser);
    if (response == 0)
    {
     Response.Redirect("ThankYou.aspx");
    }
    else
    {
     Response.Redirect("ThankYouNA.aspx");
    }
   }
  }
 }
}