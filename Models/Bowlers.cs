using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


// model for the bowlers

namespace asp_net_fifth_assignment.Models
{
    public class Bowlers
    {
        [Key]
        public int BowlerID { get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerFirstName { get; set; }
        public string BowlerLastName { get; set; }
        public string BowlerMiddleInit { get; set; }
        public string BowlerCity { get; set; }
        public int TeamID { get; set; }
        public string BowlerState { get; set; }
        public string BowlerZip { get; set;  }
        public string BowlerPhoneNumber { get; set; }

    }
}
