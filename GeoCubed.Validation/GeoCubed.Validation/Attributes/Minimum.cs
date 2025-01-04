using System.ComponentModel;

namespace GeoCubed.Validation.Attributes;

/// <summary>
/// Validation attribute to set the minimum value for an field.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class Minimum : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "The value was less than the minimum value.";

    private readonly string _minimumValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="Minimum"/> class.
    /// </summary>
    /// <param name="minimumValue">The minimum value expressed as a string.</param>
    public Minimum(string minimumValue)
        : base(_defaultErrorMessage)
    {
        this._minimumValue = minimumValue;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Minimum"/> class.
    /// </summary>
    /// <param name="minimumValue">The minimum value expressed as a string.</param>
    /// <param name="errorMessage">The error message to use on fail.</param>
    public Minimum(string minimumValue, string errorMessage)
        : base(errorMessage)
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
        if (value == null)
        {
            return true;
        }

        // TODO: Error handling.
        var objType = value.GetType();
        var converter = TypeDescriptor.GetConverter(objType); // TODO: See what's better to use this or Convert.ChangeType.
        if (converter == null)
        {
            // Cannot find the type converter.
            return false;
        }

        var comparer = (IComparable)converter.ConvertFromString(this._minimumValue);
        if (comparer == null)
        {
            // The value of minimum is null when converted.
            return false;
        }

        return comparer.CompareTo(value) <= 0;
    }
}
