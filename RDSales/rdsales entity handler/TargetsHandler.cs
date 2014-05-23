using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RDSales_Entities;

namespace RDSales_Entity_Handler
{
   public class TargetsHandler
    {
       public static bool SPCHECK_TargetsExists(string date, int region)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           bool res = false;
           try
           {
               string conn_string = DBCon.ConnectionString;
               DateTime d = System.DateTime.Parse(date);
               string edate = d.ToString("yyyy-MM-dd");

            

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPCHECK_TargetsExists]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@Date", date));
                   cmd.Parameters.Add(new SqlParameter("@RegionID", region));

                   //declare output parameter
                   SqlParameter result = new SqlParameter("@result", SqlDbType.Bit);
                   result.Direction = ParameterDirection.Output;
                   cmd.Parameters.Add(result);

                   cmd.ExecuteNonQuery();
                   connection.Close();

                   res = (bool)cmd.Parameters["@result"].Value;


               }

           }
           catch (Exception)
           {
               return false;
           }


           return res;
       }

       public static bool SPADD_RD_Targets(string date, int TerrID, string ProdCode, decimal target,int user)
       {

           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPADD_RD_Targets]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@Date", date));
                   cmd.Parameters.Add(new SqlParameter("@TerrID", TerrID));
                   cmd.Parameters.Add(new SqlParameter("@ProdCode", ProdCode));
                   cmd.Parameters.Add(new SqlParameter("@Target", target));
                   cmd.Parameters.Add(new SqlParameter("@UserID", user));
               


                   da.InsertCommand = cmd;
                   da.InsertCommand.ExecuteNonQuery();
                   connection.Close();
               }

               return true;

           }
           catch (Exception)
           {
               return false;
           }

       }
       
       public static List<RDTarget> SPGET_TargetsPer_Territory(string date, int terr)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           List<RDTarget> target = new List<RDTarget>();

           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_TargetsPer_Territory]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@Date", date));
                   cmd.Parameters.Add(new SqlParameter("@Territory", terr));

                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();

                   foreach (DataRow row in dt.Rows)
                   {
                       RDTarget objtarget = new RDTarget();

                       objtarget.ID = Int32.Parse(row[0].ToString());
                       objtarget.EntryTime = DateTime.Parse(row[1].ToString());
                       objtarget.Date = row[2].ToString();
                       objtarget.UserId = Int32.Parse(row[6].ToString());
                       objtarget.TerrID = Int32.Parse(row[3].ToString());
                       objtarget.prodcode = row[4].ToString();
                       objtarget.Target = decimal.Parse(row[5].ToString());
                       objtarget.confirmed = Boolean.Parse(row[7].ToString());


                       target.Add(objtarget);
                   }


               }

           }
           catch (Exception)
           {

           }
           return target;
       }

       public static DataTable Get_TargetsPer_Territory(DateTime date,DateTime firstOfMonth, int terr)
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
                   cmd = new SqlCommand("[dbo].[SPGET_TargetsPer_Territory]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@Date", date));
                   cmd.Parameters.Add(new SqlParameter("@firstOfMonth", firstOfMonth));
                   cmd.Parameters.Add(new SqlParameter("@Territory", terr));

                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();

               }

           }
           catch (Exception)
           {

           }
           return dt;
       }

       public static DataTable RegionSummary(DateTime date, int UserID)
       {


           try
           {

               SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@Date", date),
                new SqlParameter("@UserID", UserID)};

               return Execute.RunSP_DataTable(ConnectionStringClass.GetConnection(), "SPGET_DailyTarget_RegionSummary", paramList);

           }
           catch (Exception)
           {
               return null;
           }


       }


       public static bool SPCHECK_DataConfirmed(string date, int UserID)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           bool res = false;
           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPCHECK_TargetConfirmed]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@Date", date));
                   cmd.Parameters.Add(new SqlParameter("@UserID", UserID));


                   //declare output parameter
                   SqlParameter result = new SqlParameter("@result", SqlDbType.Bit);
                   result.Direction = ParameterDirection.Output;
                   cmd.Parameters.Add(result);

                   cmd.ExecuteNonQuery();
                   connection.Close();

                   res = (bool)cmd.Parameters["@result"].Value;


               }

           }
           catch (Exception)
           {
               return false;
           }


           return res;
       }

       public static bool SPUPDATE_RDTarget(string date, int TerrID, string ProdCode, decimal target, int Userid)
       {

           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPUPDATE_RDTarget]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@Date", date));
                   cmd.Parameters.Add(new SqlParameter("@Territory", TerrID));
                   cmd.Parameters.Add(new SqlParameter("@ProductCod", ProdCode));
                   cmd.Parameters.Add(new SqlParameter("@Target", target));
                   cmd.Parameters.Add(new SqlParameter("@UserID", Userid));



                   da.InsertCommand = cmd;
                   da.InsertCommand.ExecuteNonQuery();
                   connection.Close();
               }

               return true;

           }
           catch (Exception)
           {
               return false;
           }

       }

       public static bool SPUPDATE_Confrmed(string date, int User)
       {

           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPUPDATE_Target_Confirmed]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@Date", date));
                   cmd.Parameters.Add(new SqlParameter("@UserID", User));


                   da.InsertCommand = cmd;
                   da.InsertCommand.ExecuteNonQuery();
                   connection.Close();
               }

               return true;

           }
           catch (Exception)
           {
               return false;
           }

       }

       public static void Update_DailyTarget(DataTable dtRDSales)
       {

           try
           {
               SqlConnection conn = new SqlConnection();
               conn = ConnectionStringClass.GetConnection();
               conn.Open();

               using (conn)//assuming you have a connection here
               {
                   SqlCommand cmd = new SqlCommand("SPADD_DailyTarget_New", conn);
                   cmd.CommandType = CommandType.StoredProcedure;
                   SqlParameter tvparam = cmd.Parameters.AddWithValue("@dt", dtRDSales);
                   tvparam.SqlDbType = SqlDbType.Structured;
                   cmd.ExecuteNonQuery();
               }

           }
           catch (Exception ex)
           {

               throw new Exception(ex.Message, ex);
           }

       }

       public static DataTable RegionSummary(string date, int UserID)
       {


           try
           {

               SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@Date", date),
                new SqlParameter("@UserID", UserID)};

               return Execute.RunSP_DataTable(ConnectionStringClass.GetConnection(), "SPGET_DailyTarget_RegionSummary", paramList);

           }
           catch (Exception)
           {
               return null;
           }


       }



      public static int IsEditable(string date, int terr,int UserID)
        {

           int x= 0;

            try
            {

                SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("Date", date),
                new SqlParameter("@Territory", terr),
                new SqlParameter("@UserID", UserID),
                new SqlParameter("@outParam",SqlDbType.Int){Direction=ParameterDirection.Output}};

                x = Execute.RunSP_Output(ConnectionStringClass.GetConnection(), "SPGET_DailyTarget_Editable", paramList);

                return x;
            }
            catch (Exception)
            {
                return x;
            }


        }


      public static int Confirm(DateTime date, int terr, int UserID)
      {


          try
          {

              SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@date", date),
                new SqlParameter("@terr", terr),
                new SqlParameter("@UserID", UserID)};

              return Execute.RunSP_RowsEffected(ConnectionStringClass.GetConnection(), "SPUPDATE_Target_Confirm", paramList);

          }
          catch (Exception)
          {
              return 0;
          }


      }



    }
}
