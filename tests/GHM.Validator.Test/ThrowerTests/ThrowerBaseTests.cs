using GHM.Validator.Interfaces;
using GHM.Validator.Test.Common;

namespace GHM.Validator.Test.ThrowerTests;

public class ThrowerBaseTests
{
    private readonly IThrower _thrower;

    public ThrowerBaseTests()
    {
        _thrower = GhmValidatorProvider.GetThrowerInstance();
    }

    [Fact]
    public void Test_GetDefaultErrorMessage_WithCompareValue()
    {
        // Arrange
        int numberA = 12;
        int objToCompare = 3;
        var errorMessage = "Error: param: numberA. Value: 12. Compare: 3. ThrowerName: IfGreater";

        // Act
        void Result() => _thrower.IfGreater(numberA, objToCompare);

        // Assert
        var ex = Assert.ThrowsAny<ArgumentException>(Result);
        Assert.Equal(errorMessage, ex.Message);
    }

    [Fact]
    public void Test_GetDefaultErrorMessage_WithTrower()
    {
        // Arrange
        string textTest = "1234Asdfedf";
        var errorMessage = "Error: param: textTest. Value: 1234Asdfedf. ThrowerName: IfNotParseToLong";

        // Act
        void Result() => _thrower.IfNotParseToLong(textTest);

        // Assert
        var ex = Assert.ThrowsAny<ArgumentException>(Result);
        Assert.Equal(errorMessage, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfError_When_NotValidated_ShouldThrow_AndResetInnertThrower()
    {
        // Arrange
        string? stringTest = null;

        // Act
        void Result() => _thrower.WithException(message => new FormatException(message)).IfEmpty(stringTest);
        void Result2() => _thrower.WithException(message => new ArithmeticException(message)).IfEmpty(stringTest);
        void ResultWithInitialException() => _thrower.IfEmpty(stringTest);

        // Assert
        Assert.ThrowsAny<FormatException>(Result);
        Assert.ThrowsAny<ArithmeticException>(Result2);
        Assert.ThrowsAny<ArgumentException>(ResultWithInitialException);
    }

    [Fact]
    public void Test_ThrowIfError_When_Validated_ShouldReturn_True_AndResetInnertThrower()
    {
        // Arrange
        string? stringTest = "test123";
        string errorStringTest = "";

        // Act
        _thrower.WithException(message => new FormatException(message)).IfEmpty(stringTest);
        void ResultWithInitialException() => _thrower.IfEmpty(errorStringTest);

        // Assert
        Assert.ThrowsAny<ArgumentException>(ResultWithInitialException);
    }
}
