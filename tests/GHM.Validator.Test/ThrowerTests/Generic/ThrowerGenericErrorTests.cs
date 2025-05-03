using GHM.Validator.Interfaces;
using GHM.Validator.Test.Common;

namespace GHM.Validator.Test.ThrowerTests.Generic;

public class ThrowerGenericErrorTests
{
    private readonly IThrower _thrower;
    private readonly IThrower _throwerFileLoadException;
    private readonly string _message = "thrower message";

    public ThrowerGenericErrorTests()
    {
        _thrower = GhmValidatorProvider.GetThrowerInstance();
        _throwerFileLoadException = GhmValidatorProvider.GetThrowerInstance(config =>
            config.ExceptionThrower = (message) => new FileLoadException(message)
        );
    }

    [Fact]
    public void Test_Thrower_When_PassExceptionByMethod_ShouldReplace_InnerThower()
    {
        // Arrange
        int obj = default;

        // Act
        void GetResult() => _throwerFileLoadException.IfDefault<AggregateException, int>(obj, _message);

        // Assert
        Assert.Throws<AggregateException>(GetResult);
    }

    [Fact]
    public void Test_ThrowIfTrue_Error()
    {
        // Arrange
        bool condition = true;

        // Act
        void GetResult() => _thrower.IfTrue<AggregateException>(condition, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfFalse_Error()
    {
        // Arrange
        bool condition = false;

        // Act
        void GetResult() => _thrower.IfFalse<AggregateException>(condition, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfDefault_Error()
    {
        // Arrange
        int obj = default;

        // Act
        void GetResult() => _thrower.IfDefault<AggregateException, int>(obj, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfNotNull_Error()
    {
        // Arrange
        int? obj = 12;

        // Act
        void GetResult() => _thrower.IfNotNull<AggregateException>(obj, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfNull_Error()
    {
        // Arrange
        int? obj = null;

        // Act
        void GetResult() => _thrower.IfNull<AggregateException>(obj, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfNotEqual_Error()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 11;

        // Act
        void GetResult() => _thrower.IfNotEqual<AggregateException>(obj, objToCompare, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfZero_Int_Error()
    {
        // Arrange
        int obj = 0;

        // Act
        void GetResult() => _thrower.IfZero<AggregateException>(obj, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfZero_Decimal_Error()
    {
        // Arrange
        decimal obj = 0;

        // Act
        void GetResult() => _thrower.IfZero<AggregateException>(obj, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfGreaterOrEqual_Int_Error()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 11;
        int objToCompareEqual = 12;

        // Act
        void GetResult() => _thrower.IfGreaterOrEqual<AggregateException>(obj, objToCompare, _message);

        void GetResultEqual() => _thrower.IfGreaterOrEqual<AggregateException>(obj, objToCompareEqual, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
        AggregateException equalEx = Assert.Throws<AggregateException>(GetResultEqual);
        Assert.Equal(_message, equalEx.Message);
    }

    [Fact]
    public void Test_ThrowIfGreater_Int_Error()
    {
        // Arrange
        int obj = 12;
        int objToCompare = 11;

        // Act
        void GetResult() => _thrower.IfGreater<AggregateException>(obj, objToCompare, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfGreaterOrEqual_Decimal_Error()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 11;
        decimal objToCompareEqual = 12;

        // Act
        void GetResult() => _thrower.IfGreaterOrEqual<AggregateException>(obj, objToCompare, _message);

        void GetResultEqual() => _thrower.IfGreaterOrEqual<AggregateException>(obj, objToCompareEqual, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
        AggregateException equalEx = Assert.Throws<AggregateException>(GetResultEqual);
        Assert.Equal(_message, equalEx.Message);
    }

    [Fact]
    public void Test_ThrowIfGreater_Decimal_Error()
    {
        // Arrange
        decimal obj = 12;
        decimal objToCompare = 11;

        // Act
        void GetResult() => _thrower.IfGreater<AggregateException>(obj, objToCompare, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfEmpty_String_Error()
    {
        // Arrange
        string obj = "";
        string objNull = null!;

        // Act
        void GetResult() => _thrower.IfEmpty<AggregateException>(obj, _message);
        void GetResultNull() => _thrower.IfEmpty<AggregateException>(objNull, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
        AggregateException equalEx = Assert.Throws<AggregateException>(GetResultNull);
        Assert.Equal(_message, equalEx.Message);
    }

    [Fact]
    public void Test_ThrowIfNotParseToLong_Error()
    {
        // Arrange
        string obj = "12345-6";

        // Act
        void GetResult() => _thrower.IfNotParseToLong<AggregateException>(obj, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfEmpty_IEnumerable_Error()
    {
        // Arrange
        string[] obj = Array.Empty<string>();

        // Act
        void GetResult() => _thrower.IfEmpty<AggregateException, string>(obj, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfOlder_Error()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;

        // Act
        void GetResult() => _thrower.IfOlder<AggregateException>(dateOlder, dateYonger, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }

    [Fact]
    public void Test_ThrowIfOlderOrEqual_Error()
    {
        // Arrange
        DateTime dateOlder = DateTime.MinValue;
        DateTime dateYonger = DateTime.MaxValue;
        DateTime dateOlderEqual = DateTime.MinValue;

        // Act
        void GetResult() => _thrower.IfOlder<AggregateException>(dateOlder, dateYonger, _message);
        void GetResultEqual() => _thrower.IfOlderOrEqual<AggregateException>(dateOlder, dateOlderEqual, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
        AggregateException equalEx = Assert.Throws<AggregateException>(GetResultEqual);
        Assert.Equal(_message, equalEx.Message);
    }

    [Theory]
    [InlineData("gustavogmail.com")]
    [InlineData("123a.lalallalala")]
    [InlineData("123abc")]
    [InlineData("")]
    [InlineData(null)]
    public void Test_ThrowIfNotEmail_Error(string? mailAddress)
    {
        // Arrange

        // Act
        void GetResult() => _thrower.IfNotEmail<AggregateException>(mailAddress, _message);

        // Assert
        AggregateException ex = Assert.Throws<AggregateException>(GetResult);
        Assert.Equal(_message, ex.Message);
    }
}
