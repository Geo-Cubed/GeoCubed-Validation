namespace GeoCubed.Validation.Attributes;

/// <summary>
/// Validation attribute for checking the minimum length of an object.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MinimumLength : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "";

    private readonly int _minimumLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="MinimumLength"/> class.
    /// </summary>
    /// <param name="minimumLength">The minimum length.</param>
    public MinimumLength(int minimumLength)
        : base(_defaultErrorMessage)
    {
        ArgumentNullException.ThrowIfNull(minimumLength);

        this._minimumLength = minimumLength;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MinimumLength"/> class.
    /// </summary>
    /// <param name="minimumLength">The minimum length.</param>
    /// <param name="errorMessage">The error message to use on fail.</param>
    public MinimumLength(int minimumLength, string errorMessage)
        : base(errorMessage)
    {
        ArgumentNullException.ThrowIfNull(minimumLength);
        ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);

        this._minimumLength = minimumLength;
    }

    /// <summary>
    /// Checks if the value is of or greater than the minimum length.
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

        return length >= this._minimumLength;
    }
}
