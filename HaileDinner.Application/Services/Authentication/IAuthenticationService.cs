namespace HaileDinner.Application.Services.Authentication;

public interface IAuthenticationService 
{
    AuthenticationResult Login(string Email,string Password );
    AuthenticationResult Register(string FirstName,string LastName,string Email, string Password);

}