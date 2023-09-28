using GHM.Validator.Interfaces;

namespace GHM.Validator;

public class Validator : IValidator
{
    private readonly string _errorMessage = "Error: ";
    private readonly string _successMessage = "OK: ";

    public Validation ValidateIfNotNull(object obj, string message)
    {
        return obj != null
            ? Validation.Success(_successMessage + message)
            : Validation.Error(_errorMessage + message);
    }

    public Validation ValidateIfNull(object obj, string message)
    {
        return obj == null
            ? Validation.Success(_successMessage + message)
            : Validation.Error(_errorMessage + message);
    }

    public Validation ValidateIfEqual(object objBase, object objToComapere, string message)
    {
        return objBase.Equals(objToComapere)
            ? Validation.Success(_successMessage + message)
            : Validation.Error(_errorMessage + message);
    }

    public Validation ValidateIfBiggerOrEqualThan(int number, int numberToCompare, string message)
    {
        return number >= numberToCompare
            ? Validation.Success(_successMessage + message)
            : Validation.Error(_errorMessage + message);
    }

    public Validation ValidateIfBiggerThan(int number, int numberToCompare, string message)
    {
        return number > numberToCompare
            ? Validation.Success(_successMessage + message)
            : Validation.Error(_errorMessage + message);
    }

    public Validation ValidateIfBiggerOrEqualThan(
        decimal number,
        decimal numberToCompare,
        string message
    )
    {
        return number >= numberToCompare
            ? Validation.Success(_successMessage + message)
            : Validation.Error(_errorMessage + message);
    }

    public Validation ValidateIfBiggerThan(decimal number, decimal numberToCompare, string message)
    {
        return number > numberToCompare
            ? Validation.Success(_successMessage + message)
            : Validation.Error(_errorMessage + message);
    }

    public Validation ValidateIfNotEmpty(string text, string message)
    {
        return !string.IsNullOrEmpty(text)
            ? Validation.Success(_successMessage + message)
            : Validation.Error(_errorMessage + message);
    }

    public Validation ValidateIfParseToBigInt(string text, string message)
    {
        return long.TryParse(text, out var _)
            ? Validation.Success(_successMessage + message)
            : Validation.Error(_errorMessage + message);
    }

    public Validation ValidateIfNotEmpty<T>(IEnumerable<T> list, string message)
    {
        return list.Any()
            ? Validation.Success(_successMessage + message)
            : Validation.Error(_errorMessage + message);
    }

    public bool ThrowIfNotNull(object obj, string message)
    {
        return obj == null ? true : throw new ArgumentException(message);
    }

    public bool ThrowIfNull(object obj, string message)
    {
        return obj != null ? true : throw new ArgumentException(message);
    }

    public bool ThrowIfNotEqual(object objBase, object objToComapere, string message)
    {
        return objBase.Equals(objToComapere) ? true : throw new ArgumentException(message);
    }

    public bool ThrowIfBiggerOrEqualThan(int number, int numberToCompare, string message)
    {
        return number >= numberToCompare ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfBiggerThan(int number, int numberToCompare, string message)
    {
        return number > numberToCompare ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfBiggerOrEqualThan(decimal number, decimal numberToCompare, string message)
    {
        return number >= numberToCompare ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfBiggerThan(decimal number, decimal numberToCompare, string message)
    {
        return number > numberToCompare ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfEmpty(string text, string message)
    {
        return string.IsNullOrEmpty(text) ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfNotParseToBigInt(string text, string message)
    {
        return long.TryParse(text, out var _) ? true : throw new ArgumentException(message);
    }

    public bool ThrowIfEmpty<T>(IEnumerable<T> list, string message)
    {
        return list.Any() ? true : throw new ArgumentException(message);
    }
}
