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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string IdentificationDocument { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
