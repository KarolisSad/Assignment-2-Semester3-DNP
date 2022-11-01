using Application.DaoInterfaces;
using Application.ILogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Services;

public class AuthLogic : IAuthService
{
    private IUserLogic logic;

    public AuthLogic(IUserLogic logic)
    {
        this.logic = logic;
    }

    public Task<User> ValidateUser(string username, string password)
    {
        User? user =  logic.GetUserByUsername(username).Result;

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

    public Task<User> RegisterUser(UserCreationDTO user)
    {
        if (string.IsNullOrEmpty(user.username))
        {
            throw new Exception("Username cannot be null");
        }
        
        if (string.IsNullOrEmpty(user.password))
        {
            throw new Exception("Password cannot be null");
        }

        User created = logic.CreateUser(user).Result;
        
        return Task.FromResult(created);
    }
}