namespace GHM.Validator.Test.ThrowerTests;

public class ValidationExceptionTests
{
    [Fact]
    public void Test_Constructors()
    {
        // Arrange
        string errorMessage = "error exception teste";
        var innerException = new Exception("inner exception");
        var errors = new List<Error> { Error.Conflict("Error 1"), Error.NotFound("Error 2") };

        // Act
        var exception1 = new ValidationException(errorMessage, errors);
        var exception2 = new ValidationException(errorMessage, innerException, errors);
        var exception3 = new ValidationException(errors);

        //Assert
        Assert.Equal(errorMessage, exception1.Message);
        Assert.Equal(errorMessage, exception2.Message);

        Assert.Equal(innerException, exception2.InnerException);

        Assert.Equal(errors, exception1.Errors);
        Assert.Equal(errors, exception2.Errors);
        Assert.Equal(errors, exception3.Errors);
    }

    [Fact]
    public void Test_ErrorType()
    {
        // Arrange
        var innerException = new Exception("inner exception");
        var conflict = Error.Conflict("Error 1");
        var notFound = Error.NotFound("Error 2");

        // Act
        var exceptionWithEmptyErrors = new ValidationException(new List<Error>());
        var exceptionWithConflictError = new ValidationException(new List<Error>() { conflict });
        var exceptionWith2Errors = new ValidationException(new List<Error>() { conflict, notFound });

        //Assert
        Assert.Null(exceptionWithEmptyErrors.ErrorType);
        Assert.Equal(ErrorType.Conflict, exceptionWithConflictError.ErrorType);
        Assert.Equal(ErrorType.ManyErrors, exceptionWith2Errors.ErrorType);
    }
}
