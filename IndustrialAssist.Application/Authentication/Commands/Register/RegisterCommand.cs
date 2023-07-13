using ErrorOr;
using IndustrialAssist.Application.Services.Authentication.Common;
using MediatR;

namespace IndustrialAssist.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;