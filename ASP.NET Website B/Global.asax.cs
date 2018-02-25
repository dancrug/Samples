using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Net.Mail;
using System.Configuration;

namespace Sample
{
 public class Global : System.Web.HttpApplication
 {

  protected void Application_Start(object sender, EventArgs e)
  {

  }

  protected void Session_Start(object sender, EventArgs e)
  {

  }

  protected void Application_BeginRequest(object sender, EventArgs e)
  {

  }

  protected void Application_AuthenticateRequest(object sender, EventArgs e)
  {

  }

  protected void Application_Error(object sender, EventArgs e)
  {
   Exception ex = Server.GetLastError();
   try
   {
    String Message = ex.Message;
    String IP = Request.UserHostAddress;
    String Browser = Request.UserAgent;
    String URL = Request.Url.ToString();
    String Referrer = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : string.Empty;
    string ErrorMessage;
    ErrorMessage = "Error Message: " + Message + "<br>";
    ErrorMessage = ErrorMessage + "IP: " + IP + "<br>";
    ErrorMessage = ErrorMessage + "Browser: " + Browser + "<br>";
    ErrorMessage = ErrorMessage + "URL: " + URL + "<br>";
    ErrorMessage = ErrorMessage + "Referrer: " + Referrer + "<br>";
    ErrorMessage = ErrorMessage + "Detail Message: " + ex.InnerException + "<br>";

    MailMessage emailMessage = new MailMessage(ConfigurationManager.AppSettings["ERRORFROMEMAIL"].ToString(), ConfigurationManager.AppSettings["ERRORTOEMAIL"].ToString(), "Error On Sample", ErrorMessage);
    emailMessage.IsBodyHtml = true;
    emailMessage.CC.Add(new MailAddress(""));
    emailMessage.Priority = MailPriority.High;
    //Send the message.
    SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SMTPCLIENT"].ToString());
    client.Send(emailMessage);

   }
   catch (Exception)
   {

   }
   finally
   {

   }
  }

  protected void Session_End(object sender, EventArgs e)
  {

  }

  protected void Application_End(object sender, EventArgs e)
  {

  }
 }
}
