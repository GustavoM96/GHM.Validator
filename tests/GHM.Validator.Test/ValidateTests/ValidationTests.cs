using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.ValidateTests;

public class ValidationTests
{
    private readonly string _message = "validation message";

    [Fact]
    public void Test_ValidationSuccess_WhenSet_AsNotFound_ShouldHave_ErrorTypeNull()
    {
        // Arrange

        // Act
        var result = Validation.Success(_message).AsNotFound();

        // Assert
        Assert.True(result.IsValid);
        Assert.Null(result.ErrorType);
    }

    [Fact]
    public void Test_ValidationError_WhenNotSet_ErrorType_ShouldHave_ErrorTypeValidationByDefault()
    {
        // Arrange

        // Act
        var result = Validation.Error(_message);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(ErrorType.Validation, result.ErrorType);
    }

    [Fact]
    public void Test_ValidationError_WhenSet_AsNotFound_ShouldHave_ErrorTypeNotFound()
    {
        // Arrange

        // Act
        var result = Validation.Error(_message).AsNotFound();

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(ErrorType.NotFound, result.ErrorType);
    }

    [Fact]
    public void Test_Validation_WithTitle_ShouldSet_TitleProperty()
    {
        // Arrange
        var title = "test title";

        // Act
        var result = Validation.Success(_message).WithTitle(title);
        var result2 = Validation.Error(_message).WithTitle(title);

        // Assert
        Assert.Equal(title, result.Title);
        Assert.Equal(title, result2.Title);
    }
}
