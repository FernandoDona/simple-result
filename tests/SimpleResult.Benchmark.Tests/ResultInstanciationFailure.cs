using BenchmarkDotNet.Attributes;

namespace SimpleResult.Benchmark.Tests;

[MemoryDiagnoser]
public class ResultInstanciationFailure
{
    [Benchmark(Baseline = true)]
    public Result Instaciate_Result_WithErrors()
    {
        var errors = new List<Error>()
        {
            new("Teste.Performance", "Creating a readonly record struct Error 1", ErrorType.Unexpected),
            new("Teste.Performance", "Creating a readonly record struct Error 2", ErrorType.Unprocessable)
        };

        Result result = errors;

        return result;
    }

    [Benchmark]
    public FluentResults.Result Instantiate_FluentResult_WithErrors()
    {
        var errors = new List<FluentResults.IError>()
        {
            new FluentResults.Error("Creating a readonly record struct Error 1"),
            new FluentResults.Error("Creating a readonly record struct Error 2")
        };

        FluentResults.Result result = FluentResults.Result.Fail(errors);

        return result;
    }

    [Benchmark]
    public Ardalis.Result.Result Instantiate_ArdalisResult_WithErrors()
    {
        var errors = new List<Ardalis.Result.ValidationError>()
        {
            new Ardalis.Result.ValidationError(null, "Creating a readonly record struct Error 1", "Teste.Performance", Ardalis.Result.ValidationSeverity.Error),
            new Ardalis.Result.ValidationError(null, "Creating a readonly record struct Error 2", "Teste.Performance", Ardalis.Result.ValidationSeverity.Error),
        };

        Ardalis.Result.Result result = Ardalis.Result.Result.Invalid(errors);

        return result;
    }
}
