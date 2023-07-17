using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    
    public List<int> FavoriteGenresIds  { get; set; }
    public List<int> FavoriteMoviesIds  { get; set; }
}
