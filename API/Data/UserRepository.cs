using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public void Update(AppUser user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await _context.Users
            .Include(x => x.FavoriteGenres)
            .Include(x => x.FavoriteMovies)
            .ToListAsync();
    }

    public async Task<AppUser> GetUserByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user;
    }

    public async Task<AppUser> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        Console.WriteLine("----------------------------------------- THIS -----------------------------------------");
        Console.WriteLine(user.FavoriteMovies);
        return user;
    }
}