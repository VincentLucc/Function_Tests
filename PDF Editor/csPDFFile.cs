using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Editor
{

    internal class csPDFFile
    {
        [DisplayName("File Name")]
        internal string Path { get; set; }

        [DisplayName("File Size")]
        internal int FileSize { get; set; }

    }
}
