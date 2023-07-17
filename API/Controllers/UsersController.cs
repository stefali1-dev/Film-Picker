using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
        _context = context;
    } 
    
    [AllowAnonymous]
    [HttpGet] // GET: api/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    
    [HttpGet("{id}")] // GET: api/users/5
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
    
    [HttpGet("{id}/genres")] // GET: api/users/5/genres
    public async Task<ActionResult<IEnumerable<int>>> GetUserGenres(int id)
    {
        IEnumerable<FavoriteGenre> favoriteGenres =
            await _context.UserFavoriteGenres.Where(x => x.UserId == id).ToListAsync();
        
        // retrieve the list of genre ids
        return favoriteGenres.Select(genre => genre.GenreId).ToList();
    }
    
    [HttpGet("{id}/movies")] // GET: api/users/5/movies
    public async Task<ActionResult<IEnumerable<int>>> GetUserMovies(int id)
    {
        IEnumerable<FavoriteMovie> favoriteMovies =
            await _context.UserFavoriteMovies.Where(x => x.UserId == id).ToListAsync();
        
        // retrieve the list of movie ids
        return favoriteMovies.Select(genre => genre.MovieId).ToList();
    }
        
}