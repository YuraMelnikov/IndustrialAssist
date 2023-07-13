using IndustrialAssist.Api.Common.Errors;
using IndustrialAssist.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IndustrialAssist.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, IndustrialAssistProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}