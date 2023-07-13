using ErrorOr;
using IndustrialAssist.Application.Common.Interfaces.Authentication;
using IndustrialAssist.Application.Common.Interfaces.Persistence;
using IndustrialAssist.Application.Services.Authentication.Common;
using IndustrialAssist.Domain.UserAggregate;
using IndustrialAssist.Domain.Common.Errors;

namespace IndustrialAssist.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = User.Create(firstName, lastName, email, password);

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateJwtToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}