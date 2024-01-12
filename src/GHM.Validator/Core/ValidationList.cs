namespace GHM.Validator;

public class ValidationList : List<Validation>
{
    public bool IsError => this.Any(validation => !validation.IsValid);
    public bool IsValid => !IsError;
    public List<Validation> Errors => this.Where(validation => !validation.IsValid).ToList();

    public ValidationList()
        : base() { }

    public ValidationList(int capacity)
        : base(capacity) { }

    public ValidationList(IEnumerable<Validation> validations)
        : base(validations) { }

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
}
