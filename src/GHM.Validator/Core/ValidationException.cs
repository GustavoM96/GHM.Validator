namespace GHM.Validator;

public class ValidationException : Exception
{
    public List<Validation> Validations { get; init; }

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
