using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDSales_Entities;
using System.Data;
using System.Data.SqlClient;

namespace RDSales_Entity_Handler
{
   public class TerritoryHandler
    {
       //get List Of Territories for each region
       public static List<Territory> SPGET_TerritoryByRegion(int regID)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           List<Territory> ListTerr = new List<Territory>();

           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_TerritoriesByRegion]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@RegionID", regID));


                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();

                   foreach (DataRow row in dt.Rows)
                   {

                       Territory Terobj = new Territory();
                       Terobj.TerritoryID = Int32.Parse(row[0].ToString());
                       Terobj.TerritoryName = row[1].ToString();
                       Terobj.Region = Int32.Parse(row[2].ToString());
                       //Terobj.Distributor = Int32.Parse(row[2].ToString());

                       ListTerr.Add(Terobj);

                   }


               }

           }
           catch (Exception)
           {

           }
           return ListTerr;
       }

       public static DataTable Load_Territores_ByRegion(int RegionID)
       {
           DataTable dt = new DataTable();

           try
           {
               
                SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@RegionID", RegionID)};

              

              dt= Execute.RunSP_DataTable(ConnectionStringClass.GetConnection(), "SPGET_TerritoriesByRegion", paramList);

              return dt;
           }
           catch (Exception)
           {
               return dt;
           }
       }

       public static string[] Load_TerritoresList_ByRegion(int RegionID)
       {
           DataTable dt = new DataTable();
           string[] list;

           try
           {

               SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@RegionID", RegionID)};



               dt = Execute.RunSP_DataTable(ConnectionStringClass.GetConnection(), "SPGET_TerritoriesByRegion", paramList);
               list = new string[dt.Rows.Count];
               int x=0;
               foreach (DataRow row in dt.Rows)
               {
                   list[x] = row[1].ToString();
                   x++;
               }

               return list;
           }
           catch (Exception)
           {
               return null;
           }
       }
    }
}
