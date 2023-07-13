using ErrorOr;
using IndustrialAssist.Application.Services.Authentication.Common;

namespace IndustrialAssist.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}
