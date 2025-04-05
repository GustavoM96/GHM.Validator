namespace GHM.Validator;

/// <summary>
/// Represents the result of a validation operation with a value of type <typeparamref name="TValue"/>.
/// </summary>
public class Result<TValue> : Result
{
    /// <summary>
    /// Gets or sets the value associated with the result.
    /// </summary>
    public TValue Value { get; init; } = default!;

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class with the specified validations and value.
    /// </summary>
    /// <param name="validations">The validations associated with the result.</param>
    /// <param name="value">The value associated with the result.</param>
    public Result(IEnumerable<Validation> validations, TValue value = default!)
        : base(validations)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class with the specified validation and value.
    /// </summary>
    /// <param name="validation">The validation associated with the result.</param>
    /// <param name="value">The value associated with the result.</param>
    public Result(Validation validation, TValue value = default!)
        : base(validation)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class with the specified validation list and value.
    /// </summary>
    /// <param name="validations">The validation list associated with the result.</param>
    /// <param name="value">The value associated with the result.</param>
    public Result(ValidationList validations, TValue value = default!)
        : base(validations)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{TValue}"/> class with the specified value.
    /// </summary>
    /// <param name="value">The value associated with the result.</param>
    public Result(TValue value)
    {
        Value = value;
    }

    /// <summary>
    /// Matches the result and executes the appropriate action based on whether the result is an error or success.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the action.</typeparam>
    /// <param name="successAction">The action to be executed if the result is a success.</param>
    /// <param name="errorAction">The action to be executed if the result is an error.</param>
    /// <returns>The result returned by the executed action.</returns>
    public TResult Match<TResult>(
        Func<TValue, List<Validation>, TResult> successAction,
        Func<List<Error>, TResult> errorAction
    )
    {
        return IsError ? errorAction(Errors) : successAction(Value, Validations);
    }

    /// <summary>
    /// Matches the result and executes the appropriate action based on whether the result is an error or success.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the action.</typeparam>
    /// <param name="successAction">The action to be executed if the result is a success.</param>
    /// <param name="errorAction">The action to be executed if the result is an error.</param>
    /// <returns>The result returned by the executed action.</returns>
    public TResult Match<TResult>(
        Func<TValue, List<Validation>, TResult> successAction,
        Func<TValue, List<Error>, TResult> errorAction
    )
    {
        return IsError ? errorAction(Value, Errors) : successAction(Value, Validations);
    }

    /// <summary>
    /// Implicitly converts a value of type <typeparamref name="TValue"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    public static implicit operator Result<TValue>(TValue value) => new(value);

    /// <summary>
    /// Implicitly converts an array of <see cref="Validation"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="validations">The array of validations to be converted.</param>
    public static implicit operator Result<TValue>(Validation[] validations) => new(validations);

    /// <summary>
    /// Implicitly converts a <see cref="Validation"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="validation">The validation to be converted.</param>
    public static implicit operator Result<TValue>(Validation validation) => new(validation);

    /// <summary>
    /// Implicitly converts an <see cref="Error"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error to be converted.</param>
    public static implicit operator Result<TValue>(Error error) => new(error.ToValidation());

    /// <summary>
    /// Implicitly converts a list of <see cref="Error"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="errors">The list of errors to be converted.</param>
    public static implicit operator Result<TValue>(List<Error> errors) => new(errors.Select(error => error.ToValidation()));

    /// <summary>
    /// Implicitly converts a list of <see cref="Validation"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="validations">The list of validations to be converted.</param>
    public static implicit operator Result<TValue>(List<Validation> validations) => new(validations);

    /// <summary>
    /// Implicitly converts a <see cref="ValidationList"/> to a <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="validations">The validation list to be converted.</param>
    public static implicit operator Result<TValue>(ValidationList validations) => new(validations);
}

/// <summary>
/// Represents the result of a validation operation.
/// </summary>
public class Result
{
    /// <summary>
    /// Gets or sets the list of validations associated with the result.
    /// </summary>
    public List<Validation> Validations { get; init; } = new();

    /// <summary>
    /// Gets a value indicating whether the result is an error.
    /// </summary>
    public bool IsError => Validations.Any(validation => !validation.IsValid);

