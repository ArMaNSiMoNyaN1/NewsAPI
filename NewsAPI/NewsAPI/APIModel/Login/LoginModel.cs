using System.ComponentModel.DataAnnotations;

namespace NewsAPI.APIModel.Login;

public class LoginModel
{
    public string Surname { get; set; } = null!;

    [DataType(DataType.Password)] public string Password { get; set; } = null!;
}