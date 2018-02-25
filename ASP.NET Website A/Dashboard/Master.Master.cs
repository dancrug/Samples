using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleAffilForm.Dashboard
{
 public partial class Master : System.Web.UI.MasterPage
 {
  protected void Page_Load(object sender, EventArgs e)
  {
   // Detect if user is on a valid network and if not ask for the Hash/Password ().
   if ((Request.UserHostAddress == "") || (Request.UserHostAddress == "::1") || (Request.UserHostAddress == ""))
   {
    pnlLoggedIn.Visible = true;
    pnlLogin.Visible = false;
    Session["Hash"] = true;
   }
   else
   {
    bool checkHash = Convert.ToBoolean(Session["Hash"]);
    if (checkHash == true)
    {
     pnlLoggedIn.Visible = true;
     pnlLogin.Visible = false;
     Session["Hash"] = true;
    }
    else
    {
     pnlLoggedIn.Visible = false;
     pnlLogin.Visible = true;
     Session["Hash"] = false;
    }
   }
   Session.Timeout = 5;
  }

  protected void btnHash_Click(object sender, EventArgs e)
  {
   string hash = "";
   if (txtHash.Text == hash)
   {
    Session["Hash"] = true;
    pnlLoggedIn.Visible = true;
    pnlLogin.Visible = false;
   }
   else
   {
    Session["Hash"] = false;
    pnlLoggedIn.Visible = false;
    pnlLogin.Visible = true;
   }
  }
 }
}