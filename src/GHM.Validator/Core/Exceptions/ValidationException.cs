namespace GHM.Validator;

public class ValidationException : Exception
{
    public List<Error> Errors { get; init; }

    public ErrorType? ErrorType =>
        Errors.Count switch
        {
            0 => null,
            1 => Errors[0].ErrorType,
            _ => Validator.ErrorType.Default
        };

    public ValidationException(string? messsage, List<Error> errors)
        : base(messsage)
    {
        Errors = errors;
    }

    public ValidationException(string? messsage, Exception innerException, List<Error> errors)
        : base(messsage, innerException)
    {
        Errors = errors;
    }

    public ValidationException(List<Error> errors)
        : base()
    {
        Errors = errors;
    }
}
