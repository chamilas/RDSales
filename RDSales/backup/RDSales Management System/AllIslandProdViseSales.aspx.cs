using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDSales_Entities;
using RDSales_Entity_Handler;
using System.Data;
using System.Text;
using AjaxControlToolkit;
using System.IO;


namespace RDSales_Management_System
{
    public partial class AllIslandProdViseSales : System.Web.UI.Page
    {
        private  RDSales_Entities.UserEntity UserObj;

        private decimal target = 0;
        private decimal ach = 0;
        private decimal perc = 0;
        private decimal cumTar = 0;
        private decimal cumAch = 0;
        private decimal cumPerc = 0;
        private decimal tot_tar_Qty = 0;
        private decimal tot_ach_qty = 0;
        private decimal tot_CumAch_qty = 0;
        private decimal tot_CumPc_qty = 0;
        private DataTable final = new DataTable();


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
                       txt_date.Text = System.DateTime.Today.ToShortDateString();
                }

              

                Accordion1.SelectedIndex = -1;
                
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": Page Load";
            }
        }

        private void loadData(string date)
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


                DateTime Selcteddate = DateTime.Parse(date);
                string bProdCode = ProductHandler.splitProdCode(txt_product.Text);
                DataTable products = ProductHandler.SPGET_Products_ByBasicProd(bProdCode);

                lbl_header.Text = ProductHandler.splitProdName(txt_product.Text) + " RD Achievement at " + Selcteddate.ToLongDateString();


                #region Get Regional data Submission Status
                DataTable  dt = DailySalesHandler.SPCHECK_RegionalDataSubmissionStatus(Selcteddate);

                
                

                GridView5.DataSource = FormatSummeryTable(dt);
                GridView5.DataBind();
                int countP = 0;

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if (r["count"].ToString() == "1")
                        {
                            countP++;
                        }
                    }

                }
                else
                {
                    countP = 0;
                }

                if (countP < dt.Rows.Count)
                {


                    accPanel1.HeaderContainer.ForeColor = System.Drawing.Color.White;
                    accPanel1.HeaderContainer.BackColor = System.Drawing.ColorTranslator.FromHtml("#C02B2B");
                    accPanel1.HeaderContainer.Controls.Add(new LiteralControl("Regional Data Submision: " + countP + "/" + dt.Rows.Count));
                }
                else
                {

                    accPanel1.HeaderContainer.ForeColor = System.Drawing.Color.White;
                    accPanel1.HeaderContainer.BackColor = System.Drawing.ColorTranslator.FromHtml("#5D7056");
                    accPanel1.HeaderContainer.Controls.Add(new LiteralControl("Regional Data Submision: " + countP + "/" + dt.Rows.Count));
                }
    
               
                #endregion
               
               
                List<DataTable> List = new List<DataTable>();
                List.Clear();
                foreach (DataRow row in products.Rows)
                {
                    DataTable d = DailySalesHandler.SPGET_DailySalesProVise_FromRDSales(row[0].ToString(), Selcteddate);
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

                   
                    ViewState.Add("Datatable", temp);
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
                    final.Columns.Add("MON.TAR", typeof(string));
                    final.Columns.Add("ACH", typeof(string));

                    final.Columns.Add("Cum ACH", typeof(string));
                    final.Columns.Add("Cum PCT", typeof(string));

                    string region = "";
                    string asm = "";
                    int count = 0;

                    //Sub totals
                    decimal totAch = 0;
                    decimal MontTar_sub = 0;
                    decimal CumAch_sub = 0;
                    decimal CumPer_sub = 0;




                    //Remove Duplicate Region Names
                    foreach (DataRow r in original.Rows)
                    {
                        if (region != r[1].ToString())
                        {

                            region = r[1].ToString();
                            asm = RegionHandler.SPGET_ASMNameByREgionName_FromRDSales(region);
                            count = 0;

                            decimal target_ = 0;
                            decimal ach_ = 0;
                            decimal CumAch = 0;
                            decimal CumPer = 0;

                            //Convert values to case
                            if (caseQty > 0)
                            {
                                target_ = Decimal.Round(Decimal.Parse(r[3].ToString()) / caseQty, 2);
                                ach_ = Decimal.Round(Decimal.Parse(r[4].ToString()) / caseQty, 2);
                                CumAch = Decimal.Round(Decimal.Parse(r[6].ToString()) / caseQty, 2);

                            }



                            totAch = totAch + ach_;
                            MontTar_sub = MontTar_sub + target_;
                            CumAch_sub = CumAch_sub + CumAch;


                            if (target_ > 0)
                            {
                                CumPer = (CumAch / target_) * 100;
                            }
                            else
                            {
                                CumPer = 0;
                            }

                            if (MontTar_sub - target_ > 0)
                            {
                                CumPer_sub = Decimal.Round((CumAch_sub - CumAch) / (MontTar_sub - target_) * 100, 2);
                            }

                            final.Rows.Add("Sub Total", "", string.Format("{0:#,##0.00}", (MontTar_sub - target_)), string.Format("{0:#,##0.00}", (totAch - ach_)), string.Format("{0:#,##0.00}", (CumAch_sub - CumAch)), CumPer_sub);

                            totAch = ach_;
                            MontTar_sub = target_;
                            CumAch_sub = CumAch;

                            final.Rows.Add(

                            r[1].ToString(),//Region
                            r[2].ToString(),//Terr
                            string.Format("{0:#,##0.00}", target_),//tar
                            string.Format("{0:#,##0.00}", ach_),//ach



                            string.Format("{0:#,##0.00}", CumAch),//CumAch
                            string.Format("{0:#,##0.00}", CumPer) //Cumpercentage
                            );



                        }
                        else
                        {
                            count++;


                            decimal target_ = 0;
                            decimal ach_ = 0;
                            decimal CumAch = 0;
                            decimal CumPer = 0;

                            //Convert values to case
                            if (caseQty > 0)
                            {
                                target_ = Decimal.Round(Decimal.Parse(r[3].ToString()) / caseQty, 2);
                                ach_ = Decimal.Round(Decimal.Parse(r[4].ToString()) / caseQty, 2);
                                CumAch = Decimal.Round(Decimal.Parse(r[6].ToString()) / caseQty, 2);

                            }



                            if (target_ > 0)
                            {
                                CumPer = (CumAch / target_) * 100;
                            }
                            else
                            {
                                CumPer = 0;
                            }

                            if (count == 1)
                            {
                                totAch = totAch + ach_;
                                MontTar_sub = MontTar_sub + target_;
                                CumAch_sub = CumAch_sub + CumAch;

                                final.Rows.Add(


                                     "",//Region
                                     r[2].ToString(),//Terr
                                     string.Format("{0:#,##0.00}", target_),//tar
                                     string.Format("{0:#,##0.00}", ach_),//ach



                                    string.Format("{0:#,##0.00}", CumAch),//CumAch
                                    string.Format("{0:#,##0.00}", CumPer)//Cumpercentage

                                         );
                            }

                            else
                            {

                                decimal target3 = 0;
                                decimal ach3 = 0;
                                decimal CumAch_ = 0;
                                decimal CumPer_ = 0;

                                //Convert values to case
                                if (caseQty > 0)
                                {
                                    target3 = Decimal.Round(Decimal.Parse(r[3].ToString()) / caseQty, 2);
                                    ach3 = Decimal.Round(Decimal.Parse(r[4].ToString()) / caseQty, 2);
                                    CumAch_ = Decimal.Round(Decimal.Parse(r[6].ToString()) / caseQty, 2);

                                }

                                totAch = totAch + ach3;
                                MontTar_sub = MontTar_sub + target3;
                                CumAch_sub = CumAch_sub + CumAch_;

                                if (target3 > 0)
                                {
                                    CumPer_ = (CumAch_ / target3) * 100;
                                }
                                else
                                {
                                    CumPer_ = 0;
                                }

                                final.Rows.Add(


                          "",//Region
                          r[2].ToString(),//Terr
                          string.Format("{0:#,##0.00}", target3),//tar
                          string.Format("{0:#,##0.00}", ach3),//ach



                           string.Format("{0:#,##0.00}", CumAch_),//CumAch
                           string.Format("{0:#,##0.00}", CumPer_)//Cumpercentage

                          );
                            }


                        }

                        target = target + Decimal.Round(decimal.Parse(r[3].ToString()) / caseQty, 2);
                        ach = ach + Decimal.Round(decimal.Parse(r[4].ToString()) / caseQty, 2);


                        cumAch = cumAch + Decimal.Round(decimal.Parse(r[6].ToString()) / caseQty, 2);
                    }



                    cumPerc = Decimal.Round((cumAch / target) * 100, 2);

                    if (MontTar_sub > 0)
                    {
                        CumPer_sub = Decimal.Round((CumAch_sub) / (MontTar_sub) * 100, 2);
                    }


                    final.Rows.Add("Sub Total", "", string.Format("{0:#,##0.00}", MontTar_sub), string.Format("{0:#,##0.00}", totAch), string.Format("{0:#,##0.00}", CumAch_sub), CumPer_sub);
                    final.Rows.Add("Total", "", string.Format("{0:#,##0.00}", target), string.Format("{0:#,##0.00}", ach), string.Format("{0:#,##0.00}", cumAch), cumPerc);

                }

                target = 0;
                ach = 0;
                perc = 0;
                cumTar = 0;
                cumAch = 0;
                cumPerc = 0;
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
                loadData(txt_date.Text);
                txt_product.Focus();
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Date text change";
            }
        }

        protected void txt_date_TextChanged(object sender, EventArgs e)
        {
            try
            {
                loadData(txt_date.Text);
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
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;




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

                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;




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

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;


                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;



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
                    else if (e.Row.Cells[0].Text == "Central" | e.Row.Cells[0].Text == "Colombo1" | e.Row.Cells[0].Text == "Colombo2" | e.Row.Cells[0].Text == "East" | e.Row.Cells[0].Text == "NCP" | e.Row.Cells[0].Text == "North" | e.Row.Cells[0].Text == "North West1" | e.Row.Cells[0].Text == "North West2" | e.Row.Cells[0].Text == "Sabaragamuwa" | e.Row.Cells[0].Text == "Southern" | e.Row.Cells[0].Text == "Western1" | e.Row.Cells[0].Text == "Western2" | e.Row.Cells[0].Text == "Uva")
                    {
                        e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#E4E4E4");
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Black;

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

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                e.Row.Cells[0].Visible = false;
                e.Row.Cells[1].Visible = false;

                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;




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
                    else if (e.Row.Cells[0].Text == "Central" | e.Row.Cells[0].Text == "Colombo1" | e.Row.Cells[0].Text == "Colombo2" | e.Row.Cells[0].Text == "East" | e.Row.Cells[0].Text == "NCP" | e.Row.Cells[0].Text == "North" | e.Row.Cells[0].Text == "North West1" | e.Row.Cells[0].Text == "North West2" | e.Row.Cells[0].Text == "Sabaragamuwa" | e.Row.Cells[0].Text == "Southern" | e.Row.Cells[0].Text == "Western1" | e.Row.Cells[0].Text == "Western2" | e.Row.Cells[0].Text == "Uva")
                    {
                        e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#E4E4E4");
                        e.Row.Cells[0].ForeColor = System.Drawing.Color.Black;

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

        #region Web service: Bound to Pop-up control extender

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string GetRegionalDataSubmissionStatus(string contextKey)
        {
            StringBuilder b = new StringBuilder();
            try
            {

                DataTable dt = DailySalesHandler.SPCHECK_RegionalDataSubmissionStatus(DateTime.Parse(contextKey));

                //Formatting the output to a table


                b.Append("<table style='background-color:#FFFBD0; border: #42454B 3px solid; ");
                b.Append("width:280px; font-size:9pt; font-family:Trebuchet MS, Arial, Helvetica, sans-serif;' cellspacing='0' cellpadding='0'>");

                b.Append("<tr><td colspan='4' style='background-color:#42454B; color:white;'>");
                b.Append("<b>" + contextKey + "</b>"); b.Append("</td></tr>");


                //b.Append("<tr style='background-color:#E6E6FA;'>");
                //b.Append("<td style='width:200px;'><b>" + "Main Activity" + "</b></td>");
                //b.Append("<td style='width:80px;'><b>" + "SequenceNo" + "</b></td>");
                //b.Append("</tr>");
                //foreach (DataRow row in dt.Rows)
                //{
                //    //Values
                //    string MainAct = row["MainActivity"].ToString();
                //    string SeqNo = row["SequenceNo"].ToString();
                //    string Status = row["BatchActStatus"].ToString();

                //    if (Status == "2")
                //    {
                //        b.Append("<tr style='background-color:#ADFD71;'>");
                //    }
                //    else if (Status == "1" || Status == "3")
                //    {
                //        b.Append("<tr style='background-color:#FAFF5C;'>");
                //    }
                //    else
                //    {
                //        b.Append("<tr style='background-color:#FFFFFF;'>");
                //    }


                //    b.Append("<td>" + MainAct + "</td>");
                //    b.Append("<td>" + SeqNo + "</td>");
                //    b.Append("</tr>");

                //}



                b.Append("</table>");

            }
            catch (Exception e)
            {

                b.Append(e.Message);
            }

            return b.ToString();
        }

        #endregion

        protected void img_magnify_DataBinding(object sender, EventArgs e)
        {
            PopupControlExtender pce = FindControl("img_magnify_PopupControlExtender") as PopupControlExtender;

            string behaviorID = "pce_" + 1;
            pce.BehaviorID = behaviorID;

            Image img = (Image)FindControl("img_magnify");

            string OnMouseOverScript = string.Format("$find('{0}').showPopup();", behaviorID);
            string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);

            img.Attributes.Add("onmouseover", OnMouseOverScript);
            img.Attributes.Add("onmouseout", OnMouseOutScript);
        }

        protected void img_magnify_Load(object sender, EventArgs e)
        {
            //PopupControlExtender pce = FindControl("img_magnify_PopupControlExtender") as PopupControlExtender;

            //string behaviorID = "pce_" + 1;
            //pce.BehaviorID = "pce2";

            //Image img = (Image)FindControl("img_magnify");

            //string OnMouseOverScript = string.Format("$find('{0}').showPopup();",behaviorID);
            //string OnMouseOutScript = string.Format("$find('{0}').hidePopup();", behaviorID);

            //img.Attributes.Add("onmouseover", OnMouseOverScript);
            //img.Attributes.Add("onmouseout", OnMouseOutScript);
        }

        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
            

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Table tbl = (Table)e.Row.Parent;
                    if (e.Row.Cells[2].Text == "Available")
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#E9FFBF");
                        e.Row.ForeColor = System.Drawing.Color.DarkBlue;
                        e.Row.Font.Bold = true;
                    }

                  

                }
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + " Row Data Bound";
            }
        }

     

        public static void WriteAttachment(string FileName, string FileType, string content)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.ClearHeaders();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
            Response.ContentType = FileType;
            Response.Write(content);
            Response.End();

        }
    }
}