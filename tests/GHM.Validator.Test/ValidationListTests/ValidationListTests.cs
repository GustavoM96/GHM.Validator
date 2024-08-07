namespace GHM.Validator.Test.ValidationListTests;

public class ValidationListTests
{
    private static Validation ErrorValidation => Validation.Error("error test").AsNotFound();
    private static Validation ErrorValidation2 => Validation.Error("error test2");
    private static Validation SuccessValidation => Validation.Success("success test");
    private static ValidationList ErrorValidationList => new() { ErrorValidation, ErrorValidation2, SuccessValidation };
    private static ValidationList SuccessValidationList => new() { SuccessValidation };

    [Fact]
    public void Test_ValidationList_When_HasErrorItems_ShouldSet_IsErrorEqualTrue_And_IsValidFalse()
    {
        // Arrange
        var validationListSuccess = new ValidationList();
        var validationListSuccess2 = new ValidationList(1) { SuccessValidation };
        var validationListError = new ValidationList(new Validation[] { ErrorValidation });

        // Act

        //Assert
        Assert.False(validationListSuccess.IsError);
        Assert.False(validationListSuccess2.IsError);
        Assert.True(validationListError.IsError);

        Assert.True(validationListSuccess.IsValid);
        Assert.True(validationListSuccess2.IsValid);
        Assert.False(validationListError.IsValid);
    }

    [Fact]
    public void Test_ThrowErrors_When_HasErrorItems_ShouldThrowValidationExcpetion()
    {
        // Arrange
        string errorMessage = "error exception teste";

        // Act
        void ThrowError() => ErrorValidationList.ThrowErrors(errorMessage);

        //Assert
        var ex = Assert.Throws<ValidationException>(ThrowError);
        Assert.Equal(errorMessage, ex.Message);
        Assert.Contains(ErrorValidation.Message, ex.Errors.Select(e => e.Message));
        Assert.Contains(ErrorValidation2.Message, ex.Errors.Select(e => e.Message));
    }

    [Fact]
    public void Test_ThrowErrors_When_HasNoErrorItems_ShouldNotThrowExcpetion()
    {
        // Arrange
        string errorMessage = "error exception teste";

        // Act
        void ThrowError() => SuccessValidationList.ThrowErrors(errorMessage);

        //Assert
        ThrowError();
    }

    [Fact]
    public void Test_ThrowErrorsWithMessage_When_HasErrorItems_ShouldThrowValidationException()
    {
        // Arrange
        string separator = "|";
        string errorMessage = ErrorValidation.Message + separator + ErrorValidation2.Message;

        // Act
        void ThrowError() => ErrorValidationList.ThrowErrorsWithMessage(separator);

        //Assert
        var ex = Assert.Throws<ValidationException>(ThrowError);
        Assert.Equal(errorMessage, ex.Message);
        Assert.Contains(ErrorValidation.Message, ex.Errors.Select(e => e.Message));
        Assert.Contains(ErrorValidation2.Message, ex.Errors.Select(e => e.Message));
    }

    [Fact]
    public void Test_ThrowErrorsWithMessage_When_HasNoErrorItems_ShouldNotThrowExcpetion()
    {
        // Arrange
        string errorMessage = "error exception teste";

        // Act
        void ThrowError() => SuccessValidationList.ThrowErrorsWithMessage(errorMessage);

        //Assert
        ThrowError();
    }

    [Fact]
    public void Test_ValidationListSuccess_AsNotFound_ShouldHave_ErrorTypeNull()
    {
        // Arrange

        // Act

        // Assert
        Assert.True(SuccessValidationList.IsValid);
        Assert.Null(SuccessValidationList.ErrorType);
    }

    [Fact]
    public void Test_ValidationListError_AsNotFound_ShouldHave_ErrorTypeNotFound()
    {
        // Arrange

        // Act
        ValidationList result = new() { ErrorValidation };

        // Assert
        Assert.False(result.IsValid);
        Assert.Equal(ErrorType.NotFound, result.ErrorType);
    }

    [Fact]
    public void Test_ValidationListMultiplesErrors_ShouldHave_ErrorTypeFailure()
    {
        // Arrange

        // Act

        // Assert
        Assert.False(ErrorValidationList.IsValid);
        Assert.Equal(ErrorType.Failure, ErrorValidationList.ErrorType);
    }

    [Fact]
    public void Test_FirstError()
    {
        // Act
        Error firstError = ErrorValidationList.FirstError;

        //Assert
        Assert.True(firstError.Message == ErrorValidation.Message || firstError.Message == ErrorValidation2.Message);
    }
}
