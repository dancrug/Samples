using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SampleAffilForm.controls
{
 /// <summary>
 /// Summary description for AffiliateHandler
 /// </summary>
 public class AffiliateHandler : IHttpHandler
 {

  public void ProcessRequest(HttpContext context)
  {
   string type = context.Request.QueryString["autocomplete"];
   if (type == "callcenter")
   {
    string term = context.Request.QueryString["term"];
    context.Response.ContentType = "application/json";
    context.Response.HeaderEncoding = Encoding.UTF8;
    context.Response.Write(new JavaScriptSerializer().Serialize(GetCallCenter()));
   }
   if (type == "market")
   {
    string term = context.Request.QueryString["term"];
    string id = context.Request.QueryString["id"];
    context.Response.ContentType = "application/json";
    context.Response.HeaderEncoding = Encoding.UTF8;
    context.Response.Write(new JavaScriptSerializer().Serialize(GetMarketRegion(id)));
   }
   if (type == "affiliate")
   {
    string term = context.Request.QueryString["term"];
    string id = context.Request.QueryString["id"];
    context.Response.ContentType = "application/json";
    context.Response.HeaderEncoding = Encoding.UTF8;
    context.Response.Write(new JavaScriptSerializer().Serialize(GetAffiliateName(id)));
   }
   if (type == "duplicate")
   {
    string term = context.Request.QueryString["term"];
    string id = context.Request.QueryString["id"];
    context.Response.ContentType = "application/json";
    context.Response.HeaderEncoding = Encoding.UTF8;
    context.Response.Write(new JavaScriptSerializer().Serialize(populateBillingDupDropDown(id)));
   }
  }

  public bool IsReusable
  {
   get
   {
    return false;
   }
  }

  public List<NameValue> GetCallCenter()
  {
   List<NameValue> callcenters = new List<NameValue>();

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
       callcenters.Add(new NameValue { Value = reader.GetInt64(0).ToString(), Name = reader.GetString(1) });
      }
     }
     cmd.Dispose();
    }
    con.Close();
   }
   return callcenters;
  }
  public List<string> GetMarketRegion(string id)
  {
   List<string> list = new List<string>();

   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_Affil_MI", con))
    {
     con.Open();
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(id);
     using (SqlDataReader reader = cmd.ExecuteReader())
     {
      while (reader.Read())
      {
       list.Add(reader.GetInt64(0).ToString());
      }
     }
     cmd.Dispose();
    }
    con.Close();
   }
   return list;
  }
  public string GetAffiliateName(string id)
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
  #region populateContactDropDown
  public List<string> populateBillingDupDropDown(string id)
  {
   List<string> ls = new List<string>();
   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    con.Open();
    using (SqlCommand cmd = new SqlCommand("sp_Sample_Return_Affil_CID", con))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
     using (var reader = cmd.ExecuteReader())
     {
      while (reader.Read())
      {
       ls.Add(reader.GetString(0));
       ls.Add(reader.GetString(1));
       ls.Add(reader.GetString(2));
       ls.Add(reader.GetString(3));
       ls.Add(reader.GetString(4));
       ls.Add(reader.GetString(5));
      }
     }
    }
    con.Close();
   }
   return ls;
  }
  #endregion
  public class NameValue
  {
   public string Value { get; set; }
   public string Name { get; set; }
  }
 }
}