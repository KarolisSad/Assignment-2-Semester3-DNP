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
}