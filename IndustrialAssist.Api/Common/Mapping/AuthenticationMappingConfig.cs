using IndustrialAssist.Application.Authentication.Commands.Register;
using IndustrialAssist.Application.Authentication.Queries.Login;
using IndustrialAssist.Application.Services.Authentication.Common;
using IndustrialAssist.Contracts.Authentication;
using Mapster;

namespace IndustrialAssist.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}