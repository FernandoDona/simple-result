namespace SimpleResult.Tests;
public class ErrorTests
{
    [Fact(DisplayName = nameof(Equals_WhenOnlyMessageIsDifferent))]
    [Trait("Error", "Equals")]
    public void Equals_WhenOnlyMessageIsDifferent()
    {
        var error1 = new Error("Teste.Code", "Message 1 teste", ErrorType.InvalidData);
        var error2 = new Error("Teste.Code", "Message 2 teste diff", ErrorType.InvalidData);

        Assert.Equal(error1, error2);
    }

    [Fact(DisplayName = nameof(Create_CustomError))]
    [Trait("Error", "Create - Custom")]
    public void Create_CustomError()
    {
        var error = new Error("Order.InvalidState", "Order must be paid to be shipped", ErrorType.InvalidState);

        Assert.Equal("Order.InvalidState", error.Code);
        Assert.Equal("Order must be paid to be shipped", error.Message);
        Assert.Equal(ErrorType.InvalidState, error.Type);
    }

    [Fact(DisplayName = nameof(Create_CustomErrorFromDefault))]
    [Trait("Error", "Create - Custom")]
    public void Create_CustomErrorFromDefault()
    {
        var error = Error.InvalidState("Order.InvalidState", "Order must be paid to be shipped");

        Assert.Equal("Order.InvalidState", error.Code);
        Assert.Equal("Order must be paid to be shipped", error.Message);
        Assert.Equal(ErrorType.InvalidState, error.Type);
    }

    [Fact(DisplayName = nameof(Create_DefaultInvalidDataError))]
    [Trait("Error", "Create - Default")]
    public void Create_DefaultInvalidDataError()
    {
        var error = Error.InvalidData();

        Assert.Equal(nameof(ErrorType.InvalidData), error.Code);
        Assert.Equal("Invalid data provided", error.Message);
        Assert.Equal(ErrorType.InvalidData, error.Type);
    }
    
    [Fact(DisplayName = nameof(Create_DefaultUnauthorizedError))]
    [Trait("Error", "Create - Default")]
    public void Create_DefaultUnauthorizedError()
    {
        var error = Error.Unauthorized();

        Assert.Equal(nameof(ErrorType.Unauthorized), error.Code);
        Assert.Equal("Authentication required", error.Message);
        Assert.Equal(ErrorType.Unauthorized, error.Type);
    }
    
    [Fact(DisplayName = nameof(Create_DefaultForbiddenError))]
    [Trait("Error", "Create - Default")]
    public void Create_DefaultForbiddenError()
    {
        var error = Error.Forbidden();

        Assert.Equal(nameof(ErrorType.Forbidden), error.Code);
        Assert.Equal("Access denied", error.Message);
        Assert.Equal(ErrorType.Forbidden, error.Type);
    }
    
    [Fact(DisplayName = nameof(Create_DefaultNotFoundError))]
    [Trait("Error", "Create - Default")]
    public void Create_DefaultNotFoundError()
    {
        var error = Error.NotFound();

        Assert.Equal(nameof(ErrorType.NotFound), error.Code);
        Assert.Equal("Resource not found", error.Message);
        Assert.Equal(ErrorType.NotFound, error.Type);
    }
    
    [Fact(DisplayName = nameof(Create_DefaultInvalidStateError))]
    [Trait("Error", "Create - Default")]
    public void Create_DefaultInvalidStateError()
    {
        var error = Error.InvalidState();

        Assert.Equal(nameof(ErrorType.InvalidState), error.Code);
        Assert.Equal("Invalid state for operation", error.Message);
        Assert.Equal(ErrorType.InvalidState, error.Type);
    }
    
    [Fact(DisplayName = nameof(Create_DefaultInvalidDataError))]
    [Trait("Error", "Create - Default")]
    public void Create_DefaultRuleViolationError()
    {
        var error = Error.RuleViolation();

        Assert.Equal(nameof(ErrorType.RuleViolation), error.Code);
        Assert.Equal("Business rules violation", error.Message);
        Assert.Equal(ErrorType.RuleViolation, error.Type);
    }
    
    [Fact(DisplayName = nameof(Create_DefaultUnprocessableError))]
    [Trait("Error", "Create - Default")]
    public void Create_DefaultUnprocessableError()
    {
        var error = Error.Unprocessable();

        Assert.Equal(nameof(ErrorType.Unprocessable), error.Code);
        Assert.Equal("Unprocessable action", error.Message);
        Assert.Equal(ErrorType.Unprocessable, error.Type);
    }
    
    [Fact(DisplayName = nameof(Create_DefaultConflictError))]
    [Trait("Error", "Create - Default")]
    public void Create_DefaultConflictError()
    {
        var error = Error.Conflict();

        Assert.Equal(nameof(ErrorType.Conflict), error.Code);
        Assert.Equal("Conflict detected", error.Message);
        Assert.Equal(ErrorType.Conflict, error.Type);
    }
    
    [Fact(DisplayName = nameof(Create_DefaultUnexpectedError))]
    [Trait("Error", "Create - Default")]
    public void Create_DefaultUnexpectedError()
    {
        var error = Error.Unexpected();

        Assert.Equal(nameof(ErrorType.Unexpected), error.Code);
        Assert.Equal("An unexpected error occured", error.Message);
        Assert.Equal(ErrorType.Unexpected, error.Type);
    }
}
