using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDSales_Entities;
using RDSales_Entity_Handler;
using System.Data;

namespace RDSales_Management_System
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private RDSales_Entities.UserEntity UserObj;
        private int UserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserObj = (RDSales_Entities.UserEntity)Session["LoggedUser"];


            #region Handle Session
            if (UserObj != null)
            {
                UserId = UserObj.ID;
                bool hasPermission = false;

                if(UserObj.Role==2)
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
                loadData();
            }
     
        }

        private void loadData()
        {
            ddlist_outletType.DataSource = OutletHandler.SPGET_OutletTypes();
            ddlist_outletType.DataBind();

            List<Region> R_list = RegionHandler.SPGET_RegionByUser_list(UserId);
            string[] r_list = new string[R_list.Count];
            for (int x = 0; x < R_list.Count;x++ )
            {
                r_list[x] = R_list[x].RegionName;
            }

            ddlist_region.DataSource = r_list;
            ddlist_region.DataBind();

            territoris();

        }

        private void territoris()
        {
            try
            {
                List<Region> R_list = RegionHandler.SPGET_Regions();
                int index=0;
                for (int x = 0; x < R_list.Count;x++ )
                {
                    if(ddlist_region.SelectedValue.ToString() == R_list[x].RegionName)
                    {
                        index=R_list[x].RegionID;
                    }

                }

                ddlist_territory.DataSource = TerritoryHandler.Load_TerritoresList_ByRegion(index);
                ddlist_territory.DataBind();
            }
            catch(Exception ex)
            {
               
            }
        }

        protected void ddlist_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            territoris();
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            clearFileds();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            lb_error.Text = "";

            if (!checkfields())
            {
                return;
            }

            if (!IsValidPhoneNumber(txt_shopPhone.Text.Trim()))
            {
                return;
            }

            if (!IsNumber(txt_noOfEmployees.Text.Trim()))
            {
                return;
            }

            else
            {
                int IskeyOutlet = 0;
                if (chk_isKeyOutlet.Checked == true)
                {
                    IskeyOutlet = 1;
                }

                int outletType = OutletID(ddlist_outletType.SelectedItem.ToString());
                int regionID = RegionID(ddlist_region.SelectedItem.ToString());
                int userID = UserId;
                int territoryID = TerritoryID(ddlist_territory.SelectedItem.ToString(), regionID);
                int route = Int32.Parse(ddlist_route.SelectedItem.ToString());

                int rows = 1;
                rows = OutletHandler.SPADD_Outlet(txt_shopName.Text.Trim().ToString(), txt_shopAddress.Text.Trim().ToString(), txt_shopOwner.Text.Trim().ToString(), txt_shopPhone.Text.Trim().ToString(), txt_dateOfBirth.Text.Trim().ToString(), outletType, territoryID, regionID, route, userID, 1, IskeyOutlet, int.Parse(txt_noOfEmployees.Text.Trim().ToString()));

                if (rows == 0)
                {
                    Response.Write("<script>alert('Data has not been saved...!');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Data has been saved...!');</script>");
                    clearFileds();
                }
            }
        }

        private bool checkfields()
        {
            if ((txt_shopName.Text.Trim() == "" || txt_shopName.Text.Trim() == null) ||
                (txt_shopAddress.Text.Trim() == "" || txt_shopAddress.Text.Trim() == null) ||
                (txt_shopOwner.Text.Trim() == "" || txt_shopOwner.Text.Trim() == null) ||
                (txt_shopPhone.Text.Trim() == "" || txt_shopPhone.Text.Trim() == null) ||
                (txt_dateOfBirth.Text.Trim() == "" || txt_dateOfBirth.Text.Trim() == null) ||
                (txt_noOfEmployees.Text.Trim() == "" || txt_noOfEmployees.Text.Trim() == null))
            {
                lb_error.Text = "Please fill all details...";
                return false;
            }

            else
            {
                return true;
            }
        }

        private int RegionID(string name)
        {
            List<Region> list=RegionHandler.SPGET_Regions();
            int index = 0;
            for (int x=0; x < list.Count; x++)
            {
                if (list[x].RegionName == name)
                {
                    index = list[x].RegionID;
                }
            }
            return index;
        }

        private int OutletID(string name)
        {
            List<Outlet> list = OutletHandler.SPGET_OutletTypes_List();
            int index = 0;
            for (int x = 0; x < list.Count; x++)
            {
                if (list[x].Name == name)
                {
                    index = list[x].ID;
                }
            }
            return index;
        }

        private int TerritoryID(string name, int id)
        {
            List<Territory> list = TerritoryHandler.SPGET_TerritoryByRegion(id);
            int index = 0;
            for (int x = 0; x < list.Count; x++)
            {
                if (list[x].TerritoryName == name)
                {
                    index = list[x].TerritoryID;
                }
            }
            return index;
        }

        private bool IsValidPhoneNumber(string ch)
        {
            try
            {
                int number = int.Parse(ch.ToString().Trim());

                if (ch.Length == 10)
                {
                    return true;
                }
                else
                {
                    lb_error.Text = "Please enter a correct phone number with 10 digits...";
                    return false;
                }
            }
            catch (Exception ex)
            {
                lb_error.Text = "Please enter a correct phone number...";
                return false;
            }
        }

        private void clearFileds()
        {
            txt_shopName.Text = "";
            txt_shopAddress.Text = "";
            txt_shopOwner.Text = "";
            txt_shopPhone.Text = "";
            txt_dateOfBirth.Text = "";
            txt_noOfEmployees.Text = "";
            lb_error.Text = "";
        }

        private bool IsNumber(string ch)
        {
            try
            {
                int number = int.Parse(ch.ToString().Trim());
                return true;

            }
            catch (Exception ex)
            {
                lb_error.Text = "Please enter a number as No of Employees...";
                return false;
            }
        }
    }
}