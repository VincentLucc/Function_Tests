using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace Serialization
{
    public class csPublic
    {
        public static string SerializeObjectIgnoreNull(object oItem)
        {
            var jsonSetting = new JsonSerializerSettings();
            jsonSetting.NullValueHandling = NullValueHandling.Ignore;
            string sMessage = JsonConvert.SerializeObject(oItem, jsonSetting);
            return sMessage;
        }
    }
}
