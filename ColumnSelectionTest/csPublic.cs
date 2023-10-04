using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test001
{
    class csPublic
    {
        public static FormMapping winMapping;
        public static FormTree winTree;
        public static FormMain winMain;

        public static string FakeText= "CompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDownCompositionDiagramControl_MouseDown\r\nThe thread 0x6e64 has exited with code 0 (0x0).\r\nThe thread 0x796c has exited with code 0 (0x0).\r\nThe thread 0x60e0 has exited with code 0 (0x0).\r\nThe thread 0x36b4 has exited with code 0 (0x0).\r\nThe thread 0xa58 has exited with code 0 (0x0).\r\nThe thread 0x2958 has exited with code 0 (0x0).\r\nThe thread 0x12ec has exited with code 0 (0x0).\r\nThe thread 0x73e4 has exited with code 0 (0x0).\r\nThe program '[32472] DeltaX_Tracker.exe' has exited with code -1 (0xffffffff).";

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



    public class DataFileSetting
    {

        public DataFileSetting()
        {
            InputFields = new BindingList<InputField>();
            KeyColumn = "";
            Key2 = "";
            Key3 = "";

            //Create sample column data
            CreateSampleData();
        }

        public bool Delimited { get; set; }

        public int DelimiterIndex { get; set; }

        public string SpecialCharacter { get; set; }

        public string DelimiterCharacter
        {
            get
            {
                string str = "";

                switch (DelimiterIndex)
                {
                    case 0:
                        str = ",";
                        break;
                    case 1:
                        str = ";";
                        break;
                    case 2:
                        str = "\t";
                        break;
                    case 3:
                        str = " ";
                        break;
                    case 4:
                        str = SpecialCharacter;
                        break;
                }

                return str;
            }
        }

        public bool ContainsJobInfo { get; set; }

        public bool FirstLineIsHeader { get; set; }

        /// <summary>
        /// Main fixed width delimiter config
        /// </summary>
        public BindingList<InputField> InputFields { get; set; }

        public string KeyColumn { get; set; }

        public string Key2 { get; set; }

        public string Key3 { get; set; }

        public string SampleDataFile { get; set; }

        public bool FieldExists(string fieldName)
        {
            if (InputFields.Any(p => p.Name == fieldName))
                return true;
            else
                return false;
        }

        public bool DeviceNameExists(string fieldName)
        {
            if (InputFields.Any(p => p.Name == fieldName))
                return true;
            else
                return false;
        }

      
        /// <summary>
        /// Sample data for testing
        /// </summary>
        public void CreateSampleData()
        {
            for (int i = 0; i < 5; i++)
            {
                InputField field = new InputField()
                { Name = $"Test{i}", Description = "Test", Position = i, Length = i + 10 };


                for (int j = 0; j < 3; j++)
                {
                    InputField customFiled = new InputField()
                    { Name = $"Test{i}_{j}", Description = "Test", Position = j, Length = j + 2 };
                    field.CustomFields.Add(customFiled);
                }

                InputFields.Add(field);
            }
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
            CustomFields = new List<InputField>();
        }

        public InputField()
        {
            CustomFields = new List<InputField>();
            Description = "";
            ColumnNumber = 0;
            Position = 0;
            Length = 0;
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
        /// <summary>
        /// Indidate wether this field is hidden from operator or preview
        /// </summary>
        [XmlIgnore]
        public bool IsHidden { get; set; }
        public List<InputField> CustomFields { get; set; }
    }


    /// <summary>
    /// Custmized Fields with fixed width file format
    /// </summary>
    [Serializable]
    public class CustomField
    {
        /// <summary>
        /// Custom column index
        /// </summary>
        public int ColumnIndex { get; set; }
        /// <summary>
        /// Read from DataFileSetting.InputFields.Name
        /// </summary>
        [XmlIgnore]
        public string ColumnName { get; set; }
        /// <summary>
        /// // Sub column fixed width config 
        /// </summary>
        public List<InputField> FieldConfig { get; set; }

        public CustomField()
        {
            FieldConfig = new List<InputField>();
        }
    }

    public enum FieldAddType
    {
        DefaultSelection, //Add new filed with default selection(0,1)
        CurrentSelection,//Add a new field with current selection
        AfterCurrentSelection, //Add new filed after current selection
    }

}
