using Domain.DTOs;
using Domain.Models;

namespace Application.ILogicInterfaces;

public interface IPostLogic
{
    Task<Post> createPost(PostCreationDto dto);
    Task<Post> getPostById(int id);
    Task<IEnumerable<Post>> getAllPosts();
}