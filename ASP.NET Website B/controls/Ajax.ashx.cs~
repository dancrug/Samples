using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ReplaceMyWindows.controls
{
 /// <summary>
 /// Summary description for Ajax
 /// </summary>
 public class Ajax : IHttpHandler
 {
  string email = string.Empty;

  public void ProcessRequest(HttpContext context)
  {
   context.Response.ContentType = "text/plain";

   if (context.Request["email"] != null)
   {
    email = context.Request["email"].ToString ();
   }
   try
   {
    string connectionInfo = ConfigurationManager.AppSettings["ConnectionInfo"];

    using (SqlConnection connection = new SqlConnection(connectionInfo))
    {
     SqlCommand cmd = new SqlCommand("Sample_ReturnEmailAddresses", connection);
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
     connection.Open();
     if((int)cmd.ExecuteScalar() >= 1)
     {
      context.Response.Write(false);
     }
     else
     {
      context.Response.Write(true);
     }
     connection.Close();
    }
   }
   catch (Exception ex)
   {
    context.Response.Write(ex.ToString());
   }
  }

  public bool IsReusable
  {
   get
   {
    return false;
   }
  }

 }
}