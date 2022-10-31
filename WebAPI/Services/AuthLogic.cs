using Application.DaoInterfaces;
using Domain.Models;
using FileData.DAOs;

namespace WebAPI.Services;

public class AuthLogic : IAuthService
{
    private IUserDao userDao;

    public AuthLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public Task<User> ValidateUser(string username, string password)
    {
        User? user =  userDao.getUserByUsername(username).Result;

        if (user == null)
        {
            throw new Exception($"User {username} not found!");
        }

        if (!(user.Password.Equals(password)))
        {
            throw new Exception("Mismatch between username and password!");
        }

        return Task.FromResult(user);
    }

    public Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new Exception("Username cannot be null");
        }
        
        if (string.IsNullOrEmpty(user.Password))
        {
            throw new Exception("Password cannot be null");
        }

        userDao.createUser(user);
        
        return Task.CompletedTask;
    }
}