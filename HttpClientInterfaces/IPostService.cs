using Domain.DTOs;
using Domain.Models;

namespace HttpClientInterfaces;

public interface IPostService
{
    Task<Post> CreatePost(PostCreationDto dto);
    Task<Post> GetPostById(int id);
    Task<IEnumerable<Post>> GetAllPostsBySubPostId(int id);
}