using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Class_Copy
{
    public static class csCopyHelper
    {
        /// <summary>
        /// Copy values from another class
        /// Will only copy properties with same name.
        /// </summary>
        /// <typeparam name="tThis"></typeparam>
        /// <typeparam name="tCopySource"></typeparam>
        /// <param name="selfInstance"></param>
        /// <param name="copySourceInstance"></param>
        public static bool CopyValues<tThis, tCopySource>(this tThis selfInstance, tCopySource copySourceInstance)
        {
            if (selfInstance == null || copySourceInstance == null) return true;

            Type typeThis = selfInstance.GetType();
            Type typeCopy = copySourceInstance.GetType();

            try
            {
                //Check all fields
                var thisFields = typeThis.GetFields();
                var copyFields = typeCopy.GetFields();
                foreach (FieldInfo filedInfo in thisFields)
                {
                    //Check if field exist
                    var matchedField = copyFields.FirstOrDefault(a => a.Name == filedInfo.Name);
                    if (matchedField == null)
                    {
                        Debug.WriteLine($"Property Copy.Field Missing:{filedInfo.Name}");
                        continue;
                    }

                    // Read values
                    object valueThis = filedInfo.GetValue(selfInstance);
                    object valueCopy = matchedField.GetValue(copySourceInstance);

                    //Check field type
                    if (filedInfo.FieldType == matchedField.FieldType)
                    {
                        filedInfo.SetValue(selfInstance, valueCopy);
                        continue;
                    }

                    //Enum can go endless loop, handle enum manually
                    if (filedInfo.FieldType.IsEnum)
                    {
                        //Allow directly set value if possible
                        int iValue = (int)valueCopy;
                        if (Enum.IsDefined(filedInfo.FieldType, iValue))
                        {
                            filedInfo.SetValue(selfInstance, iValue);
                        }
                        else
                        {
                            Debug.WriteLine($"Property Copy.Enum Undefined:{filedInfo.Name}({iValue})");
                        }
                    }
                    else if (filedInfo.FieldType.IsGenericType)
                    {
                        Debug.WriteLine($"Property Copy.Generic Ignored:{filedInfo.Name}");
                    }
                    else
                    {
                        valueThis.CopyValues(valueCopy);
                    }
                }

                //Check all properties
                PropertyInfo[] thisProperties = typeThis.GetProperties();
                PropertyInfo[] copyProperties = typeCopy.GetProperties();
                foreach (PropertyInfo propertyInfo in thisProperties)
                {
                    // Skip unreadable and writeprotected ones
                    if (!propertyInfo.CanRead || !propertyInfo.CanWrite) continue;

                    //Check if property exist
                    var matchedProperty = copyProperties.FirstOrDefault(a =>
                    a.Name == propertyInfo.Name && a.CanRead);
                    if (matchedProperty == null)
                    {
                        Debug.WriteLine($"Property Copy.Property Missing:{propertyInfo.Name}");
                        continue;
                    }

                    // Read values
                    object valueThis = propertyInfo.GetValue(selfInstance, null);
                    object valueCopy = matchedProperty.GetValue(copySourceInstance, null);

                    //Check property type
                    if (propertyInfo.PropertyType == matchedProperty.PropertyType)
                    {
                        propertyInfo.SetValue(selfInstance, valueCopy, null);
                        continue;
                    }
                    //Attempt to do deep copy
                    if (propertyInfo.PropertyType.IsEnum)
                    {//Enum can go endless loop, handle enum manually
                        //Allow directly set value if possible
                        int iValue = (int)valueCopy;
                        if (Enum.IsDefined(propertyInfo.PropertyType, iValue))
                        {
                            propertyInfo.SetValue(selfInstance, iValue, null);
                        }
                        else
                        {
                            Debug.WriteLine($"Property Copy.Enum Undefined:{propertyInfo.Name}({iValue})");
                        }
                    }
                    else if (propertyInfo.PropertyType.IsGenericType)
                    {
                        Debug.WriteLine($"Property Copy.Generic Ignored:{propertyInfo.Name}");
                    }
                    else
                    {
                        valueThis.CopyValues(valueCopy);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"csCopyHelper.CopyValues.Exception:{ex.Message}");
                return false;
            }

            //Pass all steps
            return true;
        }

        /// <summary>
        /// Copy values from another class
        /// Will only copy properties with same name.
        /// </summary>
        /// <typeparam name="tThis"></typeparam>
        /// <typeparam name="tCopySource"></typeparam>
        /// <param name="selfInstance"></param>
        /// <param name="copySourceInstance"></param>
        public static bool CopyValuesSpecial<tThis, tCopySource>(this tThis selfInstance, tCopySource copySourceInstance)
        {
            if (selfInstance == null || copySourceInstance == null) return true;

            Type typeThis = selfInstance.GetType();
            Type typeCopy = copySourceInstance.GetType();

            try
            {
                //Check all fields
                var thisFields = typeThis.GetFields();
                var copyFields = typeCopy.GetFields();
                foreach (FieldInfo filedInfo in thisFields)
                {
                    //Check if field exist
                    var matchedField = copyFields.FirstOrDefault(a => a.Name == filedInfo.Name);
                    if (matchedField == null)
                    {
                        Debug.WriteLine($"Property Copy.Field Missing:{filedInfo.Name}");
                        continue;
                    }

                    // Read values
                    object valueThis = filedInfo.GetValue(selfInstance);
                    object valueCopy = matchedField.GetValue(copySourceInstance);

                    //Check field type
                    if (filedInfo.FieldType != matchedField.FieldType)
                    {//Attempt to do deep copy

                        //Enum can go endless loop, handle enum manually
                        if (filedInfo.FieldType.IsEnum)
                        {
                            //Allow directly set value if possible
                            int iValue = (int)valueCopy;
                            if (Enum.IsDefined(filedInfo.FieldType, iValue))
                            {
                                filedInfo.SetValue(selfInstance, iValue);
                                continue;
                            }
                            else
                            {
                                Debug.WriteLine($"Property Copy.Enum Undefined:{filedInfo.Name}({iValue})");
                            }

                        }
                        else if (filedInfo.FieldType.IsGenericType)
                        {
                            Debug.WriteLine($"Property Copy.Generic Ignored:{filedInfo.Name}");
                            continue; //Ignore collections
                        }
                        else
                        {
                            valueThis.CopyValuesSpecial(valueCopy);
                            continue;
                        }

                        //Handle special case

                    }

                    //Write value to this
                    filedInfo.SetValue(selfInstance, valueCopy);
                }

                //Check all properties
                PropertyInfo[] thisProperties = typeThis.GetProperties();
                PropertyInfo[] copyProperties = typeCopy.GetProperties();
                foreach (PropertyInfo propertyInfo in thisProperties)
                {
                    // Skip unreadable and writeprotected ones
                    if (!propertyInfo.CanRead || !propertyInfo.CanWrite) continue;

                    //Check if property exist
                    var matchedProperty = copyProperties.FirstOrDefault(a =>
                    a.Name == propertyInfo.Name && a.CanRead);
                    if (matchedProperty == null)
                    {
                        Debug.WriteLine($"Property Copy.Property Missing:{propertyInfo.Name}");
                        continue;
                    }

                    // Read values
                    object valueThis = propertyInfo.GetValue(selfInstance, null);
                    object valueCopy = matchedProperty.GetValue(copySourceInstance, null);

                    //Check property type
                    if (propertyInfo.PropertyType != matchedProperty.PropertyType)
                    {//Attempt to do deep copy
                     //Enum can go endless loop, handle enum manually

                        if (propertyInfo.PropertyType == typeof(List<Sub1>))
                        {
                            var newList = new List<Sub1>();
                            if (matchedProperty.PropertyType == typeof(List<Sub2>))
                            {
                                var listCopy = valueCopy as List<Sub2>;
                                foreach (var item in listCopy)
                                {
                                    var sub1Item = new Sub1();
                                    sub1Item.CopyValuesSpecial(item);
                                    newList.Add(sub1Item);
                                }
                            }
                            propertyInfo.SetValue(selfInstance, newList, null);
                        }
                        else if (propertyInfo.PropertyType.IsEnum)
                        {
                            //Allow directly set value if possible
                            int iValue = (int)valueCopy;
                            if (Enum.IsDefined(propertyInfo.PropertyType, iValue))
                            {
                                propertyInfo.SetValue(selfInstance, iValue, null);
                                continue;
                            }
                            else
                            {
                                Debug.WriteLine($"Property Copy.Enum Undefined:{propertyInfo.Name}({iValue})");
                            }
                        }
                        else if (propertyInfo.PropertyType.IsGenericType)
                        {
                            Debug.WriteLine($"Property Copy.Generic Ignored:{propertyInfo.Name}");
                            continue; //Ignore collections
                        }
                        else
                        {
                            valueThis.CopyValuesSpecial(valueCopy);
                            continue;
                        }
                    }

                    //Write value to this
                    propertyInfo.SetValue(selfInstance, valueCopy, null);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"csCopyHelper.CopyValues.Exception:{ex.Message}");
                return false;
            }

            //Pass all steps
            return true;
        }
    }
}
