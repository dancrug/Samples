﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Xml;

namespace SampleAffilForm
{
 public class SampleService
 {
  public AffiliateProperty affil = new AffiliateProperty();

  /// <summary>
  /// Inserts the note into DB.
  /// </summary>
  /// <param name="note"></param>
  /// <param name="notecategory"></param>
  /// <param name="notedate"></param>
  /// <param name="id"></param>
  public void insertNotes(string note, string notecategory, string notedate, int id)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_Notes", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@NoteSummary", SqlDbType.NVarChar, 1000).Value = HttpUtility.HtmlEncode(note);
     cmd.Parameters.Add("@NoteCategory", SqlDbType.NVarChar, 50).Value = HttpUtility.HtmlEncode(notecategory);
     cmd.Parameters.Add("@NoteDate", SqlDbType.DateTime).Value = Convert.ToDateTime(notedate);
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }


  /// <summary>
  /// Updates the current note user is editing.
  /// </summary>
  /// <param name="note"></param>
  /// <param name="notecategory"></param>
  /// <param name="notedate"></param>
  /// <param name="id"></param>
  public void updateNotes(string note, string notecategory, string notedate, int id)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_Notes", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "UPDATE";
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@NoteSummary", SqlDbType.NVarChar, 1000).Value = HttpUtility.HtmlEncode(note);
     cmd.Parameters.Add("@NoteCategory", SqlDbType.NVarChar, 50).Value = HttpUtility.HtmlEncode(notecategory);
     cmd.Parameters.Add("@NoteDate", SqlDbType.DateTime).Value = Convert.ToDateTime(notedate);
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }

  /// <summary>
  /// Soft deletes the note.
  /// </summary>
  /// <param name="id"></param>
  public void deleteNotes(int id)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_Notes", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "DELETE";
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@NoteSummary", SqlDbType.NVarChar, 1000).Value = string.Empty;
     cmd.Parameters.Add("@NoteCategory", SqlDbType.NVarChar, 50).Value = string.Empty;
     cmd.Parameters.Add("@NoteDate", SqlDbType.DateTime).Value = DateTime.Now;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }
  /* Insert Data */
  /// <summary>
  /// Insert new affiliate into DB.
  /// </summary>
  /// <param name="affil"></param>
  public void insertAffiliate(string affil)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar, 1000).Value = HttpUtility.HtmlEncode(affil);
     cmd.Parameters.Add("@AID", SqlDbType.BigInt).Value = 0;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }

  /// <summary>
  /// Insert new call center into DB.
  /// </summary>
  /// <param name="cc"></param>
  public void insertCC(string cc)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_CC", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@CallCenterName", SqlDbType.NVarChar, 1000).Value = HttpUtility.HtmlEncode(cc);
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }


  /// <summary>
  /// Insert contact information into DB.
  /// </summary>
  /// <param name="firstname"></param>
  /// <param name="lastname"></param>
  /// <param name="address"></param>
  /// <param name="city"></param>
  /// <param name="state"></param>
  /// <param name="zip"></param>
  /// <param name="id"></param>
  public void insertContact(string firstname, string lastname, string address, string city, string state, string zip, int id)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_CI", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = HttpUtility.HtmlEncode(firstname);
     cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = HttpUtility.HtmlEncode(lastname);
     cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 250).Value = HttpUtility.HtmlEncode(address);
     cmd.Parameters.Add("@City", SqlDbType.NVarChar, 200).Value = HttpUtility.HtmlEncode(city);
     cmd.Parameters.Add("@State", SqlDbType.NVarChar, 10).Value = HttpUtility.HtmlEncode(state);
     cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 5).Value = HttpUtility.HtmlEncode(zip);
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
     cmd.Parameters.Add("@AID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = true;
     cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = 0;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }

  /// <summary>
  /// Insert contact email into DB.
  /// </summary>
  /// <param name="email"></param>
  /// <param name="cid"></param>
  /// <param name="id"></param>
  public void insertContactEmail(string email, int cid, int id)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_CIE", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 200).Value = HttpUtility.HtmlEncode(email);
     cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = true;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = cid;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }

  /// <summary>
  /// Insert Contact Phone into DB
  /// </summary>
  /// <param name="phone"></param>
  /// <param name="cid"></param>
  /// <param name="id"></param>
  public void insertContactPhone(string phone, int cid, int id)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_CIP", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 200).Value = HttpUtility.HtmlEncode(phone);
     cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = true;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@CID", SqlDbType.BigInt).Value = cid;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }

  /// <summary>
  /// Insert billing information into DB.
  /// </summary>
  /// <param name="firstname"></param>
  /// <param name="lastname"></param>
  /// <param name="address"></param>
  /// <param name="city"></param>
  /// <param name="state"></param>
  /// <param name="zip"></param>
  /// <param name="id"></param>
  public void insertBilling(string firstname, string lastname, string address, string city, string state, string zip, int id)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_BI", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = HttpUtility.HtmlEncode(firstname);
     cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = HttpUtility.HtmlEncode(lastname);
     cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 250).Value = HttpUtility.HtmlEncode(address);
     cmd.Parameters.Add("@City", SqlDbType.NVarChar, 200).Value = HttpUtility.HtmlEncode(city);
     cmd.Parameters.Add("@State", SqlDbType.NVarChar, 10).Value = HttpUtility.HtmlEncode(state);
     cmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 5).Value = HttpUtility.HtmlEncode(zip);
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
     cmd.Parameters.Add("@AID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = true;
     cmd.Parameters.Add("@BID", SqlDbType.BigInt).Value = 0;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }

  /// <summary>
  /// Insert billing email into DB.
  /// </summary>
  /// <param name="email"></param>
  /// <param name="bid"></param>
  /// <param name="id"></param>
  public void insertBillingEmail(string email, int bid, int id)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_BIE", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 200).Value = HttpUtility.HtmlEncode(email);
     cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = true;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@BID", SqlDbType.BigInt).Value = bid;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }

  /// <summary>
  /// Insert billing phone into DB.
  /// </summary>
  /// <param name="phone"></param>
  /// <param name="bid"></param>
  /// <param name="id"></param>
  public void insertBillingPhone(string phone, int bid, int id)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_BIP", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 200).Value = HttpUtility.HtmlEncode(phone);
     cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = true;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@BID", SqlDbType.BigInt).Value = bid;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }

  /// <summary>
  /// Insert market information into DB.
  /// </summary>
  /// <param name="marketname"></param>
  /// <param name="monthlybudget"></param>
  /// <param name="status"></param>
  /// <param name="inzip"></param>
  /// <param name="exzip"></param>
  /// <param name="id"></param>
  /// <returns></returns>
  public int insertMarket(string marketname, string monthlybudget, string status, string inzip, string exzip, int id)
  {
   int marketid = 0;
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_MI", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@MarketName", SqlDbType.NVarChar, 150).Value = HttpUtility.HtmlEncode(marketname);
     cmd.Parameters.Add("@MonthlyBudget", SqlDbType.NVarChar, 100).Value = HttpUtility.HtmlEncode(monthlybudget);
     cmd.Parameters.Add("@RunningStatus", SqlDbType.NVarChar, 100).Value = HttpUtility.HtmlEncode(status);
     cmd.Parameters.Add("@ABID", SqlDbType.BigInt).Value = 0;
     cmd.Parameters.Add("@IncludedZipStatus", SqlDbType.NVarChar, 50).Value = inzip;
     cmd.Parameters.Add("@ExcludedZipStatus", SqlDbType.NVarChar, 50).Value = exzip;
     cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = 0;
     cmd.Parameters.Add("@MID", SqlDbType.BigInt).Value = 0;
     cmd.Parameters.Add("@AID", SqlDbType.BigInt).Value = id;
     //SqlParameter mid = cmd.Parameters.Add("@MID", SqlDbType.Int);
     SqlParameter rid = cmd.Parameters.Add("@RID", SqlDbType.Int);
     rid.Direction = ParameterDirection.Output;
     cmd.ExecuteNonQuery();
     marketid = int.Parse(rid.Value.ToString());
    }
    con.Close();
    return marketid;
   }
  }

  /// <summary>
  /// Insert market call center information into DB.
  /// </summary>
  /// <param name="callcenterid"></param>
  /// <param name="callcenterphone"></param>
  /// <param name="rid"></param>
  /// <param name="id"></param>
  /// <param name="status"></param>
  public void insertMarketCC(int callcenterid, string callcenterphone, int rid, int id, string status)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_MCC", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@ACCID", SqlDbType.BigInt).Value = 0;
     cmd.Parameters.Add("@CallCenterName", SqlDbType.NVarChar, 100).Value = string.Empty;
     cmd.Parameters.Add("@ACCHID", SqlDbType.BigInt).Value = 0;
     cmd.Parameters.Add("@ACCPID", SqlDbType.BigInt).Value = 0;
     cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar, 100).Value = callcenterphone;
     cmd.Parameters.Add("@MarketName", SqlDbType.NVarChar, 100).Value = string.Empty;
     cmd.Parameters.Add("@RID", SqlDbType.BigInt).Value = rid;
     cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = true;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = status;
     cmd.Parameters.Add("@CCID", SqlDbType.BigInt).Value = callcenterid;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }
  #region insertMarketEALD
  /// <summary>
  /// Insert market email address for lead delivery
  /// </summary>
  /// <param name="id"></param>
  /// <param name="emailaddresses"></param>
  public void insertMarketEALD(int id, string emailaddresses)
  {
   emailaddresses = emailaddresses.Replace(Environment.NewLine, "<br />");
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_EALD", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 100).Value = emailaddresses;
     cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "INSERT";
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }
  #endregion
  #region updateRunningStatus
  /// <summary>
  /// Updates running status.
  /// </summary>
  /// <param name="status"></param>
  /// <param name="id"></param>
  public void updateRunningStatus(string status, int id)
  {
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Insert_Affil_RunningStatus", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "UPDATE";
     cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = status;
     cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
     cmd.ExecuteNonQuery();
    }
    con.Close();
   }
  }
  #endregion
  #region returnRunningStatus
  /// <summary>
  /// Returns running status.
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public string returnRunningStatus(int id)
  {
   string result = string.Empty;
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_Affil_RunningStatus", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
     result = cmd.ExecuteScalar().ToString();
    }
    con.Close();
    return result;

   }
  }
  #endregion
  #region populateStates - Populates the states in the form.
  /// <summary>
  /// Populates the states list.
  /// </summary>
  /// <param name="ddl"></param>
  /// <param name="applicationPath"></param>
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
  #region populateContactDropDown
  /// <summary>
  /// Populates the contact information when adding email, phone, and billing to associate to an initial contact.
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public List<AffiliateProperty> populateContactDropDown(int id)
  {
   List<AffiliateProperty> ls = new List<AffiliateProperty>();
   ls.Add(new AffiliateProperty { CID = 0, CFullName = "Select Contact Association" });
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_Affil_CI", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = Convert.ToInt32(id);
     using (var reader = cmd.ExecuteReader())
     {
      while (reader.Read())
      {
       ls.Add(new AffiliateProperty { CID = Convert.ToInt32(reader.GetInt64(0)), CFullName = reader.GetString(1) + " " + reader.GetString(2) });
      }
     }
    }
    con.Close();
   }
   return ls;
  }
  #endregion
  #region populateBillingDropDown
  /// <summary>
  /// Populates billing association drop downs.
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public List<AffiliateProperty> populateBillingDropDown(int id)
  {
   List<AffiliateProperty> ls = new List<AffiliateProperty>();
   ls.Add(new AffiliateProperty { BID = 0, BFullName = "Select Billing Association" });
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_Affil_BI", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = Convert.ToInt32(id);
     using (var reader = cmd.ExecuteReader())
     {
      while (reader.Read())
      {
       ls.Add(new AffiliateProperty { BID = Convert.ToInt32(reader.GetInt64(0)), BFullName = reader.GetString(1) + " " + reader.GetString(2) });
      }
     }
    }
    con.Close();
   }
   return ls;
  }
  #endregion
  #region populateMarketDropDown
  /// <summary>
  /// Populate market drop down to relate a call center to a market. 
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public List<AffiliateProperty> populateMarketDropDown(int id)
  {
   List<AffiliateProperty> ls = new List<AffiliateProperty>();
   ls.Add(new AffiliateProperty { MID = 0, MarketName = "Select Market" });
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_Affil_MI", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = Convert.ToInt32(id);
     using (var reader = cmd.ExecuteReader())
     {
      while (reader.Read())
      {
       ls.Add(new AffiliateProperty { MID = Convert.ToInt32(reader.GetInt64(0)), MarketName = reader.GetString(2) });
      }
     }
    }
    con.Close();
   }
   return ls;
  }
  #endregion
  #region populateCallCenterDropDown
  /// <summary>
  /// Populates the drop down for vendor call centers when adding a call center.
  /// </summary>
  /// <returns></returns>
  public List<AffiliateProperty> populateCallCenterDropDown()
  {
   List<AffiliateProperty> callcenters = new List<AffiliateProperty>();
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_Affil_CC", con))
    {
     con.Open();
     cmd.CommandType = CommandType.StoredProcedure;
     using (SqlDataReader reader = cmd.ExecuteReader())
     {
      while (reader.Read())
      {
       callcenters.Add(new AffiliateProperty { CCID = Convert.ToInt32(reader.GetInt64(0)), CallCenterName = reader.GetString(1) });
      }
     }
     cmd.Dispose();
    }
    con.Close();
   }
   return callcenters;
  }
  #endregion
  #region populateAffiliateName
  /// <summary>
  /// Populates the affiliate name for the header.
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public string populateAffiliateName(int id)
  {
   string name = string.Empty;

   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_Affil", con))
    {
     con.Open();
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(id);
     using (SqlDataReader reader = cmd.ExecuteReader())
     {
      while (reader.Read())
      {
       name = reader.GetString(1);
      }
     }
     cmd.Dispose();
    }
    con.Close();
   }
   return name;
  }
  #endregion
  #region populateNoteCategoryFilter
  /// <summary>
  /// Allows filtering of the notes by category (currently hidden).
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public List<AffiliateProperty> populateNoteCategoryFilter(int id)
  {
   List<AffiliateProperty> categories = new List<AffiliateProperty>();
   categories.Add(new AffiliateProperty { NoteCategory = "All" });
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_Affil_Notes", con))
    {
     con.Open();
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(id);
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "FILTER";
     cmd.Parameters.Add("@FilterBy", SqlDbType.NVarChar, 50).Value = "";

     using (SqlDataReader reader = cmd.ExecuteReader())
     {
      while (reader.Read())
      {
       categories.Add(new AffiliateProperty { NoteCategory = reader.GetString(0) });
      }
     }
     cmd.Dispose();
    }
    con.Close();
   }
   return categories;
  }
  #endregion
  #region filterNoteCategory
  /// <summary>
  /// Populates the categories dropdown to filter by.
  /// </summary>
  /// <param name="filterby"></param>
  /// <param name="id"></param>
  /// <returns></returns>
  public List<AffiliateProperty> filterNoteCategory(string filterby, int id)
  {
   List<AffiliateProperty> ds = new List<AffiliateProperty>();
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_Affil_Notes", con))
    {
     con.Open();
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(id);
     cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "FILTERBY";
     cmd.Parameters.Add("@FilterBy", SqlDbType.NVarChar, 50).Value = filterby;

     using (SqlDataReader reader = cmd.ExecuteReader())
     {
      while (reader.Read())
      {
       ds.Add(new AffiliateProperty { NID = Convert.ToInt32(reader.GetInt64(0)), Notes = reader.GetString(1), NoteCategory = reader.GetString(2) });
      }
     }
     cmd.Dispose();
    }
    con.Close();
   }
   return ds;
  }
  #endregion
 }

 /// <summary>
 /// Affiliate Property stores the data for the current affiliate.
 /// </summary>
 public class AffiliateProperty
 {
  public int AID { get; set; }
  public int CID { get; set; }
  public int BID { get; set; }
  public int MID { get; set; }
  public int RID { get; set; }
  public int CCID { get; set; }
  public int NID { get; set; }
  public string GroupName { get; set; }
  public string ContractStatus { get; set; }
  public string PrepaymentInvoiceStatus { get; set; }
  public string CampaignStatus { get; set; }
  public string LeadPostCampaignCreation { get; set; }
  public string AssetsDeliveredStatus { get; set; }
  public string TestLeads { get; set; }
  public string CFirstName { get; set; }
  public string CLastName { get; set; }
  public string CFullName { get; set; }
  public string CAddress { get; set; }
  public string CCity { get; set; }
  public string CState { get; set; }
  public string CZip { get; set; }
  public string CPhone { get; set; }
  public string CEmail { get; set; }
  public string BFirstName { get; set; }
  public string BLastName { get; set; }
  public string BFullName { get; set; }
  public string BAddress { get; set; }
  public string BCity { get; set; }
  public string BState { get; set; }
  public string BZip { get; set; }
  public string BPhone { get; set; }
  public string BEmail { get; set; }
  public string MarketName { get; set; }
  public string MonthlyBudget { get; set; }
  public string ZipCodesIncludedStatus { get; set; }
  public string ZipCodesExcludedStatus { get; set; }
  public string ZipCodesInMarket { get; set; }
  public string ZipCodesExMarket { get; set; }
  public string CallCenterName { get; set; }
  public string CallCenterPhone { get; set; }
  public string CallCenterHours { get; set; }
  public string CallCenterEmail { get; set; }
  public string Notes { get; set; }
  public string NoteCategory { get; set; }
 }
}
