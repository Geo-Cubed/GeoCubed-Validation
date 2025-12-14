using GeoCubed.Validation.Attributes;
using GeoCubed.Validation.Test.Helpers;
using GeoCubed.Validation.Test.Models.WithinTestModels;

namespace GeoCubed.Validation.Test;

/// <summary>
/// Tests for the <see cref="Within"/> validation attribute.
/// </summary>
public class WithinTests
{
    public WithinTests()
    {
        TestValidationHelper.SetDefualtErrorMessage("The value was not within the range provided.");
    }

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

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(result, nameof(model.ValueInt));
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

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);
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

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);
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

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);
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

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(result, nameof(model.ValueInt));
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

        var result = AttributeValidator.Validate(model);
        Assert.True(result.HasErrors);
        Assert.NotEmpty(result.Errors);

        var error = result.Errors[0];
        Assert.Equal($"Validation Error on: ErrorMessage | Test", error.Message);
        Assert.Equal("ErrorMessage", error.Property);
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

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(result, nameof(model.ValueDecimal));
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

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);
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

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);
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

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(result);
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

        var result = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(result, nameof(model.ValueDecimal));
    }
}
