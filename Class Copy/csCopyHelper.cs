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
        /// <typeparam name="tFrom"></typeparam>
        /// <param name="selfInstance"></param>
        /// <param name="fromInstance"></param>
        public static void CopyPropertyValues<tThis, tFrom>(this tThis selfInstance, tFrom fromInstance)
        {
            Type typeThis = selfInstance.GetType();
            Type typeFrom = fromInstance.GetType();
            PropertyInfo[] thisProperties = typeThis.GetProperties();
            PropertyInfo[] fromProperties = typeFrom.GetProperties();
            foreach (PropertyInfo propertyInfo in thisProperties)
            {
                // Skip unreadable and writeprotected ones
                if (!propertyInfo.CanRead || !propertyInfo.CanWrite) continue;

                //Check if property exist
                var matchedProperty = fromProperties.FirstOrDefault(a=>
                a.Name== propertyInfo.Name && a.CanRead);
                if (matchedProperty == null)
                {
                    Debug.WriteLine($"Property Copy.Missing:{propertyInfo.Name}");
                    continue;
                }

                // Read values
                object valueThis = propertyInfo.GetValue(selfInstance, null);              
                object valueFrom = matchedProperty.GetValue(fromInstance, null);

                //Check property type
                if (propertyInfo.PropertyType != matchedProperty.PropertyType)
                {//Attempt to do deep copy
                    valueThis.CopyPropertyValues(valueFrom);
                    continue;
                }

                //Write value to this
                propertyInfo.SetValue(selfInstance, valueFrom, null);
            }
        }
    }
}
