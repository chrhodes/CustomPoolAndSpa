using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain
{
    public class ServiceCall : IEntity<int>, IModificationHistory
    {
        public ServiceCall()
        {
            ServiceAddress = new ServiceAddress();
            ServiceType = new ServiceType();
            PoolCondition = new PoolCondition();
            MaterialsUsed = new List<MaterialUsed>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime ServiceDate { get; set; }

        public TimeSpan ServiceTime { get; set; }

        [Required]
        public ServiceAddress ServiceAddress { get; set; }

        public ServiceType ServiceType { get; set; }

        public PoolCondition PoolCondition { get; set; }

        public TimeSpan AdditionalTime { get; set; }

        public List<ChemicalUsed> ChemicalsUsed;
        public List<MaterialUsed> MaterialsUsed;
        public List<PartUsed> PartsUsed;

        #region IModificationHistory

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsDirty { get; set; }

        #endregion
    }
}
