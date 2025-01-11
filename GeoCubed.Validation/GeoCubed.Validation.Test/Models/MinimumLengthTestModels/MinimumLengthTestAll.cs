using GeoCubed.Validation.Attributes;
using System.Collections.ObjectModel;

namespace GeoCubed.Validation.Test.Models.MinimumLengthTestModels;

public class MinimumLengthTestAll
{
    [MinimumLength(10)]
    public string? StringValue { get; set; }

    [MinimumLength(2)]
    public string[]? ArrayValue { get; set; }

    [MinimumLength(2)]
    public List<string>? ListValue { get; set; }

    [MinimumLength(2)]
    public Collection<string>? CollectionValue { get; set; }

    [MinimumLength(2, "Test")]
    public string? ErrorMessage { get; set; }
}
