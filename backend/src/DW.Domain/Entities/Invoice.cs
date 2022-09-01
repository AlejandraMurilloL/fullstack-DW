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

        public int CustomerId { get; internal set; }
        public int Num { get; internal set; }
        public DateTime Date { get; internal set; }
        public double Total { get; internal set; }

        public virtual Customer Customer { get; internal set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public Invoice WithInvoiceNumber(Invoice lastFactura)
        {
            if (lastFactura == null)
            {
                Num = 1;
                return this;
            }

            Num = lastFactura.Num++;
            return this;
        }

        public Invoice WithCurrentDate()
        {
            Date = DateTime.Now;
            return this;
        }
    }
}
