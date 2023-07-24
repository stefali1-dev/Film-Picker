using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    } 
    
    [HttpGet] // GET: api/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return Ok(await _userRepository.GetUsersAsync());
    }
    
    [HttpGet("{email}")] // GET: api/users/5
    public async Task<ActionResult<AppUser>> GetUser(string email)
    {
        return await _userRepository.GetUserByEmailAsync(email);
    }
    //
    // [HttpGet("{id}/genres")] // GET: api/users/5/genres
    // public async Task<ActionResult<IEnumerable<int>>> GetUserGenres(int id)
    // {
    //     IEnumerable<FavoriteGenre> favoriteGenres =
    //         await _context.UserFavoriteGenres.Where(x => x.UserId == id).ToListAsync();
    //     
    //     // retrieve the list of genre ids
    //     return favoriteGenres.Select(genre => genre.GenreId).ToList();
    // }
    //
    // [HttpGet("{id}/movies")] // GET: api/users/5/movies
    // public async Task<ActionResult<IEnumerable<int>>> GetUserMovies(int id)
    // {
    //     IEnumerable<FavoriteMovie> favoriteMovies =
    //         await _context.UserFavoriteMovies.Where(x => x.UserId == id).ToListAsync();
    //     
    //     // retrieve the list of movie ids
    //     return favoriteMovies.Select(genre => genre.MovieId).ToList();
    // }
    //
    // [HttpPut("{id}/tastes")] // PUT: api/users/5/tastes
    // public async Task<ActionResult> UpdateTastes(TastesDto tastesDto, int id)
    // {
    //     int userId = id;
    //     List<int> favoriteGenresIds = tastesDto.FavoriteGenresIds;
    //     List<int> favoriteMoviesIds = tastesDto.FavoriteMoviesIds;
    //
    //     try
    //     {
    //         // Fetch the user from the database based on the given userId
    //         var user = await _context.Users.FindAsync(userId);
    //
    //         if (user == null)
    //         {
    //             return NotFound(); // Or return any appropriate status code indicating the user was not found
    //         }
    //
    //         // Update the favorite genres of the user
    //         var favoriteGenresToAdd = favoriteGenresIds.Select(genreId => new FavoriteGenre
    //         {
    //             UserId = userId,
    //             GenreId = genreId
    //         });
    //
    //         _context.UserFavoriteGenres.AddRange(favoriteGenresToAdd);
    //
    //         // Update the favorite movies of the user
    //         var favoriteMoviesToAdd = favoriteMoviesIds.Select(movieId => new FavoriteMovie
    //         {
    //             UserId = userId,
    //             MovieId = movieId
    //         });
    //
    //         _context.UserFavoriteMovies.AddRange(favoriteMoviesToAdd);
    //
    //         // Save the changes to the database
    //         await _context.SaveChangesAsync();
    //
    //         return Ok();
    //     }
    //     
    //     catch (DbUpdateException ex)
    //     {
    //         // Check if the inner exception is a SqliteException with error code 19 (UNIQUE constraint violation)
    //         if (ex.InnerException is SqliteException sqliteException && sqliteException.SqliteErrorCode == 19)
    //         {
    //             // Handle the UNIQUE constraint violation here
    //             // For example, you can return a BadRequest with a specific error message
    //             return BadRequest("Duplicate entry detected. You have already added this genre or movie to your favorites.");
    //         }
    //         else
    //         {
    //             // Handle other types of DbUpdateException or rethrow the exception if needed
    //             throw;
    //         }
    //     }
    // }


    

}