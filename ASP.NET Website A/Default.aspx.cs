using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;

namespace SampleAffilForm
{
 public partial class Default : System.Web.UI.Page
 {
  protected void Page_Load(object sender, EventArgs e)
  {
   string strAppPath = string.Empty;
   strAppPath = Request.PhysicalApplicationPath;

   if (!Page.IsPostBack)
   {
    populateStates(ddlCState, strAppPath);
    populateStates(ddlBState, strAppPath);
    //Response.Write(Request.UserHostAddress);
   }
  }
  #region populateStates - Populates the states in the form.
  public void populateStates(DropDownList ddl, string applicationPath)
  {
   // Create xml doc.
   XmlDocument xDoc = new XmlDocument();

   try
   {
    // Grab xml document from server.
    xDoc.Load(applicationPath + "/lib/states.xml");
   }
   catch (Exception ex)
   {
    throw ex;
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

  #region sendLeadInformation
  public void sendLeadInformation(Affiliate a)
  {
   int aid = 0;
   int cid = 0;
   int bid = 0;
   int rid = 0;
   int mid = 0;
   int ccid = 0;
   //int zid = 0;
   try
   {
    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
    {
     con.Open();
     //1.0 Insert Group/Company Information
     using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil", con))
     {
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = a.Company;
      cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";
      SqlParameter output = cmd.Parameters.Add("@AID", SqlDbType.Int);
      output.Direction = ParameterDirection.Output;

      cmd.ExecuteNonQuery();
      aid = Convert.ToInt32(output.Value);
     }
     //2.0 Insert Contact Information
     using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_CI", con))
     {
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add("@CFirstName", SqlDbType.NVarChar).Value = a.CFirstName;
      cmd.Parameters.Add("@CLastName", SqlDbType.NVarChar).Value = a.CLastName;
      cmd.Parameters.Add("@CAddress", SqlDbType.NVarChar).Value = a.CAddress;
      cmd.Parameters.Add("@CCity", SqlDbType.NVarChar).Value = a.CCity;
      cmd.Parameters.Add("@CState", SqlDbType.NVarChar).Value = a.CState;
      cmd.Parameters.Add("@CZipCode", SqlDbType.NVarChar).Value = a.CZip;
      cmd.Parameters.Add("@AID", SqlDbType.Int).Value = aid;
      cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";

      SqlParameter output = cmd.Parameters.Add("@CID", SqlDbType.Int);
      output.Direction = ParameterDirection.Output;

      cmd.ExecuteNonQuery();
      cid = Convert.ToInt32(output.Value);
     }
     //2.1 Insert Contact Phones
     using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_CIP", con))
     {
      cmd.CommandType = CommandType.StoredProcedure;
      foreach (string s in a.CPhone.Split(','))
      {
       cmd.Parameters.Add("@CID", SqlDbType.Int).Value = cid;
       cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = s;
       cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";
       cmd.ExecuteNonQuery();
      }
     }
     //2.2 Insert Contact Emails
     using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_CIE", con))
     {
      cmd.CommandType = CommandType.StoredProcedure;
      foreach (string s in a.CEmail.Split(','))
      {
       cmd.Parameters.Add("@CID", SqlDbType.Int).Value = cid;
       cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = s;
       cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";
       cmd.ExecuteNonQuery();
      }
     }
     //3.0 Insert Billing Information
     using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_BI", con))
     {
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add("@BFirstName", SqlDbType.NVarChar).Value = a.BFirstName;
      cmd.Parameters.Add("@BLastName", SqlDbType.NVarChar).Value = a.BLastName;
      cmd.Parameters.Add("@BAddress", SqlDbType.NVarChar).Value = a.BAddress;
      cmd.Parameters.Add("@BCity", SqlDbType.NVarChar).Value = a.BCity;
      cmd.Parameters.Add("@BState", SqlDbType.NVarChar).Value = a.BState;
      cmd.Parameters.Add("@BZipCode", SqlDbType.NVarChar).Value = a.BZip;
      cmd.Parameters.Add("@AID", SqlDbType.Int).Value = aid;
      cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";

      SqlParameter output = cmd.Parameters.Add("@BID", SqlDbType.Int);
      output.Direction = ParameterDirection.Output;

      cmd.ExecuteNonQuery();
      bid = Convert.ToInt32(output.Value);
     }
     //3.1 Insert Billing Phones
     using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_BIP", con))
     {
      cmd.CommandType = CommandType.StoredProcedure;
      foreach (string s in a.BPhone.Split(','))
      {
       cmd.Parameters.Add("@BID", SqlDbType.Int).Value = bid;
       cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = s;
       cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";
       cmd.ExecuteNonQuery();
      }
     }
     //3.2 Insert Billing Emails
     using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_BIE", con))
     {
      cmd.CommandType = CommandType.StoredProcedure;
      foreach (string s in a.BEmail.Split(','))
      {
       cmd.Parameters.Add("@BID", SqlDbType.Int).Value = bid;
       cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = s;
       cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";
       cmd.ExecuteNonQuery();
      }
     }
     if (a.MarketInformation != null)
     {
      //4.0 Insert Market Information
      using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_MI", con))
      {
       cmd.CommandType = CommandType.StoredProcedure;
       int x = 0;
       while (x < a.MarketInformation.Length)
       {
        string[] mi = Regex.Split(a.MarketInformation[x], @"(?<!\$\d+),(?!\d+)");
        cmd.Parameters.Add("@AID", SqlDbType.Int).Value = aid;
        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";

        SqlParameter output = cmd.Parameters.Add("@MID", SqlDbType.Int);
        output.Direction = ParameterDirection.Output;

        cmd.ExecuteNonQuery();
        mid = Convert.ToInt32(output.Value);

        //4.1 Insert Market Region Information
        cmd.CommandText = "sp_Sample_Insert_Affil_MIR";
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@MID", SqlDbType.Int).Value = mid;
        cmd.Parameters.Add("@MarketName", SqlDbType.NVarChar).Value = mi[0];
        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";
        output = cmd.Parameters.Add("@RID", SqlDbType.Int);
        output.Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        rid = Convert.ToInt32(output.Value);

        //4.3 Insert Market Region Budget
        cmd.CommandText = "sp_Sample_Insert_Affil_MIRB";
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@RID", SqlDbType.Int).Value = rid;
        cmd.Parameters.Add("@Budget", SqlDbType.NVarChar).Value = mi[1];
        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";
        cmd.ExecuteNonQuery();

        // 4.4 Inser Call Center Name
        cmd.CommandText = "sp_Sample_Insert_Affil_MCC";
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@RID", SqlDbType.Int).Value = rid;
        cmd.Parameters.Add("@CallCenterName", SqlDbType.NVarChar).Value = string.Empty;
        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";
        output = cmd.Parameters.Add("@CCID", SqlDbType.Int);
        output.Direction = ParameterDirection.Output;
        cmd.ExecuteNonQuery();
        ccid = Convert.ToInt32(output.Value);

        //4.4 Insert Market Region Call Center Phone
        cmd.CommandText = "sp_Sample_Insert_Affil_MCCP";
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@CCID", SqlDbType.Int).Value = ccid;
        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = mi[4];
        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";
        cmd.ExecuteNonQuery();

        //4.5 Insert Market Region Call Center Hours
        cmd.CommandText = "sp_Sample_Insert_Affil_MCCH";
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@CCID", SqlDbType.Int).Value = ccid;
        cmd.Parameters.Add("@Hours", SqlDbType.NVarChar).Value = mi[5];
        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";
        cmd.ExecuteNonQuery();

        //4.6 Insert Market Region Call Center Email Delivery
        cmd.CommandText = "sp_Sample_Insert_Affil_MCCED";
        cmd.Parameters.Clear();
        cmd.Parameters.Add("@CCID", SqlDbType.Int).Value = ccid;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = mi[6];
        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "INSERT";

        cmd.ExecuteNonQuery();

        // To implement later
        //4.1 Insert Zip Codes in Market
        //4.2 Insert Zip Codes Excludes in Market
        x++;
       }
       cmd.Dispose();
      }
     }
     con.Close();
    }
    pnlForm.Visible = false;
    pnlSuccess.Visible = true;
   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());
   }
  }
  #endregion

  

  public class Affiliate
  {
   public string Company { get; set; }
   public string CFirstName { get; set; }
   public string CLastName { get; set; }
   public string CAddress { get; set; }
   public string CCity { get; set; }
   public string CState { get; set; }
   public string CZip { get; set; }
   public string CPhone { get; set; }
   public string CEmail { get; set; }
   public string BFirstName { get; set; }
   public string BLastName { get; set; }
   public string BAddress { get; set; }
   public string BCity { get; set; }
   public string BState { get; set; }
   public string BZip { get; set; }
   public string BPhone { get; set; }
   public string BEmail { get; set; }
   public string[] MarketInformation { get; set; }
   public string MarketName { get; set; }
   public string MonthlyBudget { get; set; }
   public string ZipCodesInMarket { get; set; }
   public string ZipCodesExMarket { get; set; }
   public string CallCenterPhone { get; set; }
   public string CallCenterHours { get; set; }
   public string CallCenterEmail { get; set; }
  }

  protected void btnSubmit_Click(object sender, EventArgs e)
  {
   try
   {
    Affiliate affil = new Affiliate();
    affil.Company = txtGroupName.Text;
    affil.CFirstName = txtCFirstName.Text;
    affil.CLastName = txtCLastName.Text;
    affil.CAddress = txtCAddress1.Text;
    affil.CCity = txtCCity.Text;
    affil.CState = ddlCState.SelectedValue;
    affil.CZip = txtCZip.Text;
    affil.CPhone = hdnContactPhone.Value;
    affil.CEmail = hdnContactEmail.Value;
    affil.BFirstName = txtBFirstName.Text;
    affil.BLastName = txtBLastName.Text;
    affil.BAddress = txtBAddress1.Text;
    affil.BCity = txtBCity.Text;
    affil.BState = ddlBState.SelectedValue;
    affil.BZip = txtBZip.Text;
    affil.BPhone = hdnBusinessPhone.Value;
    affil.BEmail = hdnBusinessEmail.Value;
    if (hdnMarketInformation.Value.Length > 0)
    {
     affil.MarketInformation = Regex.Split(hdnMarketInformation.Value.Substring(0, hdnMarketInformation.Value.Length - 1), "`,");
    }
    else
    {
     affil.MarketInformation = null;
    }
    saveLeadLog(affil);
    sendLeadInformation(affil);
   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());
   }
  }

