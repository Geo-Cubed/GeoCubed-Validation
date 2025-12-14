using System.Collections;

namespace GeoCubed.Validation.Attributes;

/// <summary>
/// Maximum length attribute for checking if a string or list / array is at maximum in length this value.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MaximumLength : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "The length was greater than the maximum value.";

    private readonly int _maximumLength;

    /// <summary>
    /// Initializes a new instance of <see cref="MaximumLength"/> class.
    /// </summary>
    /// <param name="maximumLength">The maximum length.</param>
    public MaximumLength(int maximumLength)
        : base(_defaultErrorMessage)
    {
        ArgumentNullException.ThrowIfNull(maximumLength);

        this._maximumLength = maximumLength;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaximumLength"/> class.
    /// </summary>
    /// <param name="maximumLength">The maximum length.</param>
    /// <param name="errorMessage">The error message to use on validation fail.</param>
    public MaximumLength(int maximumLength, string errorMessage)
        : base(errorMessage)
    {
        ArgumentNullException.ThrowIfNull(maximumLength);
        ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);

        this._maximumLength = maximumLength;
    }

    /// <summary>
    /// Checks if the value is less than or equal to the maximum length in length.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True if valid, False otherwise.</returns>
    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return true;
        }

        int length = int.MinValue;
        if (value is string)
        {
            var parsed = value as string;
            length = parsed == null ? 0 : parsed.Length;
        }
        else
        {
            length = (value as IEnumerable).Cast<object>().Count();
        }

        return length <= this._maximumLength;
    }
}
