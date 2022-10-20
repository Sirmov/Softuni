namespace Watchlist.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using Watchlist.Data;
    using Watchlist.Data.Entities;
    using Watchlist.Models;

    public class MoviesController : Controller
    {
        private readonly WatchlistDbContext dbContext;
        private readonly UserManager<User> userManager;

        public MoviesController(WatchlistDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> All()
        {
            var movies = await this.dbContext.Movies
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating.ToString("0.00"),
                    Genre = m.Genre.Name
                })
                .ToListAsync();

            return View(movies);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            var model = new MovieInputModel()
            {
                Genres = await this.dbContext.Genres.ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(MovieInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId
            };

            try
            {
                await this.dbContext.AddAsync(movie);
                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", "Operation was not successful.");
                model.Genres = await this.dbContext.Genres.ToListAsync();
                return View(model);
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            var userId = this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await this.dbContext.Users
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User cannot be found.");
            }

            var movie = await this.dbContext.Movies.FindAsync(movieId);

            if (movie == null)
            {
                throw new ArgumentException("Movie cannot be found");
            }

            var userMovie = new UserMovie()
            {
                UserId = userId,
                MovieId = movieId
            };

            try
            {
                if (!user.UsersMovies.Any(um => um.MovieId == movieId))
                {
                    await this.dbContext.AddAsync(userMovie);
                    await this.dbContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Error occurred while adding entity.");
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            var userId = this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await this.dbContext.Users
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("User cannot be found.");
            }

            var movie = await this.dbContext.Movies.FindAsync(movieId);

            if (movie == null)
            {
                throw new ArgumentException("Movie cannot be found");
            }

            var userMovie = user.UsersMovies.Where(um => um.MovieId == movieId).FirstOrDefault();

            if (userMovie != null)
            {
                this.dbContext.Remove(userMovie);
                await this.dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Watched));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Watched()
        {
            var userId = this.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            // First Variant
            //var user = await this.dbContext.Users
            //    .Include(u => u.UsersMovies)
            //    .ThenInclude(um => um.Movie)
            //    .FirstOrDefaultAsync(u => u.Id == userId);

            //if (user == null)
            //{
            //    throw new ArgumentException("User cannot be found.");
            //}

            //var movies = user.UsersMovies
            //    .Select(um => new MovieViewModel()
            //    {
            //        Id = um.Movie.Id,
            //        Title = um.Movie.Title,
            //        Director = um.Movie.Director,
            //        ImageUrl = um.Movie.ImageUrl,
            //        Rating = um.Movie.Rating.ToString("0.00"),
            //        Genre = um.Movie.Genre.Name
            //    });

            // Second Variant
            var movies = await this.dbContext.Movies
                .Include(m => m.UsersMovies)
                .Where(m => m.UsersMovies.Any(um => um.UserId == userId))
                .Select(m => new MovieViewModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating.ToString("0.00"),
                    Genre = m.Genre.Name
                })
                .ToListAsync();

            return View(movies);
        }
    }
}
