using GHM.Validator.Interfaces;
using GHM.Validator.Test.Common;

namespace GHM.Validator.Test.ThrowerTests;

public class ThrowerSuccessTests
{
    private readonly IThrower _thrower;
    private readonly string _message = "thrower message";

    public ThrowerSuccessTests()
    {
        _thrower = GhmValidatorProvider.GetThrowerInstance();
    }

    [Fact]
    public void Test_ThrowIfTrue_Success()
    {
        // Arrange
        bool condition = false;

        // Act
        bool result = _thrower.IfTrue(condition, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfFalse_Success()
    {
        // Arrange
        bool condition = true;

        // Act
        bool result = _thrower.IfFalse(condition, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfDefault_Success()
    {
        // Arrange
        int obj = 12;

        // Act
        bool result = _thrower.IfDefault(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfNotNull_Success()
    {
        // Arrange
        int? obj = null;

        // Act
        bool result = _thrower.IfNotNull(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfNull_Success()
    {
        // Arrange
        int? obj = 12;

        // Act
        bool result = _thrower.IfNull(obj, _message);

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
        bool result = _thrower.IfNotEqual(obj, objToCompare, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfZero_Int_Success()
    {
        // Arrange
        int obj = 12;

        // Act
        bool result = _thrower.IfZero(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfZero_Decimal_Success()
    {
        // Arrange
        decimal obj = 12;

        // Act
        bool result = _thrower.IfZero(obj, _message);

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
        bool result = _thrower.IfGreaterOrEqual(obj, objToCompare, _message);

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
        bool result = _thrower.IfGreater(obj, objToCompare, _message);
        bool resultEqual = _thrower.IfGreater(obj, objEqual, _message);

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
        bool result = _thrower.IfGreaterOrEqual(obj, objToCompare, _message);

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
        bool result = _thrower.IfGreater(obj, objToCompare, _message);
        bool resultEqual = _thrower.IfGreater(obj, objEqual, _message);

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
        bool result = _thrower.IfEmpty(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfNotParseToLong_Success()
    {
        // Arrange
        string obj = "123456";

        // Act
        bool result = _thrower.IfNotParseToLong(obj, _message);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ThrowIfEmpty_IEnumerable_Success()
    {
        // Arrange
        string[] obj = new[] { "test" };

        // Act
        bool result = _thrower.IfEmpty(obj, _message);

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
        bool result = _thrower.IfOlder(dateYonger, dateOlder, _message);
        bool resultEqual = _thrower.IfOlder(dateYonger, dateYongerEqual, _message);

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
        bool result = _thrower.IfOlderOrEqual(dateYonger, dateOlder, _message);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("gustavo.hmessias96@gmail.com")]
    [InlineData("gustavo.hmessias96@teste123.com.br")]
    [InlineData("123@teste123.com")]
    public void Test_ThrowIfNotEmail_Error(string mailAddress)
    {
        // Arrange

        // Act
        bool result = _thrower.IfNotEmail(mailAddress, _message);

        // Assert
        Assert.True(result);
    }
}
