﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;

namespace SerialPort_Ink
{
    class csXML
    {
        //read xml
        public static bool ReadXML(Type ClassType, string FilePath, out object oResult)
        {
            //Init values
            XmlSerializer xmlSerializer = new XmlSerializer(ClassType);
            oResult = new object();

            try
            {
                //Check file existance
                if (!File.Exists(FilePath))
                {
                    return false;
                }

                //Write to XML
                using (FileStream reader = new FileStream(FilePath, FileMode.Open))
                {
                    oResult = xmlSerializer.Deserialize(reader);
                }
            }
            catch (Exception e1)
            {
                Debug.WriteLine("ClassXML.ReadXML" + e1.Message);
                return false;
            }


            //Pass all steps
            return true;
        }

        public static bool WriteXML(object TargetObject, Type ClassType, string FilePath)
        {

            //Init values
            XmlSerializer xmlSerializer = new XmlSerializer(ClassType);

            try
            {
                //Check file existance, make sure to close the file after creation
                if (!File.Exists(FilePath)) File.Create(FilePath).Close();

                //Write to XML
                using (TextWriter write = new StreamWriter(FilePath))
                {
                    xmlSerializer.Serialize(write, TargetObject);
                }
            }
            catch (Exception e1)
            {
                Debug.WriteLine("ClassXML.WriteXML" + e1.Message);
                return false;
            }

            //Pass all steps
            return true;

        }
    }
}