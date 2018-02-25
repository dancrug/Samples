﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Configuration;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mime;
using System.Net;
using System.Security.Cryptography;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Script.Services;

namespace Sample
{
 public class FormClass
 {
  #region populateStates - Populates the states in the form.
  /// <summary>
  /// Populates the states.
  /// </summary>
  /// <param name="ddl">The DDL.</param>
  /// <param name="applicationPath">The application path.</param>
  public void populateStates(DropDownList ddl)
  {
   // Create xml doc.
   XmlDocument xDoc = new XmlDocument();

   try
   {
    // Grab xml document from server.
    xDoc.Load(FormProperties.strAppPath + "/lib/states.xml");
   }
   catch (Exception ex)
   {
    SendError(ex, "Sample Leads: Error populating states", "");
   }
   foreach (XmlNode node in xDoc.GetElementsByTagName("option"))
   {
    // Add the states to the dropdown list states.
    ddl.Items.Add(new ListItem(node.InnerText, node.Attributes["value"].Value));
   }
   ddl.DataValueField = "value";
   ddl.DataTextField = "text";
   ddl.DataBind();
  }
  #endregion

  #region populatePhone - Populates the phone number
  /// <summary>
  /// Populates the phone.
  /// </summary>
  /// <param name="txt">The text.</param>
  public void populatePhone(HtmlGenericControl txt, HttpRequest req)
  {
   // Create xml document.
   XmlDocument xDoc = new XmlDocument();
   try
   {
    // Load xml document on remote server
    xDoc.Load(FormProperties.strAppPath + "/lib/phonenumbers.xml");
    XmlNode n = xDoc.SelectSingleNode("/root/ph[@id=" + FormProperties.strPhone + "]");
    txt.InnerText = n.InnerText;
   }
   catch (Exception ex)
   {
    SendError(ex, "Sample Leads: Error populating phone", req.UrlReferrer.ToString());
   }
  }
  #endregion

  #region getSourceCodeName - Populates the source code
  /// <summary>
  /// Gets the name of the source code.
  /// </summary>
  public void getSourceCodeName()
  {
   // Create xml document.
   XmlDocument xDoc = new XmlDocument();
   try
   {
    // Load xml document on remote server
    xDoc.Load(FormProperties.strAppPath + "/lib/sourcecodes.xml");
    XmlNode n = xDoc.SelectSingleNode("/root/code[@id=" + FormProperties.strSource + "]");
    FormProperties.strSourceName = n.InnerText;
    if (n.Attributes["sourceid"].Value != null)
    {
     FormProperties.strSourceID = n.Attributes["sourceid"].Value;
    }
   }
   catch (Exception ex)
   {
    SendError(ex, "Sample Leads: Error populating source", "");
   }
  }
  #endregion

  #region SendError - Sends an error when form breaks.
  /// <summary>
  /// Sends the error.
  /// </summary>
  /// <param name="Error">The error.</param>
  /// <param name="ErrorHeader">The error header.</param>
  /// <param name="Url">The URL.</param>
  protected void SendError(Exception Error, string ErrorHeader, string Url)
  {
   String Message = Error.Message;
   String URL = Url;
   string ErrorMessage;
   ErrorMessage = "Error Message: " + Message + "<br>";
   ErrorMessage = ErrorMessage + "URL: " + URL + "<br>";
   ErrorMessage = ErrorMessage + "Detail Message: " + Error.InnerException + "<br>";
   try
   {
    MailMessage emailMessage = new MailMessage(ConfigurationManager.AppSettings["ERRORFROMEMAIL"].ToString(), ConfigurationManager.AppSettings["ERRORTOEMAIL"].ToString(), ErrorHeader, ErrorMessage);
    emailMessage.CC.Add(new MailAddress(""));
    emailMessage.IsBodyHtml = true;
    emailMessage.BodyEncoding = Encoding.UTF8;
    emailMessage.Priority = MailPriority.High;
    //Send the message.
    SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SMTPCLIENT"].ToString());
    client.Send(emailMessage);
   }
   catch (Exception)
   {
    saveErrorLog(ErrorMessage);
   }
  }
  #endregion

  #region saveErrorLog
  /// <summary>
  /// Saves the error log.
  /// </summary>
  /// <param name="error">The error.</param>
  protected void saveErrorLog(string error)
  {
   string filePath = string.Empty;
   string postingInformation = string.Empty;
   string applicationPath = string.Empty;

   applicationPath = AppDomain.CurrentDomain.BaseDirectory;
   postingInformation = "Begin Report: " + DateTime.Now + "\n " + error + " \nEnd Report\n";
   filePath = applicationPath + "/logs/errorlog_" + DateTime.Today.ToString("MM-dd-yyyy") + ".txt";
   StreamWriter w = null;
   try
   {
    if (!File.Exists(filePath))
    {
     using (w = File.CreateText(filePath))
     {
      w.Write(postingInformation);
     }
    }
    else
    {
     using (w = File.AppendText(filePath))
     {
      w.Write(postingInformation);
     }
    }
   }
   catch (Exception ex)
   {
    SendError(ex, "Sample Leads: Error Saving Log", "");
   }
   finally
   {
    w.Dispose();
   }
  }
  #endregion

  #region savePostingLog
  /// <summary>
  /// Saves the posting log.
  /// </summary>
  /// <param name="error">The error.</param>
  protected void savePostingLog(string postdata)
  {
   string filePath = string.Empty;
   string postingInformation = string.Empty;
   string applicationPath = string.Empty;

   applicationPath = AppDomain.CurrentDomain.BaseDirectory;
   postingInformation = "Begin Report: " + DateTime.Now + "\n " + postdata + " \nEnd Report\n";
   filePath = applicationPath + "/logs/postinglog_" + DateTime.Today.ToString("MM-dd-yyyy") + ".txt";
   StreamWriter w = null;
   try
   {
    if (!File.Exists(filePath))
    {
     using (w = File.CreateText(filePath))
     {
      w.Write(postingInformation);
     }
    }
    else
    {
     using (w = File.AppendText(filePath))
     {
      w.Write(postingInformation);
     }
    }
   }
   catch (Exception ex)
   {
    SendError(ex, "Sample Leads: Error Saving Log", "");
   }
   finally
   {
    if (w != null)
    {
     w.Dispose();
    }
   }
  }
  #endregion

