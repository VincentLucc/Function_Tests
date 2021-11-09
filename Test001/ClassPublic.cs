using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test001
{
    class ClassPublic
    {

        public GeneralResult IntVerification(object )
        {

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
