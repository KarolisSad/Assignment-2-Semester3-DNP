using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface ISubForumDao
{
    Task<SubForum> createSubForum(SubForum subForum);
    Task<SubForum> getSubForumById(int dtoSubForumId);
    Task<IEnumerable<SubForum>> getSubTopics(SearchSubForumDto dto);
}