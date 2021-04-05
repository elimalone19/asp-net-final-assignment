using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace asp_net_fifth_assignment.Models
{
    public class Teams
    {
        [Key]
        public int TeamID { get; set; }

        public string TeamName { get; set; }

        public int CaptainID { get; set; }


    }
}
