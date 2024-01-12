using GHM.Validator.Interfaces;

namespace GHM.Validator;

public class Thrower : IThrower
{
    public static Thrower Create(Func<string, Exception> exceptionThrower)
    {
        var thrower = new Thrower();
        thrower.SetException(exceptionThrower);
        return thrower;
    }

    private Func<string, Exception> _exceptionThrower = (string message) => new ArgumentException(message);

    public void SetException(Func<string, Exception> exceptionThrower) => _exceptionThrower = exceptionThrower;

    public bool IfTrue<T>(bool condition, string message)
    {
        return condition ? throw _exceptionThrower(message) : true;
    }

    public bool IfFalse<T>(bool condition, string message)
    {
        return condition ? true : throw _exceptionThrower(message);
    }

    public bool IfDefault<T>(T obj, string message)
    {
        var isDefault = EqualityComparer<T>.Default.Equals(obj, default);
        return isDefault ? throw _exceptionThrower(message) : true;
    }

    public bool IfNotNull(object? obj, string message)
    {
        return obj != null ? throw _exceptionThrower(message) : true;
    }

    public bool IfNull(object? obj, string message)
    {
        return obj == null ? throw _exceptionThrower(message) : true;
    }

    public bool IfNotEqual(object obj, object objToComapere, string message)
    {
        return obj.Equals(objToComapere) ? true : throw _exceptionThrower(message);
    }

    public bool IfZero(int number, string message)
    {
        return number == 0 ? throw _exceptionThrower(message) : true;
    }

    public bool IfZero(decimal number, string message)
    {
        return number == 0 ? throw _exceptionThrower(message) : true;
    }

    public bool IfGreaterOrEqual(int number, int numberToCompare, string message)
    {
        return number >= numberToCompare ? throw _exceptionThrower(message) : true;
    }

    public bool IfGreater(int number, int numberToCompare, string message)
    {
        return number > numberToCompare ? throw _exceptionThrower(message) : true;
    }

    public bool IfGreaterOrEqual(decimal number, decimal numberToCompare, string message)
    {
        return number >= numberToCompare ? throw _exceptionThrower(message) : true;
    }

    public bool IfGreater(decimal number, decimal numberToCompare, string message)
    {
        return number > numberToCompare ? throw _exceptionThrower(message) : true;
    }

    public bool IfEmpty(string text, string message)
    {
        return string.IsNullOrEmpty(text) ? throw _exceptionThrower(message) : true;
    }

    public bool IfNotParseToLong(string text, string message)
    {
        return long.TryParse(text, out var _) ? true : throw _exceptionThrower(message);
    }

    public bool IfEmpty<T>(IEnumerable<T> list, string message)
    {
        return list.Any() ? true : throw _exceptionThrower(message);
    }

    public bool IfOlder(DateTime date, DateTime dateToCompare, string message)
    {
        return date < dateToCompare ? throw _exceptionThrower(message) : true;
    }

    public bool IfOlderOrEqual(DateTime date, DateTime dateToCompare, string message)
    {
        return date <= dateToCompare ? throw _exceptionThrower(message) : true;
    }
}
