using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDSales_Management_System
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string popup = "<script language='javascript'>" + "window.open('test.aspx','CustomPopUp', " + "'fullscreen=no,height=240,width=648,top=250,left=250,location=0,directories=0,status=no,scrollbars=no, dependant = no, alwaysRaised = yes, menubar=no,resizable=no')" + "</script>";
            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PopupScript", popup, false);
           Page.ClientScript.RegisterStartupScript(typeof(WebForm4), "alert", "<script>alert('Hello')</script>");
           // Page.ClientScript.RegisterStartupScript(typeof(WebForm4), "ConfirmAlert", "<script>ConfirmAlert()</script>");
        }
    }
}