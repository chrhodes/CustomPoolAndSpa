using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain;
using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.Domain
{
    public class Customer : IEntity<int>, IModificationHistory
    {
        public Customer()
        {

        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string CompanyName { get;
            set; }

        public Address HomeAddress { get; set; }

        public Address BillingAddress { get; set; }

        //[Required]
        //[StringLength(100)]
        //public string Name { get; set; }

        [StringLength(50)]
        public string CellPhone { get; set; }

        [StringLength(50)]
        public string WorkPhone { get; set; }

        [StringLength(50)]
        public string MainPhone { get; set; }

        [StringLength(50)]
        public string HomePhone { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        //public List<ServiceCall> ServiceCalls { get; set; }

        [NotMapped]
        public string DisplayName
        {
            get { return FullName(); }
        }

        #region IModificationHistory

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsDirty { get; set; }

        #endregion

        public string FullName()
        {
            string fullName = "";

            if (! String.IsNullOrEmpty(CompanyName))
            {
                fullName = CompanyName;
            }
            else
            {
                fullName = (! String.IsNullOrEmpty(Title) ? Title + " " : "");
                fullName += (! String.IsNullOrEmpty(FirstName) ? FirstName + " " : "");
                fullName += (!String.IsNullOrEmpty(LastName) ? LastName + " " : "");
            }

            return fullName;
        }
    }
}
