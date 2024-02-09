namespace GHM.Validator;

public class Result<TValue> : Result
{
    public TValue Value { get; init; } = default!;

    public Result(IEnumerable<Validation> validations, TValue value)
        : base(validations)
    {
        Value = value;
    }

    public Result(IEnumerable<Validation> validations)
        : base(validations) { }

    public Result(TValue value)
    {
        Value = value;
    }

    public static Result<TValue> Create(TValue value) => new(value);

    public static implicit operator Result<TValue>(TValue value) => new(value);

    public static implicit operator Result<TValue>(Validation[] validations) => new(validations);

    public static implicit operator Result<TValue>(List<Validation> validations) => new(validations);
}

public class Result
{
    public List<Validation> Validations { get; init; } = new();
    public bool IsError => Validations.Any(validation => !validation.IsValid);
    public bool IsValid => !IsError;
    public List<Validation> Errors => Validations.Where(validation => !validation.IsValid).ToList();
    public Validation FirstError => Validations.FirstOrDefault(validation => !validation.IsValid);

    public Result(IEnumerable<Validation> validations)
    {
        Validations = validations.ToList();
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

    public static Result Create() => new();

    public static implicit operator Result(Validation[] validations) => new(validations);

    public static implicit operator Result(List<Validation> validations) => new(validations);
}
