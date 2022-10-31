namespace Domain.DTOs;

public class UserCreationDTO
{
    public String username { get; set; }
    public String password { get; set; }

    public UserCreationDTO(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}