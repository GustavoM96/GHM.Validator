namespace GHM.Validator.Interfaces;

public interface IValidator
{
    Validation ValidateIfNotNull(object obj, string message);
    Validation ValidateIfNull(object obj, string message);
    Validation ValidateIfEqual(object objBase, object objToComapere, string message);
    Validation ValidateIfBiggerOrEqualThan(int number, int numberToCompare, string message);
    Validation ValidateIfBiggerThan(int number, int numberToCompare, string message);
    Validation ValidateIfBiggerOrEqualThan(decimal number, decimal numberToCompare, string message);
    Validation ValidateIfBiggerThan(decimal number, decimal numberToCompare, string message);
    Validation ValidateIfNotEmpty(string text, string message);
    Validation ValidateIfParseToBigInt(string text, string message);
    Validation ValidateIfNotEmpty<T>(IEnumerable<T> list, string message);

    bool ThrowIfNotNull(object obj, string message);
    bool ThrowIfNull(object obj, string message);
    bool ThrowIfNotEqual(object objBase, object objToComapere, string message);
    bool ThrowIfBiggerOrEqualThan(int number, int numberToCompare, string message);
    bool ThrowIfBiggerThan(int number, int numberToCompare, string message);
    bool ThrowIfBiggerOrEqualThan(decimal number, decimal numberToCompare, string message);
    bool ThrowIfBiggerThan(decimal number, decimal numberToCompare, string message);
    bool ThrowIfEmpty(string text, string message);
    bool ThrowIfNotParseToBigInt(string text, string message);
    bool ThrowIfEmpty<T>(IEnumerable<T> list, string message);
}
