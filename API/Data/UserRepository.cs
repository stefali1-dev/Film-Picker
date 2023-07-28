using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    private readonly ITmdbApiService _tmdbApiService;

    public UserRepository(DataContext context, ITmdbApiService tmdbApiService)
    {
        _context = context;
        _tmdbApiService = tmdbApiService;
    }

    public void Update(AppUser user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _context.Users
            .Include(x => x.FavoriteGenres)
            .Include(x => x.FavoriteMovies)
            .ToListAsync();
    }

    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        var user = await _context.Users
            .Include(x => x.FavoriteGenres)
            .Include(x => x.FavoriteMovies)
            .SingleOrDefaultAsync(x => x.Id == id);
        return user;
    }

    public async Task<AppUser> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users
            .Include(x => x.FavoriteGenres)
            .Include(x => x.FavoriteMovies)
            .SingleOrDefaultAsync(x => x.Email == email);
        return user;
    }

    public async Task<IEnumerable<MovieDto>> GetRecommendedMoviesAsync(int id)
    {
        var user = await GetUserByIdAsync(id);
        
        //var favoriteGenresIds = user.FavoriteGenres.Select(x => x.Id).ToList();
        var favoriteMoviesIds = user.FavoriteMovies.Select(x => x.MovieId).ToList();
        List<MovieDto> recommendedMoviesList = new List<MovieDto>();
        // iterate through favoriteGenresIds
        foreach (var movieId in favoriteMoviesIds)
        {
            IEnumerable<MovieDto> movieList = await _tmdbApiService.GetRecommendedMoviesAsync(movieId, favoriteMoviesIds);
            recommendedMoviesList.AddRange(movieList);
        }

        return recommendedMoviesList;
    }
}