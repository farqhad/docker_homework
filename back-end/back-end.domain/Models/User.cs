namespace Backend.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public string Nickname { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}
