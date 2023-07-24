using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper =  mapper;
    } 
    
    [HttpGet] // GET: api/users
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetUsersAsync();
        
        var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
        
        return Ok(usersToReturn);
    }
    
    [HttpGet("{email}")] // GET: api/users/5
    public async Task<ActionResult<MemberDto>> GetUser(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);

        return _mapper.Map<MemberDto>(user);
    }

    [HttpPut("{email}/tastes")] // PUT: api/users/5/tastes
    public async Task<ActionResult> UpdateTastes(TastesDto tastesDto, string email)
    {
        try
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null)
            {
                return NotFound(); // Or return any appropriate status code indicating the user was not found
            }

            var userId = user.Id;

            // Update the favorite genres of the user
            var favoriteGenresToAdd = user.GetFavoriteGenresIds().Select(genreId => new FavoriteGenre
            {
                UserId = userId,
                GenreId = genreId
            });

            user.FavoriteGenres.AddRange(favoriteGenresToAdd);

            // Update the favorite movies of the user
            var favoriteMoviesIds = tastesDto.FavoriteMoviesIds;
            var favoriteMoviesToAdd = favoriteMoviesIds.Select(movieId => new FavoriteMovie
            {
                UserId = userId,
                MovieId = movieId
            });

            user.FavoriteMovies.AddRange(favoriteMoviesToAdd);

            // Save the changes to the database using the userRepository instead of _context
            await _userRepository.SaveAllAsync();
            return Ok();
        }

        catch (DbUpdateException ex)
        {
            // Check if the inner exception is a SqliteException with error code 19 (UNIQUE constraint violation)
            if (ex.InnerException is SqliteException sqliteException && sqliteException.SqliteErrorCode == 19)
            {
                // Handle the UNIQUE constraint violation here
                // For example, you can return a BadRequest with a specific error message
                return BadRequest("Duplicate entry detected. You have already added this genre or movie to your favorites.");
            }
            else
            {
                // Handle other types of DbUpdateException or rethrow the exception if needed
                throw;
            }
        }
    }

}