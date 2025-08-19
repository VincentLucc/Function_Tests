using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace Serialization_48
{
    public class csPublic
    {
        /// <summary>
        /// Json.Net
        /// </summary>
        /// <param name="oItem"></param>
        /// <returns></returns>
        public static string SerializeObjectIgnoreNull(object oItem)
        {
            var jsonSetting = new JsonSerializerSettings();
            jsonSetting.NullValueHandling = NullValueHandling.Ignore;
            string sMessage = JsonConvert.SerializeObject(oItem, jsonSetting);
            return sMessage;
        }
    }
}
