namespace Domain.Models;

public class SubForum
{
    public String SubName { get; set; }
    public String OwnerUsername { get; set; }
    public int Id { get; set; }

    public SubForum(String subName, string ownerUsername)
    {
        SubName = subName;
        OwnerUsername = ownerUsername;
    }
}