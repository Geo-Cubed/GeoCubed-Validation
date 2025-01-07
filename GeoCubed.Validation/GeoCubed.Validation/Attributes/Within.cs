using GeoCubed.Validation.Attributes.Common;
using System.ComponentModel;

namespace GeoCubed.Validation.Attributes;

/// <summary>
/// Validation attribute for checking if a value is within the bounds specified.
/// </summary>
public class Within : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "The value was not within the range provided.";

    private readonly string _minimumValue;
    private readonly string _maximumValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="Within"/> class.
    /// </summary>
    /// <param name="minimumValue">The minimum value expressed as a string.</param>
    /// <param name="maximumValue">The maximum value expressed as a string.</param>
    public Within(string minimumValue, string maximumValue)
        : base(_defaultErrorMessage)
    {
        this._minimumValue = minimumValue;
        this._maximumValue = maximumValue;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Within"/> class.
    /// </summary>
    /// <param name="minimumValue">The minimum value expressed as a string.</param>
    /// <param name="maximumValue">The maximum value expressed as a string.</param>
    /// <param name="errorMessage">The error message to use on fail.</param>
    public Within(string minimumValue, string maximumValue, string errorMessage)
        : base(errorMessage)
    {
        this._minimumValue = minimumValue;
        this._maximumValue = maximumValue;
    }

    /// <summary>
    /// Check if the value is between the min and max values (inclusive).
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True if valid, False otherwise.</returns>
    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return true;
        }

        var objType = value.GetType();

        // Fetch the converter for the object type.
        TypeConverter converter;
        try
        {
            converter = AttributeHelper.GetConverter(objType);
        }
        catch
        {
            return false;
        }

        // Get the comparer for the minimum value.
        IComparable minComparer;
        try
        {
            minComparer = AttributeHelper.GetComparer(converter, this._minimumValue);
        }
        catch
        {
            return false;
        }

        // Get the comparer for the maximum value.
        IComparable maxComparer;
        try
        {
            maxComparer = AttributeHelper.GetComparer(converter, this._maximumValue);
        }
        catch
        {
            return false;
        }

        // Compare to check the value is between min and max.
        return minComparer.CompareTo(value) <= 0 && maxComparer.CompareTo(value) >= 0;
    }
}
