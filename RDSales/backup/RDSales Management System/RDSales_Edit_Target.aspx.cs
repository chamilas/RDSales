using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDSales_Entities;
using RDSales_Entity_Handler;
using System.Data;
using System.Globalization;

namespace RDSales_Management_System
{
    public partial class RDSales_Edit_Target : System.Web.UI.Page
    {
        int UserId = 0;
        private List<Territory> ListTerr = new List<Territory>();
        private RDSales_Entities.UserEntity UserObj;
        private string date = "";
        private Region objReg = new Region();

        private void LoadTerritories()
        {
            try
            {

                cmbTerritories.DataSource = TerritoryHandler.Load_Territores_ByRegion(objReg.RegionID);
                cmbTerritories.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadCoreData()
        {
            try
            {
                string server = DBCon.GetServerDate();
                objReg = RegionHandler.SPGET_RegionByUser(UserId);
                DateTime today = DateTime.Parse(server);


                if (objReg.RegionID == 0)
                {
                    lblMessage.Text = "You hacve no region assigned!";
                   // btnUpdate.Enabled = false;
                }
                else
                {

                    //Get Territories by  Region
                    ListTerr = TerritoryHandler.SPGET_TerritoryByRegion(objReg.RegionID);

                    txt_region.Text = objReg.RegionName;

                    #region Load TerritoryNames
                    String[] Terrname = new string[8];
                    for (int i = 0; i < ListTerr.Count; i++)
                    {
                        Terrname[i] = ListTerr[i].TerritoryName + ":" + ListTerr[i].TerritoryID;
                    }

                    //Adding Labels Names

                    // cmbTerritories.SelectedValue = Terrname[0];



                    //btnUpdate.Enabled = true;


                    #region Control Visibility

                    bool dataexist = DailySalesHandler.SPCHECK_DataExists(date, UserId);
                    if (dataexist)
                    {
                        //HandleTerr1(true);

                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Data Already Submited for: " + date + ". Go to Edit Sales Page to Confirme/View data";

                        //btnUpdate.Enabled = false;

                    }
                    else
                    {

                        //ControlTextboxState();
                        lblMessage.Text = "";

                        //btnUpdate.Enabled = true;

                    }
                    #endregion

                    //ControlTextboxState();
                    #endregion
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadData()
        {


            //Get Region By LoggedUser
            try
            {
                string server = DBCon.GetServerDate();
                DateTime today = DateTime.Parse(server);
                DateTime selectedDate = DateTime.Parse(date);

                objReg = RegionHandler.SPGET_RegionByUser(UserId);

                if (objReg.RegionID == 0)
                {
                    lblMessage.Text = "You have no region assigned!";
                   // btnUpdate.Enabled = false;
                }
                else if (selectedDate > today)
                {
                    lblMessage.Text = "Data Submission is not allowed for: " + selectedDate;
                    //btnUpdate.Enabled = false;
                }
                else
                {

                    //Get Territories by  Region
                    ListTerr = TerritoryHandler.SPGET_TerritoryByRegion(objReg.RegionID);

                    txt_region.Text = objReg.RegionName;



                    #region Load TerritoryNames
                    String[] Terrname = new string[8];
                    for (int i = 0; i < ListTerr.Count; i++)
                    {
                        Terrname[i] = ListTerr[i].TerritoryName + ":" + ListTerr[i].TerritoryID;
                    }

                    //Adding Labels Names

                    cmbTerritories.SelectedValue = Terrname[0];



                   // btnUpdate.Enabled = true;



                    bool dataexist = DailySalesHandler.SPCHECK_DataExists(date, UserId);
                    if (dataexist)
                    {
                        //HandleTerr1(true);

                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Data Already Submited for: " + date + ". Go to Edit Sales Page to Confirme/View data";

                        btnUpdate.Enabled = false;

                    }
                    else
                    {

                        //ControlTextboxState();
                        lblMessage.Text = "";

                        //btnUpdate.Enabled = true;

                    }
                    #endregion

                    //ControlTextboxState();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadTextBox()
        {

            txt_region.ReadOnly = true;
            if (cmbTerritories.SelectedValue != null)
            {
                string theDate = "";
                
                theDate = clnDate.SelectedDate.ToString();

                DateTime myDate = clnDate.SelectedDate;
                DateTime firstOfMonth = new DateTime(myDate.Year,myDate.Month,1);

                System.Data.DataTable dt = TargetsHandler.Get_TargetsPer_Territory(myDate, firstOfMonth, Convert.ToInt32(cmbTerritories.SelectedValue));

                int x = dt.Rows.Count;

                dvRDSales.DataSource = dt;
                dvRDSales.DataBind();

                int b = TargetsHandler.IsEditable(theDate, Convert.ToInt32(cmbTerritories.SelectedValue), UserObj.ID);

                if (x == 2)
                {
                    btnUpdate.Visible = false;
                    btnConfirm.Visible = false;
                    dvRDSales.BackColor = System.Drawing.Color.LightGreen;

                }
                else if (x == 1)
                {
                    btnUpdate.Visible = true;
                    btnConfirm.Visible = true;
                    dvRDSales.BackColor = System.Drawing.Color.Yellow;

                }
                else
                {
                    btnUpdate.Visible = true;
                    btnConfirm.Visible = false;
                    dvRDSales.BackColor = System.Drawing.Color.White;
                }

                Load_Region_Summary();
                Calculate_Total();
               
            }



        }

        private void Load_Region_Summary()
        {
            try
            {
                DataTable dt = new DataTable();

                dt =TargetsHandler.RegionSummary(clnDate.SelectedDate, UserObj.ID);
                dgvRegionSummary.DataSource = dt;
                dgvRegionSummary.DataBind();


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i][1]) == 2)
                    {
                        dgvRegionSummary.Rows[i].BackColor = System.Drawing.Color.LightGreen;
                    }
                    else if (Convert.ToInt32(dt.Rows[i][1]) == 1)
                    {
                        dgvRegionSummary.Rows[i].BackColor = System.Drawing.Color.Yellow;
                    }
                    else
                    {
                        dgvRegionSummary.Rows[i].BackColor = System.Drawing.Color.White;
                    }
                }

            }
            catch (Exception ex)
            {
               
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserObj = (RDSales_Entities.UserEntity)Session["LoggedUser"];


                #region Handle Session
                if (UserObj != null)
                {
                    UserId = UserObj.ID;
                    bool hasPermission = UserEntityHandler.SPCHECK_UserHaspermission(UserId, "SALES_ENTER");
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

                    LoadCoreData();
                    LoadTerritories();

                    date = DBCon.GetServerDate();

                    LoadTextBox();

                }



            }
            catch (Exception ee)
            {

                lblMessage.Text = ee.Message + ": Page Load";
            }
        }
        protected void cmbTerritories_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnConfirm.Visible = false;
        }

        private void Update()
        {
            //--------------------------------------------------------

            DataTable dtDailyTarget = new DataTable();
            dtDailyTarget.Columns.Add("TheDate", typeof(String));
            dtDailyTarget.Columns.Add("TerrID", typeof(int));
            dtDailyTarget.Columns.Add("UserID", typeof(int));
            dtDailyTarget.Columns.Add("ProductCode", typeof(String));
            dtDailyTarget.Columns.Add("Target", typeof(Decimal));

            DataRow workRow;

            for (int i = 0; i < dvRDSales.Rows.Count; i++)
            {
                workRow = dtDailyTarget.NewRow();
                workRow["TheDate"] = clnDate.SelectedDate;
                workRow["TerrID"] = Convert.ToInt32(cmbTerritories.SelectedValue);
                workRow["UserID"] = UserObj.ID;
                workRow["ProductCode"] = dvRDSales.Rows[i].Cells[0].Text;

                if (((TextBox)(dvRDSales.Rows[i].Cells[2].FindControl("TextBox1"))).Text != "")
                {

                    workRow["Target"] = Convert.ToDecimal(((TextBox)(dvRDSales.Rows[i].Cells[2].FindControl("TextBox1"))).Text);
                }
                else
                {
                    workRow["Target"] = 0;
                }

                dtDailyTarget.Rows.Add(workRow);
            }

            TargetsHandler.Update_DailyTarget(dtDailyTarget);

            //--------------------------------------------------------
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string msg = "You are about to Submit Data For :" + clnDate.SelectedDate;


            ClientScript.RegisterStartupScript(this.GetType(), "Submit Alert", "alert('" + msg + "');", true);

            Update();
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTextBox();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Calculate_Total()
        {
            try
            {
                decimal total=0;
                for (int i = 0; i < dvRDSales.Rows.Count; i++)
                {

                    total = total + Convert.ToDecimal(((TextBox)(dvRDSales.Rows[i].Cells[3].FindControl("TextBox2"))).Text);

                }

                TextBox3.Text = total.ToString();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                TargetsHandler.Confirm(clnDate.SelectedDate,Convert.ToInt32(cmbTerritories.SelectedValue), UserObj.ID);

                string theDate = clnDate.SelectedDate.ToString();
                string msg = "You are about to Confirm Data For :" + theDate;


                ClientScript.RegisterStartupScript(this.GetType(), "Submit Alert", "alert('" + msg + "');", true);

                LoadTextBox();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}