using GHM.Validator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GHM.Validator.Extensions;

public static class ServiceExtentions
{
    public static IServiceCollection AddGhmValidator(this IServiceCollection services)
    {
        services.AddScoped<IValidate, Validate>();
        services.AddScoped<IThrower, Thrower>();
        return services;
    }

    public static IServiceCollection AddGhmValidator(
        this IServiceCollection services,
        Func<string, Exception> exceptionThrower
    )
    {
        services.AddScoped<IThrower>(sp => Thrower.Create(exceptionThrower));
        services.AddScoped<IValidate, Validate>();
        return services;
    }
}
