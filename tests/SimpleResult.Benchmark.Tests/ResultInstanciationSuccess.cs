using BenchmarkDotNet.Attributes;

namespace SimpleResult.Benchmark.Tests;

[MemoryDiagnoser]
public class ResultInstanciationSuccess
{
    [Benchmark(Baseline = true)]
    public Result Instaciate_Result()
    {
        Result result = Result.Success();

        return result;
    }

    [Benchmark]
    public FluentResults.Result Instantiate_FluentResult()
    {
        FluentResults.Result result = FluentResults.Result.Ok();

        return result;
    }

    [Benchmark]
    public Ardalis.Result.Result Instantiate_ArdalisResult()
    {
        Ardalis.Result.Result result = Ardalis.Result.Result.Success();

        return result;
    }
}
