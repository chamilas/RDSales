using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDSales_Entities
{
   public class DailyPC
    {
        public int ID { get; set; }
        public DateTime EntryTime { get; set; }
        public string Date { get; set; }
        public int UserID { get; set; }
        public int TerrID { get; set; }
        public int PC { get; set; }
        public int Edited { get; set; }
        public int RegionID { get; set; }
        public int RouteNO { get; set; }
        public int DayNO { get; set; }
        public bool Confirmed { get; set; }
    }
}
