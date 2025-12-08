using GHM.Validator.Core.Enum;

namespace GHM.Validator;

/// <summary>
/// Represents a validation result.
/// </summary>
public struct Validation
{
    /// <summary>
    /// Gets or sets the title of the validation.
    /// </summary>E
    public string? Title { get; private set; }

    /// <summary>
    /// Gets or sets the message of the validation.
    /// </summary>
    public string Message { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether the validation is valid.
    /// </summary>
    public bool IsValid { get; init; }

    /// <summary>
    /// Gets a value indicating whether the validation is an error.
    /// </summary>
    public readonly bool IsError => !IsValid;

    /// <summary>
    /// Gets or sets the error type of the validation.
    /// </summary>
    public ErrorType? ErrorType { get; private set; }

    /// <sumamary>
    /// Gets or sets the validation type of the validation.
    /// </sumamary>
    public ValidationType? ValidationType { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Validation"/> struct.
    /// </summary>
    /// <param name="isValid">A value indicating whether the validation is valid.</param>
    /// <param name="message">The message of the validation.</param>
    /// <param name="title">The title of the validation.</param>
    /// <param name="errorType">The error type of the validation.</param>
    public Validation(
        bool isValid,
        string message,
        string? title = null,
        ErrorType? errorType = null,
        ValidationType? validationType = null
    )
    {
        IsValid = isValid;
        Message = message;
        Title = title;
        ErrorType = isValid ? null : errorType ?? Validator.ErrorType.Validation;
        ValidationType = validationType;
    }

    /// <summary>
    /// Creates a success validation with the specified message.
    /// </summary>
    /// <param name="message">The message of the validation.</param>
    /// <returns>A success validation.</returns>
    public static Validation Success(string message) => new(true, message);

    /// <summary>
    /// Creates a success validation with the specified message and validationType.
    /// </summary>
    /// <param name="message">The message of the validation.</param>
    /// <returns>A success validation.</returns>
    public static Validation Success(ValidationType validationType, string message) =>
        new(true, message, validationType: validationType);

    /// <summary>
    /// Creates an error validation with the specified message.
    /// </summary>
    /// <param name="message">The message of the validation.</param>
    /// <returns>An error validation.</returns>
    public static Validation Error(string message) => new(false, message);

    public static Validation Error(ValidationType validationType, string message) =>
        new(false, message, validationType: validationType);

    /// <summary>
    /// Sets the error type of the validation if it is an error.
    /// </summary>
    /// <param name="errorType">The error type to set.</param>
    /// <returns>The validation with the error type set.</returns>
    private Validation WithErrorType(ErrorType errorType)
    {
        if (IsError)
        {
            ErrorType = errorType;
        }
        return this;
    }

    /// <summary>
    /// Sets the title of the validation.
    /// </summary>
    /// <param name="title">The title to set.</param>
    /// <returns>The validation with the title set.</returns>
    public Validation WithTitle(string title)
    {
        Title = title;
        return this;
    }

    /// <summary>
    /// Binds the specified error to the validation if it is not valid.
    /// </summary>
    /// <param name="error">The error to bind.</param>
    /// <returns>The validation if it is valid; otherwise, the error converted to a validation.</returns>
    public readonly Validation BindError(Error error) => IsValid ? this : error.ToValidation();

    /// <summary>
    /// Sets the error type of the validation to Failure.
    /// </summary>
    /// <returns>The validation with the error type set to Failure.</returns>
    public Validation AsFailure() => WithErrorType(Validator.ErrorType.Failure);

    /// <summary>
    /// Sets the error type of the validation to NotFound.
    /// </summary>
    /// <returns>The validation with the error type set to NotFound.</returns>
    public Validation AsNotFound() => WithErrorType(Validator.ErrorType.NotFound);

    /// <summary>
    /// Sets the error type of the validation to Unexpected.
    /// </summary>
    /// <returns>The validation with the error type set to Unexpected.</returns>
    public Validation AsUnexpected() => WithErrorType(Validator.ErrorType.Unexpected);

    /// <summary>
    /// Sets the error type of the validation to Validation.
    /// </summary>
    /// <returns>The validation with the error type set to Validation.</returns>
    public Validation AsValidation() => WithErrorType(Validator.ErrorType.Validation);

    /// <summary>
    /// Sets the error type of the validation to Conflict.
    /// </summary>
    /// <returns>The validation with the error type set to Conflict.</returns>
    public Validation AsConflict() => WithErrorType(Validator.ErrorType.Conflict);

    /// <summary>
    /// Sets the error type of the validation to Unauthorized.
    /// </summary>
    /// <returns>The validation with the error type set to Unauthorized.</returns>
    public Validation AsUnauthorized() => WithErrorType(Validator.ErrorType.Unauthorized);
}
