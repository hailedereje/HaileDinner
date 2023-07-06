using HaileDinner.Application.Common.Interfaces.Persistance;
using HaileDinner.Application.Services.Authentication;
using HaileDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HaileDinner.Api.Controllers;

[ApiController]
[Route("Auth")]
public class AuthenticationController : ControllerBase 
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserRepository _user;

    public AuthenticationController(IAuthenticationService authenticationService, IUserRepository user)
    {
        _authenticationService = authenticationService;
        _user = user;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        if(_user.GetUserByEmail(request.Email) is not null)
        {
            throw new Exception();
        }
        var authResult = _authenticationService.Register(request.FirstName,request.LastName,request.Email,request.Password);
        var response = new AuthenticationResponse(authResult.user.Id,
                                                  authResult.user.FirstName,
                                                  authResult.user.LastName,
                                                  authResult.user.Email,
                                                  authResult.Token);
        return Ok(response);
    }


    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var login = _authenticationService.Login(request.Email,request.Password);
        var response = new AuthenticationResponse(login.user.Id,login.user.FirstName,login.user.LastName,login.user.Email,login.Token);
        
        return Ok(response);
    }
}