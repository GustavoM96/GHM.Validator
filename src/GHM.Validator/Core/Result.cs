namespace GHM.Validator;

public class Result<TValue> : Result
{
    public TValue Value { get; init; } = default!;

    public Result(IEnumerable<Validation> validations, TValue value = default!)
        : base(validations)
    {
        Value = value;
    }

    public Result(Validation validation, TValue value = default!)
        : base(validation)
    {
        Value = value;
    }

    public Result(ValidationList validations, TValue value = default!)
        : base(validations)
    {
        Value = value;
    }

    public Result(TValue value)
    {
        Value = value;
    }

    public TResult Match<TResult>(
        Func<TValue, List<Validation>, TResult> successAction,
        Func<List<Error>, TResult> errorAction
    )
    {
        return IsError ? errorAction(Errors) : successAction(Value, Validations);
    }

    public TResult Match<TResult>(
        Func<TValue, List<Validation>, TResult> successAction,
        Func<TValue, List<Error>, TResult> errorAction
    )
    {
        return IsError ? errorAction(Value, Errors) : successAction(Value, Validations);
    }

    public static implicit operator Result<TValue>(TValue value) => new(value);

    public static implicit operator Result<TValue>(Validation[] validations) => new(validations);

    public static implicit operator Result<TValue>(Validation validation) => new(validation);

    public static implicit operator Result<TValue>(Error error) => new(error.ToValidation());

    public static implicit operator Result<TValue>(List<Error> errors) => new(errors.Select(error => error.ToValidation()));

    public static implicit operator Result<TValue>(List<Validation> validations) => new(validations);

    public static implicit operator Result<TValue>(ValidationList validations) => new(validations);
}

public class Result
{
    public List<Validation> Validations { get; init; } = new();
    public bool IsError => Validations.Any(validation => !validation.IsValid);
    public bool IsValid => !IsError;
    public List<Error> Errors => Validations.Where(validation => !validation.IsValid).Select(Error.FromValidation).ToList();
    public Error FirstError => Errors.First();

    public void AddValidations(IEnumerable<Validation> validations) => Validations.AddRange(validations);

    public void AddValidation(Validation validation) => Validations.Add(validation);

    public TResult Match<TResult>(Func<List<Validation>, TResult> successAction, Func<List<Error>, TResult> errorAction)
    {
        return IsError ? errorAction(Errors) : successAction(Validations);
    }

    public Result(IEnumerable<Validation> validations)
    {
        Validations = validations.ToList();
    }

    public Result(ValidationList validationList)
    {
        Validations = validationList;
    }

    public Result(Validation validation)
    {
        Validations = new List<Validation>() { validation };
    }

    public Result() { }

    public void ThrowErrors(string? exeptionMessage = null)
    {
        if (Errors.Count == 0)
        {
            return;
        }

        throw new ValidationException(exeptionMessage, Errors);
    }

    public void ThrowErrorsWithMessage(string? separator)
    {
        if (Errors.Count == 0)
        {
            return;
        }

        throw new ValidationException(string.Join(separator, Errors.Select(error => error.Message)), Errors);
    }

    public static implicit operator Result(Validation[] validations) => new(validations);

    public static implicit operator Result(Validation validation) => new(validation);

    public static implicit operator Result(Error error) => new(error.ToValidation());

    public static implicit operator Result(List<Error> errors) => new(errors.Select(error => error.ToValidation()));

    public static implicit operator Result(List<Validation> validations) => new(validations);
}
