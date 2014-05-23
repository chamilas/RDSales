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
    public partial class RangeProdViseSales : System.Web.UI.Page
    {
        private RDSales_Entities.UserEntity UserObj;

        private decimal cumAch = 0;
     

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UserObj = (RDSales_Entities.UserEntity)Session["LoggedUser"];


                #region Handle User Session

                if (UserObj != null)
                {


                    bool hasPermission = UserEntityHandler.SPCHECK_UserHaspermission(UserObj.ID, "DEPT_REPORT_PRODVISE");
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
                    txt_from.Text = DailySalesHandler.getStartdateofMonth(System.DateTime.Today);
                    txt_to.Text = System.DateTime.Today.ToShortDateString();
                }


                

            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": Page Load";
            }
        }

        private void loadData(string from,string to)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();
            GridView3.DataSource = null;
            GridView3.DataBind();
            GridView4.DataSource = null;
            GridView4.DataBind();

            lbl_prod1.Text = "";
            lbl_prod2.Text = "";
            lbl_prod3.Text = "";
            lbl_prod4.Text = "";




            try
            {


                DateTime from_ = DateTime.Parse(from);
                DateTime to_ = DateTime.Parse(to);
                string bProdCode = ProductHandler.splitProdCode(txt_product.Text);
                DataTable products = ProductHandler.SPGET_Products_ByBasicProd(bProdCode);

                lbl_header.Text = ProductHandler.splitProdName(txt_product.Text) + " RD Achievement from " + from_.ToShortDateString() + " to " + to_.ToShortDateString();

                
                List<DataTable> List = new List<DataTable>();
                List.Clear();
                foreach (DataRow row in products.Rows)
                {
                    DataTable d = DailySalesHandler.SPGET_DailySalesProVise_ForRange(row[0].ToString(),from_,to_);
                    List.Add(d);
                }

                if (List.Count > 0)
                {
                    decimal caseqry = Decimal.Parse(products.Rows[0][6].ToString());

                    DataTable temp = FormatTable(List[0], caseqry);


                    if (temp.Rows.Count > 0)
                    {
                        temp.Rows[0].Delete();
                    }

                    GridView1.DataSource = temp;
                    GridView1.DataBind();
                    lbl_prod1.Text = products.Rows[0][1].ToString();
                }

                if (List.Count > 1)
                {
                    decimal caseqry = Decimal.Parse(products.Rows[1][6].ToString());
                    DataTable temp = FormatTable(List[1], caseqry);

                    if (temp.Rows.Count > 0)
                    {
                        temp.Rows[0].Delete();
                    }

                    GridView2.DataSource = temp;
                    GridView2.DataBind();
                    lbl_prod2.Text = products.Rows[1][1].ToString();
                }

                if (List.Count > 2)
                {
                    decimal caseqry = Decimal.Parse(products.Rows[2][6].ToString());
                    DataTable temp = FormatTable(List[2], caseqry);

                    if (temp.Rows.Count > 0)
                    {
                        temp.Rows[0].Delete();
                    }


                    GridView3.DataSource = temp;
                    GridView3.DataBind();
                    lbl_prod3.Text = products.Rows[2][1].ToString();
                }

                if (List.Count > 3)
                {
                    decimal caseqry = Decimal.Parse(products.Rows[3][6].ToString());
                    DataTable temp = FormatTable(List[3], caseqry);

                    if (temp.Rows.Count > 0)
                    {
                        temp.Rows[0].Delete();
                    }


                    GridView4.DataSource = temp;
                    GridView4.DataBind();
                    lbl_prod4.Text = products.Rows[3][1].ToString();
                }


            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Binding data to Grid";
            }


        }

        private DataTable FormatTable(DataTable tb, decimal caseQty)
        {
            DataTable final = new DataTable();

            try
            {
                DataView v = tb.DefaultView;
                v.Sort = "Name";
                DataTable original = v.ToTable();
                if (original.Rows.Count > 0)
                {

                    final.Columns.Add("Region", typeof(string));
                    final.Columns.Add("TERRITORY", typeof(string));
                    //final.Columns.Add("MON.TAR", typeof(string));
                    //final.Columns.Add("ACH", typeof(string));

                    final.Columns.Add("Cum ACH", typeof(string));
                    //final.Columns.Add("Cum PCT", typeof(string));

                    string region = "";
                    int count = 0;

                    //decimal MontTar_sub = 0;
                    decimal CumAch_sub = 0;
                




                    //Remove Duplicate Region Names
                    foreach (DataRow r in original.Rows)
                    {
                        if (region != r[1].ToString())
                        {

                            region = r[1].ToString();
                            count = 0;

                            
                            
                            decimal CumAch = 0;
                            

                            //Convert values to case
                            if (caseQty > 0)
                            {
                                
                                CumAch = Decimal.Round(Decimal.Parse(r[6].ToString()) / caseQty, 2);

                            }

                            CumAch_sub = CumAch_sub + CumAch;


                            final.Rows.Add("Sub Total", "",   string.Format("{0:#,##0.00}", (CumAch_sub - CumAch)));

                            CumAch_sub = CumAch;

                            final.Rows.Add(

                            r[1].ToString(),//Region
                            r[2].ToString(),//Terr
                           
                            string.Format("{0:#,##0.00}", CumAch)//CumAch
                         
                            );



                        }
                        else
                        {
                            count++;

                            decimal CumAch = 0;
                            

                            //Convert values to case
                            if (caseQty > 0)
                            {
                                CumAch = Decimal.Round(Decimal.Parse(r[6].ToString()) / caseQty, 2);

                            }


                            if (count == 1)
                            {
                                CumAch_sub = CumAch_sub + CumAch;

                                final.Rows.Add(


                                     "",//Region
                                     r[2].ToString(),//Terr
                                    string.Format("{0:#,##0.00}", CumAch)//CumAch
                                 

                                         );
                            }

                            else
                            {

                                decimal CumAch_ = 0;
                               

                                //Convert values to case
                                if (caseQty > 0)
                                {
                                   
                                    CumAch_ = Decimal.Round(Decimal.Parse(r[6].ToString()) / caseQty, 2);

                                }

                                CumAch_sub = CumAch_sub + CumAch_;

                                

                                final.Rows.Add(


                          "",//Region
                          r[2].ToString(),//Terr
                        
                          
                           string.Format("{0:#,##0.00}", CumAch_)//CumAch
                          

                          );
                            }


                        }

                       
                        cumAch = cumAch + Decimal.Round(decimal.Parse(r[6].ToString()) / caseQty, 2);
                    }



                    final.Rows.Add("Sub Total", "", string.Format("{0:#,##0.00}", CumAch_sub));
                    final.Rows.Add("Total", "", string.Format("{0:#,##0.00}", cumAch));

                }

              
               
                cumAch = 0;
               
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Format Table";
            }
            return final;
        }

        private DataTable FormatSummeryTable(DataTable original)
        {
            DataTable final = new DataTable();
            string status = "";

            try
            {
                if (original.Rows.Count > 0)
                {

                    final.Columns.Add("Region", typeof(string));
                    final.Columns.Add("ASM", typeof(string));
                    final.Columns.Add("Status", typeof(string));

                    foreach (DataRow r in original.Rows)
                    {
                        if (r["count"].ToString() == "1")
                        {

                            status = "Available";

                        }
                        else
                        {
                            status = "Not Available";
                        }

                        final.Rows.Add(r["Name"].ToString(), r["ASM"].ToString(), status);

                    }
                }

            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Format Sum Table";
            }

            return final;
        }

        protected void txt_product_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadData(txt_from.Text,txt_to.Text);
                txt_product.Focus();
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Date text change";
            }
        }

        protected void txt_from_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadData(txt_from.Text, txt_to.Text);
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Date text change";
            }
        }

        protected void txt_to_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadData(txt_from.Text, txt_to.Text);
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Date text change";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
             

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Table tbl = (Table)e.Row.Parent;


                    if (e.Row.Cells[0].Text == "Total")
                    {
                        e.Row.BackColor = System.Drawing.Color.PowderBlue;
                        e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Font.Bold = true;
                    }
                    if (e.Row.Cells[0].Text == "Sub Total")
                    {

                        e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Font.Bold = true;
                        e.Row.BorderWidth = Unit.Pixel(2);
                        e.Row.BorderColor = System.Drawing.Color.DimGray;
                        e.Row.BackColor = System.Drawing.Color.MintCream;
                    }
                    else if (e.Row.Cells[0].Text == "Central" | e.Row.Cells[0].Text == "Colombo1" | e.Row.Cells[0].Text == "Colombo2" | e.Row.Cells[0].Text == "East" | e.Row.Cells[0].Text == "NCP" | e.Row.Cells[0].Text == "North" | e.Row.Cells[0].Text == "North West1" | e.Row.Cells[0].Text == "North West2" | e.Row.Cells[0].Text == "Sabaragamuwa" | e.Row.Cells[0].Text == "Southern" | e.Row.Cells[0].Text == "Western1" | e.Row.Cells[0].Text == "Western2" | e.Row.Cells[0].Text == "Uva")
                    {
                        e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#E4E4E4");
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Black;

                    }

                }
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Row Data Bound";
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
               

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Table tbl = (Table)e.Row.Parent;
                    if (e.Row.Cells[0].Text == "Total")
                    {
                        e.Row.BackColor = System.Drawing.Color.PowderBlue;
                        e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Font.Bold = true;
                    }

                    if (e.Row.Cells[0].Text == "Sub Total")
                    {

                        e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Font.Bold = true;
                        e.Row.BorderWidth = Unit.Pixel(2);
                        e.Row.BorderColor = System.Drawing.Color.Gray;
                        e.Row.BackColor = System.Drawing.Color.MintCream;
                    }

                 
                }
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Row Data Bound";
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Table tbl = (Table)e.Row.Parent;
                    if (e.Row.Cells[0].Text == "Total")
                    {
                        e.Row.BackColor = System.Drawing.Color.PowderBlue;
                        e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Font.Bold = true;
                    }

                    if (e.Row.Cells[0].Text == "Sub Total")
                    {

                        e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Font.Bold = true;
                        e.Row.BorderWidth = Unit.Pixel(2);
                        e.Row.BorderColor = System.Drawing.Color.Gray;
                        e.Row.BackColor = System.Drawing.Color.MintCream;
                    }


                }
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Row Data Bound";
            }
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Table tbl = (Table)e.Row.Parent;
                    if (e.Row.Cells[0].Text == "Total")
                    {
                        e.Row.BackColor = System.Drawing.Color.PowderBlue;
                        e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Font.Bold = true;
                    }

                    if (e.Row.Cells[0].Text == "Sub Total")
                    {

                        e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Font.Bold = true;
                        e.Row.BorderWidth = Unit.Pixel(2);
                        e.Row.BorderColor = System.Drawing.Color.Gray;
                        e.Row.BackColor = System.Drawing.Color.MintCream;
                    }


                }
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Row Data Bound";
            }
        }
    }
}