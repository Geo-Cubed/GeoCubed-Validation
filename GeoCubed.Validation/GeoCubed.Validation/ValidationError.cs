namespace GeoCubed.Validation;

/// <summary>
/// Model denotin a validation error.
/// </summary>
public sealed class ValidationError
{
    /// <summary>
    /// Gets or sets the property name.
    /// </summary>
    public string Property { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the error code.
    /// </summary>
    public string Code { get; set; }
}
