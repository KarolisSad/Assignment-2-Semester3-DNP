namespace Domain.DTOs;

public class PostCreationDto
{
    public int SubForumId { set; get; }
    public string OwnerUsername { set; get; }
    public string Topic { set; get; }
    public string Title { set; get; }
    public string Body { set; get; }

    public PostCreationDto(int subForumId, string ownerUsername, string topic, string title, string body)
    {
        SubForumId = subForumId;
        OwnerUsername = ownerUsername;
        Topic = topic;
        Title = title;
        Body = body;
    }

  
}