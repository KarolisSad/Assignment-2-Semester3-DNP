namespace WebAPI.Controllers;

public class SearchSubForumParametersDto
{
    public string? topic { get; }

    public SearchSubForumParametersDto(string? topic)
    {
        this.topic = topic;
    }
}