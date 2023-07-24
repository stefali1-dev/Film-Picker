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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<FavoriteGenre>()
            .HasKey(i => i.Id);
        
        modelBuilder.Entity<FavoriteMovie>()
            .HasKey(i => i.Id);

        modelBuilder.Entity<FavoriteGenre>()
            .HasOne(i => i.User)
            .WithMany(u => u.FavoriteGenres)
            .HasForeignKey(i => i.UserId);
        
        modelBuilder.Entity<FavoriteMovie>()
            .HasOne(i => i.User)
            .WithMany(u => u.FavoriteMovies)
            .HasForeignKey(i => i.UserId);
        
        // Make GenreId and MovieId unique in their respective tables
        modelBuilder.Entity<FavoriteGenre>()
            .HasIndex(i => i.GenreId)
            .IsUnique();

        modelBuilder.Entity<FavoriteMovie>()
            .HasIndex(i => i.MovieId)
            .IsUnique();
    }
}