using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RDSales_Entity_Handler
{
   public class DirectSalesHandler
    {
       public static DataTable SPGET_DirectSales_INProductType(DateTime date)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           try
           {
               string conn_string = DBCon.ConnectionString;
               string statdate = RDSales_Entity_Handler.DailySalesHandler.getStartdateofMonth(date);
               string enddate = date.ToString("yyyy-MM-dd");


               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_DirectSales_INProductType]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@firstOfMonth", statdate));
                   cmd.Parameters.Add(new SqlParameter("@Date", enddate));
                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();
               }

           }
           catch (Exception)
           { }

           return dt;
       }

       public static DataTable SPGET_DirectSales_ByCustomer(DateTime date, string cusCode)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           try
           {
               string conn_string = DBCon.ConnectionString;
               string statdate = RDSales_Entity_Handler.DailySalesHandler.getStartdateofMonth(date);
               string enddate = date.ToString("yyyy-MM-dd");


               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_DirectSales_PerCustomer]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@firstOfMonth", statdate));
                   cmd.Parameters.Add(new SqlParameter("@Date", enddate));
                   cmd.Parameters.Add(new SqlParameter("@cusCode", cusCode));
                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();
               }

           }
           catch (Exception)
           { }

           return dt;
       }

    }
}
