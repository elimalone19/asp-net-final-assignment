using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_net_fifth_assignment.Models
{
    public class EfBookstoreRepository: IBookstoreRepository
    {
        private BookstoreDbContext _context;

        public EfBookstoreRepository (BookstoreDbContext context)
        {
            _context = context;
        }


 
        public IQueryable<Bowlers> Bowlers => _context.Bowlers;
    }
}
