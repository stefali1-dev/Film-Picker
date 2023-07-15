using API.DTOs;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    
    // It's not working
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure many-to-many relationship between User and Genre
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.FavoriteGenresIds)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "UserFavoriteGenres",
                j => j
                    .HasOne<Genre>()
                    .WithMany()
                    .HasForeignKey("GenreId"),
                j => j
                    .HasOne<AppUser>()
                    .WithMany()
                    .HasForeignKey("UserId")
            );

        // Configure many-to-many relationship between User and Movie
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.FavoriteMoviesIds)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "UserFavoriteMovies",
                j => j
                    .HasOne<Movie>()
                    .WithMany()
                    .HasForeignKey("MovieId"),
                j => j
                    .HasOne<AppUser>()
                    .WithMany()
                    .HasForeignKey("UserId")
            );
    }
}