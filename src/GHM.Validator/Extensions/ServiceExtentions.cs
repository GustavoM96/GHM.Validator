using GHM.Validator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GHM.Validator.Extensions;

public static class ServiceExtentions
{
    public static IServiceCollection AddGhmValidator(
        this IServiceCollection services,
        Func<string, Exception> exceptionThrower
    )
    {
        services.AddTransient<IThrower>(sp => new Thrower(exceptionThrower));
        services.AddTransient<IValidate, Validate>();
        return services;
    }

    public static IServiceCollection AddGhmValidator(
        this IServiceCollection services,
        Action<GhmValidatorConfig>? configAction = null
    )
    {
        GhmValidatorConfig config = new();
        configAction?.Invoke(config);

        services.AddTransient<IThrower>(_ => new Thrower(config.ExceptionThrower));
        services.AddTransient<IValidate, Validate>();
        return services;
    }
}
