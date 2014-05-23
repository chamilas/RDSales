using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDSales_Entities
{
   public class DailySales
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public int UserID { get; set; }
        public int TerrID { get; set; }
        public int RegionID { get; set; }
        public int RouteNO { get; set; }
        public int DayNO { get; set; }
        public bool Confirmed { get; set; }
        public int PC_All { get; set; }

        public List<string> prodcode { get; set; }
        public List<decimal> Acheivement { get; set; }
        public List<int> PC { get; set; }
        public List<int> PC_Fresh { get; set; }
        
 
    }
}
