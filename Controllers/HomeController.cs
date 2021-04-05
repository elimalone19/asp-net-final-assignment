using asp_net_fifth_assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using asp_net_fifth_assignment.Models.ViewModels;

namespace asp_net_fifth_assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookstoreRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(int category = 0, int page = 1)
        {
            return View(new BookListViewModel
            {
                Bowlers = _repository.Bowlers
                .Where(p => category == 0 || p.TeamID == category)
                .OrderBy(p => p.BowlerID).Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == 0 ? _repository.Bowlers.Count() :
                    _repository.Bowlers.Where (x => x.TeamID == category).Count()
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