  #region saveErrorLog
  protected void saveErrorLog(string error)
  {
   string filePath = string.Empty;
   string postingInformation = string.Empty;
   string applicationPath = string.Empty;

   applicationPath = AppDomain.CurrentDomain.BaseDirectory;
   postingInformation = "Begin Report: " + DateTime.Now + "\n " + error + " \nEnd Report\n";
   filePath = applicationPath + "/logs/errorlog_" + DateTime.Today.ToString("MM-dd-yyyy") + ".txt";
   try
   {
    if (!File.Exists(filePath))
    {
     using (StreamWriter w = File.CreateText(filePath))
     {
      w.Write(postingInformation);
      w.Close();
      w.Dispose();
     }
    }
    else
    {
     using (StreamWriter w = File.AppendText(filePath))
     {
      w.Write(postingInformation);
      w.Close();
      w.Dispose();
     }
    }
   }
   catch (Exception)
   {
   }
  }
  #endregion

  #region saveLeadLog
  protected void saveLeadLog(Affiliate affil)
  {
   string filePath = string.Empty;
   string postingInformation = string.Empty;
   string applicationPath = string.Empty;
   string affilinformation = affil.Company + ";" + affil.CFirstName + ";" + affil.CLastName + ";" + affil.CAddress + ";" + affil.CCity + ";" + affil.CState + ";" + affil.CZip + ";" + affil.CPhone + ";" + affil.CEmail + ";" + affil.BFirstName + ";" + affil.BLastName + ";" + affil.BAddress + ";" + affil.BCity + ";" + affil.BState + ";" + affil.BZip + ";" + affil.BPhone + ";" + affil.BEmail + ";" + txtCEmail.Text + ";" + txtCPhone.Text + ";" + txtBEmail.Text + ";" + txtBPhone.Text;
   if (affil.MarketInformation != null)
   {
    for (int x = 0; x < affil.MarketInformation.Length; x++)
    {
     affilinformation += affil.MarketInformation[x] + ";";
    }
   }
   applicationPath = AppDomain.CurrentDomain.BaseDirectory;
   postingInformation = "Begin Report: " + DateTime.Now + "\n " + affilinformation + " \nEnd Report\n";
   filePath = applicationPath + "/logs/postinglog_" + DateTime.Today.ToString("MM-dd-yyyy") + ".txt";
   try
   {
    if (!File.Exists(filePath))
    {
     using (StreamWriter w = File.CreateText(filePath))
     {
      w.Write(postingInformation);
      w.Close();
      w.Dispose();
     }
    }
    else
    {
     using (StreamWriter w = File.AppendText(filePath))
     {
      w.Write(postingInformation);
      w.Close();
      w.Dispose();
     }
    }
   }
   catch (Exception ex)
   {
    saveErrorLog(ex.ToString());
   }
  }
  #endregion
 }
}
