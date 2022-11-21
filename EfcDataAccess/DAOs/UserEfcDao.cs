using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;
using Domain.Models;

public class UserEfcDao : IUserDao
{

    public readonly Context context;

    public UserEfcDao(Context context)
    {
        this.context = context;
    }

    public async Task<User> createUser(User user)
    {

        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }
    
    public async Task<User?> getUserByUsername(string username)
    {
        User? existinguser = await context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

        return existinguser;
    }
}