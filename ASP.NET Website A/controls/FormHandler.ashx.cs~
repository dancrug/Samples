using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;

namespace SampleAffilForm.controls
{
 /// <summary>
 /// Summary description for FormHandler
 /// </summary>
 public class FormHandler : IHttpHandler
 {

  public void ProcessRequest(HttpContext context)
  {
   var requestType = string.Empty;
   var keyword = string.Empty;
   requestType = context.Request.QueryString["type"];
   if (context.Request.QueryString["keyword"] != null)
   {
    keyword = context.Request.QueryString["keyword"];
   }
   switch (requestType)
   {
    case "autocomplete":
     context.Response.ContentType = "application/json";
     context.Response.HeaderEncoding = Encoding.UTF8;
     context.Response.Write(new JavaScriptSerializer().Serialize(GetZipCodes(keyword)));
     break;
    default: break;
   }
  }

  public bool IsReusable
  {
   get
   {
    return false;
   }
  }

  public List<NameValue> GetZipCodes(string keyword)
  {
   List<NameValue> zipcode = new List<NameValue>();

   using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionInformation"].ToString()))
   {
    using (SqlCommand cmd = new SqlCommand("sp_Sample_ReturnZipCode", con))
    {
     con.Open();
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@keyword", SqlDbType.NVarChar).Value = keyword;

     using (SqlDataReader reader = cmd.ExecuteReader())
     {
      while (reader.Read())
      {
       zipcode.Add(new NameValue { Value = reader.GetString(0), Name = reader.GetString(1)});
      }
     }
     cmd.Dispose();
    }
    con.Close();
   }
   return zipcode;
  }
  public class NameValue
  {
   public string Value { get; set; }
   public string Name { get; set; }
  }
 }
}