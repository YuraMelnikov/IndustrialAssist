using IndustrialAssist.Domain.UserAggregate;

namespace IndustrialAssist.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
    string GenerateJwtToken(User user);
}