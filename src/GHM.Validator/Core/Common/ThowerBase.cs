namespace GHM.Validator;

internal abstract class ThowerBase
{
    public ThowerBase(Func<string, Exception> exceptionThrower)
    {
        _thrower = exceptionThrower;
        _initialThrower = exceptionThrower;
    }

    protected bool ThrowIfError(bool isError, string message)
    {
        if (isError)
        {
            var exception = _thrower(message);
            _thrower = _initialThrower;
            throw exception;
        }

        _thrower = _initialThrower;
        return true;
    }

    protected Func<string, Exception> _thrower;
    private readonly Func<string, Exception> _initialThrower;

    protected static string GetDefaultErrorMessage(string validationName, string? paramName, object? value) =>
        $"Error to validate param: {paramName}. Value: {value}. ThrowerName: {validationName}";

    protected static string GetDefaultErrorMessage(
        string validationName,
        string? paramName,
        object? value,
        object? toCompare
    ) => $"Error to validate param: {paramName}. Value: {value}. Compare: {toCompare}. ThrowerName: {validationName}";
}
