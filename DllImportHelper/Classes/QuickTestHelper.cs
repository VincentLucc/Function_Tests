using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllImportHelper.Classes
{
    /// <summary>
    /// Call dll from the 【AOT】 quick test dll
    /// </summary>
    class QuickTestHelper
    {
        [System.Runtime.InteropServices.DllImport("_QuickTests.Core.dll")]
        internal static extern bool TestDoSth();

        [System.Runtime.InteropServices.DllImport("_QuickTests.Core.dll")]
        internal static extern int TestPlus(int iA, int iB);
    }
}
