namespace GHM.Validator;

public struct Validation
{
    public string? Title { get; private set; }
    public string Message { get; init; }
    public bool IsValid { get; init; }
    public readonly bool IsError => !IsValid;
    public ErrorType? ErrorType { get; private set; }

    private Validation(bool isValid, string message, string? title = null, ErrorType? errorType = null)
    {
        IsValid = isValid;
        Message = message;
        Title = title;
        ErrorType = isValid ? null : errorType ?? Validator.ErrorType.Validation;
    }

    public static Validation Create(bool isValid, string message, string title, ErrorType errorType) =>
        new(isValid, message, title, errorType);

    public static Validation Success(string message) => new(true, message);

    public static Validation Error(string message) => new(false, message);

    private Validation WithErrorType(ErrorType errorType)
    {
        if (IsError)
        {
            ErrorType = errorType;
        }
        return this;
    }

    public Validation WithTitle(string title)
    {
        Title = title;
        return this;
    }

    public Validation BindError(Error error) => IsValid ? this : error.ToValidation();

    public Validation AsFailure() => WithErrorType(Validator.ErrorType.Failure);

    public Validation AsNotFound() => WithErrorType(Validator.ErrorType.NotFound);

    public Validation AsUnexpected() => WithErrorType(Validator.ErrorType.Unexpected);

    public Validation AsValidation() => WithErrorType(Validator.ErrorType.Validation);

    public Validation AsConflict() => WithErrorType(Validator.ErrorType.Conflict);

    public Validation AsUnauthorized() => WithErrorType(Validator.ErrorType.Unauthorized);
}
