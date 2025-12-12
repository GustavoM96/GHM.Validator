using GHM.Validator.Core.Enum;
using GHM.Validator.Interfaces;
using GHM.Validator.Test.Common;

namespace GHM.Validator.Test.ValidateTests;

public class ValidateSuccessTests
{
    private readonly string _message = "validation message";
    private readonly IValidate _validate;

    public ValidateSuccessTests()
    {
        _validate = GhmValidatorProvider.GetValidateInstance();
    }

    [Fact]
    public void Test_ValidateIfTrue_Success()
    {
        // Arrange
        bool condition = true;

        // Act
        Validation result = _validate.IfTrue(condition, _message);

        // Assert
        Assert.Equal(ValidationType.IfTrue, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfFalse_Success()
    {
        // Arrange
        bool condition = false;

        // Act
        Validation result = _validate.IfFalse(condition, _message);

        // Assert
        Assert.Equal(ValidationType.IfFalse, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotDefault_Success()
    {
        // Arrange
        int obj = 12;

        // Act
        Validation result = _validate.IfNotDefault(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotDefault, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotNull_Success()
    {
        // Arrange
        int? obj = 12;

        // Act
        Validation result = _validate.IfNotNull(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotNull, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNull_Success()
    {
        // Arrange
        int? obj = null;

        // Act
        Validation result = _validate.IfNull(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNull, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfEqual_Success()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 12;

        // Act
        Validation result = _validate.IfEqual(obj, objToCompare, _message);

        // Assert
        Assert.Equal(ValidationType.IfEqual, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotZero_Int_Success()
    {
        // Arrange
        int obj = 12;

        // Act
        Validation result = _validate.IfNotZero(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotZero, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotZero_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;

        // Act
        Validation result = _validate.IfNotZero(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotZero, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfGreater_Int_Success()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 11;

        // Act
        Validation result = _validate.IfGreater(obj, objToCompare, _message);

        // Assert
        Assert.Equal(ValidationType.IfGreater, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfGreaterOrEqual_Int_Success()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 11;
        int objEqual = 12;

        // Act
        Validation result = _validate.IfGreaterOrEqual(obj, objToCompare, _message);
        Validation resultEqual = _validate.IfGreaterOrEqual(obj, objEqual, _message);

        // Assert
        Assert.Equal(ValidationType.IfGreaterOrEqual, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
        Assert.True(resultEqual.IsValid);
        Assert.Equal(_message, resultEqual.Message);
    }

    [Fact]
    public void Test_ValidateIfGreater_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 11.9M;

        // Act
        Validation result = _validate.IfGreater(obj, objToCompare, _message);

        // Assert
        Assert.Equal(ValidationType.IfGreater, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfGreaterOrEqual_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 11.9M;
        decimal objEqual = 12;

        // Act
        Validation result = _validate.IfGreaterOrEqual(obj, objToCompare, _message);
        Validation resultEqual = _validate.IfGreaterOrEqual(obj, objEqual, _message);

        // Assert
        Assert.Equal(ValidationType.IfGreaterOrEqual, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
        Assert.True(resultEqual.IsValid);
        Assert.Equal(_message, resultEqual.Message);
    }

    [Fact]
    public void Test_ValidateIfNotEmpty_String_Success()
    {
        // Arrange
        string obj = "test";

        // Act
        Validation result = _validate.IfNotEmpty(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotEmpty, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfParseToLong_Success()
    {
        // Arrange
        string obj = "123456";

        // Act
        Validation result = _validate.IfParseToLong(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfParseToLong, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfNotEmpty_IEnumerable_Success()
    {
        // Arrange
        string[] obj = new[] { "test" };

        // Act
        Validation result = _validate.IfNotEmpty(obj, _message);

        // Assert
        Assert.Equal(ValidationType.IfNotEmpty, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Fact]
    public void Test_ValidateIfOlderOrEqual_Success()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;
        DateTime dateYongerEqual = DateTime.MaxValue;

        // Act
        Validation result = _validate.IfOlderOrEqual(dateOlder, dateYonger, _message);
        Validation resultEqual = _validate.IfOlderOrEqual(dateYonger, dateYongerEqual, _message);

        // Assert
        Assert.Equal(ValidationType.IfOlderOrEqual, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
        Assert.True(resultEqual.IsValid);
        Assert.Equal(_message, resultEqual.Message);
    }

    [Fact]
    public void Test_ValidateIfOlder_Success()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;

        // Act
        Validation result = _validate.IfOlder(dateOlder, dateYonger, _message);

        // Assert
        Assert.Equal(ValidationType.IfOlder, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }

    [Theory]
    [InlineData("gustavo.hmessias96@gmail.com")]
    [InlineData("gustavo.hmessias96@teste123.com.br")]
    [InlineData("123@teste123.com")]
    public void Test_ValidateEmail_Success(string mailAddress)
    {
        // Arrange

        // Act
        Validation result = _validate.IfEmail(mailAddress, _message);

        // Assert
        Assert.Equal(ValidationType.IfEmail, result.ValidationType);
        Assert.True(result.IsValid);
        Assert.Equal(_message, result.Message);
    }
}
