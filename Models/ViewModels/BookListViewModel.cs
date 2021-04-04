using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_fifth_assignment.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Bowlers> Bowlers { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public  int CurrentCategory { get; set; }
    }
}
