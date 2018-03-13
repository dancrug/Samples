using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services;

namespace SampleAffilForm.Dashboard
{
 public partial class MasterMatrix : System.Web.UI.Page
 {
  SampleService rs = new SampleService();
  protected void Page_Load(object sender, EventArgs e)
  {
   returnCCStatus();
  }
  [WebMethod(EnableSession = true)]
  public static void ddlCCStatus_Changed(string id, string status)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_MasterGrid", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "UPDATE";
     cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = status;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }
  [WebMethod(EnableSession = true)]
  public static void txtNote_Changed(string id, string note)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_MasterGridNote", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "UPDATE";
     cmd.Parameters.Add("@Note", SqlDbType.NVarChar, 50).Value = note;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }
  public void returnCCStatus()
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_CC_Status", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     SqlDataAdapter da = new SqlDataAdapter(cmd);
     DataSet dsLeads = new DataSet();
     da.Fill(dsLeads);
     foreach (DataRow d in dsLeads.Tables[0].Rows)
     {
      GridCC.InnerHtml += "<span data-id=\"" + d[0].ToString() + "\">" + d[1].ToString() + "</span>";
     }
     da.Dispose();
    }
    con.Close();
   }
  }
  protected void btnSubmit_Click(object sender, CommandEventArgs e)
  {
   string commandType = e.CommandName;
   int id = 0;
   if (Request.QueryString["AID"] != null)
   {
    id = Convert.ToInt32(Request.QueryString["AID"]);
   }
   switch (commandType)
   {
    case "AddMarketCC":
     //rs.insertMarketCC(Convert.ToInt32(ddlCallCenterName.SelectedValue), txtCallCenterHours.Text, txtCallCenterPhone.Text, Convert.ToInt32(ddlCCMarket.SelectedValue), id, ddlCCStatus.SelectedValue);
     GridCC.DataBind();
     break;
    default:
     break;
   }
  }

  protected void GridMatrix_DataBound(object sender, EventArgs e)
  {
   GridMatrix.HeaderRow.Cells[2].CssClass = "amrid";
   GridMatrix.HeaderRow.Cells[3].CssClass = "amrnote";
   foreach (GridViewRow r in GridMatrix.Rows)
   {
    int i = 4;
    r.Cells[1].Attributes.Add("class", "amrname");
    r.Cells[2].Attributes.Add("class", "amrid");
    r.Cells[2].Attributes.Add("data-id", r.Cells[2].Text);
    r.Cells[3].Attributes.Add("class", "amrnote");
    r.Cells[3].Attributes.Add("data-id", r.Cells[2].Text);

    while (i < r.Cells.Count)
    {
     r.Cells[i].Attributes.Add("class", "ccid");
     i++;
    }
   }
  }
  protected void GridMatrix_DataBind()
  {
   GridMatrix.DataBind();
  }
 }
}