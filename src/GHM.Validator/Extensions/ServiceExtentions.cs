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
}
