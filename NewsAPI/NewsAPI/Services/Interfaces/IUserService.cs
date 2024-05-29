using NewsAPI.APIModel.Login;
using NewsAPI.APIModel.Register;
using NewsAPI.Entities;
using NewsAPI.Entities.User;

namespace NewsAPI.Services.Interfaces;

public interface IUserService
{
    bool IsUniqueUser(string username);
    Task<LoginResponseModel> Login(LoginModel loginModel);
    Task<User> Register(RegisterModel registerModel);
}