using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.ValidateTests;

public class ValidationBaseTests
{
    private readonly IValidate _validate;

    public ValidationBaseTests()
    {
        _validate = new Validate();
    }

    [Fact]
    public void Test_GetDefaultSuccessMessage()
    {
        // Arrange
        string textTest = "123456";
        var successMessage = "Validated param: textTest. Value: 123456. ValidationName: IfParseToLong";

        // Act
        var result = _validate.IfParseToLong(textTest);

        // Assert
        Assert.True(result.IsValid);
        Assert.Equal(successMessage, result.Message);
    }

    [Fact]
    public void Test_GetDefaultSuccessMessage_WithCompareValue()
    {
        // Arrange
        int numberA = 12;
        int objToCompare = 2;
        var successMessage = "Validated param: numberA. Value: 12. Compare: 2. ValidationName: IfGreaterOrEqual";

        // Act
        var result = _validate.IfGreaterOrEqual(numberA, objToCompare);

        // Assert
        Assert.True(result.IsValid);
        Assert.Equal(successMessage, result.Message);
    }

    [Fact]
    public void Test_GetDefaultErrorMessage()
    {
        // Arrange
        string textTest = "1234Asdfedf";
        var errorMessage = "Error to validate param: textTest. Value: 1234Asdfedf. ValidationName: IfParseToLong";

        // Act
        var result = _validate.IfParseToLong(textTest);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(errorMessage, result.Message);
    }

    [Fact]
    public void Test_GetDefaultErrorMessage_WithCompareValue()
    {
        // Arrange
        int numberA = 12;
        int objToCompare = 3456;
        var errorMessage = "Error to validate param: numberA. Value: 12. Compare: 3456. ValidationName: IfGreaterOrEqual";

        // Act
        var result = _validate.IfGreaterOrEqual(numberA, objToCompare);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(errorMessage, result.Message);
    }
}
