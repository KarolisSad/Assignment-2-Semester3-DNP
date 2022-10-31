namespace Domain.DTOs;

public class SearchSubForumDto
{
    public string? Topic { get; }
    private int? SubPostId { get; }

    public SearchSubForumDto(string? topic)
    {
        Topic = topic;
    }
}