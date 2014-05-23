﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;

namespace RDSales_Entity_Handler
{
   public class Alert
    {
       public static void Show(string message)
       {
           // Cleans the message to allow single quotation marks 
           string cleanMessage = message.Replace("'", "\\'");
           string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";

           // Gets the executing web page 
           Page page = HttpContext.Current.CurrentHandler as Page;

           // Checks if the handler is a Page and that the script isn't allready on the Page 
           if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
           {
               page.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", script);
           }
       }    
    }
}
