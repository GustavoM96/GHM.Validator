using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.IValidationServiceTests;

public class IValidationServiceSuccessTests
{
    private readonly string _message = "validation message";
    private readonly IValidationService _validationService;

    public IValidationServiceSuccessTests()
    {
        _validationService = new Validator();
    }

    [Fact]
    public void Test_ValidateIfNotDefault_Success()
    {
        // Arrange
        int obj = 12;

        // Act
        var result = _validationService.ValidateIfNotDefault(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotNull_Success()
    {
        // Arrange
        int? obj = 12;

        // Act
        var result = _validationService.ValidateIfNotNull(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNull_Success()
    {
        // Arrange
        int? obj = null;

        // Act
        var result = _validationService.ValidateIfNull(obj, _message);

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
        var result = _validationService.ValidateIfEqual(obj, objToCompare, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotZero_Int_Success()
    {
        // Arrange
        int obj = 12;

        // Act
        var result = _validationService.ValidateIfNotZero(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotZero_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;

        // Act
        var result = _validationService.ValidateIfNotZero(obj, _message);

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
        var result = _validationService.ValidateIfGreater(obj, objToCompare, _message);

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
        var result = _validationService.ValidateIfGreaterOrEqual(obj, objToCompare, _message);
        var resultEqual = _validationService.ValidateIfGreaterOrEqual(obj, objEqual, _message);

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
        var result = _validationService.ValidateIfGreater(obj, objToCompare, _message);

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
        var result = _validationService.ValidateIfGreaterOrEqual(obj, objToCompare, _message);
        var resultEqual = _validationService.ValidateIfGreaterOrEqual(obj, objEqual, _message);

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
        var result = _validationService.ValidateIfNotEmpty(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfParseToLong_Success()
    {
        // Arrange
        string obj = "123456";

        // Act
        var result = _validationService.ValidateIfParseToLong(obj, _message);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Test_ValidateIfNotEmpty_IEnumerable_Success()
    {
        // Arrange
        string[] obj = new[] { "test" };

        // Act
        var result = _validationService.ValidateIfNotEmpty(obj, _message);

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
        var result = _validationService.ValidateIfOlderOrEqual(dateOlder, dateYonger, _message);
        var resultEqual = _validationService.ValidateIfOlderOrEqual(dateYonger, dateYongerEqual, _message);

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
        var result = _validationService.ValidateIfOlder(dateOlder, dateYonger, _message);

        // Assert
        Assert.True(result.IsValid);
    }
}
