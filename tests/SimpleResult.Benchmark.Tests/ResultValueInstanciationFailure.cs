using BenchmarkDotNet.Attributes;

namespace SimpleResult.Benchmark.Tests;

[MemoryDiagnoser]
public class ResultValueInstanciationFailure
{
    [Benchmark(Baseline = true)]
    public Result<int> Instaciate_ResultGeneric_WithErrors()
    {
        var errors = new List<Error>()
        {
            new("Teste.Performance", "Creating a readonly record struct Error 1", ErrorType.Unexpected),
            new("Teste.Performance", "Creating a readonly record struct Error 2", ErrorType.Unprocessable)
        };

        Result<int> result = errors;

        return result;
    }

    [Benchmark]
    public FluentResults.Result<int> Instanciate_FluentResultGeneric_WithErrors()
    {
        var errors = new List<FluentResults.IError>()
        {
            new FluentResults.Error("Creating a readonly record struct Error 1"),
            new FluentResults.Error("Creating a readonly record struct Error 2")
        };

        FluentResults.Result<int> result = FluentResults.Result.Fail(errors);

        return result;
    }

    [Benchmark]
    public Ardalis.Result.Result<int> Instanciate_ArdalisResultGeneric_WithErrors()
    {
        var errors = new List<Ardalis.Result.ValidationError>()
        {
            new Ardalis.Result.ValidationError(null, "Creating a readonly record struct Error 1", "Teste.Performance", Ardalis.Result.ValidationSeverity.Error),
            new Ardalis.Result.ValidationError(null, "Creating a readonly record struct Error 2", "Teste.Performance", Ardalis.Result.ValidationSeverity.Error),
        };

        Ardalis.Result.Result<int> result = Ardalis.Result.Result.Invalid(errors);

        return result;
    }
}
