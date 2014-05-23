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
    public partial class RDSales_Data : System.Web.UI.Page
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

                cmbYear.Text = today.Year.ToString();
                cmbMonth.Text = today.Month.ToString();
                cmbDay.Text = today.Day.ToString();

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

                theDate = cmbYear.Text + "-" + cmbMonth.SelectedValue.ToString() + "-" + cmbDay.Text;

                System.Data.DataTable dt = DailySalesHandler.GetTerritorySales(theDate, Convert.ToInt32(cmbTerritories.SelectedValue));


                dvRDSales.DataSource = dt;
                dvRDSales.DataBind();

                if (dt.Rows.Count > 0)
                {
                    txt_DayNo.Text = dt.Rows[0]["DayNo"].ToString();
                    txtTotalPC.Text = dt.Rows[0]["PC_All"].ToString();
                }
                else
                {
                    txt_DayNo.Text ="0";
                    txtTotalPC.Text = "0";
                }
                int x = DailySalesHandler.IsEditable(theDate, Convert.ToInt32(cmbTerritories.SelectedValue), UserObj.ID);

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

                RemoveDuplicates();
                Load_Region_Summary();

            }



        }

        private void Load_Region_Summary()
        {
            try
            {
                DataTable dt= new DataTable();

                 dt = DailySalesHandler.RegionSummary(cmbYear.Text + "-" + cmbMonth.SelectedValue.ToString() + "-" + cmbDay.Text, UserObj.ID);
                 dgvRegionSummary.DataSource = dt;
                dgvRegionSummary.DataBind();


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[i][1])==2)
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

                //dgvRegionSummary.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
               
            }
        }
        private void RemoveDuplicates()
        {
            if (dvRDSales.Rows.Count > 0)
            {
                string currentSearch = dvRDSales.Rows[0].Cells[3].Text;

                for (int i = 0; i < dvRDSales.Rows.Count - 1; i++)
                {
                    if (currentSearch == dvRDSales.Rows[i + 1].Cells[3].Text)
                    {
                        dvRDSales.Rows[i + 1].Cells[3].Visible = false;
                        dvRDSales.Rows[i + 1].Cells[4].Visible = false;
                        dvRDSales.Rows[i + 1].Cells[5].Visible = false;
                    }
                    else
                    {
                        currentSearch = dvRDSales.Rows[i + 1].Cells[3].Text;
                    }


                }
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
        protected void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
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

        private void Update()
        {
            //--------------------------------------------------------

            DataTable dtDailySales = new DataTable();
            dtDailySales.Columns.Add("TheDate", typeof(String));
            dtDailySales.Columns.Add("TerrID", typeof(int));
            dtDailySales.Columns.Add("UserID", typeof(int));
            dtDailySales.Columns.Add("DayNo", typeof(int));
            dtDailySales.Columns.Add("RouteNo", typeof(int));
            dtDailySales.Columns.Add("ProductCode", typeof(String));
            dtDailySales.Columns.Add("Achievement", typeof(Decimal));
            dtDailySales.Columns.Add("PC", typeof(int));
            dtDailySales.Columns.Add("PC_New", typeof(int));
            dtDailySales.Columns.Add("PC_All", typeof(int));

            DataRow workRow;

            for (int i = 0; i < dvRDSales.Rows.Count; i++)
            {
                workRow = dtDailySales.NewRow();
                workRow["TheDate"] = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmbDay.Text;
                workRow["TerrID"] = Convert.ToInt32(cmbTerritories.SelectedValue);
                workRow["UserID"] = UserObj.ID;
                workRow["DayNo"] = Convert.ToInt32(txt_DayNo.Text);
                workRow["RouteNo"] = 0;
                workRow["ProductCode"] = dvRDSales.Rows[i].Cells[0].Text;

                if (((TextBox)(dvRDSales.Rows[i].Cells[2].FindControl("TextBox1"))).Text != "")
                {

                    workRow["Achievement"] = Convert.ToDecimal(((TextBox)(dvRDSales.Rows[i].Cells[2].FindControl("TextBox1"))).Text);
                }
                else
                {
                    workRow["Achievement"] = 0;
                }

                if (((TextBox)(dvRDSales.Rows[i].Cells[4].FindControl("TextBox2"))).Text != "")
                {
                    workRow["PC"] = Convert.ToInt32(((TextBox)(dvRDSales.Rows[i].Cells[4].FindControl("TextBox2"))).Text);
                }
                else
                {
                    workRow["PC"] = 0;
                }

                if (((TextBox)(dvRDSales.Rows[i].Cells[5].FindControl("TextBox3"))).Text != "")
                {
                    workRow["PC_New"] = Convert.ToInt32(((TextBox)(dvRDSales.Rows[i].Cells[5].FindControl("TextBox3"))).Text);
                }
                else
                {
                    workRow["PC_New"] = 0;
                }

                workRow["PC_All"] = Convert.ToInt32(txtTotalPC.Text);


                dtDailySales.Rows.Add(workRow);
            }

            DailySalesHandler.Update_DailySales(dtDailySales);

            //--------------------------------------------------------
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string theDate = cmbYear.Text + "-" + cmbMonth.SelectedValue.ToString() + "-" + cmbDay.Text;
            string msg = "You are about to Submit Data For :" + theDate;


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
        protected void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = false;
            btnUpdate.Visible = false;

            dvRDSales.DataSource = null;
            dvRDSales.DataBind();

            txtTotalPC.Text = "0";
            txt_DayNo.Text = "0";
        }
        protected void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConfirm.Visible = false;
            btnUpdate.Visible = false;

            dvRDSales.DataSource = null;
            dvRDSales.DataBind();

            txtTotalPC.Text = "0";
            txt_DayNo.Text = "0";
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                DailySalesHandler.Confirm(cmbYear.Text + "-" + cmbMonth.Text + "-" + cmbDay.Text,Convert.ToInt32(cmbTerritories.SelectedValue), UserObj.ID);

                string theDate = cmbYear.Text + "-" + cmbMonth.SelectedValue.ToString() + "-" + cmbDay.Text;
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