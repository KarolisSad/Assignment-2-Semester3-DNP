using Application.DaoInterfaces;
using Domain.Models;
// Sub Writer Writer to database
namespace FileData.DAOs;

public class UserFileDao : IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }
    
    public Task<User> createUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User> getUserByUsername(string username)
    {
    
        User? existing = context.Users.FirstOrDefault(u => u.Username.Equals(username));
        Console.WriteLine(existing);
        return Task.FromResult(existing);
    }
}