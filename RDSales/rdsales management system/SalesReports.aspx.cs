using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDSales_Entity_Handler;
using RDSales_Entities;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace RDSales_Management_System
{
    public partial class SalesReports : System.Web.UI.Page
    {
        private  RDSales_Entities.UserEntity UserObj;
        private  Region CurrentRegion;
        private  UserEntity CurrentAsm;
         int UserId = 0;
         int AsM_UserID = 0;
         int RegId = 0;
        private  DateTime date;


        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                UserObj = (RDSales_Entities.UserEntity)Session["LoggedUser"];
                txt_asm.ReadOnly = true;


                #region Handle User Session

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
                    List<Region> RegList = RegionHandler.SPGET_Regions();
                    foreach (Region r in RegList)
                    {
                        cmb_Region.Items.Add(r.RegionName + ":" + r.RegionID);
                    }

                   string severdate = DBCon.GetServerDate();
                    txt_date.Text = severdate;
                    date = DateTime.Parse(txt_date.Text);
                    LoadReports(date);
                   
                }
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": Page Load";
            }

           
        }

        private void LoadCumReport(DateTime currentdate)
        {
            ResetReportViewer();
            LoadCoreData();
            
            DataTable dt = DailySalesHandler.SPGET_RegionalDailySales(currentdate, RegId);
            Microsoft.Reporting.WebForms.ReportDataSource source1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            source1.Name = "RDSales";
            source1.Value = dt;

            RDProd p = ProductHandler.SPGET_Products_Bymonth(currentdate);

          

            ReportViewer1.LocalReport.ReportPath = "Reports/RegionalDailySales.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();

            #region Report Parameters
            ReportParameter p1 = new ReportParameter("Date", currentdate.ToShortDateString());
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
            ReportParameter region = new ReportParameter("Region", CurrentRegion.RegionName);

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
            ReportViewer1.LocalReport.SetParameters(region);
            

            #endregion

            
            ReportViewer1.LocalReport.DataSources.Add(source1);
        }

        private void LoadDailyReport(DateTime currentdate)
        {
            ResetReportViewer();
            LoadCoreData();

            DataTable dt = DailySalesHandler.SPGET_RegionalDailySales_PerDay(currentdate,RegId);
            Microsoft.Reporting.WebForms.ReportDataSource source1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            source1.Name = "RDSales";
            source1.Value = dt;

            RDProd p = ProductHandler.SPGET_Products_Bymonth(currentdate);

            ReportViewer1.LocalReport.ReportPath = "Reports/RegionalDailySales_PerDay.rdlc";
            ReportViewer1.LocalReport.DataSources.Clear();
          

            #region Report Parameters
            ReportParameter p1 = new ReportParameter("Date", currentdate.ToShortDateString());
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
            ReportParameter region = new ReportParameter("Region", CurrentRegion.RegionName);

          

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
            ReportViewer1.LocalReport.SetParameters(region);

            #endregion


            ReportViewer1.LocalReport.DataSources.Add(source1);
        }

        private void ResetReportViewer()
        {
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.Dispose();
            ReportViewer1.LocalReport.DataSources.Clear();


        }

        private void LoadCoreData()
        {
            try
            {
                RegId = RegionHandler.GetRegID(cmb_Region.SelectedValue.ToString());
                CurrentRegion = RegionHandler.SPGET_RegionByID(RegId);
                AsM_UserID = CurrentRegion.ASM;
                CurrentAsm = UserEntityHandler.SPGET_UserByID(AsM_UserID);
                txt_asm.Text = CurrentAsm.Name;
            }
            catch (Exception ee)
            {
                
                lbl_status.Text = ee.Message + ": Load Core Data";
            }
        }

        private void LoadReports(DateTime currentdate)
        {
            try
            {
                if (Radio_Cum.Checked)
                {
                    LoadCumReport(currentdate);
                }
                else
                {
                    LoadDailyReport(currentdate);
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        protected void cmb_Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                date = DateTime.Parse(txt_date.Text);
                LoadReports(date);
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": date changed";
            }

        
        }

        protected void txt_date_TextChanged(object sender, EventArgs e)
        {
            try
            {
                date = DateTime.Parse(txt_date.Text);
                LoadReports(date);
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": date changed";
            }
           
        }

        protected void Radio_daily_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadReports(DateTime.Parse(txt_date.Text));
            }
            catch (Exception ee )
            {
                
                lbl_status.Text = ee.Message;
            }
           
        }

        protected void Radio_Cum_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadReports(DateTime.Parse(txt_date.Text));
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message;
            }

            
        }
    }
}