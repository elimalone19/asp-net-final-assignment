using asp_net_fifth_assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using asp_net_fifth_assignment.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace asp_net_fifth_assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository _repository;

        private BookstoreDbContext _context;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository, BookstoreDbContext context)
        {
            _logger = logger;
            _repository = repository;
            _context = context;
        }

        public IActionResult Index(string category = null, int page = 1)
        {
            return View(new BookListViewModel
            {
               // join the tables to get team names
                Bowlers = _context.Bowlers
                    .Join(
                            _context.Teams,
                     
                            bowler => bowler.TeamID,
                            team => team.TeamID,

                            (Bowlers, Teams) => new Bowlers
                            {
                                BowlerID = Bowlers.BowlerID,
                                BowlerLastName = Bowlers.BowlerLastName,
                                BowlerFirstName = Bowlers.BowlerFirstName,
                                BowlerMiddleInit = Bowlers.BowlerMiddleInit,
                                BowlerAddress = Bowlers.BowlerAddress,
                                BowlerCity = Bowlers.BowlerCity,
                                BowlerState = Bowlers.BowlerState,
                                BowlerZip = Bowlers.BowlerZip,
                                BowlerPhoneNumber = Bowlers.BowlerPhoneNumber,
                                TeamName = Teams.TeamName,
                                TeamID = Teams.TeamID

                            }).Where(p => category == null || p.TeamName == category)
                .OrderBy(p => p.BowlerID).Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Bowlers.Count() :
                    _context.Teams.Where (x => x.TeamName == category).Count()
                },
                CurrentCategory = category
            });;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
