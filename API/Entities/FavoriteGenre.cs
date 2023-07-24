using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("UserFavoriteGenres")]
public class FavoriteGenre
{
    public int Id { get; set; }
    public AppUser User { get; set; }
    public int UserId { get; set; }
    public int GenreId { get; set; }
}