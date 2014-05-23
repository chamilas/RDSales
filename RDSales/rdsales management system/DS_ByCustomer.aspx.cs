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
    public partial class DS_ByCustomer : System.Web.UI.Page
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


                    bool hasPermission = UserEntityHandler.SPCHECK_UserHaspermission(UserObj.ID, "DEPT_REPORT_DIRECT_CUSTOMER");
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


                LoadData(txt_date.Text,CustomerHandler.splitCustomerCode(txt_customer.Text));

            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": Page Load";
            }
        }

        protected void txt_date_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(txt_date.Text,CustomerHandler.splitCustomerCode(txt_customer.Text));
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": txt_date_TextChanged";
            }
        }

        protected void txt_customer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(txt_date.Text, CustomerHandler.splitCustomerCode(txt_customer.Text));
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": txt_customer_TextChanged";
            }
        }

        private void LoadData(string date,string Cuscode)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();

            try
            {
                DateTime Selcteddate = DateTime.Parse(date);
                GridView1.DataSource = FormatTable(DirectSalesHandler.SPGET_DirectSales_ByCustomer(Selcteddate,Cuscode));
                GridView1.DataBind();

            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": Load Data";
            }

        }

        private DataTable FormatTable(DataTable original)
        {
            DataTable final = new DataTable();
            decimal Dtotal = 0;
            decimal Ctotal = 0;
            decimal Vtotal = 0;


            decimal daily = 0;
            decimal Cum = 0;
            decimal val = 0;



            try
            {
                if (original.Rows.Count > 0)
                {

                    final.Columns.Add("Product Range", typeof(string));
                    final.Columns.Add("Description", typeof(string));
                    final.Columns.Add("Prod Code", typeof(string));
                    final.Columns.Add("Daily ACH", typeof(string));
                    final.Columns.Add("Cumulative ACH", typeof(string));
                    final.Columns.Add("Cumulative VaLue", typeof(string));

                    foreach (DataRow r in original.Rows)
                    {
                        daily = Decimal.Parse(r["Daily"].ToString());
                        Cum = Decimal.Parse(r["Cum"].ToString());
                        val = decimal.Parse(r["C_Value"].ToString());


                        final.Rows.Add(r["ProdType"].ToString(), r["DES"].ToString(), r["ITCode"].ToString(), string.Format("{0:#,##0.00}", daily), string.Format("{0:#,##0.00}", Cum), string.Format("{0:#,##0.00}", val));

                        Dtotal = Dtotal + daily;
                        Ctotal = Ctotal + Cum;
                        Vtotal = Vtotal + val;

                    }

                    final.Rows.Add("Total", "", "", string.Format("{0:#,##0.00}", Dtotal), string.Format("{0:#,##0.00}", Ctotal), string.Format("{0:#,##0.00}", Vtotal));
                }
            }


            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Format  Table";
            }

            return final;
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
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;




                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.DarkSlateGray;
                    e.Row.Cells[3].Font.Bold = true;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.DarkSlateGray;
                    e.Row.Cells[4].Font.Bold = true;
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.DarkSlateGray;
                    e.Row.Cells[5].Font.Bold = true;


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


    }
}