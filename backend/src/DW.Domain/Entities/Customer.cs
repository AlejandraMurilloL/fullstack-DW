using System;
using System.Collections.Generic;

namespace DW.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Phone { get; internal set; }
        public string IdentificationDocument { get; internal set; }
        public string Adress { get; internal set; }
        public string Email { get; internal set; }
        public DateTime? DateOfBirth { get; internal set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
