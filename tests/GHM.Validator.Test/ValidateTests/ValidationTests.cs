namespace GHM.Validator.Test.ValidateTests;

public class ValidationTests
{
    private readonly string _message = "validation message";

    [Fact]
    public void Test_ValidationSuccess_WhenSet_AsNotFound_ShouldHave_ErrorTypeNull()
    {
        // Arrange

        // Act
        Validation result = Validation.Success(_message).AsNotFound();

        // Assert
        Assert.True(result.IsValid);
        Assert.Null(result.ErrorType);
    }

    [Fact]
    public void Test_ValidationError_WhenNotSet_ErrorType_ShouldHave_ErrorTypeValidationByDefault()
    {
        // Arrange

        // Act
        Validation result = Validation.Error(_message);

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(ErrorType.Validation, result.ErrorType);
    }

    [Fact]
    public void Test_ValidationError_WhenSet_AsNotFound_ShouldHave_ErrorTypeNotFound()
    {
        // Arrange

        // Act
        Validation result = Validation.Error(_message).AsNotFound();

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(ErrorType.NotFound, result.ErrorType);
    }

    [Fact]
    public void Test_Validation_WithTitle_ShouldSet_TitleProperty()
    {
        // Arrange
        string title = "test title";

        // Act
        Validation result = Validation.Success(_message).WithTitle(title);
        Validation result2 = Validation.Error(_message).WithTitle(title);

        // Assert
        Assert.Equal(title, result.Title);
        Assert.Equal(title, result2.Title);
    }

    [Fact]
    public void Test_Validation_WithErrorType_ShouldHave_ErrorTypeCorrect()
    {
        // Arrange

        // Act
        Validation asFailure = Validation.Error(_message).AsFailure();
        Validation asNotFound = Validation.Error(_message).AsNotFound();
        Validation asUnexpected = Validation.Error(_message).AsUnexpected();
        Validation asValidation = Validation.Error(_message).AsValidation();
        Validation asConflict = Validation.Error(_message).AsConflict();
        Validation asUnauthorized = Validation.Error(_message).AsUnauthorized();

        // Assert
        Assert.Equal(ErrorType.Failure, asFailure.ErrorType);
        Assert.Equal(ErrorType.NotFound, asNotFound.ErrorType);
        Assert.Equal(ErrorType.Unexpected, asUnexpected.ErrorType);
        Assert.Equal(ErrorType.Validation, asValidation.ErrorType);
        Assert.Equal(ErrorType.Conflict, asConflict.ErrorType);
        Assert.Equal(ErrorType.Unauthorized, asUnauthorized.ErrorType);
    }

    [Fact]
    public void Test_Validation_BindError_WhenError_ShouldBind_Data()
    {
        // Arrange

        // Act
        Error error = Error.Conflict("invalid data", "Movie.Title");
        Validation result = Validation.Error(_message).BindError(error);

        // Assert
        Assert.NotEqual(_message, result.Message);
        Assert.False(result.IsValid);

        Assert.Equal(error.Title, result.Title);
        Assert.Equal(error.Message, result.Message);
        Assert.Equal(error.ErrorType, result.ErrorType);
    }

    [Fact]
    public void Test_Validation_BindError_WhenSucces_ShouldNotBind_Data()
    {
        // Arrange

        // Act
        Error error = Error.Conflict("invalid title", "Movie.Title");
        Validation result = Validation.Success(_message).BindError(error);

        // Assert
        Assert.Equal(_message, result.Message);
        Assert.True(result.IsValid);

        Assert.NotEqual(error.Title, result.Title);
        Assert.NotEqual(error.Message, result.Message);
        Assert.NotEqual(error.ErrorType, result.ErrorType);
    }
}
