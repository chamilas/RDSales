using System;
using RDSales_Entities;

namespace RDSales_Management_System
{
    public partial class Main : System.Web.UI.MasterPage
    {

        UserEntity UserObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserObj = (UserEntity)Session["LoggedUser"];
            if (UserObj != null)
            {
                this.lbl_user.Text = UserObj.Name;
                this.lbl_date.Text = System.DateTime.Today.ToShortDateString();
            }
        }
    }
}