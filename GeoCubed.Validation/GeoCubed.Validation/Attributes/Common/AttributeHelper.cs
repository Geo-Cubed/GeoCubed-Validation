using System.ComponentModel;

namespace GeoCubed.Validation.Attributes.Common;

internal static class AttributeHelper
{
    internal static TypeConverter GetConverter(Type objectType)
    {
        var converter = TypeDescriptor.GetConverter(objectType); // TODO: See what's better to use this or Convert.ChangeType.
        if (converter == null)
        {
            // Cannot find the type converter.
            throw new Exception("No Converter");
        }

        return converter;
    }

    internal static IComparable GetComparer(TypeConverter converter, string value)
    {
        var comparer = (IComparable)converter.ConvertFromString(value);
        if (comparer == null)
        {
            // The value of minimum is null when converted.
            throw new Exception("No Comparer");
        }

        return comparer;
    }
}
