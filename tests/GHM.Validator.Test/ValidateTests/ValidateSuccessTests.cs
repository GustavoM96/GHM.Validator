using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.ValidateTests;

public class ValidateSuccessTests
{
    private readonly string _message = "validation message";
    private readonly IValidate _validate;

    public ValidateSuccessTests()
    {
        _validate = new Validate();
    }

    [Fact]
    public void Test_ValidateIfTrue_Success()
    {
        // Arrange
        bool condition = true;

        // Act
        var result = _validate.IfTrue(condition, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfFalse_Success()
    {
        // Arrange
        bool condition = false;

        // Act
        var result = _validate.IfFalse(condition, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotDefault_Success()
    {
        // Arrange
        int obj = 12;

        // Act
        var result = _validate.IfNotDefault(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotNull_Success()
    {
        // Arrange
        int? obj = 12;

        // Act
        var result = _validate.IfNotNull(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNull_Success()
    {
        // Arrange
        int? obj = null;

        // Act
        var result = _validate.IfNull(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfEqual_Success()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 12;

        // Act
        var result = _validate.IfEqual(obj, objToCompare, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotZero_Int_Success()
    {
        // Arrange
        int obj = 12;

        // Act
        var result = _validate.IfNotZero(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotZero_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;

        // Act
        var result = _validate.IfNotZero(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfGreater_Int_Success()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 11;

        // Act
        var result = _validate.IfGreater(obj, objToCompare, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfGreaterOrEqual_Int_Success()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 11;
        int objEqual = 12;

        // Act
        var result = _validate.IfGreaterOrEqual(obj, objToCompare, _message);
        var resultEqual = _validate.IfGreaterOrEqual(obj, objEqual, _message);

        // Assert
        Assert.True(result.IsValid);
        Assert.True(resultEqual.IsValid);
    }

    [Fact]
    public void Test_ValidateIfGreater_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 11.9M;

        // Act
        var result = _validate.IfGreater(obj, objToCompare, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfGreaterOrEqual_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 11.9M;
        decimal objEqual = 12;

        // Act
        var result = _validate.IfGreaterOrEqual(obj, objToCompare, _message);
        var resultEqual = _validate.IfGreaterOrEqual(obj, objEqual, _message);

        // Assert
        Assert.True(result.IsValid);
        Assert.True(resultEqual.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotEmpty_String_Success()
    {
        // Arrange
        string obj = "test";

        // Act
        var result = _validate.IfNotEmpty(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfParseToLong_Success()
    {
        // Arrange
        string obj = "123456";

        // Act
        var result = _validate.IfParseToLong(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotEmpty_IEnumerable_Success()
    {
        // Arrange
        string[] obj = new[] { "test" };

        // Act
        var result = _validate.IfNotEmpty(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfOlderOrEqual_Success()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;
        DateTime dateYongerEqual = DateTime.MaxValue;

        // Act
        var result = _validate.IfOlderOrEqual(dateOlder, dateYonger, _message);
        var resultEqual = _validate.IfOlderOrEqual(dateYonger, dateYongerEqual, _message);

        // Assert
        Assert.True(result.IsValid);
        Assert.True(resultEqual.IsValid);
    }

    [Fact]
    public void Test_ValidateIfOlder_Success()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;

        // Act
        var result = _validate.IfOlder(dateOlder, dateYonger, _message);

        // Assert
        Assert.True(result.IsValid);
    }
}
