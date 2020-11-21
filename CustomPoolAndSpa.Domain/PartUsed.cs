using System;
using System.ComponentModel.DataAnnotations;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain
{
    public class PartUsed : IEntity<int>, IModificationHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Material Part { get; set; }

        //public int PartId { get; set; }

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
