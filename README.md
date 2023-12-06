<p align="center">
<img src="logo.png" alt="logo" width="200px"/>
</p>

<h1 align="center"> GHM.Validator </h1>

GHM.Validator is a nuget package aims to validate data.

## Install Package

.NET CLI

```sh
dotnet add package GHM.Validator --version 2.0.0
```

Package Manager

```sh
NuGet\Install-Package GHM.Validator -Version 2.0.0
```

## IServiceCollectionExtensions

To add scoped interface `IValidate` to implementate `Validate` or `IThrower` to implementate `Thrower` , call extension method to your serviceCollection.

```csharp
using GHM.Validator.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
service.AddGhmValidator();
```

## Example

### To validate request data

```csharp
using GHM.Validator;

public Validation[] ValidateCreateUserRequest(CreateUserRequest request)
{
    IValidate validate;

    return new Validation[]
    {
        validate.IfNotNull(request.Name,"Name must not be null"),
        validate.IfNotZero(request.Age,"Age must not be 0")
    };
}
```

### To throw if request data is invalid

```csharp
using GHM.Validator;

public bool ValidateCreateUserRequest(CreateUserRequest request)
{
    IThrower thrower;

    thrower.IfNull(request.Name,"Name must not be null");
    thrower.IfZero(request.Age,"Age must not be 0");

    return true;
}
```

## Classes

### Validation

Validation is a object with properties(Message, IsValid).

```csharp
using GHM.Validator;

var validationSuccess = Validation.Success("Successful message");

validationSuccess.Message; // "Successful message"
validationSuccess.IsValid; // true

var validationError = Validation.Error("Error message");

validationError.Message; // "Error message"
validationError.IsValid; // false
```

## Interfaces

### IValidate

You can use it to return a validation result.

```csharp

public interface IValidate
{
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

```

### IThrower

You can use it to throw exception.

```csharp
public interface IThrower
{
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
```

## Star

if you enjoy, don't forget the ⭐ and install the package 😊.
