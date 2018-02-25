using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleAffilForm.Dashboard
{
 public partial class Default : System.Web.UI.Page
 {
  SampleService rs = new SampleService();

  /// <summary>
  /// Redirect to manage the specific affiliate based on the AID.
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void AffiliateGrid_RowCommand(object sender, GridViewCommandEventArgs e)
  {
   int index = Convert.ToInt32(e.CommandArgument);

   switch (e.CommandName)
   {
    case "Select":
     string AID = AffiliateGrid.DataKeys[index].Value.ToString();
     Session["AID"] = AID;
     Response.Redirect("ManageAffiliate.aspx?AID=" + AID);
     break;
    default:
     break;
   }
  }

  /// <summary>
  /// Inserts new affiliate to DB.
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
  protected void btnSubmit_Click(object sender, EventArgs e)
  {
   if (txtAffil.Text != null && txtAffil.Text != string.Empty)
   {
    rs.insertAffiliate(txtAffil.Text);
    AffiliateGrid.DataBind();
    txtAffil.Text = string.Empty;
   }
  }
 }
}