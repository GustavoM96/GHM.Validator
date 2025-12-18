namespace GHM.Validator.Test.ValidateTests;

public class ErrorTests
{
    [Fact]
    public void Test_Error_Constructor()
    {
        // Arrange
        // Act
        var notFoundError = Error.NotFound("test notFound", "test title");
        var conflictError = Error.Conflict("test conflict", "test title");
        var failureError = Error.Failure("test failure", "test title");
        var unexpectedError = Error.Unexpected("test unexpected", "test title");
        var unauthorizedError = Error.Unauthorized("test unauthorized", "test title");
        var validationError = Error.Validation("test validation", "test title");

        // Assert
        Assert.Equal("test notFound", notFoundError.Message);
        Assert.Equal("test conflict", conflictError.Message);
        Assert.Equal("test failure", failureError.Message);
        Assert.Equal("test unexpected", unexpectedError.Message);
        Assert.Equal("test unauthorized", unauthorizedError.Message);
        Assert.Equal("test validation", validationError.Message);

        Assert.Equal("test title", notFoundError.Title);
        Assert.Equal("test title", conflictError.Title);
        Assert.Equal("test title", failureError.Title);
        Assert.Equal("test title", unexpectedError.Title);
        Assert.Equal("test title", unauthorizedError.Title);
        Assert.Equal("test title", validationError.Title);

        Assert.Equal(ErrorType.NotFound, notFoundError.ErrorType);
        Assert.Equal(ErrorType.Conflict, conflictError.ErrorType);
        Assert.Equal(ErrorType.Failure, failureError.ErrorType);
        Assert.Equal(ErrorType.Unexpected, unexpectedError.ErrorType);
        Assert.Equal(ErrorType.Unauthorized, unauthorizedError.ErrorType);
        Assert.Equal(ErrorType.Validation, validationError.ErrorType);

        Assert.False(notFoundError.IsValid);
        Assert.False(conflictError.IsValid);
        Assert.False(failureError.IsValid);
        Assert.False(unexpectedError.IsValid);
        Assert.False(unauthorizedError.IsValid);
        Assert.False(validationError.IsValid);
    }

    [Fact]
    public void Test_ToValidation()
    {
        // Arrange
        var error = Error.Failure("test failure", "test title");
        // Act
        var validation = error.ToValidation();
        // Assert
        Assert.False(validation.IsValid);
        Assert.Equal("test failure", validation.Message);
        Assert.Equal("test title", validation.Title);
        Assert.Equal(ErrorType.Failure, validation.ErrorType);
    }

    [Fact]
    public void Test_FromValidation()
    {
        // Arrange
        var validation = Validation.Error("test error").AsUnauthorized().WithTitle("test title");
        // Act
        var error = Error.FromValidation(validation);
        // Assert
        Assert.False(error.IsValid);
        Assert.Equal("test error", error.Message);
        Assert.Equal("test title", error.Title);
        Assert.Equal(ErrorType.Unauthorized, error.ErrorType);
    }
}
