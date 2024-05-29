namespace NewsAPI.Entities.User;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }
    
    public string Password { get; set; }

    public Roles Role { get; set; }
}