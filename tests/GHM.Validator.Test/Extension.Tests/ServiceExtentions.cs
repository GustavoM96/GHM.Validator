using GHM.Validator.Interfaces;
using GHM.Validator.Test.Common;

namespace GHM.Validator.Test.Extension.Tests;

public class ServiceExtentions
{
    [Fact]
    public void Test_AddGhmValidator_ShouldInject_IThrowerAndIValidate()
    {
        // Arrange
        var validate = GhmValidatorProvider.GetValidateInstance();
        var thrower = GhmValidatorProvider.GetThrowerInstance();

        // Act
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
        var thrower = GhmValidatorProvider.GetThrowerInstance(
            config => config.ExceptionThrower = (string message) => new OverflowException(message)
        );

        // Act
        void TestException() => thrower!.IfEmpty("");

        // Assert
        Assert.Throws<OverflowException>(TestException);
    }
}
