namespace GeoCubed.Validation;

/// <summary>
/// Model for storing the result of a validation check.
/// </summary>
public sealed class ValidationResult
{
    /// <summary>
    /// Gets or sets if the validation has errors.
    /// </summary>
    public bool HasErrors { get; set; }

    /// <summary>
    /// Gets or sets the Errors in the validation.
    /// </summary>
    public List<(string property, string errorMessage)> Errors { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// </summary>
    public ValidationResult()
    {
        this.HasErrors = false;
        this.Errors = new ();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationResult"/> class.
    /// </summary>
    /// <param name="hasErrors">If the model has errors.</param>
    public ValidationResult(bool hasErrors)
    {
        this.HasErrors = hasErrors;
        this.Errors = new ();
    }

    /// <summary>
    /// Get a successful validation result.
    /// </summary>
    public static ValidationResult Success => new ValidationResult(hasErrors: false); 
}
