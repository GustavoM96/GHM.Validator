using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.IThrowerServiceTests;

public class IThrowerServiceSuccessTests
{
    private readonly IThrowerService _throwerService;
    private readonly string _message = "thrower message";

    public IThrowerServiceSuccessTests()
    {
        _throwerService = new Validator();
    }

    [Fact]
    public void Test_ThrowIfDefault_Success()
    {
        // Arrange
        int obj = 12;

        // Act
        var result = _throwerService.ThrowIfDefault(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfNotNull_Success()
    {
        // Arrange
        int? obj = null;

        // Act
        var result = _throwerService.ThrowIfNotNull(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfNull_Success()
    {
        // Arrange
        int? obj = 12;

        // Act
        var result = _throwerService.ThrowIfNull(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfNotEqual_Success()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 12;

        // Act
        var result = _throwerService.ThrowIfNotEqual(obj, objToCompare, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfZero_Int_Success()
    {
        // Arrange
        int obj = 12;

        // Act
        var result = _throwerService.ThrowIfZero(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfZero_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;

        // Act
        var result = _throwerService.ThrowIfZero(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfGreaterOrEqual_Int_Success()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 13;

        // Act
        var result = _throwerService.ThrowIfGreaterOrEqual(obj, objToCompare, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfGreater_Int_Success()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 13;
        int objEqual = 12;

        // Act
        var result = _throwerService.ThrowIfGreater(obj, objToCompare, _message);
        var resultEqual = _throwerService.ThrowIfGreater(obj, objEqual, _message);

        // Assert
        Assert.True(result);
        Assert.True(resultEqual);
    }

    [Fact]
    public void Test_ThrowIfGreaterOrEqual_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 12.1M;

        // Act
        var result = _throwerService.ThrowIfGreaterOrEqual(obj, objToCompare, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfGreater_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 13;
        decimal objEqual = 12;

        // Act
        var result = _throwerService.ThrowIfGreater(obj, objToCompare, _message);
        var resultEqual = _throwerService.ThrowIfGreater(obj, objEqual, _message);

        // Assert
        Assert.True(result);
        Assert.True(resultEqual);
    }

    [Fact]
    public void Test_ThrowIfEmpty_String_Success()
    {
        // Arrange
        string obj = "test";

        // Act
        var result = _throwerService.ThrowIfEmpty(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfNotParseToLong_Success()
    {
        // Arrange
        string obj = "123456";

        // Act
        var result = _throwerService.ThrowIfNotParseToLong(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfEmpty_IEnumerable_Success()
    {
        // Arrange
        string[] obj = new[] { "test" };

        // Act
        var result = _throwerService.ThrowIfEmpty(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfOlder_Success()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;
        DateTime dateYongerEqual = DateTime.MaxValue;

        // Act
        var result = _throwerService.ThrowIfOlder(dateYonger, dateOlder, _message);
        var resultEqual = _throwerService.ThrowIfOlder(dateYonger, dateYongerEqual, _message);

        // Assert
        Assert.True(result);
        Assert.True(resultEqual);
    }

    [Fact]
    public void Test_ThrowIfOlderOrEqual_Success()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;

        // Act
        var result = _throwerService.ThrowIfOlderOrEqual(dateYonger, dateOlder, _message);

        // Assert
        Assert.True(result);
    }
}
