using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test001
{
    class ClassPublic
    {

        /// <summary>
        /// Verify if object is a int value and if in range
        /// </summary>
        /// <param name="oData"></param>
        /// <param name="Min"></param>
        /// <param name="Max"></param>
        /// <returns></returns>
        public static GeneralResult IntVerification(object oData,int Min=0,int Max=100)
        {
            //Init result
            var result = new GeneralResult();

            //Null verification
            if (oData==null)
            {
                result.IsSuccess = false;
                result.Message = "Empty input.";
                return result;
            }

            //Check if value is int value
            if (!int.TryParse(oData.ToString(),out int iData))
            {
                result.IsSuccess = false;
                result.Message = "Input is not a integral value.";
                return result;
            }

            //Check if value in range
            if (iData>Max||iData<Min)
            {
                result.IsSuccess = false;
                result.Message = "Input is not in range.";
                return result;
            }


            //Pass all steps
            result.IsSuccess = true;
            result.IntResult = iData;
            return result;
        }
    }

    /// <summary>
    /// General return of a method
    /// </summary>
    public class GeneralResult
    {
        public bool IsSuccess { get; set; } //Method is succes or not
        public int IntResult { get; set; } //Return int result if value needed
        public String Message { get; set; }
    }


    public class SelectionResult
    {
        public bool IsSuccess { get; set; } //Method is succes or not
        public List<int[]> Selection { get; set; } //Return selection result if value needed                                           
        public string Message { get; set; }
        public SelectionResult()
        {
            Selection = new List<int[]>();
        }
    }


    [Serializable]
    public class InputField
    {
        public InputField(string _Name)
        {
            Name = _Name;
            Description = "";
            ColumnNumber = 0;
            Position = 0;
            Length = 0;
        }

        public InputField()
        {
        }

        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
        [XmlAttribute]
        public int ColumnNumber { get; set; }
        [XmlAttribute]
        public int Position { get; set; }
        [XmlAttribute]
        public int Length { get; set; }
    }


}
