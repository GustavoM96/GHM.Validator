using GHM.Validator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GHM.Validator.Extensions;

public static class ServiceExtentions
{
    public static IServiceCollection AddGhmValidator(this IServiceCollection services)
    {
        services.AddTransient<IValidate, Validate>();
        services.AddTransient<IThrower, Thrower>();
        return services;
    }

    public static IServiceCollection AddGhmValidator(
        this IServiceCollection services,
        Func<string, Exception> exceptionThrower
    )
    {
        services.AddTransient<IThrower>(sp => Thrower.Create(exceptionThrower));
        services.AddTransient<IValidate, Validate>();
        return services;
    }
}
