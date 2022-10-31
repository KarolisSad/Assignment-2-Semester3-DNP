using Domain.Models;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> createUser(User user);
    Task<User> getUserByUsername(string username);
}