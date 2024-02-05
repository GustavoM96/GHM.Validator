using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.ValidateTests;

public class ValidateErrorTypeTests
{
    private readonly string _message = "validation message";
    private readonly IValidate _validate;

    public ValidateErrorTypeTests()
    {
        _validate = new Validate();
    }

    [Fact]
    public void Test_ValidateIfTrue_Success_AsNotFound_ShouldHave_ErrorTypeNull()
    {
        // Arrange
        bool condition = true;

        // Act
        var result = _validate.IfTrue(condition, _message).AsNotFound();

        // Assert
        Assert.True(result.IsValid);
        Assert.Null(result.ErrorType);
    }

    [Fact]
    public void Test_ValidateIfTrue_Error_AsNotFound_ShouldHave_ErrorTypeNotFound()
    {
        // Arrange
        bool condition = false;

        // Act
        var result = _validate.IfTrue(condition, _message).AsNotFound();

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(ErrorType.NotFound, result.ErrorType);
    }

    [Fact]
    public void Test_ValidationList_Success_AsNotFound_ShouldHave_ErrorTypeNull()
    {
        // Arrange
        bool condition = true;

        // Act
        ValidationList result =
            new() { _validate.IfTrue(condition, _message).AsNotFound(), _validate.IfTrue(condition, _message).AsNotFound() };

        // Assert
        Assert.True(result.IsValid);
        Assert.Null(result.ErrorType);
    }

    [Fact]
    public void Test_ValidationList_Error_AsNotFound_ShouldHave_ErrorTypeNotFound()
    {
        // Arrange
        bool condition = true;

        // Act
        ValidationList result =
            new()
            {
                _validate.IfTrue(condition, _message).AsNotFound(),
                _validate.IfTrue(!condition, _message).AsNotFound()
            };

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(ErrorType.NotFound, result.ErrorType);
    }

    [Fact]
    public void Test_ValidationList_MultiplesErrors_ShouldHave_ErrorTypeFailure()
    {
        // Arrange
        bool condition = true;

        // Act
        ValidationList result =
            new()
            {
                _validate.IfTrue(condition, _message).AsNotFound(),
                _validate.IfTrue(!condition, _message).AsNotFound(),
                _validate.IfTrue(!condition, _message).AsConflict()
            };

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(ErrorType.Failure, result.ErrorType);
    }
}
