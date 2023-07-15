using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    
    public List<Genre> FavoriteGenresIds  { get; set; }
    public List<Movie> FavoriteMoviesIds  { get; set; }
}
