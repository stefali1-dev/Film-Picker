using API.DTOs;

namespace API.Entities;

public class AppUser
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    
    public ICollection<Genre> FavoriteGenresIds  { get; set; }
    public ICollection<Movie> FavoriteMoviesIds  { get; set; }
}

public class Movie
{
    public int Id { get; set; }
}

public class Genre
{
    public int Id { get; set; }
}
