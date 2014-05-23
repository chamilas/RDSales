using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using RDSales_Entities;
using RDSales_Entity_Handler;

namespace RDSales_Management_System
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {
        
        //get product code and names from RD Sales database
        [WebMethod]
        public string[] GetBasicProdctListOfRDsales(string prefixText)
        {

            DataTable dt = ProductHandler.SPGET_RD_BasicProdctsbyPrefix(prefixText);
            List<string> items = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i][1].ToString() + ":" + dt.Rows[i][0].ToString();
                items.Add(strName);
            }
            return items.ToArray();
        }



        [WebMethod]
        public string[] GetDirectSalesCustomers(string prefixText)
        {

            DataTable dt = CustomerHandler.SPGET_DS_CustomersbyPrefix(prefixText);
            List<string> items = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i][1].ToString() + ":" + dt.Rows[i][0].ToString();
                items.Add(strName);
            }
            return items.ToArray();
        }
    }
}
