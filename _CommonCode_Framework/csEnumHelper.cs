using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _CommonCode_Framework
{
    public static class csEnumHelper<EnumType>
        where EnumType : struct, Enum // This constraint requires C# 7.3 or later.
    {
        public static IList<EnumType> GetValues(Enum value)
        {
            var enumValues = new List<EnumType>();

            foreach (FieldInfo fi in value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumValues.Add((EnumType)Enum.Parse(value.GetType(), fi.Name, false));
            }
            return enumValues;
        }

        public static EnumType Parse(string value)
        {
            return (EnumType)Enum.Parse(typeof(EnumType), value, true);
        }

        public static IList<string> GetNames(Enum value)
        {
            return value.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(fi => fi.Name).ToList();
        }

        public static IList<string> GetDisplayValues(Enum value)
        {
            return GetNames(value).Select(obj => GetDisplayValue(Parse(obj))).ToList();
        }

        private static string lookupResource(Type resourceManagerProvider, string resourceKey)
        {
            var resourceKeyProperty = resourceManagerProvider.GetProperty(resourceKey,
    BindingFlags.Static | BindingFlags.Public, null,
                                                                          typeof(string),
    new Type[0], null);
            if (resourceKeyProperty != null)
            {
                return (string)resourceKeyProperty.GetMethod.Invoke(null, null);
            }

            return resourceKey; // Fallback with the key name
        }

        public static string GetDisplayValue(EnumType value)
        {
            try
            {
                var fieldInfo = value.GetType().GetField(value.ToString());

                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DisplayAttribute), false) as DisplayAttribute[];

                if (descriptionAttributes[0].ResourceType != null)
                    return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

                if (descriptionAttributes == null) return string.Empty;
                return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EnumHelper.GetDisplayValue:\r\n" + ex.Message);
                return string.Empty;
            }
        }

        public static string GetDescription(EnumType value)
        {
            try
            {
                var fieldInfo = value.GetType().GetField(value.ToString());

                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DescriptionAttribute), false) as DescriptionAttribute[];

                if (descriptionAttributes == null) return string.Empty;
                return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Description : value.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EnumHelper.GetDescription:\r\n" + ex.Message);
                return string.Empty;
            }
        }

        public static List<string> GetDescriptions()
        {
            var descriptions = new List<string>();

            try
            {
                var allFields = typeof(EnumType).GetFields();

                foreach (var field in allFields)
                {//Ignore special field
                    if (field.IsSpecialName) continue;
                    var description = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
                    if (description == null) continue;
                    descriptions.Add(description.Description);
                }

                return descriptions;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("EnumHelper.GetDescriptions:\r\n" + ex.Message);
                return null;
            }
        }

        public static Dictionary<EnumType, string> GetDescriptionsDictionary()
        {
            var descriptions = new Dictionary<EnumType, string>();

            try
            {
                foreach (FieldInfo field in typeof(EnumType).GetFields(BindingFlags.Static | BindingFlags.Public))
                {
                    var key = (EnumType)Enum.Parse(typeof(EnumType), field.Name, false);
                    var desc = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
                    if (desc == null) continue;
                    descriptions.Add(key, desc.Description);
                }

                return descriptions;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EnumHelper.GetDescriptionsDictionary:\r\n" + ex.Message);
                return null;
            }
        }

        public static object GetDefaultValue(EnumType value)
        {
            try
            {
                var fieldInfo = value.GetType().GetField(value.ToString());

                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(DefaultValueAttribute), false) as DefaultValueAttribute[];

                if (descriptionAttributes == null) return null;
                return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Value : null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EnumHelper.GetDefaultValue:\r\n" + ex.Message);
                return null;
            }
        }
    }
}
