using Application.DaoInterfaces;
using Application.ILogicInterfaces;
using Domain.DTOs;
using Domain.Models;
// Our logic of USER
namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    public async Task<User> CreateUser(UserCreationDTO userToCreate)
    {
        User? user = await userDao.getUserByUsername(userToCreate.username);
        if (user != null)
        {
            throw new Exception($"User with username {user.Username} already exists.");
        }
        ValidateData(userToCreate);

        User? createdUser = new User(userToCreate.username, userToCreate.password);
        userDao.createUser(createdUser);
        return createdUser;
    }

    public async Task<User> GetUserByUsername(string username)
    {
        User? user = await userDao.getUserByUsername(username);
        return user;
    }

    private void ValidateData(UserCreationDTO userToCreate)
    {
        if (userToCreate.username.Length<3)
        {
            throw new Exception("Username must contain at least 3 characters.");
        }
        if (userToCreate.password.Length<3)
        {
            throw new Exception("Password must contain at least 3 characters.");
        }
    }
}