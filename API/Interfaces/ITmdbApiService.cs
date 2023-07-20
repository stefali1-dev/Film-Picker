using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces;

public interface ITmdbApiService
{
    Task<ActionResult<IEnumerable<MovieDto>>> SearchMovieAsync(string movieName);
}