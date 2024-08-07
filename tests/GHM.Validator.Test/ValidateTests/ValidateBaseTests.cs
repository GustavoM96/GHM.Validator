using GHM.Validator.Interfaces;
using GHM.Validator.Test.Common;

namespace GHM.Validator.Test.ValidateTests;

public class ValidationBaseTests
{
    private readonly IValidate _validate;

    public ValidationBaseTests()
    {
        _validate = GhmValidatorProvider.GetValidateInstance();
    }

    [Fact]
    public void Test_GetDefaultSuccessMessage()
    {
        // Arrange
        string textTest = "123456";
        string successMessage = "Validated param: textTest. Value: 123456. ValidationName: IfParseToLong";

        // Act
        Validation result = _validate.IfParseToLong(textTest);

        // Assert
        Assert.True(result.IsValid);
        Assert.Equal(successMessage, result.Message);
    }

    [Fact]
    public void Test_GetDefaultSuccessMessageWithCompareValue()
    {
        // Arrange
        int numberA = 12;
        int objToCompare = 2;
        string successMessage = "Validated param: numberA. Value: 12. Compare: 2. ValidationName: IfGreaterOrEqual";

        // Act
        Validation result = _validate.IfGreaterOrEqual(numberA, objToCompare);

        // Assert
        Assert.True(result.IsValid);
        Assert.Equal(successMessage, result.Message);
    }

    [Fact]
    public void Test_GetDefaultErrorMessage()
    {
        // Arrange
        string textTest = "1234Asdfedf";
        string errorMessage = "Error to validate param: textTest. Value: 1234Asdfedf. ValidationName: IfParseToLong";

        // Act
        Validation result = _validate.IfParseToLong(textTest);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(errorMessage, result.Message);
    }

    [Fact]
    public void Test_GetDefaultErrorMessageWithCompareValue()
    {
        // Arrange
        int numberA = 12;
        int objToCompare = 3456;
        string errorMessage = "Error to validate param: numberA. Value: 12. Compare: 3456. ValidationName: IfGreaterOrEqual";

        // Act
        Validation result = _validate.IfGreaterOrEqual(numberA, objToCompare);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(errorMessage, result.Message);
    }
}
