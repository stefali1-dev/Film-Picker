
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
}

public class FavoriteGenre
{
    public int Id { get; set; }
    public AppUser User { get; set; }
    public int UserId { get; set; }
    public int GenreId { get; set; }
}

public class FavoriteMovie
{
    public int Id { get; set; }
    public AppUser User { get; set; }

    public int UserId { get; set; }
    public int MovieId { get; set; }
}