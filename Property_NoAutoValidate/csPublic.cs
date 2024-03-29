﻿using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_NoAutoValidate
{
    class csPublic
    {
        public static ImageCollection imageCollection;
    }

    /// <summary>
    /// Masks
    /// # any digital or nothing if empty
    /// 0 any digital or zero if empty
    /// . decimal point
    /// , thousand separator
    /// "##0.##" allow to input 000.00 format
    /// Ref:https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Editors.PropertyEditor.EditMask
    /// </summary>
    static class EditMasks
    {
        public const string Metric_Distance2 = "#0.00\\ \\m\\m";
        public const string Metric_Distance3 = "##0.00\\ \\m\\m";
        public const string Metric_Distance4 = "###0.00\\ \\m\\m";
        public const string Metric_Distance5 = "####0.00\\ \\m\\m";

        public const string Metric_Speed = "###0.00\\ \\m\\/\\m";
        public const string Metric_RPM = "###0.00\\ \\R\\P\\M";

        public const string Imperial_Distance2 = "#0.000\\ \\I\\n\\c\\h\\e\\s";
        public const string Imperial_Distance3 = "##0.000\\ \\I\\n\\c\\h\\e\\s";
        public const string Imperial_Distance4 = "###0.000\\ \\I\\n\\c\\h\\e\\s";
        public const string Imperial_Distance5 = "####0.000\\ \\I\\n\\c\\h\\e\\s";

        public const string Imperial_Speed = "###0.00\\ \\F\\P\\M";

        public const string DigitalValue3 = "##0";
        public const string DigitalValue5 = "####0";
        public const string DigitalValue6 = "#####0";
        public const string DigitalValue9 = "########0";

        public const string RegNumber6NoZero = "[1-9][0-9]{0,5}";
    }
}
