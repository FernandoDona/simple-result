using BenchmarkDotNet.Attributes;

namespace SimpleResult.Benchmark.Tests;

[MemoryDiagnoser]
public class ResultValueInstanciationSuccess
{
    [Benchmark(Baseline = true)]
    public Result<int> Instaciate_Result_WithValue()
    {
        Result<int> result = 42;

        return result;
    }

    [Benchmark]
    public FluentResults.Result<int> Instantiate_FluentResult_WithValue()
    {
        FluentResults.Result<int> result = FluentResults.Result.Ok(42);

        return result;
    }

    [Benchmark]
    public Ardalis.Result.Result<int> Instantiate_ArdalisResult_WithValue()
    {
        Ardalis.Result.Result<int> result = Ardalis.Result.Result.Success(42);

        return result;
    }
}
