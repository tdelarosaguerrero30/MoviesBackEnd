using MyMovie.Library.Models;
using MyMovie.Library.Models.DTO;
using MyMovie.Library.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovie.Library.Repositries
{
    public interface IMovieRepository
    {
        void AddMovie(Movie model);
        void AddReviewMovie(ReviewAddDTO model);
        Movie GetMovie(int id);
        IEnumerable<Review> GetMovieRiviews(int movieId);
        void DisableAMovie(int id);
        IEnumerable<Movie> GetMovies(MovieParameters movieParameters);
    }
}
