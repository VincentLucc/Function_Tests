using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test001
{
    class ClassPublic
    {

        public GeneralResult IntVerification(object oData,int Min=0,int Max=100)
        {
            //Init result
            var result = new GeneralResult();

            if (!int.TryParse(oData.ToString(),out int iresult))
            {
                result.IsSuccess = false;
                result.Message = "Input is not a integral value.";
                return result;
            }


            //Pass all steps
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


   
}
