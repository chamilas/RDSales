using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;

namespace RDSales_Entity_Handler
{
   public class DBCon
    {
       //public static string ConnectionString = @"Data Source=(local);Initial Catalog=RDSales;Integrated Security=True";
       //public static string ConnectionString = "Data Source=(local);Initial Catalog=RDSales;Persist Security Info=True;User ID=sa;Password=dawnangel_withme";
       public static string ConnectionString = "Data Source=THILINA_ARIMAC;Initial Catalog=RDSales;Integrated Security=True";

       static string error = "";
       
       public DBCon()
        {

        }

       //Execute select query : returns a dataset
       public static DataTable db_Select_Query(string strQuery)
       {
           DataTable dSet = new DataTable();

           try
           {
               using (SqlConnection connection = new SqlConnection(ConnectionString))
               {
                   connection.Open();
                   SqlDataAdapter DA = new SqlDataAdapter(strQuery, connection);
                   DA.Fill(dSet);

                   
               }
               return dSet;
           }

           catch (Exception)
           {
               
               return dSet;
              
           }
       }

       //Execute Insert,Update, Delete queries
       public static string db_Update_Delete_Query(string strQuery)
       {
           try
           {
               using (SqlConnection connection = new SqlConnection(ConnectionString))
               {
                   connection.Open();
                   SqlCommand command = new SqlCommand(strQuery, connection);
                   command.ExecuteNonQuery();

                   error = "Success!";
               }
           }
           catch (Exception)
           {
               error = "Data Insert/Update/Delete failed!";

           }

           return error;
       }

       public static string GetServerDate()
       {
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           string date = "";
          
           
           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {
                  
                   connection.Open();
                   cmd = new SqlCommand("SELECT CONVERT(VARCHAR(10),GETDATE(),101)", connection);
                   cmd.CommandType = CommandType.Text;
                   string d = cmd.ExecuteScalar().ToString();
                   //date = d.ToString("dd/MM/yyyy");
                   date = d;
                   connection.Close();

                  
               }

           }
           catch (Exception)
           {
               return "error";
           }

           return date;
       }

       public static bool CheckSQLServer()
       {
           try
           {
               string SQLHost = "IT-CHAMILA";
               int SQLPort = 1433;

               IPHostEntry IPHost = new IPHostEntry();
               IPHost = Dns.Resolve(SQLHost);

               IPAddress IPAddr = IPHost.AddressList[0];

               TcpClient TcpCli = new TcpClient();
               TcpCli.Connect(IPAddr, SQLPort);
               TcpCli.Close();

               return true;
           }
           catch
           {
               return false;
           }
       }

    }
}
