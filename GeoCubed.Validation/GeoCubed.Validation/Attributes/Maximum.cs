using GeoCubed.Validation.Attributes.Common;
using System.ComponentModel;

namespace GeoCubed.Validation.Attributes;

/// <summary>
/// Attribute for defining the maximum value a property can be.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class Maximum : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "The value was more than the maximum value.";

    private readonly string _maximumValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="Maximum"/> class.
    /// </summary>
    /// <param name="maximumValue">The maximum value expressed as a string.</param>
    public Maximum(string maximumValue) : base(_defaultErrorMessage)
    {
         this._maximumValue = maximumValue;
    }

    /// <summary>
    /// Initializes a new instanc of the <see cref="Maximum"/> class.
    /// </summary>
    /// <param name="maximumValue">The maximum value expressed as a string.</param>
    /// <param name="errorMessage">The error message to use on fail.</param>
    public Maximum(string maximumValue, string errorMessage)
        : base(errorMessage)
    {
        this._maximumValue = maximumValue;
    }

    /// <summary>
    /// Checks if the value is at maximum the maximum value.
    /// </summary>
    /// <param name="value">The value of the property.</param>
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

        // Fetch the comparer for the object type.
        IComparable comparer;
        try
        {
            comparer = AttributeHelper.GetComparer(converter, this._maximumValue);
        }
        catch
        {
            return false;
        }

        return comparer.CompareTo(value) >= 0;
    }
}
