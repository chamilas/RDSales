using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDSales_Entities;
using System.Data;
using CryptoEngine;
using RDSales_Entity_Handler;
using RDSales_Entities;

namespace RDSales_Management_System
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UserEntity UserObj = (UserEntity)Session["LoggedUser"];
            if (UserObj != null)
            {
                int UserId = UserObj.ID;
                bool haspermission = UserEntityHandler.SPCHECK_UserHaspermission(UserId, "CREATE_USER");

                if (!haspermission)
                {
                    Response.Redirect("AccessDenied.aspx");
                }
            }
            else
            {
                Response.Redirect("SessionTimedOut.aspx");
            }

            if (!IsPostBack)
            {
                DataTable dt = RDSales_Entity_Handler.UserEntityHandler.SPGET_Roles();
                foreach (DataRow item in dt.Rows)
                {
                    DropD_Role.Items.Add(item[1].ToString() + "-" + item[0].ToString());
                }
            }
            
        }

        protected void bttn_Create_Click(object sender, EventArgs e)
        {
            try
            {
                int roleid = RDSales_Entity_Handler.UserEntityHandler.GetRoleID(DropD_Role.SelectedValue);
                bool res = RDSales_Entity_Handler.UserEntityHandler.SPADD_User(txt_fname.Text,Int32.Parse(txt_EmpNum.Text),txt_Username.Text,CryptorEngine.Encrypt(txt_password.Text, true),txt_Designation.Text,roleid);
                if (res)
                {
                    lbl_Result.ForeColor = System.Drawing.Color.Green;
                    lbl_Result.Text = "User Successfully created!";

                }
                else
                {
                    lbl_Result.ForeColor = System.Drawing.Color.Red;
                    lbl_Result.Text = "User Creation Unsuccessful!,contact system administrator!";
                }

            }
            catch (Exception er)
            {
                lbl_Result.ForeColor = System.Drawing.Color.Red;
                lbl_Result.Text = er.Message;
            }
        }
    }
}