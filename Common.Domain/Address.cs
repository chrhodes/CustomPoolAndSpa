using System;
using System.ComponentModel.DataAnnotations;

using VNC.Core.DomainServices;

namespace Common.Domain
{
    public class Address : IEntity<int>, IModificationHistory
    {

        #region IEntity<int>

        // Using Data Annotations to enforce constraints
        // Need to add reference to System.ComponentModel.DataAnnotations

        // By convention Id is the Key.  But let's specify anyway.

        [Key]
        public int Id { get; set; }

        #endregion

        //[MaxLength(50)] // Used for Strings or Byte Arrays

        [StringLength(50)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string CountryOrRegion { get; set; }

        #region IModificationHistory

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsDirty { get; set; }

        #endregion
    }
}
