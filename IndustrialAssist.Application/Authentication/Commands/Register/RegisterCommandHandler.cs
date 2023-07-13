using ErrorOr;
using IndustrialAssist.Application.Common.Interfaces.Authentication;
using IndustrialAssist.Application.Common.Interfaces.Persistence;
using IndustrialAssist.Application.Services.Authentication.Common;
using IndustrialAssist.Domain.UserAggregate;
using MediatR;
using IndustrialAssist.Domain.Common.Errors;

namespace IndustrialAssist.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);


        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateJwtToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}