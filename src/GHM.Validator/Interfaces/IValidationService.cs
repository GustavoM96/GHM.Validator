namespace GHM.Validator.Interfaces;

public interface IValidationService
{
    Validation ValidateIfNotDefault<T>(T obj, string message);
    Validation ValidateIfNotNull(object? obj, string message);
    Validation ValidateIfNull(object? obj, string message);
    Validation ValidateIfEqual(object obj, object objToComapere, string message);
    Validation ValidateIfNotZero(int number, string message);
    Validation ValidateIfNotZero(decimal number, string message);
    Validation ValidateIfGreaterOrEqual(int number, int numberToCompare, string message);
    Validation ValidateIfGreater(int number, int numberToCompare, string message);
    Validation ValidateIfGreaterOrEqual(decimal number, decimal numberToCompare, string message);
    Validation ValidateIfGreater(decimal number, decimal numberToCompare, string message);
    Validation ValidateIfNotEmpty(string text, string message);
    Validation ValidateIfParseToLong(string text, string message);
    Validation ValidateIfNotEmpty<T>(IEnumerable<T> list, string message);
    Validation ValidateIfOlder<T>(DateTime date, DateTime dateToCompare, string message);
    Validation ValidateIfOlderOrEqual<T>(DateTime date, DateTime dateToCompare, string message);
}