    /// <summary>
    /// Gets a value indicating whether the result is valid.
    /// </summary>
    public bool IsValid => !IsError;

    /// <summary>
    /// Gets the list of errors associated with the result.
    /// </summary>
    public List<Error> Errors => Validations.Where(validation => !validation.IsValid).Select(Error.FromValidation).ToList();

    /// <summary>
    /// Gets the first error associated with the result.
    /// </summary>
    public Error FirstError => Error.FromValidation(Validations.First(validation => !validation.IsValid));

    /// <summary>
    /// Adds a collection of validations to the result.
    /// </summary>
    /// <param name="validations">The collection of validations to be added.</param>
    public void AddValidations(IEnumerable<Validation> validations) => Validations.AddRange(validations);

    /// <summary>
    /// Adds a validation to the result.
    /// </summary>
    /// <param name="validation">The validation to be added.</param>
    public void AddValidation(Validation validation) => Validations.Add(validation);

    /// <summary>
    /// Matches the result and executes the appropriate action based on whether the result is an error or success.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the action.</typeparam>
    /// <param name="successAction">The action to be executed if the result is a success.</param>
    /// <param name="errorAction">The action to be executed if the result is an error.</param>
    /// <returns>The result returned by the executed action.</returns>
    public TResult Match<TResult>(Func<List<Validation>, TResult> successAction, Func<List<Error>, TResult> errorAction)
    {
        return IsError ? errorAction(Errors) : successAction(Validations);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with the specified validations.
    /// </summary>
    /// <param name="validations">The validations associated with the result.</param>
    public Result(IEnumerable<Validation> validations)
    {
        Validations = validations.ToList();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with the specified validation list.
    /// </summary>
    /// <param name="validationList">The validation list associated with the result.</param>
    public Result(ValidationList validationList)
    {
        Validations = validationList;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class with the specified validation.
    /// </summary>
    /// <param name="validation">The validation associated with the result.</param>
    public Result(Validation validation)
    {
        Validations = new List<Validation>() { validation };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class.
    /// </summary>
    public Result() { }

    /// <summary>
    /// Throws a <see cref="ValidationException"/> if there are any errors in the result.
    /// </summary>
    /// <param name="exceptionMessage">The exception message to be used.</param>
    public void ThrowErrors(string? exceptionMessage = null)
    {
        if (Errors.Count == 0)
        {
            return;
        }

        throw new ValidationException(exceptionMessage, Errors);
    }

    /// <summary>
    /// Throws a <see cref="ValidationException"/> with a message constructed from the errors in the result.
    /// </summary>
    /// <param name="separator">The separator to be used between error messages.</param>
    public void ThrowErrorsWithMessage(string? separator)
    {
        if (Errors.Count == 0)
        {
            return;
        }

        throw new ValidationException(string.Join(separator, Errors.Select(error => error.Message)), Errors);
    }

    /// <summary>
    /// Implicitly converts an array of <see cref="Validation"/> to a <see cref="Result"/>.
    /// </summary>
    /// <param name="validations">The array of validations to be converted.</param>
    public static implicit operator Result(Validation[] validations) => new(validations);

    /// <summary>
    /// Implicitly converts a <see cref="Validation"/> to a <see cref="Result"/>.
    /// </summary>
    /// <param name="validation">The validation to be converted.</param>
    public static implicit operator Result(Validation validation) => new(validation);

    /// <summary>
    /// Implicitly converts an <see cref="Error"/> to a <see cref="Result"/>.
    /// </summary>
    /// <param name="error">The error to be converted.</param>
    public static implicit operator Result(Error error) => new(error.ToValidation());

    /// <summary>
    /// Implicitly converts a list of <see cref="Error"/> to a <see cref="Result"/>.
    /// </summary>
    /// <param name="errors">The list of errors to be converted.</param>
    public static implicit operator Result(List<Error> errors) => new(errors.Select(error => error.ToValidation()));

    /// <summary>
    /// Implicitly converts a list of <see cref="Validation"/> to a <see cref="Result"/>.
    /// </summary>
    /// <param name="validations">The list of validations to be converted.</param>
    public static implicit operator Result(List<Validation> validations) => new(validations);
}
