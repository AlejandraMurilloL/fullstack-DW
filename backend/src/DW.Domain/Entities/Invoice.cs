using System;
using System.Collections.Generic;

namespace DW.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int CustomerId { get; set; }
        public int Num { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
