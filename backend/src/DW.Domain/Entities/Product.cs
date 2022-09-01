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

        public int CategoryId { get; internal set; }
        public string Name { get; internal set; }
        public double Price { get; internal set; }
        public int Stock { get; internal set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public Product SubtractStock(int quantity)
        {
            Stock -= quantity;
            return this;
        }
    }
}
