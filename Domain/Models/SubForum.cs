namespace Domain.Models;
using System.ComponentModel.DataAnnotations;

public class SubForum
{
    public String SubName { get; set; }
    public String OwnerUsername { get; set; }
    [Key]
    public int Id { get; set; }

    public SubForum(String subName, string ownerUsername)
    {
        SubName = subName;
        OwnerUsername = ownerUsername;
    }
}