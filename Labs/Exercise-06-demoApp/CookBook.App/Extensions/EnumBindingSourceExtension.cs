using System;
using System.Windows.Markup;

namespace CookBook.App.Extensions
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        private Type enumType;

        public EnumBindingSourceExtension()
        {
        }

        public EnumBindingSourceExtension(Type enumType) => EnumType = enumType;

        public Type EnumType
        {
            get => enumType;
            set
            {
                if (value == enumType)
                {
                    return;
                }

                if (null != value)
                {
                    var enumType = Nullable.GetUnderlyingType(value) ?? value;
                    if (!enumType.IsEnum)
                    {
                        throw new ArgumentException("Type must be for an Enum.");
                    }
                }

                enumType = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (null == enumType)
            {
                throw new InvalidOperationException("The EnumType must be specified.");
            }

            var actualEnumType = Nullable.GetUnderlyingType(enumType) ?? enumType;
            var enumValues = Enum.GetValues(actualEnumType);

            if (actualEnumType == enumType)
            {
                return enumValues;
            }

            var tempArray = Array.CreateInstance(actualEnumType, enumValues.Length + 1);
            enumValues.CopyTo(tempArray, 1);
            return tempArray;
        }
    }
}