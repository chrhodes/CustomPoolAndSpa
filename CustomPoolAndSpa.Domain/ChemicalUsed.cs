using System;
using System.ComponentModel.DataAnnotations;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain
{
    public class ChemicalUsed : IEntity<int>, IModificationHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Chemical Chemical { get; set; }

        //public int ChemicalId { get; set; }

        public float Quantity { get; set; }

        [Required]
        public ServiceCall ServiceReport { get; set; }

        #region IModificationHistory

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsDirty { get; set; }

        #endregion
    }
}
