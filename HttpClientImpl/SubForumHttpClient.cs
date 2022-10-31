using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClientInterfaces;
using WebAPI.Controllers;


namespace HttpClientImpl;

public class SubForumHttpClient : ISubForumService
{
    private readonly HttpClient client;

    public SubForumHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<SubForum> CreateSubForumAsync(SubForumCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/SubForum", dto);
        string message = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(message);
        }

        SubForum subForum = JsonSerializer.Deserialize<SubForum>(message, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return subForum;
    }

    public async Task<IEnumerable<SubForum>> GetAllSubForumsAsync(string topic)
    {
        HttpResponseMessage response;
        if (!string.IsNullOrEmpty(topic))
        { 
            response = await client.GetAsync($"/SubForum/{topic}");
        }
        else
        {
            response = await client.GetAsync("/SubForum");
        }

        string message = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(message);
        }

        IEnumerable<SubForum> result = JsonSerializer.Deserialize<IEnumerable<SubForum>>(message, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return result;
    }

    public async Task<SubForum> GetSubForumById(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/SubForum/{id}");
        string message = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(message);
        }

        SubForum forum = JsonSerializer.Deserialize<SubForum>(message, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return forum;

    }
}