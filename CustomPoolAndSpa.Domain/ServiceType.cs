using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomPoolAndSpa.Domain
{

    //public struct ServiceType
    //{
    //    public bool VacuumService { get; set; }

    //    public bool ChemicalCheck { get; set; }

    //    public bool SPAService { get; set; }

    //    public bool PolarisService { get; set; }

    //    public bool ServiceCall { get; set; }

    //    public bool Delivery { get; set; }

    //}

    [ComplexType]
    public class ServiceType
    {
        public bool VacuumService { get; set; }

        public bool ChemicalCheck { get; set; }

        public bool SPAService { get; set; }

        public bool PolarisService { get; set; }

        public bool ServiceCall { get; set; }

        public bool Delivery { get; set; }

        // TODO(crhodes)
        // Figure out how to get EF to not need this
        public bool? IsDirty { get; set; }

    }
}
