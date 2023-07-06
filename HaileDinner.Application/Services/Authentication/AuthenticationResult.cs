using HaileDinner.Domain.Entities;

namespace HaileDinner.Application.Services.Authentication;

public record AuthenticationResult(
     User user,
     string Token
);