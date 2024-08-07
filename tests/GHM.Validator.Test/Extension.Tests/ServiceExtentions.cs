using GHM.Validator.Interfaces;
using GHM.Validator.Test.Common;

namespace GHM.Validator.Test.Extension.Tests;

public class ServiceExtentions
{
    private readonly IThrower _thrower;
    private readonly IThrower _throwerOverflowException;
    private readonly IValidate _validate;

    public ServiceExtentions()
    {
        _thrower = GhmValidatorProvider.GetThrowerInstance();
        _validate = GhmValidatorProvider.GetValidateInstance();
        _throwerOverflowException = GhmValidatorProvider.GetThrowerInstance(
            config => config.ExceptionThrower = (string message) => new OverflowException(message)
        );

    }

    [Fact]
    public void Test_AddGhmValidator_ShouldInject_IThrowerAndIValidate()
    {
        // Arrange
        // Act
        void TestException() => _thrower!.IfEmpty("");

        // Assert
        Assert.IsAssignableFrom<IThrower>(_thrower);
        Assert.IsAssignableFrom<IValidate>(_validate);
        Assert.Throws<ArgumentException>(TestException);
    }

    [Fact]
    public void Test_AddGhmValidator_When_WithConfig_ShouldInject_IThrowerAndIValidateWithConfig()
    {
        // Arrange
        // Act
        void TestException() => _throwerOverflowException!.IfEmpty("");

        // Assert
        Assert.Throws<OverflowException>(TestException);
    }
}
