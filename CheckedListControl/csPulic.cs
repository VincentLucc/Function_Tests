using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CheckedListControl
{
    static class csPulic
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
              .GetMember(enumValue.ToString())
              .First()
              .GetCustomAttribute<DisplayAttribute>()
              ?.GetName();
        }
    }

    public enum InkSystemFunctionCode
    {
        [Display(Name = "Enable Ink System")]
        EnableInk = 0,
        [Display(Name = "Enable Recirculation")]
        EnableRecirculation = 3,
        /// <summary>
        /// Monitored fill pump set will update this setting
        /// </summary>
        [Display(Name = "Disable Fill Pump")]
        UserPWM_FillPumpDisable = 4,
        [Display(Name = "Enable Onboard Purge")]
        LocalOnBoardPurgeEnable = 6, //Local purge
        [Display(Name = "Enable Internal Purge")]
        InternalSignalEnable = 7, //USE INTERNAL SIGNALS
        [Display(Name = "Enable External Purge")]
        ExternalPurgeEnable = 9,//enable external purge signal
        [Display(Name = "Enable Degas")]
        EnableDegass = 13,
    }
}
