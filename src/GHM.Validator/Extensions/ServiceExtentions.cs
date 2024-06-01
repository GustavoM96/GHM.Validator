using GHM.Validator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GHM.Validator.Extensions;

public static class ServiceExtentions
{
    public static IServiceCollection AddGhmValidator(this IServiceCollection services)
    {
        services.AddTransient<IThrower>(sp => new Thrower());
        services.AddTransient<IValidate, Validate>();
        return services;
    }

    public static IServiceCollection AddGhmValidator(
        this IServiceCollection services,
        Func<string, Exception> exceptionThrower
    )
    {
        services.AddTransient<IThrower>(sp => new Thrower(exceptionThrower));
        services.AddTransient<IValidate, Validate>();
        return services;
    }
}
