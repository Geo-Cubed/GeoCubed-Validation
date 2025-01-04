using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestUshort
{
    [Minimum("100")]
    public ushort Value { get; set; }
}
