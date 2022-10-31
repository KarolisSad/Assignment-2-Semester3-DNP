using Domain.DTOs;
using Domain.Models;
using WebAPI.Controllers;

namespace HttpClientInterfaces;

public interface ISubForumService
{
    Task<SubForum> CreateSubForumAsync(SubForumCreationDto dto);
    Task<IEnumerable<SubForum>> GetAllSubForumsAsync(string topic);
    Task<SubForum> GetSubForumById(int id);
}