using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RDSales_Entities;
using System.Data;
using System.Data.SqlClient;



namespace RDSales_Entity_Handler
{
   public class UserEntityHandler
    {


       //Get Logged User
       public static UserEntity SPGET_User(string uname, string password)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           UserEntity objuser = new UserEntity();

           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_LoggedUser]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@uname", uname));
                   cmd.Parameters.Add(new SqlParameter("@passwrd", password));

                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();

                   foreach (DataRow row in dt.Rows)
                   {
                       objuser.ID = Int32.Parse(row[0].ToString());
                       objuser.Name = row[1].ToString();
                       objuser.EPF = Int32.Parse(row[2].ToString());
                       objuser.Username = row[3].ToString();
                       objuser.Password = row[4].ToString();
                       objuser.Designation = row[5].ToString();
                       objuser.Role = Int32.Parse(row[6].ToString());
                     
                   }


               }

           }
           catch (Exception)
           {

           }
           return objuser;
       }

       //Create New USer
       public static bool SPADD_User(string name, int epf, string username, string password, string designation, int roleid)
       {

           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPADD_NewUser]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@Name", name));
                   cmd.Parameters.Add(new SqlParameter("@EPF", epf));
                   cmd.Parameters.Add(new SqlParameter("@UserName", username));
                   cmd.Parameters.Add(new SqlParameter("@Password", password));
                   cmd.Parameters.Add(new SqlParameter("@Designation", designation));
                   cmd.Parameters.Add(new SqlParameter("@RoleID", roleid));
             

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

       //Get User Roles
       public static DataTable SPGET_Roles()
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
                   cmd = new SqlCommand("[dbo].[SPGET_UserRoles]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;

                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();
               }

           }
           catch (Exception)
           {
               throw;
           }
           return dt;
       }

       //Check User Access Permssion

       public static bool SPCHECK_UserHaspermission(int UserID, string component)
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
                   cmd = new SqlCommand("[dbo].[SPCHECK_UserHasPermission]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
                   cmd.Parameters.Add(new SqlParameter("@Component", component));

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

       //Get Role Id
       public static int GetRoleID(string value)
       {
           int result = -99;
           try
           {
               string[] arry;
               arry = value.Split('-');
               result = Int32.Parse(arry[1].ToString());
           }
           catch (Exception ex)
           { }
           return result;
       }


       //Get User data by ID
       public static UserEntity SPGET_UserByID(int id)
       {
           DataTable dt = new DataTable();
           SqlCommand cmd = new SqlCommand();
           SqlDataAdapter da = new SqlDataAdapter();
           UserEntity objuser = new UserEntity();

           try
           {
               string conn_string = DBCon.ConnectionString;

               using (SqlConnection connection = new SqlConnection(conn_string))
               {

                   connection.Open();
                   cmd = new SqlCommand("[dbo].[SPGET_UserByUserID]", connection);
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add(new SqlParameter("@UserID", id));


                   da.SelectCommand = cmd;
                   da.Fill(dt);
                   connection.Close();

                   foreach (DataRow row in dt.Rows)
                   {
                       objuser.ID = Int32.Parse(row[0].ToString());
                       objuser.Name = row[1].ToString();
                       objuser.EPF = Int32.Parse(row[2].ToString());
                       objuser.Username = row[3].ToString();
                       objuser.Password = row[4].ToString();
                       objuser.Designation = row[5].ToString();
                       objuser.Role = Int32.Parse(row[6].ToString());

                   }


               }

           }
           catch (Exception)
           {

           }
           return objuser;
       }

    }
}
