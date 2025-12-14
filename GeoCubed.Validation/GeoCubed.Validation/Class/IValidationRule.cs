namespace GeoCubed.Validation.Custom;

internal interface IValidationRule<TModel> where TModel : class
{
    void Validate(ValidationContext<TModel> context);
}