  #region saveResponseLog
  /// <summary>
  /// Saves the response log.
  /// </summary>
  /// <param name="error">The error.</param>
  protected void saveResponseLog(string response)
  {
   string filePath = string.Empty;
   string postingInformation = string.Empty;
   string applicationPath = string.Empty;

   applicationPath = AppDomain.CurrentDomain.BaseDirectory;
   postingInformation = "Begin Report: " + DateTime.Now + "\n " + response + " \nEnd Report\n";
   filePath = applicationPath + "/logs/responselog_" + DateTime.Today.ToString("MM-dd-yyyy") + ".txt";
   StreamWriter w = null;
   try
   {
    if (!File.Exists(filePath))
    {
     using (w = File.CreateText(filePath))
     {
      w.Write(postingInformation);
     }
    }
    else
    {
     using (w = File.AppendText(filePath))
     {
      w.Write(postingInformation);
     }
    }
   }
   catch (Exception ex)
   {
    SendError(ex, "Sample Leads: Error Saving Log", "");
   }
   finally
   {
    w.Dispose();
   }
  }
  #endregion

  #region saveOOMPostingLog
  /// <summary>
  /// Saves the posting log.
  /// </summary>
  /// <param name="error">The error.</param>
  protected void saveOOMPostingLog(string postdata)
  {
   string filePath = string.Empty;
   string postingInformation = string.Empty;
   string applicationPath = string.Empty;

   applicationPath = AppDomain.CurrentDomain.BaseDirectory;
   postingInformation = "Begin Report: " + DateTime.Now + "\n " + postdata + " \nEnd Report\n";
   filePath = applicationPath + "/logs/postingoomlog_" + DateTime.Today.ToString("MM-dd-yyyy") + ".txt";
   StreamWriter w = null;
   try
   {
    if (!File.Exists(filePath))
    {
     using (w = File.CreateText(filePath))
     {
      w.Write(postingInformation);
     }
    }
    else
    {
     using (w = File.AppendText(filePath))
     {
      w.Write(postingInformation);
     }
    }
   }
   catch (Exception ex)
   {
    SendError(ex, "Sample Leads: Error Saving Log", "");
   }
   finally
   {
    w.Dispose();
   }
  }
  #endregion

  #region sendLead - Sends lead to client via email.
  /// <summary>
  /// Sends the lead.
  /// </summary>
  /// <param name="firstname">The firstname.</param>
  /// <param name="lastname">The lastname.</param>
  /// <param name="email">The email.</param>
  /// <param name="address">The address.</param>
  /// <param name="city">The city.</param>
  /// <param name="state">The state.</param>
  /// <param name="zipcode">The zipcode.</param>
  /// <param name="phone">The phone.</param>
  /// <param name="besttimetocall">The besttimetocall.</param>
  /// <param name="numberofwindows">The numberofwindows.</param>
  /// <param name="sourcecode">The sourcecode.</param>
  public int sendLead(string firstname, string lastname, string email, string address, string city, string state, string zipcode, string phone, string besttimetocall, string numberofwindows, string tcpaconsentlanguage, string useragent = "", string browser = "", bool repost = false)
  {
   var QAEmail = string.Empty;

   FormProperties.strFirstName = firstname;
   FormProperties.strLastName = lastname;
   FormProperties.strEmail = email;
   FormProperties.strStreet = address;
   FormProperties.strCity = city;
   FormProperties.strState = state;
   FormProperties.strZipCode = zipcode;
   FormProperties.strPhoneNumber = phone;
   FormProperties.strBestTimetoCall = besttimetocall;
   FormProperties.strNumberofWindows = numberofwindows;
   bool outofmarket = false;
   string[] result = new string[4];
   int Sampleleadid = 0;
   List<LeadBid> highestBidder = new List<LeadBid>();
   getSourceCodeName();
   getEmailAddressforLead();

   QAEmail = "";

   if (FormProperties.strToEmail == string.Empty || FormProperties.strToEmail == null)
   {
    outofmarket = true;
   }
   else
   {
    outofmarket = false;
   }

   if (repost == false)
   {
    try
    {
     bool isTest = returnBoolValue(FormProperties.strIsTest);
     Sampleleadid = saveLeadtoDB(FormProperties.strSourceName, FormProperties.strCampaign, string.Empty, FormProperties.strkwd, FormProperties.strIpAddress, firstname, lastname, email, address, city, state, phone, zipcode, besttimetocall, numberofwindows, outofmarket, useragent, FormProperties.strReferralURL, browser, isTest);
    }
    catch (Exception ex)
    {
     SendError(ex, "Sample Error saving lead", "");
    }
   }
   if (FormProperties.strIsTest == "1")
   {
    if (outofmarket)
    {
     FormProperties.strToEmail = QAEmail;
     FormProperties.strIpAddress = generateRandomIP();
     sendLeadEmail();
     // Ping QuoteMe
     result = pingQuoteMeOOMLead(email, "ECEM", zipcode, FormProperties.strIpAddress, numberofwindows, tcpaconsentlanguage, FormProperties.strIsTest, Sampleleadid);
     saveAPIResponse(Sampleleadid, result[1], result[2], result[3], result[0], "Ping");
     //saveResponseLog("QuoteMe Ping Response: " + result[0] + ";" + result[1] + ";" + result[2] + ";" + result[3]);
     if ((!result[1].Contains("FAIL")) && (!result[1].Contains("here")))
     {
      highestBidder.Add(new LeadBid { LeadAPIID = result[0], LeadId = result[2], LeadPrice = Convert.ToDouble(result[3]) });
     }
     // Ping Modernize
     result = pingModernizeOOMLead("Aff899", zipcode, FormProperties.strIsTest, Sampleleadid);
     saveAPIResponse(Sampleleadid, result[3], result[1], result[2], result[0], "Ping");
     //saveResponseLog("Modernize Ping Response: " + result[0] + ";" + result[1] + ";" + result[2] + ";" + result[3]);
     if (result[3] == "Matched")
     {
      highestBidder.Add(new LeadBid { LeadAPIID = result[0], LeadId = result[1], LeadPrice = Convert.ToDouble(result[2]) });
     }
     // Ping Remodeling
     result = pingRemodelingOOMLead(zipcode, numberofwindows, Sampleleadid);
     saveAPIResponse(Sampleleadid, result[3], result[1], result[2], result[0], "Ping");
     //saveResponseLog("Remodeling Ping Response: " + result[0] + ";" + result[1] + ";" + result[2] + ";" + result[3]);
     if (result[3] == "accepted")
     {
      highestBidder.Add(new LeadBid { LeadAPIID = result[0], LeadId = result[1], LeadPrice = Convert.ToDouble(result[2]) });
     }
     if (highestBidder.Count > 0)
     {
      highestBidder = highestBidder.OrderByDescending(LeadBid => LeadBid.LeadPrice).ToList();
      sendOOMLead(Sampleleadid, highestBidder, email, zipcode, "Yes", numberofwindows, firstname, lastname, address, city, state, tcpaconsentlanguage, phone, besttimetocall);
     }
     return 1;
    }
    else
    {
     FormProperties.strToEmail = QAEmail;
     sendLeadEmail();
     return 0;
    }
   }
   else
   {
    if (outofmarket)
    {
     // ** Check for lead cap for eCrux, if it's under ping/post. otherwise skip **
     if (isAPILeadCap("0"))
     {
      result = pingQuoteMeOOMLead(email, "ECEM", zipcode, FormProperties.strIpAddress, numberofwindows, tcpaconsentlanguage, FormProperties.strIsTest, Sampleleadid);
      saveAPIResponse(Sampleleadid, result[1], result[2], result[3], result[0], "Ping");
      if ((!result[1].Contains("FAIL")) && (!result[1].Contains("here")))
      {
       highestBidder.Add(new LeadBid { LeadAPIID = result[0], LeadId = result[2], LeadPrice = Convert.ToDouble(result[3]) });
      }
     }
     //** Ping Modernize for all leads, but only post if under the lead cap.
     result = pingModernizeOOMLead("Aff899", zipcode, FormProperties.strIsTest, Sampleleadid);
     saveAPIResponse(Sampleleadid, result[3], result[1], result[2], result[0], "Ping");
     if (result[3] == "Matched")
     {
      highestBidder.Add(new LeadBid { LeadAPIID = result[0], LeadId = result[1], LeadPrice = Convert.ToDouble(result[2]) });
     }
     //** Ping Remodeling
     result = pingRemodelingOOMLead(zipcode, numberofwindows, Sampleleadid);
     saveAPIResponse(Sampleleadid, result[3], result[1], result[2], result[0], "Ping");
     //saveResponseLog("Remodeling Ping Response: " + result[0] + ";" + result[1] + ";" + result[2] + ";" + result[3]);
     if (result[3] == "accepted")
     {
      highestBidder.Add(new LeadBid { LeadAPIID = result[0], LeadId = result[1], LeadPrice = Convert.ToDouble(result[2]) });
     }
     if (highestBidder.Count > 0)
     {
      highestBidder = highestBidder.OrderByDescending(LeadBid => LeadBid.LeadPrice).ToList();
      sendOOMLead(Sampleleadid, highestBidder, email, zipcode, "Yes", numberofwindows, firstname, lastname, address, city, state, tcpaconsentlanguage, phone, besttimetocall);
     }
     return 1;
    }
    else
    {
     sendLeadEmail();
     return 0;
    }
   }
  }
  #endregion

