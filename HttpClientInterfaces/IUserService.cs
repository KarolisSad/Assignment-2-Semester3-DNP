using Domain.DTOs;
using Domain.Models;

namespace HttpClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDTO dto);
}