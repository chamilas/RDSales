using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RDSales_Entity_Handler
{
   public class CustomerHandler
    {
         public static DataTable SPGET_DS_CustomersbyPrefix(string prefx)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           
           try
           {
               string conn_string = DBCon.ConnectionString;


               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_DS_CustomersbyPrefix]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@prefix", prefx));

                   da.SelectCommand = cmd;
                   da.Fill(dt);



                   connection.Close();
               }

           }
           catch (Exception)
           { }

           return dt;
       }

         public static string splitCustomerCode(string prod)
         {
             try
             {
                 String[] a = prod.Split(':');
                 return a[1];
             }
             catch (Exception)
             {
                 return "";
             }
         }
    }
    
}
