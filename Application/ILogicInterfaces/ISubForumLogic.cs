using Domain.DTOs;
using Domain.Models;

namespace Application.ILogicInterfaces;

public interface ISubForumLogic
{
    Task<SubForum> CreateSubForum(SubForumCreationDto subForumToAdd);
    Task<IEnumerable<SubForum>> GetSubTopics(SearchSubForumDto subForumDto);
    Task<SubForum> GetSubForumById(int id);
}