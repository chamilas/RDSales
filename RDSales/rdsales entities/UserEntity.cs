using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDSales_Entities
{
   public class UserEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int EPF { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public int Role { get; set; }
    }
}
