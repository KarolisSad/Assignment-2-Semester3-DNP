using Domain.DTOs;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> createPost(PostCreationDto post);
    Task<Post> getPostById(int id);
    Task<IEnumerable<Post>> getAllPosts();
}