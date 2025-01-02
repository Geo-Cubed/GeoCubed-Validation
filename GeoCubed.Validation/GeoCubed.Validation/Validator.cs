namespace GeoCubed.Validation;

/// <summary>
/// Validation class for running the validation on an object.
/// </summary>
public sealed class Validator
{
    /// <summary>
    /// Validates an object.
    /// </summary>
    /// <param name="obj">The object to validate using the validation attributes.</param>
    /// <returns>The result of the validation.</returns>
    public static ValidationResult Validate(object obj)
    {
        // TODO: validate an object passed to it and return a object representing the result.
        var result = ValidationResult.Success;

        // 1. Loop through object.

        // 2. If property has validation attribute.

        // 3. Run validation.

        // 4. If there are errors then add the messages + property name to result.Errors.

        return result;
    }
}
