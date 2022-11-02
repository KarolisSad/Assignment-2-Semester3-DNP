using Domain.DTOs;
using Domain.Models;

namespace Application.ILogicInterfaces;

public interface IUserLogic
{
    
    Task<User> CreateUser(UserCreationDTO userToCreate);
    Task<User> GetUserByUsername(string username);
}