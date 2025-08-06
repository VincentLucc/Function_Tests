using _CommonCode_Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Copy
{
    public class csInstanceCopyLog
    {
        /// <summary>
        /// Field or property name
        /// </summary>
        public string PropertyName { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public string Message { get; set; }

        public csInstanceCopyLog(string sPropertyName)
        {
            PropertyName = sPropertyName;
        }

        public csInstanceCopyLog(string sPropertyName, string sMessage)
        {
            PropertyName = sPropertyName;
            Message = sMessage;
        }

        public csInstanceCopyLog(string sPropertyName, object oPreviousValue, object oNewValue)
        {
            PropertyName = sPropertyName;
            PreviousValue = oPreviousValue.GetValidString();
            NewValue = oNewValue.GetValidString();
        }
    }

    public static class csInstanceCopyExtension
    {
        /// <summary>
        /// [PropertyType.IsClass] may contains string, datetype, List<T>...
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool IsUserDefinedClass(this Type type)
        {
            //Must be class
            if (!type.IsClass) return false;

            //Handle special type
            if (type == typeof(string)) return false;

            //Remove system items
            if (type.Namespace != null && type.Namespace.StartsWith("System")) return false;

            return true;
        }

        public static void LogValueChange(this List<csInstanceCopyLog> propertyChanges, FieldInfo fieldInfo, object oldValue, object newValue)
        {
            string sFieldName = $"{fieldInfo.ReflectedType.FullName}.{fieldInfo.Name}";
            propertyChanges.LogValueChange(sFieldName, oldValue, newValue);
        }

        public static void LogValueChange(this List<csInstanceCopyLog> propertyChanges, PropertyInfo propertyInfo, object oldValue, object newValue)
        {
            string sFieldName = $"{propertyInfo.ReflectedType.FullName}.{propertyInfo.Name}";
            propertyChanges.LogValueChange(sFieldName, oldValue, newValue);
        }
        private static void LogValueChange(this List<csInstanceCopyLog> PropertyChanges, string sFieldname, object oldValue, object newValue)
        {
            //ignore identical value
            if (oldValue == newValue) return;

            //Handle null
            if (oldValue == null && newValue != null)
            {
                $"LogValueChange:[{sFieldname}],[Old:Empty],[new:{newValue}]]".TraceRecord();
                PropertyChanges.Add(new csInstanceCopyLog(sFieldname, oldValue, newValue));
                return;
            }
            if (oldValue != null && newValue == null)
            {
                $"LogValueChange:[{sFieldname}],[Old:{newValue}],[new:Empty]".TraceRecord();
                PropertyChanges.Add(new csInstanceCopyLog(sFieldname, oldValue, newValue));
                return;
            }

            //Treat as object
            if (oldValue.Equals(newValue)) return;

            if (PropertyChanges.Count > 5000) return;
            $"LogValueChange:[{sFieldname}],[Old:{oldValue}],[new:{newValue}]".TraceRecord();
            PropertyChanges.Add(new csInstanceCopyLog(sFieldname, oldValue, newValue));
        }

        public static void LogError(this List<csInstanceCopyLog> propertyChanges, PropertyInfo propertyInfo, string sError)
        {
            string sFieldName = $"{propertyInfo.ReflectedType.FullName}.{propertyInfo.Name}";
            propertyChanges.LogError(sFieldName, sError);
        }

        public static void LogError(this List<csInstanceCopyLog> PropertyChanges, FieldInfo fieldInfo, string sError)
        {
            string sFieldName = $"{fieldInfo.ReflectedType.FullName}.{fieldInfo.Name}";
            PropertyChanges.LogError(sFieldName, sError);
        }
        private static void LogError(this List<csInstanceCopyLog> PropertyChanges, string sFieldname, string sError)
        {
            $"LogValueChange:[{sFieldname}],[Msg:{sError}]".TraceRecord();
            PropertyChanges.Add(new csInstanceCopyLog(sFieldname, sError));
        }


    }
}
