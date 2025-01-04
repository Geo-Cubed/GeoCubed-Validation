using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestFloatDecimal
{
    [Minimum("2.2")]
    public float Value { get; set; }
}
