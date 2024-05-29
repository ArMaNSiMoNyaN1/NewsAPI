using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NewsAPI.APIModel.Login;
using NewsAPI.APIModel.Register;
using NewsAPI.Data;
using NewsAPI.Entities.User;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Services.Implementations;

public class UserService : IUserService
{
    private readonly DataContext _context;
    private string secretKey;

    public UserService(DataContext context, IConfiguration configuration)
    {
        _context = context;
        secretKey = configuration.GetValue<string>("ApiSettings:Secret");
    }

    public bool IsUniqueUser(string username)
    {
        var user = _context.Users.FirstOrDefault(x => x.Surname == username);
        if (user == null)
        {
            return true;
        }

        return false;
    }

    public async Task<LoginResponseModel> Login(LoginModel loginModel)
    {
        var user = _context.Users.FirstOrDefault(u => u.Surname.ToLower() == loginModel.Surname.ToLower()
                                                      && u.Password == loginModel.Password);
        if (user == null)
        {
            return new LoginResponseModel()
            {
                Token = "",
                User = null
            };
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(5),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        LoginResponseModel loginResponseModel = new LoginResponseModel()
        {
            Token = tokenHandler.WriteToken(token),
            User = user
        };
        return loginResponseModel;
    }

    public async Task<User> Register(RegisterModel registerModel)
    {
        Roles userRole = Roles.User;
        User user = new User()
        {
            Surname = registerModel.Surname,
            Password = registerModel.Password,
            Name = registerModel.Name,
            Role = registerModel.Role
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        user.Password = "";
        return user;
    }
}