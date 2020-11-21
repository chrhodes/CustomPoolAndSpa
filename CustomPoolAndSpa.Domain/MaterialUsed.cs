using System;
using System.ComponentModel.DataAnnotations;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain
{
    public class MaterialUsed : IEntity<int>, IModificationHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Material Material { get; set; }

        //public int MaterialId { get; set; }

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
