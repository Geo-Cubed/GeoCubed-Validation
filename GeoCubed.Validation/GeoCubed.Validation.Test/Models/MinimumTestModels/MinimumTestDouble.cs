using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestDouble
{
    [Minimum("0")]
    public double Value { get; set; }
}
