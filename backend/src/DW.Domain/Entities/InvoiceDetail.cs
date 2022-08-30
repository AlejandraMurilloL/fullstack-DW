using System;
using System.Collections.Generic;

namespace DW.Domain.Entities
{
    public class InvoiceDetail : BaseEntity
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
