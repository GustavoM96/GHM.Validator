namespace GHM.Validator.Interfaces;

public interface IValidator
{
    Validation ValidateIfNotDefault<T>(T obj, string message);
    Validation ValidateIfNotNull(object obj, string message);
    Validation ValidateIfNull(object obj, string message);
    Validation ValidateIfEqual(object obj, object objToComapere, string message);
    Validation ValidateIfNotZero(int number, string message);
    Validation ValidateIfNotZero(decimal number, string message);
    Validation ValidateIfBiggerOrEqualThan(int number, int numberToCompare, string message);
    Validation ValidateIfBiggerThan(int number, int numberToCompare, string message);
    Validation ValidateIfBiggerOrEqualThan(decimal number, decimal numberToCompare, string message);
    Validation ValidateIfBiggerThan(decimal number, decimal numberToCompare, string message);
    Validation ValidateIfNotEmpty(string text, string message);
    Validation ValidateIfParseToLong(string text, string message);
    Validation ValidateIfNotEmpty<T>(IEnumerable<T> list, string message);
    Validation ValidateIfOlderThan<T>(DateTime date, DateTime dateToCompare, string message);
    Validation ValidateIfOlderOrEqualThan<T>(DateTime date, DateTime dateToCompare, string message);

    bool ThrowIfDefault<T>(T obj, string message);
    bool ThrowIfNotNull(object obj, string message);
    bool ThrowIfNull(object obj, string message);
    bool ThrowIfNotEqual(object obj, object objToComapere, string message);
    bool ThrowIfZero(int number, string message);
    bool ThrowIfZero(decimal number, string message);
    bool ThrowIfBiggerOrEqualThan(int number, int numberToCompare, string message);
    bool ThrowIfBiggerThan(int number, int numberToCompare, string message);
    bool ThrowIfBiggerOrEqualThan(decimal number, decimal numberToCompare, string message);
    bool ThrowIfBiggerThan(decimal number, decimal numberToCompare, string message);
    bool ThrowIfEmpty(string text, string message);
    bool ThrowIfNotParseToLong(string text, string message);
    bool ThrowIfEmpty<T>(IEnumerable<T> list, string message);
    bool ThrowIfOlderThan<T>(DateTime date, DateTime dateToCompare, string message);
    bool ThrowIfOlderOrEqualThan<T>(DateTime date, DateTime dateToCompare, string message);
}
