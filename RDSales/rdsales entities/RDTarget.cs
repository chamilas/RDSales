using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDSales_Entities
{
   public class RDTarget
    {
        public int ID { get; set; }
        public DateTime EntryTime { get; set; }
        public string Date { get; set; }
        public int TerrID { get; set; }
        public string prodcode { get; set; }
        public decimal Target { get; set; }
        public int UserId { get; set; }
        public bool confirmed { get; set; }
    }
}
