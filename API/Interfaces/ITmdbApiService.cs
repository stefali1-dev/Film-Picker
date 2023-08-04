using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces;

public interface ITmdbApiService
{
    Task<ActionResult<IEnumerable<MovieDto>>> SearchMovieAsync(string movieName);
    Task<IEnumerable<MovieDto>> GetRecommendedMoviesAsync(int movieId, List<int> favoriteMovieIds);
    Task<ActionResult<MovieDto>> GetMovieDetailsAsync(int movieId);
}