namespace GeoCubed.Validation.Attributes;

/// <summary>
/// Validation attribute to set the minimum value for an field.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class Minimum : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "";

    private readonly long _minimumValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="Minimum"/> class.
    /// </summary>
    /// <param name="minimumValue">The minimum value.</param>
    public Minimum(long minimumValue)
        : base(_defaultErrorMessage)
    {
        this._minimumValue = minimumValue;
    }

    /// <summary>
    /// Checks if the value is at minium the minimum value.
    /// </summary>
    /// <param name="value">The value of the property.</param>
    /// <returns>True if valid, False otherwise.</returns>
    public override bool IsValid(object value)
    {
        // TODO: sort this :D.
        return (long)value >= this._minimumValue;
    }
}
