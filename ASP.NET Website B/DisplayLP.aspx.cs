using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sample
{
 public partial class DLP : System.Web.UI.Page
 {
  FormClass f = new FormClass();

  protected void Page_Load(object sender, EventArgs e)
  {
   FormProperties.strSource = "0";
   FormProperties.strAppPath = Request.PhysicalApplicationPath;
   if (Request.QueryString["PH"] != null)
   {
    FormProperties.strPhone = Request.QueryString["PH"];
   }
   else
   {
    phone.Visible = false;
    slogan.Attributes.Add("class", "right");
   }

   if (!Page.IsPostBack)
   {
    f.populatePhone(phoneNumber, Request);
    return;
   }
  }
 }
}