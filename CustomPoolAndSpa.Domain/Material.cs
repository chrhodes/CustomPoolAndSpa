using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain
{
    public class Material : IEntity<int>, IModificationHistory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        #region IModificationHistory

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsDirty { get; set; }

        #endregion
    }
}
