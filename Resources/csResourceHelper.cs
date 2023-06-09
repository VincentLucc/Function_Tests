using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesTest
{
    class csResourceHelper
    {
        public static Dictionary<string, ResXDataNode> ResList;

        public static bool Init()
        {
            try
            {
                ResList?.Clear();
                ResList = new Dictionary<string, ResXDataNode>();

                //Notice:
                //In "Embedded Resource" mode, text is in compact mode (Instead of raw xml)
                //which ResXResourceReader doesn't support
                //ResourceReader can read compact mode, but doesn't contain "comment" property
                //Use "Attached file" mode to read the raw xml data instead;
                //Maintain "Embedded Resource" mode to make sure direct reference is valid
                string sOutput = Properties.Resources.ResourceStrings;
                
                //Read as ResXDataNode
                using (MemoryStream fixedStream = new MemoryStream(Encoding.UTF8.GetBytes(sOutput)))
                {
                    using (ResXResourceReader resxReader = new ResXResourceReader(fixedStream))
                    {
                        resxReader.UseResXDataNodes = true;
                        IDictionaryEnumerator enumerator = resxReader.GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            ResXDataNode node = (ResXDataNode)enumerator.Value;
                            ResList.Add(node.Name, node);
                            //Debug.WriteLine($"Name:{node.Name},{node.GetValue((ITypeResolutionService)null)},Comment:{node.Comment}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"csResourceHelper.Init:\r\n{ex.Message}");
                return false;
            }


            //Pass all steps
            Debug.WriteLine($"Resources messages loaded count: {ResList.Count}");
            return true;
        }

        public static string GetValue(string sName)
        {
            if (!ResList.ContainsKey(sName)) return "";
            ResXDataNode node = ResList[sName];
            var value = node.GetValue((ITypeResolutionService)null);
            return value.ToString();
        }

        public static string GetComment(string sName)
        {
            if (!ResList.ContainsKey(sName)) return "";
            ResXDataNode node = ResList[sName];
            return node.Comment;
        }
    }
}
