namespace GHM.Validator;

public struct Validation
{
    public string Message;
    public bool IsValid;

    private Validation(bool isValid, string message)
    {
        IsValid = isValid;
        Message = message;
    }

    public static Validation Success(string message)
    {
        return new Validation(true, message);
    }

    public static Validation Error(string message)
    {
        return new Validation(false, message);
    }
}
