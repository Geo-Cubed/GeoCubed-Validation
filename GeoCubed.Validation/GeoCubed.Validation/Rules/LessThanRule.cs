using GeoCubed.Validation.Attributes.Common;
using GeoCubed.Validation.Custom;
using System.ComponentModel;

namespace GeoCubed.Validation.Rules;

public class LessThanRule<TModel, TProperty> : BaseRuleComponent<TProperty>, IRuleComponent<TModel, TProperty> where TModel : class
{
    private const string DEFAULT_ERROR = "{PROPERTY} is not less than {VALUE}";
    private readonly string _maximumValue;

    public LessThanRule(string maximumValue, string propertyName) : base(maximumValue, DEFAULT_ERROR)
    {
        this._maximumValue = maximumValue;
    }

    public void IsValid(TProperty value, ValidationContext<TModel> context)
    {
        if (!this.CheckGreaterThan(value))
        {
            context.AddFailiure(this.PropertyName, this.ConstructErrorMessage(value));
        }
    }

    private bool CheckGreaterThan(TProperty value)
    {
        if (value == null)
        {
            return true;
        }

        var objType = value.GetType();

        // Fetch the converter for the object type.
        TypeConverter converter;
        try
        {
            converter = AttributeHelper.GetConverter(objType);
        }
        catch
        {
            return false;
        }

        // Fetch the comparer for the object type.
        IComparable comparer;
        try
        {
            comparer = AttributeHelper.GetComparer(converter, this._maximumValue);
        }
        catch
        {
            return false;
        }

        return comparer.CompareTo(value) >= 0;
    }
}
