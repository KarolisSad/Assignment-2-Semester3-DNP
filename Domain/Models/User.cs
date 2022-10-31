namespace Domain.Models;

public class User
{
    public String Username { get; set; }
    public String Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
    
}