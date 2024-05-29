using NewsAPI.Entities;
using NewsAPI.Entities.User;

namespace NewsAPI.APIModel.Login;

public class LoginResponseModel
{
    public User User { get; set; } 
    
    public string Token { get; set; }
}