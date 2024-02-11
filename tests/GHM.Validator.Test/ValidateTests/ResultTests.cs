using GHM.Validator.Interfaces;

namespace GHM.Validator.Test.ValidateTests;

public class ResultTests
{
    private readonly Result _result = Result.Create();
    private readonly Result<string> _resultValue = Result<string>.Create("test Value");
    private static Validation ErrorValidation => Validation.Error("error test");
    private static Validation ErrorValidation2 => Validation.Error("error test2");
    private static Validation SuccessValidation => Validation.Success("success test");
    private static ValidationList ErrorValidationList => new() { ErrorValidation, ErrorValidation2, SuccessValidation };

    [Fact]
    public void Test_Result_Constructors()
    {
        // Arrange

        // Act
        Result result = Result.Create();
        Result result2 = SuccessValidation;
        Result result3 = ErrorValidationList;
        Result result4 = new Validation[2] { SuccessValidation, ErrorValidation };

        // Assert
        Assert.Empty(result.Validations);
        Assert.Equal(SuccessValidation, result2.Validations[0]);
        Assert.Equal(ErrorValidationList.Count, result3.Validations.Count);
        Assert.Equal(2, result4.Validations.Count);
    }

    [Fact]
    public void Test_ResultValue_Constructors()
    {
        // Arrange
        var value = "test Value";

        // Act
        Result<string> result = Result<string>.Create(value);
        Result<string> result2 = SuccessValidation;
        Result<string> result3 = ErrorValidationList;
        Result<string> result4 = new Validation[2] { SuccessValidation, ErrorValidation };
        Result<string> result5 = new(SuccessValidation, value);
        Result<string> result6 = new(ErrorValidationList, value);

        // Assert
        Assert.Equal(value, result.Value);
        Assert.Equal(SuccessValidation, result2.Validations[0]);
        Assert.Equal(ErrorValidationList.Count, result3.Validations.Count);
        Assert.Equal(2, result4.Validations.Count);
        Assert.Equal(value, result5.Value);
        Assert.Equal(SuccessValidation, result5.Validations[0]);
        Assert.Equal(value, result6.Value);
        Assert.Equal(ErrorValidationList.Count, result6.Validations.Count);
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
