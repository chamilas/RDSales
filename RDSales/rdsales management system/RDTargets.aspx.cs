using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RDSales_Entities;
using RDSales_Entity_Handler;

namespace RDSales_Management_System
{
    public partial class RDTargets : System.Web.UI.Page
    {
        int UserId = 0;
        private List<Territory> ListTerr = new List<Territory>();
        private RDSales_Entities.UserEntity UserObj;
        private string date = "";
        private Region objReg = new Region();

        private int region = 0;


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
                    date = DBCon.GetServerDate();
                    txt_date.Text = date;
                    LoadTextBox();

                    //HandleConfirmbuttom();
                }

                LoadData();
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": Page Load";
            }
            
        }

        private void LoadData()
        {


            //Get Region By LoggedUser
            try
            {
                date = txt_date.Text;
               

                objReg = RegionHandler.SPGET_RegionByUser(UserId);

                if (objReg.RegionID == 0)
                {
                    lbl_status.Text = "You have no region assigned!";
                    bttn_submit.Enabled = false;
                }
                
                else
                {

                    //Get Territories by  Region
                    ListTerr = TerritoryHandler.SPGET_TerritoryByRegion(objReg.RegionID);

                    txt_region.Text = objReg.RegionName;
                    txt_asm.Text = UserObj.Name;



                    #region Load TerritoryNames
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



                    bttn_submit.Enabled = true;


                    #region Control Visibility

                    bool dataexist = TargetsHandler.SPCHECK_TargetsExists(date, objReg.RegionID);
                    if (dataexist)
                    {
                        HandleTerr1(true);
                        HandleTerr2(true);
                        HandleTerr3(true);
                        HandleTerr4(true);
                        HandleTerr5(true);
                        HandleTerr6(true);
                        HandleTerr7(true);
                        HandleTerr8(true);

                        lbl_status.ForeColor = System.Drawing.Color.Green;
                        lbl_status.Text = "Data Already Submited for: " + date;

                        bttn_submit.Enabled = false;

                    }
                    else
                    {

                        ControlTextboxState();
                        lbl_status.Text = "";

                        bttn_submit.Enabled = true;

                    }
                    #endregion

                    ControlTextboxState();
                }
            }
            catch (Exception)
            {

                throw;
            }

          #endregion

        }

        #region Control state of Territory Textbox
        private void HandleTerr1(bool val)
        {
            txt_samahan_1.Visible = val;
            txt_keshaN_1.Visible = val;
            txt_keshaJ_1.Visible = val;
            txt_HCC_1.Visible = val;
            txt_MG_1.Visible = val;
            txt_Paspangu_1.Visible = val;
            txt_Sud45_1.Visible = val;
            txt_Sud80_1.Visible = val;
            txt_balm3_1.Visible = val;
            txt_balm7_1.Visible = val;
            txt_balm25_1.Visible = val;
            txt_balm50_1.Visible = val;
            txt_sws30_1.Visible = val;
            txt_sws60_1.Visible = val;
            txt_sws120_1.Visible = val;

         
          



        }

        private void HandleTerr2(bool val)
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

           
           
        }

        private void HandleTerr3(bool val)
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

           
        }

        private void HandleTerr4(bool val)
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

          

           
        }

        private void HandleTerr5(bool val)
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

         

           
        }

        private void HandleTerr6(bool val)
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

            
        }

        private void HandleTerr7(bool val)
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

        

           

        }

        private void HandleTerr8(bool val)
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

    

            

        }

        #endregion

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

                HandleTerr1(hasTerr[0]);
                HandleTerr2(hasTerr[1]);
                HandleTerr3(hasTerr[2]);
                HandleTerr4(hasTerr[3]);
                HandleTerr5(hasTerr[4]);
                HandleTerr6(hasTerr[5]);
                HandleTerr7(hasTerr[6]);
                HandleTerr8(hasTerr[7]);
            }
            catch (Exception ee)
            {

                lbl_status.Text = ee.Message + ": Control  Textbox state";
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

           

          


        }

        protected void txt_date_TextChanged(object sender, EventArgs e)
        {
            date = txt_date.Text;
            lbl_status.Text = "";
            LoadData();
        }

        protected void bttn_submit_Click(object sender, EventArgs e)
        {
            try
            {
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


                        //Insert Daily Sales
                        int count = 0;
                        foreach (RDTarget tar in TarList)
                        {

                            bool stat = TargetsHandler.SPADD_RD_Targets(tar.Date, tar.TerrID, tar.prodcode, tar.Target, UserObj.ID);
                            if (stat)
                            {
                                count++;
                            }


                        }


                        if (count < ListTerr.Count * 15 || count == 0)
                        {

                            
                            Alert.Show("Sales Target Insertion Unsuccessful: NUMBER OF RECORDS UPDATED: " + count );
                        }
                        else
                        {

                            Alert.Show("Sales Target Insertion : Successfull,RECORDS UPDATED: " + count);
                            LoadTextBox();
                            
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

                lbl_status.Text = ee.Message + "Submit";
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


        public static int GetTerrID(string value)
        {
            int result = -99;
            try
            {
                string[] arry;
                arry = value.Split(':');
                result = Int32.Parse(arry[1].ToString());
            }
            catch (Exception ee)
            {

            }
            return result;
        }
    }
} 