using Application.DaoInterfaces;
using Application.ILogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private IPostDao PostDao;
    private ISubForumDao SubForumDao;
    private IUserDao UserDao;

    public PostLogic(IPostDao postDao, IUserDao userDao, ISubForumDao subForumDao)
    {
        PostDao = postDao;
        SubForumDao = subForumDao;
        UserDao = userDao;
    }

    public async Task<Post> createPost(PostCreationDto dto)
    {
        // Disadvantage is that we have to call to data base 3 times  
        
        // To check if owner exists
        User? userExisting = await UserDao.getUserByUsername(dto.OwnerUsername);
        if (userExisting == null)
        {
            throw new Exception($"User with username: {dto.OwnerUsername} doesn't exist.");
        }
        // To check if SubForum exists
        SubForum? forumExisting = SubForumDao.getSubForumById(dto.SubForumId);
        if (forumExisting == null)
        {
            throw new Exception($"Forum with id: {dto.SubForumId} doesn't exist.");
        }
        Post createdPost = await PostDao.createPost(dto);
        return createdPost;
    }

    public async Task<Post> getPostById(int id)
    {
        Post? post = await PostDao.getPostById(id);
        return post;
    }

    public async Task<IEnumerable<Post>> getAllPosts()
    {
        IEnumerable<Post>? posts = await PostDao.getAllPosts();
        return posts;
    }
}