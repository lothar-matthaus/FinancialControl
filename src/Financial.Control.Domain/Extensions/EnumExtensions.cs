using System.ComponentModel;
using System.Reflection;

namespace Financial.Control.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum @enum)
        {
            FieldInfo field = @enum.GetType().GetField(@enum.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? @enum.ToString() : attribute.Description;
        }
    }
}
