using MOVIESHELF.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace MOVIESHELF.Controllers
{
    public class StoreController : Controller
    {
        DATABASE_MOVIESHELFEntities1 storeDb = new DATABASE_MOVIESHELFEntities1();
        
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var id_User = (Session["LogedUserId"]);
            var logedUser = Convert.ToInt32(id_User);

            if ((Session["LogedUserId"])!= null)
            {
                var movieModel = from p in storeDb.Movie_Users
                where p.idUser == logedUser
                select p;
                return View(movieModel);
            }
            ViewBag.loged_user = logedUser;
            return RedirectToAction("Login", "Home");
        }

        // GET: /Store/BrowseByGenre;
        public ActionResult BrowseByGenre(string genre)
        {
           var id_User = (Session["LogedUserId"]);
           var logedUser = Convert.ToInt32(id_User);
            
           // Retrieve Genre and its Associated Movies from database
           var genreModel = storeDb.Genres.Include("Movies_Genres")
           .Single(g => g.Name == genre);
            
            ViewBag.logedUser = logedUser;
            return View(genreModel);
        }

        public ActionResult BrowseByCountry(string country)
        {
            var id_User = (Session["LogedUserId"]);
            var logedUser = Convert.ToInt32(id_User);
            
            // Retrieve Country and its Associated Movies from database
            var countryModel = storeDb.Countries.Include("Movie_Country")
            .Single(c => c.Name == country);

            ViewBag.logedUser = logedUser;
            return View(countryModel);
        }

        public ActionResult BrowseByYear(int year)
        {
            var id_User = (Session["LogedUserId"]);
            var logedUser = Convert.ToInt32(id_User);
            
            // Retrieve Movies by year from database
            var moviesByYear = from p in storeDb.Movies1
                               where p.Year == year
                               select p;

            
            
            var moviesByUserYear = from p in storeDb.Movie_Users
                                   where p.Movies1.Year== year
                                   select p;
            
            List<Movie_Users> moviesHelp = new List <Movie_Users>();
            Movie_Users movieUser= new Movie_Users();

            foreach (var k in moviesByUserYear)
            {
                if (k.idUser == logedUser)
                {moviesHelp.Add(k);}

            }
            
            ViewBag.logedUser = logedUser;
            ViewBag.year = year;
            return View(moviesHelp);
        }

        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            Movies1 movie = storeDb.Movies1.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // GET: /Store/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Store/Edit/5
        public ActionResult Edit(int id)
        {
            Movie_Users movie_user = storeDb.Movie_Users.Find(id);
            return View(movie_user);
        }

        //
        // POST: /Store/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie_Users movie_user, List<string> Storage)
        {
            Movie_Users movieuserHelp = storeDb.Movie_Users.Find(movie_user.IdRelMovie_User);
            if (ModelState.IsValid)
            {
                foreach (var item in movieuserHelp.MovieUser_TypeStorage.ToList())
                {
                    storeDb.MovieUser_TypeStorage.Remove(item);
                }
                movieuserHelp.MovieUser_TypeStorage = new List<MovieUser_TypeStorage>();
                Storage.ForEach(a =>
                {
                    var type_storage = storeDb.TypeStorages.FirstOrDefault(store => store.TypeStorage1 == a);
                    movieuserHelp.MovieUser_TypeStorage.Add(new MovieUser_TypeStorage
                    {
                        TypeStorage = type_storage
                    });
                });

                movieuserHelp.PersonalScore = movie_user.PersonalScore;
                movieuserHelp.Seen = movie_user.Seen;
                movieuserHelp.Favorite = movie_user.Favorite;

                storeDb.SaveChanges();
                storeDb.Entry(movieuserHelp).State = System.Data.Entity.EntityState.Modified;
                storeDb.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(movie_user);
        }

        //
        // GET: /Store/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Movie_Users movie_user = storeDb.Movie_Users.Find(id);
            return View(movie_user);
        }

        //
        // POST: /Store/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
           Movie_Users movie_user = storeDb.Movie_Users.Find(id);
           foreach (var storage in movie_user.MovieUser_TypeStorage.Where( a=> a.idRelMovieUser==id).ToList())
            {
               storeDb.MovieUser_TypeStorage.Remove(storage);
            }
            storeDb.Movie_Users.Remove(movie_user);

            storeDb.SaveChanges();
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var id_User = (Session["LogedUserId"]);
            var logedUser = Convert.ToInt32(id_User);
            var genres = storeDb.Genres.ToList();
            ViewBag.logedUser = logedUser;
            
            return PartialView(genres);
        }

        [ChildActionOnly]
        public ActionResult FiltersMenu()
        {
            return PartialView();
        }

        // GET: /Store/BrowseByCountry
        public ActionResult CountryMenu()
        {
            var id_User = (Session["LogedUserId"]);
            var logedUser = Convert.ToInt32(id_User);
            var countries = storeDb.Countries.ToList();
            ViewBag.logedUser = logedUser;

            return View(countries);
        }

        public ActionResult SearchMovie()
        {
            return View();
        }

        public ActionResult AddMovie(string newTitle)
        {
            ViewBag.storageId = new SelectList(storeDb.TypeStorages, "IdTypeStorage", "TypeStorage1");
            ViewBag.movieTitle = HttpUtility.HtmlEncode(newTitle);
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(Movie_Users _movieUser, string nameDirector, string nameActor, string nameCountry, string nameGenre, List<string> Storage)
        {
            var id_User = (Session["LogedUserId"]);
            var logedUser = Convert.ToInt32(id_User);

           
                if (ModelState.IsValid)
                {

                 var auxMovie = storeDb.Movies1.FirstOrDefault(movie => movie.Title == _movieUser.Movies1.Title);
                 _movieUser.idUser = logedUser;
                if(auxMovie==null)
                  {

                 _movieUser.Movies1.Movie_Director = new List<Movie_Director>();
                nameDirector.Split(',').ToList().ForEach(a =>
                {
                    var director = storeDb.Directors.FirstOrDefault(direc => direc.nameDirector == a.Trim());
                    if(director==null)
                    {
                        director = new Director();
                        director.nameDirector = a.Trim();
                    }
                    _movieUser.Movies1.Movie_Director.Add(new Movie_Director
                    {
                        Director = director
                    });
                });

                _movieUser.Movies1.Movie_Actors = new List<Movie_Actors>();
                nameActor.Split(',').ToList().ForEach(a =>
                {
                    var actor = storeDb.Actors.FirstOrDefault(_actor => _actor.Name == a.Trim());
                    if (actor==null)
                    {
                        actor = new Actor();
                        actor.Name = a.Trim();
                    }
                    _movieUser.Movies1.Movie_Actors.Add(new Movie_Actors
                    {
                        Actor=actor
                    });
                });

                _movieUser.Movies1.Movie_Country = new List<Movie_Country>();
                
                    nameCountry.Split(',').ToList().ForEach(a =>
                {
                    var country = storeDb.Countries.FirstOrDefault(_country => _country.Name == a.Trim());
                    if (country==null)
                    {
                        country = new Country();
                        country.Name = a.Trim();
                    }
                    _movieUser.Movies1.Movie_Country.Add(new Movie_Country
                    {
                         Country = country
                    });
                });

                _movieUser.Movies1.Movies_Genres = new List<Movies_Genres>();
                nameGenre.Split(',').ToList().ForEach(a =>
                {
                    var genre = storeDb.Genres.FirstOrDefault(_country => _country.Name == a.Trim());
                    if (genre == null)
                    {
                        genre = new Genre();
                        genre.Name = a.Trim();
                    }
                    _movieUser.Movies1.Movies_Genres.Add(new Movies_Genres
                    {
                        Genre= genre
                    });
                });
                  }
                _movieUser.MovieUser_TypeStorage = new List<MovieUser_TypeStorage>();
                Storage.ForEach(a =>{
                    var type_storage = storeDb.TypeStorages.FirstOrDefault(store => store.TypeStorage1 == a);
                    _movieUser.MovieUser_TypeStorage.Add(new MovieUser_TypeStorage
                    {
                        TypeStorage=type_storage
                    });
                });
                
                storeDb.Movie_Users.Add(_movieUser);
                try { 
                storeDb.SaveChanges();
                    }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return RedirectToAction("Index");
                
               
        };
            ViewBag.storageId = new SelectList(storeDb.TypeStorages, "IdTypeStorage", "TypeStorage1");
            return View();
        }
    }
}