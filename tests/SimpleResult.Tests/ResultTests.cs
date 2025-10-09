namespace SimpleResult.Tests;

public class ResultTests
{
    [Fact(DisplayName = nameof(Create_SuccessResult))]
    [Trait("Result", "Create")]
    public void Create_SuccessResult()
    {
        Result result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
    }

    [Fact(DisplayName = nameof(Create_FailureResult))]
    [Trait("Result", "Create")]
    public void Create_FailureResult()
    {
        var error = new Error("Test.Error", "Test error message", ErrorType.InvalidData);

        Result result = error;

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Single(result.Errors);
        Assert.Equal(error, result.Errors[0]);
    }

    [Fact(DisplayName = nameof(Create_FailureResult_ListErrors))]
    [Trait("Result", "Create")]
    public void Create_FailureResult_ListErrors()
    {
        var errors = new List<Error>
        {
            new Error("Test.Error1", "Test error message", ErrorType.Conflict),
            new Error("Test.Error2", "Test error message", ErrorType.RuleViolation)
        };

        Result result = errors;

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        foreach (var error in errors)
        {
            Assert.Contains(error, result.Errors);
        }
    }

    [Fact(DisplayName = nameof(Create_FailureResult_NullErrors))]
    [Trait("Result", "Create")]
    public void Create_FailureResult_NullErrors()
    {
        List<Error>? errors = null;

        Action act = () => { Result result = errors!; };

        var exception = Assert.Throws<ArgumentNullException>(act);
        Assert.Equal("An error result must have at least one error (Parameter 'errors')", exception.Message);
    }

    [Fact(DisplayName = nameof(Create_FailureResult_EmptyErrors))]
    [Trait("Result", "Create")]
    public void Create_FailureResult_EmptyErrors()
    {
        List<Error> errors = new List<Error>();

        Action act = () => { Result result = errors; };

        var exception = Assert.Throws<ArgumentNullException>(act);
        Assert.Equal("An error result must have at least one error (Parameter 'errors')", exception.Message);
    }

    [Fact(DisplayName = nameof(Match_Success))]
    [Trait("Result", "Match")]
    public void Match_Success()
    {
        Result result = Result.Success();

        var response = result.Match(
            onSuccess: () => true,
            onError: _ => false);
        
        Assert.True(response);
    }

    [Fact(DisplayName = nameof(Match_Failure))]
    [Trait("Result", "Match")]
    public void Match_Failure()
    {
        var error = new Error("Test.Error", "Test error message", ErrorType.Unauthorized);
        Result result = error;

        var response = result.Match(
            onSuccess: () => "test",
            onError: e => e.First().Message);

        Assert.Equal(error.Message, response);
    }
}