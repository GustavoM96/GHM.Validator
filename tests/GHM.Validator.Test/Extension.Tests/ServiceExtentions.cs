using GHM.Validator.Extensions;
using GHM.Validator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GHM.Validator.Test.Extension.Tests;

public class ServiceExtentions
{
    private readonly IServiceCollection _service;

    public ServiceExtentions()
    {
        _service = new ServiceCollection();
    }

    [Fact]
    public void Test_AddGhmValidator_ShouldInject_IThrowerAndIValidate()
    {
        // Arrange
        _service.AddGhmValidator();

        // Act
        var provider = _service.BuildServiceProvider();
        var validate = provider.GetService<IValidate>();
        var thrower = provider.GetService<IThrower>();
        void TestException() => thrower!.IfEmpty("");

        // Assert
        Assert.IsAssignableFrom<IThrower>(thrower);
        Assert.IsAssignableFrom<IValidate>(validate);
        Assert.Throws<ArgumentException>(TestException);
    }

    [Fact]
    public void Test_AddGhmValidator_When_WithConfig_ShouldInject_IThrowerAndIValidateWithConfig()
    {
        // Arrange
        _service.AddGhmValidator(config => config.ExceptionThrower = (string message) => new OverflowException(message));

        // Act
        var provider = _service.BuildServiceProvider();
        var thrower = provider.GetService<IThrower>();
        void TestException() => thrower!.IfEmpty("");

        // Assert
        Assert.Throws<OverflowException>(TestException);
    }
}
