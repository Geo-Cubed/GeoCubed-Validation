using GeoCubed.Validation.Attributes;

namespace GeoCubed.Validation;

/// <summary>
/// Required validation attribute class. This will check if an object is not null (or empty in case of string).
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class NotNull : BaseValidationAttribute
{
    private const string _defaultErrorMessage = "The value was null.";

    /// <summary>
    /// Initializes a new instance of the <see cref="NotNull"/> class.
    /// </summary>
    public NotNull()
        : base(_defaultErrorMessage)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotNull"/> class.
    /// </summary>
    /// <param name="errorMessage">The error message for the validation.</param>
    public NotNull(string errorMessage)
        : base(errorMessage)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage);
    }

    /// <summary>
    /// Checks if the value is null or not.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>True if valid, False otherwise.</returns>
    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return false;
        }

        var convertedValue = value as string;
        if (convertedValue != null)
        {
            return !string.IsNullOrEmpty(convertedValue);
        }

        return true;
    }
}
