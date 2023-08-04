using System.Text.Json;
using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace API.Controllers;
[Authorize]
public class MovieController : BaseApiController
{
    // _context
    private readonly DataContext _context;
    private readonly ITmdbApiService _tmdbApiService;
    
    public MovieController(DataContext context, ITmdbApiService tmdbApiService)
    {
        _context = context;
        _tmdbApiService = tmdbApiService;
    }
    
    [AllowAnonymous]
    [HttpGet("search/{movieName}")] // GET: api/movie/search/{movieName}
    public async Task<ActionResult<IEnumerable<MovieDto>>> Search(string movieName)
    {
        return await _tmdbApiService.SearchMovieAsync(movieName);
    }
    
    [AllowAnonymous]
    [HttpGet("{movieId}")] // GET: api/movie/{movieId}
    public async Task<ActionResult<MovieDto>> GetMovie(int movieId)
    {
        return await _tmdbApiService.GetMovieDetailsAsync(movieId);
    }
    
}
