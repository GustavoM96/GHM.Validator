namespace GHM.Validator;

/// <summary>
/// Represents a list of validations.
/// </summary>
public class ValidationList : List<Validation>
{
    /// <summary>
    /// Gets a value indicating whether there is any error in the validation list.
    /// </summary>
    public bool IsError => this.Any(validation => !validation.IsValid);

    /// <summary>
    /// Gets a value indicating whether the validation list is valid.
    /// </summary>
    public bool IsValid => !IsError;

    /// <summary>
    /// Gets the list of errors in the validation list.
    /// </summary>
    public List<Error> GetErrors() => this.Where(validation => !validation.IsValid).Select(Error.FromValidation).ToList();

    /// <summary>
    /// Gets the error type of the validation list.
    /// </summary>
    public ErrorType? ErrorType =>
        GetErrors().Count switch
        {
            0 => null,
            1 => GetErrors()[0].ErrorType,
            _ => Validator.ErrorType.Failure,
        };

    /// <summary>
    /// Gets the first error in the validation list.
    /// </summary>
    public Error FirstError => Error.FromValidation(this.First(validation => !validation.IsValid));

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationList"/> class.
    /// </summary>
    public ValidationList()
        : base() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationList"/> class with the specified capacity.
    /// </summary>
    /// <param name="capacity">The initial capacity of the list.</param>
    public ValidationList(int capacity)
        : base(capacity) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationList"/> class with the specified validations.
    /// </summary>
    /// <param name="validations">The validations to add to the list.</param>
    public ValidationList(IEnumerable<Validation> validations)
        : base(validations) { }

    /// <summary>
    /// Throws a <see cref="ValidationException"/> if there are any errors in the validation list.
    /// </summary>
    /// <param name="exceptionMessage">The exception message to include in the <see cref="ValidationException"/>.</param>
    public void ThrowErrors(string? exceptionMessage = null)
    {
        if (GetErrors().Count == 0)
        {
            return;
        }

        throw new ValidationException(exceptionMessage, GetErrors());
    }

    /// <summary>
    /// Throws a <see cref="ValidationException"/> with a message that combines all error messages in the validation list.
    /// </summary>
    /// <param name="separator">The separator to use between error messages.</param>
    public void ThrowErrorsWithMessage(string? separator)
    {
        if (GetErrors().Count == 0)
        {
            return;
        }

        throw new ValidationException(string.Join(separator, GetErrors().Select(error => error.Message)), GetErrors());
    }
}
