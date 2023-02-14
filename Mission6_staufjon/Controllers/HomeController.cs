using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6_staufjon.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_staufjon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext MovieFileContext { get; set; }
        //constructor
        public HomeController(ILogger<HomeController> logger, MovieContext rg)
        {
            _logger = logger;
            MovieFileContext = rg ?? throw new ArgumentNullException(nameof(rg));
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movie()
        {
            return View("Movie");
        }
        [HttpPost]
        public IActionResult Movie(MovieCollection mc)
        {

            if (ModelState.IsValid)
            {
                MovieFileContext.Add(mc);
                MovieFileContext.SaveChanges();
                return View("confirmation", mc);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Podcast()
        {
            return View("MyPodcast");
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
