using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.MinimumTestModels;

public class MinimumTestSbyte
{
    [Minimum("-100")]
    public sbyte Value { get; set; }
}
