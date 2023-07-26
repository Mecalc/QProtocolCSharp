// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;
using System.Reflection;

namespace QProtocol.Attributes
{
    [Serializable]
    public static class AttributeExtensions
    {
        /// <summary>
        /// This method can be used to fetch the <see cref="RestfulPropertiesAttribute"/> from various Enum.
        /// </summary>
        /// <typeparam name="T">Type of the field.</typeparam>
        /// <param name="option">Instance of the field of an Enum.</param>
        /// <returns>The <see cref="RestfulPropertiesAttribute"/> of the provided field.</returns>
        /// <exception cref="NotSupportedException">If no <see cref="RestfulPropertiesAttribute"/> has been specified.</exception>
        public static RestfulPropertiesAttribute GetRestfulPropertiesAttribute<T>(this T instance)
            where T : Enum
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            var attribute = instance.GetType()
                                    .GetField(instance.ToString())?
                                    .GetCustomAttribute<RestfulPropertiesAttribute>();

            if (attribute != null)
            {
                return attribute;
            }

            throw new NotSupportedException("The object provided did not contain the necessary attribute for this method to work.");
        }

        /// <summary>
        /// This method can be used to fetch the <see cref="RestfulPropertiesAttribute"/> from a setting property.
        /// </summary>
        /// <param name="propertyInfo">The property info instance of a setting property.</param>
        /// <returns>The <see cref="RestfulPropertiesAttribute"/> of the provided field.</returns>
        /// <exception cref="NotSupportedException">If no <see cref="RestfulPropertiesAttribute"/> has been specified.</exception>
        public static RestfulPropertiesAttribute GetRestfulPropertiesAttribute(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException(nameof(propertyInfo));
            }
            
            if (Attribute.GetCustomAttribute(propertyInfo, typeof(RestfulPropertiesAttribute)) is RestfulPropertiesAttribute userFriendlyNameAttribute)
            {
                return userFriendlyNameAttribute;
            }

            throw new NotSupportedException("The object provided did not contain the necessary attribute for this method to work.");
        }
    }
}
