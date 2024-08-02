using GHM.Validator.Extensions;
using GHM.Validator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GHM.Validator.Test.Common;

public class GhmValidatorProvider
{
    public static ServiceProvider GetServiceProvider(Action<GhmValidatorConfig>? configAction = null)
    {
        var service = new ServiceCollection();
        service.AddGhmValidator(configAction);
        return service.BuildServiceProvider();
    }

    public static IValidate GetValidateInstance(Action<GhmValidatorConfig>? configAction = null)
    {
        return GetServiceProvider(configAction).GetService<IValidate>()!;
    }

    public static IThrower GetThrowerInstance(Action<GhmValidatorConfig>? configAction = null)
    {
        return GetServiceProvider(configAction).GetService<IThrower>()!;
    }
}
