using _CommonCode_Framework;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Class_Copy
{
    public static class csInstanceCopyHelper
    {
        /// <summary>
        /// Copy values from another class
        /// Allow to copy and log value changes
        /// </summary>
        /// <typeparam name="tThis"></typeparam>
        /// <typeparam name="tCopySource"></typeparam>
        /// <param name="selfInstance"></param>
        /// <param name="copyInstance"></param>
        /// <returns></returns>
        public static List<csInstanceCopyLog> CopyInstanceValues<tThis, tCopySource>(this tThis selfInstance, tCopySource copyInstance)
        {
            List<csInstanceCopyLog> PropertyChanges = new List<csInstanceCopyLog>();
            "InstanceCopy.Start".TraceRecord();
            bool isSuccess = selfInstance.CopyValues(copyInstance, ref PropertyChanges);
            $"InstanceCopy.Complete:[Count:{PropertyChanges.Count}],[Success:{isSuccess}]".TraceRecord();
            return PropertyChanges;
        }

        /// <summary>
        /// Copy values from another class
        /// Will only copy properties with same name.
        /// </summary>
        /// <typeparam name="tThis"></typeparam>
        /// <typeparam name="tCopySource"></typeparam>
        /// <param name="selfInstance"></param>
        /// <param name="copyInstance"></param>
        public static bool CopyValues<tThis, tCopySource>(this tThis selfInstance, tCopySource copyInstance, ref List<csInstanceCopyLog> propertyChanges)
        {
            if (selfInstance == null || copyInstance == null) return true;

            try
            {
                CopyFields(selfInstance, copyInstance, ref propertyChanges);
                CopyProperties(selfInstance, copyInstance, ref propertyChanges);
            }
            catch (Exception ex)
            {
                ex.TraceException("csCopyHelper.CopyValues");
                return false;
            }

            //Pass all steps
            return true;
        }

        private static void CopyFields(object selfInstance, object copySourceInstance, ref List<csInstanceCopyLog> propertyChanges)
        {
            try
            {
                //Check all fields
                var thisFields = selfInstance.GetType().GetFields();
                var copyFields = copySourceInstance.GetType().GetFields();
                foreach (FieldInfo thisFieldInfo in thisFields)
                {
                    //Check if field exist
                    var copyFieldInfo = copyFields.FirstOrDefault(a => a.Name == thisFieldInfo.Name);
                    if (copyFieldInfo == null)
                    {
                        $"Property Copy.Field Missing:{thisFieldInfo.Name}".TraceRecord();
                        propertyChanges.LogError(thisFieldInfo, "Field Missing");
                        continue;
                    }

                    // Read values
                    object valueThis = thisFieldInfo.GetValue(selfInstance);
                    object valueCopy = copyFieldInfo.GetValue(copySourceInstance);

                    //Direcly copy items with the same type
                    if (thisFieldInfo.FieldType == copyFieldInfo.FieldType)
                    {
                        //Handle class
                        if (thisFieldInfo.FieldType.IsUserDefinedClass())
                        {
                            valueThis.CopyValues(valueCopy, ref propertyChanges);
                            continue;
                        }

                        //Other types, directly set
                        //Enum: same type, set direcly
                        thisFieldInfo.SetValue(selfInstance, valueCopy);
                        propertyChanges.LogValueChange(thisFieldInfo, valueThis, valueCopy);
                        continue;
                    }

                    //Type is different, attempt to do deep copy
                    //Enum can go endless loop, handle enum manually
                    if (thisFieldInfo.FieldType.IsEnum)
                    {
                        //Allow directly set value if possible
                        int iValue = (int)valueCopy;
                        if (Enum.IsDefined(thisFieldInfo.FieldType, iValue))
                        {
                            thisFieldInfo.SetValue(selfInstance, iValue);
                            propertyChanges.LogValueChange(thisFieldInfo, valueThis, valueCopy);
                            continue;
                        }
                        else
                        {
                            $"Property Copy.Enum Undefined:{thisFieldInfo.Name}({iValue})".TraceRecord();
                            propertyChanges.LogError(thisFieldInfo, $"Enum Undefined({iValue})");
                        }
                    }
                    else if (thisFieldInfo.FieldType.IsGenericType)
                    {
                        SetGenericField(selfInstance, copySourceInstance, thisFieldInfo, copyFieldInfo, ref propertyChanges);
                    }
                    else
                    {
                        valueThis.CopyValues(valueCopy, ref propertyChanges);
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.TraceException("InstanceCopy.CopyFields");
            }

        }

        private static void SetGenericField(object selfInstance, object copyInstance, FieldInfo thisFieldInfo, FieldInfo copyFieldInfo, ref List<csInstanceCopyLog> propertyChanges)
        {
            
            //Get value
            object valueThis = thisFieldInfo.GetValue(selfInstance);
            object valueCopy = copyFieldInfo.GetValue(copyInstance);

            //Make sure value is generic
            var genericType = thisFieldInfo.FieldType.GetGenericTypeDefinition();
            if (genericType != typeof(List<>) ||
                genericType != typeof(BindingList<>))
            {
                //Directly copy
                if (thisFieldInfo.FieldType == copyFieldInfo.FieldType)
                {
                    thisFieldInfo.SetValue(selfInstance, valueCopy);
                    propertyChanges.LogValueChange(thisFieldInfo, valueThis, valueCopy);
                    return;
                }

                //Ignore collections
                $"Field Copy.Generic Ignored:{thisFieldInfo.Name}".TraceRecord();
                propertyChanges.LogError(thisFieldInfo, "Ignored");
                return;
            }


            //Create reference list
            var thisItemType = thisFieldInfo.FieldType.GetGenericArguments()[0];
            var copyList = (System.Collections.IList)valueCopy;
            //Create new list
            var newList = (System.Collections.IList)Activator.CreateInstance(thisFieldInfo.FieldType);
            foreach (var item in copyList)
            {
                var thisItem = Activator.CreateInstance(thisItemType);
                thisItem.CopyValues(item, ref propertyChanges);
                newList.Add(thisItem);
            }


            thisFieldInfo.SetValue(selfInstance, newList);
            propertyChanges.LogValueChange(thisFieldInfo, valueThis, valueCopy);
        }


        private static void CopyProperties(object selfInstance, object copyInstance, ref List<csInstanceCopyLog> propertyChanges)
        {
            try
            {
                var thisType = selfInstance.GetType();
                var copyType = copyInstance.GetType();
                PropertyInfo[] thisProperties = thisType.GetProperties();
                PropertyInfo[] copyProperties = copyType.GetProperties();
                foreach (PropertyInfo thisPropertyInfo in thisProperties)
                {
                    // Skip unreadable and writeprotected ones
                    if (!thisPropertyInfo.CanRead || !thisPropertyInfo.CanWrite) continue;

                    //Check if property exist
                    var copyPropertyInfo = copyProperties.FirstOrDefault(a =>
                    a.Name == thisPropertyInfo.Name && a.CanRead);
                    if (copyPropertyInfo == null)
                    {
                        $"Property Copy.Property Missing:{thisPropertyInfo.Name}".TraceRecord();
                        propertyChanges.LogError(thisPropertyInfo, "Property Missing");
                        continue;
                    }

                    // Read values
                    object valueThis = thisPropertyInfo.GetValue(selfInstance, null);
                    object valueCopy = copyPropertyInfo.GetValue(copyInstance, null);

                    //Same property type
                    if (thisPropertyInfo.PropertyType == copyPropertyInfo.PropertyType)
                    {//Write value to this
                     //Handle class
                        if (thisPropertyInfo.PropertyType.IsUserDefinedClass())
                        {
                            valueThis.CopyValues(valueCopy, ref propertyChanges);
                            continue;
                        }

                        //Other types, directly set
                        //Enum: same type, set directly
                        thisPropertyInfo.SetValue(selfInstance, valueCopy, null);
                        propertyChanges.LogValueChange(thisPropertyInfo, valueThis, valueCopy);
                        continue;
                    }

                    //Attempt to do deep copy
                    //Enum can go endless loop, handle enum manually
                    if (thisPropertyInfo.PropertyType.IsEnum)
                    {
                        //Allow directly set value if possible
                        int iValue = (int)valueCopy;
                        if (Enum.IsDefined(thisPropertyInfo.PropertyType, iValue))
                        {
                            thisPropertyInfo.SetValue(selfInstance, iValue, null);
                            propertyChanges.LogValueChange(thisPropertyInfo, valueThis, valueCopy);
                            continue;
                        }
                        else
                        {
                            $"Property Copy.Enum Undefined:{thisPropertyInfo.Name}({iValue})".TraceRecord();
                            propertyChanges.LogError(thisPropertyInfo, $"Enum Undefined({iValue})");
                        }
                    }
                    else if (thisPropertyInfo.PropertyType.IsGenericType)
                    {
                        SetGenericProperty(selfInstance, copyInstance, thisPropertyInfo, copyPropertyInfo, ref propertyChanges);
                    }
                    else
                    {
                        valueThis.CopyValues(valueCopy, ref propertyChanges);
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.TraceException("InstanceCopy.CopyProperties");
            }

        }



        /// <summary>
        /// Handle generic object with different class type
        /// </summary>
        /// <param name="thisPropertyInfo"></param>
        /// <param name="propertyChanges"></param>
        private static void SetGenericProperty(object selfInstance, object copyInstance, PropertyInfo thisPropertyInfo, PropertyInfo copyPropertyInfo, ref List<csInstanceCopyLog> propertyChanges)
        {
            //Get value
            object valueThis = thisPropertyInfo.GetValue(selfInstance);
            object valueCopy = copyPropertyInfo.GetValue(copyInstance);

            //Make sure value is generic
            var genericType = thisPropertyInfo.PropertyType.GetGenericTypeDefinition();
            if (genericType != typeof(List<>) ||
                genericType != typeof(BindingList<>))
            {//Ignore collections

                //Directly copy
                if (thisPropertyInfo.PropertyType == copyPropertyInfo.PropertyType)
                {
                    thisPropertyInfo.SetValue(selfInstance, valueCopy);
                    propertyChanges.LogValueChange(thisPropertyInfo, valueThis, valueCopy);
                    return;
                }

                $"Property Copy.Generic Ignored:{thisPropertyInfo.Name}".TraceRecord();
                propertyChanges.LogError(thisPropertyInfo, "Ignored");
                return;
            }



            //Create reference list
            var thisItemType = thisPropertyInfo.PropertyType.GetGenericArguments()[0];
            var copyList = (System.Collections.IList)valueCopy;
            //Create new list
            var newList = (System.Collections.IList)Activator.CreateInstance(thisPropertyInfo.PropertyType);
            foreach (var item in copyList)
            {
                var thisItem = Activator.CreateInstance(thisItemType);
                thisItem.CopyValues(item, ref propertyChanges);
                newList.Add(thisItem);
            }


            thisPropertyInfo.SetValue(selfInstance, newList, null);
            propertyChanges.LogValueChange(thisPropertyInfo, valueThis, valueCopy);
        }
    }
}
