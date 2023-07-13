using IndustrialAssist.Application.Common.Interfaces.Services;

namespace IndustrialAssist.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}