using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.ThrowerTests;

public class ThrowerErrorTests
{
    private readonly IThrower _thrower;
    private readonly string _message = "thrower message";

    public ThrowerErrorTests()
    {
        _thrower = new Thrower();
    }

    [Fact]
    public void Test_Create_ShouldReturn_Thower()
    {
        // Arrange
        int obj = default;
        var thrower = new Thrower((message) => new FileLoadException(message));

        // Act
        void GetResult() => thrower.IfDefault(obj, _message);

        // Assert
        Assert.Throws<FileLoadException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfTrue_Error()
    {
        // Arrange
        bool condition = true;

        // Act
        void GetResult() => _thrower.IfTrue(condition, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfFalse_Error()
    {
        // Arrange
        bool condition = false;

        // Act
        void GetResult() => _thrower.IfFalse(condition, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfDefault_Error()
    {
        // Arrange
        int obj = default;

        // Act
        void GetResult() => _thrower.IfDefault(obj, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfNotNull_Error()
    {
        // Arrange
        int? obj = 12;

        // Act
        void GetResult() => _thrower.IfNotNull(obj, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfNull_Error()
    {
        // Arrange
        int? obj = null;

        // Act
        void GetResult() => _thrower.IfNull(obj, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfNotEqual_Error()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 11;

        // Act
        void GetResult() => _thrower.IfNotEqual(obj, objToCompare, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfZero_Int_Error()
    {
        // Arrange
        int obj = 0;

        // Act
        void GetResult() => _thrower.IfZero(obj, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfZero_Decimal_Error()
    {
        // Arrange
        decimal obj = 0;

        // Act
        void GetResult() => _thrower.IfZero(obj, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfGreaterOrEqual_Int_Error()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 11;
        int objToCompareEqual = 12;

        // Act
        void GetResult() => _thrower.IfGreaterOrEqual(obj, objToCompare, _message);

        void GetResultEqual() => _thrower.IfGreaterOrEqual(obj, objToCompareEqual, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
        Assert.Throws<ArgumentException>(GetResultEqual);
    }

    [Fact]
    public void Test_ThrowIfGreater_Int_Error()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 11;

        // Act
        void GetResult() => _thrower.IfGreater(obj, objToCompare, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfGreaterOrEqual_Decimal_Error()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 11;
        decimal objToCompareEqual = 12;

        // Act
        void GetResult() => _thrower.IfGreaterOrEqual(obj, objToCompare, _message);

        void GetResultEqual() => _thrower.IfGreaterOrEqual(obj, objToCompareEqual, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
        Assert.Throws<ArgumentException>(GetResultEqual);
    }

    [Fact]
    public void Test_ThrowIfGreater_Decimal_Error()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 11;

        // Act
        void GetResult() => _thrower.IfGreater(obj, objToCompare, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfEmpty_String_Error()
    {
        // Arrange
        string obj = "";
        string objNull = null!;

        // Act
        void GetResult() => _thrower.IfEmpty(obj, _message);
        void GetResultNull() => _thrower.IfEmpty(objNull, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
        Assert.Throws<ArgumentException>(GetResultNull);
    }

    [Fact]
    public void Test_ThrowIfNotParseToLong_Error()
    {
        // Arrange
        string obj = "12345-6";

        // Act
        void GetResult() => _thrower.IfNotParseToLong(obj, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfEmpty_IEnumerable_Error()
    {
        // Arrange
        string[] obj = Array.Empty<string>();

        // Act
        void GetResult() => _thrower.IfEmpty(obj, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfOlder_Error()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;

        // Act
        void GetResult() => _thrower.IfOlder(dateOlder, dateYonger, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfOlderOrEqual_Error()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;
        DateTime dateOlderEqual = DateTime.MinValue;

        // Act
        void GetResult() => _thrower.IfOlder(dateOlder, dateYonger, _message);
        void GetResultEqual() => _thrower.IfOlderOrEqual(dateOlder, dateOlderEqual, _message);

        // Assert
        Assert.Throws<ArgumentException>(GetResult);
        Assert.Throws<ArgumentException>(GetResultEqual);
    }
}
