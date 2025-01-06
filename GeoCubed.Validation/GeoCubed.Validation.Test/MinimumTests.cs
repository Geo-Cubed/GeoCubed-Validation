using GeoCubed.Validation.Attributes;
using GeoCubed.Validation.Test.Models.MinimumTestModels;

namespace GeoCubed.Validation.Test;

/// <summary>
/// Tests for the <see cref="Minimum"/> validation attribute.
/// </summary>
public class MinimumTests
{
    /// <summary>
    /// Test correct validation when value less than minimum.
    /// </summary>
    [Fact]
    public void TestMinimumValueLess()
    {
        var model = new MinimumTestInt()
        {
            Value = int.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test correct validation when value equal to minimum.
    /// </summary>
    [Fact]
    public void TestMinimumValueEqual()
    {
        var model = new MinimumTestInt()
        {
            Value = 0,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test correct validation when value greater than minimum.
    /// </summary>
    [Fact]
    public void TestMinimumValueGreater()
    {
        var model = new MinimumTestInt()
        {
            Value = int.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test correct error message on validation fail.
    /// </summary>
    [Fact]
    public void TestMinimumValueErrorMessage()
    {
        var model = new MinimumTestErrorMessage()
        {
            Value = 1,
        };

        var validation = Validator.Validate(model);

        Assert.True(validation.HasErrors);
        Assert.NotEmpty(validation.Errors);

        var error = validation.Errors[0];
        Assert.Equal("Validation Error on: Value | Test", error.errorMessage);
        Assert.Equal("Value", error.property);
    }

    /// <summary>
    /// Test validation pass on sbyte.
    /// </summary>
    [Fact]
    public void TestMinimimValueSbytePass()
    {
        var model = new MinimumTestSbyte()
        {
            Value = sbyte.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on sbyte.
    /// </summary>
    [Fact]
    public void TestMinimimValueSbyteFail()
    {
        var model = new MinimumTestSbyte()
        {
            Value = sbyte.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test validation pass on byte.
    /// </summary>
    [Fact]
    public void TestMinimimValueBytePass()
    {
        var model = new MinimumTestByte()
        {
            Value = byte.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on byte.
    /// </summary>
    [Fact]
    public void TestMinimimValueByteFail()
    {
        var model = new MinimumTestByte()
        {
            Value = byte.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test validation pass on short.
    /// </summary>
    [Fact]
    public void TestMinimimValueShortPass()
    {
        var model = new MinimumTestShort()
        {
            Value = short.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on short.
    /// </summary>
    [Fact]
    public void TestMinimimValueShortFail()
    {
        var model = new MinimumTestShort()
        {
            Value = short.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test validation pass on ushort.
    /// </summary>
    [Fact]
    public void TestMinimimValueUshortPass()
    {
        var model = new MinimumTestUshort()
        {
            Value = ushort.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on ushort.
    /// </summary>
    [Fact]
    public void TestMinimimValueUshortFail()
    {
        var model = new MinimumTestUshort()
        {
            Value = ushort.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test validation pass on int.
    /// </summary>
    [Fact]
    public void TestMinimumValueIntPass()
    {
        var model = new MinimumTestInt()
        {
            Value = int.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on int.
    /// </summary>
    [Fact]
    public void TestMinimumValueIntFail()
    {
        var model = new MinimumTestInt()
        {
            Value = int.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test validation pass on uint.
    /// </summary>
    [Fact]
    public void TestMinimumValueUintPass()
    {
        var model = new MinimumTestUint()
        {
            Value = uint.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on uint.
    /// </summary>
    [Fact]
    public void TestMinimumValueUintFail()
    {
        var model = new MinimumTestUint()
        {
            Value = uint.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test validation pass on long.
    /// </summary>
    [Fact]
    public void TestMinimumValueLongPass()
    {
        var model = new MinimumTestLong()
        {
            Value = long.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on long.
    /// </summary>
    [Fact]
    public void TestMinimumValueLongFail()
    {
        var model = new MinimumTestLong()
        {
            Value = long.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test validation pass on ulong.
    /// </summary>
    [Fact]
    public void TestMinimumValueUlongPass()
    {
        var model = new MinimumTestUlong()
        {
            Value = ulong.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on ulong.
    /// </summary>
    [Fact]
    public void TestMinimumValueUlongFail()
    {
        var model = new MinimumTestUlong()
        {
            Value = ulong.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test validation pass on float.
    /// </summary>
    [Fact]
    public void TestMinimumValueFloatPass()
    {
        var model = new MinimumTestFloat()
        {
            Value = float.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on float.
    /// </summary>
    [Fact]
    public void TestMinimumValueFloatFail()
    {
        var model = new MinimumTestFloat()
        {
            Value = float.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }

    /// <summary>
    /// Test validation pass on float where the minimum is a decimal value.
    /// </summary>
    [Fact]
    public void TestMinimumValueFloatPassDeciaml()
    {
        var model = new MinimumTestFloatDecimal()
        {
            Value = 2.2f,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on decimal where the minimum is a decimal value.
    /// </summary>
    [Fact]
    public void TestMinimumValueFloatFailDeciaml()
    {
        var model = new MinimumTestFloatDecimal()
        {
            Value = 2.199f,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test validation pass on double.
    /// </summary>
    [Fact]
    public void TestMinimumValueDoublePass()
    {
        var model = new MinimumTestDouble()
        {
            Value = double.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on double.
    /// </summary>
    [Fact]
    public void TestMinimumValueDoubleFail()
    {
        var model = new MinimumTestDouble()
        {
            Value = double.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }
    
    /// <summary>
    /// Test validation pass on decimal.
    /// </summary>
    [Fact]
    public void TestMinimumValueDecimalPass()
    {
        var model = new MinimumTestDecimal()
        {
            Value = decimal.MaxValue,
        };

        var validation = Validator.Validate(model);
        this.ValidatePass(validation);
    }
    
    /// <summary>
    /// Test validation fail on decimal.
    /// </summary>
    [Fact]
    public void TestMinimumValueDecimalFail()
    {
        var model = new MinimumTestDecimal()
        {
            Value = decimal.MinValue,
        };

        var validation = Validator.Validate(model);
        this.ValidateFail(validation);
    }

    private void ValidateFail(ValidationResult result)
    {
        Assert.True(result.HasErrors);
        Assert.NotEmpty(result.Errors);

        var error = result.Errors[0];
        Assert.Equal("Validation Error on: Value | The value was less than the minimum value.", error.errorMessage);
        Assert.Equal("Value", error.property);
    }

    private void ValidatePass(ValidationResult result)
    {
        Assert.False(result.HasErrors);
        Assert.Empty(result.Errors);
    }
}
