using GeoCubed.Validation.Attributes;
using GeoCubed.Validation.Custom;
using System.Reflection;

namespace GeoCubed.Validation;

/// <summary>
/// Validation class for running the validation on an object.
/// </summary>
public static class AttributeValidator
{
    /// <summary>
    /// Validates an object.
    /// </summary>
    /// <param name="obj">The object to validate using the validation attributes.</param>
    /// <returns>The result of the validation.</returns>
    public static ValidationResult Validate<T>(T obj) where T : class
    {
        var validationContext = new ValidationContext<T>(obj);

        // Get the properties of the object.
        var properties = obj.GetType().GetProperties().AsSpan();
        for (var i = 0; i < properties.Length; ++i)
        {
            ValidateProperty(properties[i], validationContext);
        }

        // TODO: Validate fields?
        return validationContext.ToValidationResult();
    }

    private static void ValidateProperty<T>(PropertyInfo property, ValidationContext<T> validationContext) where T : class
    {
        // Get the validation attributes from the property.
        var validationAttributes = property.GetCustomAttributes(typeof(BaseValidationAttribute), true);
        if (validationAttributes != null && validationAttributes.Length > 0)
        {
            var value = property.GetValue(validationContext.Instance);

            // Loop through the validation attributes on the property.
            for (int j = 0; j < validationAttributes.Length; ++j)
            {
                var attribute = validationAttributes[j] as BaseValidationAttribute;
                if (attribute != null)
                {
                    RunValidation(attribute, property, value, validationContext);
                }
            }
        }
    }

    private static void RunValidation<T>(BaseValidationAttribute attribute, PropertyInfo property, object? value, ValidationContext<T> validationContext) where T : class
    {
        // Run the validation.
        var result = attribute?.IsValid(value);
        if (result == false && attribute != null)
        {
            // On validation error set the errors flag and add error message.
            validationContext.AddFailiure(property.Name, attribute.ConstructErrorMessage(property.Name));
        }
    }
}
