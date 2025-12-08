namespace GHM.Validator;

internal abstract class ValidateBase
{
    protected static string GetDefaultErrorMessage(
        string? message,
        string validationName,
        string? paramName,
        object? value
    ) => message ?? $"Error to validate param: {paramName}. Value: {value}. ValidationName: {validationName}";

    protected static string GetDefaultSuccessMessage(
        string? message,
        string validationName,
        string? paramName,
        object? value
    ) => message ?? $"Validated param: {paramName}. Value: {value}. ValidationName: {validationName}";

    protected static string GetDefaultErrorMessage(
        string? message,
        string validationName,
        string? paramName,
        object? value,
        object? toCompare
    ) => message ?? $"Error: param: {paramName}. Value: {value}. Compare: {toCompare}. ValidationName: {validationName}";

    protected static string GetDefaultSuccessMessage(
        string? message,
        string validationName,
        string? paramName,
        object? value,
        object? toCompare
    ) => message ?? $"Validated: param: {paramName}. Value: {value}. Compare: {toCompare}. ValidationName: {validationName}";
}
