using System;
using System.ComponentModel.DataAnnotations;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain
{
    public class Chemical : IEntity<int>, IModificationHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        #region IModificationHistory

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsDirty { get; set; }

        #endregion
    }
}
