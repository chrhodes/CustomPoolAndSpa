using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain
{
    [ComplexType]
    public class PoolCondition
    {
        //[StringLength(20)]
        // Typically whole values and 0.5
        // Nominal 0
        [Range(0, 5, ErrorMessage = "Invalid Value (0-5)")]
        public Single ChlorineResidual { get; set; }

        //[StringLength(20)]
        // Nominal 1
        [Range(0, 4, ErrorMessage = "Invalid Value (0-4)")]
        public Single FreeChlorine { get; set; }

        //[StringLength(20)]
        // Nominal 7.4-7.6
        [Range(6, 8, ErrorMessage = "Invalid Value (6.0 - 8.0)")]
        public Single PHLevel { get; set; }

        //[StringLength(20)]
        // Nominal 160
        [Range(110, 180, ErrorMessage = "Invalid Value (110 - 180)")]
        public Single TotalAlkalinity { get; set; }

        //[StringLength(20)]
        // Nominal 0
        [Range(0, 10, ErrorMessage = "Invalid Value (0 - 10)")]
        public Single Turbidity { get; set; }

        //[StringLength(20)]
        // Nominal 30-40
        [Range(0, 80, ErrorMessage = "Invalid Value (0 - 80)")]
        public Single CyanuricAcidLevel { get; set; }

        // Nominal < 82
        [Range(0, 100, ErrorMessage = "Invalid Temperature (0 - 100F)")]
        public Single Temperature { get; set; }

        // TODO(crhodes)
        // Figure out how to get EF to not need this
        public bool? IsDirty { get; set; }

    }
}
