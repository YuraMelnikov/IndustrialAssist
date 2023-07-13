using ErrorOr;
using IndustrialAssist.Application.Common.Interfaces.Authentication;
using IndustrialAssist.Application.Common.Interfaces.Persistence;
using IndustrialAssist.Application.Services.Authentication.Common;
using IndustrialAssist.Domain.UserAggregate;
using MediatR;
using IndustrialAssist.Domain.Common.Errors;

namespace IndustrialAssist.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != query.Password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
        }

        var token = _jwtTokenGenerator.GenerateJwtToken(user);
        return new AuthenticationResult(
            user,
            token);
    }
}
