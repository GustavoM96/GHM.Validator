using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.IValidationServiceTests;

public class IValidationServiceErrorTests
{
    private readonly string _message = "validation message";
    private readonly IValidate _validation;

    public IValidationServiceErrorTests()
    {
        _validation = new Validate();
    }

    [Fact]
    public void Test_ValidateIfNotDefault_Error()
    {
        // Arrange
        int obj = default;

        // Act
        var result = _validation.IfNotDefault(obj, _message);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotNull_Error()
    {
        // Arrange
        int? obj = null;

        // Act
        var result = _validation.IfNotNull(obj, _message);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNull_Error()
    {
        // Arrange
        int? obj = 12;

        // Act
        var result = _validation.IfNull(obj, _message);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfEqual_Error()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 13;

        // Act
        var result = _validation.IfEqual(obj, objToCompare, _message);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotZero_Int_Error()
    {
        // Arrange
        int obj = 0;

        // Act
        var result = _validation.IfNotZero(obj, _message);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotZero_Decimal_Error()
    {
        // Arrange
        decimal obj = 0;

        // Act
        var result = _validation.IfNotZero(obj, _message);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfGreater_Int_Error()
    {
        // Arrange
        int obj = 12;
        int objEqual = 12;
        int objToCompare = 13;

        // Act
        var result = _validation.IfGreater(obj, objToCompare, _message);
        var resultEqual = _validation.IfGreater(obj, objEqual, _message);

        // Assert
        Assert.False(result.IsValid);
        Assert.False(resultEqual.IsValid);
    }

    [Fact]
    public void Test_ValidateIfGreaterOrEqual_Int_Error()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 13;

        // Act
        var result = _validation.IfGreaterOrEqual(obj, objToCompare, _message);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfGreater_Decimal_Error()
    {
        // Arrange
        decimal obj = 12;
        decimal objEqual = 12;
        decimal objToCompare = 12.1M;

        // Act
        var result = _validation.IfGreater(obj, objToCompare, _message);
        var resultEqual = _validation.IfGreater(obj, objEqual, _message);

        // Assert
        Assert.False(result.IsValid);
        Assert.False(resultEqual.IsValid);
    }

    [Fact]
    public void Test_ValidateIfGreaterOrEqual_Decimal_Error()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 12.1M;

        // Act
        var result = _validation.IfGreaterOrEqual(obj, objToCompare, _message);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotEmpty_String_Error()
    {
        // Arrange
        string obj = "";
        string objNull = null!;

        // Act
        var result = _validation.IfNotEmpty(obj, _message);
        var resultNull = _validation.IfNotEmpty(objNull, _message);

        // Assert
        Assert.False(result.IsValid);
        Assert.False(resultNull.IsValid);
    }

    [Fact]
    public void Test_ValidateIfParseToLong_Error()
    {
        // Arrange
        string obj = "12345-6";

        // Act
        var result = _validation.IfParseToLong(obj, _message);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotEmpty_IEnumerable_Error()
    {
        // Arrange
        string[] obj = Array.Empty<string>();

        // Act
        var result = _validation.IfNotEmpty(obj, _message);

        // Assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfOlder_Error()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;
        DateTime dateYongerEqual = DateTime.MaxValue;

        // Act
        var result = _validation.IfOlder(dateYonger, dateOlder, _message);
        var resultEqual = _validation.IfOlder(dateYongerEqual, dateYonger, _message);

        // Assert
        Assert.False(resultEqual.IsValid);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfOlderOrEqual_Error()
    {
        // Arrange
        DateTime dateYonger = DateTime.MaxValue;
        DateTime dateOlder = DateTime.MinValue;

        // Act
        var result = _validation.IfOlderOrEqual(dateYonger, dateOlder, _message);

        Assert.False(result.IsValid);
    }
}
