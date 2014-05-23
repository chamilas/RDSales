using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace RDSales_Entity_Handler
{
  public  class DBFReaderHandler
    {
     private static string connstring = @"Driver={Microsoft dBase Driver (*.dbf)};Driverid=277;SourceType=DBF;datasource=D:\;Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";

      public static DataTable ReadData_PROSTOCK()
      {
          OdbcCommand cmd = new OdbcCommand();
          OdbcDataAdapter da = new OdbcDataAdapter();
          DataTable dt = new DataTable();
          try
          {
              

              using (OdbcConnection connection = new OdbcConnection(connstring))
              {
                  connection.Open();
                  cmd = new OdbcCommand(@"SELECT * FROM D:\Images\PROSTOCK.dbf", connection);
                  cmd.CommandType = CommandType.Text;

                  da.SelectCommand = cmd;
                  da.Fill(dt);
              }


          }
          catch (Exception)
          {
              
            
          }

          return dt;

      }

      public static DataTable ReadData_SAINV(DateTime date)
      {
          OdbcCommand cmd = new OdbcCommand();
          OdbcDataAdapter da = new OdbcDataAdapter();
          DataTable dt = new DataTable();
          try
          {
              string start = getStartdateofMonth(date);
              string end = getEnddateofMonth(date);


              //string year = date.Year.ToString();
              //string month = date.Month.ToString();

              using (OdbcConnection connection = new OdbcConnection(connstring))
              {
                  connection.Open();
                  //cmd = new OdbcCommand(@"SELECT * FROM D:\DBFreader\SAINV.dbf where RDATE like '"+month+"/%/"+year+"'", connection);
                  cmd = new OdbcCommand(@"SELECT * FROM D:\DBFreader\SAINV.dbf  where [RDATE] between #"+start+" 12:00:00 AM# and #"+end+" 12:00:00 AM#", connection);
                  cmd.CommandType = CommandType.Text;

                  da.SelectCommand = cmd;
                  da.Fill(dt);

                 int y = dt.Rows.Count;
              }


          }
          catch (Exception)
          {


          }

          return dt;

      }

      public static DataTable ReadData_SAINVSB(string refno)
      {
          OdbcCommand cmd = new OdbcCommand();
          OdbcDataAdapter da = new OdbcDataAdapter();
          DataTable dt = new DataTable();
          try
          {
              
              using (OdbcConnection connection = new OdbcConnection(connstring))
              {
                  connection.Open();
                  cmd = new OdbcCommand(@"SELECT * FROM D:\DBFreader\SAINVSB.dbf where [REFNO] = '"+refno+"'", connection);
                  cmd.CommandType = CommandType.Text;

                  da.SelectCommand = cmd;
                  da.Fill(dt);

                  int y = dt.Rows.Count;
              }


          }
          catch (Exception)
          {


          }

          return dt;

      }
      
      public static bool SPADD_PROSTOCK( string ITCODE, string PACK_TYPE, string PACK_SIZE, string UNIT,string LOC_CODE,float OLD_COST,float CUR_COST,float PRE_COST,float COST,float DCOST,string CST_DATE,int QTY_BAL,int DQTY_BAL,int QTY_VAN,int DQTY_VAN,int QTY_RESVD,float PRICE, float PRE_PRICE, float FRI_PRICE,string PRI_DATE,int REO_LEVEL,int MIN_ST,int MAX_ST,string REM,float RATE_A, float RATE_N,float RATE_S)
      {

          SqlCommand cmd = new SqlCommand();
          SqlDataAdapter da = new SqlDataAdapter();
          try
          {
              string conn_string = DBCon.ConnectionString;

              using (SqlConnection connection = new SqlConnection(conn_string))
              {

                  connection.Open();
                  cmd = new SqlCommand("[dbo].[SPADD_PROSTOCK]", connection);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.Add(new SqlParameter("@ITCODE", ITCODE));
                  cmd.Parameters.Add(new SqlParameter("@PACK_TYPE", PACK_TYPE));
                  cmd.Parameters.Add(new SqlParameter("@PACK_SIZE",PACK_SIZE ));
                  cmd.Parameters.Add(new SqlParameter("@UNIT",UNIT ));
                  cmd.Parameters.Add(new SqlParameter("@LOC_CODE", LOC_CODE));
                  cmd.Parameters.Add(new SqlParameter("@OLD_COST", OLD_COST));
                  cmd.Parameters.Add(new SqlParameter("@CUR_COST", CUR_COST));
                  cmd.Parameters.Add(new SqlParameter("@PRE_COST", PRE_COST));
                  cmd.Parameters.Add(new SqlParameter("@COST", COST));
                  cmd.Parameters.Add(new SqlParameter("@DCOST",DCOST ));
                  cmd.Parameters.Add(new SqlParameter("@CST_DATE", CST_DATE ));
                  cmd.Parameters.Add(new SqlParameter("@QTY_BAL", QTY_BAL));
                  cmd.Parameters.Add(new SqlParameter("@DQTY_BAL", DQTY_BAL));
                  cmd.Parameters.Add(new SqlParameter("@QTY_VAN",QTY_VAN ));
                  cmd.Parameters.Add(new SqlParameter("@DQTY_VAN", DQTY_VAN));
                  cmd.Parameters.Add(new SqlParameter("@QTY_RESVD", QTY_RESVD));
                  cmd.Parameters.Add(new SqlParameter("@PRICE", PRICE));
                  cmd.Parameters.Add(new SqlParameter("@PRE_PRICE", PRE_PRICE));
                  cmd.Parameters.Add(new SqlParameter("@FRI_PRICE", FRI_PRICE));
                  cmd.Parameters.Add(new SqlParameter("@PRI_DATE", PRI_DATE));
                  cmd.Parameters.Add(new SqlParameter("@REO_LEVEL", REO_LEVEL));
                  cmd.Parameters.Add(new SqlParameter("@MIN_ST", MIN_ST));
                  cmd.Parameters.Add(new SqlParameter("@MAX_ST", MAX_ST));
                  cmd.Parameters.Add(new SqlParameter("@REM", REM));
                  cmd.Parameters.Add(new SqlParameter("@RATE_A",RATE_A ));
                  cmd.Parameters.Add(new SqlParameter("@RATE_N", RATE_N));
                  cmd.Parameters.Add(new SqlParameter("@RATE_S", RATE_S));



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
      
      public static bool SPADD_SAINV(string REFNO, string PRE_INVNO, string SALTYP, string ARCODE, string SLTYPE, string SAL_REFNO, string DEPCODE, string RTNCODE, string ORDNO, string CUSCODE, string LOCODE, string PAYTYP, string REPCODE, string REPCODE_OR, string DISTYP, string RDATE, float TOT_AMT, float TOT_PAY, float DIS_AMT, float ADIS_AMT, float UN_CHEQE, string DELFLG, string TYPFLG, string RTNTYP, string USID, string REM, string FLFLG, string D_USID, string D_DATE, string VATPAY, float VATRATE, float VAT_AMT, float NBTRATE , float NBT_AMT)
      {

          SqlCommand cmd = new SqlCommand();
          SqlDataAdapter da = new SqlDataAdapter();
          try
          {
              string conn_string = DBCon.ConnectionString;

              using (SqlConnection connection = new SqlConnection(conn_string))
              {

                  connection.Open();
                  cmd = new SqlCommand("[dbo].[SPADD_SAINV]", connection);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.Add(new SqlParameter("@REFNO",REFNO ));
                  cmd.Parameters.Add(new SqlParameter("@PRE_INVNO", PRE_INVNO));
                  cmd.Parameters.Add(new SqlParameter("@SALTYP", SALTYP));
                  cmd.Parameters.Add(new SqlParameter("@ARCODE", ARCODE));
                  cmd.Parameters.Add(new SqlParameter("@SLTYPE", SLTYPE));
                  cmd.Parameters.Add(new SqlParameter("@SAL_REFNO", SAL_REFNO));
                  cmd.Parameters.Add(new SqlParameter("@DEPCODE", DEPCODE));
                  cmd.Parameters.Add(new SqlParameter("@RTNCODE", RTNCODE));
                  cmd.Parameters.Add(new SqlParameter("@ORDNO", ORDNO));
                  cmd.Parameters.Add(new SqlParameter("@CUSCODE", CUSCODE));
                  cmd.Parameters.Add(new SqlParameter("@LOCODE", LOCODE));
                  cmd.Parameters.Add(new SqlParameter("@PAYTYP", PAYTYP));
                  cmd.Parameters.Add(new SqlParameter("@REPCODE", REPCODE));
                  cmd.Parameters.Add(new SqlParameter("@REPCODE_OR", REPCODE_OR));
                  cmd.Parameters.Add(new SqlParameter("@DISTYP", DISTYP));
                  cmd.Parameters.Add(new SqlParameter("@RDATE", RDATE));
                  cmd.Parameters.Add(new SqlParameter("@TOT_AMT", TOT_AMT));
                  cmd.Parameters.Add(new SqlParameter("@TOT_PAY", TOT_PAY));
                  cmd.Parameters.Add(new SqlParameter("@DIS_AMT",DIS_AMT ));
                  cmd.Parameters.Add(new SqlParameter("@ADIS_AMT", ADIS_AMT));
                  cmd.Parameters.Add(new SqlParameter("@UN_CHEQE",UN_CHEQE));
                  cmd.Parameters.Add(new SqlParameter("@DELFLG", DELFLG));
                  cmd.Parameters.Add(new SqlParameter("@TYPFLG", TYPFLG));
                  cmd.Parameters.Add(new SqlParameter("@RTNTYP", RTNTYP));
                  cmd.Parameters.Add(new SqlParameter("@USID", USID));
                  cmd.Parameters.Add(new SqlParameter("@REM", REM ));
                  cmd.Parameters.Add(new SqlParameter("@FLFLG", FLFLG));
                  cmd.Parameters.Add(new SqlParameter("@D_USID", D_USID));
                  cmd.Parameters.Add(new SqlParameter("@D_DATE", D_DATE));
                  cmd.Parameters.Add(new SqlParameter("@VATPAY",VATPAY ));
                  cmd.Parameters.Add(new SqlParameter("@VATRATE", VATRATE ));
                  cmd.Parameters.Add(new SqlParameter("@VAT_AMT", VAT_AMT ));
                  cmd.Parameters.Add(new SqlParameter("@NBTRATE", NBTRATE));
                  cmd.Parameters.Add(new SqlParameter("@NBT_AMT", NBT_AMT));
          



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
      
      public static bool SPADD_SAINVSB(string REFNO,string ITCODE,float PRICE,float COST, float FRI_PRICE,int QTY,int BAL_QTY,string FLFLG,string DELFLG,string PAYTYP,string SALTYP,string TYPFLG)
      {

          SqlCommand cmd = new SqlCommand();
          SqlDataAdapter da = new SqlDataAdapter();
          try
          {
              string conn_string = DBCon.ConnectionString;

              using (SqlConnection connection = new SqlConnection(conn_string))
              {

                  connection.Open();
                  cmd = new SqlCommand("[dbo].[SPADD_SAINVSB]", connection);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.Add(new SqlParameter("@REFNO", REFNO));
                  cmd.Parameters.Add(new SqlParameter("@ITCODE", ITCODE));
                  cmd.Parameters.Add(new SqlParameter("@PRICE", PRICE));
                  cmd.Parameters.Add(new SqlParameter("@COST", COST));
                  cmd.Parameters.Add(new SqlParameter("@FRI_PRICE", FRI_PRICE));
                  cmd.Parameters.Add(new SqlParameter("@QTY", QTY));
                  cmd.Parameters.Add(new SqlParameter("@BAL_QTY", BAL_QTY));
                  cmd.Parameters.Add(new SqlParameter("@SALTYP", SALTYP));
                  cmd.Parameters.Add(new SqlParameter("@PAYTYP", PAYTYP));
                  cmd.Parameters.Add(new SqlParameter("@DELFLG", DELFLG));
                  cmd.Parameters.Add(new SqlParameter("@TYPFLG", TYPFLG));
                  cmd.Parameters.Add(new SqlParameter("@FLFLG", FLFLG));
                  

                  da.InsertCommand = cmd;
                 int c =  da.InsertCommand.ExecuteNonQuery();
                  connection.Close();
              }

              return true;

          }
          catch (Exception)
          {
              return false;
          }

      }

      public static string getStartdateofMonth(DateTime _Date)
      {
          if (_Date != null)
              return new DateTime(_Date.Year, _Date.Month, 1).ToString("MM/dd/yyyy");
          else
              return _Date.ToString("MM/dd/yyyy");


      }

      public static string getEnddateofMonth(DateTime _Date)
      {
          if (_Date != null)
              return new DateTime(_Date.Year, _Date.Month, 1).AddMonths(1).AddDays(-1).ToString("MM/dd/yyyy");
          else
              return _Date.ToString("MM/dd/yyyy");


      }
      

    }

}
