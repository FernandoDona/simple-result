using BenchmarkDotNet.Running;
using SimpleResult.Benchmark.Tests;

BenchmarkRunner.Run<ResultInstanciationSuccess>();
BenchmarkRunner.Run<ResultInstanciationFailure>();
BenchmarkRunner.Run<ResultValueInstanciationSuccess>();
BenchmarkRunner.Run<ResultValueInstanciationFailure>();