using Camera_Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class csConfigModel
{
    public bool CustomResolution { get; set; }

    /// <summary>
    /// Actual resolution value
    /// </summary>
    public csResolution Resolution { get; set; }

    public csConfigModel()
    {
        Resolution = new csResolution(1920, 1080);
    }

}

