﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDSales_Entities;
using System.Data.SqlClient;
using System.Data;

namespace RDSales_Entity_Handler
{
  public class DailyPCHandler
    {

      public static bool SPADD_DailyTerrPC(string date, int User, int TerrID, int pc, int region, int day, int route)
      {

          SqlCommand cmd = new SqlCommand();
          SqlDataAdapter da = new SqlDataAdapter();
          try
          {
              string conn_string = DBCon.ConnectionString;

              using (SqlConnection connection = new SqlConnection(conn_string))
              {

                  connection.Open();
                  cmd = new SqlCommand("[dbo].[SPADD_DailyTerritory_PC]", connection);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.Add(new SqlParameter("@Date", date));
                  cmd.Parameters.Add(new SqlParameter("@UserID", User));
                  cmd.Parameters.Add(new SqlParameter("@TerrID", TerrID));
                  cmd.Parameters.Add(new SqlParameter("@PC", pc));
                  cmd.Parameters.Add(new SqlParameter("@Region", region));
                  cmd.Parameters.Add(new SqlParameter("@DayNo", day));
                  cmd.Parameters.Add(new SqlParameter("@RouteNo", route));


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


      public static DailyPC SPGET_DailyPCPerDay_Territory(string date, int terr)
      {
          DataTable dt = new DataTable();
          SqlCommand cmd = new SqlCommand();
          SqlDataAdapter da = new SqlDataAdapter();
          DailyPC PC = new DailyPC();

          try
          {
              string conn_string = DBCon.ConnectionString;

              using (SqlConnection connection = new SqlConnection(conn_string))
              {

                  connection.Open();
                  cmd = new SqlCommand("[dbo].[SPGET_DailyPCPerday_Territory]", connection);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.Add(new SqlParameter("@Date", date));
                  cmd.Parameters.Add(new SqlParameter("@Territory", terr));

                  da.SelectCommand = cmd;
                  da.Fill(dt);

                  connection.Close();

                  foreach (DataRow row in dt.Rows)
                  {


                      PC.ID = Int32.Parse(row[0].ToString());
                      PC.EntryTime = DateTime.Parse(row[1].ToString());
                      PC.Date = row[2].ToString();
                      PC.UserID = Int32.Parse(row[3].ToString());
                      PC.TerrID = Int32.Parse(row[4].ToString());
                      PC.PC = Int32.Parse(row[5].ToString());
                      PC.Edited = Int32.Parse(row[6].ToString());
                      PC.Confirmed = Boolean.Parse(row[7].ToString());

                  }


              }

          }
          catch (Exception)
          {

          }
          return PC;
      }


      public static bool SPUPDATE_DailyPC(string date, int TerrID,  int pc, int Userid)
      {

          SqlCommand cmd = new SqlCommand();
          SqlDataAdapter da = new SqlDataAdapter();
          try
          {
              string conn_string = DBCon.ConnectionString;

              using (SqlConnection connection = new SqlConnection(conn_string))
              {

                  connection.Open();
                  cmd = new SqlCommand("[dbo].[SPUPDATE_DailyPC]", connection);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.Add(new SqlParameter("@Date", date));
                  cmd.Parameters.Add(new SqlParameter("@Territory", TerrID));
                  cmd.Parameters.Add(new SqlParameter("@PC", pc));
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


      public static bool Confirm(string date, int User)
      {

          SqlCommand cmd = new SqlCommand();
          SqlDataAdapter da = new SqlDataAdapter();
          try
          {
              string conn_string = DBCon.ConnectionString;

              using (SqlConnection connection = new SqlConnection(conn_string))
              {

                  connection.Open();
                  cmd = new SqlCommand("[dbo].[SPUPDATE_DailyPC_Confirmed]", connection);
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
                  cmd = new SqlCommand("[dbo].[SPUPDATE_DailyPC_Confirmed]", connection);
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
    }
}
