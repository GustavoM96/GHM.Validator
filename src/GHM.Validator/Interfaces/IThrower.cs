namespace GHM.Validator.Interfaces;

public interface IThrower
{
    void SetException(Func<string, Exception> exceptionThrower);
    bool IfFalse<T>(bool condition, string message);
    bool IfTrue<T>(bool condition, string message);
    bool IfDefault<T>(T obj, string message);
    bool IfNotNull(object? obj, string message);
    bool IfNull(object? obj, string message);
    bool IfNotEqual(object obj, object objToComapere, string message);
    bool IfZero(int number, string message);
    bool IfZero(decimal number, string message);
    bool IfGreaterOrEqual(int number, int numberToCompare, string message);
    bool IfGreater(int number, int numberToCompare, string message);
    bool IfGreaterOrEqual(decimal number, decimal numberToCompare, string message);
    bool IfGreater(decimal number, decimal numberToCompare, string message);
    bool IfEmpty(string text, string message);
    bool IfNotParseToLong(string text, string message);
    bool IfEmpty<T>(IEnumerable<T> list, string message);
    bool IfOlder(DateTime date, DateTime dateToCompare, string message);
    bool IfOlderOrEqual(DateTime date, DateTime dateToCompare, string message);
}
