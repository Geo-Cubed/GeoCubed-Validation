using GeoCubed.Validation.Test.Helpers;
using GeoCubed.Validation.Test.Models.MaximumTestModels;

namespace GeoCubed.Validation.Test;

public class MaximumTests
{
    public MaximumTests()
    {
        TestValidationHelper.SetDefualtErrorMessage("The value was more than the maximum value.");    
    }

    [Fact]
    public void TestMaximumValueLess()
    {
        var model = new MaximumAll()
        {
            ValueInt = int.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }

    [Fact]
    public void TestMaximumValueEqual()
    {
        var model = new MaximumAll()
        {
            ValueInt = 0,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }

    [Fact]
    public void TestMaximumValueGreater()
    {
        var model = new MaximumAll()
        {
            ValueInt = int.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueInt");
    }

    [Fact]
    public void TestMaximumValueErrorMessage()
    {
        var model = new MaximumAll()
        {
            ValueError = int.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);

        Assert.True(validation.HasErrors);
        Assert.NotEmpty(validation.Errors);

        var error = validation.Errors[0];
        Assert.Equal("Validation Error on: ValueError | Test", error.Message);
        Assert.Equal("ValueError", error.Property);
    }

    [Fact]
    public void TestMaximumValueSbytePass()
    {
        var model = new MaximumAll()
        {
            ValueSByte = sbyte.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }
    
    [Fact]
    public void TestMaximumValueSbyteFail()
    {
        var model = new MaximumAll()
        {
            ValueSByte = sbyte.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueSByte");
    }
    
    [Fact]
    public void TestMaximumValueBytePass()
    {
        var model = new MaximumAll()
        {
            ValueByte = byte.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }
    
    [Fact]
    public void TestMaximumValueByteFail()
    {
        var model = new MaximumAll()
        {
            ValueByte = byte.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueByte");
    }
    
    [Fact]
    public void TestMaximumValueShortPass()
    {
        var model = new MaximumAll()
        {
            ValueShort = short.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }
    
    [Fact]
    public void TestMaximumValueShortFail()
    {
        var model = new MaximumAll()
        {
            ValueShort = short.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueShort");
    }
    
    [Fact]
    public void TestMaximumValueUshortPass()
    {
        var model = new MaximumAll()
        {
            ValueUShort = ushort.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }
    
    [Fact]
    public void TestMaximumValueUshortFail()
    {
        var model = new MaximumAll()
        {
            ValueUShort = ushort.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueUShort");
    }
    
    [Fact]
    public void TestMaximumValueIntPass()
    {
        var model = new MaximumAll()
        {
            ValueInt = int.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }
    
    [Fact]
    public void TestMaximumValueIntFail()
    {
        var model = new MaximumAll()
        {
            ValueInt = int.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueInt");
    }
    
    [Fact]
    public void TestMaximumValueUintPass()
    {
        var model = new MaximumAll()
        {
            ValueUInt = uint.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }
    
    [Fact]
    public void TestMaximumValueUintFail()
    {
        var model = new MaximumAll()
        {
            ValueUInt = uint.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueUInt");
    }
    
    [Fact]
    public void TestMaximumValueLongPass()
    {
        var model = new MaximumAll()
        {
            ValueLong = long.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }
    
    [Fact]
    public void TestMaximumValueLongFail()
    {
        var model = new MaximumAll()
        {
            ValueLong = long.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueLong");
    }
    
    [Fact]
    public void TestMaximumValueUlongPass()
    {
        var model = new MaximumAll()
        {
            ValueULong = ulong.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }
    
    [Fact]
    public void TestMaximumValueUlongFail()
    {
        var model = new MaximumAll()
        {
            ValueULong = ulong.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueULong");
    }
    
    [Fact]
    public void TestMaximumValueFloatPass()
    {
        var model = new MaximumAll()
        {
            ValueFloat = float.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }
    
    [Fact]
    public void TestMaximumValueFloatFail()
    {
        var model = new MaximumAll()
        {
            ValueFloat = float.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueFloat");
    }

    [Fact]
    public void TestMaximumValueFloatPassDecimal()
    {
        var model = new MaximumAll()
        {
            ValueFloatDecimal = 2.2f,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }

    [Fact]
    public void TestMaximumValueFloatFailDecimal()
    {
        var model = new MaximumAll()
        {
            ValueFloatDecimal = 2.201f,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueFloatDecimal");
    }
    
    [Fact]
    public void TestMaximumValueDoublePass()
    {
        var model = new MaximumAll()
        {
            ValueDouble = double.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }

    [Fact]
    public void TestMaximumValueDoubleFail()
    {
        var model = new MaximumAll()
        {
            ValueDouble = double.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueDouble");
    }
    
    [Fact]
    public void TestMaximumValueDecimalPass()
    {
        var model = new MaximumAll()
        {
            ValueDecimal = decimal.MinValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidatePass(validation);
    }

    [Fact]
    public void TestMaximumValueDecimalFail()
    {
        var model = new MaximumAll()
        {
            ValueDecimal = decimal.MaxValue,
        };

        var validation = AttributeValidator.Validate(model);
        TestValidationHelper.ValidateFail(validation, "ValueDecimal");
    }
}
