using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDSales_Entity_Handler;
using RDSales_Entities;
using CryptoEngine;

namespace RDSales_Management_System
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserEntity UserObj = (UserEntity)Session["LoggedUser"];
            if (UserObj != null)
            {
                Session["LoggedUser"] = null;

            }

        
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
                string test = CryptorEngine.Encrypt(txt_password.Text.ToString(), true);
             UserEntity objUser = UserEntityHandler.SPGET_User(txt_username.Text.ToString(), CryptorEngine.Encrypt(txt_password.Text.ToString(), true));

            if (objUser.ID > 0)
            {
                CreateSession(objUser);
                Response.Redirect("Home.aspx",false);
            }
            else
            {
                lbl_status.Visible = true;
                lbl_status.ForeColor = System.Drawing.Color.Red;
                lbl_status.Text = "Sorry!, You don't have access permission to access this web. Contact System Administrator";
            }
        }

        private void CreateSession(UserEntity objUser)
        {
            try
            {
                Object Sessionobj = Session["LoggedUser"];
                Session["LoggedUser"] = objUser;
            }
            catch (Exception)
            {
            }

        }
        
    }
}