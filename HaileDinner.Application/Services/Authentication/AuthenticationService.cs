using HaileDinner.Application.Common.Interfaces.Authentication;
using HaileDinner.Application.Common.Interfaces.Persistance;
using HaileDinner.Domain.Entities;

namespace HaileDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string Email, string Password)
    {
        if(_userRepository.GetUserByEmail(Email) is not User user)
        {
            throw new Exception(_userRepository.GetAll().ToString());
        }
        if(user.Password != Password)
        {
            throw new Exception("invalid password");
        }
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user,token);
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        if(_userRepository.GetUserByEmail(Email) is not null)
        {
            throw new Exception("user already exist");
        }      
        
        var user = new User {FirstName=FirstName,LastName=LastName, Email = Email, Password = Password };
        _userRepository.Add(user);
        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}