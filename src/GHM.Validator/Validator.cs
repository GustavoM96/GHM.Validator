using GHM.Validator.Interfaces;

namespace GHM.Validator;

public class Validator : IValidator
{
    public Validation ValidateIfNotDefault<T>(T obj, string message)
    {
        var isDefault = EqualityComparer<T>.Default.Equals(obj, default);
        return isDefault ? Validation.Error(message) : Validation.Success(message);
    }

    public Validation ValidateIfNotNull(object obj, string message)
    {
        return obj != null ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfNull(object obj, string message)
    {
        return obj == null ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfEqual(object obj, object objToComapere, string message)
    {
        return obj.Equals(objToComapere) ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfNotZero(int number, string message)
    {
        return number != 0 ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfNotZero(decimal number, string message)
    {
        return number != 0 ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfGreaterOrEqual(int number, int numberToCompare, string message)
    {
        return number >= numberToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfGreater(int number, int numberToCompare, string message)
    {
        return number > numberToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfGreaterOrEqual(
        decimal number,
        decimal numberToCompare,
        string message
    )
    {
        return number >= numberToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfGreater(decimal number, decimal numberToCompare, string message)
    {
        return number > numberToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfNotEmpty(string text, string message)
    {
        return string.IsNullOrEmpty(text) ? Validation.Error(message) : Validation.Success(message);
    }

    public Validation ValidateIfParseToLong(string text, string message)
    {
        return long.TryParse(text, out var _)
            ? Validation.Success(message)
            : Validation.Error(message);
    }

    public Validation ValidateIfNotEmpty<T>(IEnumerable<T> list, string message)
    {
        return list.Any() ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfOlder<T>(DateTime date, DateTime dateToCompare, string message)
    {
        return date < dateToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation ValidateIfOlderOrEqual<T>(
        DateTime date,
        DateTime dateToCompare,
        string message
    )
    {
        return date <= dateToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public bool ThrowIfDefault<T>(T obj, string message)
    {
        var isDefault = EqualityComparer<T>.Default.Equals(obj, default);
        return isDefault ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfNotNull(object obj, string message)
    {
        return obj != null ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfNull(object obj, string message)
    {
        return obj == null ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfNotEqual(object obj, object objToComapere, string message)
    {
        return obj.Equals(objToComapere) ? true : throw new ArgumentException(message);
    }

    public bool ThrowIfZero(int number, string message)
    {
        return number == 0 ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfZero(decimal number, string message)
    {
        return number == 0 ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfGreaterOrEqual(int number, int numberToCompare, string message)
    {
        return number >= numberToCompare ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfGreater(int number, int numberToCompare, string message)
    {
        return number > numberToCompare ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfGreaterOrEqual(decimal number, decimal numberToCompare, string message)
    {
        return number >= numberToCompare ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfGreater(decimal number, decimal numberToCompare, string message)
    {
        return number > numberToCompare ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfEmpty(string text, string message)
    {
        return string.IsNullOrEmpty(text) ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfNotParseToLong(string text, string message)
    {
        return long.TryParse(text, out var _) ? true : throw new ArgumentException(message);
    }

    public bool ThrowIfEmpty<T>(IEnumerable<T> list, string message)
    {
        return list.Any() ? true : throw new ArgumentException(message);
    }

    public bool ThrowIfOlder<T>(DateTime date, DateTime dateToCompare, string message)
    {
        return date < dateToCompare ? throw new ArgumentException(message) : true;
    }

    public bool ThrowIfOlderOrEqual<T>(DateTime date, DateTime dateToCompare, string message)
    {
        return date <= dateToCompare ? throw new ArgumentException(message) : true;
    }
}
