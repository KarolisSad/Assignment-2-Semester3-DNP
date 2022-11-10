using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClientInterfaces;

namespace HttpClientImpl;

public class PostHttpClient : IPostService
{
    private readonly HttpClient httpClient;

    public PostHttpClient(HttpClient client)
    {
        this.httpClient = client;
    }
    
    public async Task<Post> CreatePost(PostCreationDto dto)
    {
        HttpResponseMessage response = await httpClient.PostAsJsonAsync("/post",dto);
        string message = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(message);
        }

        Post post = JsonSerializer.Deserialize<Post>(message, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }

    public async Task<Post> GetPostById(int id)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"/post/{id}");
        string message = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(message);
        }
        
        Post post = JsonSerializer.Deserialize<Post>(message, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive  = true
        })!;
        return post;
    }

    public async Task<IEnumerable<Post>> GetAllPostsBySubPostId(int id)
    {
        HttpResponseMessage response = await httpClient.GetAsync($"/post");
        string message = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(message);
        }
        
        IEnumerable<Post> post = JsonSerializer.Deserialize<IEnumerable<Post>>(message, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive  = true
        })!;
        // Methods approach of getting all "PostsBySubPostId" is not best practice.
        // The way to do it, would be to have "filtering" done in server part and get ready results.
        // :)
        post = post.Where(post => post.SubForumId == id);
        return post;
    }
}