using IndustrialAssist.Domain.UserAggregate;

namespace IndustrialAssist.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);