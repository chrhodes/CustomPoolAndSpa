using System;
using System.ComponentModel.DataAnnotations;

using VNC.Core.DomainServices;

namespace Common.Domain
{
    public class Person : IEntity<int>, IModificationHistory
    {
        #region IEntity<int>

        public int Id { get; set; }

        #endregion

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        #region IModificationHistory

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsDirty { get; set; }

        #endregion
    }
}
