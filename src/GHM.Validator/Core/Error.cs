namespace GHM.Validator;

public struct Error
{
    public string Title { get; private set; }
    public string Message { get; init; }
    public bool IsValid { get; } = false;
    public ErrorType ErrorType { get; private set; }

    private Error(string message, string title, ErrorType errorType)
    {
        Title = title;
        Message = message;
        ErrorType = errorType;
    }

    public Validation ToValidation() => Validator.Validation.Create(false, Message, Title, ErrorType);

    public static Error Failure(string message, string title = "Generic.Error") => new(message, title, ErrorType.Failure);

    public static Error NotFound(string message, string title = "Generic.Error") => new(message, title, ErrorType.NotFound);

    public static Error Unexpected(string message, string title = "Generic.Error") =>
        new(message, title, ErrorType.Unexpected);

    public static Error Validation(string message, string title = "Generic.Error") =>
        new(message, title, ErrorType.Validation);

    public static Error Conflict(string message, string title = "Generic.Error") => new(message, title, ErrorType.Conflict);

    public static Error Unauthorized(string message, string title = "Generic.Error") =>
        new(message, title, ErrorType.Unauthorized);
}
