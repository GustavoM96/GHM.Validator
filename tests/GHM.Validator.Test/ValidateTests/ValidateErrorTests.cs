using GHM.Validator.Core.Enum;
using GHM.Validator.Interfaces;
using GHM.Validator.Test.Common;

namespace GHM.Validator.Test.ValidateTests;

public class ValidateErrorTests
{
    private readonly string _message = "validation message";
    private readonly IValidate _validate;

    public ValidateErrorTests()
    {
        _validate = GhmValidatorProvider.GetValidateInstance();
    }

    [Fact]
    public void Test_ValidateIfTrue_Error()
    {
        // Arrange
        bool condition = false;

        // Act
        Validation result = _validate.IfTrue(condition, _message);

        // Assert
        Assert.Equal(ValidationType.IfTrue, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfFalse_Error()
    {
        // Arrange
        bool condition = true;

        // Act
        Validation result = _validate.IfFalse(condition, _message);

        // Assert
        Assert.Equal(ValidationType.IfFalse, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotDefault_Error()
    {
        // Arrange
        int obj = default;

        // Act
        Validation result = _validate.IfNotDefault(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotDefault, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotNull_Error()
    {
        // Arrange
        int? obj = null;

        // Act
        Validation result = _validate.IfNotNull(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotNull, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNull_Error()
    {
        // Arrange
        int? obj = 12;

        // Act
        Validation result = _validate.IfNull(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNull, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfEqual_Error()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 13;

        // Act
        Validation result = _validate.IfEqual(obj, objToCompare, _message);

        // Assert
        Assert.Equal(ValidationType.IfEqual, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotZero_Int_Error()
    {
        // Arrange
        int obj = 0;

        // Act
        Validation result = _validate.IfNotZero(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotZero, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotZero_Decimal_Error()
    {
        // Arrange
        decimal obj = 0;

        // Act
        Validation result = _validate.IfNotZero(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotZero, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfGreater_Int_Error()
    {
        // Arrange
        int obj = 12;
        int objEqual = 12;
        int objToCompare = 13;

        // Act
        Validation result = _validate.IfGreater(obj, objToCompare, _message);
        Validation resultEqual = _validate.IfGreater(obj, objEqual, _message);

        // Assert
        Assert.Equal(ValidationType.IfGreater, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);

        Assert.False(resultEqual.IsValid);
        Assert.Equal(_message, resultEqual.Message);
    }

    [Fact]
    public void Test_ValidateIfGreaterOrEqual_Int_Error()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 13;

        // Act
        Validation result = _validate.IfGreaterOrEqual(obj, objToCompare, _message);

        // Assert
        Assert.Equal(ValidationType.IfGreaterOrEqual, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfGreater_Decimal_Error()
    {
        // Arrange
        decimal obj = 12;
        decimal objEqual = 12;
        decimal objToCompare = 12.1M;

        // Act
        Validation result = _validate.IfGreater(obj, objToCompare, _message);
        Validation resultEqual = _validate.IfGreater(obj, objEqual, _message);

        // Assert
        Assert.Equal(ValidationType.IfGreater, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);

        Assert.False(resultEqual.IsValid);
        Assert.Equal(_message, resultEqual.Message);
    }

    [Fact]
    public void Test_ValidateIfGreaterOrEqual_Decimal_Error()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 12.1M;

        // Act
        Validation result = _validate.IfGreaterOrEqual(obj, objToCompare, _message);

        // Assert
        Assert.Equal(ValidationType.IfGreaterOrEqual, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotEmpty_String_Error()
    {
        // Arrange
        string obj = "";
        string objNull = null!;

        // Act
        Validation result = _validate.IfNotEmpty(obj, _message);
        Validation resultNull = _validate.IfNotEmpty(objNull, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotEmpty, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);

        Assert.False(resultNull.IsValid);
        Assert.Equal(_message, resultNull.Message);
    }

    [Fact]
    public void Test_ValidateIfParseToLong_Error()
    {
        // Arrange
        string obj = "12345-6";

        // Act
        Validation result = _validate.IfParseToLong(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfParseToLong, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotEmpty_IEnumerable_Error()
    {
        // Arrange
        string[] obj = Array.Empty<string>();

        // Act
        Validation result = _validate.IfNotEmpty(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotEmpty, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfOlder_Error()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;
        DateTime dateYongerEqual = DateTime.MaxValue;

        // Act
        Validation result = _validate.IfOlder(dateYonger, dateOlder, _message);
        Validation resultEqual = _validate.IfOlder(dateYongerEqual, dateYonger, _message);

        // Assert
        Assert.Equal(ValidationType.IfOlder, result.ValidationType);
        Assert.False(resultEqual.IsValid);
        Assert.False(resultEqual.IsValid);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfOlderOrEqual_Error()
    {
        // Arrange
        DateTime dateYonger = DateTime.MaxValue;
        DateTime dateOlder = DateTime.MinValue;

        // Act
        Validation result = _validate.IfOlderOrEqual(dateYonger, dateOlder, _message);

        Assert.False(result.IsValid);
        Assert.Equal(ValidationType.IfOlderOrEqual, result.ValidationType);
        Assert.Equal(_message, result.Message);
    }

    [Theory]
    [InlineData("gustavogmail.com")]
    [InlineData("123a.lalallalala")]
    [InlineData("123abc")]
    [InlineData("")]
    [InlineData(null)]
    public void Test_ValidateEmail_Error(string? mailAddress)
    {
        // Arrange

        // Act
        Validation result = _validate.IfEmail(mailAddress, _message);

        // Assert
        Assert.Equal(ValidationType.IfEmail, result.ValidationType);
        Assert.False(result.IsValid);
        Assert.Equal(_message, result.Message);
    }
}
