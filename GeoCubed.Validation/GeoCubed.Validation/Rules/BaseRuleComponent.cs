namespace GeoCubed.Validation.Rules;

public class BaseRuleComponent<TProperty>
{
    protected string PropertyName;
    protected string ErrorMessage;

    public BaseRuleComponent(string propertyName, string errorMessage)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }

    public void SetErrorMessage(string message)
    {
        ErrorMessage = message;
    }

    protected virtual string ConstructErrorMessage(TProperty propertyValue)
    {
        // TODO: Do this better.
        return ErrorMessage.Replace("{PROPERTY}", PropertyName).Replace("{VALUE}", propertyValue.ToString());
    }
}
