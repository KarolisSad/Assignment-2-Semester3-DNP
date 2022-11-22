using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;
using Application.DaoInterfaces;


public class PostEfcDao:IPostDao
{
    private readonly Context context;

    public PostEfcDao(Context context)
    {
        this.context = context;
    }

    public async Task<Post> createPost(PostCreationDto post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(new Post(post.SubForumId, post.OwnerUsername, post.Topic, post.Title, post.Body));
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<Post?> getPostById(int id)
    {
        Post? post = await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        return post;
    }

    public async Task<IEnumerable<Post>> getAllPosts()
    {
        IQueryable<Post> postQuery = context.Posts.AsQueryable();
        IEnumerable<Post> results = await postQuery.ToListAsync();
        return results;
    }
}