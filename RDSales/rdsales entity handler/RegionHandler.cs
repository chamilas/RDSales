using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDSales_Entities;
using System.Data;
using System.Data.SqlClient;

namespace RDSales_Entity_Handler
{
   public class RegionHandler
    {

       public static Region SPGET_RegionByUser(int userID)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           Region objReg = new Region();

           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_RegionByUser]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@UserID", userID));


                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();

                   foreach (DataRow row in dt.Rows)
                   {
                       objReg.RegionID = Int32.Parse(row[0].ToString());
                       objReg.RegionName = row[1].ToString();
                       objReg.ASM = Int32.Parse(row[2].ToString());


                   }


               }

           }
           catch (Exception)
           {

           }
           return objReg;
       }

       public static List<Region> SPGET_Regions()
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           List<Region> ListRegion = new List<Region>();

           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_Regions]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;

                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();

                   foreach (DataRow row in dt.Rows)
                   {
                       Region objReg = new Region();
                       objReg.RegionID = Int32.Parse(row[0].ToString());
                       objReg.RegionName = row[1].ToString();
                       objReg.ASM = Int32.Parse(row[2].ToString());

                       ListRegion.Add(objReg);
                   }


               }

           }
           catch (Exception)
           {

           }
           return ListRegion;
       }

       public static List<Region> SPGET_RegionByUser_list(int ID)
       {
           DataTable dt=new DataTable();
           List<Region> list = new List<Region>();
           try
           {

               SqlParameter[] paramList = new SqlParameter[] {
               new SqlParameter("@UserID", ID)};
               dt=Execute.RunSP_DataTable(ConnectionStringClass.GetConnection(), "SPGET_RegionByUser", paramList);

               foreach (DataRow row in dt.Rows)
               {
                   Region reg = new Region();
                   reg.RegionID = Int32.Parse(row[0].ToString());
                   reg.RegionName = row[1].ToString();
                   reg.ASM = Int32.Parse(row[2].ToString());
                   list.Add(reg);
               }

               return list;

           }
           catch (Exception)
           {
               return null;
           }

       }

       public static int GetRegID(string value)
       {
           int result = -99;
           try
           {
               string[] arry;
               arry = value.Split(':');
               result = Int32.Parse(arry[1].ToString());
           }
           catch (Exception ex)
           { }
           return result;
       }

       public static Region SPGET_RegionByID(int RegID)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           Region objReg = new Region();

           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_RegionDetails_ByRegionID]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@RegID", RegID));


                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();

                   foreach (DataRow row in dt.Rows)
                   {
                       objReg.RegionID = Int32.Parse(row[0].ToString());
                       objReg.RegionName = row[1].ToString();
                       objReg.ASM = Int32.Parse(row[2].ToString());


                   }


               }

           }
           catch (Exception)
           {

           }
           return objReg;
       }

       public static string SPGET_ASMNameByREgionName_FromRDSales(string region)
       {

           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           string asm = "";
           try
           {
               string conn_string = DBCon.ConnectionString;


               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_ASMNameByRegionName]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@Region", region));


                   da.SelectCommand = cmd;
                   asm = cmd.ExecuteScalar().ToString();


                   connection.Close();
               }

           }
           catch (Exception)
           { }

           return asm;
       }

    }
}
