using System.Net;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.APIModel;
using NewsAPI.APIModel.Login;
using NewsAPI.APIModel.Register;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Controller;

[Route("api/UsersAuth")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    protected APIResponse _response;

    public UserController(IUserService userService)
    {
        _userService = userService;
        this._response = new();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var loginResponse = await _userService.Login(model);
        if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessage.Add("Username or password is incorrect");
            return BadRequest(_response);
        }

        _response.StatusCode = HttpStatusCode.OK;
        _response.IsSuccess = true;
        _response.Result = loginResponse;
        return Ok(_response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        bool ifUserNameUnique = _userService.IsUniqueUser(model.Surname);
        if (!ifUserNameUnique)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessage.Add("Username already exists");
            return BadRequest(_response);
        }

        var user = await _userService.Register(model);
        if (user == null)
        {
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessage.Add("Error while registering");
            return BadRequest(_response);
        }

        _response.StatusCode = HttpStatusCode.OK;
        _response.IsSuccess = true;
        return Ok(_response);
    }
}