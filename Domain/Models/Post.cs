namespace Domain.Models;
using System.ComponentModel.DataAnnotations;

public class Post
{
    public int SubForumId { set; get; }
    public string OwnerUsername { set; get; }
    public string Topic { set; get; }
    public string Title { set; get; }
    public string Body { set; get; }
    public int Id { set; get; }

    public Post(int subForumId, string ownerUsername, string topic, string title, string body, int id)
    {
        SubForumId = subForumId;
        OwnerUsername = ownerUsername;
        Topic = topic;
        Title = title;
        Body = body;
        Id = id;
    }
    
    public Post(int subForumId, string ownerUsername, string topic, string title, string body)
    {
        SubForumId = subForumId;
        OwnerUsername = ownerUsername;
        Topic = topic;
        Title = title;
        Body = body;
    }

    public Post()
    {
    }
}