using GeoCubed.Validation.Attributes;
using GeoCubed.Validation.Test.Models.WithinTestModels;

namespace GeoCubed.Validation.Test;

/// <summary>
/// Tests for the <see cref="Within"/> validation attribute.
/// </summary>
public class WithinTests
{
    /// <summary>
    /// Test validation fail on value less than the range.
    /// </summary>
    [Fact]
    public void TestLessThan()
    {
        var model = new WithinTestAll()
        {
            ValueInt = 0,
        };

        var result = Validator.Validate(model);
        this.ValidateFail(result, "ValueInt");
    }

    /// <summary>
    /// Test validation pass on value being lower bound.
    /// </summary>
    [Fact]
    public void TestWithinRangeLowerBound()
    {
        var model = new WithinTestAll()
        {
            ValueInt = 1,
        };

        var result = Validator.Validate(model);
        this.ValidatePass(result);
    }
    
    /// <summary>
    /// Test validation pass on value being upper bound.
    /// </summary>
    [Fact]
    public void TestWithinRangeUpperBound()
    {
        var model = new WithinTestAll()
        {
            ValueInt = 10,
        };

        var result = Validator.Validate(model);
        this.ValidatePass(result);
    }
    
    /// <summary>
    /// Test validation pass on value being within range.
    /// </summary>
    [Fact]
    public void TestWithinRange()
    {
        var model = new WithinTestAll()
        {
            ValueInt = 100,
        };

        var result = Validator.Validate(model);
        this.ValidatePass(result);
    }

    /// <summary>
    /// Test validation fail on value being greater than the range.
    /// </summary>
    [Fact]
    public void TestGreaterThan()
    {
        var model = new WithinTestAll()
        {
            ValueInt = 101,
        };

        var result = Validator.Validate(model);
        this.ValidateFail(result, "ValueInt");
    }

    /// <summary>
    /// Test correct error message used on validation fail.
    /// </summary>
    [Fact]
    public void TestErrorMessage()
    {
        var model = new WithinTestAll()
        {
            ErrorMessage = 0,
        };

        var result = Validator.Validate(model);
        Assert.True(result.HasErrors);
        Assert.NotEmpty(result.Errors);

        var error = result.Errors[0];
        Assert.Equal($"Validation Error on: ErrorMessage | Test", error.errorMessage);
        Assert.Equal("ErrorMessage", error.property);
    }

    /// <summary>
    /// Test validation fail on decimal value being less than minimum.
    /// </summary>
    [Fact]
    public void TestLessThanDecimal() 
    {
        var model = new WithinTestAll()
        {
            ValueDecimal = 2.1m,
        };

        var result = Validator.Validate(model);
        this.ValidateFail(result, "ValueDecimal");
    }
    
    /// <summary>
    /// Test validation pass on decimal value being the lower bound.
    /// </summary>
    [Fact]
    public void TestWithinRangeLowerBoundDecimal() 
    {
        var model = new WithinTestAll()
        {
            ValueDecimal = 2.2m,
        };

        var result = Validator.Validate(model);
        this.ValidatePass(result);
    }

    /// <summary>
    /// Test validation pass on decimal value being within the range.
    /// </summary>
    [Fact]
    public void TestWithinRangeDecimal()
    {
        var model = new WithinTestAll()
        {
            ValueDecimal = 5m,
        };

        var result = Validator.Validate(model);
        this.ValidatePass(result);
    }
    
    /// <summary>
    /// Test validation pass on decimal value being upper bound.
    /// </summary>
    [Fact]
    public void TestWithinRangeUpperBoundDecimal()
    {
        var model = new WithinTestAll()
        {
            ValueDecimal = 10.0m,
        };

        var result = Validator.Validate(model);
        this.ValidatePass(result);
    }

    /// <summary>
    /// Test validation fail on decimal value being greater than the maximum.
    /// </summary>
    [Fact]
    public void TestGreaterThanDecimal()
    {
        var model = new WithinTestAll()
        {
            ValueDecimal = 10.1m,
        };

        var result = Validator.Validate(model);
        this.ValidateFail(result, "ValueDecimal");
    }

    private void ValidatePass(ValidationResult result)
    {
        Assert.False(result.HasErrors);
        Assert.Empty(result.Errors);
    }

    private void ValidateFail(ValidationResult result, string propertyName)
    {
        Assert.True(result.HasErrors);
        Assert.NotEmpty(result.Errors);

        var error = result.Errors[0];
        Assert.Equal($"Validation Error on: {propertyName} | The value was not within the range provided.", error.errorMessage);
        Assert.Equal(propertyName, error.property);
    }
}
