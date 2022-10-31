using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> createPost(PostCreationDto post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(i => i.Id);
            id++;
        }

        Post createdPost = new Post(post.SubForumId, post.OwnerUsername, post.Topic, post.Title, post.Body, id);
        context.Posts.Add(createdPost);
        context.SaveChanges();
        return Task.FromResult(createdPost);
    }

    public async Task<Post> getPostById(int id)
    {
        Post? post = context.Posts.FirstOrDefault(p => p.Id == id);
        return post;
    }

    public async Task<IEnumerable<Post>> getAllPosts()
    {
        IEnumerable<Post>? posts = context.Posts;
        return posts;
    }
}