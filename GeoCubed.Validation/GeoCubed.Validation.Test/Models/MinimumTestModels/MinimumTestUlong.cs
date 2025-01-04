using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestUlong
{
    [Minimum("100")]
    public ulong Value { get; set; }
}
