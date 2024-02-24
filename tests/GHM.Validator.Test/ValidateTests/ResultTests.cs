using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.ValidateTests;

public class ResultTests
{
    private readonly Result _result = Result.Create();
    private readonly Result<string> _resultValue = Result<string>.Create("test Value");
    private static Validation ErrorValidation => Validation.Error("error test");
    private static Validation ErrorValidation2 => Validation.Error("error test2");
    private static Validation SuccessValidation => Validation.Success("success test");
    private static Error ErrorData => Error.Conflict("test conflict");
    private static ValidationList ErrorValidationList => new() { ErrorValidation, ErrorValidation2, SuccessValidation };

    [Fact]
    public void Test_ResultConstructors_ShouldHave_ErrorsEqualsParameter()
    {
        // Arrange

        // Act
        Result result = SuccessValidation;
        Result result2 = ErrorValidationList;
        Result result3 = new Validation[2] { SuccessValidation, ErrorValidation };
        Result result4 = new List<Validation>(2) { SuccessValidation, ErrorValidation };
        Result result5 = ErrorData;
        Result result6 = new List<Error>(1) { ErrorData };

        // Assert
        Assert.Contains(SuccessValidation, result.Validations);
        Assert.Contains(SuccessValidation, result2.Validations);
        Assert.Contains(SuccessValidation, result3.Validations);
        Assert.Contains(SuccessValidation, result4.Validations);
        Assert.Contains(ErrorData.Message, result5.Validations[0].Message);
        Assert.Contains(ErrorData.Message, result6.Validations[0].Message);
    }

    [Fact]
    public void Test_ResultValueConstructors_ShouldHave_ValueEqualsParameter()
    {
        // Arrange
        var value = "test Value";

        // Act
        Result<string> result = Result<string>.Create(value);
        Result<string> result2 = new(SuccessValidation, value);
        Result<string> result3 = new(ErrorValidationList, value);
        Result<string> result4 = new(new Validation[2] { SuccessValidation, ErrorValidation }, value);
        Result<string> result5 = value;

        // Assert
        Assert.Equal(value, result.Value);
        Assert.Equal(value, result2.Value);
        Assert.Equal(value, result3.Value);
        Assert.Equal(value, result4.Value);
        Assert.Equal(value, result5.Value);
    }

    [Fact]
    public void Test_ResultValueConstructors_ShouldHave_ErrorsEqualsParameter()
    {
        // Arrange

        // Act
        Result<string> result = SuccessValidation;
        Result<string> result2 = ErrorValidationList;
        Result<string> result3 = new Validation[2] { SuccessValidation, ErrorValidation };
        Result<string> result4 = new List<Validation>(2) { SuccessValidation, ErrorValidation };
        Result<string> result5 = ErrorData;
        Result<string> result6 = new List<Error>(1) { ErrorData };
        
        // Assert
        Assert.Contains(SuccessValidation, result.Validations);
        Assert.Contains(SuccessValidation, result2.Validations);
        Assert.Contains(SuccessValidation, result3.Validations);
        Assert.Contains(SuccessValidation, result4.Validations);
        Assert.Contains(ErrorData.Message, result5.Validations[0].Message);
        Assert.Contains(ErrorData.Message, result6.Validations[0].Message);
    }

    [Fact]
    public void Test_IsError_When_SuccessfulCase_ShouldReturnFalse()
    {
        // Arrange

        // Act

        // Assert
        Assert.False(_resultValue.IsError);
        Assert.False(_result.IsError);

        Assert.True(_resultValue.IsValid);
        Assert.True(_result.IsValid);
    }

    [Fact]
    public void Test_IsError_When_FailureCase_ShouldReturnTrue()
    {
        // Arrange
        Result<string> result = Result<string>.Create("test Value");
        Result result2 = Result.Create();

        result.AddValidation(ErrorValidation);
        result2.AddValidations(ErrorValidationList);

        // Act

        // Assert
        Assert.True(result.IsError);
        Assert.True(result2.IsError);

        Assert.False(result.IsValid);
        Assert.False(result2.IsValid);
    }

    [Fact]
    public void Test_Errors_ShouldReturn_AllValidationsInvalid()
    {
        // Arrange
        Result result = Result.Create();
        result.AddValidations(ErrorValidationList);

        // Act
        var errors = result.Errors;

        // Assert
        Assert.Contains(ErrorValidation, errors);
        Assert.Contains(ErrorValidation2, errors);
        Assert.Equal(2, errors.Count);
    }

    [Fact]
    public void Test_ThrowErrors_When_HasErrorItems_ShouldThrowValidationExcpetion()
    {
        // Arrange
        var errorMessage = "error exception teste";

        // Act
        Result result = new(ErrorValidationList);
        void ThrowError() => result.ThrowErrors(errorMessage);

        //Assert
        var ex = Assert.Throws<ValidationException>(ThrowError);
        Assert.Equal(errorMessage, ex.Message);
        Assert.Contains(ErrorValidation, ex.Validations);
        Assert.Contains(ErrorValidation2, ex.Validations);
    }

    [Fact]
    public void Test_ThrowErrors_When_HasNoErrorItems_ShouldNotThrowExcpetion()
    {
        // Arrange
        var errorMessage = "error exception teste";

        // Act
        void ThrowError() => _result.ThrowErrors(errorMessage);

        //Assert
        ThrowError();
    }

    [Fact]
    public void Test_ThrowErrorsWithMessage_When_HasErrorItems_ShouldThrowValidationException()
    {
        // Arrange
        var separator = "|";
        var errorMessage = ErrorValidation.Message + separator + ErrorValidation2.Message;

        // Act
        Result result = new(ErrorValidationList);
        void ThrowError() => result.ThrowErrorsWithMessage(separator);

        //Assert
        var ex = Assert.Throws<ValidationException>(ThrowError);
        Assert.Equal(errorMessage, ex.Message);
        Assert.Contains(ErrorValidation, ex.Validations);
        Assert.Contains(ErrorValidation2, ex.Validations);
    }

    [Fact]
    public void Test_ThrowErrorsWithMessage_When_HasNoErrorItems_ShouldNotThrowExcpetion()
    {
        // Arrange
        var errorMessage = "error exception teste";

        // Act
        void ThrowError() => _result.ThrowErrorsWithMessage(errorMessage);

        //Assert
        ThrowError();
    }
}