  #region pingQuoteMeOOMLead - Pings oom leads for best price.
  /// <summary>
  /// Sends the oom lead.
  /// </summary>
  /// <param name="email">The email.</param>
  /// <param name="sourceid">The sourceid.</param>
  /// <param name="zipcode">The zipcode.</param>
  /// <param name="ipaddress">The ipaddress.</param>
  /// <param name="numberofwindows">The numberofwindows.</param>
  /// <param name="firstname">The firstname.</param>
  /// <param name="lastname">The lastname.</param>
  /// <param name="phone">The phone.</param>
  /// <param name="address">The address.</param>
  /// <param name="city">The city.</param>
  /// <param name="state">The state.</param>
  /// source is ECEM
  protected string[] pingQuoteMeOOMLead(string email, string sourceid, string zipcode, string ipaddress, string numberofwindows, string tcpaconsentlang, string istest, int Sampleleadid)
  {
   string PostUrl = ConfigurationManager.AppSettings["QuoteMeAPIURLPing"].ToString();
   string[] result = new string[4];
   string[] responses = new string[4] { "", "", "", "" };
   string response = string.Empty;
   try
   {
    using (WebClient client = new WebClient())
    {
     var reqparm = new System.Collections.Specialized.NameValueCollection();
     reqparm.Add("SRC", sourceid);
     reqparm.Add("zip", zipcode);
     reqparm.Add("Home_Improvement_Product", "Windows");
     reqparm.Add("subcat", "Windows - Window Installation");
     reqparm.Add("ipAddress", ipaddress);
     reqparm.Add("TCPAConsent", "Yes");
     reqparm.Add("TCPAConsentLanguage", tcpaconsentlang);
     reqparm.Add("answer1", numberofwindows);
     reqparm.Add("Test_Lead", istest);
     byte[] responsebytes = client.UploadValues(PostUrl, "POST", reqparm);
     response = Encoding.UTF8.GetString(responsebytes);
     saveResponseLog("Quote Me Ping: (" + Sampleleadid.ToString() + ") " + response);
     responses = response.Split('|');
     // API ID
     result[0] = "0";
     // API LeadID
     result[1] = responses[0];
     if (responses.Length > 1)
     {
      // API Lead Price
      result[2] = responses[1];
     }
     if (responses.Length > 2)
     {
      // API Response
      result[3] = responses[2];
     }
     return result;
    }
   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());
    result[0] = "0";
    result[2] = "rejected";
    return result;
   }
  }
  #endregion

