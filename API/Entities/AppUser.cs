
using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    
    public List<FavoriteGenre> FavoriteGenres { get; set; }
    public List<FavoriteMovie> FavoriteMovies { get; set; }
    
    public List<int> GetFavoriteGenresIds()
    {
        return FavoriteGenres.Select(fg => fg.GenreId).ToList();
    }
    
    public List<int> GetFavoriteMoviesIds()
    {
        return FavoriteMovies.Select(fm => fm.MovieId).ToList();
    }
}