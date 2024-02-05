namespace GHM.Validator;

public struct Validation
{
    public string Message { get; init; }
    public bool IsValid { get; init; }
    public readonly bool IsError => !IsValid;
    public ErrorType? ErrorType { get; private set; }

    private Validation(bool isValid, string message)
    {
        IsValid = isValid;
        Message = message;
    }

    public static Validation Create(bool isValid, string message) => new(isValid, message);

    public static Validation Success(string message) => new(true, message);

    public static Validation Error(string message) => new(false, message);

    private Validation SetErrorType(ErrorType errorType)
    {
        if (!IsValid)
        {
            ErrorType = errorType;
        }
        return this;
    }

    public Validation AsFailure() => SetErrorType(Validator.ErrorType.Failure);

    public Validation AsNotFound() => SetErrorType(Validator.ErrorType.NotFound);

    public Validation AsUnexpected() => SetErrorType(Validator.ErrorType.Unexpected);

    public Validation AsValidation() => SetErrorType(Validator.ErrorType.Validation);

    public Validation AsConflict() => SetErrorType(Validator.ErrorType.Conflict);

    public Validation AsUnauthorized() => SetErrorType(Validator.ErrorType.Unauthorized);
}
