# GHM.Validator

GHM.Validator is a nuget package with the aim of validating data.

## IServiceCollectionExtentions

To add scoped interface `IValidator` to implementation `Validator`, call extension method to your serviceCollection.

```csharp
using  GHM.Validator.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
service.AddGhmValidator();
```

## Example

## Validation object

Validation is a object with properties(Message, IsValid).

```csharp
var validationSuccess = Validation.Success("Successful message");

validationSuccess.Message; // "Successful message"
validationSuccess.IsValid; // true

var validationError = Validation.Error("Error message");

validationError.Message; // "Error message"
validationError.IsValid; // false
```

### Validate request data

```csharp

public Validation[] ValidateCreateUserRequest(CreateUserRequest request)
{
    IValidator validator;

    return new Validation[]
    {
        validator.ValidateIfNotNull(request.Name,"Name must not be null"),
        validator.ValidateIfNotZero(request.Age,"Age must not be 0")
    };
}
```

### Throw if request data is invalid

```csharp
public bool ValidateCreateUserRequest(CreateUserRequest request)
{
    IValidator validator;
    validator.ThrowIfNull(request.Name,"Name must not be null");
    validator.ThrowIfZero(request.Age,"Age must not be 0");

    return true;
}
```

## Returns

### Base Interface

IValidator is inherited from IThrowerService and IValidationService.

```csharp
public interface IValidator : IThrowerService, IValidationService { }
```

### Validation Return

You can use it to return a validation result with method struct object.

```csharp

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
    Validation ValidateIfOlder(DateTime date, DateTime dateToCompare, string message);
    Validation ValidateIfOlderOrEqual(DateTime date, DateTime dateToCompare, string message);
}

```

### Throw Exception

You can use it to throw exception with method struct object.

```csharp
public interface IThrowerService
{
    bool ThrowIfDefault<T>(T obj, string message);
    bool ThrowIfNotNull(object? obj, string message);
    bool ThrowIfNull(object? obj, string message);
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
    bool ThrowIfOlder(DateTime date, DateTime dateToCompare, string message);
    bool ThrowIfOlderOrEqual(DateTime date, DateTime dateToCompare, string message);
}
```

## Star

if you enjoy, don't forget the ⭐ and install the package 😊.
