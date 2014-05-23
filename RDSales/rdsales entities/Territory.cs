using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDSales_Entities
{
   public class Territory
    {
        public int TerritoryID { get; set; }
        public string TerritoryName { get; set; }
        public int Region { get; set; }
        public int Distributor { get; set; }
    }
}
