// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QProtocol.JsonProperties
{
    /// <summary>
    /// A class defining what a QProtocol Setting consists of.
    /// </summary>
    [Serializable]
    public class Setting
    {
        /// <summary>
        /// Gets or sets the setting name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of setting.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a list of supported values for this setting.
        /// </summary>
        public List<SupportedValue> SupportedValues { get; set; }

        /// <summary>
        /// Gets or sets a list of validation values where the <see cref="Value"/> must reside in.
        /// </summary>
        public ValidationLimits ValidationLimits { get; set; }

        /// <summary>
        /// Gets or sets the actual setting value.
        /// </summary>
        public object Value { get; set; }

        public static List<Setting> ConvertFrom<T>(T derivedSettings)
        {
            var settings = new List<Setting>();
            foreach (var option in derivedSettings.GetType().GetProperties())
            {
                // Override the name if a user friendly version exists.
                var name = option.Name;
                if (Attribute.GetCustomAttribute(option, typeof(RestfulPropertiesAttribute)) is RestfulPropertiesAttribute userFriendlyNameAttribute)
                {
                    name = userFriendlyNameAttribute.Description;
                }

                var value = option.GetValue(derivedSettings);
                if (value != null)
                {
                    settings.Add(new Setting() { Name = name, Value = value.GetType().IsEnum ? Convert.ToInt32(value) : value });
                }
            }

            return settings;
        }

        public static T ConvertTo<T>(List<Setting> settingList)
        {
            var derivedSettings = Activator.CreateInstance<T>();
            foreach (var item in settingList)
            {
                var settingProperty = derivedSettings.GetType()
                                                     .GetProperties()
                                                     .First(info => DoesNameMatch(info, item.Name));

                // An explicit cast is required for non int32 types.
                var value = item.Value;
                switch (item.Type)
                {
                    case "Byte":
                        value = Convert.ToByte(value);
                        break;

                    case "Double":
                        value = Convert.ToDouble(value);
                        break;

                    case "Float":
                        value = Convert.ToSingle(value);
                        break;

                    case "Unsigned Integer":
                        value = Convert.ToUInt32(value);
                        break;

                    case "Unsigned Integer []":
                        var genericList = ((IEnumerable)value).Cast<object>().ToList();
                        value = genericList.Select(val => Convert.ToUInt32(val))
                                           .ToList();
                        break;

                    case "String":
                        value = Convert.ToString(value);
                        break;

                    case "Enumeration":
                    default:
                        value = Convert.ToInt32(value);
                        break;
                }

                // Settings with Nullable Properties needs a little TLC.
                var underlyingType = Nullable.GetUnderlyingType(settingProperty.PropertyType);
                if (underlyingType != null)
                {
                    var safeValue = Enum.ToObject(underlyingType, value);
                    settingProperty.SetValue(derivedSettings, safeValue, null);
                    continue;
                }

                settingProperty.SetValue(derivedSettings, value, null);
            }

            return derivedSettings;
        }

        private static bool DoesNameMatch(PropertyInfo info, string name)
        {
            if (Attribute.GetCustomAttribute(info, typeof(RestfulPropertiesAttribute)) is RestfulPropertiesAttribute userFriendlyNameAttribute)
            {
                return userFriendlyNameAttribute.Description.Equals(name);
            }

            return false;
        }
    }
}
