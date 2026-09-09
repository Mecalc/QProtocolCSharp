// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using QProtocol.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using QProtocol.Advanced;

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

        /// <summary>
        /// Caters for nested settings.
        /// </summary>
        public List<Setting> Settings { get; set; }

        public static List<Setting> ConvertFrom<T>(T derivedSettings)
        {
            var settings = new List<Setting>();
            foreach (var option in derivedSettings.GetType().GetProperties())
            {
                // Override the name if a user friendly version exists.
                var name = option.Name;
                if (Attribute.GetCustomAttribute(option, typeof(RestfulPropertiesAttribute)) is
                    RestfulPropertiesAttribute userFriendlyNameAttribute)
                {
                    name = userFriendlyNameAttribute.Description;
                }

                var value = option.GetValue(derivedSettings);
                if (value != null)
                {
                    var settingType = value.GetType();
                    if (IsComplexType(settingType))
                    {
                        var nestedSettings = ConvertFromComplexType(value, settingType);
                        settings.Add(new Setting()
                        {
                            Name = name,
                            Value = null,
                            Settings = nestedSettings,
                            Type = "array"
                        });
                    }
                    else
                    {
                        settings.Add(new Setting()
                        {
                            Name = name,
                            Value = settingType.IsEnum ? Convert.ToInt32(value) : value,
                            Type = GetSettingType(settingType)
                        });
                    }
                }
            }
            return settings;
        }


        private static bool IsComplexType(Type type)
        {
            // Check if it's a primitive type, string, enum, or nullable of these
            if (type.IsPrimitive || type == typeof(string) || type.IsEnum)
                return false;
    
            // Handle nullable types
            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
            {
                return IsComplexType(underlyingType);
            }
    
            // Handle collections (List<T>, arrays, etc.)
            if (typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string))
            {
                return true; // Collections are considered complex for nested handling
            }
    
            // Everything else is considered a complex type
            return true;
        }

        
        private static List<Setting> ConvertFromComplexType(object value, Type type)
        {
            // Handle collections (List<T>, arrays, etc.)
            if (typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string))
            {
                var collection = (IEnumerable)value;
                var collectionSettings = new List<Setting>();
        
                foreach (var item in collection)
                {
                    if (item != null)
                    {
                        var itemType = item.GetType();
                        if (IsComplexType(itemType))
                        {
                            // For array/list elements, we don't need a name at the item level
                            var itemSettings = ConvertFromComplexType(item, itemType);
                            collectionSettings.Add(new Setting()
                            {
                                Name = null, // Array elements don't have individual names
                                Value = null,
                                Settings = itemSettings,
                                Type = "object"
                            });
                        }
                        else
                        {
                            // Simple array element
                            collectionSettings.Add(new Setting()
                            {
                                Name = null,
                                Value = itemType.IsEnum ? Convert.ToInt32(item) : item,
                                Type = GetSettingType(itemType)
                            });
                        }
                    }
                }
        
                return collectionSettings;
            }
    
            // Handle regular nested objects by recursively calling ConvertFrom
            var method = typeof(Setting).GetMethod(nameof(ConvertFrom))?.MakeGenericMethod(type);
            if (method != null)
            {
                return (List<Setting>)method.Invoke(null, new[] { value });
            }
    
            return new List<Setting>();
        }

        private static string GetSettingType(Type type)
        {
            // Handle nullable types
            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
            {
                type = underlyingType;
            }
    
            if (type.IsEnum)
                return "enumeration";
    
            if (type == typeof(byte))
                return "byte";
            if (type == typeof(double))
                return "double";
            if (type == typeof(float))
                return "float";
            if (type == typeof(ushort))
                return "unsigned short";
            if (type == typeof(uint))
                return "unsigned integer";
            if (type == typeof(string))
                return "string";
            if (type == typeof(int))
                return "integer";
    
            // Handle arrays/collections
            if (typeof(IEnumerable).IsAssignableFrom(type) && type != typeof(string))
                return "array";
    
            return "object";
        }

        
        public static T ConvertTo<T>(List<Setting> settingList)
        {
            if (settingList == null)
                throw new ArgumentNullException(nameof(settingList));

            var derivedSettings = Activator.CreateInstance<T>();
            var targetType = typeof(T);
            var properties = targetType.GetProperties().ToList();

            foreach (var item in settingList)
            {
                if (item == null)
                {
                    throw new InvalidOperationException($"Setting at index {settingList.IndexOf(item)} is null.");
                }

                // Handle array items that don't have names (they're just nested objects)
                if (string.IsNullOrEmpty(item.Name) && item.Settings != null)
                {
                    // This is likely an array element without a name - skip individual processing
                    // The parent array handler should deal with this
                    continue;
                }

                if (string.IsNullOrEmpty(item.Name))
                {
                    throw new InvalidOperationException($"Setting at index {settingList.IndexOf(item)} has a null or empty Name property.");
                }

                var settingProperty = properties.FirstOrDefault(info => DoesNameMatch(info, item.Name));
                if (settingProperty == null)
                {
                    var availableProperties = properties
                        .Select(p => GetPropertyDisplayName(p))
                        .ToList();
            
                    throw new InvalidOperationException(
                        $"No matching property found for setting '{item.Name}' in type '{targetType.Name}'. " +
                        $"Available properties: [{string.Join(", ", availableProperties)}]");
                }

                try
                {
                    ProcessSettingValue(item, settingProperty, derivedSettings);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"Failed to set property '{settingProperty.Name}' with value '{item.Value}' " +
                        $"of type '{item.Type}' for setting '{item.Name}'.", ex);
                }
            }

            return derivedSettings;
        }

        private static void ProcessArraySetting(Setting item, PropertyInfo settingProperty, object derivedSettings)
        {
            try
            {
                var propertyType = settingProperty.PropertyType;
        
                // Handle List<T> types
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var elementType = propertyType.GetGenericArguments()[0];
                    var listInstance = Activator.CreateInstance(propertyType);
                    var addMethod = propertyType.GetMethod("Add");
            
                    if (item.Settings != null)
                    {
                        foreach (var nestedSetting in item.Settings)
                        {
                            object elementInstance;
                    
                            // Handle nested settings that don't have names (array elements)
                            if (string.IsNullOrEmpty(nestedSetting.Name) && nestedSetting.Settings != null)
                            {
                                // This is an array element - convert its nested settings
                                elementInstance = ConvertSettingsToType(nestedSetting.Settings, elementType);
                            }
                            else
                            {
                                // This is a regular named setting - convert it normally
                                elementInstance = ConvertSettingsToType(new List<Setting> { nestedSetting }, elementType);
                            }
                    
                            addMethod?.Invoke(listInstance, new[] { elementInstance });
                        }
                    }
            
                    settingProperty.SetValue(derivedSettings, listInstance);
                    return;
                }
        
                // Handle single nested object
                var method = typeof(Setting).GetMethod(nameof(ConvertTo))
                    ?.MakeGenericMethod(propertyType);
        
                if (method == null)
                {
                    throw new InvalidOperationException($"Could not find ConvertTo method for nested type '{propertyType.Name}'.");
                }

                var nestedObject = method.Invoke(null, new object[] { item.Settings });
                settingProperty.SetValue(derivedSettings, nestedObject);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Failed to process array setting '{item.Name}' of type '{settingProperty.PropertyType.Name}'", ex);
            }
        }

        private static object ConvertSettingsToType(List<Setting> settings, Type targetType)
        {
            var method = typeof(Setting).GetMethod(nameof(ConvertTo))
                ?.MakeGenericMethod(targetType);
    
            if (method == null)
            {
                throw new InvalidOperationException($"Could not find ConvertTo method for type '{targetType.Name}'.");
            }

            return method.Invoke(null, new object[] { settings });
        }

        private static void ProcessSettingValue(Setting item, PropertyInfo settingProperty, object derivedSettings)
        {
            // An explicit cast is required for non int32 types.
            var value = item.Value;
    
            switch (item.Type?.ToLowerInvariant())
            {
                case "byte":
                    value = Convert.ToByte(value);
                    break;
                case "double":
                    value = Convert.ToDouble(value);
                    break;
                case "float":
                    value = Convert.ToSingle(value);
                    break;
                case "unsigned short":
                    value = Convert.ToUInt16(value);
                    break;
                case "unsigned integer":
                    value = Convert.ToUInt32(value);
                    break;
                case "unsigned integer []":
                    var genericList = ((IEnumerable)value).Cast<object>().ToList();
                    value = genericList.Select(val => Convert.ToUInt32(val)).ToList();
                    break;
                case "string":
                    value = Convert.ToString(value);
                    break;
                case "array":
                    ProcessArraySetting(item, settingProperty, derivedSettings);
                    return;
                case "enumeration":
                    // Handle enumeration types - use the Value directly (should be an integer)
                    value = Convert.ToInt32(value);
                    break;
                case null:
                    throw new InvalidOperationException($"Setting '{item.Name}' has a null Type property.");
                default:
                    value = Convert.ToInt32(value);
                    break;
            }

            SetPropertyValue(settingProperty, derivedSettings, value);
        }

        private static void SetPropertyValue(PropertyInfo settingProperty, object derivedSettings, object value)
        {
            // Settings with Nullable Properties needs a little TLC.
            var underlyingType = Nullable.GetUnderlyingType(settingProperty.PropertyType);
            if (underlyingType != null)
            {
                if (underlyingType.IsEnum)
                {
                    var enumValue = Enum.ToObject(underlyingType, value);
                    settingProperty.SetValue(derivedSettings, enumValue);
                }
                else
                {
                    settingProperty.SetValue(derivedSettings, value);
                }
                return;
            }
    
            // Handle enum properties
            if (settingProperty.PropertyType.IsEnum)
            {
                var enumValue = Enum.ToObject(settingProperty.PropertyType, value);
                settingProperty.SetValue(derivedSettings, enumValue);
                return;
            }
    
            settingProperty.SetValue(derivedSettings, value);
        }

        private static string GetPropertyDisplayName(PropertyInfo propertyInfo)
        {
            if (Attribute.GetCustomAttribute(propertyInfo, typeof(RestfulPropertiesAttribute)) is RestfulPropertiesAttribute attribute)
            {
                return $"{propertyInfo.Name} ('{attribute.Description}')";
            }
            return propertyInfo.Name;
        }

        private static bool DoesNameMatch(PropertyInfo info, string name)
        {
            if (Attribute.GetCustomAttribute(info, typeof(RestfulPropertiesAttribute)) is RestfulPropertiesAttribute
                userFriendlyNameAttribute)
            {
                return userFriendlyNameAttribute.Description.Equals(name, StringComparison.InvariantCultureIgnoreCase);
            }

            return false;
        }
    }
}