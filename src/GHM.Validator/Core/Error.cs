namespace GHM.Validator;

/// <summary>
/// Represents an error with a title, message, error type, and validity status.
/// </summary>
public struct Error
{
    /// <summary>
    /// Gets the title of the error.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Gets or sets the message of the error.
    /// </summary>
    public string Message { get; init; }

    /// <summary>
    /// Gets the validity status of the error.
    /// </summary>
    public bool IsValid { get; } = false;

    /// <summary>
    /// Gets the error type of the error.
    /// </summary>
    public ErrorType ErrorType { get; private set; }

    private Error(string message, string title, ErrorType errorType)
    {
        Title = title;
        Message = message;
        ErrorType = errorType;
    }

    /// <summary>
    /// Converts the error to a validation object.
    /// </summary>
    /// <returns>The validation object.</returns>
    public readonly Validation ToValidation() => new(false, Message, Title, ErrorType);

    /// <summary>
    /// Creates an error from a validation object.
    /// </summary>
    /// <param name="validation">The validation object.</param>
    /// <returns>The error object.</returns>
    public static Error FromValidation(Validation validation) =>
        new(validation.Message, validation.Title ?? "Generic.Error", validation.ErrorType ?? ErrorType.Validation);

    /// <summary>
    /// Creates a failure error with the specified message and title.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="title">The error title. Default is "Generic.Error".</param>
    /// <returns>The failure error object.</returns>
    public static Error Failure(string message, string title = "Generic.Error") => new(message, title, ErrorType.Failure);

    /// <summary>
    /// Creates a not found error with the specified message and title.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="title">The error title. Default is "Generic.Error".</param>
    /// <returns>The not found error object.</returns>
    public static Error NotFound(string message, string title = "Generic.Error") => new(message, title, ErrorType.NotFound);

    /// <summary>
    /// Creates an unexpected error with the specified message and title.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="title">The error title. Default is "Generic.Error".</param>
    /// <returns>The unexpected error object.</returns>
    public static Error Unexpected(string message, string title = "Generic.Error") =>
        new(message, title, ErrorType.Unexpected);

    /// <summary>
    /// Creates a validation error with the specified message and title.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="title">The error title. Default is "Generic.Error".</param>
    /// <returns>The validation error object.</returns>
    public static Error Validation(string message, string title = "Generic.Error") =>
        new(message, title, ErrorType.Validation);

    /// <summary>
    /// Creates a conflict error with the specified message and title.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="title">The error title. Default is "Generic.Error".</param>
    /// <returns>The conflict error object.</returns>
    public static Error Conflict(string message, string title = "Generic.Error") => new(message, title, ErrorType.Conflict);

    /// <summary>
    /// Creates an unauthorized error with the specified message and title.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="title">The error title. Default is "Generic.Error".</param>
    /// <returns>The unauthorized error object.</returns>
    public static Error Unauthorized(string message, string title = "Generic.Error") =>
        new(message, title, ErrorType.Unauthorized);
}
