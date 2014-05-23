using System;
using System.Web.UI;
using RDSales_Entity_Handler;
using System.Data;

namespace RDSales_Management_System
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //HandleDBF();
                       
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RDSales_Data.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RDSales_Data.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RDSales_Data.aspx");
        }

        private int HandleInt(string obj)
        {
            int num = 0;
            try
            {
                num = Int32.Parse(obj);

            }
            catch (Exception)
            {
                num = 0;
            }
            return num;
        }

        private float HandleFloat(string obj)
        {
            float num = 0;
            try
            {
                num = float.Parse(obj);

            }
            catch (Exception)
            {
                num = 0;
            }
            return num;
        }


        private void HandleDBF()
        {

            try
            {
           

                #region Read DBF files

                DataTable prosock = DBFReaderHandler.ReadData_PROSTOCK();
                DataTable sanv = DBFReaderHandler.ReadData_SAINV(DateTime.Parse("5/15/2003"));
                DataTable sanvb = new DataTable();
                sanvb.Clear();

                foreach (DataRow row in sanv.Rows)
                {
                    DataTable dt = DBFReaderHandler.ReadData_SAINVSB(row["REFNO"].ToString());
                    sanvb.Merge(dt);
                }


               #region Sort after data is read

                //string statOfMonth = DateTime.Parse("2/16/2006").ToString();
                //string endofMonth = DateTime.Parse("2/20/2006").ToString();

               //string statOfMonth = DBFReaderHandler.getStartdateofMonth(System.DateTime.Today);
               //string endofMonth = DBFReaderHandler.getEnddateofMonth(System.DateTime.Today);

               //DataTable dt = DBFReaderHandler.ReadData_PROSTOCK();
               
               //DataRow[] array;
               //array = sanv.Select("RDATE >= '" + statOfMonth + "' AND RDATE <= '" + endofMonth + "'");

               //DataTable dt_filter = sanv.Clone();


               //foreach (DataRow row in array)
               //{
                  
               //    dt_filter.ImportRow(row);
               //}

             


               #endregion

                
                GridView1.DataSource = sanvb;
                GridView1.DataBind();

                #endregion


                //#region Sendinf to sql server
                ////PRSTOCK
                //int count = 0;

                ////foreach (DataRow row in prosock.Rows)
                ////{

                ////    bool stat = DBFReaderHandler.SPADD_PROSTOCK(row["ITCODE"].ToString(), row["PACK_TYPE"].ToString(), row["PACK_SIZE"].ToString(), row["UNIT"].ToString(), row["LOC_CODE"].ToString(), HandleFloat(row["OLD_COST"].ToString()), HandleFloat(row["CUR_COST"].ToString()), HandleFloat(row["PRE_COST"].ToString()), HandleFloat(row["COST"].ToString()), HandleFloat(row["DCOST"].ToString()), row["CST_DATE"].ToString(), HandleInt(row["QTY_BAL"].ToString()), HandleInt(row["DQTY_BAL"].ToString()), HandleInt(row["QTY_VAN"].ToString()), HandleInt(row["DQTY_VAN"].ToString()), HandleInt(row["QTY_RESVD"].ToString()), HandleFloat(row["PRICE"].ToString()), HandleFloat(row["PRE_PRICE"].ToString()), HandleFloat(row["FRI_PRICE"].ToString()), row["PRI_DATE"].ToString(), HandleInt(row["REO_LEVEL"].ToString()), HandleInt(row["MIN_ST"].ToString()), HandleInt(row["MAX_ST"].ToString()), row["REM"].ToString(), HandleFloat(row["RATE_A"].ToString()), HandleFloat(row["RATE_N"].ToString()), HandleFloat(row["RATE_S"].ToString()));

                ////    if (stat)
                ////    {
                ////        count++;
                ////    }
                ////}

                ////if (count < prosock.Rows.Count)
                ////{
                ////    Alert.Show("Error occured! " + count + " out of " + prosock.Rows.Count + " Updated");
                ////}
                ////else
                ////{
                ////    Alert.Show("Success! " + count + " out of " + prosock.Rows.Count + " Updated");
                ////}


                ////SAINV
                //int count_2 = 0;
                //foreach (DataRow row in sanv.Rows)
                //{

                //    bool stat = DBFReaderHandler.SPADD_SAINV(row["REFNO"].ToString(), row["PRE_INVNO"].ToString(), row["SALTYP"].ToString(), row["ARCODE"].ToString(), row["SLTYPE"].ToString(), row["SAL_REFNO"].ToString(), row["DEPCODE"].ToString(), row["RTNCODE"].ToString(), row["ORDNO"].ToString(), row["CUSCODE"].ToString(), row["LOCODE"].ToString(), row["PAYTYP"].ToString(), row["REPCODE"].ToString(), row["REPCODE_OR"].ToString(), row["DISTYP"].ToString(), row["RDATE"].ToString(), HandleFloat(row["TOT_AMT"].ToString()), HandleFloat(row["TOT_PAY"].ToString()), HandleFloat(row["DIS_AMT"].ToString()), HandleFloat(row["ADIS_AMT"].ToString()), HandleFloat(row["UN_CHEQE"].ToString()), row["DELFLG"].ToString(), row["TYPFLG"].ToString(), row["RTNTYP"].ToString(), row["USID"].ToString(), row["REM"].ToString(), row["FLFLG"].ToString(), row["D_USID"].ToString(), row["D_DATE"].ToString(), row["VATPAY"].ToString(), HandleFloat(row["VATRATE"].ToString()), HandleFloat(row["VAT_AMT"].ToString()), HandleFloat(row["NBTRATE"].ToString()), HandleFloat(row["NBT_AMT"].ToString()));


                //    if (stat)
                //    {
                //        count_2++;
                //    }
                //}

                //if (count_2 < sanv.Rows.Count)
                //{
                //    //Alert.Show("Error occured! " + count_2 + " out of " + sanv.Rows.Count + " Updated");

                //    Label1.ForeColor = System.Drawing.Color.Red;
                //    Label1.Text = "Error occured! " + count_2 + " out of " + sanv.Rows.Count + " Updated";
                //}
                //else
                //{
                //    //Alert.Show("Success! " + count_2 + " out of " + sanv.Rows.Count + " Updated");

                //    Label1.ForeColor = System.Drawing.Color.Green;
                //    Label1.Text = "Success! " + count_2 + " out of " + sanv.Rows.Count + " Updated";
                //}


                ////SAINVSB

                //int count_3 = 0;
                //foreach (DataRow row in sanvb.Rows)
                //{

                //    bool stat = DBFReaderHandler.SPADD_SAINVSB(row["REFNO"].ToString(), row["ITCODE"].ToString(), HandleFloat(row["PRICE"].ToString()), HandleFloat(row["COST"].ToString()), HandleFloat(row["FRI_PRICE"].ToString()), HandleInt(row["QTY"].ToString()), HandleInt(row["BAL_QTY"].ToString()), row["FLFLG"].ToString(), row["DELFLG"].ToString(), row["PAYTYP"].ToString(), row["SALTYP"].ToString(), row["TYPFLG"].ToString());
                //    if (stat)
                //    {
                //        count_3++;
                //    }
                //}

                //if (count_3 < sanvb.Rows.Count)
                //{
                //    //Alert.Show("Error occured! " + count_3 + " out of " + sanvb.Rows.Count + " Updated");

                //    Label2.ForeColor = System.Drawing.Color.Red;
                //    Label2.Text = "Error occured! " + count_3 + " out of " + sanvb.Rows.Count + " Updated";
                //}
                //else
                //{
                //    //Alert.Show("Success! " + count_3 + " out of " + sanvb.Rows.Count + " Updated");

                //    Label2.ForeColor = System.Drawing.Color.Red;
                //    Label2.Text = "Success! " + count_3 + " out of " + sanvb.Rows.Count + " Updated";
                //}


                //#endregion
               

            
            }
            catch (Exception)
            {
                
                
            }



 
        }
    }
}