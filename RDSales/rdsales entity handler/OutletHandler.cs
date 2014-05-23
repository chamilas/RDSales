using RDSales_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RDSales_Entity_Handler
{
    public class OutletHandler
    {
        public static List<string> SPGET_OutletTypes()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            List<string> outletTypes = new List<string>();

            try
            {
                string conn_string = DBCon.ConnectionString;

                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPGET_OutletTypes]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    connection.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        outletTypes.Add(row[1].ToString());
                    }


                }

            }
            catch (Exception)
            {

            }
            return outletTypes;
        }

        public static int SPADD_Outlet(string name,string address,string owner, string phone, string dob, int outlettpye, int territory, int RegionID, int route, int userID,int status,int isKeyOutlet,int noOfEmployees)
        {
            int rows=0;

            try
            {

                SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@Name", name),
                new SqlParameter("@Address", address),
                new SqlParameter("@Owner", owner),
                new SqlParameter("@Phone", phone),
                new SqlParameter("@DOB", dob),
                new SqlParameter("@OutletType", outlettpye),
                new SqlParameter("@Territory", territory),
                new SqlParameter("@RegionID", RegionID),
                new SqlParameter("@Route", route),
                new SqlParameter("@UserID", userID),
                new SqlParameter("@Status", status),
                new SqlParameter("@IsKeyOutlet", isKeyOutlet),
                new SqlParameter("@NoOfEmployees", noOfEmployees)};



                rows = Execute.RunSP_RowsEffected(ConnectionStringClass.GetConnection(), "SPADD_Outlet", paramList);

                return rows;
            }
            catch (Exception)
            {
                return rows;
            }
        }

        public static List<Outlet> SPGET_OutletTypes_List()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            List<Outlet> outletTypes = new List<Outlet>();

            try
            {
                string conn_string = DBCon.ConnectionString;

                using (SqlConnection connection = new SqlConnection(conn_string))
                {

                    connection.Open();
                    cmd = new SqlCommand("[dbo].[SPGET_OutletTypes]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    connection.Close();

                    foreach (DataRow row in dt.Rows)
                    {
                        Outlet outlet = new Outlet();
                        outlet.ID = Int32.Parse(row[0].ToString());
                        outlet.Name = row[1].ToString();
                        outletTypes.Add(outlet);
                    }


                }

            }
            catch (Exception)
            {

            }
            return outletTypes;
        }

        public static DataTable NonConfirmOutlets()
        {
            try
            {

                SqlParameter[] paramList = new SqlParameter[] {};
                return Execute.RunSP_DataTable(ConnectionStringClass.GetConnection(), "SPGET_Outlets1", paramList);

            }
            catch (Exception)
            {
                return null;
            }

        }

        public static int SPUPDATE_OutletStatus(int ID)
        {
            int rows = 0;

            try
            {

                SqlParameter[] paramList = new SqlParameter[] {
                new SqlParameter("@ID", ID)};

                rows = Execute.RunSP_RowsEffected(ConnectionStringClass.GetConnection(), "SPUPDATE_OutletStatus", paramList);

                return rows;
            }
            catch (Exception)
            {
                return rows;
            }
        }
    }
}
