using System.ComponentModel.DataAnnotations;

namespace NewsAPI.APIModel.Register;

public class RegisterModel
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;

    [DataType(DataType.Password)] public string Password { get; set; } = null!;

    public Roles Role { get; set; }
}