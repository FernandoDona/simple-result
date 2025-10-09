# SimpleResult

SimpleResult is one of the simplest and fastest libraries implementing the Result Pattern.  
It was designed to be straightforward and focused, including only the essential features.

---

## 📑 Table of Contents
- [Overview](#overview)
- [How to Use](#how-to-use)
- [Examples](#examples)
  - [Returning Success or Error](#returning-success-or-error)
  - [Returning Multiple Errors](#returning-multiple-errors)
- [Benchmarks](#benchmarks)
- [License](#license)

---

## Overview

SimpleResult provides a minimal and high-performance implementation of the Result Pattern for .NET.  
It focuses on simplicity and performance while maintaining expressiveness and ease of use.

---

## How to Use

Unlike other Result Pattern libraries, SimpleResult creates a `Result` object only through **implicit conversions**.  
If a successful result has no value, you can use `Result.Success()`.  

In other words, if your function returns a `Result<T>`, you can simply return the **value** or the **error(s)** directly.

You also need to specify an `ErrorType`, which is useful when you want to classify errors (e.g., by HTTP status).

---

## Examples

### Returning Success or Error

```csharp
public Result<Order> SendOrder(Order order) 
{
    if (!order.IsPaid)
        return new Error("Order.CannotBeSent", "Order must be paid before it can be sent", ErrorType.InvalidState);
    
    order.Send();
    return order;
}
```

---

### Returning Multiple Errors

Here we use the static method `Error.InvalidData` to create errors of type `InvalidData`.

```csharp
public Result ValidateUser(User user) 
{
    var errors = new List<Error>();

    if (string.IsNullOrEmpty(user.Name))
        errors.Add(Error.InvalidData("User.Name", "User name cannot be null or empty"));
    if (string.IsNullOrEmpty(user.Email))
        errors.Add(Error.InvalidData("User.Email", "User email cannot be null or empty"));
    
    return errors.Any() 
        ? errors 
        : Result.Success();
}
```

---

## Benchmarks

Here are some benchmarks comparing the speed and memory allocation with two of the most popular Result Pattern libraries.

| Method                                      | Mean      | Error     | StdDev    | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------------------- |----------:|----------:|----------:|-------:|--------:|-------:|----------:|------------:|
| Instanciate_Result                          | 0.0209 ns | 0.0020 ns | 0.0019 ns |   1.01 |    0.12 |      - |         - |          NA |
| Instanciate_FluentResult                    | 7.0899 ns | 0.0367 ns | 0.0343 ns | 342.34 |   29.05 | 0.0089 |      56 B |          NA |
| Instanciate_ArdalisResult                   | 6.6181 ns | 0.0181 ns | 0.0151 ns | 319.56 |   27.09 | 0.0115 |      72 B |          NA |

| Method                                      | Mean       | Error     | StdDev    | Median     | Ratio  | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------------------- |-----------:|----------:|----------:|-----------:|-------:|--------:|-------:|----------:|------------:|
| Instanciate_Result_WithValue                |  0.0230 ns | 0.0008 ns | 0.0007 ns |  0.0228 ns |   1.00 |    0.04 |      - |         - |          NA |
| Instanciate_FluentResult_WithValue          | 20.0673 ns | 0.2854 ns | 0.2670 ns | 20.1302 ns | 875.04 |   28.54 | 0.0179 |     112 B |          NA |
| Instanciate_ArdalisResult_WithValue         |  6.7763 ns | 0.3117 ns | 0.9042 ns |  6.3659 ns | 295.48 |   40.24 | 0.0102 |      64 B |          NA |

| Method                                      | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------------------- |----------:|---------:|---------:|------:|--------:|-------:|----------:|------------:|
| Instanciate_ResultGeneric_WithErrors        |  15.66 ns | 0.299 ns | 0.280 ns |  1.00 |    0.02 | 0.0242 |     152 B |        1.00 |
| Instanciate_FluentResultGeneric_WithErrors  | 166.63 ns | 1.339 ns | 1.187 ns | 10.64 |    0.20 | 0.1273 |     800 B |        5.26 |
| Instanciate_ArdalisResultGeneric_WithErrors |  41.60 ns | 0.184 ns | 0.153 ns |  2.66 |    0.05 | 0.0510 |     320 B |        2.11 |

| Method                                      | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|-------------------------------------------- |---------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| Instanciate_Result_WithErrors               | 30.38 ns | 0.173 ns | 0.162 ns |  1.00 |    0.01 | 0.0408 |      - |     256 B |        1.00 |
| Instanciate_FluentResult_WithErrors         | 96.16 ns | 0.926 ns | 0.773 ns |  3.17 |    0.03 | 0.0867 | 0.0001 |     544 B |        2.12 |
| Instanciate_ArdalisResult_WithErrors        | 27.00 ns | 0.113 ns | 0.106 ns |  0.89 |    0.01 | 0.0408 |      - |     256 B |        1.00 |

---

## License

This project is licensed under the MIT License — see the [LICENSE](LICENSE) file for details.
