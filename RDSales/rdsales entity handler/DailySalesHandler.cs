using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDSales_Entities;
using System.Data.SqlClient;
using System.Data;

namespace RDSales_Entity_Handler
{
   public class DailySalesHandler
    {



        public static bool SPADD_Dailysales(string date, int User, int TerrID, string ProdCode, decimal achvement, int region, int day, int route, int PC, int PC_Fresh, int PC_All)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                string conn_string = DBCon.ConnectionString;

                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPADD_DailySales]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Date", date));
                    cmd.Parameters.Add(new SqlParameter("@UserID", User));
                    cmd.Parameters.Add(new SqlParameter("@TerrID", TerrID));
                    cmd.Parameters.Add(new SqlParameter("@ProdCode", ProdCode));
                    cmd.Parameters.Add(new SqlParameter("@Achivement", achvement));
                    cmd.Parameters.Add(new SqlParameter("@Region", region));
                    cmd.Parameters.Add(new SqlParameter("@DayNo", day));
                    cmd.Parameters.Add(new SqlParameter("@RouteNo", route));
                    cmd.Parameters.Add(new SqlParameter("@PC", PC));
                    cmd.Parameters.Add(new SqlParameter("@PC_Fresh", PC_Fresh));
                    cmd.Parameters.Add(new SqlParameter("@PC_All", PC_All));


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
                    cmd = new SqlCommand("[dbo].[SPUPDATE_DailySales_Confirmed]", connection);
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

