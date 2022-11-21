namespace Domain.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public String Username { get; set; }
    public String Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
    
}