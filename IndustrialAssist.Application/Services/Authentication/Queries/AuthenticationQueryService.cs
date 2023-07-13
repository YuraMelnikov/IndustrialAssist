using ErrorOr;
using IndustrialAssist.Application.Common.Interfaces.Authentication;
using IndustrialAssist.Application.Common.Interfaces.Persistence;
using IndustrialAssist.Application.Services.Authentication.Common;
using IndustrialAssist.Domain.UserAggregate;
using IndustrialAssist.Domain.Common.Errors;

namespace IndustrialAssist.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
        }

        var token = _jwtTokenGenerator.GenerateJwtToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}