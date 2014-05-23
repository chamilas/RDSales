using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDSales_Entities;
using RDSales_Entity_Handler;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace RDSales_Management_System
{
    public partial class AllIslandDailySales : System.Web.UI.Page
    {
        private  RDSales_Entities.UserEntity UserObj;
        int UserId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_status.Text = "";
                UserObj = (RDSales_Entities.UserEntity)Session["LoggedUser"];
                #region Handle Session
                if (UserObj != null)
                {
                    UserId = UserObj.ID;
                    bool hasPermission = UserEntityHandler.SPCHECK_UserHaspermission(UserId, "DEPT_REPORT");

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
                    DateTime date = System.DateTime.Today;
                    txt_date.Text = date.ToShortDateString();
                    LoadReport(date);

                }

            }
            catch (Exception ee)
            {

                lbl_status.ForeColor = System.Drawing.Color.Red;
                lbl_status.Text = "Error: " + ee.Message;
            }
                               
                            
        }

        private void LoadReport(DateTime currendate)
        {
            try
            {
           
                DataTable dt = DailySalesHandler.SPGET_AllIslandDailySales(currendate);

                RDProd p = ProductHandler.SPGET_Products_Bymonth(currendate);


                Microsoft.Reporting.WebForms.ReportDataSource source1 = new Microsoft.Reporting.WebForms.ReportDataSource();
                source1.Name = "RDSales";
                source1.Value = dt;

             
                #region Report Parameters
                ReportParameter p1 = new ReportParameter("Date", currendate.ToShortDateString());
                ReportParameter Balm3P = new ReportParameter("Balm3P", p.Balm3P.ToString());
                ReportParameter Balm7P = new ReportParameter("Balm7P", p.Balm7P.ToString());
                ReportParameter Balm25P = new ReportParameter("Balm25P", p.Balm25P.ToString());
                ReportParameter Balm50P = new ReportParameter("Balm50P", p.Balm50P.ToString());
                ReportParameter PaspanguwaP = new ReportParameter("PaspanguwaP", p.PaspanguwaP.ToString());
                ReportParameter HCCP = new ReportParameter("HCCP", p.HCCP.ToString());
                ReportParameter KeshaNP = new ReportParameter("KeshaNP", p.KeshaNP.ToString());
                ReportParameter KeshaJP = new ReportParameter("KeshaJP", p.KeshaJP.ToString());
                ReportParameter MGP = new ReportParameter("MGP", p.MGP.ToString());
                ReportParameter SamahanP = new ReportParameter("SamahanP", p.SamahanP.ToString());
                ReportParameter Su45P = new ReportParameter("Su45P", p.Su45P.ToString());
                ReportParameter Su80P = new ReportParameter("Su80P", p.Su80P.ToString());
                ReportParameter SW30P = new ReportParameter("SW30P", p.SW30P.ToString());
                ReportParameter SW60P = new ReportParameter("SW60P", p.SW60P.ToString());
                ReportParameter SW120P = new ReportParameter("SW120P", p.SW120P.ToString());
                ReportParameter AkalapalithaP = new ReportParameter("AkalapalithaP", p.AkalapalithaP.ToString());
                

                ReportViewer1.LocalReport.SetParameters(p1);
                ReportViewer1.LocalReport.SetParameters(Balm3P);
                ReportViewer1.LocalReport.SetParameters(Balm7P);
                ReportViewer1.LocalReport.SetParameters(Balm25P);
                ReportViewer1.LocalReport.SetParameters(Balm50P);
                ReportViewer1.LocalReport.SetParameters(PaspanguwaP);
                ReportViewer1.LocalReport.SetParameters(HCCP);
                ReportViewer1.LocalReport.SetParameters(KeshaNP);
                ReportViewer1.LocalReport.SetParameters(KeshaJP);
                ReportViewer1.LocalReport.SetParameters(MGP);
                ReportViewer1.LocalReport.SetParameters(SamahanP);
                ReportViewer1.LocalReport.SetParameters(Su45P);
                ReportViewer1.LocalReport.SetParameters(Su80P);
                ReportViewer1.LocalReport.SetParameters(SW30P);
                ReportViewer1.LocalReport.SetParameters(SW60P);
                ReportViewer1.LocalReport.SetParameters(SW120P);
                ReportViewer1.LocalReport.SetParameters(AkalapalithaP);
                #endregion


                //ReportViewer1.LocalReport.ReportEmbeddedResource = null;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(source1);
         

            }
            catch (Exception ee)
            {

                lbl_status.ForeColor = System.Drawing.Color.Red;
                lbl_status.Text = "Error: " + ee.Message;
            }


        }

        protected void txt_date_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadReport(DateTime.Parse(txt_date.Text));
            }
            catch (Exception ee)
            {

                lbl_status.ForeColor = System.Drawing.Color.Red;
                lbl_status.Text = "Error: " + ee.Message;
            }
            
        }
    }
}