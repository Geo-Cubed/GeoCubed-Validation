namespace GeoCubed.Validation.Attributes;

/// <summary>
/// Validate that the length of a value is within a range.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class WithinLength : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "";

    private readonly int _minimumLength;
    private readonly int _maximumLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="WithinLength"/> class.
    /// </summary>
    /// <param name="minimumLength">The minimum length.</param>
    /// <param name="maximumLength">The maximum length.</param>
    public WithinLength(int minimumLength, int maximumLength)
        : base(_defaultErrorMessage)
    {
        ArgumentNullException.ThrowIfNull(minimumLength);
        ArgumentNullException.ThrowIfNull(maximumLength);

        this._minimumLength = minimumLength;
        this._maximumLength = maximumLength;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WithinLength"/> class.
    /// </summary>
    /// <param name="minimumLength">The minimum length.</param>
    /// <param name="maximumLength">The maximum length.</param>
    /// <param name="errorMessage">The error message to use.</param>
    public WithinLength(int minimumLength, int maximumLength, string errorMessage)
        : base(errorMessage)
    {
        ArgumentNullException.ThrowIfNull(minimumLength);
        ArgumentNullException.ThrowIfNull(maximumLength);
        ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);

        this._minimumLength = minimumLength;
        this._maximumLength = maximumLength;
    }

    /// <summary>
    /// Check if the length of a value is within a range.
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
            length = ((Array)value).Length;
        }

        return length >= this._minimumLength && length <= this._maximumLength;
    }
}
