using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("UserFavoriteMovies")]
public class FavoriteMovie
{
    public int Id { get; set; }
    public AppUser User { get; set; }

    public int UserId { get; set; }
    public int MovieId { get; set; }
}