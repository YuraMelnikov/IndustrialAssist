using ErrorOr;
using IndustrialAssist.Application.Services.Authentication.Common;
using MediatR;

namespace IndustrialAssist.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;