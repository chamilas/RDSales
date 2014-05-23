using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDSales_Entity_Handler;
using RDSales_Entities;

namespace RDSales_Management_System
{
    public partial class EditRDTargerts : System.Web.UI.Page
    {

        private List<Territory> ListTerr = new List<Territory>();
        private RDSales_Entities.UserEntity UserObj;
        private string date = "";
        private Region objReg = new Region();
        int UserId = 0;

        List<RDTarget> T1;
        List<RDTarget> T2;
        List<RDTarget> T3;
        List<RDTarget> T4;
        List<RDTarget> T5;
        List<RDTarget> T6;
        List<RDTarget> T7;
        List<RDTarget> T8;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                 UserObj = (RDSales_Entities.UserEntity)Session["LoggedUser"];
             

                txt_asm.ReadOnly = true;
                //txt_date.ReadOnly = true;
                txt_region.ReadOnly = true;

                #region Handle User Session
                if (UserObj != null)
                {
                    UserId = UserObj.ID;
                    bool hasPermission = UserEntityHandler.SPCHECK_UserHaspermission(UserId, "SALES_EDIT");
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
                    date = DBCon.GetServerDate();
                    txt_date.Text = date;

                    HandleConfirmbutton();
                    LoadData();

                }


              
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + "Page Load";
            }
        }

        private void LoadCoreData()
        {
            try
            {
                  #region Load Core Data

                //Get Region By LoggedUser
               
                objReg = RegionHandler.SPGET_RegionByUser(UserId);

                //Get Territories by  Region
                ListTerr = TerritoryHandler.SPGET_TerritoryByRegion(objReg.RegionID);

                txt_region.Text = objReg.RegionName;
                txt_asm.Text = UserObj.Name;
                date = txt_date.Text;

                #endregion

                #region Loading Names and handle state of text box based on number of Territories

                String[] Terrname = new string[8];
                for (int i = 0; i < ListTerr.Count; i++)
                {
                    Terrname[i] = ListTerr[i].TerritoryName + ":" + ListTerr[i].TerritoryID;
                }

                //Adding Labels Names

                lbl_Terr1.Text = Terrname[0];
                lbl_Terr2.Text = Terrname[1];
                lbl_Terr3.Text = Terrname[2];
                lbl_Terr4.Text = Terrname[3];
                lbl_Terr5.Text = Terrname[4];
                lbl_Terr6.Text = Terrname[5];
                lbl_Terr7.Text = Terrname[6];
                lbl_Terr8.Text = Terrname[7];

                //Control Visibility
                ControlTextboxState();


                #endregion
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + "Load Core Data";
            }
        }
        
        private void ControlTextboxState()
        {
            try
            {
                List<bool> hasTerr = new List<bool>();
                for (int i = 0; i < 8; i++)
                {
                    hasTerr.Add(false);
                }

                for (int i = 0; i < ListTerr.Count; i++)
                {
                    hasTerr[i] = true;
                }

                HandleTerr1(hasTerr[0], false);
                HandleTerr2(hasTerr[1], false);
                HandleTerr3(hasTerr[2], false);
                HandleTerr4(hasTerr[3], false);
                HandleTerr5(hasTerr[4], false);
                HandleTerr6(hasTerr[5], false);
                HandleTerr7(hasTerr[6], false);
                HandleTerr8(hasTerr[7], false);
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": ControlTextboxState";
            }



        }

        private void HandleConfirmbutton()
        {
            try
            {
                bool dataexist = TargetsHandler.SPCHECK_TargetsExists(date, objReg.RegionID);
                bool confirmed = TargetsHandler.SPCHECK_DataConfirmed(date, UserId);

                if (dataexist && confirmed)
                {
                    bttn_confirm.Visible = false;
                    bttn_edit.Visible = false;
                }
                else if (dataexist && !confirmed)
                {
                    bttn_confirm.Enabled = true;
                    bttn_confirm.Visible = true;
                    bttn_edit.Visible = true;
                }
                else if (!dataexist)
                {
                    bttn_confirm.Visible = false;
                    bttn_edit.Visible = false;
                }

            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": HandleConfirm";
            }


        }

        #region Control state of Territory Textbox
        private void HandleTerr1(bool visible, bool read)
        {
            txt_samahan_1.Visible = visible;
            txt_keshaN_1.Visible = visible;
            txt_keshaJ_1.Visible = visible;
            txt_HCC_1.Visible = visible;
            txt_MG_1.Visible = visible;
            txt_Paspangu_1.Visible = visible;
            txt_Sud45_1.Visible = visible;
            txt_Sud80_1.Visible = visible;
            txt_balm3_1.Visible = visible;
            txt_balm7_1.Visible = visible;
            txt_balm25_1.Visible = visible;
            txt_balm50_1.Visible = visible;
            txt_sws30_1.Visible = visible;
            txt_sws60_1.Visible = visible;
            txt_sws120_1.Visible = visible;

           

            txt_samahan_1.ReadOnly = read;
            txt_keshaN_1.ReadOnly = read;
            txt_keshaJ_1.ReadOnly = read;
            txt_HCC_1.ReadOnly = read;
            txt_MG_1.ReadOnly = read;
            txt_Paspangu_1.ReadOnly = read;
            txt_Sud45_1.ReadOnly = read;
            txt_Sud80_1.ReadOnly = read;
            txt_balm3_1.ReadOnly = read;
            txt_balm7_1.ReadOnly = read;
            txt_balm25_1.ReadOnly = read;
            txt_balm50_1.ReadOnly = read;
            txt_sws30_1.ReadOnly = read;
            txt_sws60_1.ReadOnly = read;
            txt_sws120_1.ReadOnly = read;

         
            txt_totalT1.Visible = visible;

          

        }

        private void HandleTerr2(bool val, bool read)
        {
            txt_samahan_2.Visible = val;
            txt_keshaN_2.Visible = val;
            txt_keshaJ_2.Visible = val;
            txt_HCC_2.Visible = val;
            txt_MG_2.Visible = val;
            txt_Paspangu_2.Visible = val;
            txt_Sud45_2.Visible = val;
            txt_Sud80_2.Visible = val;
            txt_balm3_2.Visible = val;
            txt_balm7_2.Visible = val;
            txt_balm25_2.Visible = val;
            txt_balm50_2.Visible = val;
            txt_sws30_2.Visible = val;
            txt_sws60_2.Visible = val;
            txt_sws120_2.Visible = val;



            txt_samahan_2.ReadOnly = read;
            txt_keshaN_2.ReadOnly = read;
            txt_keshaJ_2.ReadOnly = read;
            txt_HCC_2.ReadOnly = read;
            txt_MG_2.ReadOnly = read;
            txt_Paspangu_2.ReadOnly = read;
            txt_Sud45_2.ReadOnly = read;
            txt_Sud80_2.ReadOnly = read;
            txt_balm3_2.ReadOnly = read;
            txt_balm7_2.ReadOnly = read;
            txt_balm25_2.ReadOnly = read;
            txt_balm50_2.ReadOnly = read;
            txt_sws30_2.ReadOnly = read;
            txt_sws60_2.ReadOnly = read;
            txt_sws120_2.ReadOnly = read;

           

            txt_totalT2.Visible = val;
       



        }

        private void HandleTerr3(bool val, bool read)
        {
            txt_samahan_3.Visible = val;
            txt_keshaN_3.Visible = val;
            txt_keshaJ_3.Visible = val;
            txt_HCC_3.Visible = val;
            txt_MG_3.Visible = val;
            txt_Paspangu_3.Visible = val;
            txt_Sud45_3.Visible = val;
            txt_Sud80_3.Visible = val;
            txt_balm3_3.Visible = val;
            txt_balm7_3.Visible = val;
            txt_balm25_3.Visible = val;
            txt_balm50_3.Visible = val;
            txt_sws30_3.Visible = val;
            txt_sws60_3.Visible = val;
            txt_sws120_3.Visible = val;

     

            txt_samahan_3.ReadOnly = read;
            txt_keshaN_3.ReadOnly = read;
            txt_keshaJ_3.ReadOnly = read;
            txt_HCC_3.ReadOnly = read;
            txt_MG_3.ReadOnly = read;
            txt_Paspangu_3.ReadOnly = read;
            txt_Sud45_3.ReadOnly = read;
            txt_Sud80_3.ReadOnly = read;
            txt_balm3_3.ReadOnly = read;
            txt_balm7_3.ReadOnly = read;
            txt_balm25_3.ReadOnly = read;
            txt_balm50_3.ReadOnly = read;
            txt_sws30_3.ReadOnly = read;
            txt_sws60_3.ReadOnly = read;
            txt_sws120_3.ReadOnly = read;


     

            txt_totalT3.Visible = val;
        
        }

        private void HandleTerr4(bool val, bool read)
        {
            txt_samahan_4.Visible = val;
            txt_keshaN_4.Visible = val;
            txt_keshaJ_4.Visible = val;
            txt_HCC_4.Visible = val;
            txt_MG_4.Visible = val;
            txt_Paspangu_4.Visible = val;
            txt_Sud45_4.Visible = val;
            txt_Sud80_4.Visible = val;
            txt_balm3_4.Visible = val;
            txt_balm7_4.Visible = val;
            txt_balm25_4.Visible = val;
            txt_balm50_4.Visible = val;
            txt_sws30_4.Visible = val;
            txt_sws60_4.Visible = val;
            txt_sws120_4.Visible = val;


            


            txt_samahan_4.ReadOnly = read;
            txt_keshaN_4.ReadOnly = read;
            txt_keshaJ_4.ReadOnly = read;
            txt_HCC_4.ReadOnly = read;
            txt_MG_4.ReadOnly = read;
            txt_Paspangu_4.ReadOnly = read;
            txt_Sud45_4.ReadOnly = read;
            txt_Sud80_4.ReadOnly = read;
            txt_balm3_4.ReadOnly = read;
            txt_balm7_4.ReadOnly = read;
            txt_balm25_4.ReadOnly = read;
            txt_balm50_4.ReadOnly = read;
            txt_sws30_4.ReadOnly = read;
            txt_sws60_4.ReadOnly = read;
            txt_sws120_4.ReadOnly = read;


           
            txt_totalT4.Visible = val;
          
        }

        private void HandleTerr5(bool val, bool read)
        {
            txt_samahan_5.Visible = val;
            txt_keshaN_5.Visible = val;
            txt_keshaJ_5.Visible = val;
            txt_HCC_5.Visible = val;
            txt_MG_5.Visible = val;
            txt_Paspangu_5.Visible = val;
            txt_Sud45_5.Visible = val;
            txt_Sud80_5.Visible = val;
            txt_balm3_5.Visible = val;
            txt_balm7_5.Visible = val;
            txt_balm25_5.Visible = val;
            txt_balm50_5.Visible = val;
            txt_sws30_5.Visible = val;
            txt_sws60_5.Visible = val;
            txt_sws120_5.Visible = val;

           

            txt_samahan_5.ReadOnly = read;
            txt_keshaN_5.ReadOnly = read;
            txt_keshaJ_5.ReadOnly = read;
            txt_HCC_5.ReadOnly = read;
            txt_MG_5.ReadOnly = read;
            txt_Paspangu_5.ReadOnly = read;
            txt_Sud45_5.ReadOnly = read;
            txt_Sud80_5.ReadOnly = read;
            txt_balm3_5.ReadOnly = read;
            txt_balm7_5.ReadOnly = read;
            txt_balm25_5.ReadOnly = read;
            txt_balm50_5.ReadOnly = read;
            txt_sws30_5.ReadOnly = read;
            txt_sws60_5.ReadOnly = read;
            txt_sws120_5.ReadOnly = read;

          

            txt_totalT5.Visible = val;
         
        }

        private void HandleTerr6(bool val, bool read)
        {
            txt_samahan_6.Visible = val;
            txt_keshaN_6.Visible = val;
            txt_keshaJ_6.Visible = val;
            txt_HCC_6.Visible = val;
            txt_MG_6.Visible = val;
            txt_Paspangu_6.Visible = val;
            txt_Sud45_6.Visible = val;
            txt_Sud80_6.Visible = val;
            txt_balm3_6.Visible = val;
            txt_balm7_6.Visible = val;
            txt_balm25_6.Visible = val;
            txt_balm50_6.Visible = val;
            txt_sws30_6.Visible = val;
            txt_sws60_6.Visible = val;
            txt_sws120_6.Visible = val;

       

            txt_samahan_6.ReadOnly = read;
            txt_keshaN_6.ReadOnly = read;
            txt_keshaJ_6.ReadOnly = read;
            txt_HCC_6.ReadOnly = read;
            txt_MG_6.ReadOnly = read;
            txt_Paspangu_6.ReadOnly = read;
            txt_Sud45_6.ReadOnly = read;
            txt_Sud80_6.ReadOnly = read;
            txt_balm3_6.ReadOnly = read;
            txt_balm7_6.ReadOnly = read;
            txt_balm25_6.ReadOnly = read;
            txt_balm50_6.ReadOnly = read;
            txt_sws30_6.ReadOnly = read;
            txt_sws60_6.ReadOnly = read;
            txt_sws120_6.ReadOnly = read;

           

            txt_totalT6.Visible = val;
       


          
        }

        private void HandleTerr7(bool val, bool read)
        {
            txt_samahan_7.Visible = val;
            txt_keshaN_7.Visible = val;
            txt_keshaJ_7.Visible = val;
            txt_HCC_7.Visible = val;
            txt_MG_7.Visible = val;
            txt_Paspangu_7.Visible = val;
            txt_Sud45_7.Visible = val;
            txt_Sud80_7.Visible = val;
            txt_balm3_7.Visible = val;
            txt_balm7_7.Visible = val;
            txt_balm25_7.Visible = val;
            txt_balm50_7.Visible = val;
            txt_sws30_7.Visible = val;
            txt_sws60_7.Visible = val;
            txt_sws120_7.Visible = val;

         

            txt_samahan_7.ReadOnly = read;
            txt_keshaN_7.ReadOnly = read;
            txt_keshaJ_7.ReadOnly = read;
            txt_HCC_7.ReadOnly = read;
            txt_MG_7.ReadOnly = read;
            txt_Paspangu_7.ReadOnly = read;
            txt_Sud45_7.ReadOnly = read;
            txt_Sud80_7.ReadOnly = read;
            txt_balm3_7.ReadOnly = read;
            txt_balm7_7.ReadOnly = read;
            txt_balm25_7.ReadOnly = read;
            txt_balm50_7.ReadOnly = read;
            txt_sws30_7.ReadOnly = read;
            txt_sws60_7.ReadOnly = read;
            txt_sws120_7.ReadOnly = read;

        

            txt_totalT7.Visible = val;
            
        }

        private void HandleTerr8(bool val, bool read)
        {
            txt_samahan_8.Visible = val;
            txt_keshaN_8.Visible = val;
            txt_keshaJ_8.Visible = val;
            txt_HCC_8.Visible = val;
            txt_MG_8.Visible = val;
            txt_Paspangu_8.Visible = val;
            txt_Sud45_8.Visible = val;
            txt_Sud80_8.Visible = val;
            txt_balm3_8.Visible = val;
            txt_balm7_8.Visible = val;
            txt_balm25_8.Visible = val;
            txt_balm50_8.Visible = val;
            txt_sws30_8.Visible = val;
            txt_sws60_8.Visible = val;
            txt_sws120_8.Visible = val;

           


            txt_samahan_8.ReadOnly = read;
            txt_keshaN_8.ReadOnly = read;
            txt_keshaJ_8.ReadOnly = read;
            txt_HCC_8.ReadOnly = read;
            txt_MG_8.ReadOnly = read;
            txt_Paspangu_8.ReadOnly = read;
            txt_Sud45_8.ReadOnly = read;
            txt_Sud80_8.ReadOnly = read;
            txt_balm3_8.ReadOnly = read;
            txt_balm7_8.ReadOnly = read;
            txt_balm25_8.ReadOnly = read;
            txt_balm50_8.ReadOnly = read;
            txt_sws30_8.ReadOnly = read;
            txt_sws60_8.ReadOnly = read;
            txt_sws120_8.ReadOnly = read;

         

            txt_totalT8.Visible = val;
        
        }

        #endregion

        private void LoadData()
        {


            LoadCoreData();

            bool confirmed = TargetsHandler.SPCHECK_DataConfirmed(date, UserObj.ID);
            bool dataexist = TargetsHandler.SPCHECK_TargetsExists(date, objReg.RegionID);
           

            try
            {
                if (DBCon.CheckSQLServer())
                {

                    #region Load Existing data

                    if (dataexist)
                    {
                        lbl_status.Text = "";
                        RDProd product = ProductHandler.SPGET_Products_Bymonth(DateTime.Parse(date));

                        //Terr1
                        if (ListTerr.Count > 0)
                        {
                            if (ListTerr[0].TerritoryID == GetTerrID(lbl_Terr1.Text))
                            {
                                T1 = TargetsHandler.SPGET_TargetsPer_Territory(date, ListTerr[0].TerritoryID);
                               

                                if (T1.Count > 0)
                                {
                                    txt_samahan_1.Text = T1[9].Target.ToString();
                                    txt_keshaN_1.Text = T1[6].Target.ToString();
                                    txt_keshaJ_1.Text = T1[7].Target.ToString();
                                    txt_HCC_1.Text = T1[5].Target.ToString();
                                    txt_MG_1.Text = T1[8].Target.ToString();
                                    txt_Paspangu_1.Text = T1[4].Target.ToString();
                                    txt_Sud45_1.Text = T1[10].Target.ToString();
                                    txt_Sud80_1.Text = T1[11].Target.ToString();
                                    txt_balm3_1.Text = T1[0].Target.ToString();
                                    txt_balm7_1.Text = T1[1].Target.ToString();
                                    txt_balm25_1.Text = T1[2].Target.ToString();
                                    txt_balm50_1.Text = T1[3].Target.ToString();
                                    txt_sws30_1.Text = T1[12].Target.ToString();
                                    txt_sws60_1.Text = T1[13].Target.ToString();
                                    txt_sws120_1.Text = T1[14].Target.ToString();


                                    txt_totalT1.Text = Math.Round(((T1[9].Target * product.SamahanP) + (T1[6].Target * product.KeshaNP) + (T1[7].Target * product.KeshaJP) + (T1[5].Target * product.HCCP) + (T1[8].Target * product.MGP) + (T1[4].Target * product.PaspanguwaP) + (T1[10].Target * product.Su45P) + (T1[11].Target * product.Su80P) + (T1[0].Target * product.Balm3P) + (T1[1].Target * product.Balm7P) + (T1[2].Target * product.Balm25P) + (T1[3].Target * product.Balm50P) + (T1[12].Target * product.SW30P) + (T1[13].Target * product.SW60P) + (T1[14].Target * product.SW120P)), 2).ToString();
                                }
                              


                            }
                        }

                        //Terr2
                        if (ListTerr.Count > 1)
                        {
                            if (ListTerr[1].TerritoryID == GetTerrID(lbl_Terr2.Text))
                            {
                                T2 = TargetsHandler.SPGET_TargetsPer_Territory(date, ListTerr[1].TerritoryID);
                                


                                if (T2.Count > 0)
                                {
                                    txt_samahan_2.Text = T2[9].Target.ToString();
                                    txt_keshaN_2.Text = T2[6].Target.ToString();
                                    txt_keshaJ_2.Text = T2[7].Target.ToString();
                                    txt_HCC_2.Text = T2[5].Target.ToString();
                                    txt_MG_2.Text = T2[8].Target.ToString();
                                    txt_Paspangu_2.Text = T2[4].Target.ToString();
                                    txt_Sud45_2.Text = T2[10].Target.ToString();
                                    txt_Sud80_2.Text = T2[11].Target.ToString();
                                    txt_balm3_2.Text = T2[0].Target.ToString();
                                    txt_balm7_2.Text = T2[1].Target.ToString();
                                    txt_balm25_2.Text = T2[2].Target.ToString();
                                    txt_balm50_2.Text = T2[3].Target.ToString();
                                    txt_sws30_2.Text = T2[12].Target.ToString();
                                    txt_sws60_2.Text = T2[13].Target.ToString();
                                    txt_sws120_2.Text = T2[14].Target.ToString();

                                
                                    txt_totalT2.Text = Math.Round(((T2[9].Target * product.SamahanP) + (T2[6].Target * product.KeshaNP) + (T2[7].Target * product.KeshaJP) + (T2[5].Target * product.HCCP) + (T2[8].Target * product.MGP) + (T2[4].Target * product.PaspanguwaP) + (T2[10].Target * product.Su45P) + (T2[11].Target * product.Su80P) + (T2[0].Target * product.Balm3P) + (T2[1].Target * product.Balm7P) + (T2[2].Target * product.Balm25P) + (T2[3].Target * product.Balm50P) + (T2[12].Target * product.SW30P) + (T2[13].Target * product.SW60P) + (T2[14].Target * product.SW120P)), 2).ToString();
                                }

                               
                            }
                        }

                        //Terr3
                        if (ListTerr.Count > 2)
                        {
                            if (ListTerr[2].TerritoryID == GetTerrID(lbl_Terr3.Text))
                            {
                                T3 = TargetsHandler.SPGET_TargetsPer_Territory(date, ListTerr[2].TerritoryID);
                     

                                if (T3.Count > 0)
                                {
                                    txt_samahan_3.Text = T3[9].Target.ToString();
                                    txt_keshaN_3.Text = T3[6].Target.ToString();
                                    txt_keshaJ_3.Text = T3[7].Target.ToString();
                                    txt_HCC_3.Text = T3[5].Target.ToString();
                                    txt_MG_3.Text = T3[8].Target.ToString();
                                    txt_Paspangu_3.Text = T3[4].Target.ToString();
                                    txt_Sud45_3.Text = T3[10].Target.ToString();
                                    txt_Sud80_3.Text = T3[11].Target.ToString();
                                    txt_balm3_3.Text = T3[0].Target.ToString();
                                    txt_balm7_3.Text = T3[1].Target.ToString();
                                    txt_balm25_3.Text = T3[2].Target.ToString();
                                    txt_balm50_3.Text = T3[3].Target.ToString();
                                    txt_sws30_3.Text = T3[12].Target.ToString();
                                    txt_sws60_3.Text = T3[13].Target.ToString();
                                    txt_sws120_3.Text = T3[14].Target.ToString();
                                    

                                    txt_totalT3.Text = Math.Round(((T3[9].Target * product.SamahanP) + (T3[6].Target * product.KeshaNP) + (T3[7].Target * product.KeshaJP) + (T3[5].Target * product.HCCP) + (T3[8].Target * product.MGP) + (T3[4].Target * product.PaspanguwaP) + (T3[10].Target * product.Su45P) + (T3[11].Target * product.Su80P) + (T3[0].Target * product.Balm3P) + (T3[1].Target * product.Balm7P) + (T3[2].Target * product.Balm25P) + (T3[3].Target * product.Balm50P) + (T3[12].Target * product.SW30P) + (T3[13].Target * product.SW60P) + (T3[14].Target * product.SW120P)), 2).ToString();
                                }

                               
                            }
                        }

                        //Terr4
                        if (ListTerr.Count > 3)
                        {
                            if (ListTerr[3].TerritoryID == GetTerrID(lbl_Terr4.Text))
                            {
                                T4 = TargetsHandler.SPGET_TargetsPer_Territory(date, ListTerr[3].TerritoryID);
                              

                                if (T4.Count > 0)
                                {
                                    txt_samahan_4.Text = T4[9].Target.ToString();
                                    txt_keshaN_4.Text = T4[6].Target.ToString();
                                    txt_keshaJ_4.Text = T4[7].Target.ToString();
                                    txt_HCC_4.Text = T4[5].Target.ToString();
                                    txt_MG_4.Text = T4[8].Target.ToString();
                                    txt_Paspangu_4.Text = T4[4].Target.ToString();
                                    txt_Sud45_4.Text = T4[10].Target.ToString();
                                    txt_Sud80_4.Text = T4[11].Target.ToString();
                                    txt_balm3_4.Text = T4[0].Target.ToString();
                                    txt_balm7_4.Text = T4[1].Target.ToString();
                                    txt_balm25_4.Text = T4[2].Target.ToString();
                                    txt_balm50_4.Text = T4[3].Target.ToString();
                                    txt_sws30_4.Text = T4[12].Target.ToString();
                                    txt_sws60_4.Text = T4[13].Target.ToString();
                                    txt_sws120_4.Text = T4[14].Target.ToString();
                                   

                                    txt_totalT4.Text = Math.Round(((T4[9].Target * product.SamahanP) + (T4[6].Target * product.KeshaNP) + (T4[7].Target * product.KeshaJP) + (T4[5].Target * product.HCCP) + (T4[8].Target * product.MGP) + (T4[4].Target * product.PaspanguwaP) + (T4[10].Target * product.Su45P) + (T4[11].Target * product.Su80P) + (T4[0].Target * product.Balm3P) + (T4[1].Target * product.Balm7P) + (T4[2].Target * product.Balm25P) + (T4[3].Target * product.Balm50P) + (T4[12].Target * product.SW30P) + (T4[13].Target * product.SW60P) + (T4[14].Target * product.SW120P)), 2).ToString();
                                }

                               
                            }
                        }


                        //Terr5
                        if (ListTerr.Count > 4)
                        {
                            if (ListTerr[4].TerritoryID == GetTerrID(lbl_Terr5.Text))
                            {
                                T5 = TargetsHandler.SPGET_TargetsPer_Territory(date, ListTerr[4].TerritoryID);
                                

                                if (T5.Count > 0)
                                {
                                    txt_samahan_5.Text = T5[9].Target.ToString();
                                    txt_keshaN_5.Text = T5[6].Target.ToString();
                                    txt_keshaJ_5.Text = T5[7].Target.ToString();
                                    txt_HCC_5.Text = T5[5].Target.ToString();
                                    txt_MG_5.Text = T5[8].Target.ToString();
                                    txt_Paspangu_5.Text = T5[4].Target.ToString();
                                    txt_Sud45_5.Text = T5[10].Target.ToString();
                                    txt_Sud80_5.Text = T5[11].Target.ToString();
                                    txt_balm3_5.Text = T5[0].Target.ToString();
                                    txt_balm7_5.Text = T5[1].Target.ToString();
                                    txt_balm25_5.Text = T5[2].Target.ToString();
                                    txt_balm50_5.Text = T5[3].Target.ToString();
                                    txt_sws30_5.Text = T5[12].Target.ToString();
                                    txt_sws60_5.Text = T5[13].Target.ToString();
                                    txt_sws120_5.Text = T5[14].Target.ToString();
                                   

                                    txt_totalT5.Text = Math.Round(((T5[9].Target * product.SamahanP) + (T5[6].Target * product.KeshaNP) + (T5[7].Target * product.KeshaJP) + (T5[5].Target * product.HCCP) + (T5[8].Target * product.MGP) + (T5[4].Target * product.PaspanguwaP) + (T5[10].Target * product.Su45P) + (T5[11].Target * product.Su80P) + (T5[0].Target * product.Balm3P) + (T5[1].Target * product.Balm7P) + (T5[2].Target * product.Balm25P) + (T5[3].Target * product.Balm50P) + (T5[12].Target * product.SW30P) + (T5[13].Target * product.SW60P) + (T5[14].Target * product.SW120P)), 2).ToString();
                                }

                               
                            }
                        }

                        //Terr6
                        if (ListTerr.Count > 5)
                        {
                            if (ListTerr[5].TerritoryID == GetTerrID(lbl_Terr6.Text))
                            {
                                T6 = TargetsHandler.SPGET_TargetsPer_Territory(date, ListTerr[5].TerritoryID);
                               
                                if (T6.Count > 0)
                                {
                                    txt_samahan_6.Text = T6[9].Target.ToString();
                                    txt_keshaN_6.Text = T6[6].Target.ToString();
                                    txt_keshaJ_6.Text = T6[7].Target.ToString();
                                    txt_HCC_6.Text = T6[5].Target.ToString();
                                    txt_MG_6.Text = T6[8].Target.ToString();
                                    txt_Paspangu_6.Text = T6[4].Target.ToString();
                                    txt_Sud45_6.Text = T6[10].Target.ToString();
                                    txt_Sud80_6.Text = T6[11].Target.ToString();
                                    txt_balm3_6.Text = T6[0].Target.ToString();
                                    txt_balm7_6.Text = T6[1].Target.ToString();
                                    txt_balm25_6.Text = T6[2].Target.ToString();
                                    txt_balm50_6.Text = T6[3].Target.ToString();
                                    txt_sws30_6.Text = T6[12].Target.ToString();
                                    txt_sws60_6.Text = T6[13].Target.ToString();
                                    txt_sws120_6.Text = T6[14].Target.ToString();
                                   

                                    txt_totalT6.Text = Math.Round(((T6[9].Target * product.SamahanP) + (T6[6].Target * product.KeshaNP) + (T6[7].Target * product.KeshaJP) + (T6[5].Target * product.HCCP) + (T6[8].Target * product.MGP) + (T6[4].Target * product.PaspanguwaP) + (T6[10].Target * product.Su45P) + (T6[11].Target * product.Su80P) + (T6[0].Target * product.Balm3P) + (T6[1].Target * product.Balm7P) + (T6[2].Target * product.Balm25P) + (T6[3].Target * product.Balm50P) + (T6[12].Target * product.SW30P) + (T6[13].Target * product.SW60P) + (T6[14].Target * product.SW120P)), 2).ToString();
                                }

                                
                            }
                        }

                        //Terr7
                        if (ListTerr.Count > 6)
                        {
                            if (ListTerr[6].TerritoryID == GetTerrID(lbl_Terr7.Text))
                            {
                                T7 = TargetsHandler.SPGET_TargetsPer_Territory(date, ListTerr[6].TerritoryID);
                               

                                if (T7.Count > 0)
                                {
                                    txt_samahan_7.Text = T7[9].Target.ToString();
                                    txt_keshaN_7.Text = T7[6].Target.ToString();
                                    txt_keshaJ_7.Text = T7[7].Target.ToString();
                                    txt_HCC_7.Text = T7[5].Target.ToString();
                                    txt_MG_7.Text = T7[8].Target.ToString();
                                    txt_Paspangu_7.Text = T7[4].Target.ToString();
                                    txt_Sud45_7.Text = T7[10].Target.ToString();
                                    txt_Sud80_7.Text = T7[11].Target.ToString();
                                    txt_balm3_7.Text = T7[0].Target.ToString();
                                    txt_balm7_7.Text = T7[1].Target.ToString();
                                    txt_balm25_7.Text = T7[2].Target.ToString();
                                    txt_balm50_7.Text = T7[3].Target.ToString();
                                    txt_sws30_7.Text = T7[12].Target.ToString();
                                    txt_sws60_7.Text = T7[13].Target.ToString();
                                    txt_sws120_7.Text = T7[14].Target.ToString();
                              

                                    txt_totalT7.Text = Math.Round(((T7[9].Target * product.SamahanP) + (T7[6].Target * product.KeshaNP) + (T7[7].Target * product.KeshaJP) + (T7[5].Target * product.HCCP) + (T7[8].Target * product.MGP) + (T7[4].Target * product.PaspanguwaP) + (T7[10].Target * product.Su45P) + (T7[11].Target * product.Su80P) + (T7[0].Target * product.Balm3P) + (T7[1].Target * product.Balm7P) + (T7[2].Target * product.Balm25P) + (T7[3].Target * product.Balm50P) + (T7[12].Target * product.SW30P) + (T7[13].Target * product.SW60P) + (T7[14].Target * product.SW120P)), 2).ToString();
                                }

                             

                            }
                        }

                        //Terr8
                        if (ListTerr.Count > 7)
                        {
                            if (ListTerr[7].TerritoryID == GetTerrID(lbl_Terr8.Text))
                            {
                                T8 = TargetsHandler.SPGET_TargetsPer_Territory(date, ListTerr[7].TerritoryID);
                               

                                if (T8.Count > 0)
                                {
                                    txt_samahan_8.Text = T8[9].Target.ToString();
                                    txt_keshaN_8.Text = T8[6].Target.ToString();
                                    txt_keshaJ_8.Text = T8[7].Target.ToString();
                                    txt_HCC_8.Text = T8[5].Target.ToString();
                                    txt_MG_8.Text = T8[8].Target.ToString();
                                    txt_Paspangu_8.Text = T8[4].Target.ToString();
                                    txt_Sud45_8.Text = T8[10].Target.ToString();
                                    txt_Sud80_8.Text = T8[11].Target.ToString();
                                    txt_balm3_8.Text = T8[0].Target.ToString();
                                    txt_balm7_8.Text = T8[1].Target.ToString();
                                    txt_balm25_8.Text = T8[2].Target.ToString();
                                    txt_balm50_8.Text = T8[3].Target.ToString();
                                    txt_sws30_8.Text = T8[12].Target.ToString();
                                    txt_sws60_8.Text = T8[13].Target.ToString();
                                    txt_sws120_8.Text = T8[14].Target.ToString();
                                   

                                    txt_totalT8.Text = Math.Round(((T8[9].Target * product.SamahanP) + (T8[6].Target * product.KeshaNP) + (T8[7].Target * product.KeshaJP) + (T8[5].Target * product.HCCP) + (T8[8].Target * product.MGP) + (T8[4].Target * product.PaspanguwaP) + (T8[10].Target * product.Su45P) + (T8[11].Target * product.Su80P) + (T8[0].Target * product.Balm3P) + (T8[1].Target * product.Balm7P) + (T8[2].Target * product.Balm25P) + (T8[3].Target * product.Balm50P) + (T8[12].Target * product.SW30P) + (T8[13].Target * product.SW60P) + (T8[14].Target * product.SW120P)), 2).ToString();
                                }


                                

                            }
                        }


                    }
                    else
                    {
                        //Alert.Show("No data Available for: " + date);
                        lbl_status.ForeColor = System.Drawing.Color.Red;
                        lbl_status.Text = "No data Available for: " + date;
                        LoadTextBox();
                    }



                    #endregion

                    #region If no data or Data Confirmed : Lock textBox


                    //Cannot edit : data already confirmed
                    if (dataexist == true & confirmed == true)
                    {
                        HandleTerr1(true, true);
                        HandleTerr2(true, true);
                        HandleTerr3(true, true);
                        HandleTerr4(true, true);
                        HandleTerr5(true, true);
                        HandleTerr6(true, true);
                        HandleTerr7(true, true);
                        HandleTerr8(true, true);

                        ControlTextboxState();

                        bttn_edit.Visible = false;
                        bttn_confirm.Visible = false;

                        lbl_status.ForeColor = System.Drawing.Color.Green;
                        lbl_status.Text = "Data Confirmed!,Can no longer be edited";
                    }
                   
                   
                    //Can edit 
                    else if (dataexist == true & confirmed == false)
                    {

                        ControlTextboxState();



                        lbl_status.ForeColor = System.Drawing.Color.Red; ;
                        lbl_status.Text = "Data not Confirmed!";
                        bttn_edit.Visible = true;
                        bttn_confirm.Visible = true;
                        HandleConfirmbutton();
                    }
                    //Cannort edit: No Data
                    else
                    {
                        HandleTerr1(true, true);
                        HandleTerr2(true, true);
                        HandleTerr3(true, true);
                        HandleTerr4(true, true);
                        HandleTerr5(true, true);
                        HandleTerr6(true, true);
                        HandleTerr7(true, true);
                        HandleTerr8(true, true);

                        ControlTextboxState();

                        bttn_edit.Visible = false;
                        bttn_confirm.Visible = false;
                    }
                    #endregion
                }
                else
                {
                    Alert.Show("Cannot reach the server. Please check your internet connection");
                }

            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": Load Data";
                LoadTextBox();

            }
        }
        
        private void LoadTextBox()
        {

            txt_asm.ReadOnly = true;
            txt_region.ReadOnly = true;

            txt_samahan_1.Text = "0";
            txt_samahan_2.Text = "0";
            txt_samahan_3.Text = "0";
            txt_samahan_4.Text = "0";
            txt_samahan_5.Text = "0";
            txt_samahan_6.Text = "0";
            txt_samahan_7.Text = "0";
            txt_samahan_8.Text = "0";
            txt_keshaN_1.Text = "0";
            txt_keshaN_2.Text = "0";
            txt_keshaN_3.Text = "0";
            txt_keshaN_4.Text = "0";
            txt_keshaN_5.Text = "0";
            txt_keshaN_6.Text = "0";
            txt_keshaN_7.Text = "0";
            txt_keshaN_8.Text = "0";
            txt_keshaJ_1.Text = "0";
            txt_keshaJ_2.Text = "0";
            txt_keshaJ_3.Text = "0";
            txt_keshaJ_4.Text = "0";
            txt_keshaJ_5.Text = "0";
            txt_keshaJ_6.Text = "0";
            txt_keshaJ_7.Text = "0";
            txt_keshaJ_8.Text = "0";
            txt_HCC_1.Text = "0";
            txt_HCC_2.Text = "0";
            txt_HCC_3.Text = "0";
            txt_HCC_4.Text = "0";
            txt_HCC_5.Text = "0";
            txt_HCC_6.Text = "0";
            txt_HCC_7.Text = "0";
            txt_HCC_8.Text = "0";
            txt_MG_1.Text = "0";
            txt_MG_2.Text = "0";
            txt_MG_3.Text = "0";
            txt_MG_4.Text = "0";
            txt_MG_5.Text = "0";
            txt_MG_6.Text = "0";
            txt_MG_7.Text = "0";
            txt_MG_8.Text = "0";
            txt_Paspangu_1.Text = "0";
            txt_Paspangu_2.Text = "0";
            txt_Paspangu_3.Text = "0";
            txt_Paspangu_4.Text = "0";
            txt_Paspangu_5.Text = "0";
            txt_Paspangu_6.Text = "0";
            txt_Paspangu_7.Text = "0";
            txt_Paspangu_8.Text = "0";
            txt_Sud45_1.Text = "0";
            txt_Sud45_2.Text = "0";
            txt_Sud45_3.Text = "0";
            txt_Sud45_4.Text = "0";
            txt_Sud45_5.Text = "0";
            txt_Sud45_6.Text = "0";
            txt_Sud45_7.Text = "0";
            txt_Sud45_8.Text = "0";
            txt_Sud80_1.Text = "0";
            txt_Sud80_2.Text = "0";
            txt_Sud80_3.Text = "0";
            txt_Sud80_4.Text = "0";
            txt_Sud80_5.Text = "0";
            txt_Sud80_6.Text = "0";
            txt_Sud80_7.Text = "0";
            txt_Sud80_8.Text = "0";
            txt_balm3_1.Text = "0";
            txt_balm3_2.Text = "0";
            txt_balm3_3.Text = "0";
            txt_balm3_4.Text = "0";
            txt_balm3_5.Text = "0";
            txt_balm3_6.Text = "0";
            txt_balm3_7.Text = "0";
            txt_balm3_8.Text = "0";
            txt_balm7_1.Text = "0";
            txt_balm7_2.Text = "0";
            txt_balm7_3.Text = "0";
            txt_balm7_4.Text = "0";
            txt_balm7_5.Text = "0";
            txt_balm7_6.Text = "0";
            txt_balm7_7.Text = "0";
            txt_balm7_8.Text = "0";
            txt_balm25_1.Text = "0";
            txt_balm25_2.Text = "0";
            txt_balm25_3.Text = "0";
            txt_balm25_4.Text = "0";
            txt_balm25_5.Text = "0";
            txt_balm25_6.Text = "0";
            txt_balm25_7.Text = "0";
            txt_balm25_8.Text = "0";
            txt_balm50_1.Text = "0";
            txt_balm50_2.Text = "0";
            txt_balm50_3.Text = "0";
            txt_balm50_4.Text = "0";
            txt_balm50_5.Text = "0";
            txt_balm50_6.Text = "0";
            txt_balm50_7.Text = "0";
            txt_balm50_8.Text = "0";
            txt_sws30_1.Text = "0";
            txt_sws30_2.Text = "0";
            txt_sws30_3.Text = "0";
            txt_sws30_4.Text = "0";
            txt_sws30_5.Text = "0";
            txt_sws30_6.Text = "0";
            txt_sws30_7.Text = "0";
            txt_sws30_8.Text = "0";
            txt_sws60_1.Text = "0";
            txt_sws60_2.Text = "0";
            txt_sws60_3.Text = "0";
            txt_sws60_4.Text = "0";
            txt_sws60_5.Text = "0";
            txt_sws60_6.Text = "0";
            txt_sws60_7.Text = "0";
            txt_sws60_8.Text = "0";
            txt_sws120_1.Text = "0";
            txt_sws120_2.Text = "0";
            txt_sws120_3.Text = "0";
            txt_sws120_4.Text = "0";
            txt_sws120_5.Text = "0";
            txt_sws120_6.Text = "0";
            txt_sws120_7.Text = "0";
            txt_sws120_8.Text = "0";

         
            txt_totalT1.Text = "0";
            txt_totalT2.Text = "0";
            txt_totalT3.Text = "0";
            txt_totalT4.Text = "0";
            txt_totalT5.Text = "0";
            txt_totalT6.Text = "0";
            txt_totalT7.Text = "0";
            txt_totalT8.Text = "0";
        }

        public static int GetTerrID(string value)
        {
            int result = -99;
            try
            {
                string[] arry;
                arry = value.Split(':');
                result = Int32.Parse(arry[1].ToString());
            }
            catch (Exception ex)
            { }
            return result;
        }

        protected void txt_date_TextChanged(object sender, EventArgs e)
        {
            date = txt_date.Text;

           string xx= date.Substring(1, date.Length - 1);
            lbl_status.Text = "";

            LoadData();
        }

        protected void bttn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCoreData();


                List<RDTarget> TarList = new List<RDTarget>();
                if (DBCon.CheckSQLServer())
                {
                    Page.Validate();
                    if (Page.IsValid)
                    {
                        #region Ter1

                        if (ListTerr.Count >= 1 & txt_samahan_1.Text.Length > 0)
                        {

                            RDTarget T1_Sm = new RDTarget();
                            T1_Sm.Date = date;
                            T1_Sm.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_Sm.prodcode = ProductCodes.Samahan.ToString();
                            T1_Sm.Target = HandleDecimal(txt_samahan_1.Text);

                            TarList.Add(T1_Sm);

                            RDTarget T1_Kn = new RDTarget();
                            T1_Kn.Date = date;
                            T1_Kn.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_Kn.prodcode = ProductCodes.KeshaNormal.ToString();
                            T1_Kn.Target = HandleDecimal(txt_keshaN_1.Text);

                            TarList.Add(T1_Kn);

                            RDTarget T1_Kj = new RDTarget();
                            T1_Kj.Date = date;
                            T1_Kj.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_Kj.prodcode = ProductCodes.KeshaJusmine.ToString();
                            T1_Kj.Target = HandleDecimal(txt_keshaJ_1.Text);

                            TarList.Add(T1_Kj);

                            RDTarget T1_Hc = new RDTarget();
                            T1_Hc.Date = date;
                            T1_Hc.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_Hc.prodcode = ProductCodes.HairCareCool.ToString();
                            T1_Hc.Target = HandleDecimal(txt_HCC_1.Text);

                            TarList.Add(T1_Hc);


                            RDTarget T1_MG = new RDTarget();
                            T1_MG.Date = date;
                            T1_MG.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_MG.prodcode = ProductCodes.Muscleguard.ToString();
                            T1_MG.Target = HandleDecimal(txt_MG_1.Text);

                            TarList.Add(T1_MG);


                            RDTarget T1_paspangu = new RDTarget();
                            T1_paspangu.Date = date;
                            T1_paspangu.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_paspangu.prodcode = ProductCodes.Paspanguwa.ToString();
                            T1_paspangu.Target = HandleDecimal(txt_Paspangu_1.Text);

                            TarList.Add(T1_paspangu);



                            RDTarget T1_sud45 = new RDTarget();
                            T1_sud45.Date = date;
                            T1_sud45.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_sud45.prodcode = ProductCodes.Sudantha45g.ToString();
                            T1_sud45.Target = HandleDecimal(txt_Sud45_1.Text);

                            TarList.Add(T1_sud45);


                            RDTarget T1_sud80 = new RDTarget();
                            T1_sud80.Date = date;
                            T1_sud80.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_sud80.prodcode = ProductCodes.Sudantha80g.ToString();
                            T1_sud80.Target = HandleDecimal(txt_Sud80_1.Text);

                            TarList.Add(T1_sud80);


                            RDTarget T1_balm3 = new RDTarget();
                            T1_balm3.Date = date;
                            T1_balm3.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_balm3.prodcode = ProductCodes.SamahanBalm_3g.ToString();
                            T1_balm3.Target = HandleDecimal(txt_balm3_1.Text);

                            TarList.Add(T1_balm3);

                            RDTarget T1_balm7 = new RDTarget();
                            T1_balm7.Date = date;
                            T1_balm7.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_balm7.prodcode = ProductCodes.SamahanBalm_7g.ToString();
                            T1_balm7.Target = HandleDecimal(txt_balm7_1.Text);

                            TarList.Add(T1_balm7);


                            RDTarget T1_balm25 = new RDTarget();
                            T1_balm25.Date = date;
                            T1_balm25.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_balm25.prodcode = ProductCodes.SamahanBalm_25g.ToString();
                            T1_balm25.Target = HandleDecimal(txt_balm25_1.Text);

                            TarList.Add(T1_balm25);

                            RDTarget T1_balm50 = new RDTarget();
                            T1_balm50.Date = date;
                            T1_balm50.TerrID = GetTerrID(lbl_Terr1.Text);
                            T1_balm50.prodcode = ProductCodes.SamahanBalm_50g.ToString();
                            T1_balm50.Target = HandleDecimal(txt_balm50_1.Text);

                            TarList.Add(T1_balm50);


                            RDTarget sws30 = new RDTarget();
                            sws30.Date = date;
                            sws30.TerrID = GetTerrID(lbl_Terr1.Text);
                            sws30.prodcode = ProductCodes.SwasthaThripala30T.ToString();
                            sws30.Target = HandleDecimal(txt_sws30_1.Text);

                            TarList.Add(sws30);

                            RDTarget sws60 = new RDTarget();
                            sws60.Date = date;
                            sws60.TerrID = GetTerrID(lbl_Terr1.Text);
                            sws60.prodcode = ProductCodes.SwasthaThripala60T.ToString();
                            sws60.Target = HandleDecimal(txt_sws60_1.Text);

                            TarList.Add(sws60);


                            RDTarget sws120 = new RDTarget();
                            sws120.Date = date;
                            sws120.TerrID = GetTerrID(lbl_Terr1.Text);
                            sws120.prodcode = ProductCodes.SwasthaThripala120T.ToString();
                            sws120.Target = HandleDecimal(txt_sws120_1.Text);

                            TarList.Add(sws120);
                        }

                        # endregion

                        #region Ter2

                        if (ListTerr.Count >= 2 & txt_samahan_2.Text.Length > 0)
                        {
                            RDTarget T1_Sm = new RDTarget();
                            T1_Sm.Date = date;
                            T1_Sm.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_Sm.prodcode = ProductCodes.Samahan.ToString();
                            T1_Sm.Target = HandleDecimal(txt_samahan_2.Text);

                            TarList.Add(T1_Sm);

                            RDTarget T1_Kn = new RDTarget();
                            T1_Kn.Date = date;
                            T1_Kn.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_Kn.prodcode = ProductCodes.KeshaNormal.ToString();
                            T1_Kn.Target = HandleDecimal(txt_keshaN_2.Text);

                            TarList.Add(T1_Kn);

                            RDTarget T1_Kj = new RDTarget();
                            T1_Kj.Date = date;
                            T1_Kj.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_Kj.prodcode = ProductCodes.KeshaJusmine.ToString();
                            T1_Kj.Target = HandleDecimal(txt_keshaJ_2.Text);

                            TarList.Add(T1_Kj);

                            RDTarget T1_Hc = new RDTarget();
                            T1_Hc.Date = date;
                            T1_Hc.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_Hc.prodcode = ProductCodes.HairCareCool.ToString();
                            T1_Hc.Target = HandleDecimal(txt_HCC_2.Text);

                            TarList.Add(T1_Hc);


                            RDTarget T1_MG = new RDTarget();
                            T1_MG.Date = date;
                            T1_MG.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_MG.prodcode = ProductCodes.Muscleguard.ToString();
                            T1_MG.Target = HandleDecimal(txt_MG_2.Text);

                            TarList.Add(T1_MG);


                            RDTarget T1_paspangu = new RDTarget();
                            T1_paspangu.Date = date;
                            T1_paspangu.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_paspangu.prodcode = ProductCodes.Paspanguwa.ToString();
                            T1_paspangu.Target = HandleDecimal(txt_Paspangu_2.Text);

                            TarList.Add(T1_paspangu);



                            RDTarget T1_sud45 = new RDTarget();
                            T1_sud45.Date = date;
                            T1_sud45.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_sud45.prodcode = ProductCodes.Sudantha45g.ToString();
                            T1_sud45.Target = HandleDecimal(txt_Sud45_2.Text);

                            TarList.Add(T1_sud45);


                            RDTarget T1_sud80 = new RDTarget();
                            T1_sud80.Date = date;
                            T1_sud80.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_sud80.prodcode = ProductCodes.Sudantha80g.ToString();
                            T1_sud80.Target = HandleDecimal(txt_Sud80_2.Text);

                            TarList.Add(T1_sud80);


                            RDTarget T1_balm3 = new RDTarget();
                            T1_balm3.Date = date;
                            T1_balm3.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_balm3.prodcode = ProductCodes.SamahanBalm_3g.ToString();
                            T1_balm3.Target = HandleDecimal(txt_balm3_2.Text);

                            TarList.Add(T1_balm3);

                            RDTarget T1_balm7 = new RDTarget();
                            T1_balm7.Date = date;
                            T1_balm7.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_balm7.prodcode = ProductCodes.SamahanBalm_7g.ToString();
                            T1_balm7.Target = HandleDecimal(txt_balm7_2.Text);

                            TarList.Add(T1_balm7);


                            RDTarget T1_balm25 = new RDTarget();
                            T1_balm25.Date = date;
                            T1_balm25.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_balm25.prodcode = ProductCodes.SamahanBalm_25g.ToString();
                            T1_balm25.Target = HandleDecimal(txt_balm25_2.Text);

                            TarList.Add(T1_balm25);

                            RDTarget T1_balm50 = new RDTarget();
                            T1_balm50.Date = date;
                            T1_balm50.TerrID = GetTerrID(lbl_Terr2.Text);
                            T1_balm50.prodcode = ProductCodes.SamahanBalm_50g.ToString();
                            T1_balm50.Target = HandleDecimal(txt_balm50_2.Text);

                            TarList.Add(T1_balm50);


                            RDTarget sws30 = new RDTarget();
                            sws30.Date = date;
                            sws30.TerrID = GetTerrID(lbl_Terr2.Text);
                            sws30.prodcode = ProductCodes.SwasthaThripala30T.ToString();
                            sws30.Target = HandleDecimal(txt_sws30_2.Text);

                            TarList.Add(sws30);

                            RDTarget sws60 = new RDTarget();
                            sws60.Date = date;
                            sws60.TerrID = GetTerrID(lbl_Terr2.Text);
                            sws60.prodcode = ProductCodes.SwasthaThripala60T.ToString();
                            sws60.Target = HandleDecimal(txt_sws60_2.Text);

                            TarList.Add(sws60);


                            RDTarget sws120 = new RDTarget();
                            sws120.Date = date;
                            sws120.TerrID = GetTerrID(lbl_Terr2.Text);
                            sws120.prodcode = ProductCodes.SwasthaThripala120T.ToString();
                            sws120.Target = HandleDecimal(txt_sws120_2.Text);

                            TarList.Add(sws120);
                        }

                        # endregion

                        #region Ter3

                        if (ListTerr.Count >= 3 & txt_samahan_3.Text.Length > 0)
                        {
                            RDTarget T1_Sm = new RDTarget();
                            T1_Sm.Date = date;
                            T1_Sm.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_Sm.prodcode = ProductCodes.Samahan.ToString();
                            T1_Sm.Target = HandleDecimal(txt_samahan_3.Text);

                            TarList.Add(T1_Sm);

                            RDTarget T1_Kn = new RDTarget();
                            T1_Kn.Date = date;
                            T1_Kn.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_Kn.prodcode = ProductCodes.KeshaNormal.ToString();
                            T1_Kn.Target = HandleDecimal(txt_keshaN_3.Text);

                            TarList.Add(T1_Kn);

                            RDTarget T1_Kj = new RDTarget();
                            T1_Kj.Date = date;
                            T1_Kj.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_Kj.prodcode = ProductCodes.KeshaJusmine.ToString();
                            T1_Kj.Target = HandleDecimal(txt_keshaJ_3.Text);

                            TarList.Add(T1_Kj);

                            RDTarget T1_Hc = new RDTarget();
                            T1_Hc.Date = date;
                            T1_Hc.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_Hc.prodcode = ProductCodes.HairCareCool.ToString();
                            T1_Hc.Target = HandleDecimal(txt_HCC_3.Text);

                            TarList.Add(T1_Hc);


                            RDTarget T1_MG = new RDTarget();
                            T1_MG.Date = date;
                            T1_MG.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_MG.prodcode = ProductCodes.Muscleguard.ToString();
                            T1_MG.Target = HandleDecimal(txt_MG_3.Text);

                            TarList.Add(T1_MG);


                            RDTarget T1_paspangu = new RDTarget();
                            T1_paspangu.Date = date;
                            T1_paspangu.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_paspangu.prodcode = ProductCodes.Paspanguwa.ToString();
                            T1_paspangu.Target = HandleDecimal(txt_Paspangu_3.Text);

                            TarList.Add(T1_paspangu);



                            RDTarget T1_sud45 = new RDTarget();
                            T1_sud45.Date = date;
                            T1_sud45.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_sud45.prodcode = ProductCodes.Sudantha45g.ToString();
                            T1_sud45.Target = HandleDecimal(txt_Sud45_3.Text);

                            TarList.Add(T1_sud45);


                            RDTarget T1_sud80 = new RDTarget();
                            T1_sud80.Date = date;
                            T1_sud80.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_sud80.prodcode = ProductCodes.Sudantha80g.ToString();
                            T1_sud80.Target = HandleDecimal(txt_Sud80_3.Text);

                            TarList.Add(T1_sud80);


                            RDTarget T1_balm3 = new RDTarget();
                            T1_balm3.Date = date;
                            T1_balm3.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_balm3.prodcode = ProductCodes.SamahanBalm_3g.ToString();
                            T1_balm3.Target = HandleDecimal(txt_balm3_3.Text);

                            TarList.Add(T1_balm3);

                            RDTarget T1_balm7 = new RDTarget();
                            T1_balm7.Date = date;
                            T1_balm7.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_balm7.prodcode = ProductCodes.SamahanBalm_7g.ToString();
                            T1_balm7.Target = HandleDecimal(txt_balm7_3.Text);

                            TarList.Add(T1_balm7);


                            RDTarget T1_balm25 = new RDTarget();
                            T1_balm25.Date = date;
                            T1_balm25.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_balm25.prodcode = ProductCodes.SamahanBalm_25g.ToString();
                            T1_balm25.Target = HandleDecimal(txt_balm25_3.Text);

                            TarList.Add(T1_balm25);

                            RDTarget T1_balm50 = new RDTarget();
                            T1_balm50.Date = date;
                            T1_balm50.TerrID = GetTerrID(lbl_Terr3.Text);
                            T1_balm50.prodcode = ProductCodes.SamahanBalm_50g.ToString();
                            T1_balm50.Target = HandleDecimal(txt_balm50_3.Text);

                            TarList.Add(T1_balm50);


                            RDTarget sws30 = new RDTarget();
                            sws30.Date = date;
                            sws30.TerrID = GetTerrID(lbl_Terr3.Text);
                            sws30.prodcode = ProductCodes.SwasthaThripala30T.ToString();
                            sws30.Target = HandleDecimal(txt_sws30_3.Text);

                            TarList.Add(sws30);

                            RDTarget sws60 = new RDTarget();
                            sws60.Date = date;
                            sws60.TerrID = GetTerrID(lbl_Terr3.Text);
                            sws60.prodcode = ProductCodes.SwasthaThripala60T.ToString();
                            sws60.Target = HandleDecimal(txt_sws60_3.Text);

                            TarList.Add(sws60);


                            RDTarget sws120 = new RDTarget();
                            sws120.Date = date;
                            sws120.TerrID = GetTerrID(lbl_Terr3.Text);
                            sws120.prodcode = ProductCodes.SwasthaThripala120T.ToString();
                            sws120.Target = HandleDecimal(txt_sws120_3.Text);

                            TarList.Add(sws120);
                        }

                        # endregion

                        #region Ter4

                        if (ListTerr.Count >= 4 & txt_samahan_4.Text.Length > 0)
                        {
                            RDTarget T1_Sm = new RDTarget();
                            T1_Sm.Date = date;
                            T1_Sm.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_Sm.prodcode = ProductCodes.Samahan.ToString();
                            T1_Sm.Target = HandleDecimal(txt_samahan_4.Text);

                            TarList.Add(T1_Sm);

                            RDTarget T1_Kn = new RDTarget();
                            T1_Kn.Date = date;
                            T1_Kn.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_Kn.prodcode = ProductCodes.KeshaNormal.ToString();
                            T1_Kn.Target = HandleDecimal(txt_keshaN_4.Text);

                            TarList.Add(T1_Kn);

                            RDTarget T1_Kj = new RDTarget();
                            T1_Kj.Date = date;
                            T1_Kj.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_Kj.prodcode = ProductCodes.KeshaJusmine.ToString();
                            T1_Kj.Target = HandleDecimal(txt_keshaJ_4.Text);

                            TarList.Add(T1_Kj);

                            RDTarget T1_Hc = new RDTarget();
                            T1_Hc.Date = date;
                            T1_Hc.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_Hc.prodcode = ProductCodes.HairCareCool.ToString();
                            T1_Hc.Target = HandleDecimal(txt_HCC_4.Text);

                            TarList.Add(T1_Hc);


                            RDTarget T1_MG = new RDTarget();
                            T1_MG.Date = date;
                            T1_MG.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_MG.prodcode = ProductCodes.Muscleguard.ToString();
                            T1_MG.Target = HandleDecimal(txt_MG_4.Text);

                            TarList.Add(T1_MG);


                            RDTarget T1_paspangu = new RDTarget();
                            T1_paspangu.Date = date;
                            T1_paspangu.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_paspangu.prodcode = ProductCodes.Paspanguwa.ToString();
                            T1_paspangu.Target = HandleDecimal(txt_Paspangu_4.Text);

                            TarList.Add(T1_paspangu);



                            RDTarget T1_sud45 = new RDTarget();
                            T1_sud45.Date = date;
                            T1_sud45.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_sud45.prodcode = ProductCodes.Sudantha45g.ToString();
                            T1_sud45.Target = HandleDecimal(txt_Sud45_4.Text);

                            TarList.Add(T1_sud45);


                            RDTarget T1_sud80 = new RDTarget();
                            T1_sud80.Date = date;
                            T1_sud80.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_sud80.prodcode = ProductCodes.Sudantha80g.ToString();
                            T1_sud80.Target = HandleDecimal(txt_Sud80_4.Text);

                            TarList.Add(T1_sud80);


                            RDTarget T1_balm3 = new RDTarget();
                            T1_balm3.Date = date;
                            T1_balm3.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_balm3.prodcode = ProductCodes.SamahanBalm_3g.ToString();
                            T1_balm3.Target = HandleDecimal(txt_balm3_4.Text);

                            TarList.Add(T1_balm3);

                            RDTarget T1_balm7 = new RDTarget();
                            T1_balm7.Date = date;
                            T1_balm7.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_balm7.prodcode = ProductCodes.SamahanBalm_7g.ToString();
                            T1_balm7.Target = HandleDecimal(txt_balm7_4.Text);

                            TarList.Add(T1_balm7);


                            RDTarget T1_balm25 = new RDTarget();
                            T1_balm25.Date = date;
                            T1_balm25.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_balm25.prodcode = ProductCodes.SamahanBalm_25g.ToString();
                            T1_balm25.Target = HandleDecimal(txt_balm25_4.Text);

                            TarList.Add(T1_balm25);

                            RDTarget T1_balm50 = new RDTarget();
                            T1_balm50.Date = date;
                            T1_balm50.TerrID = GetTerrID(lbl_Terr4.Text);
                            T1_balm50.prodcode = ProductCodes.SamahanBalm_50g.ToString();
                            T1_balm50.Target = HandleDecimal(txt_balm50_4.Text);

                            TarList.Add(T1_balm50);


                            RDTarget sws30 = new RDTarget();
                            sws30.Date = date;
                            sws30.TerrID = GetTerrID(lbl_Terr4.Text);
                            sws30.prodcode = ProductCodes.SwasthaThripala30T.ToString();
                            sws30.Target = HandleDecimal(txt_sws30_4.Text);

                            TarList.Add(sws30);

                            RDTarget sws60 = new RDTarget();
                            sws60.Date = date;
                            sws60.TerrID = GetTerrID(lbl_Terr4.Text);
                            sws60.prodcode = ProductCodes.SwasthaThripala60T.ToString();
                            sws60.Target = HandleDecimal(txt_sws60_4.Text);

                            TarList.Add(sws60);


                            RDTarget sws120 = new RDTarget();
                            sws120.Date = date;
                            sws120.TerrID = GetTerrID(lbl_Terr4.Text);
                            sws120.prodcode = ProductCodes.SwasthaThripala120T.ToString();
                            sws120.Target = HandleDecimal(txt_sws120_4.Text);

                            TarList.Add(sws120);
                        }

                        # endregion

                        #region Ter5

                        if (ListTerr.Count >= 5 & txt_samahan_5.Text.Length > 0)
                        {
                            RDTarget T1_Sm = new RDTarget();
                            T1_Sm.Date = date;
                            T1_Sm.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_Sm.prodcode = ProductCodes.Samahan.ToString();
                            T1_Sm.Target = HandleDecimal(txt_samahan_5.Text);

                            TarList.Add(T1_Sm);

                            RDTarget T1_Kn = new RDTarget();
                            T1_Kn.Date = date;
                            T1_Kn.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_Kn.prodcode = ProductCodes.KeshaNormal.ToString();
                            T1_Kn.Target = HandleDecimal(txt_keshaN_5.Text);

                            TarList.Add(T1_Kn);

                            RDTarget T1_Kj = new RDTarget();
                            T1_Kj.Date = date;
                            T1_Kj.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_Kj.prodcode = ProductCodes.KeshaJusmine.ToString();
                            T1_Kj.Target = HandleDecimal(txt_keshaJ_5.Text);

                            TarList.Add(T1_Kj);

                            RDTarget T1_Hc = new RDTarget();
                            T1_Hc.Date = date;
                            T1_Hc.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_Hc.prodcode = ProductCodes.HairCareCool.ToString();
                            T1_Hc.Target = HandleDecimal(txt_HCC_5.Text);

                            TarList.Add(T1_Hc);


                            RDTarget T1_MG = new RDTarget();
                            T1_MG.Date = date;
                            T1_MG.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_MG.prodcode = ProductCodes.Muscleguard.ToString();
                            T1_MG.Target = HandleDecimal(txt_MG_5.Text);

                            TarList.Add(T1_MG);


                            RDTarget T1_paspangu = new RDTarget();
                            T1_paspangu.Date = date;
                            T1_paspangu.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_paspangu.prodcode = ProductCodes.Paspanguwa.ToString();
                            T1_paspangu.Target = HandleDecimal(txt_Paspangu_5.Text);

                            TarList.Add(T1_paspangu);



                            RDTarget T1_sud45 = new RDTarget();
                            T1_sud45.Date = date;
                            T1_sud45.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_sud45.prodcode = ProductCodes.Sudantha45g.ToString();
                            T1_sud45.Target = HandleDecimal(txt_Sud45_5.Text);

                            TarList.Add(T1_sud45);


                            RDTarget T1_sud80 = new RDTarget();
                            T1_sud80.Date = date;
                            T1_sud80.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_sud80.prodcode = ProductCodes.Sudantha80g.ToString();
                            T1_sud80.Target = HandleDecimal(txt_Sud80_5.Text);

                            TarList.Add(T1_sud80);


                            RDTarget T1_balm3 = new RDTarget();
                            T1_balm3.Date = date;
                            T1_balm3.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_balm3.prodcode = ProductCodes.SamahanBalm_3g.ToString();
                            T1_balm3.Target = HandleDecimal(txt_balm3_5.Text);

                            TarList.Add(T1_balm3);

                            RDTarget T1_balm7 = new RDTarget();
                            T1_balm7.Date = date;
                            T1_balm7.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_balm7.prodcode = ProductCodes.SamahanBalm_7g.ToString();
                            T1_balm7.Target = HandleDecimal(txt_balm7_5.Text);

                            TarList.Add(T1_balm7);


                            RDTarget T1_balm25 = new RDTarget();
                            T1_balm25.Date = date;
                            T1_balm25.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_balm25.prodcode = ProductCodes.SamahanBalm_25g.ToString();
                            T1_balm25.Target = HandleDecimal(txt_balm25_5.Text);

                            TarList.Add(T1_balm25);

                            RDTarget T1_balm50 = new RDTarget();
                            T1_balm50.Date = date;
                            T1_balm50.TerrID = GetTerrID(lbl_Terr5.Text);
                            T1_balm50.prodcode = ProductCodes.SamahanBalm_50g.ToString();
                            T1_balm50.Target = HandleDecimal(txt_balm50_5.Text);

                            TarList.Add(T1_balm50);


                            RDTarget sws30 = new RDTarget();
                            sws30.Date = date;
                            sws30.TerrID = GetTerrID(lbl_Terr5.Text);
                            sws30.prodcode = ProductCodes.SwasthaThripala30T.ToString();
                            sws30.Target = HandleDecimal(txt_sws30_5.Text);

                            TarList.Add(sws30);

                            RDTarget sws60 = new RDTarget();
                            sws60.Date = date;
                            sws60.TerrID = GetTerrID(lbl_Terr5.Text);
                            sws60.prodcode = ProductCodes.SwasthaThripala60T.ToString();
                            sws60.Target = HandleDecimal(txt_sws60_5.Text);

                            TarList.Add(sws60);


                            RDTarget sws120 = new RDTarget();
                            sws120.Date = date;
                            sws120.TerrID = GetTerrID(lbl_Terr5.Text);
                            sws120.prodcode = ProductCodes.SwasthaThripala120T.ToString();
                            sws120.Target = HandleDecimal(txt_sws120_5.Text);

                            TarList.Add(sws120);
                        }

                        # endregion

                        #region Ter6

                        if (ListTerr.Count >= 6 & txt_samahan_6.Text.Length > 0)
                        {
                            RDTarget T1_Sm = new RDTarget();
                            T1_Sm.Date = date;
                            T1_Sm.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_Sm.prodcode = ProductCodes.Samahan.ToString();
                            T1_Sm.Target = HandleDecimal(txt_samahan_6.Text);

                            TarList.Add(T1_Sm);

                            RDTarget T1_Kn = new RDTarget();
                            T1_Kn.Date = date;
                            T1_Kn.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_Kn.prodcode = ProductCodes.KeshaNormal.ToString();
                            T1_Kn.Target = HandleDecimal(txt_keshaN_6.Text);

                            TarList.Add(T1_Kn);

                            RDTarget T1_Kj = new RDTarget();
                            T1_Kj.Date = date;
                            T1_Kj.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_Kj.prodcode = ProductCodes.KeshaJusmine.ToString();
                            T1_Kj.Target = HandleDecimal(txt_keshaJ_6.Text);

                            TarList.Add(T1_Kj);

                            RDTarget T1_Hc = new RDTarget();
                            T1_Hc.Date = date;
                            T1_Hc.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_Hc.prodcode = ProductCodes.HairCareCool.ToString();
                            T1_Hc.Target = HandleDecimal(txt_HCC_6.Text);

                            TarList.Add(T1_Hc);


                            RDTarget T1_MG = new RDTarget();
                            T1_MG.Date = date;
                            T1_MG.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_MG.prodcode = ProductCodes.Muscleguard.ToString();
                            T1_MG.Target = HandleDecimal(txt_MG_6.Text);

                            TarList.Add(T1_MG);


                            RDTarget T1_paspangu = new RDTarget();
                            T1_paspangu.Date = date;
                            T1_paspangu.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_paspangu.prodcode = ProductCodes.Paspanguwa.ToString();
                            T1_paspangu.Target = HandleDecimal(txt_Paspangu_6.Text);

                            TarList.Add(T1_paspangu);



                            RDTarget T1_sud45 = new RDTarget();
                            T1_sud45.Date = date;
                            T1_sud45.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_sud45.prodcode = ProductCodes.Sudantha45g.ToString();
                            T1_sud45.Target = HandleDecimal(txt_Sud45_6.Text);

                            TarList.Add(T1_sud45);


                            RDTarget T1_sud80 = new RDTarget();
                            T1_sud80.Date = date;
                            T1_sud80.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_sud80.prodcode = ProductCodes.Sudantha80g.ToString();
                            T1_sud80.Target = HandleDecimal(txt_Sud80_6.Text);

                            TarList.Add(T1_sud80);


                            RDTarget T1_balm3 = new RDTarget();
                            T1_balm3.Date = date;
                            T1_balm3.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_balm3.prodcode = ProductCodes.SamahanBalm_3g.ToString();
                            T1_balm3.Target = HandleDecimal(txt_balm3_6.Text);

                            TarList.Add(T1_balm3);

                            RDTarget T1_balm7 = new RDTarget();
                            T1_balm7.Date = date;
                            T1_balm7.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_balm7.prodcode = ProductCodes.SamahanBalm_7g.ToString();
                            T1_balm7.Target = HandleDecimal(txt_balm7_6.Text);

                            TarList.Add(T1_balm7);


                            RDTarget T1_balm25 = new RDTarget();
                            T1_balm25.Date = date;
                            T1_balm25.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_balm25.prodcode = ProductCodes.SamahanBalm_25g.ToString();
                            T1_balm25.Target = HandleDecimal(txt_balm25_6.Text);

                            TarList.Add(T1_balm25);

                            RDTarget T1_balm50 = new RDTarget();
                            T1_balm50.Date = date;
                            T1_balm50.TerrID = GetTerrID(lbl_Terr6.Text);
                            T1_balm50.prodcode = ProductCodes.SamahanBalm_50g.ToString();
                            T1_balm50.Target = HandleDecimal(txt_balm50_6.Text);

                            TarList.Add(T1_balm50);


                            RDTarget sws30 = new RDTarget();
                            sws30.Date = date;
                            sws30.TerrID = GetTerrID(lbl_Terr6.Text);
                            sws30.prodcode = ProductCodes.SwasthaThripala30T.ToString();
                            sws30.Target = HandleDecimal(txt_sws30_6.Text);

                            TarList.Add(sws30);

                            RDTarget sws60 = new RDTarget();
                            sws60.Date = date;
                            sws60.TerrID = GetTerrID(lbl_Terr6.Text);
                            sws60.prodcode = ProductCodes.SwasthaThripala60T.ToString();
                            sws60.Target = HandleDecimal(txt_sws60_6.Text);

                            TarList.Add(sws60);


                            RDTarget sws120 = new RDTarget();
                            sws120.Date = date;
                            sws120.TerrID = GetTerrID(lbl_Terr6.Text);
                            sws120.prodcode = ProductCodes.SwasthaThripala120T.ToString();
                            sws120.Target = HandleDecimal(txt_sws120_6.Text);

                            TarList.Add(sws120);
                        }

                        # endregion

                        #region Ter7

                        if (ListTerr.Count >= 7 & txt_samahan_7.Text.Length > 0)
                        {
                            RDTarget T1_Sm = new RDTarget();
                            T1_Sm.Date = date;
                            T1_Sm.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_Sm.prodcode = ProductCodes.Samahan.ToString();
                            T1_Sm.Target = HandleDecimal(txt_samahan_7.Text);

                            TarList.Add(T1_Sm);

                            RDTarget T1_Kn = new RDTarget();
                            T1_Kn.Date = date;
                            T1_Kn.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_Kn.prodcode = ProductCodes.KeshaNormal.ToString();
                            T1_Kn.Target = HandleDecimal(txt_keshaN_7.Text);

                            TarList.Add(T1_Kn);

                            RDTarget T1_Kj = new RDTarget();
                            T1_Kj.Date = date;
                            T1_Kj.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_Kj.prodcode = ProductCodes.KeshaJusmine.ToString();
                            T1_Kj.Target = HandleDecimal(txt_keshaJ_7.Text);

                            TarList.Add(T1_Kj);

                            RDTarget T1_Hc = new RDTarget();
                            T1_Hc.Date = date;
                            T1_Hc.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_Hc.prodcode = ProductCodes.HairCareCool.ToString();
                            T1_Hc.Target = HandleDecimal(txt_HCC_7.Text);

                            TarList.Add(T1_Hc);


                            RDTarget T1_MG = new RDTarget();
                            T1_MG.Date = date;
                            T1_MG.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_MG.prodcode = ProductCodes.Muscleguard.ToString();
                            T1_MG.Target = HandleDecimal(txt_MG_7.Text);

                            TarList.Add(T1_MG);


                            RDTarget T1_paspangu = new RDTarget();
                            T1_paspangu.Date = date;
                            T1_paspangu.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_paspangu.prodcode = ProductCodes.Paspanguwa.ToString();
                            T1_paspangu.Target = HandleDecimal(txt_Paspangu_7.Text);

                            TarList.Add(T1_paspangu);



                            RDTarget T1_sud45 = new RDTarget();
                            T1_sud45.Date = date;
                            T1_sud45.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_sud45.prodcode = ProductCodes.Sudantha45g.ToString();
                            T1_sud45.Target = HandleDecimal(txt_Sud45_7.Text);

                            TarList.Add(T1_sud45);


                            RDTarget T1_sud80 = new RDTarget();
                            T1_sud80.Date = date;
                            T1_sud80.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_sud80.prodcode = ProductCodes.Sudantha80g.ToString();
                            T1_sud80.Target = HandleDecimal(txt_Sud80_7.Text);

                            TarList.Add(T1_sud80);


                            RDTarget T1_balm3 = new RDTarget();
                            T1_balm3.Date = date;
                            T1_balm3.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_balm3.prodcode = ProductCodes.SamahanBalm_3g.ToString();
                            T1_balm3.Target = HandleDecimal(txt_balm3_7.Text);

                            TarList.Add(T1_balm3);

                            RDTarget T1_balm7 = new RDTarget();
                            T1_balm7.Date = date;
                            T1_balm7.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_balm7.prodcode = ProductCodes.SamahanBalm_7g.ToString();
                            T1_balm7.Target = HandleDecimal(txt_balm7_7.Text);

                            TarList.Add(T1_balm7);


                            RDTarget T1_balm25 = new RDTarget();
                            T1_balm25.Date = date;
                            T1_balm25.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_balm25.prodcode = ProductCodes.SamahanBalm_25g.ToString();
                            T1_balm25.Target = HandleDecimal(txt_balm25_7.Text);

                            TarList.Add(T1_balm25);

                            RDTarget T1_balm50 = new RDTarget();
                            T1_balm50.Date = date;
                            T1_balm50.TerrID = GetTerrID(lbl_Terr7.Text);
                            T1_balm50.prodcode = ProductCodes.SamahanBalm_50g.ToString();
                            T1_balm50.Target = HandleDecimal(txt_balm50_7.Text);

                            TarList.Add(T1_balm50);


                            RDTarget sws30 = new RDTarget();
                            sws30.Date = date;
                            sws30.TerrID = GetTerrID(lbl_Terr7.Text);
                            sws30.prodcode = ProductCodes.SwasthaThripala30T.ToString();
                            sws30.Target = HandleDecimal(txt_sws30_7.Text);

                            TarList.Add(sws30);

                            RDTarget sws60 = new RDTarget();
                            sws60.Date = date;
                            sws60.TerrID = GetTerrID(lbl_Terr7.Text);
                            sws60.prodcode = ProductCodes.SwasthaThripala60T.ToString();
                            sws60.Target = HandleDecimal(txt_sws60_7.Text);

                            TarList.Add(sws60);


                            RDTarget sws120 = new RDTarget();
                            sws120.Date = date;
                            sws120.TerrID = GetTerrID(lbl_Terr7.Text);
                            sws120.prodcode = ProductCodes.SwasthaThripala120T.ToString();
                            sws120.Target = HandleDecimal(txt_sws120_7.Text);

                            TarList.Add(sws120);
                        }

                        # endregion

                        #region Ter8

                        if (ListTerr.Count >= 8 & txt_samahan_8.Text.Length > 0)
                        {
                            RDTarget T1_Sm = new RDTarget();
                            T1_Sm.Date = date;
                            T1_Sm.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_Sm.prodcode = ProductCodes.Samahan.ToString();
                            T1_Sm.Target = HandleDecimal(txt_samahan_8.Text);

                            TarList.Add(T1_Sm);

                            RDTarget T1_Kn = new RDTarget();
                            T1_Kn.Date = date;
                            T1_Kn.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_Kn.prodcode = ProductCodes.KeshaNormal.ToString();
                            T1_Kn.Target = HandleDecimal(txt_keshaN_8.Text);

                            TarList.Add(T1_Kn);

                            RDTarget T1_Kj = new RDTarget();
                            T1_Kj.Date = date;
                            T1_Kj.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_Kj.prodcode = ProductCodes.KeshaJusmine.ToString();
                            T1_Kj.Target = HandleDecimal(txt_keshaJ_8.Text);

                            TarList.Add(T1_Kj);

                            RDTarget T1_Hc = new RDTarget();
                            T1_Hc.Date = date;
                            T1_Hc.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_Hc.prodcode = ProductCodes.HairCareCool.ToString();
                            T1_Hc.Target = HandleDecimal(txt_HCC_8.Text);

                            TarList.Add(T1_Hc);


                            RDTarget T1_MG = new RDTarget();
                            T1_MG.Date = date;
                            T1_MG.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_MG.prodcode = ProductCodes.Muscleguard.ToString();
                            T1_MG.Target = HandleDecimal(txt_MG_8.Text);

                            TarList.Add(T1_MG);


                            RDTarget T1_paspangu = new RDTarget();
                            T1_paspangu.Date = date;
                            T1_paspangu.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_paspangu.prodcode = ProductCodes.Paspanguwa.ToString();
                            T1_paspangu.Target = HandleDecimal(txt_Paspangu_8.Text);

                            TarList.Add(T1_paspangu);



                            RDTarget T1_sud45 = new RDTarget();
                            T1_sud45.Date = date;
                            T1_sud45.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_sud45.prodcode = ProductCodes.Sudantha45g.ToString();
                            T1_sud45.Target = HandleDecimal(txt_Sud45_8.Text);

                            TarList.Add(T1_sud45);


                            RDTarget T1_sud80 = new RDTarget();
                            T1_sud80.Date = date;
                            T1_sud80.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_sud80.prodcode = ProductCodes.Sudantha80g.ToString();
                            T1_sud80.Target = HandleDecimal(txt_Sud80_8.Text);

                            TarList.Add(T1_sud80);


                            RDTarget T1_balm3 = new RDTarget();
                            T1_balm3.Date = date;
                            T1_balm3.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_balm3.prodcode = ProductCodes.SamahanBalm_3g.ToString();
                            T1_balm3.Target = HandleDecimal(txt_balm3_8.Text);

                            TarList.Add(T1_balm3);

                            RDTarget T1_balm7 = new RDTarget();
                            T1_balm7.Date = date;
                            T1_balm7.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_balm7.prodcode = ProductCodes.SamahanBalm_7g.ToString();
                            T1_balm7.Target = HandleDecimal(txt_balm7_8.Text);

                            TarList.Add(T1_balm7);


                            RDTarget T1_balm25 = new RDTarget();
                            T1_balm25.Date = date;
                            T1_balm25.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_balm25.prodcode = ProductCodes.SamahanBalm_25g.ToString();
                            T1_balm25.Target = HandleDecimal(txt_balm25_8.Text);

                            TarList.Add(T1_balm25);

                            RDTarget T1_balm50 = new RDTarget();
                            T1_balm50.Date = date;
                            T1_balm50.TerrID = GetTerrID(lbl_Terr8.Text);
                            T1_balm50.prodcode = ProductCodes.SamahanBalm_50g.ToString();
                            T1_balm50.Target = HandleDecimal(txt_balm50_8.Text);

                            TarList.Add(T1_balm50);


                            RDTarget sws30 = new RDTarget();
                            sws30.Date = date;
                            sws30.TerrID = GetTerrID(lbl_Terr8.Text);
                            sws30.prodcode = ProductCodes.SwasthaThripala30T.ToString();
                            sws30.Target = HandleDecimal(txt_sws30_8.Text);

                            TarList.Add(sws30);

                            RDTarget sws60 = new RDTarget();
                            sws60.Date = date;
                            sws60.TerrID = GetTerrID(lbl_Terr8.Text);
                            sws60.prodcode = ProductCodes.SwasthaThripala60T.ToString();
                            sws60.Target = HandleDecimal(txt_sws60_8.Text);

                            TarList.Add(sws60);


                            RDTarget sws120 = new RDTarget();
                            sws120.Date = date;
                            sws120.TerrID = GetTerrID(lbl_Terr8.Text);
                            sws120.prodcode = ProductCodes.SwasthaThripala120T.ToString();
                            sws120.Target = HandleDecimal(txt_sws120_8.Text);

                            TarList.Add(sws120);
                        }

                        # endregion


                        //Update Targets
                        int count = 0;
                        foreach (RDTarget tar in TarList)
                        {

                            bool stat = TargetsHandler.SPUPDATE_RDTarget(tar.Date, tar.TerrID, tar.prodcode, tar.Target, UserObj.ID);
                            if (stat)
                            {
                                count++;
                            }


                        }


                        if (count < ListTerr.Count * 15 || count == 0)
                        {


                            Alert.Show("Target Update  Unsuccessful: NUMBER OF RECORDS UPDATED: " + count);
                        }
                        else
                        {

                            Alert.Show("Target Update   : Successfull,RECORDS UPDATED: " + count);
                            LoadData();

                        }

                    }
                }
                else
                {
                    lbl_status.Text = "Server Unavailable:Please try again later";
                }
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + "Edit";
            }
        }

        private decimal HandleDecimal(string val)
        {
            decimal obj = 0;
            try
            {
                obj = Decimal.Parse(val);
            }
            catch (Exception)
            {

                obj = 0;
            }

            return obj;

        }

        private int HandleInt(string val)
        {
            int obj = 0;
            try
            {
                obj = Int32.Parse(val);
            }
            catch (Exception)
            {

                obj = 0;
            }

            return obj;

        }

        protected void bttn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCoreData();

                if (DBCon.CheckSQLServer())
                {
                    
                    bool stat = TargetsHandler.SPUPDATE_Confrmed(date, UserId);
                    
                    if (stat)
                    {
                        Alert.Show("Data Confirmed.The data can no longer be edited\\n" + "Sales:" + stat );
                        LoadData();
                    }
                    else
                    {
                        Alert.Show("Confirmation Unsuccessful,Please try again later\\n" + "Sales:" + stat);
                    }
                }
                else
                {
                    Alert.Show("Cannot reach the server. Please check your internet connection");
                }
            }
            catch (Exception ee)
            {
                lbl_status.Text = ee.Message + ": Confirm";

            }
        }
    }
}