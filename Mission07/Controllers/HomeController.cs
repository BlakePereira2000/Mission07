using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission07.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission07.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _MovieContext { get; set; }

        public HomeController(MovieContext x)
        {
            _MovieContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.categories = _MovieContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Movies(Movie hcm)
        {
            if(ModelState.IsValid)
            {
                _MovieContext.Add(hcm);
                _MovieContext.SaveChanges();

                return View("Confirmation", hcm);
            }
            else
            {
                ViewBag.categories = _MovieContext.Categories.ToList();

                return View();
            }

        }
        public IActionResult WaitList()
        {
            var MovieList = _MovieContext.Movies.Include(x => x.category).OrderBy(x=> x.director).ToList();

            return View(MovieList);
        }
        [HttpGet]
        public IActionResult Edit(int MovieId)
        {
            ViewBag.categories = _MovieContext.Categories.ToList();

            var movie = _MovieContext.Movies.Single(x => x.MovieId == MovieId);

            return View("Movies", movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie Blah)
        {
            _MovieContext.Update(Blah);
            _MovieContext.SaveChanges();

            return RedirectToAction("WaitList");
        }
        [HttpGet]
        public IActionResult Delete(int MovieId)
        {
            var movie = _MovieContext.Movies.Single(x => x.MovieId == MovieId);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Movie ar)
        {
            _MovieContext.Movies.Remove(ar);
            _MovieContext.SaveChanges();

            return RedirectToAction("WaitList");
        }

    }
}
