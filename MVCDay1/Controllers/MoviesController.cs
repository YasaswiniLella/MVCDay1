using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDay1.Models;
using System.Data.Entity;
using MVCDay1.ViewModel;

namespace MVCDay1.Controllers
{
    [RoutePrefix("Movies")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if(dbContext!=null)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: Movies
        public ActionResult Index()
        {
            //return Content("Content from Movies Controller");
            List<Movie> movies = GetMovies();
            return View(movies);
        }
        //public ActionResult GetMoviebyId(int movieId)
        //{
        //    return Content("Getting Movie by Id:" + movieId);
        //}
        //[Route("Search_Movie/{name?}/{releaseDate?}")]
        //public ActionResult SearchMovie(string name,DateTime? releaseDate)
        //{
        //    if(string.IsNullOrEmpty(name))
        //    {
        //        name = "Default";
        //    }
        //    if(!releaseDate.HasValue)
        //    {
        //        releaseDate = DateTime.Now;
        //    }
        //    return Content($"Movie Name:{name} Release Date:{releaseDate.Value}");
        //}
        //[Route("SearchMovie/{id}")]
        //public ActionResult Search_Movie(int id)
        //{
        //    return Content("Searching Movie by Id:" + id);
        //}
        [HttpGet]
        public ActionResult Details(int id)
        {
            //var movie = GetMovies().FirstOrDefault(x => x.Id == id);
            var movie = dbContext.movies.Include(m => m.Genre).FirstOrDefault(x => x.Id == id);
            return View(movie);

        }
        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.GenreId = GetGenreNames();
            var viewModel = new MovieViewModel
            {
                Movie = new Movie(),
                GetGenres = dbContext.Genres.ToList(),
            };
            return View("CreateNew",viewModel);
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                //ViewBag.GenreId = GetGenreNames();
                var viewModel = new MovieViewModel
                {
                    Movie =movie,
                    GetGenres = dbContext.Genres.ToList(),
                };
                return View("CreateNew", viewModel);
            }
            dbContext.movies.Add(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Test()
        {
            object Name = "Yasaswini";
            return View(Name);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = dbContext.movies.SingleOrDefault(x => x.Id == id);
            if(movie!=null)
            {
                var viewModel = new MovieViewModel
                {
                    Movie = movie,
                    GetGenres = dbContext.Genres.ToList()
                };
                return View(viewModel);
            }
            return HttpNotFound("Movie Id not exist");
        }
        [HttpPost]
        public ActionResult Edit(int id,Movie movie)
        {
            var movieInDb = dbContext.movies.SingleOrDefault(x => x.Id == id);
            if(movieInDb!=null)
            {
                movieInDb.Name = movie.Name;
                movieInDb.DirectorName = movie.DirectorName;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var movie = dbContext.movies.SingleOrDefault(m => m.Id == id);
            if(movie!=null)
            {
                dbContext.movies.Remove(movie);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            return HttpNotFound();
        }

        [NonAction]
        public List<Movie> GetMovies()
        {
            return dbContext.movies.ToList();

        }
        [NonAction]
        public IEnumerable<SelectListItem>GetGenreNames()
        {
            var genres = dbContext.Genres.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.GenreName,
                Value = x.Id.ToString()
            });
            return genres;

        }


    }
}