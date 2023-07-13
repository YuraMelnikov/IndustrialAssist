using ErrorOr;
using IndustrialAssist.Application.Authentication.Commands.Register;
using IndustrialAssist.Application.Authentication.Queries.Login;
using IndustrialAssist.Application.Services.Authentication.Common;
using IndustrialAssist.Contracts.Authentication;
using IndustrialAssist.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialAssist.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _sender = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _sender.Send(command);

        return authResult.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)), errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _sender.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }

        return authResult.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)), errors => Problem(errors));
    }
}