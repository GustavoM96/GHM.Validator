namespace GHM.Validator.Interfaces;

public interface IThrowerService
{
    bool ThrowIfDefault<T>(T obj, string message);
    bool ThrowIfNotNull(object obj, string message);
    bool ThrowIfNull(object obj, string message);
    bool ThrowIfNotEqual(object obj, object objToComapere, string message);
    bool ThrowIfZero(int number, string message);
    bool ThrowIfZero(decimal number, string message);
    bool ThrowIfGreaterOrEqual(int number, int numberToCompare, string message);
    bool ThrowIfGreater(int number, int numberToCompare, string message);
    bool ThrowIfGreaterOrEqual(decimal number, decimal numberToCompare, string message);
    bool ThrowIfGreater(decimal number, decimal numberToCompare, string message);
    bool ThrowIfEmpty(string text, string message);
    bool ThrowIfNotParseToLong(string text, string message);
    bool ThrowIfEmpty<T>(IEnumerable<T> list, string message);
    bool ThrowIfOlder<T>(DateTime date, DateTime dateToCompare, string message);
    bool ThrowIfOlderOrEqual<T>(DateTime date, DateTime dateToCompare, string message);
}
