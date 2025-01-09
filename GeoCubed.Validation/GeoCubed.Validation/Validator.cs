using GeoCubed.Validation.Attributes;
using System.Reflection;

namespace GeoCubed.Validation;

/// <summary>
/// Validation class for running the validation on an object.
/// </summary>
public static class Validator
{
    /// <summary>
    /// Validates an object.
    /// </summary>
    /// <param name="obj">The object to validate using the validation attributes.</param>
    /// <returns>The result of the validation.</returns>
    public static ValidationResult Validate(object obj)
    {
        var validationResult = ValidationResult.Success;

        // Get the properties of the object.
        var properties = obj.GetType().GetProperties().AsSpan();
        for (var i = 0; i < properties.Length; ++i)
        {
            ValidateProperty(properties[i], obj, validationResult);
        }

        // TODO: Validate fields?

        return validationResult;
    }

    private static void ValidateProperty(PropertyInfo property, object obj, ValidationResult validationResult)
    {
        // Get the validation attributes from the property.
        var validationAttributes = property.GetCustomAttributes(typeof(BaseValidationAttribute), true);
        if (validationAttributes != null && validationAttributes.Length > 0)
        {
            var value = property.GetValue(obj);

            // Loop through the validation attributes on the property.
            for (int j = 0; j < validationAttributes.Length; ++j)
            {
                var attribute = validationAttributes[j] as BaseValidationAttribute;
                if (attribute != null)
                {
                    RunValidation(attribute, property, obj, value, validationResult);
                }
            }
        }
    }

    private static void RunValidation(BaseValidationAttribute attribute, PropertyInfo property, object obj, object? value, ValidationResult validationResult)
    {
        // Run the validation.
        var result = attribute?.IsValid(value);
        if (result == false && attribute != null)
        {
            // On validation error set the errors flag and add error message.
            validationResult.HasErrors |= true;
            validationResult.Errors.Add((property.Name, attribute.ConstructErrorMessage(property.Name)));
        }
    }
}
