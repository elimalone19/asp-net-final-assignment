using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_fifth_assignment.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Bowlers> Bowlers { get; }
    }
}
