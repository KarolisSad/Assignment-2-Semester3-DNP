using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class SubForumEfcDao:ISubForumDao
{
    private readonly Context context;

    public SubForumEfcDao(Context context)
    {
        this.context = context;
    }

    public async Task<SubForum> createSubForum(SubForum subForum)
    {
        EntityEntry<SubForum> newSubForum = await context.SubForums.AddAsync(subForum);
        await context.SaveChangesAsync();
        return newSubForum.Entity;
    }

    public async Task<SubForum> getSubForumById(int dtoSubForumId)
    {
        SubForum? subForum = await context.SubForums.FirstOrDefaultAsync(p => p.Id == dtoSubForumId);
        return subForum;
    }

    public async Task<IEnumerable<SubForum>> getSubTopics(SearchSubForumDto dto)
    {
        IQueryable<SubForum> subForumsQuery = context.SubForums.AsQueryable();
        
        if (!string.IsNullOrEmpty(dto.Topic))
        {
            subForumsQuery = subForumsQuery.Where(sub => sub.SubName.ToLower().Contains(dto.Topic.ToLower()));
        }

        IEnumerable<SubForum> results = await subForumsQuery.ToListAsync();
        return results;
    }
}