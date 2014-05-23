using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDSales_Entities;
using System.Data.SqlClient;
using System.Data;

namespace RDSales_Entity_Handler
{
   public class ProductHandler
    {
       public static RDProd SPGET_Products_FormRDSales()
       {

           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           DataTable dt = new DataTable();
           RDProd data = new RDProd();

          

           try
           {
               string conn_string = DBCon.ConnectionString;
               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_Products]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;

                   da.SelectCommand = cmd;
                   da.Fill(dt);




                   connection.Close();
               }


             

               data.Balm3P = Decimal.Parse(dt.Rows[0][2].ToString());
               data.Balm7P = Decimal.Parse(dt.Rows[1][2].ToString());
               data.Balm25P = Decimal.Parse(dt.Rows[2][2].ToString());
               data.Balm50P = Decimal.Parse(dt.Rows[3][2].ToString());
               data.PaspanguwaP = Decimal.Parse(dt.Rows[4][2].ToString());
               data.HCCP = Decimal.Parse(dt.Rows[5][2].ToString());
               data.KeshaNP = Decimal.Parse(dt.Rows[6][2].ToString());
               data.KeshaJP = Decimal.Parse(dt.Rows[7][2].ToString());
               data.MGP = Decimal.Parse(dt.Rows[8][2].ToString());

               data.SamahanP = Decimal.Parse(dt.Rows[9][2].ToString());
               data.Su45P = Decimal.Parse(dt.Rows[10][2].ToString());
               data.Su80P = Decimal.Parse(dt.Rows[11][2].ToString());

               data.SW30P = Decimal.Parse(dt.Rows[12][2].ToString());
               data.SW60P = Decimal.Parse(dt.Rows[13][2].ToString());
               data.SW120P = Decimal.Parse(dt.Rows[14][2].ToString());

              

           }
           catch (Exception)
           { }

           return data;
       }

       public static RDProd SPGET_Products_Bymonth(DateTime date)
       {

           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           DataTable dt = new DataTable();
           RDProd data = new RDProd();

           string d = date.ToString("yyyy-MM-dd");

           try
           {
               string conn_string = DBCon.ConnectionString;
               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_Products_Bymonth]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                 
                   cmd.Parameters.Add(new SqlParameter("@Date", d));
                   da.SelectCommand = cmd;
                   da.Fill(dt);




                   connection.Close();
               }



               data.AkalapalithaP = Decimal.Parse(dt.Rows[0][3].ToString());
               data.Balm3P = Decimal.Parse(dt.Rows[1][3].ToString());
               data.Balm7P = Decimal.Parse(dt.Rows[2][3].ToString());
               data.Balm25P = Decimal.Parse(dt.Rows[3][3].ToString());
               data.Balm50P = Decimal.Parse(dt.Rows[4][3].ToString());
               data.PaspanguwaP = Decimal.Parse(dt.Rows[5][3].ToString());
               data.HCCP = Decimal.Parse(dt.Rows[6][3].ToString());
               data.KeshaNP = Decimal.Parse(dt.Rows[7][3].ToString());
               data.KeshaJP = Decimal.Parse(dt.Rows[8][3].ToString());
               data.MGP = Decimal.Parse(dt.Rows[9][3].ToString());

               data.SamahanP = Decimal.Parse(dt.Rows[10][3].ToString());
               data.Su45P = Decimal.Parse(dt.Rows[11][3].ToString());
               data.Su80P = Decimal.Parse(dt.Rows[12][3].ToString());

               data.SW30P = Decimal.Parse(dt.Rows[13][3].ToString());
               data.SW60P = Decimal.Parse(dt.Rows[14][3].ToString());
               data.SW120P = Decimal.Parse(dt.Rows[15][3].ToString());



           }
           catch (Exception)
           { }

           return data;
       }


       public static DataTable SPGET_RD_BasicProdctsbyPrefix(string prefix)
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
                   cmd = new SqlCommand("[dbo].[SPGET_BasicProdctsbyPrefix]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@prefix", prefix));
                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();
               }

           }
           catch (Exception)
           { }

           return dt;
       }

       public static string splitProdName(string prod)
       {
           try
           {
               String[] a = prod.Split(':');
               return a[0];
           }
           catch (Exception)
           {
               return "";
           }
       }

       public static string splitProdCode(string prod)
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


     

       public static DataTable SPGET_Products_ByBasicProd(string Pcode)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           string asm = "";
           try
           {
               string conn_string = DBCon.ConnectionString;


               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_Products_ByBasicProd]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@Bcode", Pcode));

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
