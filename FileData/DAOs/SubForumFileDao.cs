using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class SubForumFileDao : ISubForumDao
{
    private readonly FileContext context;

    public SubForumFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<SubForum> createSubForum(SubForum subForum)
    {
        int id = 1;
        if (context.SubForums.Any())
        {
            id = context.SubForums.Max(i => i.Id);
            id++;
        }
        subForum.Id = id;
        
        context.SubForums.Add(subForum);
        context.SaveChanges();
        
        return Task.FromResult(subForum);
    }

    public Task<SubForum> getSubForumById(int dtoSubForumId)
    {
        SubForum? subForum = context.SubForums.FirstOrDefault(s => s.Id.Equals(dtoSubForumId));
        return Task.FromResult(subForum);
    }

    public Task<IEnumerable<SubForum>> getSubTopics(SearchSubForumDto dto)
    {
        IEnumerable<SubForum> subForums = context.SubForums.AsEnumerable();
        if (!string.IsNullOrEmpty(dto.Topic))
        {
            subForums = context.SubForums.Where(s => dto.Topic.Equals(s.SubName, StringComparison.OrdinalIgnoreCase));
        }
        return Task.FromResult(subForums);
    }
}