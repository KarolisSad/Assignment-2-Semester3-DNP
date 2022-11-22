using System.Text.Json.Serialization;

namespace Domain.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    
    public String Username { get; set; }
    public String Password { get; set; }
    
    [JsonIgnore]
    public ICollection<Post> MyPosts { get; set; }

    [JsonIgnore]
    public ICollection<SubForum> MyForums { get; set; }

    public User(string username, string password, ICollection<Post> myPosts, ICollection<SubForum> myForums)
    {
        Username = username;
        Password = password;
        MyPosts = myPosts;
        MyForums = myForums;
    }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public User()
    {
    }
}