using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation.Test.Models.WithinTestModels;

public class WithinTestAll
{
    [Within(minimumValue: "1", maximumValue: "100")]
    public int? ValueInt { get; set; }

    [Within(minimumValue: "1", maximumValue: "100", "Test")]
    public int? ErrorMessage { get; set; }

    [Within(minimumValue: "2.2", maximumValue: "10.0")]
    public decimal? ValueDecimal { get; set; }
}
