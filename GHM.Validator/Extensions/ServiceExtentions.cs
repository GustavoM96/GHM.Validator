using GHM.Validator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GHM.Validator.Extensions;

public static class ServiceExtentions
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddScoped<IValidator, Validator>();
        return services;
    }
}
