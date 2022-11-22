using Application.DaoInterfaces;
using Application.ILogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class SubForumLogic : ISubForumLogic
{
    private readonly ISubForumDao subForumDao;
    private readonly IUserDao userDao;
    
    public SubForumLogic(ISubForumDao subForumDao, IUserDao userDao)
    {
        this.subForumDao = subForumDao;
        this.userDao = userDao;
    }

    public async Task<SubForum> CreateSubForum(SubForumCreationDto subForumToAdd)
    {
        validateData(subForumToAdd);
        User? user = await userDao.getUserByUsername(subForumToAdd.OwnerUsername);
        if (user == null)
        {
            throw new Exception($"User with name: {subForumToAdd.OwnerUsername} doesn't exist.");
        }
        
        SubForum? subForum = new SubForum(subForumToAdd.SubName, subForumToAdd.OwnerUsername);
        SubForum createdSubForum = await subForumDao.createSubForum(subForum);
        return createdSubForum;
    }

    public async Task<IEnumerable<SubForum>> GetSubTopics(SearchSubForumDto subForumDto)
    {
        IEnumerable<SubForum> subList = await subForumDao.getSubTopics(subForumDto);
        return subList;
    }

    public async Task<SubForum> GetSubForumById(int id)
    {
        SubForum? subForum = await subForumDao.getSubForumById(id);
        if (subForum == null)
        {
            throw new Exception($"Sub forum with ID: {id} doesn't exist");
        }
        return subForum;
    }

    private async void validateData(SubForumCreationDto subForumToAdd)
    {
        if (subForumToAdd.SubName.Length <3 )
        {
            throw new Exception("Sub forum name must contain at least 3 characters");
        }

        if (string.IsNullOrEmpty(subForumToAdd.OwnerUsername))
        {
            throw new Exception($"Owner must be assigned to SubForum");
        }
    }
}