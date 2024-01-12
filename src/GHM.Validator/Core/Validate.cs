using GHM.Validator.Interfaces;

namespace GHM.Validator;

public class Validate : IValidate
{
    public Validation IfTrue<T>(bool condition, string message)
    {
        return Validation.Create(condition, message);
    }

    public Validation IfFalse<T>(bool condition, string message)
    {
        return Validation.Create(!condition, message);
    }

    public Validation IfNotDefault<T>(T obj, string message)
    {
        var isDefault = EqualityComparer<T>.Default.Equals(obj, default);
        return isDefault ? Validation.Error(message) : Validation.Success(message);
    }

    public Validation IfNotNull(object? obj, string message)
    {
        return obj != null ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfNull(object? obj, string message)
    {
        return obj == null ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfEqual(object obj, object objToComapere, string message)
    {
        return obj.Equals(objToComapere) ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfNotZero(int number, string message)
    {
        return number != 0 ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfNotZero(decimal number, string message)
    {
        return number != 0 ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfGreaterOrEqual(int number, int numberToCompare, string message)
    {
        return number >= numberToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfGreater(int number, int numberToCompare, string message)
    {
        return number > numberToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfGreaterOrEqual(decimal number, decimal numberToCompare, string message)
    {
        return number >= numberToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfGreater(decimal number, decimal numberToCompare, string message)
    {
        return number > numberToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfNotEmpty(string text, string message)
    {
        return string.IsNullOrEmpty(text) ? Validation.Error(message) : Validation.Success(message);
    }

    public Validation IfParseToLong(string text, string message)
    {
        return long.TryParse(text, out var _) ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfNotEmpty<T>(IEnumerable<T> list, string message)
    {
        return list.Any() ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfOlder(DateTime date, DateTime dateToCompare, string message)
    {
        return date < dateToCompare ? Validation.Success(message) : Validation.Error(message);
    }

    public Validation IfOlderOrEqual(DateTime date, DateTime dateToCompare, string message)
    {
        return date <= dateToCompare ? Validation.Success(message) : Validation.Error(message);
    }
}
