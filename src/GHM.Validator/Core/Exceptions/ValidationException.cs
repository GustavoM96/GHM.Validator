namespace GHM.Validator;

public class ValidationException : Exception
{
    public List<Validation> Validations { get; init; }

    public ErrorType? ErrorType =>
        Validations.Count switch
        {
            0 => null,
            1 => Validations[0].ErrorType,
            _ => Validator.ErrorType.Failure
        };

    public ValidationException(string? messsage, List<Validation> validations)
        : base(messsage)
    {
        Validations = validations;
    }

    public ValidationException(string? messsage, Exception innerException, List<Validation> validations)
        : base(messsage, innerException)
    {
        Validations = validations;
    }

    public ValidationException(List<Validation> validations)
        : base()
    {
        Validations = validations;
    }
}
