using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.ThrowerTests;

public class ThrowerBaseTests
{
    private readonly IThrower _thrower;

    public ThrowerBaseTests()
    {
        _thrower = new Thrower();
    }

    [Fact]
    public void Test_GetDefaultErrorMessage_WithCompareValue()
    {
        // Arrange
        int numberA = 12;
        int objToCompare = 3;
        var errorMessage = "Error to validate param: numberA. Value: 12. Compare: 3. ThrowerName: IfGreater";

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
        var errorMessage = "Error to validate param: textTest. Value: 1234Asdfedf. ThrowerName: IfNotParseToLong";

        // Act
        void Result() => _thrower.IfNotParseToLong(textTest);

        // Assert
        var ex = Assert.ThrowsAny<ArgumentException>(Result);
        Assert.Equal(errorMessage, ex.Message);
    }
}
