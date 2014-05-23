using RDSales_Entity_Handler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RDSales_Management_System
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private RDSales_Entities.UserEntity UserObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserObj = (RDSales_Entities.UserEntity)Session["LoggedUser"];
            #region Handle Session
            if (UserObj != null)
            {
                bool hasPermission = false;

                if (UserObj.Role == 2)
                {
                    hasPermission = true;
                }

                if (!hasPermission)
                {
                    Response.Redirect("AccessDenied.aspx");
                }
                else
                {

                }

            }
            else
            {
                Response.Redirect("SessionTimedOut.aspx");
            }
            #endregion

            if (!IsPostBack)
            {
                load();
            }
        }

        protected void gdvOutlets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectRow")
            {
                int index=int.Parse(e.CommandArgument.ToString());
                GridViewRow gvr = gdvOutlets.Rows[index];
                int OutletID = int.Parse(Server.HtmlDecode(gvr.Cells[1].Text));
                int rows = OutletHandler.SPUPDATE_OutletStatus(OutletID);

                load();

            }
        }

        private void load()
        {
            DataTable dt = OutletHandler.NonConfirmOutlets();
            gdvOutlets.DataSource = dt;
            gdvOutlets.DataBind();
        }

    }
}