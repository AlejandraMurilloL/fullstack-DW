using System;
using System.Collections.Generic;

namespace DW.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
