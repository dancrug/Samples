using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleAffilForm.Dashboard
{

 /// <summary>
 /// Inserts new vendor into database.
 /// </summary>
 public partial class ManageVendor : System.Web.UI.Page
 {
  SampleService rs = new SampleService();

  protected void btnSubmit_Click(object sender, EventArgs e)
  {
   if (txtCC.Text != null && txtCC.Text != string.Empty)
   {
    rs.insertCC(txtCC.Text);
    VendorGrid.DataBind();
    txtCC.Text = string.Empty;
   }
  }
 }
}