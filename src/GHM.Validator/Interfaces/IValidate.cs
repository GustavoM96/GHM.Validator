namespace GHM.Validator.Interfaces;

public interface IValidate
{
    Validation IfTrue(bool condition, string message);
    Validation IfFalse(bool condition, string message);
    Validation IfNotDefault<T>(T obj, string message);
    Validation IfNotNull(object? obj, string message);
    Validation IfNull(object? obj, string message);
    Validation IfEqual(object obj, object objToComapere, string message);
    Validation IfNotZero(int number, string message);
    Validation IfNotZero(decimal number, string message);
    Validation IfGreaterOrEqual(int number, int numberToCompare, string message);
    Validation IfGreater(int number, int numberToCompare, string message);
    Validation IfGreaterOrEqual(decimal number, decimal numberToCompare, string message);
    Validation IfGreater(decimal number, decimal numberToCompare, string message);
    Validation IfNotEmpty(string text, string message);
    Validation IfParseToLong(string text, string message);
    Validation IfNotEmpty<T>(IEnumerable<T> list, string message);
    Validation IfOlder(DateTime date, DateTime dateToCompare, string message);
    Validation IfOlderOrEqual(DateTime date, DateTime dateToCompare, string message);
}
