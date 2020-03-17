using System;
using System.ComponentModel.DataAnnotations;

namespace POC.Web.Common.Validation.Extensions
{
    public static class ValidationContextExtensions
    {
        public static PropertyContextResolution<TValue> GetProperty<TValue>(
            this ValidationContext context,
            string name,
            Func<object, TValue> converter = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return PropertyContextResolution<TValue>.Error("Password field is empty");
            }

            var propertyInfo = context.ObjectType.GetProperty(name);

            if (propertyInfo == null)
            {
                return PropertyContextResolution<TValue>.Error($"Property with name: {name} is not present in model");
            }

            var propertyObject = propertyInfo.GetValue(context.ObjectInstance, null);

            var propertyValue = converter == null
                ? (TValue)propertyObject
                : converter(propertyObject);

            return PropertyContextResolution<TValue>.Success(propertyValue);
        }
    }

    public class PropertyContextResolution<TValue>
    {
        public string ErrorMessage { get; set; }

        public TValue Value { get; set; }

        public bool IsValid => string.IsNullOrEmpty(ErrorMessage);

        public static PropertyContextResolution<TValue> Error(string errorMessage)
        {
            return new PropertyContextResolution<TValue> { ErrorMessage = errorMessage };
        }

        public static PropertyContextResolution<TValue> Success(TValue value)
        {
            return new PropertyContextResolution<TValue> { Value = value };
        }
    }
}
