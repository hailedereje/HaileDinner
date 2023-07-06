using HaileDinner.Domain.Entities;

namespace HaileDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator  
{
    string GenerateToken(User user);
    
}