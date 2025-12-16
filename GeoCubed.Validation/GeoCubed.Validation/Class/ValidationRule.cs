using GeoCubed.Validation.Rules;
using System.Linq.Expressions;
using System.Reflection;

namespace GeoCubed.Validation.Custom;

/*
 * Rules:
 * Equal *
 * Greater than *
 * Less than *
 * string contains *
 * In the list
 * Length Greater than
 * length less than
 * length equal to
 * Not null
 * Not empty or whitespace
 * Is Null
 * In Range
 * 
 * Custom function
 */


public class ValidationRule<TModel, TProperty> : IValidationRule<TModel> where TModel : class
{
    private readonly MemberInfo _member; // A rule needs a member to pass onto the various validation rules.
    private readonly List<IRuleComponent<TModel, TProperty>> _components;

    public string MemberName { get => this._member.Name; }

    public ValidationRule(Expression<Func<TModel, TProperty>> expression) 
    {
        this._member = expression.GetMember();
        this._components = new List<IRuleComponent<TModel, TProperty>>();
    }

    public void AddComponent(IRuleComponent<TModel, TProperty> component)
    {
        this._components.Add(component);
    }

    public void Validate(ValidationContext<TModel> validationContext)
    {
        var value = this.GetValueFromMember(validationContext.Instance);

        var rules = this._components.Count();
        for (int i = 0; i < rules; ++i)
        {
            this._components[i].IsValid(value, validationContext);
        }
    }

    private TProperty GetValueFromMember(TModel instance)
    {
        switch (this._member.MemberType)
        {
            case MemberTypes.Field:
                return (TProperty)((FieldInfo)this._member).GetValue(instance);
            case MemberTypes.Property:
                return (TProperty)((PropertyInfo)this._member).GetValue(instance);
            default:
                throw new NotImplementedException();
        }
    }
}
