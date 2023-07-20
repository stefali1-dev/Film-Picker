using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }
    
    [HttpPost("register")] // POST: api/account/register
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Email))
        {
            return BadRequest("Email is taken");
        }
        
        using var hmac = new HMACSHA512();
        
        var user = new AppUser
        {
            Email = registerDto.Email.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };
        
        user.FavoriteGenres = new List<FavoriteGenre>();
        foreach (var genreId in registerDto.FavoriteGenresIds)
        {
            user.FavoriteGenres.Add(new FavoriteGenre
            {
                User = user,
                UserId = user.Id,
                GenreId = genreId
            });
        }
        
        user.FavoriteMovies = new List<FavoriteMovie>();
        foreach (var movieId in registerDto.FavoriteMoviesIds)
        {
            user.FavoriteMovies.Add(new FavoriteMovie
            {
                User = user,
                UserId = user.Id,
                MovieId = movieId
            });
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDto
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        };
    }
    
    [HttpPost("login")] // POST: api/account/login
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == loginDto.Email);

        if (user == null)
        {
            return Unauthorized("Invalid Email");
        }

        using var hmac = new HMACSHA512(user.PasswordSalt);

        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (var i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i])
            {
                return Unauthorized("Invalid password");
            }
        }

        return new UserDto
        {
            Email = user.Email,
            UserId = user.Id,
            Token = _tokenService.CreateToken(user)
        };
    }
    
    private async Task<bool> UserExists(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email == email.ToLower());
    }
}