# GHM.Validator

GHM.Validator is a nuget package with the aim of validating data

## IServiceCollectionExtentions

To add scoped interface `IValidator` to implementation `Validator`, call extension method to your serviceCollection

```csharp
using  GHM.Validator.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
service.AddGhmValidator();
```

## Example

## Validation object
Validation is a object with properties(Message, IsValid)
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

### Validation Return

You can use it to return a validation result with method struct object 

```csharp
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
```

### Throw Exception

You can use it to throw exception with method struct object 

```csharp
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
```