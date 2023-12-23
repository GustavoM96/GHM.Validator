namespace GHM.Validator;

public readonly struct Validation
{
    public string Message { get; init; }
    public bool IsValid { get; init; }
    public bool IsError => !IsValid;

    private Validation(bool isValid, string message)
    {
        IsValid = isValid;
        Message = message;
    }

    public static Validation Success(string message) => new(true, message);

    public static Validation Error(string message) => new(false, message);
}