        public static bool SPCHECK_DataExists(string date, int asm)
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
                    cmd = new SqlCommand("[dbo].[SPCHECK_DataExists]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Date", date));
                    cmd.Parameters.Add(new SqlParameter("@UserID", asm));

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

        //public static List<DailySales> SPGET_DailysalesPerDay_Territory(string date, int terr)
        //{
        //    DataTable dt = new DataTable();
        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    List<DailySales> sale = new List<DailySales>();

        //    try
        //    {
        //        string conn_string = DBCon.ConnectionString;

        //        using (SqlConnection connection = new SqlConnection(conn_string))
        //        {

        //            connection.Open();
        //            cmd = new SqlCommand("[dbo].[SPGEET_DailySalesPerday_Territory]", connection);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(new SqlParameter("@Date", date));
        //            cmd.Parameters.Add(new SqlParameter("@Territory", terr));

        //            da.SelectCommand = cmd;
        //            da.Fill(dt);
        //            connection.Close();

        //            foreach (DataRow row in dt.Rows)
        //            {
        //                DailySales objSales = new DailySales();

        //                objSales.ID = Int32.Parse(row[0].ToString());
        //                objSales.EntryTime = DateTime.Parse(row[1].ToString());
        //                objSales.Date = row[2].ToString();
        //                objSales.UserID = Int32.Parse(row[3].ToString());
        //                objSales.TerrID = Int32.Parse(row[4].ToString());
        //                objSales.prodcode = row[5].ToString();
        //                objSales.Acheivement = decimal.Parse(row[6].ToString());
        //                objSales.Edited = Int32.Parse(row[7].ToString());
        //                objSales.Confirmed = Boolean.Parse(row[8].ToString());
        //                objSales.RegionID = HandlInt(row[9].ToString());
        //                objSales.RouteNO = HandlInt(row[10].ToString());
        //                objSales.DayNO = HandlInt(row[11].ToString());
        //                objSales.PC = HandlInt(row[12].ToString());
        //                objSales.PC_Fresh = HandlInt(row[13].ToString());
        //                objSales.PC_All = HandlInt(row[14].ToString());

        //                sale.Add(objSales);
        //            }


        //        }

        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return sale;
        //}


        public static DataTable GetTerritorySales(string date, int terr)
        {

            DataTable dt = new DataTable();

            try
            {

                SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@Date", date),
                new SqlParameter("@Territory", terr)};

                dt = Execute.RunSP_DataTable(ConnectionStringClass.GetConnection(), "SPGEET_DailySalesPerday_Territory", paramList);

                return dt;
            }
            catch (Exception)
            {
                return dt;
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

                 x= Execute.RunSP_Output(ConnectionStringClass.GetConnection(), "SPGET_DailySales_Editable", paramList);

                return x;
            }
            catch (Exception)
            {
                return x;
            }


        }



        public static DataTable AddTerritorySales(int TerritoryID,string theDate,int PC_All,string Achievement, string PC, string PC_New)
        {

            DataTable dt = new DataTable();

            try
            {

                SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("Date", theDate),
                new SqlParameter("@Territory", TerritoryID)};

                dt = Execute.RunSP_DataTable(ConnectionStringClass.GetConnection(), "SPGEET_DailySalesPerday_Territory", paramList);

                return dt;
            }
            catch (Exception)
            {
                return dt;
            }


        }


        private static int HandlInt(string obj)
        {
            int num = 0;
            try
            {
                num = Int32.Parse(obj);
            }
            catch (Exception)
            {
                num = 0;

            }

            return num;
        }

        public static bool SPUPDATE_DailySales(string date, int TerrID, string ProdCode, decimal achvement, int Userid, int dayNo, int Routno, int PC, int PC_Fresh, int PC_All)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                string conn_string = DBCon.ConnectionString;

                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPUPDATE_DailyAchieved]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Date", date));
                    cmd.Parameters.Add(new SqlParameter("@Territory", TerrID));
                    cmd.Parameters.Add(new SqlParameter("@ProductCod", ProdCode));
                    cmd.Parameters.Add(new SqlParameter("@Achievement", achvement));
                    cmd.Parameters.Add(new SqlParameter("@UserID", Userid));
                    cmd.Parameters.Add(new SqlParameter("@RouteNo", Routno));
                    cmd.Parameters.Add(new SqlParameter("@DayNo", dayNo));
                    cmd.Parameters.Add(new SqlParameter("@PC", PC));
                    cmd.Parameters.Add(new SqlParameter("@PC_Fresh", PC_Fresh));
                    cmd.Parameters.Add(new SqlParameter("@PC_All", PC_All));

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

        public static bool SPUPDATE_DailySales_Exclde_DayRoute(string date, int TerrID, string ProdCode, decimal achvement, int Userid, int PC, int PC_Fresh, int PC_All)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                string conn_string = DBCon.ConnectionString;

                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPUPDATE_DailyAchieved_ExcDayRoute]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Date", date));
                    cmd.Parameters.Add(new SqlParameter("@Territory", TerrID));
                    cmd.Parameters.Add(new SqlParameter("@ProductCod", ProdCode));
                    cmd.Parameters.Add(new SqlParameter("@Achievement", achvement));
                    cmd.Parameters.Add(new SqlParameter("@UserID", Userid));
                    cmd.Parameters.Add(new SqlParameter("@PC", PC));
                    cmd.Parameters.Add(new SqlParameter("@PC_Fresh", PC_Fresh));
                    cmd.Parameters.Add(new SqlParameter("@PC_All", PC_All));


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
                    cmd = new SqlCommand("[dbo].[SPCHECK_Confirmed]", connection);
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

        public static bool SPCHECK_TimeoutToEdit()
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
                    cmd = new SqlCommand("[dbo].[SPCHECK_TimeOutToEdit]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

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

        public static DataTable SPGET_RegionalDailySales(DateTime date, int region)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();


            try
            {
                string conn_string = DBCon.ConnectionString;
                string statdate = getStartdateofMonth(date);
                string edate = date.ToString("yyyy-MM-dd");

                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPGET_RegionalDailySales]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@firstOfMonth", statdate));
                    cmd.Parameters.Add(new SqlParameter("@Date", edate));
                    cmd.Parameters.Add(new SqlParameter("@Region", region));


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

        public static DataTable SPGET_RegionalDailySales_PerDay(DateTime date, int region)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();


            try
            {
                string conn_string = DBCon.ConnectionString;
                string edate = date.ToString("yyyy-MM-dd");

                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPGET_RegionalDailySales_PerDay]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Date", edate));
                    cmd.Parameters.Add(new SqlParameter("@Region", region));


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

        public static DataTable SPGET_AllIslandDailySales(DateTime date)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();


            try
            {
                string conn_string = DBCon.ConnectionString;
                string firstOfmonthe = getStartdateofMonth(date);
                string edate = date.ToString("yyyy-MM-dd");

                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPGET_DailySalesReport_FromRDSales]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@firstOfMonth", firstOfmonthe));
                    cmd.Parameters.Add(new SqlParameter("@Date", edate));


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

        public static string getStartdateofMonth(DateTime _Date)
        {
            if (_Date != null)
                return new DateTime(_Date.Year, _Date.Month, 1).ToString("yyyy-MM-dd");
            else
                return _Date.ToString("yyyy-MM-dd");


        }

        public static bool IstheLatesRecordSet(int region, string selectDate)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            string date = "";
            //string sdate = selectDate.ToString("dd/MM/yyyy");
            //DateTime seldate = DateTime.Parse(selectDate);
            bool result = false;

            try
            {
                string conn_string = DBCon.ConnectionString;


                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPGET_LatestRecordDatePerRegion]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@RegionID", region));


                    da.SelectCommand = cmd;
                    DateTime d = (DateTime)cmd.ExecuteScalar();
                    date = d.ToString("MM/dd/yyyy");

                    connection.Close();

                }

                if (date == selectDate)
                {
                    result = true;
                }

            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public static DataTable SPGET_DailySalesProVise_FromRDSales(string prodcode, DateTime date)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                string conn_string = DBCon.ConnectionString;
                string statdate = getStartdateofMonth(date);
                string enddate = date.ToString("yyyy-MM-dd");


                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPGET_DailySalesProVise]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProdCode", prodcode));
                    cmd.Parameters.Add(new SqlParameter("@Date", enddate));
                    cmd.Parameters.Add(new SqlParameter("@firstOfMonth", statdate));
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    connection.Close();
                }

            }
            catch (Exception)
            { }

            return dt;
        }

        public static DataTable SPGET_DailySalesProVise_ForRange(string prodcode, DateTime from, DateTime to)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                string conn_string = DBCon.ConnectionString;
                string from_ = from.ToString("yyyy-MM-dd");
                string to_ = to.ToString("yyyy-MM-dd");


                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPGET_DailySalesProVise]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProdCode", prodcode));
                    cmd.Parameters.Add(new SqlParameter("@Date", to_));
                    cmd.Parameters.Add(new SqlParameter("@firstOfMonth", from_));
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    connection.Close();
                }

            }
            catch (Exception)
            { }

            return dt;
        }

        public static DataTable SPCHECK_RegionalDataSubmissionStatus(DateTime date)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                string conn_string = DBCon.ConnectionString;
                string statdate = getStartdateofMonth(date);
                string enddate = date.ToString("yyyy-MM-dd");


                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPCHECK_RegionalDataSubmissionStatus]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
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

        public static void Update_DailySales(DataTable dtRDSales)
        {

            try
            {
                SqlConnection conn = new SqlConnection();
                conn = ConnectionStringClass.GetConnection();
                conn.Open();

                using (conn)//assuming you have a connection here
                {
                    SqlCommand cmd = new SqlCommand("SPADD_DailySales_New", conn);
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

        public static int Confirm(string date, int terr, int UserID)
        {


            try
            {

                SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@date", date),
                new SqlParameter("@terr", terr),
                new SqlParameter("@UserID", UserID)};

                return Execute.RunSP_RowsEffected(ConnectionStringClass.GetConnection(), "SPUPDATE_RDSales_Confirm", paramList);

            }
            catch (Exception)
            {
                return 0;
            }


        }


    public static DataTable RegionSummary(string date, int UserID)
        {


            try
            {

                SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@Date", date),
                new SqlParameter("@UserID", UserID)};

                return Execute.RunSP_DataTable(ConnectionStringClass.GetConnection(), "SPGET_DailySales_RegionSummary", paramList);

            }
            catch (Exception)
            {
                return null;
            }


        }


        public static int IsConfirmed(string date, int terr, int UserID)
        {


            try
            {

                SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@date", date),
                new SqlParameter("@terr", terr),
                new SqlParameter("@UserID", UserID)};

                return Execute.RunSP_RowsEffected(ConnectionStringClass.GetConnection(), "SPUPDATE_RDSales_Confirm", paramList);

            }
            catch (Exception)
            {
                return 0;
            }


        }



    }
}
