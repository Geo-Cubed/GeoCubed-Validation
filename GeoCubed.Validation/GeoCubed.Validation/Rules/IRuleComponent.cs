using GeoCubed.Validation.Custom;

namespace GeoCubed.Validation.Rules;

public interface IRuleComponent<TModel, TProperty> where TModel : class
{
    void IsValid(TProperty value, ValidationContext<TModel> context);

    void SetErrorMessage(string message);
}
