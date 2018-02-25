using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample
{
 public partial class ThankYou : System.Web.UI.Page
 {
  FormClass f = new FormClass();
  public string email = "";

  protected void Page_Load(object sender, EventArgs e)
  {
   if (Request.QueryString["PH"] != null)
   {
    FormProperties.strPhone = Request.QueryString["PH"];
   }
   if (FormProperties.strEmail != string.Empty)
   {
    email = FormProperties.strEmail;
   }
   FormProperties.strAppPath = Request.PhysicalApplicationPath;

   if (!Page.IsPostBack)
   {
    f.populatePhone(phoneNumber, Request);
    return;
   }
  }
 }
}