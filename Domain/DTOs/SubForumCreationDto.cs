namespace Domain.DTOs;

public class SubForumCreationDto
{
    public String SubName { get; set; }
    public String OwnerUsername { get; set; }
    public int Id { get; }

    public SubForumCreationDto(string subName, string ownerUsername)
    {
        SubName = subName;
        OwnerUsername = ownerUsername;
    }
}