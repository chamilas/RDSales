using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDSales_Entity_Handler;
using RDSales_Entities;
using System.Data;

namespace RDSales_Management_System
{
    public partial class DS_InProductRange : System.Web.UI.Page
    {
        private RDSales_Entities.UserEntity UserObj;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserObj = (RDSales_Entities.UserEntity)Session["LoggedUser"];


                #region Handle User Session

                if (UserObj != null)
                {


                    bool hasPermission = UserEntityHandler.SPCHECK_UserHaspermission(UserObj.ID, "DEPT_REPORT_DIRECT_PRODRANGE");
                    if (!hasPermission)
                    {
                        Response.Redirect("AccessDenied.aspx");
                    }


                }
                else
                {
                    Response.Redirect("SessionTimedOut.aspx");
                }

                #endregion

                if (!IsPostBack)
                {
                    txt_date.Text = System.DateTime.Today.ToShortDateString();
                }


                LoadData(txt_date.Text);

            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": Page Load";
            }
        }


        private void LoadData(string date)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();

            try
            {
                DateTime Selcteddate = DateTime.Parse(date);
                GridView1.DataSource = FormatTable(DirectSalesHandler.SPGET_DirectSales_INProductType(Selcteddate));
                GridView1.DataBind();

            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": Load Data";
            }
 
        }

        protected void txt_date_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(txt_date.Text);
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": txt_date_TextChanged";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;

             



                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.DarkSlateGray;
                    e.Row.Cells[3].Font.Bold = true;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.DarkSlateGray;
                    e.Row.Cells[4].Font.Bold = true;


                    if (e.Row.Cells[0].Text == "Total")
                    {
                        e.Row.BackColor = System.Drawing.Color.PowderBlue;
                        e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Font.Bold = true;
                    }



                    // when mouse is over the row, save original color to new attribute, and change it to highlight color
                    e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#E6FFFD'");

                    // when mouse leaves the row, change the bg color to its original value  
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
                }
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Row Data Bound";
            }
        }


        private DataTable FormatTable(DataTable original)
        {
            DataTable final = new DataTable();
            decimal Dtotal = 0;
            decimal Ctotal = 0;


            decimal daily = 0;
            decimal Cum = 0;

          

            try
            {
                if (original.Rows.Count > 0)
                {

                    final.Columns.Add("Product Range", typeof(string));
                    final.Columns.Add("Customer Code", typeof(string));
                    final.Columns.Add("Customer Name", typeof(string));
                    final.Columns.Add("Daily ACH", typeof(string));
                    final.Columns.Add("Cumulative ACH", typeof(string));

                    foreach (DataRow r in original.Rows)
                    {
                        daily = Decimal.Parse(r["Daily"].ToString());
                        Cum = Decimal.Parse(r["Cum"].ToString());

                        final.Rows.Add(r["ProdType"].ToString(), r["CUSCODE"].ToString(), r["Name"].ToString(),string.Format("{0:#,##0.00}", daily), string.Format("{0:#,##0.00}",Cum));

                        Dtotal = Dtotal + daily;
                        Ctotal = Ctotal + Cum;

                    }

                    final.Rows.Add("Total", "", "",  string.Format("{0:#,##0.00}", Dtotal),  string.Format("{0:#,##0.00}",Ctotal));
                }
            }


            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Format  Table";
            }

            return final;
        }

    }
}