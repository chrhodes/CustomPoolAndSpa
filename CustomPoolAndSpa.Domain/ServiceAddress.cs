using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Common.Domain;
using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain
{
    public class ServiceAddress : IEntity<int>, IModificationHistory
    {
        public ServiceAddress()
        {
            ServiceCalls = new List<ServiceCall>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Address Address { get; set; }

        public List<ServiceCall> ServiceCalls { get; set; }

        #region IModificationHistory

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsDirty { get; set; }

        #endregion
    }
}
