using Microsoft.EntityFrameworkCore;
using MyMovie.Library.DataBase;
using MyMovie.Library.Models;
using MyMovie.Library.Models.DTO;
using MyMovie.Library.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovie.Library.Repositries
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _db;
        public MovieRepository(MovieDbContext movieDbContext)
        {
            _db = movieDbContext;
        }

        public void AddMovie(Movie model)
        {
            if (_db.Movies.Any(x => x.Title == model.Title))
            {
                throw new Exception("This title already exist");
            }
            _db.Movies.Add(model);
            _db.SaveChanges();
        }

        public void AddReviewMovie(ReviewAddDTO model)
        {
            int movieId = 0;
            if (!_db.Movies.Any(x => x.Title.Equals(model.MovieTitle)))
            {
                throw new Exception("This title not exist");
            }
            movieId = _db.Movies.FirstOrDefault(x => x.Title.Equals(model.MovieTitle)).Id;
            Review review = new Review
            {
                CreatedDate = DateTime.Now,
                Comment = model.Comment,
                MovieId = movieId,
                Starts = model.Starts,
                User = model.User
            };
            _db.Reviews.Add(review);
            _db.SaveChanges();
        }

        public void DisableAMovie(int id)
        {
            var movie = _db.Movies.Find(id);
            movie.IsActive = false;
            _db.SaveChanges();
        }

        public Movie GetMovie(int id)
        {
            return _db.Movies.Find(id);
        }

        public IEnumerable<Review> GetMovieRiviews(int movieId)
        {
            return _db.Reviews.Where(e => e.MovieId == movieId);
        }

        public IEnumerable<Movie> GetMovies(MovieParameters movieParameters)
        {
            return _db.Movies.Include("Reviews").Where(e => e.Title.Contains(movieParameters.Title) || string.IsNullOrEmpty(movieParameters.Title))
          .OrderBy(on => on.Title)
         .Skip((movieParameters.PageNumber - 1) * movieParameters.PageSize)
         .Take(movieParameters.PageSize)
         .ToList();
        }
    }
}
