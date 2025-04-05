using GHM.Validator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GHM.Validator.Extensions;

/// <summary>
/// Extension methods for IServiceCollection to add GHM Validator.
/// </summary>
public static class ServiceExtentions
{
    /// <summary>
    /// Adds GHM Validator to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add GHM Validator to.</param>
    /// <param name="configAction">An optional action to configure GHM Validator.</param>
    /// <returns>The modified IServiceCollection.</returns>
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
