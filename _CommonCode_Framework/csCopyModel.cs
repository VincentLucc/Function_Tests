using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CommonCode_Framework
{

    public class csInstanceCopingData
    {
        public _instanceCopyMode CopyMode = _instanceCopyMode.None;

        /// <summary>
        /// Allow to ignore data type diffrence to copy possible valid values
        /// </summary>
        public bool HandleTypeDifference = true;

        public List<csInstanceCopyLog> PropertyChanges = new List<csInstanceCopyLog>();

        public void LogValueChange(FieldInfo fieldInfo, object oldValue, object newValue)
        {
            string sFieldName = $"{fieldInfo.ReflectedType.FullName}.{fieldInfo.Name}";
            LogValueChange(sFieldName, oldValue, newValue);
        }

        public void LogValueChange(PropertyInfo propertyInfo, object oldValue, object newValue)
        {
            string sFieldName = $"{propertyInfo.ReflectedType.FullName}.{propertyInfo.Name}";
            LogValueChange(sFieldName, oldValue, newValue);
        }
        private void LogValueChange(string sFieldname, object oldValue, object newValue)
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

        public void LogError(PropertyInfo propertyInfo, string sError)
        {
            string sFieldName = $"{propertyInfo.ReflectedType.FullName}.{propertyInfo.Name}";
            LogError(sFieldName, sError);
        }

        public void LogError(FieldInfo fieldInfo, string sError)
        {
            string sFieldName = $"{fieldInfo.ReflectedType.FullName}.{fieldInfo.Name}";
            LogError(sFieldName, sError);
        }
        private void LogError(string sFieldname, string sError)
        {
            $"LogValueChange:[{sFieldname}],[Msg:{sError}]".TraceRecord();
            PropertyChanges.Add(new csInstanceCopyLog(sFieldname, sError));
        }

    }

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

    public enum _instanceCopyMode
    {
        /// <summary>
        /// Copy only
        /// </summary>
        None,
        /// <summary>
        /// Only copy items with [InstanceDataAttribute] attribute
        /// </summary>
        InstanceData,
    }

    /// <summary>
    /// Mark the specific item to be copied
    /// </summary>
    public class InstanceDataAttribute : Attribute
    {
        /// <summary>
        /// Can have more properties
        /// </summary>
        public InstanceDataAttribute()
        {

        }
    }
}