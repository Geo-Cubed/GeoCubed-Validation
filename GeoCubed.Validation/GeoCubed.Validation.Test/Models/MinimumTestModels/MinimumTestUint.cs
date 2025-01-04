using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestUint
{
    [Minimum("100")]
    public uint Value { get; set; }
}
