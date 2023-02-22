using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieContext MovieFileContext { get; set; }
        //constructor
        public HomeController(MovieContext rg)
        {
            MovieFileContext = rg;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movie()
        {
            ViewBag.Categories = MovieFileContext.Categories.ToList();
            return View();
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
                ViewBag.Categories = MovieFileContext.Categories.ToList();
                return View();
            }
        }
        //get the movie list
        public IActionResult MovieList()
        {
            // var entries = MovieFileContext.Responses.Where(x => x.Title == "name")
            // .orderby(x => x.Category)
            // .ToList();
            var entries = MovieFileContext.responses.Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(entries);
        }
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = MovieFileContext.Categories.ToList();
            var entry = MovieFileContext.responses.Single(x => x.MovieId == movieid);
            return View("Movie", entry);
        }
        [HttpPost]
        public IActionResult Edit(MovieCollection update)
        {
            MovieFileContext.Update(update);
            MovieFileContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var entry = MovieFileContext.responses.Single(x => x.MovieId == movieid);

            return View(entry);
        }
        [HttpPost]
        public IActionResult Delete(MovieCollection mc)
        {
            MovieFileContext.responses.Remove(mc);
            MovieFileContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        public IActionResult Podcast()
        {
            return View("MyPodcast");
        }

    }
}
