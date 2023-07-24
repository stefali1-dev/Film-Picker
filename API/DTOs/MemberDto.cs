using API.Entities;

namespace API.DTOs;

public class MemberDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    
    public List<int> FavoriteGenresIds { get; set; }
    public List<int> FavoriteMoviesIds { get; set; }
}