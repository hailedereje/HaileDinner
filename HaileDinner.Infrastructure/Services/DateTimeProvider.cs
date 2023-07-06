using HaileDinner.Application.Common.Services;

namespace HaileDinner.infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}