using Domain.Models;
using HttpClientInterfaces;

namespace HttpClientImpl;

public class AuthClient : IAuthService
{
    public Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task RegisterUser(User user)
    {
        throw new NotImplementedException();
    }

    /*
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
    */
}