  #region postQuoteMeOOMLead - Send leads to best price
  /// <summary>
  /// Posts the quote me oom lead.
  /// </summary>
  /// <param name="email">The email.</param>
  /// <param name="leadid">The leadid.</param>
  /// <param name="sourceid">The sourceid.</param>
  /// <param name="zipcode">The zipcode.</param>
  /// <param name="ipaddress">The ipaddress.</param>
  /// <param name="tcpaconsentlanguage">The tcpaconsentlanguage.</param>
  /// <param name="numberofwindows">The numberofwindows.</param>
  /// <param name="firstname">The firstname.</param>
  /// <param name="lastname">The lastname.</param>
  /// <param name="phone">The phone.</param>
  /// <param name="address">The address.</param>
  /// <param name="city">The city.</param>
  /// <param name="state">The state.</param>
  /// <param name="homeowner">The homeowner.</param>
  /// <param name="timeframe">The timeframe.</param>
  /// <param name="homeimprovementproduct">The homeimprovementproduct.</param>
  /// <param name="subcat">The subcat.</param>
  /// <param name="tcpaconsent">The tcpaconsent.</param>
  /// <param name="istest">The istest.</param>
  protected bool postQuoteMeOOMLead(int Sampleleadid, string email, LeadBid highestBidder, string sourceid, string zipcode, string tcpaconsentlanguage, string numberofwindows, string firstname, string lastname, string phone, string address, string city, string state, string istest, string besttime, string homeowner = "Yes", string timeframe = "Immediately", string homeimprovementproduct = "Windows", string subcat = "Windows - Window Installation", string tcpaconsent = "Yes")
  {
   string PostUrl = ConfigurationManager.AppSettings["QuoteMeAPIURLPost"].ToString();
   string postData = string.Empty;
   try
   {
    /* Optimizations */
    ServicePointManager.Expect100Continue = false;
    ServicePointManager.DefaultConnectionLimit = 5;

    // Create a request using a URL that can receive a post. 
    WebRequest request = WebRequest.Create(PostUrl);
    // Set the Method property of the request to POST.
    request.Method = "POST";
    request.Proxy = null;

    // Create POST data and convert it to a byte array.
    postData = "email=" + email + "&leadid=" + highestBidder.LeadId + "&SRC=" + sourceid + "&zip=" + zipcode + "&Home_Improvement_Product=" + homeimprovementproduct + "&subcat=" + subcat + "&ipAddress=" + FormProperties.strIpAddress + "&TCPAConsent=" + tcpaconsent + "&TCPAConsentLanguage=" + tcpaconsentlanguage + "&answer1=" + numberofwindows + "&firstname=" + firstname + "&lastname=" + lastname + "&phone=" + phone + "&address=" + address + "&city=" + city + "&state=" + state + "&besttime=" + besttime + "&timeframe=" + timeframe + "&homeowner=" + homeowner + "&Test_Lead=" + istest;

    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    // Set the ContentType property of the WebRequest.
    request.ContentType = "application/x-www-form-urlencoded";
    // Set the ContentLength property of the WebRequest.
    request.ContentLength = byteArray.Length;
    // Get the request stream.
    Stream dataStream = request.GetRequestStream();
    // Write the data to the request stream.
    dataStream.Write(byteArray, 0, byteArray.Length);
    // Close the Stream object.
    dataStream.Close();
    // Get the response.
    WebResponse response = request.GetResponse();

    // Display the status.
    //saveResponseLog(((HttpWebResponse)response).StatusDescription);
    // Get the stream containing content returned by the server.
    dataStream = response.GetResponseStream();
    // Open the stream using a StreamReader for easy access.
    StreamReader reader = new StreamReader(dataStream);
    // Read the content.
    string responseFromServer = reader.ReadToEnd();
    // Display the content.
    saveResponseLog("QuoteMe Post: Response: (" + Sampleleadid.ToString() + ") " + responseFromServer);
    // Clean up the streams.
    reader.Close();
    dataStream.Close();
    response.Close();
    if (responseFromServer.Contains("FAIL"))
    {
     Exception e = new Exception(responseFromServer);

     //SendError(e, "RMW Error posting: QuoteMeAPI - RMWLeadID: " + Sampleleadid + ", APILeadID: " + highestBidder.LeadId + ", ", string.Empty);
     saveErrorLog("RMW Error posting: QuoteMeAPI - RMWLeadID: " + Sampleleadid + ", APILeadID: " + highestBidder.LeadId + ": " + e.ToString());
     return false;
    }
    else
    {
     saveAPIResponse(Sampleleadid, responseFromServer, highestBidder.LeadId, highestBidder.LeadPrice.ToString(), highestBidder.LeadAPIID, "Post");
     return true;
    }

   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());
    return false;
   }
  }
  #endregion

  #region pingModernizeOOMLead - pings modernize for price.
  /// <summary>
  /// Sends the oom lead.
  /// </summary>
  /// <param name="sourceid">The sourceid.</param>
  /// <param name="zipcode">The zipcode.</param>
  /// <param name="istest">The test var.</param>
  /// source is Aff899 
  protected string[] pingModernizeOOMLead(string sourceid, string zipcode, string istest, int Sampleleadid)
  {
   string PostUrl = ConfigurationManager.AppSettings["ModernizeAPIURLPing"].ToString();
   string postData = string.Empty;
   string[] result = new string[4] { "", "", "", "" };
   try
   {
    /* Optimizations */
    ServicePointManager.Expect100Continue = false;
    ServicePointManager.DefaultConnectionLimit = 5;

    // Create a request using a URL that can receive a post. 
    WebRequest request = WebRequest.Create(PostUrl);
    // Set the Method property of the request to POST.
    request.Method = "POST";
    request.Proxy = null;

    // Create POST data and convert it to a byte array.
    postData = "Key=LnD7hFN3O3r-b6A0L3akEWL3L6c7hnXYO4A0b4hqLqDkOnAyLFNqE4yrGkD2&tcpa=Yes&SRC=" + sourceid + "&Landing_Page=landing&Zip=" + zipcode + "&Sub_ID=12&Project=Window Replacement of Multiple Windows&Repair=No&Return_Best_Price=1&Homeowner=Yes&Test_Lead=" + istest;

    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    // Set the ContentType property of the WebRequest.
    request.ContentType = "application/x-www-form-urlencoded";
    // Set the ContentLength property of the WebRequest.
    request.ContentLength = byteArray.Length;
    // Get the request stream.
    Stream dataStream = request.GetRequestStream();
    // Write the data to the request stream.
    dataStream.Write(byteArray, 0, byteArray.Length);
    // Close the Stream object.
    dataStream.Close();
    // Get the response.
    WebResponse response = request.GetResponse();

    // Display the status.
    //saveResponseLog(((HttpWebResponse)response).StatusDescription);
    // Get the stream containing content returned by the server.
    dataStream = response.GetResponseStream();
    // Open the stream using a StreamReader for easy access.
    StreamReader reader = new StreamReader(dataStream);
    // Read the content.
    string responseFromServer = reader.ReadToEnd();
    saveResponseLog("Modernize Ping: (" + Sampleleadid.ToString() + ") " + responseFromServer.Trim().Replace(Environment.NewLine, ""));

    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(responseFromServer);
    //API ID
    result[0] = "1";
    var isMatch = xmlDoc.SelectSingleNode("/response/status").InnerText;
    if (isMatch == "Matched")
    {
     // API LeadID
     result[1] = xmlDoc.SelectSingleNode("/response/lead_id").InnerText;
     // API Lead Price
     result[2] = xmlDoc.SelectSingleNode("/response/price").InnerText;
    }
    // API Response
    result[3] = isMatch;
    // Display the content.
    // Clean up the streams.
    reader.Close();
    dataStream.Close();
    response.Close();
   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());
    result[0] = "1";
    result[3] = "rejected";
   }
   return result;
  }
  #endregion

  #region postModernizeOOMLead - Sends out of market leads to CRM
  protected bool postModernizeOOMLead(int Sampleleadid, LeadBid highestBidder, string tcpaconsentlanguage, string sourceid, string firstname, string lastname, string address, string city, string state, string zipcode, string email, string phone, string numberofwindows, string istest, string tcpaconsent = "Yes", string homeowner = "Yes", string subid = "12", string material = "Wood", string repair = "No", string landingpage = "landing")
  {
   string PostUrl = ConfigurationManager.AppSettings["ModernizeAPIURLPost"].ToString();
   string postData = string.Empty;
   try
   {
    /* Optimizations */
    ServicePointManager.Expect100Continue = false;
    ServicePointManager.DefaultConnectionLimit = 5;

    // Create a request using a URL that can receive a post. 
    WebRequest request = WebRequest.Create(PostUrl);
    // Set the Method property of the request to POST.
    request.Method = "POST";
    request.Proxy = null;

    // Create POST data and convert it to a byte array.
    postData = "Key=LnD7hFN3O3r-b6A0L3akEWL3L6c7hnXYO4A0b4hqLqDkOnAyLFNqE4yrGkD2&Lead_ID=" + highestBidder.LeadId + "&tcpa=" + tcpaconsent + "&tcpaText=" + tcpaconsentlanguage + "&Homeowner=" + homeowner + "&ipAddress=" + FormProperties.strIpAddress + "&SRC=" + sourceid + "&Landing_Page=" + landingpage + "&Sub_ID=" + subid + "&Material=" + material + "&First_Name=" + firstname + "&Last_Name=" + lastname + "&Address=" + address + "&City=" + city + "&State=" + state + "&Zip=" + zipcode + "&Email=" + email + "&Home_Phone=" + phone + "&Hear=" + numberofwindows + "&Repair=" + repair + "&Project=Window Replacement of Multiple Windows";
    if (istest == "1")
    {
     postData += "&Test_Lead=1";
    }
    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    // Set the ContentType property of the WebRequest.
    request.ContentType = "application/x-www-form-urlencoded";
    // Set the ContentLength property of the WebRequest.
    request.ContentLength = byteArray.Length;
    // Get the request stream.
    Stream dataStream = request.GetRequestStream();
    // Write the data to the request stream.
    dataStream.Write(byteArray, 0, byteArray.Length);
    // Close the Stream object.
    dataStream.Close();
    // Get the response.
    WebResponse response = request.GetResponse();

    // Display the status.
    //saveResponseLog(((HttpWebResponse)response).StatusDescription);
    // Get the stream containing content returned by the server.
    dataStream = response.GetResponseStream();
    // Open the stream using a StreamReader for easy access.
    StreamReader reader = new StreamReader(dataStream);
    // Read the content.
    string responseFromServer = reader.ReadToEnd();
    // Display the content.
    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(responseFromServer);
    saveResponseLog("Modernize Post: (" + Sampleleadid.ToString() + ") " + responseFromServer);
    // Clean up the streams.
    reader.Close();
    dataStream.Close();
    response.Close();
    responseFromServer = responseFromServer.ToLower();
    if (responseFromServer.Contains("rejected"))
    {
     Exception e = new Exception(responseFromServer);
     SendError(e, "RMW Error posting: ModernizeAPI - RMWLeadID:" + Sampleleadid + ", APILeadID: " + highestBidder.LeadId + ", " + responseFromServer, string.Empty);
     return false;
    }
    else
    {
     saveAPIResponse(Sampleleadid, xmlDoc.OuterXml, highestBidder.LeadId, highestBidder.LeadPrice.ToString(), highestBidder.LeadAPIID, "Post");
     return true;
    }
   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());
    return false;
   }
  }
  #endregion

  #region pingRemodelingOOMLead - pings remodeling for price
  protected string[] pingRemodelingOOMLead(string zipcode, string numberofwindows, int Sampleleadid)
  {
   string pingUrl = ConfigurationManager.AppSettings["RemodelingAPIURLPing"].ToString();
   string apiKey = ConfigurationManager.AppSettings["RemodelingAPIKey"].ToString();
   string postData = string.Empty;
   string[] result = new string[4] { "", "", "", "" };
   try
   {
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(pingUrl);
    httpWebRequest.Headers.Add("API-Key", apiKey);
    httpWebRequest.Headers.Add("Request-Signature", generateRequestSignature());
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";

    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
     string json = "{ \"service\": \"windows\", \"zipcode\": \"" + zipcode + "\", \"answers\": { \"service_type\": \"install\", \"property_type\": \"residential\", \"time_frame\": \"not_sure\", \"number_of_windows\": \"" + returnMappedWindows(numberofwindows) + "\" } }";

     streamWriter.Write(json);
     streamWriter.Flush();
     streamWriter.Close();
    }

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
     RemodelingLead response = new RemodelingLead();
     response.error = null;
     string responseStream = streamReader.ReadToEnd();
     response = new JavaScriptSerializer().Deserialize<RemodelingLead>(responseStream);
     saveResponseLog("Remodeling Ping: (" + Sampleleadid.ToString() + ") " + responseStream);
     if (response.error == null)
     {
      // API ID
      result[0] = "2";
      // API Lead ID
      result[1] = response.id;
      // API Lead Price
      result[2] = response.payout;
      // API Response
      result[3] = response.status;
     }
     else
     {
      result[3] = response.error;
     }
    }
   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());
    result[0] = "2";
    result[3] = "rejected";
   }
   return result;

  }
  #endregion

  #region postRemodelingOOMLead - posts lead to CRM 
  protected bool postRemodelingOOMLead(int Sampleleadid, LeadBid highestBidder, string firstname, string lastname, string phonenumber, string email, string address, string city, string state, string zipcode, string numberofwindows, string pingid = "", string trafficsource = "", string partnerleadid = "", string campaign = "")
  {
   string PostUrl = ConfigurationManager.AppSettings["RemodelingAPIURLPost"].ToString();
   string apiKey = ConfigurationManager.AppSettings["RemodelingAPIKey"].ToString();
   string postData = string.Empty;
   try
   {
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
    httpWebRequest.Headers.Add("API-Key", apiKey);
    httpWebRequest.Headers.Add("Request-Signature", generateRequestSignature());
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";

    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
     string json = "{ \"service\": \"windows\", \"zipcode\": \"" + zipcode + "\", \"ping_id\": \"" + highestBidder.LeadId + "\", \"traffic_source\": \"sms55\", \"partner_lead_id\": \"" + Sampleleadid + "\", \"ip_address\": \"" + FormProperties.strIpAddress + "\",  \"campaign\": \"window123\",  \"answers\": { \"service_type\": \"install\", \"property_type\": \"residential\", \"time_frame\": \"not_sure\", \"number_of_windows\": \"" + returnMappedWindows(numberofwindows) + "\" },  \"pii\": { \"first_name\": \"" + firstname + "\", \"last_name\": \"" + lastname + "\", \"phone_number\": \"" + phonenumber + "\", \"email\": \"" + email + "\", \"street_address\": \"" + address + "\", \"city\": \"" + city + "\", \"state_code\": \"" + state + "\" } }";

     streamWriter.Write(json);
     streamWriter.Flush();
     streamWriter.Close();
    }

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
     string streamString = streamReader.ReadToEnd();
     RemodelingLead JSresponse = new JavaScriptSerializer().Deserialize<RemodelingLead>(streamString);
     saveResponseLog("Remodeling Post: (" + Sampleleadid + ") " + streamString);
     if (JSresponse.status == "rejected")
     {
      return false;
     }
     else
     {
      saveAPIResponse(Sampleleadid, JSresponse.status, highestBidder.LeadId, highestBidder.LeadPrice.ToString(), highestBidder.LeadAPIID, "Post");
      return true;
     }
    }

   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());
    return false;
   }
  }
  #endregion

  #region sendOOMLead - sends lead to the highest bidder {
  protected void sendOOMLead(int Sampleleadid, List<LeadBid> highestBidder, string email, string zipcode, string tcpaconsent, string numberofwindows, string firstname, string lastname, string address, string city, string state, string tcpaconsentlanguage, string phone, string besttimetocall, int nextHighestBidder = 0)
  {
   bool isPostedLead = false;
   switch (highestBidder[nextHighestBidder].LeadAPIID)
   {
    case "0":
     isPostedLead = postQuoteMeOOMLead(Sampleleadid, email, highestBidder[nextHighestBidder], "ECEM", zipcode, tcpaconsent, numberofwindows, firstname, lastname, phone, address, city, state, FormProperties.strIsTest, besttimetocall);
     break;
    case "1":
     isPostedLead = postModernizeOOMLead(Sampleleadid, highestBidder[nextHighestBidder], tcpaconsentlanguage, "Aff899", firstname, lastname, address, city, state, zipcode, email, phone, numberofwindows, FormProperties.strIsTest);
     break;
    case "2":
     isPostedLead = postRemodelingOOMLead(Sampleleadid, highestBidder[nextHighestBidder], firstname, lastname, phone, email, address, city, state, zipcode, numberofwindows);
     break;
    default:
     isPostedLead = false;
     break;
   }
   /* Go to next highest bidder */
   if (isPostedLead == false)
   {
    nextHighestBidder += 1;
    if (nextHighestBidder < highestBidder.Count)
    {
     sendOOMLead(Sampleleadid, highestBidder, email, zipcode, tcpaconsent, numberofwindows, firstname, lastname, address, city, state, tcpaconsentlanguage, phone, besttimetocall, nextHighestBidder);
    }
    else
    {
     saveAPIResponse(Sampleleadid, "All Rejected", "", "", "", "");
    }
   }
   else
   {
    //saveAPIResponse(Sampleleadid, "accepted", highestBidder[nextHighestBidder].LeadId, highestBidder[nextHighestBidder].LeadPrice.ToString(), highestBidder[nextHighestBidder].LeadAPIID, "Post");
   }
  }
  #endregion

  #region getEmailAddressforLead
  /// <summary>
  /// Gets the email addressfor lead.
  /// </summary>
  protected void getEmailAddressforLead()
  {
   //Post lead to Client
   string connectionInfo = ConfigurationManager.AppSettings["ConnectionInfo"];
   try
   {
    //Get Email Address to Post Lead to
    using (SqlConnection connection = new SqlConnection(connectionInfo))
    {
     SqlDataAdapter da = new SqlDataAdapter("Home_GetCmpDetails", connection);
     da.SelectCommand.CommandType = CommandType.StoredProcedure;
     da.SelectCommand.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = FormProperties.strZipCode;
     da.SelectCommand.Parameters.Add("@Campaignid", SqlDbType.Int).Value = FormProperties.strCampaignID;
     DataSet dsCampDetails = new DataSet();
     da.Fill(dsCampDetails);
     da.Dispose();

     if (dsCampDetails.Tables[0].Rows.Count >= 0)
     {
      foreach (DataRow drCmp in dsCampDetails.Tables[0].Rows)
      {
       FormProperties.strToEmail = Convert.ToString(drCmp["Email"]);
       FormProperties.strLocationID = Convert.ToString(drCmp["Locationid"]);
      }
     }
    }
   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());

    SendError(ex, "Error on Sample: function getEmailAddressforLead", "");
   }
  }
  #endregion

  #region sendLeadEmail
  /// <summary>
  /// Sends the lead email.
  /// </summary>
  protected void sendLeadEmail()
  {
   FormProperties.strFromEmail = "Leads@convergeTrack.com";
   string subject = FormProperties.strSourceName;

   // HTML Email
   string body = "<html><body style=\"font-family: Arial, sans-serif;\"><p><b>Hot Lead,</b><br><br>The Following Lead has been Received.</p>";
   body = body + "<table border='1' cellpadding='2' width='600' style=\"font-family: Arial, sans-serif;\"><tbody>";
   body = body + "<tr><td>First Name:</td><td>" + FormProperties.strFirstName + "</td></tr>";
   body = body + "<tr><td>Last Name:</td><td>" + FormProperties.strLastName + "</td></tr>";
   body = body + "<tr><td>Address:</td><td>" + FormProperties.strStreet + "</td></tr>";
   body = body + "<tr><td>City:</td><td>" + FormProperties.strCity + "</td></tr>";
   body = body + "<tr><td>State:</td><td>" + FormProperties.strState + "</td></tr>";
   body = body + "<tr><td>Zip:</td><td>" + FormProperties.strZipCode + "</td></tr>";
   body = body + "<tr><td>HomePhone:</td><td>" + FormProperties.strPhoneNumber + "</td></tr>";
   body = body + "<tr><td>WorkPhone:</td><td>" + string.Empty + "</td></tr>";
   body = body + "<tr><td>CellPhone:</td><td>" + string.Empty + "</td></tr>";
   body = body + "<tr><td>Email:</td><td>" + FormProperties.strEmail + "</td></tr>";
   body = body + "<tr><td>Best Time to Call:</td><td>" + FormProperties.strBestTimetoCall + "</td></tr>";
   body = body + "<tr><td>Number of Windows:</td><td>" + FormProperties.strNumberofWindows + "</td></tr>";
   body = body + "<tr><td>Source:</td><td>" + FormProperties.strSourceName + "</td></tr>";
   if ((FormProperties.strSourceID != null) || (FormProperties.strSourceID != string.Empty))
   {
    body = body + "<tr><td>Source ID:</td><td>" + FormProperties.strSourceID + "</td></tr>";
   }
   body = body + "</tbody></table><p>Please do not reply to this email.</p></html>";

   bool isHtml = true;
   if (FormProperties.strLocationID == "43")
   {
    isHtml = false;
    body = "Hot Lead," + Environment.NewLine + "The Following Lead has been Received." + Environment.NewLine + Environment.NewLine;
    body = body + "First Name: " + FormProperties.strFirstName + Environment.NewLine;
    body = body + "Last Name: " + FormProperties.strLastName + Environment.NewLine;
    body = body + "Address: " + FormProperties.strStreet + Environment.NewLine;
    body = body + "City: " + FormProperties.strCity + Environment.NewLine;
    body = body + "State: " + FormProperties.strState + Environment.NewLine;
    body = body + "Zip: " + FormProperties.strZipCode + Environment.NewLine;
    body = body + "HomePhone: " + FormProperties.strPhoneNumber + Environment.NewLine;
    body = body + "WorkPhone: " + string.Empty + Environment.NewLine;
    body = body + "CellPhone: " + string.Empty + Environment.NewLine;
    body = body + "Email: " + FormProperties.strEmail + Environment.NewLine;
    body = body + "Best Time to Call: " + FormProperties.strBestTimetoCall + Environment.NewLine;
    body = body + "Number of Windows: " + FormProperties.strNumberofWindows + Environment.NewLine;
    body = body + "Source: " + FormProperties.strSourceName + Environment.NewLine;
    if ((FormProperties.strSourceID != null) || (FormProperties.strSourceID != string.Empty))
    {
     body = body + "Source ID: " + FormProperties.strSourceID + Environment.NewLine + Environment.NewLine;
    }
    body = body + "Please do not reply to this email.";
   }

   try
   {
    SendSampleEmail(subject, body, isHtml);
   }
   catch (Exception ex)
   {
    SendError(ex, "Sample: Error Sending Lead", FormProperties.strReferralURL);
    saveErrorLog(ex.ToString());
   }
  }
  #endregion

  #region SendSampleEmail
  /// <summary>
  /// Sends the Sample email.
  /// </summary>
  /// <param name="subject">The subject.</param>
  /// <param name="body">The body.</param>
  protected void SendSampleEmail(string subject, string body, bool isHtml)
  {
   MailMessage emailMessage = new MailMessage();
   emailMessage.Bcc.Add(new MailAddress(""));
   //emailMessage.Bcc.Add(new MailAddress(""));

   emailMessage.From = new MailAddress(FormProperties.strFromEmail);
   emailMessage.Subject = subject;
   emailMessage.Body = body;
   emailMessage.IsBodyHtml = isHtml;

   if (FormProperties.strToEmail.Contains(",") == true)
   {
    string[] toemails = FormProperties.strToEmail.Split(',');
    foreach (string email in toemails)
    {
     emailMessage.To.Add(new MailAddress(email));
    }
   }
   else
   {
    emailMessage.To.Add(new MailAddress(FormProperties.strToEmail));
   }

   //emailMessage.Priority = MailPriority.High;
   //Send the message.
   SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SMTPCLIENT"].ToString());

   try
   {
    client.Send(emailMessage);
   }
   catch (Exception em)
   {
    SendError(em, "Sample: Error Sending Sample EMail", FormProperties.strReferralURL);
    saveErrorLog(em.ToString());
   }
  }
  #endregion

  #region saveLeadtoDB
  protected int saveLeadtoDB(string sourcecampaignid, string campaignid, string leadsource, string kwd, string ipaddress, string firstname, string lastname, string email, string address, string city, string state, string phone, string zipcode, string besttimetocall, string numberofwindows, bool outofmarket, string useragent, string referringurl, string browser, bool test, string apileadid = "", string apileadprice = "", string apiid = "", string apitype = "")
  {
   int leadid = 0;
   try
   {
    string connectionInfo = ConfigurationManager.AppSettings["ConnectionInfo"];
    using (SqlConnection connection = new SqlConnection(connectionInfo))
    {
     SqlCommand cmd = new SqlCommand("Sample_WebLead_Insert", connection);
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@source_campaign_id", SqlDbType.VarChar, 50).Value = sourcecampaignid;
     cmd.Parameters.Add("@campaign_id", SqlDbType.VarChar, 50).Value = campaignid;
     cmd.Parameters.Add("@lead_source", SqlDbType.VarChar, 50).Value = leadsource;
     cmd.Parameters.Add("@kwd", SqlDbType.VarChar, 150).Value = kwd;
     cmd.Parameters.Add("@ip_address", SqlDbType.VarChar, 50).Value = ipaddress;
     cmd.Parameters.Add("@first_name", SqlDbType.VarChar, 50).Value = firstname;
     cmd.Parameters.Add("@last_name", SqlDbType.VarChar, 50).Value = lastname;
     cmd.Parameters.Add("@email", SqlDbType.VarChar, 150).Value = email;
     cmd.Parameters.Add("@address", SqlDbType.VarChar, 150).Value = address;
     cmd.Parameters.Add("@city", SqlDbType.VarChar, 50).Value = city;
     cmd.Parameters.Add("@state", SqlDbType.VarChar, 50).Value = state;
     cmd.Parameters.Add("@phone", SqlDbType.VarChar, 50).Value = phone;
     cmd.Parameters.Add("@zip_code", SqlDbType.VarChar, 20).Value = zipcode;
     cmd.Parameters.Add("@best_time_to_call", SqlDbType.VarChar, 50).Value = besttimetocall;
     cmd.Parameters.Add("@number_of_windows", SqlDbType.VarChar, 10).Value = numberofwindows;
     cmd.Parameters.Add("@out_of_market", SqlDbType.Bit).Value = outofmarket;
     cmd.Parameters.Add("@user_agent", SqlDbType.VarChar, 1000).Value = useragent;
     cmd.Parameters.Add("@referring_url", SqlDbType.VarChar, 750).Value = referringurl;
     cmd.Parameters.Add("@browser", SqlDbType.VarChar, 150).Value = browser;
     cmd.Parameters.Add("@test", SqlDbType.Bit).Value = test;
     cmd.Parameters.Add("@apileadid", SqlDbType.VarChar, 50).Value = apileadid;
     cmd.Parameters.Add("@apileadprice", SqlDbType.VarChar, 50).Value = apileadprice;
     cmd.Parameters.Add("@apiid", SqlDbType.VarChar, 50).Value = getLeadAPIIDName(apiid);
     cmd.Parameters.Add("@apiresponsetype", SqlDbType.NVarChar, 50).Value = apitype;
     SqlParameter outputParam = cmd.Parameters.Add("@lead_id", SqlDbType.Int);
     outputParam.Direction = ParameterDirection.Output;

     connection.Open();
     cmd.ExecuteNonQuery();

     leadid = int.Parse(outputParam.Value.ToString());

     if (connection.State == ConnectionState.Open)
     {
      connection.Close();
     }
    }
    return leadid;
   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());
    return 0;
   }
  }
  #endregion

  #region generateRandomIP
  protected string generateRandomIP()
  {
   Random _random = new Random();
   return string.Format("{0}.{1}.{2}.{3}", _random.Next(0, 255), _random.Next(0, 255), _random.Next(0, 255), _random.Next(0, 255));
  }
  #endregion

  #region getLeadAPIIDName
  protected string getLeadAPIIDName(string id)
  {
   switch (id)
   {
    case "0":
     return "QuoteMeAPI";
    case "1":
     return "ModernizeAPI";
    case "2":
     return "RemodelingAPI";
    default:
     return "";
   }
  }
  #endregion

  #region saveAPIResponse
  protected void saveAPIResponse(int leadid, string response, string apileadid = "", string apileadprice = "", string apiid = "", string apitype = "")
  {
   string connectionInfo = ConfigurationManager.AppSettings["ConnectionInfo"];
   try
   {
    using (SqlConnection connection = new SqlConnection(connectionInfo))
    {
     SqlCommand cmd = new SqlCommand("Sample_UpdatePostingResponse", connection);
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@LeadID", SqlDbType.Int).Value = leadid;
     cmd.Parameters.Add("@apileadid", SqlDbType.VarChar, 50).Value = apileadid;
     cmd.Parameters.Add("@apileadprice", SqlDbType.VarChar, 50).Value = apileadprice;
     cmd.Parameters.Add("@apiid", SqlDbType.VarChar, 50).Value = getLeadAPIIDName(apiid);
     cmd.Parameters.Add("@apiresponsetype", SqlDbType.NVarChar, 50).Value = apitype;
     cmd.Parameters.Add("@Status", SqlDbType.VarChar, 250).Value = response;
     connection.Open();
     cmd.ExecuteNonQuery();

     if (connection.State == ConnectionState.Open)
     {
      connection.Close();
     }
    }
   }
   catch (Exception ex)
   {
    SendError(ex, "ERROR ON Sample: saveAPIResponse", "");
   }
  }
  #endregion

  #region isAPILeadCap
  protected bool isAPILeadCap(string api_id)
  {
   string connectionInfo = ConfigurationManager.AppSettings["ConnectionInfo"];
   int leadcount = 0;
   try
   {
    using (SqlConnection connection = new SqlConnection(connectionInfo))
    {
     SqlCommand cmd = new SqlCommand("Sample_GetLeadCount", connection);
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@APILeadID", SqlDbType.VarChar, 50).Value = getLeadAPIIDName(api_id);
     SqlParameter outputParam = cmd.Parameters.Add("@count", SqlDbType.Int);
     outputParam.Direction = ParameterDirection.Output;
     connection.Open();
     cmd.ExecuteNonQuery();
     leadcount = int.Parse(outputParam.Value.ToString());

     if (connection.State == ConnectionState.Open)
     {
      connection.Close();
     }
    }
    switch (api_id)
    {
     case "0":
      if (leadcount <= 8)
      {
       return true;
      }
      else
      {
       return false;
      }
     /*
    case "1":
     if (leadcount <= 50)
     {
      return true;
     }
     else
     {
      return false;
     } */
     default:
      return false;
    }
   }
   catch (Exception ex)
   {
    SendError(ex, "ERROR ON Sample: saveAPIResponse", "");
    return false;
   }
  }
  #endregion

  #region returnBoolValue
  protected bool returnBoolValue(string value)
  {
   switch (value)
   {
    case "0":
     return false;
    case "1":
     return true;
    default:
     return false;
   }
  }
  #endregion

  #region Generate Request Signature - Remodeling
  protected string generateRequestSignature()
  {
   string secretKey = ConfigurationManager.AppSettings["RemodelingAPISecretKey"].ToString();
   int timeStamp = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
   string timeStampEncoding = Convert.ToBase64String(Encoding.UTF8.GetBytes(timeStamp.ToString()));

   HMACSHA1 hmacSha1 = new HMACSHA1(Encoding.UTF8.GetBytes(secretKey));
   hmacSha1.ComputeHash(Encoding.UTF8.GetBytes(timeStampEncoding));

   StringBuilder keyHash = new StringBuilder();
   foreach (byte b in hmacSha1.Hash)
   {
    keyHash.Append(b.ToString("x2"));
   }
   return timeStampEncoding + "--" + keyHash.ToString();
  }
  #endregion

  #region Map Number of Windows - Remodeling
  protected string returnMappedWindows(string numberofwindows)
  {
   switch (numberofwindows)
   {
    case "Under 3":
     return "1";
    case "3-10":
     return "3_5";
    case "10+":
     return "10_and_more";
    default: return "";
   }
  }
  #endregion
 }
}
